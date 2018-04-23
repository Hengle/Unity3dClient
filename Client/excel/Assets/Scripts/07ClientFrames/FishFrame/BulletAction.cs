using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    class FishActionBulletMove : FishActionInterval
    {
        public FishActionBulletMove(Vector2 position, float angle, float speed) : base(1)
        {
            bullet_speed_ = speed;
            position_ = position;
            angle_ = angle;

            dx_ = Mathf.Cos(angle_ - (float)FishConfig.M_PI_2);
            dy_ = Mathf.Sin(angle_ - (float)FishConfig.M_PI_2);
            butid = -1;
            ftime = 0;
        }

        public FishActionBulletMove():base(1)
        {

        }

        public void Create(Vector2 position, float angle, float speed)
        {
            elapsed_ = 0.0f;
            stop_ = false;
            duration_ = 1;
            bullet_speed_ = speed;
            position_ = position;
            angle_ = angle;

            dx_ = Mathf.Cos(angle_ - (float)FishConfig.M_PI_2);
            dy_ = Mathf.Sin(angle_ - (float)FishConfig.M_PI_2);
            butid = -1;
            ftime = 0;
        }

        public override bool IsDone()
        {
            return false;
        }

        public override void Step(float delta_time)
        {
            position_.x += bullet_speed_ * delta_time * dx_ * speed_;
            position_.y += bullet_speed_ * delta_time * dy_ * speed_;


            if (position_.x < 0.0f)
            {
                position_.x = -position_.x;
                dx_ = -dx_;
                angle_ = -angle_;
            }
            if (position_.x > FishConfig.kScreenWidth)
            {
                position_.x = FishConfig.kScreenWidth - (position_.x - FishConfig.kScreenWidth);
                dx_ = -dx_;
                angle_ = -angle_;
            }
            if (position_.y < 0.0f)
            {
                position_.y = -position_.y;
                dy_ = -dy_;
                angle_ = M_PI - angle_;
            }
            if (position_.y > FishConfig.kScreenHeight)
            {
                position_.y = FishConfig.kScreenHeight - (position_.y - FishConfig.kScreenHeight);
                dy_ = -dy_;
                angle_ = M_PI - angle_;
            }
        }

        public override void Stepbut(float delta_time, int butid_, long ftime_, long etime)
        {
            if (butid == butid_ && ftime_ - ftime < 10)
            {
                ftime = ftime_;
                return;
            }
            ftime = ftime_;
            butid = butid_;
            position_.x += bullet_speed_ * delta_time * dx_ * speed_;
            position_.y += bullet_speed_ * delta_time * dy_ * speed_;


            if (position_.x < 0.0f)
            {
                position_.x = -position_.x;
                dx_ = -dx_;
                angle_ = -angle_;
            }
            if (position_.x > FishConfig.kScreenWidth)
            {
                position_.x = FishConfig.kScreenWidth - (position_.x - FishConfig.kScreenWidth);
                dx_ = -dx_;
                angle_ = -angle_;
            }
            if (position_.y < 0.0f)
            {
                position_.y = -position_.y;
                dy_ = -dy_;
                angle_ = M_PI - angle_;
            }
            if (position_.y > FishConfig.kScreenHeight)
            {
                position_.y = FishConfig.kScreenHeight - (position_.y - FishConfig.kScreenHeight);
                dy_ = -dy_;
                angle_ = M_PI - angle_;
            }
        }

        private float bullet_speed_;
        private float dx_;
        private float dy_;
        private int butid;
        private long ftime;
    };
    //------------------------------------------------------------------------------
    class FishActionBulletMoveTo : FishActionInterval
    {
        public FishActionBulletMoveTo():base(1)
        {

        }

        public FishActionBulletMoveTo(Vector2 start, Vector2 end, float angle, float speed) : base(1)
        {
            bullet_speed_ = speed;
            start_ = start;
            end_ = end;
            position_ = start;
            angle_ = angle;
            delta_ = new Vector2(end_.x - start_.x, end_.y - start_.y);
            float length = Mathf.Sqrt(delta_.x * delta_.x + delta_.y * delta_.y);
            duration_ = length / bullet_speed_;
        }

        public void Create(Vector2 start, Vector2 end, float angle, float speed)
        {
            duration_ = 1;
            elapsed_ = 0.0f;
            stop_ = false;

            bullet_speed_ = speed;
            start_ = start;
            end_ = end;
            position_ = start;
            angle_ = angle;
            delta_ = new Vector2(end_.x - start_.x, end_.y - start_.y);
            float length = Mathf.Sqrt(delta_.x * delta_.x + delta_.y * delta_.y);
            duration_ = length / bullet_speed_;
        }

        public override void Update(float time)
        {
            position_.x = start_.x + delta_.x * time;
            position_.y = start_.y + delta_.y * time;
        }

        private float bullet_speed_;
        private Vector2 start_;
        private Vector2 end_;
        private Vector2 delta_;
    };
}