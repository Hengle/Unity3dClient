using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameClient
{
	public class FishMainFrame : ClientFrame 
	{
        UnityEngine.UI.Button mbtnQuit;
        GameClient.ComFishLogic mcomLogic;
        Scripts.UI.ComUIListScript mcomUIList;
        UnityEngine.UI.Image mbg_prev;
        UnityEngine.UI.Image mbg_cur;
        DG.Tweening.DOTweenAnimation mwave_action;
        GameClient.ComFishLogic mfish_logic;
        PathNormalList path = null;

        protected override void _InitScriptBinder()
        {
            mbtnQuit = mScriptBinder.GetObject("btnQuit") as UnityEngine.UI.Button;
            mcomLogic = mScriptBinder.GetObject("comLogic") as GameClient.ComFishLogic;
            mcomUIList = mScriptBinder.GetObject("comUIList") as Scripts.UI.ComUIListScript;
            mbg_prev = mScriptBinder.GetObject("bg_prev") as UnityEngine.UI.Image;
            mbg_cur = mScriptBinder.GetObject("bg_cur") as UnityEngine.UI.Image;
            mwave_action = mScriptBinder.GetObject("wave_action") as DG.Tweening.DOTweenAnimation;
            mfish_logic = mScriptBinder.GetObject("fish_logic") as GameClient.ComFishLogic;
        }

        protected override sealed void _OnOpenFrame()
		{
			if(null != mbtnQuit)
            {
                mbtnQuit.onClick.AddListener(_OnClickClose);
            }

            path = AssetLoader.Instance().LoadRes("Xml/path", typeof(PathNormalList)).obj as PathNormalList;

            //InvokeManager.Instance().Invoke(this, 3.0f, _BuildFishScene1);
            //InvokeManager.Instance().InvokeRepeate(this, 10.0f, _BuildFishScene4, false);

            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_CHANGE_SCENE, _OnChangeFishScene);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_PLAYER_UP_SCORE_CHANGED,_OnPlayerScoreChanged);

            _InitPlayerScores();

            for (int i = 0; i < (int)SceneKind.SCENE_COUNT; ++i)
            {
                SceneKind _scene = (SceneKind)(i);
                InvokeManager.Instance().Invoke(this, i * 20.0f, ()=>
                {
                    FishDataManager.Instance().CreateSwitchScene(_scene);
                });
            }
            
            //InvokeManager.Instance().InvokeRepeate(this, 0.0f, 1, 10.0f, null, FishDataManager.Instance().CreateSwitchScene, null, false);
        }

        void _BuildFishScene1()
        {
            for(int i = 0; i < (int)SceneKind.SCENE_COUNT; ++i)
            {
                FishSceneManager.Instance().BuildSceneFish((SceneKind)i, 0);
                FishSceneManager.Instance().BuildSceneFish((SceneKind)i, 3);
            }
        }

        void _BuildFishScene6()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_1, 0);
        }

        void _BuildFishScene6r()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_1, 3);
        }

        void _BuildFishScene2()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_6, 0);
        }

        void _BuildFishScene3()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_3, 0);
        }

        void _BuildFishScene4()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_5, 0);
        }

        void _BuildFishScene5()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_2, 0);
        }

        int m_cmd = 100050;
        void _OnCreateFish()
        {
            for(int i = 0; i < 5; ++i)
            {
                CMD_S_SceneFish cmd = new CMD_S_SceneFish();
                cmd.fish_id = ++m_cmd;
                cmd.fish_kind = (FishKind)(1 + UnityEngine.Random.Range(0, 21));
                cmd.elapsed = 0;
                int pathId = UnityEngine.Random.Range(0, path.pathes.Length - 1);
                cmd.position = path.pathes[pathId].positions;
                cmd.position_count = cmd.position.Length;
                cmd.tag = 0;
                cmd.tick_count = 0;

                FishDataManager.Instance().ExecuteCmd(cmd);
            }
        }

        void ChangeScreen()
        {
            FishDataManager.Instance().sceneAudioHandle = 0;

            int fishScene = (int)FishDataManager.Instance().FishScene;
            int curBgIndex = (int)fishScene % FishDataManager.Instance().BgCount;
            int preBgIndex = (curBgIndex + FishDataManager.Instance().BgCount - 1) % FishDataManager.Instance().BgCount;

            AudioManager.Instance().PlaySound(2000);//TransWave.ogg

            var wave_action = GetObject("wave_action") as DOTweenAnimation;
            if(null != wave_action)
            {
                wave_action.gameObject.CustomActive(true);
                wave_action.DORestartById("wave_action");
            }

            InvokeManager.Instance().Invoke(this, 9.50f, _OnVisibleChild);
        }

        void _OnVisibleChild()
        {
            if(null != mfish_logic)
            {
                mfish_logic.RecycleAllFish();
            }

            var wave_action = GetObject("wave_action") as DOTweenAnimation;
            if(null != wave_action)
            {
                wave_action.gameObject.CustomActive(false);
            }

            int fishScene = (int)FishDataManager.Instance().FishScene;
            int curBgIndex = (int)fishScene % FishDataManager.Instance().BgCount;
            SetImage("bg_cur", FishDataManager.Instance().GetSceneBG(curBgIndex));

            FishDataManager.Instance().sceneAudioHandle = AudioManager.Instance().PlaySound(2100 + curBgIndex + 1);

            FishSceneManager.Instance().BuildSceneFish(FishDataManager.Instance().FishScene, FishDataManager.Instance().chairId);
            FishDataManager.Instance().CanSend = true;
        }

        public override bool needLuaBehavior()
        {
            return false;
        }

        void _OnClickClose()
        {
            UIManager.Instance().CloseFrame(this);
        }

        protected void _OnChangeFishScene(object argv)
        {
            ChangeScreen();
        }

        protected void _InitPlayerScores()
        {
            for(int i = 0; i < FishConfig.fish_player_count;++i)
            {
                ComUINumber uiNumber = mScriptBinder.GetScript<ComUINumber>(string.Format("num_{0}", i));
                if (null != uiNumber)
                {
                    uiNumber.Value = FishDataManager.Instance().GetPlayerScore(i);
                }
            }
        }

        protected void _OnPlayerScoreChanged(object argv)
        {
            int chairId = (int)argv;
            long score = FishDataManager.Instance().GetPlayerScore(chairId);

            ComUINumber uiNumber = mScriptBinder.GetScript<ComUINumber>(string.Format("num_{0}", chairId));
            if(null != uiNumber)
            {
                uiNumber.Value = score;
            }
        }

        protected override sealed void _OnCloseFrame()
		{
            InvokeManager.Instance().RemoveInvoke(this);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_CHANGE_SCENE, _OnChangeFishScene);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_PLAYER_UP_SCORE_CHANGED, _OnPlayerScoreChanged);
            FishDataManager.Instance().sceneAudioHandle = 0;
        }
	}
}