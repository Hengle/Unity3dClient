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
            //initialize global data
            if(!GlobalDataManager.Instance().Initialize(this))
            {
                LogManager.Instance().LogProcessFormat(8000, "<color=#ff0000>GlobalDataManager Initialized !</color>");
                return;
            }
            LogManager.Instance().LogProcessFormat(8000, "<color=#00ff00>GlobalDataManager Initialized !</color>");

            //initialize data here , for table data ,net work, and so on ...
            if (!TableManager.Instance().Initialize())
            {
                LogManager.Instance().LogProcessFormat(8001, "<color=#ff0000>load tables failed !</color>");
                return;
            }
            LogManager.Instance().LogProcessFormat(8001, "<color=#00ff00>load tables succeed !</color>");

            UIManager.Instance().OpenFrame<LoginFrame>(FrameTypeID.FTID_LOGIN);

            EventManager.Instance().SendEvent(ClientEvent.CE_LOGIN_TEST);
        }

        private void Update()
        {
            InvokeManager.Instance().Update();
        }

        void OnDestroy()
		{

		}
	}
}