using System.Collections.Generic;

namespace GameClient
{
    public class BulletData
    {
        public static List<BulletData> _recycled = new List<BulletData>(150);
        public static List<BulletData> _actived = new List<BulletData>(150);

        public void OnCreate()
        {
            m_bIsBadButtle = false;
        }

        public void OnRecycle()
        {

        }

        public static BulletData Create()
        {
            BulletData data = null;
            if (_recycled.Count == 0)
            {
                data = new BulletData();
                _actived.Add(data);
            }
            else
            {
                data = _recycled[0];
                _recycled.RemoveAt(0);
                _actived.Add(data);
            }

            data.OnCreate();
            return data;
        }

        public static void ThrowBulletToPool(BulletData data)
        {
            if (null != data)
            {
                _actived.Remove(data);
                data.OnRecycle();
                _recycled.Add(data);
            }
        }

        public bool m_IsAndroid;
        public long m_ButtleID;
        public int m_SendChairID;
        public int m_Status;
        public int m_ButtleType;
        public bool m_IsSupperButtle;
        public int m_sendtime;
        public float m_lockfish;
        public long m_HitFishID;
        public float bullet_speed_;
        public bool m_bIsBadButtle;
        public float bounding_radius_;
        public int bullet_mulriple;
        FishAction action_bullet_move_;
        public void ResetBulletActionMove(FishAction action)
        {
            if (null != action_bullet_move_)
            {
                FishAction.ThrowActionToPoll(action_bullet_move_);
                action_bullet_move_ = null;
            }
            action_bullet_move_ = action;
        }

        public void CancelLock()
        {
            m_lockfish = -1;
            ResetBulletActionMove(null);
            //FishActionBulletMove action = new FishActionBulletMove(action_bullet_move_->position(), action_bullet_move_->angle(), bullet_speed_);
            //action_bullet_move_delay_delete_.reset(action);
            //action_bullet_move_delay_delete_.swap(action_bullet_move_);
        }
    };
}