using UnityEngine;
using System.Collections;

namespace GameClient
{
	class GameFrameWork : MonoBehaviour 
	{
		// Use this for initialization
		void Start() 
		{
			GameObject.DontDestroyOnLoad (this);

            if(!Initialize())
            {
                return;
            }

			bool bNeedHotFix = true;

            if(!bNeedHotFix)
            {
                UIManager.Instance().OpenFrame<LoginFrame>(FrameTypeID.FTID_LOGIN);
                EventManager.Instance().SendEvent(ClientEvent.CE_LOGIN_TEST);
            }
            else
            {
                UIManager.Instance().OpenFrame<HotFixFrame>(FrameTypeID.FTID_HOTFIX);
                UIManager.Instance().OpenFrame<LoginFrame>(FrameTypeID.FTID_LOGIN);
                EventManager.Instance().SendEvent(ClientEvent.CE_LOGIN_TEST);
            }
        }

        private bool Initialize()
        {
            //initialize global data
            if (!GlobalDataManager.Instance().Initialize(this))
            {
                LogManager.Instance().LogProcessFormat(8000, "<color=#ff0000>GlobalDataManager Initialized failed !</color>");
                return false;
            }
            LogManager.Instance().LogProcessFormat(8000, "<color=#00ff00>GlobalDataManager Initialized succeed !</color>");

            //initialize data here , for table data ,net work, and so on ...
            if (!TableManager.Instance().Initialize())
            {
                LogManager.Instance().LogProcessFormat(8001, "<color=#ff0000>TableManager Initialize failed !</color>");
                return false;
            }
            LogManager.Instance().LogProcessFormat(8001, "<color=#00ff00>TableManager Initialize succeed !</color>");

            if(!AudioManager.Instance().Initialize())
            {
                LogManager.Instance().LogProcessFormat(8002, "<color=#ff0000>AudioManager  Initialize failed !</color>");
                return false;
            }
            LogManager.Instance().LogProcessFormat(8002, "<color=#00ff00>AudioManager  Initialize succeed !</color>");

            if(!InvokeManager.Instance().Initialize())
            {
                LogManager.Instance().LogProcessFormat(8003, "<color=#ff0000>InvokeManager  Initialize failed !</color>");
                return false;
            }
            LogManager.Instance().LogProcessFormat(8003, "<color=#00ff00>InvokeManager  Initialize succeed !</color>");

            return true;
        }

        private void Update()
        {
            InvokeManager.Instance().Update();
            AudioManager.Instance().Update();
        }

        void OnDestroy()
		{
            AudioManager.Instance().Clear();
            InvokeManager.Instance().Clear();

            InvokeManager.Instance().RemoveInvoke(this);
        }
	}
}