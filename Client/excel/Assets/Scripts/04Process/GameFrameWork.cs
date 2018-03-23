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

            MusicSetting setting = LocalSettingManager.Instance().GetSetting<MusicSetting>(ProtoTable.LocalSettingTable.eSetting.MUSIC_SETTING);
            LogManager.Instance().LogProcessFormat(88997, "name = {0}", setting.name);
            LogManager.Instance().LogProcessFormat(88997, "age = {0}", setting.age);
            LogManager.Instance().LogProcessFormat(88997, "music is on = {0}", setting.isOn);
            setting.age = 25;
            setting.name = "wangfang";
            setting.isOn = true;
            LocalSettingManager.Instance().SaveSettingToFile(ProtoTable.LocalSettingTable.eSetting.MUSIC_SETTING);

            return;

			bool bNeedHotFix = true;

            if(!bNeedHotFix)
            {
                UIManager.Instance().OpenFrame<LoginFrame>(FrameTypeID.FTID_LOGIN);
                EventManager.Instance().SendEvent(ClientEvent.CE_LOGIN_TEST);
            }
            else
            {
                UIManager.Instance().OpenFrame<HotFixFrame>(FrameTypeID.FTID_HOTFIX);
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