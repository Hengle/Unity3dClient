using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	class SceneManager : Singleton<SceneManager>
	{
        public enum SceneType
        {
            ST_INVALID = -1,
            ST_LOGIN = 0,
        }
        SceneType eCurrent = SceneType.ST_INVALID;
        SceneType eTo = SceneType.ST_INVALID;
        UnityAction onSceneChangeFinish = null;
        bool _loading = false;
        bool Loading
        {
            get
            {
                return _loading;
            }
            set
            {
                _loading = value;

                if(_loading)
                {
                    _OpenLoadingFrame();
                }
                else
                {
                    _CloseLoadingFrame();
                }
            }
        }

        protected void _OpenLoadingFrame()
        {
            UIManager.Instance().OpenFrame<LoadingFrame>(7);
        }

        protected void _CloseLoadingFrame()
        {
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_FINISH);
        }

        public bool Initialize()
		{
			return true;
		}

		public void SwitchSceneTo(SceneType eSceneType,IEnumerator co, UnityAction cb)
		{
            if (eSceneType == eCurrent)
            {
                return;
            }

            if (Loading)
            {
                return;
            }

            if(null != co)
            {
                eTo = eSceneType;
                Clear(false);
                Loading = true;
                onSceneChangeFinish = cb;
                GameFrameWork.FrameWorkHandle.StartCoroutine(StartChangeScene(co));
            }
        }

        IEnumerator StartChangeScene(IEnumerator co)
        {
            eCurrent = SceneType.ST_INVALID;
            yield return new WaitForEndOfFrame();

            yield return co;

            eCurrent = eTo;
            eTo = SceneType.ST_INVALID;

            yield return new WaitForEndOfFrame();
            Loading = false;

            if (null != onSceneChangeFinish)
            {
                onSceneChangeFinish.Invoke();
                onSceneChangeFinish = null;
            }
        }

        public void Clear(bool bGlobal)
        {
            AudioManager.Instance().Clear();
            InvokeManager.Instance().Clear(bGlobal);
            UIManager.Instance().CloseAllFrames();
            AsyncLoadTaskManager.Instance().ClearAllAsyncTasks();
        }

        public void ExitGame()
        {
            Clear(true);
            TableManager.Instance().ClearAll();
            eCurrent = SceneType.ST_INVALID;
            eTo = SceneType.ST_INVALID;
            onSceneChangeFinish = null;
            _loading = false;
        }

		public void UnInitialize()
		{
			
		}
	}
}