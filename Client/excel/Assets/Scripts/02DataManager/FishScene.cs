using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public class FishScene
    {
        public static IScene CreateFishScene()
        {
            Scene scene = new Scene();
            scene.onBeginLoading = _OnBeginLoading;
            scene.onEndLoading = _OnEndLoading;
            scene.onRunning = null;
            scene.itExit = null;
            scene.itEnter = _OnLoadResources(scene);
            scene.onEnter = _OnEnter;
            scene.onExit = _OnExit;
            return scene;
        }

        static void _OnBeginLoading()
        {
            UIManager.Instance().OpenFrame<LoadingFrame>(7);
        }

        static void _OnEndLoading()
        {
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_FINISH);
        }

        static IEnumerator _OnLoadResources(Scene scene)
        {
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, "加载鱼的资源...");
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 0.0f);
            yield return new WaitForEndOfFrame();
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 0.98f);
            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, "加载场景音乐...");
            AudioManager.Instance().PlaySound(1001);

            EventManager.Instance().SendEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, 1.0f);
            yield return new WaitForEndOfFrame();
            if (null != scene)
            {
                scene.SetAction(SceneAction.SA_READY_RUNNING);
            }
        }

        static void _OnEnter()
        {
            UIManager.Instance().OpenFrame<FishMainFrame>(5);
        }

        static void _OnExit()
        {

        }
    }
}