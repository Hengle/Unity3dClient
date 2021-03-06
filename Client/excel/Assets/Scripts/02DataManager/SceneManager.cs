﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

namespace GameClient
{
    public enum SceneType
    {
        ST_INVALID = 0,
        ST_LOGIN = 1,
        ST_BATTLE_FISH,
        ST_COUNT,
    }

    [LuaCallCSharp]
    class SceneManager
	{
        protected static SceneManager ms_handle = null;
        public static SceneManager Instance()
        {
            if (null == ms_handle)
            {
                ms_handle = new SceneManager();
            }
            return ms_handle;
        }

        public delegate IScene EActionCreate();
        EActionCreate[] mActions = new EActionCreate[(int)SceneType.ST_COUNT];
        Scene[] mScenes = new Scene[(int)SceneType.ST_COUNT];

        public void RegisterScene(SceneType eScene, EActionCreate cb)
        {
            if(eScene > SceneType.ST_INVALID && eScene < SceneType.ST_COUNT)
            {
                mActions[(int)eScene] = cb;
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

        void _OnChangeScene(object argv)
        {
            SceneType eScene = (SceneType)argv;
            SwitchScene(eScene);
        }

        [LuaCallCSharp]
        public void SwitchScene(int iSceneId,object luaParam)
        {
            SwitchScene((SceneType)iSceneId, luaParam);
        }

        Scene mScene = null;
        Coroutine coSwith = null;
        public void SwitchScene(SceneType eSceneType,object luaParam = null)
        {
            try
            {
                LogManager.Instance().LogProcessFormat(8888, "<color=#00ff00>SwitchScene Scene !!!</color>");
                EventManager.Instance().UnRegisterEvent(ClientEvent.CE_CHANGE_SCENE, _OnChangeScene);
                EventManager.Instance().RegisterEvent(ClientEvent.CE_CHANGE_SCENE, _OnChangeScene);
                if (null != coSwith)
                {
                    GameFrameWork.FrameWorkHandle.StopCoroutine(coSwith);
                    coSwith = null;
                }
                coSwith = GameFrameWork.FrameWorkHandle.StartCoroutine(AnsySwitchScene(eSceneType, luaParam));
            }
            catch (System.Exception e)
            {
                LogManager.Instance().LogErrorFormat("<color=#ff0000>SwitchScene Scene Failed!!! {0}</color>", eSceneType);
                LogManager.Instance().LogErrorFormat("<color=#ff0000>SwitchScene Err {0}</color>", e.ToString());
            }
        }

        public IEnumerator AnsySwitchScene(SceneType eSceneType,object luaParam = null)
        {
            if (null != mScene)
            {
                mScene.OnExit();

                while (mScene.GetAction() != SceneAction.SA_EXITED)
                {
                    yield return new WaitForSecondsRealtime(0.10f);
                }
                mScene.SetAction(SceneAction.SA_INVALID);
                mScene = null;
            }

            int sceneId = (int)eSceneType;
            var sceneItem = TableManager.Instance().GetTableItem<ProtoTable.SceneTable>(sceneId);
            if(null == sceneItem)
            {
                LogManager.Instance().LogProcessFormat(8888, "<color=#ff00ff>create scene{0} failed !!! sceneId can not found in sceneTable !!!</color>", sceneId);
                coSwith = null;
                yield break;
            }

            GameObject goScene = AssetLoader.Instance().LoadRes(sceneItem.Prefab,typeof(GameObject)).obj as GameObject;
            if(null == goScene)
            {
                LogManager.Instance().LogProcessFormat(8888, "<color=#ff00ff>load scene {0} failed !!! sceneId = {1}!!!</color>", sceneItem.Desc, sceneId);
                coSwith = null;
                yield break;
            }

#if UNITY_EDITOR
            goScene.name = string.Format("[SCENE]:[{0}]", sceneItem.Desc);
#endif
            Utility.AttachTo(goScene, GlobalDataManager.Instance().uiConfig.sceneRoot);
            goScene.transform.SetAsFirstSibling();

            var sceneBehavior = goScene.GetComponent<LuaSceneBehavior>();
            if(null == sceneBehavior)
            {
                LogManager.Instance().LogProcessFormat(8888, "<color=#ff00ff>load scene {0} failed !!! missing LuaSceneBehavior script !!!</color>", sceneItem.Desc, sceneId);
                coSwith = null;
                luaParam = null;
                yield break;
            }
            sceneBehavior.luaParam = luaParam;

            if (null != mActions[(int)eSceneType])
            {
                mScenes[(int)eSceneType] = mActions[(int)eSceneType].Invoke() as Scene;
            }
            else
            {
                mScenes[(int)eSceneType] = new Scene();
            }

            mScene = mScenes[(int)eSceneType];
            if(null == mScene)
            {
                LogManager.Instance().LogProcessFormat(8888, "<color=#ff00ff>create scene{0} failed !!! mScene is null !!!</color>", eSceneType);
                coSwith = null;
                yield break;
            }

            if(!mScene.Create(sceneId))
            {
                LogManager.Instance().LogProcessFormat(8888, "<color=#ff00ff>create scene{0} failed !!! </color>", sceneId);
                coSwith = null;
                yield break;
            }

            mScene.SetSceneBehavior(sceneBehavior);
            mScene.OnEnter();

            while (mScene.GetAction() != SceneAction.SA_RUNNING && mScene.GetAction() != SceneAction.SA_INVALID)
            {
                yield return new WaitForSecondsRealtime(0.10f);
            }

            if(mScene.GetAction() == SceneAction.SA_INVALID)
            {
                LogManager.Instance().LogProcessFormat(8888, "<color=#ff00ff>create scene{0} failed !!! mScene action is SA_INVALID !!!</color>", eSceneType);
                coSwith = null;
                yield break;
            }

            coSwith = null;
        }

        public void Clear(bool bGlobal)
        {
            AudioManager.Instance().Clear();
            InvokeManager.Instance().Clear(bGlobal);
            UIManager.Instance().CloseAllFrames();
            if(bGlobal)
            {
                EventManager.Instance().Clear();
            }
            AsyncLoadTaskManager.Instance().ClearAllAsyncTasks();
        }

        public void ExitGame()
        {
            if(null != mScene)
            {
                mScene.ExitGame();
                mScene = null;
            }
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_CHANGE_SCENE, _OnChangeScene);
            Clear(true);
            TableManager.Instance().ClearAll();
        }

		public void UnInitialize()
		{
			
		}
	}
}