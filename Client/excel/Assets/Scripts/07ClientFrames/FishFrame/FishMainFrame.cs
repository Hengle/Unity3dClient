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
        GameClient.ComUINumber mnum_0;
        GameClient.ComUINumber mnum_1;
        GameClient.ComUINumber mnum_2;
        GameClient.ComUINumber mnum_3;
        GameClient.ComUINumber mnum_4;
        GameClient.ComUINumber mnum_5;
        UnityEngine.UI.Text mbblv_0;
        UnityEngine.UI.Text mbblv_1;
        UnityEngine.UI.Text mbblv_2;
        UnityEngine.UI.Text mbblv_3;
        UnityEngine.UI.Text mbblv_4;
        UnityEngine.UI.Text mbblv_5;
        UnityEngine.UI.Button mbtnAdd;
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
            mnum_0 = mScriptBinder.GetObject("num_0") as GameClient.ComUINumber;
            mnum_1 = mScriptBinder.GetObject("num_1") as GameClient.ComUINumber;
            mnum_2 = mScriptBinder.GetObject("num_2") as GameClient.ComUINumber;
            mnum_3 = mScriptBinder.GetObject("num_3") as GameClient.ComUINumber;
            mnum_4 = mScriptBinder.GetObject("num_4") as GameClient.ComUINumber;
            mnum_5 = mScriptBinder.GetObject("num_5") as GameClient.ComUINumber;
            mbblv_0 = mScriptBinder.GetObject("bblv_0") as UnityEngine.UI.Text;
            mbblv_1 = mScriptBinder.GetObject("bblv_1") as UnityEngine.UI.Text;
            mbblv_2 = mScriptBinder.GetObject("bblv_2") as UnityEngine.UI.Text;
            mbblv_3 = mScriptBinder.GetObject("bblv_3") as UnityEngine.UI.Text;
            mbblv_4 = mScriptBinder.GetObject("bblv_4") as UnityEngine.UI.Text;
            mbblv_5 = mScriptBinder.GetObject("bblv_5") as UnityEngine.UI.Text;
            mbtnAdd = mScriptBinder.GetObject("btnAdd") as UnityEngine.UI.Button;
        }


        protected override sealed void _OnOpenFrame()
		{
			if(null != mbtnQuit)
            {
                mbtnQuit.onClick.AddListener(_OnClickClose);
            }

            if(null != mbtnAdd)
            {
                mbtnAdd.onClick.AddListener(() => 
                {
                    AddWinCoin(25, 10000, 0);
                });
            }

            path = AssetLoader.Instance().LoadRes("Xml/path", typeof(PathNormalList)).obj as PathNormalList;

            //InvokeManager.Instance().Invoke(this, 3.0f, _BuildFishScene1);
            //InvokeManager.Instance().InvokeRepeate(this, 10.0f, _BuildFishScene4, false);

            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_CHANGE_SCENE, _OnChangeFishScene);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_PLAYER_UP_SCORE_CHANGED,_OnPlayerScoreChanged);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_PLAYER_CANNON_CHANGED, _OnPlayerCannonChanged);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_LOCK_FISH, _OnLockFish);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_USER_SHOOT, _OnUserShoot);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_UPPER_SUPER_CANNON, _OnSetSupperCannon);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_CATCH_CHAIN, _OnCatchFishChain);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_FISH_CATCH_FISH_GROUP, _OnCatchFishGroup);

            _InitPlayerScores();
            _InitBeiLv();

            for (int i = 0; i < (int)SceneKind.SCENE_COUNT; ++i)
            {
                SceneKind _scene = (SceneKind)(i);
                InvokeManager.Instance().Invoke(this, i * 20.0f, () =>
                {
                    FishDataManager.Instance().CreateSwitchScene(_scene);
                });
                break;
            }

            FishDataManager.Instance().CreateCatchChainCmd();

            //InvokeManager.Instance().InvokeRepeate(this, 0.0f, 1, 10.0f, null, FishDataManager.Instance().CreateSwitchScene, null, false);

            InvokeManager.Instance().Invoke(this, 15.0f, () =>
            {
                EventManager.Instance().SendEvent(ClientEvent.CE_FISH_LOCK_FISH, new object[] { 0,1 });
            });
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
            FishDataManager.Instance().ClearLockFish();
            for(int i = 0; i < FishConfig.fish_player_count; ++i)
            {
                //隐藏所有锁住鱼的鱼线图
                //for (int j = 0; j < 20; j++)
                //{
                //    m_FishLockLinespr[i][j] = Sprite::createWithSpriteFrame(cache->getSpriteFrameByName("LockLine.png"));
                //    this->addChild(m_FishLockLinespr[i][j], 10000);
                //    m_FishLockLinespr[i][j]->setVisible(false);
                //}
            }

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

        protected void _InitBeiLv()
        {
            for (int i = 0; i < FishConfig.fish_player_count; ++i)
            {
                SetText("bblv_" + i, FishDataManager.Instance().GetBulletPower(i).ToString());
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

        protected void _OnPlayerCannonChanged(object argv)
        {
            int chairId = (int)argv;
            int beiLv = FishDataManager.Instance().GetBulletPower(chairId);
            int cannonId = FishDataManager.Instance().GetBulletType(chairId);

            SetText("bblv_" + chairId, beiLv.ToString());
            SetImage("cannon_" + chairId,FishDataManager.Instance().GetCannonPath(cannonId));
        }

        protected void _OnLockFish(object argv)
        {
            object[] argvs = argv as object[];
            int LogicChairID = (int)argvs[0];
            int lock_fish_id = (int)argvs[1];
            FishKind lock_fish_kind = FishKind.FISH_KIND_COUNT;
            FishActionInterval action_fish = null;
            if(null == mfish_logic)
            {
                return;
            }

            if (!mfish_logic.LockFishInfo(lock_fish_id, ref lock_fish_kind, ref action_fish))
            {
                lock_fish_id = -1;
                mfish_logic.SetLockFish(LogicChairID, -1, FishKind.FISH_KIND_COUNT, null);
            }
            else
            {
                mfish_logic.SetLockFish(LogicChairID, lock_fish_id, lock_fish_kind, action_fish);
            }
        }

        protected void _OnUserShoot(object argv)
        {
            object[] argvs = argv as object[];
            int chairId = (int)argvs[0];
            float shootAngle = (float)argvs[1];
            long bulletId = (long)argvs[2];
            bool isAndroid = (bool)argvs[3];
            long userAndroidCharId = (long)argvs[4];
            float bullet_speed = (float)argvs[5];
            int locked_fish_id = (int)argvs[6];
            FishActionInterval action = argvs[7] as FishActionInterval;
            if (null != mfish_logic)
            {
                mfish_logic.Shoot(chairId, shootAngle, bulletId, isAndroid, userAndroidCharId, bullet_speed, locked_fish_id, action);
            }
        }

        protected void _OnSetSupperCannon(object argv)
        {
            object[] argvs = argv as object[];
            int chairId = (int)argvs[0];
            bool bSupperCannon = (bool)argvs[1];

            FishDataManager.Instance().SetSuperPao(chairId, bSupperCannon);
            var bulletType = FishDataManager.Instance().GetBulletType(chairId);

            if (bSupperCannon && bulletType <= 4)
            {
                AudioManager.Instance().PlaySound(2017);
            }
            else if (!bSupperCannon && bulletType > 4)
            {
                AudioManager.Instance().PlaySound(2018);
            }

            int cannonPower = FishDataManager.Instance().GetBulletPower(chairId);
            FishDataManager.Instance().UpDataBeiLv(chairId, cannonPower, false);
        }

        protected void _OnCatchFishChain(object argv)
        {
            CMD_S_CatchChain cmd = (CMD_S_CatchChain)argv;

            int total_score = 0;
            var powerLv = FishDataManager.Instance().GetBulletPower(cmd.chair_id);
            for (int i = 0; i < cmd.catch_fish.Length; ++i)
            {
                total_score += (int)cmd.catch_fish[i].fish_score;
                SetDeadFish(cmd.catch_fish[i].fish_id, cmd.chair_id, total_score, total_score / powerLv);
            }

            AddWinCoin(total_score / powerLv, total_score, cmd.chair_id);
            FishDataManager.Instance().UpDataUpScoreHitFish(cmd.chair_id, total_score);
        }

        protected void _OnCatchFishGroup(object argv)
        {
            CMD_S_CatchFishGroup catch_fish_group = (CMD_S_CatchFishGroup)argv;

            bool same_kind_fish = catch_fish_group.catch_fish[0].link_fish_id == -1 && catch_fish_group.catch_fish[0].fish_kind >= FishKind.FISH_DNTG && catch_fish_group.catch_fish[0].fish_kind <= FishKind.FISH_QJF;
            bool bomb = catch_fish_group.catch_fish[0].link_fish_id == -1 && (catch_fish_group.catch_fish[0].fish_kind == FishKind.FISH_FOSHOU || catch_fish_group.catch_fish[0].fish_kind == FishKind.FISH_BGLU);
            long total_score = 0;
            if (bomb)
                total_score = catch_fish_group.catch_fish[0].fish_score;

            int view_chair_id = FishDataManager.Instance().SwitchChairID(catch_fish_group.chair_id);

            for (int i = 0; i < catch_fish_group.catch_fish.Length; ++i)
            {
                if (catch_fish_group.catch_fish[i].bullet_double)
                {
                    EventManager.Instance().SendEvent(ClientEvent.CE_FISH_UPPER_SUPER_CANNON, new object[] { view_chair_id, true });
                }
                if (!bomb)
                {
                    FishDataManager.Instance().UpDataUpScoreHitFish(view_chair_id, catch_fish_group.catch_fish[i].fish_score);
                }
                if (!same_kind_fish)
                {
                    bool bingo = false;
                    bool bPlayWav = false;

                    bingo = catch_fish_group.catch_fish[i].fish_kind >= FishKind.FISH_YINSHA && (catch_fish_group.catch_fish[i].link_fish_id == -1);
                    if (catch_fish_group.catch_fish[i].fish_kind == FishKind.FISH_JINCHAN || catch_fish_group.catch_fish[i].fish_kind == FishKind.FISH_SHENXIANCHUAN)
                    {
                        bingo = false;
                    }

                    FishKind fish_kind = catch_fish_group.catch_fish[i].fish_kind;
                    bPlayWav = (fish_kind == FishKind.FISH_BAWANGJING || fish_kind == FishKind.FISH_XIAOJINLONG
                        || fish_kind == FishKind.FISH_SWK || fish_kind == FishKind.FISH_YUWANGDADI
                        || fish_kind == FishKind.FISH_YINSHA || fish_kind == FishKind.FISH_JINSHA);

                    if (bingo)
                    {
                        AddSqueeeScore(view_chair_id,(int)catch_fish_group.catch_fish[i].fish_score);
                    }

                    if (bingo || bomb)
                    {
                        AudioManager.Instance().PlaySound(2019);//bingo.ogg
                    }

                    var powerLv = FishDataManager.Instance().GetBulletPower(view_chair_id);

                    SetDeadFish(catch_fish_group.catch_fish[i].fish_id, view_chair_id, (int)catch_fish_group.catch_fish[i].fish_score,(int)(catch_fish_group.catch_fish[i].fish_score / powerLv));
                    AddWinCoin((int)catch_fish_group.catch_fish[i].fish_score / powerLv,(int)catch_fish_group.catch_fish[i].fish_score, view_chair_id);
                }
            }

            if (bomb)
            {
                FishDataManager.Instance().UpDataUpScoreHitFish(view_chair_id, total_score);
            }
        }

        //添加大鱼死后玩家前面的滚圈数字显示
        void AddSqueeeScore(int chairID, int FishScore)
        {
            //if (this->getChildByTag(chairID * 10 + 8) != NULL) return;
            if (FishScore <= 0) return;
            //SpriteFrameCache* cache = SpriteFrameCache::getInstance();
            //CCFishRewardLayer* m_SqueeBgimg = new CCFishRewardLayer();
            //float BeginPosY = m_UserData[chairID].m_PointY - 240;
            //float EndPosY = m_UserData[chairID].m_PointY + 200;
            if (chairID >= 3)
            {
                //BeginPosY = m_UserData[chairID].m_PointY + 240;
                //EndPosY = m_UserData[chairID].m_PointY - 200;
                //m_SqueeBgimg->setRotation(180);
            }
            //m_SqueeBgimg->Render(0, FishScore);
            //m_SqueeBgimg->setPosition(Vec2(m_UserData[chairID].m_PointX, BeginPosY));
            //m_SqueeBgimg->setAnchorPoint(Vec2(0.5, 0.5));
            //m_SqueeBgimg->setTag(chairID * 10 + 8);
            //this->addChild(m_SqueeBgimg, -1);
            //ActionInterval* moveToAction = MoveTo::create(0.2f, Vec2(m_UserData[chairID].m_PointX, EndPosY));
            //ActionInterval* moveToAction1 = MoveTo::create(0.2f, Vec2(m_UserData[chairID].m_PointX, BeginPosY));
            //FiniteTimeAction* RemoveChild = CallFuncN::create(CC_CALLBACK_1(CCFishCommonLayer::RemoveChild, this));
            //m_SqueeBgimg->runAction(Sequence::create(moveToAction, DelayTime::create(5.5), moveToAction1, RemoveChild, NULL));
            //
        }

        protected void SetDeadFish(int fishID, int KillChairid, int Winscore, int fishKindScore)
        {
            if (null != mfish_logic)
            {
                mfish_logic.SetDeadFish(fishID, KillChairid, Winscore, fishKindScore);
            }
        }

        protected void AddWinCoin(int CoinNum, int m_FishScore_, int chairID)
        {
            if (CoinNum > 50) CoinNum = 50;

            if (null != mfish_logic)
            {
                mfish_logic.AddWinCoin(CoinNum, m_FishScore_, chairID);
            }
        }

        protected override sealed void _OnCloseFrame()
		{
            InvokeManager.Instance().RemoveInvoke(this);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_CHANGE_SCENE, _OnChangeFishScene);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_PLAYER_UP_SCORE_CHANGED, _OnPlayerScoreChanged);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_PLAYER_CANNON_CHANGED, _OnPlayerCannonChanged);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_LOCK_FISH, _OnLockFish);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_USER_SHOOT, _OnUserShoot);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_UPPER_SUPER_CANNON, _OnSetSupperCannon);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_CATCH_CHAIN, _OnCatchFishChain);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_FISH_CATCH_FISH_GROUP, _OnCatchFishGroup);
            FishDataManager.Instance().sceneAudioHandle = 0;
        }
	}
}