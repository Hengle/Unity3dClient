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

        private EAction luaStart;
        private EAction luaUpdate;
        private EAction luaOnDestroy;
        private LuaTable scriptEnv;

        static GameFrameWork mFrameWorkHandle = null;
        public static GameFrameWork FrameWorkHandle
        {
            private set
            {
                mFrameWorkHandle = value;
            }
            get
            {
                return mFrameWorkHandle;
            }
        }

        public void Invoke(EAction action)
        {
            if (null != action)
            {
                luaUpdate = (EAction)Delegate.Remove((EAction)this.luaUpdate, action);
                luaUpdate = (EAction)Delegate.Combine((EAction)this.luaUpdate, action);
            }
        }

        private byte[] CustomLoaderMethod(ref string fileName)
        {
#if UNITY_EDITOR
            fileName = Application.dataPath + "/Resources/XLuaCode" + fileName.Replace('.', '/') + ".lua" + ".txt";
            if (File.Exists(fileName))
            {
                LogManager.Instance().LogProcessFormat(2000,"Load Lua Succeed [<color=#00ff00>{0}</color>]", fileName);
                return File.ReadAllBytes(fileName);
            }
            else
            {
                LogManager.Instance().LogProcessFormat(2000,"Load Lua File {0} Failed !!!", fileName);
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
            FrameWorkHandle = this;

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
            Application.targetFrameRate = 30;

            //initialize global data
            if (!GlobalDataManager.Instance().Initialize(this))
            {
                LogManager.Instance().LogProcessFormat(8000, "<color=#ff0000>GlobalDataManager Initialized failed !</color>");
                return;
            }
            LogManager.Instance().LogProcessFormat(8000, "<color=#00ff00>GlobalDataManager Initialized succeed !</color>");

            SceneManager.Instance().RegisterScene(SceneType.ST_LOGIN, CreateLoginScene);
            SceneManager.Instance().RegisterScene(SceneType.ST_BATTLE_FISH, FishScene.CreateFishScene);

            SceneManager.Instance().SwitchScene(SceneType.ST_LOGIN);
        }

        IScene CreateLoginScene()
        {
            Scene scene = new Scene();
            scene.onBeginLoading = _OnBeginLoading;
            scene.onEndLoading = _OnEndLoading;
            scene.onRunning = null;
            scene.itExit = null;
            scene.itEnter = _LoadAllResource(scene);
            scene.onEnter = _OnEnter;
            scene.onExit = _OnExit;
            return scene;
        }

        void _OnBeginLoading()
        {
            UIManager.Instance().OpenFrame<LoadingFrame>(7);
        }

        void _OnEndLoading()
        {
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_FINISH);
        }

        void _OnEnter()
        {
            luaEnv.DoString(luaScript.text, "GameFrameWork");

            scriptEnv.Get("Start", out luaStart);
            scriptEnv.Get("Update", out luaUpdate);
            scriptEnv.Get("OnDestroy", out luaOnDestroy);

            if (null != luaStart)
            {
                luaStart();
            }
        }

        void _OnExit()
        {
            SceneManager.Instance().Clear(false);
        }

        IEnumerator _LoadAllResource(Scene scene)
        {
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, "加载AssetLoader...");
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS,0.0f);
            AssetLoader.Instance().Initialize();
            yield return new WaitForEndOfFrame();

            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, "加载合局表格...");
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 0.01f);
            //initialize data here , for table data ,net work, and so on ...
            yield return AssetManager.Instance().AnsyLoadAllTables();
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 0.95f);
            yield return new WaitForEndOfFrame();
            if (!TableManager.Instance().IsValid())
            {
                LogManager.Instance().LogProcessFormat(8001, "<color=#ff0000>TableManager Initialize failed !</color>");
                yield break;
            }
            LogManager.Instance().LogProcessFormat(8001, "<color=#00ff00>TableManager Initialize succeed !</color>");

            yield return new WaitForEndOfFrame();
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, "初始化音效管理器...");
            if (!AudioManager.Instance().Initialize())
            {
                LogManager.Instance().LogProcessFormat(8002, "<color=#ff0000>AudioManager  Initialize failed !</color>");
                yield break;
            }
            LogManager.Instance().LogProcessFormat(8002, "<color=#00ff00>AudioManager  Initialize succeed !</color>");
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 0.96f);

            yield return new WaitForEndOfFrame();
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, "初始化调度管理器...");
            if (!InvokeManager.Instance().Initialize(true))
            {
                LogManager.Instance().LogProcessFormat(8003, "<color=#ff0000>InvokeManager  Initialize failed !</color>");
                yield break;
            }
            LogManager.Instance().LogProcessFormat(8003, "<color=#00ff00>InvokeManager  Initialize succeed !</color>");

            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 0.98f);
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, "加载场景音乐...");
            AudioManager.Instance().PlaySound(1001);

            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 1.0f);
            yield return new WaitForEndOfFrame();
            if(null != scene)
            {
                scene.SetAction(SceneAction.SA_READY_RUNNING);
            }
            LogManager.Instance().LogProcessFormat(8003, "<color=#00ff00>_LoadAllResource  Co Aborted !!!!</color>");
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
            StopAllCoroutines();
            SceneManager.Instance().ExitGame();
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
            FrameWorkHandle = null;
        }
	}
}