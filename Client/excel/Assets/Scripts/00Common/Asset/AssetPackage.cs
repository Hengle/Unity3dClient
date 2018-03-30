using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameClient;

public class AssetArchive
{
    public string m_FullPath = null;
    public string m_HashName = null;
}

public enum AssetPackageState
{
    Unload,
    Loading,
    Loaded,
}

[System.Serializable]
public class AssetPackage
{
    [SerializeField]
    protected string m_BundlePath;
    [SerializeField]
    protected string m_BundleName;
    [SerializeField]
    protected string m_BundleFullPath;
    [SerializeField]
    protected string m_BundleHotfixPath;

    [SerializeField]
    protected List<AssetPackage> m_DependencyList = new List<AssetPackage>();
    //protected List<AssetArchive> m_AssetArchiveList = new List<AssetArchive>();

    [SerializeField]
    protected uint m_PackageFlag;
    [SerializeField]
    protected int m_PackageSize = 0;
    [SerializeField]
    protected long m_cbBytes = 0;

    [System.NonSerialized]
    protected AssetBundle m_AssetBundle = null;
    [System.NonSerialized]
    protected AssetPackageState m_PackageState;
    [System.NonSerialized]
    protected int m_DenpendentRefCnt = 0;

    protected struct AssetItem
    {
        public int assetInstID;
        public bool isGameObjAsset;
    }

    [System.NonSerialized]
    protected List<AssetItem> m_LoadedAssetList = new List<AssetItem>();
    [System.NonSerialized]
    protected int m_AssetResCount = 0;

    [System.NonSerialized]
    protected bool m_LoadAsDependent = true;/// 必须为true
    [System.NonSerialized]
    protected bool m_DependentLoaded = false;

    #region Async load
    [System.NonSerialized]
    //protected IAssetPackageRequest m_AssetBundleRequest = null;
    protected IAsyncLoadRequest<AssetBundle> m_AssetBundleRequest = null;

    // protected class AssetAsyncLoadCommand
    // {
    //     public string m_AssetName;
    //     public System.Type m_AssetType;
    //     public string m_SubRes;
    // }
    // 
    // protected List<AssetAsyncLoadCommand> m_AssetAsyncLoadCommandList = new List<AssetAsyncLoadCommand>();
    // protected List<AssetAsyncLoadCommand> m_AssetAsyncIdleCommandList = new List<AssetAsyncLoadCommand>();

    // protected AssetAsyncLoadCommand _AllocAsyncLoadCommand()
    // {
    //     if(m_AssetAsyncIdleCommandList.Count > 0)
    //     {
    //         int lastIdx = m_AssetAsyncIdleCommandList.Count - 1;
    //         AssetAsyncLoadCommand idleCommand = m_AssetAsyncIdleCommandList[lastIdx];
    //         m_AssetAsyncIdleCommandList.RemoveAt(lastIdx);
    //         return idleCommand;
    //     }
    // 
    //     return new AssetAsyncLoadCommand();
    // }

    public void UpdateAsyncPackageLoad()
    {
        if (null != m_AssetBundleRequest)
        {
            if (m_AssetBundleRequest.IsDone())
            {
                m_AssetBundle = m_AssetBundleRequest.Extract();
                m_AssetBundleRequest = null;
            }
        }
    }

    public void UpdateAsyncAssetLoad()
    {
        if (!IsPackageLoadFinish(false))
            return;

        // if(null == m_AssetBundle)
        // {
        //     LogManager.Instance().LogErrorFormat("AssetBundle has been unload!");
        //     return;
        // }
        // 
        // for(int i = 0,icnt = m_AssetAsyncLoadCommandList.Count;i<icnt;++i)
        // {
        //     AssetAsyncLoadCommand curCommand = m_AssetAsyncLoadCommandList[i];
        //     if(null != curCommand && null != curCommand.m_AssetResquestWrapper)
        //     {
        //         curCommand.m_AssetResquestWrapper.m_OnExtractCallback = _OnAsyncExtractCallback;
        //         curCommand.m_AssetResquestWrapper.m_AssetBundle = m_AssetBundle;
        //         //curCommand.m_AssetResquestWrapper.DoLoad(curCommand.m_AssetName, curCommand.m_AssetType, curCommand.m_SubRes);
        //     }
        // 
        //     if(null != curCommand)
        //     {
        //         curCommand.m_AssetName = null;
        //         curCommand.m_AssetType = null;
        //         curCommand.m_SubRes = null;
        // 
        //         m_AssetAsyncIdleCommandList.Add(curCommand);
        //     }
        // }
        // 
        // if (m_AssetAsyncLoadCommandList.Count > 0)
        //     m_AssetAsyncLoadCommandList.Clear();
    }

    #endregion

    public bool Init(string bundlePath, string bundleName, AssetPackage[] dependency, DPackAssetDesc[] assets, uint packageFlag)
    {
        if (string.IsNullOrEmpty(bundleName) || string.IsNullOrEmpty(bundlePath))
        {
            LogManager.Instance().LogErrorFormat( "Package bundle must has a name and path!");
            return false;
        }

        m_BundleName = bundleName.ToLower();
        m_BundlePath = bundlePath;
        m_PackageFlag = packageFlag;
        m_BundleFullPath = Path.Combine(m_BundlePath, m_BundleName);
        m_BundleHotfixPath = Path.Combine(Path.Combine(m_BundlePath,"hotfix"), m_BundleName);

        if (null != dependency)
        {
            m_DependencyList.AddRange(dependency);
            //for (int i = 0; i < dependency.Length; ++i)
            //{
            //    if (null != dependency[i])
            //        m_DependencyList.Add(dependency[i]);
            //}
        }

        //for (int i = 0; i < assets.Length; ++i)
        //{
        //    AssetArchive newArchive = new AssetArchive();
        //    newArchive.m_FullPath = assets[i].packageAsset;
        //    newArchive.m_HashName = assets[i].packageGUID;
        //    m_AssetArchiveList.Add(newArchive);
        //}

        return true;
    }

    public bool ReloadPackage( bool isDependent = false)
    {
        if (!isDependent && !m_DependentLoaded)
        {
            for (int i = 0; i < m_DependencyList.Count; ++i)
            {
                if (null != m_DependencyList[i])
                {
                    if (this == m_DependencyList[i] || m_BundleName == m_DependencyList[i].m_BundleName)
                        continue;

                    /// 2017-04-07 这种写法有点问题 改成下面的写法
                    //if (AssetPackageManager.Instance().LoadPackage(m_DependencyList[i], bAsync, true))
                    //    m_DependencyList[i].AddDependentRef();

                    AssetPackageManager.Instance().LoadPackage(m_DependencyList[i], true);
                    m_DependencyList[i].AddDependentRef();
                }
            }

            m_DependentLoaded = true;
        }

        /// 2017-04-07 这种写法有点问题 改成下面的写法
        m_LoadAsDependent = isDependent & m_LoadAsDependent;

        if (null != m_AssetBundle)
        {
            m_PackageState = AssetPackageState.Loaded;
            return true;
        }

        /// 2017-04-07 这种写法有点问题 改成下面的写法
        //m_LoadAsDependent = isDependent & m_LoadAsDependent;
        m_PackageState = AssetPackageState.Loading;
        m_AssetBundle = AssetPackageLoader.instance.LoadPackage(this);

        if (null != m_AssetBundle)
        {
            m_PackageState = AssetPackageState.Loaded;
            return true;
        }
        else
        {
            m_PackageState = AssetPackageState.Unload;
            return false;
        }
    }

    public bool IsPackageNeedLoad(bool isDependent = false)
    {
        if(!isDependent)
        {
            return !m_DependentLoaded;
        }
        else
        {
            return null != m_AssetBundle;
        }
    }

    public bool IsPackageLoadFinish(bool asDependent)
    {
        if (!asDependent)
        {
            for (int i = 0, icnt = m_DependencyList.Count; i < icnt; ++i)
            {
                if (null != m_DependencyList[i])
                {
                    if (this == m_DependencyList[i] || m_BundleName == m_DependencyList[i].m_BundleName)
                        continue;

                    if (!m_DependencyList[i].IsPackageLoadFinish(true))
                        return false;
                }
            }
        }

        return null != m_AssetBundle;
    }

    public void ReloadPackageAsync(bool isDependent = false)
    {
        if (!isDependent && !m_DependentLoaded)
        {
            for (int i = 0; i < m_DependencyList.Count; ++i)
            {
                if (null != m_DependencyList[i])
                {
                    if (this == m_DependencyList[i] || m_BundleName == m_DependencyList[i].m_BundleName)
                        continue;

                    AssetPackageManager.Instance().LoadPackageAsync(m_DependencyList[i], true);
                    m_DependencyList[i].AddDependentRef();
                }
            }
            
            m_DependentLoaded = true;
        }

        m_LoadAsDependent = isDependent & m_LoadAsDependent;
        if (null != m_AssetBundle)
        {
            m_PackageState = AssetPackageState.Loaded;
        }
        else
        {
            //m_AssetBundleRequest = AssetPackageLoader.Instance().LoadPackageAsync(this);
            m_AssetBundleRequest = AssetPackageLoader.instance.LoadPackageAsync(this);
            m_PackageState = AssetPackageState.Loading;
        }
    }

    public void UnloadPackage(bool bUnloadAllAsset = false)
    {
        //AssetPackageLoader.Instance().UnloadPackage(this, bFroceUnload);
        LogManager.Instance().LogErrorFormat( "Unloading package \"{0}\"!", m_BundleName);

        if(null != m_AssetBundleRequest)
        {
            m_AssetBundleRequest.Abort();
            m_AssetBundleRequest = null;
        }

        if (!m_LoadAsDependent && m_DependentLoaded)
        {
            for (int i = 0; i < m_DependencyList.Count; ++i)
            {
                if (null != m_DependencyList[i] && this != m_DependencyList[i])
                    m_DependencyList[i].RemoveDependentRef();
            }

            m_DependentLoaded = false;
        }
        

        if (null != m_AssetBundle)
            m_AssetBundle.Unload(bUnloadAllAsset);
        
        m_PackageState = AssetPackageState.Unload;
        m_AssetBundle = null;
        m_LoadAsDependent = true;
    }

    public UnityEngine.Object LoadResFromPackage(string resName,System.Type type,bool bAsync = false,string subRes = "")
    {
        float lastTimeMS = Time.realtimeSinceStartup * 1000.0f;
        AssetPackageManager.Instance().LoadPackage(this);
        lastTimeMS = Time.realtimeSinceStartup * 1000.0f - lastTimeMS;
        LogManager.Instance().LogErrorFormat("#### Load dependent bundle for package {0} with {1}!", m_BundleName, lastTimeMS);

        if (null != m_AssetBundle)
        {
            int nameIdx = resName.LastIndexOf('/');
            if (0 <= nameIdx && nameIdx < resName.Length)
                resName = resName.Substring(nameIdx + 1).ToLower();

            UnityEngine.Object assetOut = null;
            if (type == typeof(Sprite))
            {
                Sprite[] spriteArray = m_AssetBundle.LoadAssetWithSubAssets<Sprite>(CFileManager.EraseExtension(resName));
                for (int i = 0; i < spriteArray.Length; ++i)
                {
                    if (spriteArray[i].name == subRes)
                        assetOut = spriteArray[i];
                }
            }

            if (null == assetOut)
            {
                lastTimeMS = Time.realtimeSinceStartup * 1000.0f;
                assetOut = m_AssetBundle.LoadAsset(resName, type);
                lastTimeMS = Time.realtimeSinceStartup * 1000.0f - lastTimeMS;
                LogManager.Instance().LogErrorFormat("#### Load Res {0} from package {1} with {2}!", resName, m_BundleName, lastTimeMS);
            }

            if (null != assetOut)
            {
                // if(typeof(GameObject) == type && CanUnload())
                //     UnloadPackage();
                // else
                // {
                //     if (!m_LoadedAssetList.Contains(assetOut.GetInstanceID()))
                //         m_LoadedAssetList.Add(assetOut.GetInstanceID());
                //     else
                //         LogManager.Instance().LogErrorFormat("Asset \"{0}\" has be loaded multiple times, Maybe there is bug in asset load system!", resName);
                // }

                bool isGameObjAsset = assetOut is GameObject;
                _AddAssetRecord(assetOut.GetInstanceID(), isGameObjAsset, resName);
                if (isGameObjAsset && 0 == m_AssetResCount && m_DenpendentRefCnt <= 0)
                {
                    AssetPackageManager.Instance().AddHoldPackage(this);
                    //if (null != m_AssetBundle)
                    //{
                    //    m_AssetBundle.Unload(false);
                    //    m_AssetBundle = null;
                    //}
                }
            }

            return assetOut;
        }

        return null;
    }

    void _AddAssetRecord(int instID,bool isGameObj,string resName)
    {
        for(int i = 0,icnt = m_LoadedAssetList.Count;i<icnt;++i)
        {
            if(m_LoadedAssetList[i].assetInstID == instID)
            {
                LogManager.Instance().LogErrorFormat("Asset \"{0}\" has be loaded multiple times, Maybe there is bug in asset load system!", resName);
                return;
            }
        }

        AssetItem newItem = new AssetItem();
        newItem.assetInstID = instID;
        newItem.isGameObjAsset = isGameObj;
        m_LoadedAssetList.Add(newItem);

        if (!isGameObj)
            ++m_AssetResCount;
    }

    void _RemoveAssetRecord(int instID)
    {
        for (int i = 0, icnt = m_LoadedAssetList.Count; i < icnt; ++i)
        {
            if (m_LoadedAssetList[i].assetInstID == instID)
            {
                if (!m_LoadedAssetList[i].isGameObjAsset)
                    --m_AssetResCount;

                m_LoadedAssetList.RemoveAt(i);
                return;
            }
        }
    }

    protected void _OnAsyncExtractCallback(UnityEngine.Object asset,string resName)
    {
        if (null != asset)
        {
            //if (asset is GameObject && CanUnload())
            //    UnloadPackage();
            //else
            //{
            //    if (!m_LoadedAssetList.Contains(asset.GetInstanceID()))
            //    {
            //        m_LoadedAssetList.Add(asset.GetInstanceID());
            //    }
            //    else
            //        LogManager.Instance().LogErrorFormat("Asset \"{0}\" has be loaded multiple times, Maybe there is bug in asset load system!", resName);
            //}

            bool isGameObjAsset = asset is GameObject;
            _AddAssetRecord(asset.GetInstanceID(), isGameObjAsset, resName);
            if(isGameObjAsset && 0 == m_AssetResCount && m_DenpendentRefCnt <= 0)
            {
                //if (null != m_AssetBundle)
                //{
                //    m_AssetBundle.Unload(false);
                //    m_AssetBundle = null;
                //}

                AssetPackageManager.Instance().AddHoldPackage(this);
            }
        }
    }

    public IAsyncLoadRequest<UnityEngine.Object> LoadResFromPackageAsync(string resName, System.Type type, string subRes = "")
    {
        //AssetPackageManager.Instance().LoadPackageAsync(this);
        LogManager.Instance().LogErrorFormat("#### Async load dependent bundle for package {0}!", m_BundleName);
        AssetPackageManager.Instance().LoadPackage(this);

        return AsyncLoadTaskAllocator<AssetBundleResquestWrapper, UnityEngine.Object>.Instance().AllocAsyncTask(resName, new AssetBundleResquestData(type, subRes, this, _OnAsyncExtractCallback));
        // AssetAsyncLoadCommand newAsyncLoadCommand = _AllocAsyncLoadCommand();
        // if (null != newAsyncLoadCommand)
        // {
        //     newAsyncLoadCommand.m_SubRes = subRes;
        //     newAsyncLoadCommand.m_AssetName = resName;
        //     newAsyncLoadCommand.m_AssetType = type;
        //     m_AssetAsyncLoadCommandList.Add(newAsyncLoadCommand);
        //     return AsyncLoadTaskAllocator<AssetBundleResquestWrapper, UnityEngine.Object>.Instance().AllocAsyncTask(resName, new AssetBundleResquestData(type, subRes,this,_OnAsyncExtractCallback));
        //     //return AssetAsyncTaskAllocator<AssetPackageResRequest>.Instance().AllocAsyncTask(resName, type,subRes, out newAsyncLoadCommand.m_AssetResquestWrapper);
        // }
        // else
        //     return AsyncLoadTaskAllocator<AssetBundleResquestWrapper, UnityEngine.Object>.INVALID_LOAD_REQUEST;
    }

    public void UnloadAsset(int assetInstID)
    {
        //m_LoadedAssetList.Remove(assetInstID);

        //for (int i = 0; i < m_LoadedAssetList.Count; ++i)
        //    LogManager.Instance().LogErrorFormat("   Asset {0} in package {1}", m_LoadedAssetList[i],m_BundleName);

        _RemoveAssetRecord(assetInstID);
    }

    public bool CanUnload()
    {
        //         if(DAssetPackageFlag.LeaveWithAsset == m_PackageFlag)
        //         {
        //             return 0 == m_AssetLoadedCnt;
        //         }
        // 
        //         return true;
        return 0 == m_LoadedAssetList.Count && 0 >= m_DenpendentRefCnt;
    }

    /// <summary>
    /// 外部不要调用
    /// </summary>
    public void UnloadBundle()
    {
        if (null != m_AssetBundle)
        {
            m_AssetBundle.Unload(false);
            m_AssetBundle = null;
        }
    }

    public void AddDependentRef()
    {
        ++m_DenpendentRefCnt;
        LogManager.Instance().LogErrorFormat("AssetBundle [{0}] add reference count to {1}", m_AssetBundle, m_DenpendentRefCnt);
    }

    public void RemoveDependentRef()
    {
        --m_DenpendentRefCnt;
        LogManager.Instance().LogErrorFormat("AssetBundle [{0}] release reference count to {1}", m_AssetBundle, m_DenpendentRefCnt);
        if (m_DenpendentRefCnt < 0)
            LogManager.Instance().LogErrorFormat( "AssetBundle [{0}] released count is more than created count", m_BundleName);
    }

    public string packageFullPath
    {
        get
        {
            return m_BundleFullPath;
        }
    }
    public string packageHotfixPath
    {
        get
        {
            return m_BundleHotfixPath;
        }
    }

    public string packageName
    {
        get { return m_BundleName; }
    }

    protected bool _IsResInNative(string resPath)
    {
        return false;
    }

    protected bool _IsResInServer(string resPath)
    {
        return false;
    }
    protected string _GetServerResourcePath()
    {
        return "";
    }

    protected string _GetNativeResourcePath()
    {
        return "";
    }

    public long packageBytes
    {
        get
        {
            return m_cbBytes;
        }
    }

    public bool usingHashName
    {
        get
        {
            return (m_PackageFlag & (uint)DAssetPackageFlag.UsingGUIDName) != 0;
        }
    }

    public AssetPackage[] dependPackages
    {
        get
        {
            return m_DependencyList.ToArray();
        }
    }

    public int[] loadAssetHashes
    {
        get
        {
            int[] hash = new int[m_LoadedAssetList.Count];
            for (int i = 0, icnt = m_LoadedAssetList.Count; i < icnt; ++i)
                hash[i] = m_LoadedAssetList[i].assetInstID;

            return hash;
        }
    }

    public int denpendentRefCnt
    {
        get { return m_DenpendentRefCnt; }
    }

    public bool packageLoaded
    {
        get { return null != m_AssetBundle; }
    }

    public AssetBundle assetBundle
    {
        get { return m_AssetBundle; }
    }
}


