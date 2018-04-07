using UnityEngine;
using System.Collections;
using XLua;
using System;
using System.IO;

namespace GameClient
{
	class GameFrameWork : MonoBehaviour 
	{
        public TextAsset luaScript = null;
        public static LuaEnv LuaInstance
        {
            get
            {
                return luaEnv;
            }
        }
        internal static LuaEnv luaEnv = new LuaEnv();
        internal static float lastGCTime = 0;
        internal const float GCInterval = 1;//1 second 

        private Action luaStart;
        private Action luaUpdate;
        private Action luaOnDestroy;
        private LuaTable scriptEnv;

        private byte[] CustomLoaderMethod(ref string fileName)
        {
#if UNITY_EDITOR
            fileName = Application.dataPath + "/Resources/XLuaCode" + fileName.Replace('.', '/') + ".lua";
            if (File.Exists(fileName))
            {
                return File.ReadAllBytes(fileName);
            }
            else
            {
                Debug.LogErrorFormat("Load Lua File {0} Failed !!!", fileName);
                return null;
            }
#else
            fileName = "XLuaCode" + fileName;
            fileName = fileName.Replace('.', '/') + ".lua";
            var assetInst = AssetLoader.Instance().LoadRes(fileName, typeof(TextAsset));
            if(null != assetInst && null != assetInst.obj)
            {
                TextAsset file = assetInst.obj as TextAsset;
                if (file != null)
                {
                    return file.bytes;
                }
            }

            LogManager.Instance().LogProcessFormat(1000,"can not load lua file {0}",fileName);
            return null;
#endif
        }

        void Awake()
        {
            LuaEnv.CustomLoader method = CustomLoaderMethod;
            luaEnv.AddLoader(method);

            scriptEnv = luaEnv.NewTable();

            LuaTable meta = luaEnv.NewTable();
            meta.Set("__index", luaEnv.Global);
            scriptEnv.SetMetaTable(meta);
            meta.Dispose();

            scriptEnv.Set("self", this);
        }

        // Use this for initialization
        void Start() 
		{
			GameObject.DontDestroyOnLoad (this);

            if (!Initialize())
            {
                return;
            }

            Application.targetFrameRate = 30;

            luaEnv.DoString(luaScript.text);

            scriptEnv.Get("start", out luaStart);
            scriptEnv.Get("update", out luaUpdate);
            scriptEnv.Get("ondestroy", out luaOnDestroy);

            if (null != luaStart)
            {
                luaStart();
            }
        }

        private bool Initialize()
        {
            AssetLoader.Instance().Initialize();
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
            AsyncLoadTaskManager.Instance().Update(Time.deltaTime);

            if(null != luaUpdate)
            {
                luaUpdate();
            }

            if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
            {
                luaEnv.Tick();
                LuaBehaviour.lastGCTime = Time.time;
            }
        }

        void OnDestroy()
		{
            AudioManager.Instance().Clear();
            InvokeManager.Instance().Clear();
            AsyncLoadTaskManager.Instance().ClearAllAsyncTasks();
            AssetLoader.Instance().ClearAll();
            UIManager.Instance().CloseAllFrames();
            if(null != luaOnDestroy)
            {
                luaOnDestroy();
            }
            luaOnDestroy = null;
            luaUpdate = null;
            luaStart = null;
            if(null != scriptEnv)
            {
                scriptEnv.Dispose();
                scriptEnv = null;
            }

            if (null != luaEnv)
            {
                luaEnv.Dispose();
                luaEnv = null;
            }
        }
	}
}