using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
    public struct CMD_S_SceneFish
    {
        public int fish_id;
        public FishKind fish_kind;
        public Vector2[] position;
        public int position_count;
        public int tag;
        public float elapsed;
        public ulong tick_count;
    };

    public struct CMD_S_DistributeFish
    {
        public FishKind fish_kind;
        public int fish_id;
        public int tag;
        public ulong tick_count;
        public int position_count;
        public Vector2[] position;
        public TraceType trace_type;
        public int fish_order;
    };

    public struct CMD_S_SwitchScene
    {
        public SceneKind next_scene;
        public ulong tick_count;
    };

    public class FishData
    {
        public int fish_id;
        public ProtoTable.FishTable fishItem;
        public FishActionFishMove action;
        public int tag;
        public float elapsed;
        public ulong tick_count;
    }

    class FishDataPool : GamePool.ObjectPool<FishData>
    {
        public static void OnGet(FishData x)
        {

        }

        public static void OnRelease(FishData x)
        {
            x.action = null;
            x.fishItem = null;
        }

        public FishDataPool():base(OnGet,OnRelease)
        {

        }
    }

    public class FishDataManager
    {
        protected static FishDataManager ms_handle = null;
        private FishDataPool mFishDataPool = new FishDataPool();
        protected static string[] ms_bgPaths = new string[]
            {
                "UI/Image/BG/fish_bg_1.png:fish_bg_1",
                "UI/Image/BG/fish_bg_2.png:fish_bg_2",
                "UI/Image/BG/fish_bg_3.png:fish_bg_3",
                "UI/Image/BG/fish_bg_4.png:fish_bg_4",
            };

        public int BgCount
        {
            get
            {
                return ms_bgPaths.Length;
            }
        }

        public string GetSceneBG(int index)
        {
            if(index >= 0 && index < ms_bgPaths.Length)
            {
                return ms_bgPaths[index];
            }
            return ms_bgPaths[0];
        }

        protected SceneKind mFishScene = SceneKind.SCENE_1;
        public SceneKind FishScene
        {
            get { return mFishScene; }
        }
        protected bool mCanSend = false;
        public bool CanSend
        {
            get
            {
                return mCanSend;
            }
            set
            {
                mCanSend = value;
            }
        }

        public void Clear()
        {
            mFishScene = SceneKind.SCENE_1;
            mCanSend = false;
        }

        public FishData Get()
        {
            return mFishDataPool.Get();
        }

        public void CreateFish(FishKind kind,int fish_id, FishActionFishMove action)
        {
            var fishItem = TableManager.Instance().GetTableItem<ProtoTable.FishTable>((int)kind + 1);
            if (null == fishItem)
            {
                LogManager.Instance().LogErrorFormat("create fish failed !! which kind={0}:[id={1}] can not be found in fishtable !!!", kind, (int)kind + 1);
                return;
            }

            var data = mFishDataPool.Get();
            data.fish_id = fish_id;
            data.action = action;
            data.tag = 0;
            data.elapsed = 0.0f;
            data.tick_count = 0;
            data.fishItem = fishItem;

            EventManager.Instance().SendEvent(ClientEvent.CE_CREATE_FISH, data);
        }

        public void Release(FishData data)
        {
            if(null != data)
            {
                mFishDataPool.Release(data);
            }
        }

        public static FishDataManager Instance()
        {
            if (null == ms_handle)
            {
                ms_handle = new FishDataManager();
            }
            return ms_handle;
        }

        public void Initialize()
        {
            chairId = 0;
        }

        public int chairId
        {
            get;set;
        }

        uint _bg_audio_handle = 0;
        public uint sceneAudioHandle
        {
            get
            {
                return _bg_audio_handle;
            }
            set
            {
                if(0 != _bg_audio_handle)
                AudioManager.Instance().Stop(_bg_audio_handle);
                _bg_audio_handle = value;
            }
        }

        public void ExecuteCmd(CMD_S_SceneFish cmd)
        {
            /*
            LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>ExecuteCmd CMD_S_SceneFish !!!</color>");
            LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>fish_id:{0} fish_kind:{1} fish_pos_count:{2}</color>", cmd.fish_id,cmd.fish_kind, cmd.position_count);
            for(int i = 0; i < cmd.position_count && i < cmd.position.Length; ++i)
            {
                LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>fish_pos[{0}]={1}</color>", i, cmd.position[i]);
            }
            LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>fish_tag:{0} fish_elapsed:{1} fish_tick_count:{2}</color>", cmd.tag,cmd.elapsed,cmd.tick_count);
            */
            if (chairId < 3)
            {
                for (int j = 0; j < cmd.position_count && j < cmd.position.Length; ++j)
                {
                    cmd.position[j].x = FishConfig.kScreenWidth - cmd.position[j].x;
                    cmd.position[j].y = FishConfig.kScreenHeight - cmd.position[j].y;
                }
            }

            var fishItem = TableManager.Instance().GetTableItem<ProtoTable.FishTable>((int)cmd.fish_kind);
            if(null == fishItem)
            {
                LogManager.Instance().LogErrorFormat("create fish failed !! which kind={0}:[id={1}] can not be found in fishtable !!!", cmd.fish_kind, (int)cmd.fish_kind);
                return;
            }

            float speed = fishItem.Speed * 0.001f;

            FishActionFishMove action = null;
            if (cmd.fish_kind == FishKind.FISH_FOSHOU)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveFoshou>(16);
                FishActionFishMoveFoshou actionFoshou = action as FishActionFishMoveFoshou;
                actionFoshou.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y));
            }
            else
            {
                if (cmd.position.Length == 3)
                {
                    action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                    FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                    actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y));
                }
                else if (cmd.position.Length == 4)
                {
                    action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                    FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                    actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), new Vector2(cmd.position[3].x, cmd.position[3].y));
                }
                else
                {
                    action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>(16);
                    FishActionFishMoveLinear actionLine = action as FishActionFishMoveLinear;
                    actionLine.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y));
                }
            }

            // TODO:服务器和本地时间同步
            ulong elasped = 0;// TimerManager::GetInstance()->GetDelayTick(cmd.tick_count);
            action.set_elapsed(cmd.elapsed + (float)(elasped) / 1000.0f);

            var data = mFishDataPool.Get();
            data.fish_id = cmd.fish_id;
            data.action = action;
            data.tag = cmd.tag;
            data.elapsed = cmd.elapsed;
            data.tick_count = cmd.tick_count;
            data.fishItem = fishItem;

            EventManager.Instance().SendEvent(ClientEvent.CE_CREATE_FISH, data);
        }

        public void ExecuteCmd(CMD_S_DistributeFish cmd)
        {
            if (chairId < 3)
            {
                for (int j = 0; j < cmd.position.Length; ++j)
                {
                    cmd.position[j].x = FishConfig.kScreenWidth - cmd.position[j].x;
                    cmd.position[j].y = FishConfig.kScreenHeight - cmd.position[j].y;
                }
            }

            FishActionFishMove action = null;

            var fishItem = TableManager.Instance().GetTableItem<ProtoTable.FishTable>((int)cmd.fish_kind);
            if (null == fishItem)
            {
                LogManager.Instance().LogErrorFormat("create fish failed !! which kind={0}:[id={1}] can not be found in fishtable !!!", cmd.fish_kind, (int)cmd.fish_kind);
                return;
            }

            float speed = fishItem.Speed * 0.001f;

            if (cmd.fish_kind == FishKind.FISH_FOSHOU)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveFoshou>(16);
                FishActionFishMoveFoshou actionFoshou = action as FishActionFishMoveFoshou;
                actionFoshou.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y));
            }
            else
            {
                if (cmd.trace_type == TraceType.TRACE_SPPEND_CHANGE_NINE)
                {
                    if (cmd.fish_kind == FishKind.FISH_YUWANGDADI)
                    {
                        action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                        FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                        actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), FishSpeedType.FISHSPEED_LEVEL3);
                    }
                    else if (cmd.fish_kind == FishKind.FISH_SWK)
                    {
                        action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                        FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                        actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), FishSpeedType.FISHSPEED_LEVEL1);
                        //action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), FishSpeedType.FISHSPEED_LEVEL1);
                    }
                    else if (cmd.fish_kind == FishKind.FISH_BAWANGJING)
                    {
                        action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                        FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                        actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), FishSpeedType.FISHSPEED_LEVEL2);
                        //action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), FishSpeedType.FISHSPEED_LEVEL2);
                    }
                    else if (cmd.fish_kind == FishKind.FISH_YINSHA || cmd.fish_kind == FishKind.FISH_JINSHA)
                    {
                        action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                        FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                        actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), FishSpeedType.FISHSPEED_LEVEL1);
                        //action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), FishSpeedType.FISHSPEED_LEVEL1);
                    }
                    else
                    {
                        action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                        FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                        actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y));
                        //action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y));
                    }
                }
                else if (cmd.trace_type <= TraceType.TRACE_SPPEND_CHANGE_THREE)
                {
                    action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                    FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                    actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), cmd.fish_order, cmd.trace_type);
                    //action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), cmd.fish_order, cmd.trace_type);
                }
                else
                {
                    action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>(16);
                    FishActionFishMoveBezier actionBezier = action as FishActionFishMoveBezier;
                    actionBezier.Create(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), cmd.fish_order, cmd.trace_type, true);
                    //action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), cmd.fish_order, cmd.trace_type, true);
                }
            }
            action.Step(0);

            var data = mFishDataPool.Get();
            data.fish_id = cmd.fish_id;
            data.action = action;
            data.tag = cmd.tag;
            data.elapsed = 0;
            data.tick_count = cmd.tick_count;
            data.fishItem = fishItem;

            EventManager.Instance().SendEvent(ClientEvent.CE_CREATE_FISH, data);

            // 提示
            if (cmd.fish_kind == FishKind.FISH_SWK || cmd.fish_kind == FishKind.FISH_YUWANGDADI
                || cmd.fish_kind == FishKind.FISH_BAWANGJING || cmd.fish_kind == FishKind.FISH_XIAOJINLONG
                || cmd.fish_kind == FishKind.FISH_MEIRENYU || cmd.fish_kind == FishKind.FISH_XIAOQINGLONG)
            {
                if (cmd.fish_kind == FishKind.FISH_SWK)
                {
                    //m_FishTipimg->initWithSpriteFrame(SpriteFrameCache::getInstance()->getSpriteFrameByName("notice_swk.png"));
                }
                else if (cmd.fish_kind == FishKind.FISH_YUWANGDADI)
                {
                    //m_FishTipimg->initWithSpriteFrame(SpriteFrameCache::getInstance()->getSpriteFrameByName("notice_ywdd.png"));
                }
                else if (cmd.fish_kind == FishKind.FISH_BAWANGJING)
                {
                    //m_FishTipimg->initWithSpriteFrame(SpriteFrameCache::getInstance()->getSpriteFrameByName("notice_Shark.png"));
                }
                else if (cmd.fish_kind == FishKind.FISH_XIAOJINLONG)
                {
                    //m_FishTipimg->initWithSpriteFrame(SpriteFrameCache::getInstance()->getSpriteFrameByName("notice_dragon.png"));
                }
                else if (cmd.fish_kind == FishKind.FISH_XIAOQINGLONG)
                {
                    //m_FishTipimg->initWithSpriteFrame(SpriteFrameCache::getInstance()->getSpriteFrameByName("notice_qinlong.png"));
                }
                else if (cmd.fish_kind == FishKind.FISH_MEIRENYU)
                {
                    //m_FishTipimg->initWithSpriteFrame(SpriteFrameCache::getInstance()->getSpriteFrameByName("notice_meirenyu.png"));
                }
                //m_FishTipimg->stopAllActions();
                //m_FishTipimg->setOpacity(255);
                //TODO: 5s alpha
                //ActionInterval* FadeOut = CCFadeOut::create(0.5f);
                //TODO: delay 3.0f 隐藏掉
                //m_FishTipimg->runAction(Sequence::create(CCDelayTime::create(3.0f), FadeOut, nullptr));

            }
        }

        public void ExecuteCmd(CMD_S_SwitchScene cmd)
        {
            mFishScene = cmd.next_scene;

            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_CHANGE_SCENE);

            mCanSend = false;
        }

        public void CreateSwitchScene(SceneKind scene)
        {
            CMD_S_SwitchScene kCmd = new CMD_S_SwitchScene();
            kCmd.next_scene = scene;
            kCmd.tick_count = 0;
            ExecuteCmd(kCmd);
        }
    }
}