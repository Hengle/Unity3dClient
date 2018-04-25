using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
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
    [LuaCallCSharp]
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
    [LuaCallCSharp]
    public struct CMD_S_SwitchScene
    {
        public SceneKind next_scene;
        public ulong tick_count;
    };
    [LuaCallCSharp]
    public struct CMD_S_UserFire
    {
        public ulong tick_count;
        public short chair_id;
        public int bullet_id;
        public float angle;
        public bool bullet_double;
        public int bullet_mulriple;
        public int lock_fish_id;
        public bool isAndroidUser;
        public ulong userAndroidCharId;
    };
    [LuaCallCSharp]
    public struct CMD_S_BulletDoubleTimeout
    {
        public short chair_id;
    };
    [LuaCallCSharp]
    public struct CMD_S_ExchangeFishScore
    {
        public short chair_id;
        public long swap_fish_score;
        public long exchange_fish_score;
    };
    [LuaCallCSharp]
    public struct CatchFish
    {
        public int fish_id;
        public FishKind fish_kind;
        public long fish_score;
        public bool bullet_double;
        public int link_fish_id;
    };
    [LuaCallCSharp]
    public struct CMD_S_CatchChain
    {
        public short chair_id;
        public CatchFish[] catch_fish;
    };
    [LuaCallCSharp]
    public struct CMD_S_CatchFishGroup
    {
        public long tick_count;
        public short chair_id;
        public CatchFish[] catch_fish;
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
    [LuaCallCSharp]
    public struct CMD_C_ExchangeFishScore
    {
        public long exchange_score;
    };
    [LuaCallCSharp]
    struct CMD_C_UserFire
    {
        public int bullet_id_temp;
        public int tick_count;
        public float angle;
        public int lock_fish_id;
        public int bullet_mulriple;
    };
    [LuaCallCSharp]
    public struct CMD_C_CatchFish
    {
        public int fish_id;                                  // 鱼的编号
        public int bullet_mulriple;                            // 子弹倍数
        public short chair_id;                                    // 椅子编号
        public bool isDouble;                                   // 是否双倍
        public byte byFishKind;                                   // 鱼类型
    };
    [LuaCallCSharp]
    public class ClientGameConfig
    {
        public int exchange_ratio_userscore;
        public int exchange_ratio_fishscore;
        public int exchange_count;
        public int min_bullet_multiple;
        public int max_bullet_multiple;
        public float[] fish_speed = new float[(int)FishKind.FISH_KIND_COUNT];
        public float[] fish_bounding_radius = new float[(int)FishKind.FISH_KIND_COUNT];
        public int[] fish_bounding_count = new int[(int)FishKind.FISH_KIND_COUNT];
        public float[] bullet_speed = new float[(int)BulletKind.BULLET_KIND_COUNT];
        public float[] bullet_bounding_radius = new float[(int)BulletKind.BULLET_KIND_COUNT];
        public void Clear()
        {
            exchange_ratio_userscore = 0;
            exchange_ratio_fishscore = 0;
            exchange_count = 0;
            min_bullet_multiple = 1;
            max_bullet_multiple = 1;
            for(int i = 0; i < (int)FishKind.FISH_KIND_COUNT; ++i)
            {
                fish_speed[i] = 0.0f;
                fish_bounding_radius[i] = 0.0f;
                fish_bounding_count[i] = 1;
            }
            for (int i = 0; i < (int)BulletKind.BULLET_KIND_COUNT; ++i)
            {
                bullet_speed[i] = 0;
                bullet_bounding_radius[i] = 0;
            }
        }
    };
    [LuaCallCSharp]
    public class CMD_S_GameStatus
    {
        public int tick_count;
        public ClientGameConfig game_config = new ClientGameConfig();
        public long[] fish_score = new long[FishConfig.fish_player_count];
        public long[] exchange_fish_score = new long[FishConfig.fish_player_count];
        public string szGameRoomName;// 房间名称
        public void Clear()
        {
            tick_count = 0;
            game_config.Clear();
            for(int i = 0; i < fish_score.Length; ++i)
            {
                fish_score[i] = 0;
                exchange_fish_score[i] = 0;
            }
            szGameRoomName = string.Empty;
        }
    };

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
        protected static string[] ms_cannon_Paths = new string[]
        {
            "UI/Image/Packed/pck_ui_fish_main.png:paoguan",
            "UI/Image/Packed/pck_ui_fish_main.png:paoguan",
            "UI/Image/Packed/pck_ui_fish_main.png:paoguan",
            "UI/Image/Packed/pck_ui_fish_main.png:paoguan",
            "UI/Image/Packed/pck_ui_fish_main.png:paoguan",
            "UI/Image/Packed/pck_ui_fish_main.png:paoguan",
            "UI/Image/Packed/pck_ui_fish_main.png:paoguan",
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

        long[] m_UserScore = new long[FishConfig.fish_player_count];
        long[] m_UserUpScore = new long[FishConfig.fish_player_count];
        int[] m_ButtleType = new int[FishConfig.fish_player_count];
        int[] m_BeiLv = new int[FishConfig.fish_player_count];
        bool[] m_SupperPao = new bool[FishConfig.fish_player_count];
        int[] m_UserLockFishID = new int[FishConfig.fish_player_count];
        FishKind[] m_UserLockFishKind = new FishKind[FishConfig.fish_player_count];
        int[] m_RealChairID = new int[FishConfig.fish_player_count];
        Vector2[] m_UserData = new Vector2[FishConfig.fish_player_count]
        {
            new Vector2(0.0f,0.0f),new Vector2(0.0f,0.0f),new Vector2(0.0f,0.0f),new Vector2(0.0f,0.0f),new Vector2(0.0f,0.0f),new Vector2(0.0f,0.0f),
        };
        ClientGameConfig m_clientGameConfig = new ClientGameConfig();
        public ClientGameConfig GameConfig
        {
            get
            {
                return m_clientGameConfig;
            }
        }

        public void Clear()
        {
            mFishScene = SceneKind.SCENE_1;
            mCanSend = false;
            for(int i = 0; i < FishConfig.fish_player_count;++i)
            {
                m_UserLockFishKind[i] = FishKind.FISH_KIND_COUNT;
                m_UserLockFishID[i] = -1;
                m_UserUpScore[i] = 0;
                m_UserScore[i] = 0;
                m_ButtleType[i] = 0;
                m_BeiLv[i] = 1;
                m_SupperPao[i] = false;
                m_RealChairID[i] = i;
            }
        }

        public int GetRealChairID(int local)
        {
            if(local >= 0 && local < m_RealChairID.Length)
            {
                return m_RealChairID[local];
            }
            return 0;
        }

        public void ClearLockFish()
        {
            for (int i = 0; i < FishConfig.fish_player_count; ++i)
            {
                m_UserLockFishKind[i] = FishKind.FISH_KIND_COUNT;
                m_UserLockFishID[i] = -1;
            }
        }

        public FishData Get()
        {
            return mFishDataPool.Get();
        }

        public void SendCmdCatchFish(CMD_C_CatchFish cmd)
        {
            LogManager.Instance().LogErrorFormat("SendCmdCatchFish TO DO!");
            //CCGameRoomTcpSocket::GetManager()->Send((const char*)&catch_fish, sizeof(catch_fish), SUB_C_CATCH_FISH, MDM_GF_GAME);
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
            Clear();
        }

        ulong _current_time = 0;
        ulong _recieve_tick = 0;
        public ulong getCurrentTime()
        {
            return _current_time + ((ulong)(Time.time * 1000.0f) - _recieve_tick);
        }

        public void fixCurrentTime(ulong current)
        {
            _current_time = current;
            _recieve_tick = (ulong)(Time.time * 1000.0f);
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
        public void UpDataUpScoreHitFish(int chairID, long UpScore)
        {
            if(chairID >= 0 && chairID < m_UserUpScore.Length)
            {
                m_UserUpScore[chairID] += UpScore;
            }

            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_PLAYER_UP_SCORE_CHANGED, chairID);
        }

        public void UpDataUpScore(int chairID,long UpScore)
        {
            if (chairID >= 0 && chairID < m_UserUpScore.Length)
            {
                m_UserUpScore[chairID] = UpScore;
            }

            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_PLAYER_UP_SCORE_CHANGED, chairID);
        }

        public void SetSuperPao(int chairID,bool bSuperPao)
        {
            if(chairID >= 0 && chairID < m_SupperPao.Length)
            {
                m_SupperPao[chairID] = bSuperPao;
            }
        }

        public void SetUserScore(int chairID,long userScore)
        {
            if(chairID >= 0 && chairID < m_UserScore.Length)
            {
                m_UserScore[chairID] = userScore;
            }
        }

        public void UpDataBeiLv(int chairID, int BeiLv, bool Runaction)
        {
            if(chairID < 0 || chairID >= m_ButtleType.Length)
            {
                return;
            }

            int NowType = m_ButtleType[chairID];
            if (Runaction)
            {
                AudioManager.Instance().PlaySound(2104);//ChangeWeapon.ogg
            }

            m_BeiLv[chairID] = BeiLv;
            if (m_BeiLv[chairID] < 100)
            {
                m_ButtleType[chairID] = 2;
            }
            else if (m_BeiLv[chairID] >= 100 && m_BeiLv[chairID] < 1000)
            {
                m_ButtleType[chairID] = 3;
            }
            else
            {
                m_ButtleType[chairID] = 4;
            }
            if (m_SupperPao[chairID])
            {
                m_ButtleType[chairID] = m_ButtleType[chairID] + 3;
            }

            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_PLAYER_CANNON_CHANGED, chairID);
        }

        public long GetPlayerScore(int chairID)
        {
            if (chairID >= 0 && chairID < m_UserUpScore.Length)
            {
                return m_UserUpScore[chairID];
            }
            return 0;
        }

        public int GetBulletType(int chairID)
        {
            if (chairID >= 0 && chairID < m_ButtleType.Length)
            {
                return m_ButtleType[chairID];
            }
            return 0;
        }

        public int GetBulletPower(int chairID)
        {
            if (chairID >= 0 && chairID < m_BeiLv.Length)
            {
                return m_BeiLv[chairID];
            }
            return 0;
        }
        public string GetCannonPath(int cannonId)
        {
            if(cannonId >= 1 && cannonId <= ms_cannon_Paths.Length)
            {
                return ms_cannon_Paths[cannonId - 1];
            }
            return ms_cannon_Paths[0];
        }
        public int GetLockedFishId(int chairID)
        {
            if(chairID >= 0 && chairID < m_UserLockFishID.Length)
            {
                return m_UserLockFishID[chairID];
            }
            return -1;
        }

        public void SetLockedFishId(int chairID,int fishId)
        {
            if (chairID >= 0 && chairID < m_UserLockFishID.Length)
            {
                m_UserLockFishID[chairID] = fishId;
            }
        }

        public void CreateCatchChainCmd()
        {
            var cmd = new CMD_S_CatchChain();
            cmd.chair_id = 0;
            cmd.catch_fish = new CatchFish[3];
            for (int i = 0; i < cmd.catch_fish.Length; ++i)
            {
                cmd.catch_fish[i].fish_id = 199 + i;
                cmd.catch_fish[i].fish_kind = (FishKind.FISH_WONIUYU + i);
                cmd.catch_fish[i].fish_score = 100 + i * 1000;
                cmd.catch_fish[i].bullet_double = (i & 1) == 0;
                if (i > 0)
                {
                    cmd.catch_fish[i].link_fish_id = cmd.catch_fish[i - 1].fish_id;
                }
                else
                {
                    cmd.catch_fish[i].fish_id = 0;
                }
            }
            ExecuteCmd(cmd);
        }

        public void CreateSwitchScene(SceneKind scene)
        {
            CMD_S_SwitchScene kCmd = new CMD_S_SwitchScene();
            kCmd.next_scene = scene;
            kCmd.tick_count = 0;
            ExecuteCmd(kCmd);
        }

        public int SwitchChairID(short nCurChairId)
        {
            int changChairID = nCurChairId;
            switch (chairId)
            {
                case 0:
                case 1:
                case 2:
                    {
                        switch (nCurChairId)
                        {
                            case 0: return 0;
                            case 1: return 1;
                            case 2: return 2;
                            case 3: return 3;
                            case 4: return 4;
                            case 5: return 5;
                        }
                        break;
                    }
                case 3:
                case 4:
                case 5:
                    {
                        switch (nCurChairId)
                        {
                            case 0: return 3;
                            case 1: return 4;
                            case 2: return 5;
                            case 3: return 0;
                            case 4: return 1;
                            case 5: return 2;
                        }
                        break;
                    }
            }
            return changChairID;
        }

        #region execute_server_cmd
        [LuaCallCSharp]
        public void ExecuteCmd(CMD_S_SwitchScene cmd)
        {
            mFishScene = cmd.next_scene;

            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_CHANGE_SCENE);

            mCanSend = false;
        }
        [LuaCallCSharp]
        public void ExecuteCmd(CMD_S_UserFire cmd)
        {
            int LogicChairID = SwitchChairID(cmd.chair_id);
            BulletKind bullet_kind;
            if (cmd.bullet_mulriple < 100)
            {
                bullet_kind = cmd.bullet_double ? BulletKind.BULLET_2_DOUBLE : BulletKind.BULLET_2_NORMAL;
            }
            else if (cmd.bullet_mulriple >= 100 && cmd.bullet_mulriple < 1000)
            {
                bullet_kind = cmd.bullet_double ? BulletKind.BULLET_3_DOUBLE : BulletKind.BULLET_3_NORMAL;
            }
            else if (cmd.bullet_mulriple >= 1000)
            {
                bullet_kind = cmd.bullet_double ? BulletKind.BULLET_4_DOUBLE : BulletKind.BULLET_4_NORMAL;
            }
            else
                bullet_kind = BulletKind.BULLET_2_DOUBLE;

            if (cmd.chair_id != FishDataManager.Instance().chairId)
            {
                UpDataUpScoreHitFish(LogicChairID, -cmd.bullet_mulriple);

                float angle = cmd.angle;
                if (FishDataManager.Instance().chairId < 3)
                {
                    angle -= (float)FishConfig.M_PI;
                }

                UpDataBeiLv(LogicChairID, cmd.bullet_mulriple, false);

                EventManager.Instance().SendEvent(ClientEvent.CE_FISH_LOCK_FISH, new object[] { LogicChairID, cmd.lock_fish_id });

                EventManager.Instance().SendEvent(ClientEvent.CE_FISH_USER_SHOOT, new object[] { LogicChairID, angle,cmd.bullet_id, cmd.isAndroidUser, cmd.userAndroidCharId,500.0f, cmd.lock_fish_id ,null});
                //m_FishCommonLayer->UserShoot(LogicChairID, angle, cmd.bullet_id, cmd.isAndroidUser, cmd.userAndroidCharId,
                //    CCGameMyData::GetManager()->GetFishGameConfig().bullet_speed[bullet_kind], lock_fish_id, action_fish);
            }
            else
            {
                //TODO:
                //m_TimeOverCount = 120;
            }
        }
        [LuaCallCSharp]
        public void ExecuteCmd(CMD_S_BulletDoubleTimeout cmd)
        {
            int chairID = SwitchChairID(cmd.chair_id);
            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_UPPER_SUPER_CANNON, new object[] { chairID,false });
        }
        [LuaCallCSharp]
        public void ExecuteCmd(CMD_S_ExchangeFishScore cmd)
        {
            int chairID = SwitchChairID(cmd.chair_id);
            FishDataManager.Instance().UpDataUpScoreHitFish(chairID, cmd.swap_fish_score);
            FishDataManager.Instance().SetUserScore(chairID,cmd.exchange_fish_score);
        }
        [LuaCallCSharp]
        public void ExecuteCmd(CMD_S_CatchChain cmd)
        {
            int chairID = SwitchChairID(cmd.chair_id);
            cmd.chair_id = (short)chairID;
            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_CATCH_CHAIN, cmd);
        }
        [LuaCallCSharp]
        public void ExecuteCmd(CMD_S_CatchFishGroup catch_fish_group)
        {
            if(catch_fish_group.catch_fish.Length <= 0)
            {
                return;
            }

            EventManager.Instance().SendEvent(ClientEvent.CE_FISH_CATCH_FISH_GROUP, catch_fish_group);
        }
        [LuaCallCSharp]
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
            if (null == fishItem)
            {
                LogManager.Instance().LogErrorFormat("create fish failed !! which kind={0}:[id={1}] can not be found in fishtable !!!", cmd.fish_kind, (int)cmd.fish_kind);
                return;
            }

            float speed = fishItem.Speed;

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
        [LuaCallCSharp]
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
        [LuaCallCSharp]
        public void ExecuteCmd(CMD_S_GameStatus cmd)
        {
            m_clientGameConfig = cmd.game_config;
            //初始化个人信息
            for(int i = 0; i < FishConfig.fish_player_count; ++i)
            {
                int LogicChairID = SwitchChairID((short)i);
                UpDataUpScore(LogicChairID, cmd.fish_score[i]);
                SetUserScore(LogicChairID, cmd.exchange_fish_score[i]);
                UpDataBeiLv(LogicChairID, cmd.game_config.min_bullet_multiple, false);
            }
        }
        #endregion
    }
}