using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using GameClient;

public class AsyncLoadTaskManager : Singleton<AsyncLoadTaskManager>
{
    private List<AsyncLoadTask> mAsyncTasks = new List<AsyncLoadTask>();

    public void ClearAllAsyncTasks()
    {
        LogManager.Instance().LogProcessFormat(10888,"[AsyncLoadTask] clear all task {0}", mAsyncTasks.Count);

        for (int i = 0; i < mAsyncTasks.Count; ++i)
        {
            _abortAsyncTask(mAsyncTasks[i]);
        }

        mAsyncTasks.Clear();
    }

    public void RemoveAsyncLoadGameObjectByHandle(uint handle)
    {
        _removeAsyncLoadTask(handle);
    }

    public uint AddAsyncLoadGameObject(string tag, string path, PostLoadGameObject load, uint condition = uint.MaxValue)
    {
        return _addAsyncLoadGameObject(tag, path, load, condition);
    }

    public uint AddAsyncLoadGameObject(string tag, string path, enResourceType restype, bool reserveLast, PostLoadGameObject load, uint condition = uint.MaxValue)
    {
        return _addPooledAsyncLoadGameObject(tag, path, restype, reserveLast, load, condition);
    }

    #region Normal
    private uint _addAsyncLoadGameObject(string tag, string path, PostLoadGameObject load, uint condition)
    {
        uint handle = AssetLoader.Instance().LoadResAsyncAsGameObject(path,true,(uint)AssetLoadFlag.HideAfterLoad);
        if (!AssetLoader.Instance().IsValidHandle(handle))
        {
            LogManager.Instance().LogErrorFormat("[AsyncLoadTask] add fail with {0}:{1}", tag, path);
            return uint.MaxValue;
        }

        _addAsyncLoadTask(tag, handle, path, condition, load, false);
        return handle;
    }

    #endregion

    #region Pooled
    private uint _addPooledAsyncLoadGameObject(string tag, string path, enResourceType restype, bool reserveLast, PostLoadGameObject load, uint condition)
    {
        uint handle = CGameObjectPool.Instance().GetGameObjectAsync(path, restype, reserveLast ? ((uint)GameObjectPoolFlag.ReserveLast| (uint)GameObjectPoolFlag.HideAfterLoad) : (uint)GameObjectPoolFlag.HideAfterLoad,0x322d2312);

        if (!CGameObjectPool.Instance().IsValidHandle(handle))
        {
            LogManager.Instance().LogErrorFormat("[AsyncLoadTask] add fail with {0}:{1}", tag, path);
            return uint.MaxValue;
        }

        _addAsyncLoadTask(tag, handle, path, condition, load, true);
        return handle;
    }
    #endregion

    public void Update(float delta)
    {
        for (int i = 0; i < mAsyncTasks.Count; ++i)
        {
            switch (mAsyncTasks[i].status)
            {
                case eAsyncLoadTaskStatus.onNone:
                    mAsyncTasks[i].status = eAsyncLoadTaskStatus.onLoading;
                    LogManager.Instance().LogProcessFormat(99880,"[AsyncLoadTask] status is loading {0}, {1}", mAsyncTasks[i].handle, mAsyncTasks[i].path);
                    break;
                case eAsyncLoadTaskStatus.onLoading:
                    if (_isRequestDone(mAsyncTasks[i]))
                    {
                        mAsyncTasks[i].status = eAsyncLoadTaskStatus.onCondition;
                        LogManager.Instance().LogProcessFormat(99880,"[AsyncLoadTask] status is condition {0} {1}", mAsyncTasks[i].handle, mAsyncTasks[i].path);
                    }
                    break;
                case eAsyncLoadTaskStatus.onCondition:
                    if (_isTaskCondition(mAsyncTasks[i]))
                    {
                        LogManager.Instance().LogProcessFormat(99880,"[AsyncLoadTask] status is finish {0} {1}", mAsyncTasks[i].handle, mAsyncTasks[i].path);
                        mAsyncTasks[i].status = eAsyncLoadTaskStatus.onPostCall;
                    }
                    break;
                case eAsyncLoadTaskStatus.onPostCall:
                    _onPostLoad(mAsyncTasks[i]);
                    mAsyncTasks[i].status = eAsyncLoadTaskStatus.onFinish;
                    break;
                case eAsyncLoadTaskStatus.onFinish:
                    break;
            }
        }
    }

    private bool _removeAllFinishTask(AsyncLoadTask task)
    {
        if (null == task)
        {
            return true;
        }

        if (task.isFinish)
        {
            _removeAsyncLoadTask(task);
            return true;
        }

        return false;
    }

    private bool _isTaskCondition(AsyncLoadTask task)
    {
        if (null == task)
        {
            LogManager.Instance().LogProcessFormat(99880,"[AsyncLoadTask] task is nil");
            return true;
        }

        if (uint.MaxValue == task.waithandle)
        {
            return true;
        }

        AsyncLoadTask waittask = _findTask(task.waithandle);


        if (null == waittask)
        {
            return true;
        }

        return waittask.isFinish;
    }

    private AsyncLoadTask _findTask(uint handle)
    {
        for (int i = 0; i < mAsyncTasks.Count; ++i)
        {
            if (mAsyncTasks[i].handle == handle )
            {
                return mAsyncTasks[i];
            }
        }

        return null;
    }

    private bool _isRequestDone(AsyncLoadTask task)
    {
        if (null == task)
        {
            LogManager.Instance().LogProcessFormat(99880,"[AsyncLoadTask] task is nil");
            return false;
        }

        if (task.isPooled)
        {
            return CGameObjectPool.Instance().IsRequestDone(task.handle);
        }
        else
        {
            return AssetLoader.Instance().IsRequestDone(task.handle);
        }
    }

    private void _onPostLoad(AsyncLoadTask task)
    {
        if (null == task)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] task is nil");
            return;
        }

        if (null != task.load)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] call post load {0} {1}", task.handle, task.path);
            task.load(_extraGameObjectByHandle(task));
        }
    }

    private GameObject _extraGameObjectByHandle(AsyncLoadTask task)
    {
        if (null == task)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] task is nil");
            return null;
        }

        if (task.isPooled)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] get pool gameobject {0} {1}", task.handle, task.path);
            return CGameObjectPool.Instance().ExtractAsset(task.handle) as GameObject;
        }
        else
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] get normal gameobject {0} {1}", task.handle, task.path);
            return AssetLoader.Instance().Extract(task.handle).obj as GameObject;
        }
    }
    
    private void _addAsyncLoadTask(string tag, uint handle, string path, uint condition, PostLoadGameObject load, bool isPooled)
    {
        AsyncLoadTask task = new AsyncLoadTask(tag, handle, path, condition, load, isPooled);
        mAsyncTasks.Add(task);

        LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] add task ID {0}, count left {1}, {2}", task.handle, mAsyncTasks.Count, task.path);
    }

    private void _removeAsyncLoadTask(AsyncLoadTask task)
    {
        if (null == task)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] task is nil");
            return;
        }

        _abortAsyncTask(task);

        mAsyncTasks.Remove(task);

        LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] remove task {0}, count left {1}", task.handle, mAsyncTasks.Count);
    }

    private void _removeAsyncLoadTask(uint handle)
    {
        AsyncLoadTask task = _findTask(handle);

        if (null == task)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] task is nil");
            return;
        }

        _removeAsyncLoadTask(task);
    }

    private void _abortAsyncTask(AsyncLoadTask task)
    {
        if (null == task)
        {
            LogManager.Instance().LogProcessFormat(99880,"[AsyncLoadTask] task is nil");
            return ;
        }

        if (task.isFinish)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] finish task {0}, {1}", task.handle, task.path);
            return;
        }

        if (task.isPooled)
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] finish task with pool abort {0}, {1}", task.handle, task.path);
            CGameObjectPool.Instance().AbortRequest(task.handle);
        }
        else
        {
            LogManager.Instance().LogProcessFormat(99880, "[AsyncLoadTask] finish task with normal abort {0}, {1}", task.handle, task.path);
            AssetLoader.Instance().AbortRequest(task.handle);
        }
    }
}
