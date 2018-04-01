using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameClient;

public enum AssetLoadFlag
{
    None = 0x00,
    HideAfterLoad = 0x01,
}

public class AssetLoader : Singleton<AssetLoader>
{
    static public readonly uint INVILID_HANDLE = ~0u;

    protected int m_QureyCnt = 0;
    protected readonly int QUREY_STEP = 4;

    #region 方法

    /// <summary>
    /// 加载资源
    ///     对于Prefab类型资源，会自动实例化Prefab到GameObject。
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="type">资源类型（Sprite,Texture2D等静态资源需要传入类型以正确加载资源）</param>
    /// <param name="isMustExist">必须存在 为True在资源不存在时将报错</param>
    /// <returns>资源实例</returns>
    public AssetInst LoadRes(string path,System.Type type,bool isMustExist = true,uint flag = 0u)
    {
#if UNITY_EDITOR
        _ValidResPath(path);
#endif
        //LogManager.Instance().LogErrorFormat("Begin load resource from Path:" + path);
        _TickAutoPurgeCnt();

        AssetDesc assetDesc = null;
        if (_GetCachedAssetDesc(path, type,out assetDesc))
        {/// GameObject 和静态资源分开管理。
            if (null != assetDesc)
                return assetDesc.CreateRefInst();
            else
                _RemoveCacheAssetDesc(path,type);
        }

        string mainRes, subRes;
        _ParseAssetPath(path, out mainRes, out subRes);

        {
            /// 检查正在创建的AssetDesc
            //if(AssetAsyncTaskAllocator<AssetResourceRequest>.Instance().IsAssetInAsyncLoading(path))
            if(AsyncLoadTaskAllocator<ResourceRequestWrapper, UnityEngine.Object>.Instance().IsResInAsyncLoading(path))
            {
#if UNITY_EDITOR
                LogManager.Instance().LogErrorFormat("Async load task is already exist,sync load has failed![res:{0}]", path);
#else
                LogManager.Instance().LogWarningFormat("Async load task is already exist,sync load has failed![res:{0}]", path);
#endif
                return null;
            }
        }

        /// 创建新的AssetDesc
        assetDesc = new AssetDesc();
        if(assetDesc.Init(mainRes, type, subRes))
        {
            _RecordLoadFile(path);
            _AddCachedAssetDesc(path, type, assetDesc);
            return assetDesc.CreateRefInst();
        }
        else
        {
            if(isMustExist)
                LogManager.Instance().LogErrorFormat("Can not instantiate asset with path \"{0}\"!", path);
            return null;
        }
    }

    public AssetInst LoadRes(string path, bool isMustExist = true,uint flag = 0u)
    {
        return LoadRes(path,typeof(UnityEngine.Object), isMustExist,flag);
    }

    /// <summary>
    /// 加载GameObject资源LoadRes的便捷方式
    /// </summary>
    /// <param name="path">Prefab路径</param>
    /// <param name="isMustExist">必须存在 为True在资源不存在时将报错</param>
    /// <returns>实例化后GameObject</returns>
    public GameObject LoadResAsGameObject(string path,bool isMustExist = true,uint flag = 0u)
    {
        var inst = LoadRes(path, typeof(GameObject) ,isMustExist,flag);

        if(inst == null)
        {
            LogManager.Instance().LogErrorFormat( "{0} path do not exist!",path);
            return null;
        }

        if(inst.obj == null)
        {
            LogManager.Instance().LogErrorFormat("{0} path Contain Empty Object!",path);
            return null;
        }

        GameObject obj =  inst.obj as GameObject;

        if(obj == null)
        {
            LogManager.Instance().LogErrorFormat("{0} path Contain Error Object,{1}",path,inst.obj.GetType().Name);
        }
        
        return obj;
    }

    /// <summary>
    /// 加载资源
    ///     对于Prefab类型资源，会自动实例化Prefab到GameObject。
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="type">资源类型（Sprite,Texture2D等静态资源需要传入类型以正确加载资源）</param>
    /// <param name="callback">资源加载完成回调</param>
    /// <param name="isMustExist">必须存在 为True在资源不存在时将报错</param>
    /// <returns>资源实例</returns>
    public uint LoadResAync(string path, System.Type type, bool isMustExist = true,uint flag = 0u, uint waterMark = 0x0)
    {
#if UNITY_EDITOR
        _ValidResPath(path);
#endif
        if (string.IsNullOrEmpty(path))
            return INVILID_HANDLE;

        IAssetInstRequest assetRequest = _LoadResAync(path, type, isMustExist, flag,waterMark);
        if (null != assetRequest)
        {
            return m_AsyncRequestAllocator.AddAsyncRequest(assetRequest);
        }
        else
            LogManager.Instance().LogErrorFormat("Async load asset [{0}] has failed!", path);

        return INVILID_HANDLE;
    }

    /// <summary>
    /// 加载GameObject资源LoadRes的便捷方式
    /// </summary>
    /// <param name="path">Prefab路径</param>
    /// <param name="isMustExist">必须存在 为True在资源不存在时将报错</param>
    /// <returns>实例化后GameObject</returns>
    public uint LoadResAsyncAsGameObject(string path, bool isMustExist = true,uint flag = 0u, uint waterMark = 0x0)
    {
        return LoadResAync(path, typeof(GameObject), isMustExist,flag,waterMark);
    }

    public bool IsRequestDone(uint handle)
    {
        IAssetInstRequest request = m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle);
        if (null != request)
            return request.IsDone();
        else
        {
            LogManager.Instance().LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", handle.ToString("x"));
#if UNITY_EDITOR
            Debug.DebugBreak();
#endif
        }

        return false;
    }

    public void AbortRequest(uint handle)
    {
        IAssetInstRequest request = m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle);
        if (null != request)
        {
            m_AsyncRequestAllocator.RemoveAsyncRequest(handle);
            request.Abort();
        }
        else
            LogManager.Instance().LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", handle.ToString("x"));
    }

    public AssetInst Extract(uint handle)
    {
        IAssetInstRequest request = m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle);
        if (null != request)
        {
            if (request.IsDone())
            {
                m_AsyncRequestAllocator.RemoveAsyncRequest(handle);
                return request.Extract();
            }
        }
        else
            LogManager.Instance().LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", handle.ToString("x"));

        return null;
    }

    public bool IsValidHandle(uint handle)
    {
        IAssetInstRequest request = m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle);
        if (null == request)
        {
            LogManager.Instance().LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", handle.ToString("x"));
            return false;
        }
        else
            return true;
    }

    public void SetPurgeTime(float timeLen)
    {
        m_PurgeTime = timeLen;
    }

    public void SetAutoPurgeCount(int cnt)
    {
        m_AutoPurgeCnt = cnt;
    }

    public void ResetPurgeTick()
    {
        m_CurPurgeCnt = 0;
    }

    public void PurgeUnusedRes(bool ignoreTime = false,Type type = null)
    {

        Dictionary<string, List<AssetInfo>>.Enumerator enumerator = m_ResDescCacheTableEx.GetEnumerator();

        //List<string> deleteKeyList = new List<string>();
        List<AssetDelKey> deleteKeyList = GamePool.ListPool<AssetDelKey>.Get();// new List<string>();
        while (enumerator.MoveNext())
        {
            List<AssetInfo> value = enumerator.Current.Value;
            if (null == value) continue;
            for (int i = 0, icnt = value.Count; i < icnt; ++i)
            {
                AssetInfo curInfo = value[i];
                if (null == curInfo || null == curInfo.m_AssetDesc) continue;

                if (null != type && type != curInfo.m_AssetDesc.assetType)
                    continue;

                if (curInfo.m_AssetDesc.CanBeRemoved())
                {
                    if (ignoreTime || curInfo.m_AssetDesc.lastUseTime > m_PurgeTime)
                    {
                        curInfo.m_AssetDesc.Deinit();
                        AssetDelKey delKey = new AssetDelKey();
                        delKey.path = enumerator.Current.Key;
                        delKey.type = curInfo.m_AssetType;
                        deleteKeyList.Add(delKey);
                    }
                }
            }
        }

        for (int i = 0; i < deleteKeyList.Count; ++i)
            _RemoveCacheAssetDesc(deleteKeyList[i].path, deleteKeyList[i].type);

        GamePool.ListPool<AssetDelKey>.Release(deleteKeyList);
    }

    public void ClearAll(bool force = false)
    {
        Dictionary<string, List<AssetInfo>>.Enumerator enumerator = m_ResDescCacheTableEx.GetEnumerator();

        //List<string> deleteKeyList = new List<string>();
        List<AssetDelKey> deleteKeyList = GamePool.ListPool<AssetDelKey>.Get();// new List<string>();
        while (enumerator.MoveNext())
        {
            List<AssetInfo> value = enumerator.Current.Value;
            if(null == value) continue;
            for(int i = 0,icnt = value.Count;i<icnt;++i)
            {
                AssetInfo curInfo = value[i];
                if (null == curInfo || null == curInfo.m_AssetDesc) continue;

                if(curInfo.m_AssetDesc.CanBeRemoved())
                {
                    curInfo.m_AssetDesc.Deinit();
                    AssetDelKey delKey = new AssetDelKey();
                    delKey.path = enumerator.Current.Key;
                    delKey.type = curInfo.m_AssetType;
                    deleteKeyList.Add(delKey);
                }
                else
                {
                    if (force)
                    {
                        LogManager.Instance().LogErrorFormat("Asset [{0}] is under using!", curInfo.m_AssetDesc.m_FullPath);

                        curInfo.m_AssetDesc.Deinit();
                        AssetDelKey delKey = new AssetDelKey();
                        delKey.path = enumerator.Current.Key;
                        delKey.type = curInfo.m_AssetType;
                        deleteKeyList.Add(delKey);
                    }
                }
            }
        }

        for (int i = 0; i < deleteKeyList.Count; ++i)
            _RemoveCacheAssetDesc(deleteKeyList[i].path, deleteKeyList[i].type);

        GamePool.ListPool<AssetDelKey>.Release(deleteKeyList);
    }

#endregion

#region 私有方法

    public void Initialize()
    {
        AssetAsyncLoader.instance.Init();

#if UNITY_EDITOR
        m_DumpFile = "ResLoadRecord/FileLoadTrace_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + ".rec";
        string dumpFileDir = Path.Combine(Application.streamingAssetsPath,Path.GetDirectoryName(m_DumpFile));
        if (Directory.Exists(dumpFileDir))
            Directory.CreateDirectory(dumpFileDir);
#endif
    }

    void _ParseAssetPath(string assetPath,out string mainRes,out string subRes)
    {
        string[] assetKeys = assetPath.Split(':');
        if (assetKeys.Length > 1)
        {
            subRes = assetKeys[1];
            mainRes = assetKeys[0];
        }
        else
        {
            subRes = "";
            mainRes = assetPath;
        }
    }

    public IAssetInstRequest _LoadResAync(string path, System.Type type, bool isMustExist = true,uint flag = 0u, uint waterMark = 0x0)
    {
        _TickAutoPurgeCnt();
        AssetInstRequest instReq = null;
        AssetDesc assetDesc = null;
        if (_GetCachedAssetDesc(path, type, out assetDesc))
        {/// GameObject 和静态资源分开管理。
            instReq = _AllocAssetInstRequest();
            instReq.m_AssetInst = assetDesc.CreateRefInst(flag);
            instReq.m_IsDone = true;
            instReq.m_HasExtract = false;
            instReq.m_flag = flag;
            instReq.m_waterMark = waterMark;

            m_CompletedReqList.Add(instReq);
            return instReq;
        }

        string mainRes, subRes;
        _ParseAssetPath(path, out mainRes, out subRes);

        /// 检查正在创建的AssetDesc
        for (int i = 0; i < m_AsyncLoadTaskList.Count; ++i)
        {
            AsyncLoadTaskDesc curTask = m_AsyncLoadTaskList[i];
            if (path == curTask.m_ResPath && type == curTask.m_ResType)
            {
                instReq = _AllocAssetInstRequest();
                instReq.m_flag = flag;
                instReq.m_waterMark = waterMark;
                curTask.m_WaitingReqList.Add(instReq);
                return instReq;
            }
        }

        /// 创建新的AssetDesc
        _RecordLoadFile(path);
        assetDesc = new AssetDesc();
        assetDesc.InitAsync(path, type, subRes);
        AsyncLoadTaskDesc newAsyncTask = new AsyncLoadTaskDesc();
        newAsyncTask.m_AssetDesc = assetDesc;
        newAsyncTask.m_ResPath = path;
        newAsyncTask.m_ResType = type;
        instReq = _AllocAssetInstRequest();
        instReq.m_flag = flag;
        instReq.m_waterMark = waterMark;
        newAsyncTask.m_WaitingReqList.Add(instReq);

        m_AsyncLoadTaskList.Add(newAsyncTask);
        return instReq;
        /*

        _TickAutoPurgeCnt();
        AssetInstRequest instReq = null;
        AssetDesc assetDesc = null;

        string mainRes, subRes;
        _ParseAssetPath(path, out mainRes, out subRes);

        /// 检查正在创建的AssetDesc
        for (int i = 0; i < m_AsyncLoadTaskList.Count; ++i)
        {
            AsyncLoadTaskDesc curTask = m_AsyncLoadTaskList[i];
            if (path == curTask.m_ResPath && type == curTask.m_ResType)
            {
                instReq = _AllocAssetInstRequest();				
            	instReq.m_flag = flag;
                curTask.m_WaitingReqList.Add(instReq);
                return instReq;
            }
        }


        if (_GetCachedAssetDesc(path, type, out assetDesc))
        {            
            assetDesc.SetHolding(true);
            if(null == assetDesc || null == assetDesc.m_AssetObjRef)
            {
                _RemoveCacheAssetDesc(path, type);
                assetDesc = null;
            }
        }

        if(null == assetDesc)
        {
            /// 创建新的AssetDesc
            _RecordLoadFile(path);
            assetDesc = new AssetDesc(); 
            assetDesc.InitAsync(path, type, subRes);  
        }        
        AsyncLoadTaskDesc newAsyncTask = new AsyncLoadTaskDesc();
        newAsyncTask.m_AssetDesc = assetDesc;
        newAsyncTask.m_ResPath = path;
        newAsyncTask.m_ResType = type;
        instReq = _AllocAssetInstRequest();
		instReq.m_flag = flag;
        newAsyncTask.m_WaitingReqList.Add(instReq);

        m_AsyncLoadTaskList.Add(newAsyncTask);
        return instReq; 

*/
    }

    void _AddCachedAssetDesc(string path, System.Type type,AssetDesc assetDesc)
    {
        List<AssetInfo> assetInfoList = null;
        if (m_ResDescCacheTableEx.TryGetValue(path, out assetInfoList))
        {
            for (int i = 0, icnt = assetInfoList.Count; i < icnt; ++i)
            {
                AssetInfo assetInfo = assetInfoList[i];
                if (null == assetInfo) continue;

                if (assetInfo.m_AssetType == type)
                {
                    LogManager.Instance().LogErrorFormat("Multiple asset desc with path {0} and type {1}", path, type.Name);
                    return;
                }
            }

            assetInfoList.Add(new AssetInfo(type, assetDesc));
            return;
        }

        assetInfoList = new List<AssetInfo>();
        assetInfoList.Add(new AssetInfo(type, assetDesc));
        m_ResDescCacheTableEx.Add(path, assetInfoList);
    }

    void _RemoveCacheAssetDesc(string path,Type type)
    {
        List<AssetInfo> assetInfoList = null;
        if (m_ResDescCacheTableEx.TryGetValue(path, out assetInfoList))
        {
            for (int i = 0, icnt = assetInfoList.Count; i < icnt; ++i)
            {
                AssetInfo assetInfo = assetInfoList[i];
                if (null == assetInfo) continue;

                if (assetInfo.m_AssetType == type)
                {
                    assetInfoList.RemoveAt(i);
                    return;
                }
            }
        }

        Debug.LogErrorFormat("########################## Path:[{0}] Type:{1}", path, type);
    }

    bool _GetCachedAssetDesc(string path, System.Type type, out AssetDesc assetDesc)
    {
        assetDesc = null;
        List<AssetInfo> assetInfoList = null;
        if (m_ResDescCacheTableEx.TryGetValue(path, out assetInfoList))
        {
            for (int i = 0, icnt = assetInfoList.Count; i < icnt; ++i)
            {
                AssetInfo assetInfo = assetInfoList[i];
                if (null == assetInfo) continue;

                if (assetInfo.m_AssetType == type)
                {
                    assetDesc = assetInfo.m_AssetDesc;
                    return true;
                }
            }
        }

        return false;
    }

    //bool _GetCachedAssetDescEx(string path,System.Type type , out string resKey, out AssetDesc assetDesc)
    //{
    //    resKey = path + "(" + type.ToString() + ")";
    //    return m_ResDescCacheTable.TryGetValue(resKey, out assetDesc);
    //}

    //int CGCnt = 0;
    void _TickAutoPurgeCnt()
    {
        AssetGabageCollectorHelper.Instance().AddGCPurgeTick(AssetGCTickType.Asset);
        ///if(0 != m_AutoPurgeCnt)
        ///{
        ///    if (m_CurPurgeCnt >= m_AutoPurgeCnt)
        ///    {
        ///        //Debug.LogWarningFormat("Tick GC ...... {0}", CGCnt++);
        ///        AssetGabageCollector.Instance().ClearUnusedAsset();
        ///        m_CurPurgeCnt = 0;
        ///    }
        ///
        ///    ++ m_CurPurgeCnt;
        ///}
    }

#endregion

#region 变量

    //private DictionaryView<string, AssetDesc> m_ResDescCacheTable = new DictionaryView<string, AssetDesc>();
    class AssetInfo
    {
        public AssetInfo(Type type,AssetDesc desc)
        {
            m_AssetDesc = desc;
            m_AssetType = type;
        }

        public System.Type m_AssetType;
        public AssetDesc m_AssetDesc;
    }
    private Dictionary<string, List<AssetInfo>> m_ResDescCacheTableEx = new Dictionary<string, List<AssetInfo>>();

    struct AssetDelKey
    {
        public string path;
        public Type type;
    }


    private float m_PurgeTime = 30.0f; /// 默认清理时间设置为30秒
    private int m_AutoPurgeCnt = 0;
    private int m_CurPurgeCnt = 0;

#endregion

#region 异步加载状态管理

    protected List<AssetInstRequest> m_AssetInstReqPool = new List<AssetInstRequest>();
    protected List<AssetInstRequest> m_CompletedReqList = new List<AssetInstRequest>();

    protected class AsyncLoadTaskDesc
    {
        public AssetDesc m_AssetDesc;
        public string m_ResPath;
        public Type m_ResType;
        public List<AssetInstRequest> m_WaitingReqList = new List<AssetInstRequest>();
    }

    protected List<AsyncLoadTaskDesc> m_AsyncLoadTaskList = new List<AsyncLoadTaskDesc>();

    protected AssetInstRequest _AllocAssetInstRequest()
    {
        AssetInstRequest availableReq = null;
        if(m_AssetInstReqPool.Count > 0)
        {
            availableReq = m_AssetInstReqPool[0];
            m_AssetInstReqPool.RemoveAt(0);
        }

        if(null == availableReq)
            availableReq = new AssetInstRequest();

        availableReq.Reset();
        return availableReq;
    }

    protected void _Update()
    {
        //++m_QureyCnt;
        //if (m_QureyCnt >= QUREY_STEP)
        //    m_QureyCnt = 0;
        //else
        //    return;

        List<AssetInstRequest> reqCompleteList = null;
        for (int i = 0,icnt = m_AsyncLoadTaskList.Count;i<icnt;++i)
        {
            AsyncLoadTaskDesc cur = m_AsyncLoadTaskList[i];
            if(null == cur)
            {
                m_AsyncLoadTaskList.RemoveAt(i);
                break;
            }

            if (!cur.m_AssetDesc.CheckAsyncLoadComplete())
                continue;

            AssetDesc dummy = null;
            if (!_GetCachedAssetDesc(cur.m_ResPath, cur.m_ResType,out dummy))
                _AddCachedAssetDesc(cur.m_ResPath, cur.m_ResType, cur.m_AssetDesc);

            for (int j = 0,jcnt= cur.m_WaitingReqList.Count;j<jcnt;++j)
            {
                AssetInstRequest curReq = cur.m_WaitingReqList[j];
                if(null != curReq)
                {
                    if(!curReq.m_IsAbort)
                    {
                        curReq.m_AssetInst = cur.m_AssetDesc.CreateRefInst(curReq.m_flag);
                        curReq.m_IsDone = true;
                    }
                }
            }

            reqCompleteList = cur.m_WaitingReqList;
            m_AsyncLoadTaskList.RemoveAt(i);
            break;
        }

        int Step = 4;
        for(int i = 0,icnt = m_CompletedReqList.Count;i<icnt;++i)
        {
            AssetInstRequest curReq = m_CompletedReqList[i];
            if(null != curReq)
            {
                if(curReq.m_IsAbort)
                {
                    if(null != curReq.m_AssetInst && curReq.m_AssetInst.isGameObject)
                    {
                        //GameObject go = (curReq.m_AssetInst.obj as GameObject);
                        //if(null != go)
                        //    go.SetActive(true);

                        //#if UNITY_EDITOR
                        //                        LogManager.Instance().LogErrorFormat("AssetInstReq Destory:" + curReq.m_AssetInst.obj.name +  " " + curReq.m_waterMark.ToString("x"));
                        //#endif

                        GameObject.Destroy(curReq.m_AssetInst.obj);
                    }
                    curReq.Reset();
                    m_AssetInstReqPool.Add(curReq);
                    m_CompletedReqList.RemoveAt(i);
                    --i;
                    --icnt;
                    continue;
                }
                else
                {
                    if (!curReq.m_HasExtract)
                        continue;
                }

                --Step;
                curReq.Reset();
                m_AssetInstReqPool.Add(curReq);
            }

            m_CompletedReqList.RemoveAt(i);
            --i;
            --icnt;
            if(Step <= 0)
                break;
        }

        if (null != reqCompleteList)
            m_CompletedReqList.AddRange(reqCompleteList);
    }

    public void Update()
    {
        _Update();
    }

    public void DumpAssetInfo(ref List<string> assetList)
    {
        assetList.Clear();
        Dictionary<string, List<AssetInfo>>.Enumerator enumerator = m_ResDescCacheTableEx.GetEnumerator();

        //List<string> deleteKeyList = new List<string>();
        List<AssetDelKey> deleteKeyList = GamePool.ListPool<AssetDelKey>.Get();// new List<string>();
        while (enumerator.MoveNext())
        {
            List<AssetInfo> value = enumerator.Current.Value;
            if (null == value) continue;
            for (int i = 0, icnt = value.Count; i < icnt; ++i)
            {
                AssetInfo curInfo = value[i];
                if (null == curInfo || null == curInfo.m_AssetDesc) continue;

                AssetDesc val = curInfo.m_AssetDesc;
                string info = string.Format("{0} ({1}) Ref:{2}     [Key: {3}]", Path.GetFileNameWithoutExtension(val.m_FullPath), val.assetType.ToString(), val.GetRefCount(), enumerator.Current.Key);
                assetList.Add(info);
            }
        }
        GamePool.ListPool<AssetDelKey>.Release(deleteKeyList);
    }

#endregion

#region 异步加载句柄管理
    AsyncRequestHandleAllocator<IAssetInstRequest> m_AsyncRequestAllocator = new AsyncRequestHandleAllocator<IAssetInstRequest>(0);
#endregion

#region 辅助功能：资源加载统计
    
    string m_DumpFile = "ResLoadRecord/FileLoadTrace.rec";
    List<string> m_DumpBuf = new List<string>();
    int m_BufLineNum = 10;

    void _DumpToFile()
    {
        if (m_DumpBuf.Count <= 0)
            return;
#if UNITY_EDITOR
        if(!Directory.Exists(Path.Combine(Application.streamingAssetsPath, "ResLoadRecord")))
            Directory.CreateDirectory(Path.Combine(Application.streamingAssetsPath, "ResLoadRecord"));

        FileStream fs = new FileStream(Path.Combine(Application.streamingAssetsPath, m_DumpFile), FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.Flush();
        sw.BaseStream.Seek(0, SeekOrigin.End);
        for (int i = 0; i < m_DumpBuf.Count; ++i)
            sw.WriteLine(m_DumpBuf[i]);

        sw.Flush();
        sw.Close();
#endif

        m_DumpBuf.Clear();
    }

    void _RecordLoadFile(string file)
    {
        //TODO:DJM
        //if (!Global.Settings.recordResFile)
        return;

        if (m_DumpBuf.Count >= m_BufLineNum)
            _DumpToFile();

        m_DumpBuf.Add(file);
    }

    void _ValidResPath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return;

        if (path.Length != path.TrimEnd(' ').Length)
        {
            LogManager.Instance().LogErrorFormat("路径有问题：{0}！", path);
        }
    }

#endregion
}
