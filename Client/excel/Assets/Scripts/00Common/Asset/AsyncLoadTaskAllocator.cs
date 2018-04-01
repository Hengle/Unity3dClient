using UnityEngine;
using System.Collections.Generic;
using GameClient;


public interface IAsyncLoadRequest<T> where T:class
{
    bool IsDone();
    T Extract();
    string GetLoadPath();
    void Abort();

    bool IsValid();
}

/// <summary>
/// 异步加载：
///     异步加载模块返回该接口。 提供以下四个接口
/// </summary>
public class AsyncLoadRequest<T> : IAsyncLoadRequest<T> where T : class
{
    public T m_ResObject = null;

    public string m_ResPath = null;
    public bool m_IsDone = false;
    public bool m_Extracted = false;
    public bool m_IsAbort = false;
    public uint m_WaterMark = 0x0;


    /// <summary>
    /// 查询请求的资源知否加载完毕
    /// </summary>
    /// <returns>true为加载完毕</returns>
    public bool IsDone()
    {
        return m_IsDone;
    }

    public void Encase(T resObj)
    {
        m_IsDone = true;
        m_ResObject = resObj;
        m_Extracted = false;
    }


    /// <summary>
    /// 提取加载完成的资源，只能提取一次
    /// 注意：加载完毕的资源提取后，才会从加载列表中移除
    /// </summary>
    /// <returns>
    ///     返回加载目标资源
    /// </returns>
    public virtual T Extract()
    {
        if (!m_IsDone)
            return null;

        if (!m_Extracted)
        {
            T target = m_ResObject;
            m_ResObject = null;
            m_Extracted = true;

            //#if UNITY_EDITOR
            //            LogManager.Instance().LogErrorFormat("Extract AsyncLoadRequest<T>:" + m_ResPath + " " + m_WaterMark.ToString("x"));
            //#endif
            return target;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 获取目标资源的路径
    /// </summary>
    /// <returns></returns>
    public string GetLoadPath()
    {
        return m_ResPath;
    }

    /// <summary>
    /// 终止目标资源的异步加载过程
    /// 注意：调用后目标资源加载请求将从请求列表中移除
    /// </summary>
    public void Abort()
    {
//#if UNITY_EDITOR
//        LogManager.Instance().LogErrorFormat("Abort:" + m_ResPath + " " + m_WaterMark.ToString("x"));
//#endif
        m_IsAbort = true;
    }

    /// <summary>
    /// 该异步请求是否合法
    /// </summary>
    public bool IsValid()
    {
        return null != m_ResObject;
    }

    public void Reset()
    {
        m_ResObject = null;
        m_IsDone = false;
        m_Extracted = false;
        m_IsAbort = false;
        m_ResPath = null;
        m_WaterMark = 0x0;
    }

}

public enum AsyncLoadRequestType
{
    None,
    PackageResquest,
    PackageResResquest,
    ResourceRequest,
}

public class AsyncLoadTaskAllocator<T,Q> : Singleton<AsyncLoadTaskAllocator<T,Q>> 
    where T : class , IAsyncLoadWrapper<Q>, new()
    where Q : class
{
    static public readonly AsyncLoadRequest<Q> INVALID_LOAD_REQUEST = new AsyncLoadRequest<Q>();

    protected class AsyncLoadTask
    {
        public IAsyncLoadWrapper<Q> m_RequestWrapper = new T();
        public AsyncLoadRequest<Q> m_LoadRequest = new AsyncLoadRequest<Q>();
        public AsyncLoadData m_RequestData = null;
        public string m_AsyncLoadPath = null;
        public uint m_FrameCnt = 0;
    }

    List<AsyncLoadTask> m_AsyncLoadTaskQueue = new List<AsyncLoadTask>();
    List<AsyncLoadTask> m_CompleteTaskQueue = new List<AsyncLoadTask>();
    List<AsyncLoadTask> m_IdleTaskPool = new List<AsyncLoadTask>();

    protected class AsyncLoadTaskRecord
    {
        public string m_LoadTaskName = "";
        public int m_LoadTaskCnt = 0;
    }

    List<AsyncLoadTaskRecord> m_AsyncLoadingList = new List<AsyncLoadTaskRecord>();
    List<AsyncLoadTaskRecord> m_AsyncRecordPool = new List<AsyncLoadTaskRecord>();

    public bool IsResInAsyncLoading(string path)
    {
        AsyncLoadTaskRecord record = _GetAssetRecordByName(path);
        if (null != record)
            return record.m_LoadTaskCnt > 0;

        return false;
    }

    protected AsyncLoadTaskRecord _AllocateAsyncRecord()
    {
        AsyncLoadTaskRecord newRecord = null;
        if (m_AsyncRecordPool.Count > 0)
        {
            int lstIdx = m_AsyncRecordPool.Count - 1;
            newRecord = m_AsyncRecordPool[lstIdx];
            m_AsyncRecordPool.RemoveAt(lstIdx);

            newRecord.m_LoadTaskName = "";
            newRecord.m_LoadTaskCnt = 0;

            return newRecord;
        }

        return new AsyncLoadTaskRecord();
    }

    protected AsyncLoadTaskRecord _GetAssetRecordByName(string name)
    {
        for (int i = 0, icnt = m_AsyncLoadingList.Count; i < icnt; ++i)
        {
            AsyncLoadTaskRecord record = m_AsyncLoadingList[i];
            if (null == record) continue;

            if (record.m_LoadTaskName.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                return record;
        }

        return null;
    }

    public AsyncLoadRequest<Q> AllocAsyncTask(string resPath,AsyncLoadData asyncLoadData)
    {
        AsyncLoadTask res = null;
        if (m_IdleTaskPool.Count > 0)
        {
            res = m_IdleTaskPool[0];
            m_IdleTaskPool.RemoveAt(0);
        }

        if (null == res)
            res = new AsyncLoadTask();

        res.m_RequestWrapper.Reset();
        res.m_LoadRequest.Reset();
        res.m_FrameCnt = 0;
        res.m_LoadRequest.m_ResPath = resPath;
        res.m_RequestData = asyncLoadData;
        res.m_AsyncLoadPath = resPath;

        m_AsyncLoadTaskQueue.Add(res);
        return res.m_LoadRequest;
    }
    public AsyncLoadRequest<Q> AllocAsyncTaskWithTarget(Q resLoaded, string resPath)
    {
        AsyncLoadRequest<Q> asyncReq = AllocAsyncTask(resPath, null);
        asyncReq.m_ResObject = resLoaded;
        asyncReq.m_ResPath = resPath;
        asyncReq.m_IsDone = true;
        asyncReq.m_Extracted = false;

        return asyncReq;
    }

    public void Update()
    {
        /// 检查异步加载队列
        for (int i = 0, icnt = m_AsyncLoadTaskQueue.Count; i < icnt; ++i)
        {
            AsyncLoadTask curTask = m_AsyncLoadTaskQueue[i];

            if (null != curTask)
            {
                if (!curTask.m_LoadRequest.IsDone())
                {
                    if (curTask.m_RequestWrapper.InLoading())
                    {
                        if (!curTask.m_RequestWrapper.IsDone()) continue;

                        AsyncLoadTaskRecord record = _GetAssetRecordByName(curTask.m_AsyncLoadPath);
                        if (null != record)
                        {
                            if (record.m_LoadTaskCnt > 0)
                                --record.m_LoadTaskCnt;
                            else
                                LogManager.Instance().LogWarning("Bad count for async-load task!");

                            m_AsyncRecordPool.Add(record);
                            m_AsyncLoadingList.Remove(record);
                        }

                        curTask.m_LoadRequest.Encase(curTask.m_RequestWrapper.Extract());
                        curTask.m_AsyncLoadPath = null;
                        curTask.m_RequestData = null;

                        curTask.m_RequestWrapper.Reset();
                        curTask.m_FrameCnt = 0;

                        m_CompleteTaskQueue.Add(curTask);
                    }
                    else
                    {
                        /// 默认晚一帧 在进行异步加载 主要是为了错开同步加载和异步加载的时机
                        if (null != curTask.m_AsyncLoadPath)
                        {
                            curTask.m_RequestWrapper.Prepare(curTask.m_AsyncLoadPath, curTask.m_RequestData);

                            if (!curTask.m_RequestWrapper.IsReady())
                                continue;

                            if (1 <= curTask.m_FrameCnt)
                            {
                                curTask.m_RequestWrapper.DoLoad();

                                AsyncLoadTaskRecord record = _GetAssetRecordByName(curTask.m_AsyncLoadPath);
                                if (null != record)
                                    ++record.m_LoadTaskCnt;
                                else
                                {
                                    AsyncLoadTaskRecord newRecord = _AllocateAsyncRecord();
                                    newRecord.m_LoadTaskName = curTask.m_AsyncLoadPath;
                                    newRecord.m_LoadTaskCnt = 1;

                                    m_AsyncLoadingList.Add(newRecord);
                                }
                            }
                            else
                                curTask.m_FrameCnt++;

                            continue;
                        }
                    }
                }
            }
            
            m_AsyncLoadTaskQueue.RemoveAt(i);
            --i;
            --icnt;
        }

        /// 检查完成队列
        for (int i = 0, icnt = m_CompleteTaskQueue.Count; i < icnt; ++i)
        {
            AsyncLoadTask curTask = m_CompleteTaskQueue[i];
            if (null != curTask)
            {
                if (!curTask.m_LoadRequest.m_Extracted && !curTask.m_LoadRequest.m_IsAbort) continue;

                curTask.m_LoadRequest.Reset();
                curTask.m_RequestWrapper.Reset();

                m_IdleTaskPool.Add(curTask);
            }
            m_CompleteTaskQueue.RemoveAt(i);

            --i;
            --icnt;
        }
    }
}
