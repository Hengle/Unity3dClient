using UnityEngine;
using System.Collections;
using XLua;

namespace GameClient
{
	class GameFrameWork : MonoBehaviour 
	{
        public TextAsset luaScript = null;
		// Use this for initialization
		void Start() 
		{
			GameObject.DontDestroyOnLoad (this);

            if (!Initialize())
            {
                return;
            }

            Application.targetFrameRate = 30;

            //AssetPackageLoader.instance.LoadPackage("");

            //if (null != luaScript)
            //{
            //    LuaEnv luaEnv = new LuaEnv();
            //    luaEnv.DoString(luaScript.text);
            //    luaEnv.Dispose();
            //}
            //UIManager.Instance ().OpenFrame<LobbyFrame> (FrameTypeID.FTID_LOBBY);

            var mFrame = UIFrameLua.OpenFrameLua(3);
            if(null != mFrame)
            {
                mFrame.SetImage("playerHead", "UI/Image/Packed/pck_lobby.png", "btnSetting");
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