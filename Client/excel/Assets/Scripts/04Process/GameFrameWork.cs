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

            UIManager.Instance().OpenFrame<LoginFrame>(FrameTypeID.FTID_LOGIN);

            EventManager.Instance().SendEvent(ClientEvent.CE_LOGIN_TEST);
        }

        private bool Initialize()
        {
            //initialize global data
            if (!GlobalDataManager.Instance().Initialize(this))
            {
                LogManager.Instance().LogProcessFormat(8000, "<color=#ff0000>GlobalDataManager Initialized !</color>");
                return false;
            }
            LogManager.Instance().LogProcessFormat(8000, "<color=#00ff00>GlobalDataManager Initialized !</color>");

            //initialize data here , for table data ,net work, and so on ...
            if (!TableManager.Instance().Initialize())
            {
                LogManager.Instance().LogProcessFormat(8001, "<color=#ff0000>load tables failed !</color>");
                return false;
            }
            LogManager.Instance().LogProcessFormat(8001, "<color=#00ff00>load tables succeed !</color>");

            if(!AudioManager.Instance().Initialize())
            {
                LogManager.Instance().LogProcessFormat(8002, "<color=#ff0000>AudioManager  Initialize failed !</color>");
                return false;
            }
            LogManager.Instance().LogProcessFormat(8002, "<color=#00ff00>AudioManager  Initialize succeed !</color>");

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
        }
	}
}