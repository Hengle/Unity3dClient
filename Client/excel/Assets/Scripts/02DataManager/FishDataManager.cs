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

        }

        public FishDataPool():base(OnGet,OnRelease)
        {

        }
    }

    public class FishDataManager
    {
        protected static FishDataManager ms_handle = null;
        private FishDataPool mFishDataPool = new FishDataPool();

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

        public void ExecuteCmd(CMD_S_SceneFish cmd)
        {
            LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>ExecuteCmd CMD_S_SceneFish !!!</color>");
            LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>fish_id:{0} fish_kind:{1} fish_pos_count:{2}</color>", cmd.fish_id,cmd.fish_kind, cmd.position_count);
            for(int i = 0; i < cmd.position_count && i < cmd.position.Length; ++i)
            {
                LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>fish_pos[{0}]={1}</color>", i, cmd.position[i]);
            }
            LogManager.Instance().LogProcessFormat(10002000, "<color=#00ff00>fish_tag:{0} fish_elapsed:{1} fish_tick_count:{2}</color>", cmd.tag,cmd.elapsed,cmd.tick_count);

            if (chairId < 3)
            {
                //for (int j = 0; j < cmd.position_count && j < cmd.position.Length; ++j)
                //{
                //    cmd.position[j].x = FishConfig.kScreenWidth - cmd.position[j].x;
                //    cmd.position[j].y = FishConfig.kScreenHeight - cmd.position[j].y;
                //}
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
                action = new FishActionFishMoveFoshou(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y));
            }
            else
            {
                if (cmd.position_count == 3)
                {
                    action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y));
                }
                else if (cmd.position_count == 4)
                {
                    action = new FishActionFishMoveBezier(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y), new Vector2(cmd.position[2].x, cmd.position[2].y), new Vector2(cmd.position[3].x, cmd.position[3].y));
                }
                else
                {
                    action = new FishActionFishMoveLinear(speed, new Vector2(cmd.position[0].x, cmd.position[0].y), new Vector2(cmd.position[1].x, cmd.position[1].y));
                }
            }

            var data = mFishDataPool.Get();
            data.fish_id = cmd.fish_id;
            data.action = action;
            data.tag = cmd.tag;
            data.elapsed = cmd.elapsed;
            data.tick_count = cmd.tick_count;
            data.fishItem = fishItem;

            EventManager.Instance().SendEvent(ClientEvent.CE_CREATE_FISH, data);
        }
    }
}