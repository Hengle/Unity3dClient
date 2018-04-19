using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    public enum SceneAction
    {
        SA_INVALID = -1,
        SA_ON_ENTER,
        SA_RUNNING,
        SA_READY_RUNNING,
        SA_ON_EXIT,
        SA_EXITED,
    }

    [LuaCallCSharp]
    public class Scene : IScene 
	{
        SceneAction _state = SceneAction.SA_INVALID;
        public IEnumerator itEnter = null;
        public IEnumerator itExit = null;
        public EAction onBeginLoading = null;
        public EAction onExit = null;
        public EAction onEnter = null;
        public EAction onRunning = null;
        public EAction onEndLoading = null;
        Coroutine coEnter = null;
        Coroutine coExit = null;
        protected int _ID = -1;
        protected LuaSceneBehavior mSceneBehavior = null;
        protected ProtoTable.SceneTable sceneItem = null;

        public void Reset()
        {
            _state = SceneAction.SA_INVALID;
            itEnter = null;
            itExit = null;
            onBeginLoading = null;
            onExit = null;
            onEnter = null;
            onRunning = null;
            onEndLoading = null;
            coEnter = null;
            coExit = null;
            mSceneBehavior = null;
            sceneItem = null;
            _ID = -1;
        }

        public int GetID()
        {
            return _ID;
        }

        public string GetName()
        {
            if(null != sceneItem)
            {
                return sceneItem.Desc;
            }
            return "[Scene:Unknown]";
        }

        public bool Create(int iId)
        {
            _ID = iId;
            sceneItem = TableManager.Instance().GetTableItem<ProtoTable.SceneTable>(iId);
            return null != sceneItem;
        }

        public void SetAction(SceneAction eAction)
        {
            _state = eAction;
        }

        public SceneAction GetAction()
        {
            return _state;
        }

        public void OnEnter()
        {
            if (null != coEnter)
            {
                GameFrameWork.FrameWorkHandle.StopCoroutine(coEnter);
                coEnter = null;
            }
            _state = SceneAction.SA_INVALID;
            coEnter = GameFrameWork.FrameWorkHandle.StartCoroutine(_AnsyEnter());
        }

        IEnumerator _AnsyEnter()
        {
            _state = SceneAction.SA_ON_ENTER;
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [OnBeginLoading] ...");

            if (null != onBeginLoading)
            {
                onBeginLoading.Invoke();
            }
            yield return new WaitForEndOfFrame();
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [OnStartEnter Coroutine] ...");

            if (null != itEnter)
            {
                yield return itEnter;
            }

            if (_state != SceneAction.SA_READY_RUNNING)
            {
                _state = SceneAction.SA_INVALID;
                yield break;
            }
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [OnEndLoading] ...");
            yield return new WaitForEndOfFrame();
            if (null != onEndLoading)
            {
                onEndLoading.Invoke();
            }

            yield return new WaitForEndOfFrame();
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [OnEnter] ...");
            if (null != onEnter)
            {
                onEnter.Invoke();
            }
            coEnter = null;

            yield return new WaitForEndOfFrame();
            LogManager.Instance().LogProcessFormat(8888, "Execute LuaSceneBehavior [OnEnter] ...");
            if(null != mSceneBehavior)
            {
                mSceneBehavior.OnOpenScene(this);
            }

            yield return new WaitForEndOfFrame();
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [Running] ...");
            _state = SceneAction.SA_RUNNING;
        }

        IEnumerator _AnsyExit()
        {
            if (null != mSceneBehavior)
            {
                mSceneBehavior.OnCloseScene();
            }

            if (null != onExit)
            {
                onExit.Invoke();
                onExit = null;
            }

            yield return new WaitForEndOfFrame();
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [OnExit Co] ...");
            if (null != itExit)
            {
                yield return itExit;
            }
            itExit = null;

            yield return new WaitForEndOfFrame();

            if (null != mSceneBehavior)
            {
                mSceneBehavior.DestroyWithScene();
            }
            mSceneBehavior = null;

            coExit = null;
            Reset();
            _state = SceneAction.SA_EXITED;
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [OnExit Finish] ...");
        }

        public void OnExit()
        {
            if (null != coExit)
            {
                GameFrameWork.FrameWorkHandle.StopCoroutine(coExit);
                coExit = null;
            }
            _state = SceneAction.SA_ON_EXIT;
            LogManager.Instance().LogProcessFormat(8888, "Execute Action [OnExit] ...");
            coExit = GameFrameWork.FrameWorkHandle.StartCoroutine(_AnsyExit());
        }

        public void ExitGame()
        {
            if(null != mSceneBehavior)
            {
                mSceneBehavior.OnCloseScene();
                mSceneBehavior.DestroyWithScene();
                mSceneBehavior = null;
            }
        }

        public void SetSceneBehavior(LuaSceneBehavior behavior)
        {
            mSceneBehavior = behavior;
        }

        public void OnUpdate()
        {
            if(_state == SceneAction.SA_RUNNING)
            {
                if(null != onRunning)
                {
                    onRunning.Invoke();
                }
            }
        }
    }
}