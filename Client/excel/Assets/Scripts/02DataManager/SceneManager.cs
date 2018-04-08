using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	class SceneManager : Singleton<SceneManager>
	{
		Scene current = null;
        public enum SceneType
        {
            ST_INVALID = -1,
            ST_LOGIN = 0,
        }
        SceneType eCurrent = SceneType.ST_INVALID;
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

        }

        protected void _CloseLoadingFrame()
        {

        }

        public bool Initialize()
		{
			return true;
		}

		public void SwitchSceneTo(SceneType eSceneType)
		{
            if (eSceneType == eCurrent)
            {
                return;
            }

            if (Loading)
            {
                return;
            }

            Loading = true;

            Clear();
        }

        public void Clear()
        {
            AudioManager.Instance().Clear();
            InvokeManager.Instance().Clear();
            UIManager.Instance().CloseAllFrames();
            AsyncLoadTaskManager.Instance().ClearAllAsyncTasks();
        }

		public void UnInitialize()
		{
			
		}
	}
}