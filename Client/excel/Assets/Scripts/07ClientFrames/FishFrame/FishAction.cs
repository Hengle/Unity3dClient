using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    [System.Serializable]
    public class MovePoint
    {
        public MovePoint()
        {

        }

        public MovePoint(Vector2 position, float angle)
        {
            position_ = position;
            angle_ = angle;
        }

        public Vector2 position_;
        public float angle_;
    };
    //typedef List<MovePoint> MovePointVector;

    //------------------------------------------------------------------------------
    public class FishActionFishMove : FishActionInterval
    {
        public FishActionFishMove(float duration) : base(duration)
        { }

        public virtual Vector2 FishMoveTo(float elapsed)
        {
            return new Vector2();
        }
    };

    //------------------------------------------------------------------------------
    class FishActionFishMoveLinear : FishActionFishMove
    {
        public FishActionFishMoveLinear() : base(0)
        {
            start_ = Vector2.zero;
            end_ = Vector2.zero;
            fish_speed_ = 0.0f;
        }

        public void Create(float fish_speed, Vector2 start, Vector2 end)
        {
            duration_ = 0;
            start_ = start;
            end_ = end;
            fish_speed_ = fish_speed;
        }

        public FishActionFishMoveLinear(float fish_speed, Vector2 start, Vector2 end) : base(0)
        {
            start_ = start;
            end_ = end;
            fish_speed_ = fish_speed;
        }

        //virtual ~FishActionFishMoveLinear();

        public override void Start()
        {
            position_ = start_;
            delta_ = new Vector2(end_.x - start_.x, end_.y - start_.y);
            float length = delta_.magnitude;
            if (length > 0)
            {
                if (delta_.y >= 0)
                {
                    angle_ = Mathf.Acos(delta_.x / length);
                }
                else
                {
                    angle_ = -Mathf.Acos(delta_.x / length);
                }
            }
            duration_ = length / fish_speed_;
            base.Start();
        }

        public override void Update(float time)
        {
            position_.x = start_.x + delta_.x * time;
            position_.y = start_.y + delta_.y * time;
        }

        public override Vector2 FishMoveTo(float elapsed)
        {
            float time = Mathf.Min(1.0f, (elapsed_ + elapsed) / duration_);
            return new Vector2(start_.x + delta_.x * time, start_.y + delta_.y * time);
        }

        protected Vector2 start_;
        protected Vector2 end_;
        protected Vector2 delta_;
        protected float fish_speed_;
    };

    //------------------------------------------------------------------------------
    class FishActionFishMoveBezier : FishActionFishMove
    {
        public FishActionFishMoveBezier():base(0)
        {

        }

        public void Create(float fish_speed, Vector2 start, Vector2 c1, Vector2 end)
        {
            elapsed_ = 0.0f;
            stop_ = false;
            start_ = start;
            end_ = end;
            control1_ = c1;
            fish_speed_ = fish_speed;
            position_ = start_;
            Vector2[] points =
            {
                start,
                c1,
                end
            };

            FishCommonLogic.BuildBezier(points, ref move_points_, fish_speed * FishConfig.kSpeed);
            duration_ = FishConfig.kSpeed * move_points_.Count;
        }

        public void Create(float fish_speed, Vector2 start, Vector2 c1, Vector2 c2, Vector2 end)
        {
            elapsed_ = 0.0f;
            stop_ = false;
            start_ = start;
            end_ = end;
            control1_ = c1;
            control2_ = c2;
            fish_speed_ = fish_speed;
            position_ = start_;
            Vector2[] points =
            { start, c1, c2, end };
            float kSpeed = FishConfig.kSpeed;
            FishCommonLogic.BuildBezier(points, ref move_points_, fish_speed * FishConfig.kSpeed);
            duration_ = kSpeed * move_points_.Count;
        }

        public FishActionFishMoveBezier(float fish_speed, Vector2 start, Vector2 c1, Vector2 end)
                : base(0)
        {
            start_ = start;
            end_ = end;
            control1_ = c1;
            fish_speed_ = fish_speed;
            position_ = start_;
            Vector2[] points =
            {
                start,
                c1,
                end
            };

            float kSpeed = FishConfig.kSpeed;
            //FishCommonLogic.BuildBezier(points, ref move_points_);
            //FishCommonLogic.BuildBezier(points, 3, ref move_points_, fish_speed_ * kSpeed, FishSpeedType.FISHSPEED_LEVEL0);
            duration_ = kSpeed * move_points_.Count;
            /*
            for (int i = 0; i < move_points_.Count; ++i)
            {
                LogManager.Instance().LogFormat("<color=#00ff00>[point[{0}]]:[{1},{2}]</color>", i, move_points_[i].position_.x, move_points_[i].position_.y);
            }
            LogManager.Instance().LogFormat("<color=#00ff00>[duration_:{0}]</color>", duration_);
            */
        }

        public FishActionFishMoveBezier(float fish_speed, Vector2 start, Vector2 c1, Vector2 end, FishSpeedType speedType) : base(0)
        {
            start_ = start;
            end_ = end;
            control1_ = c1;
            fish_speed_ = fish_speed;
            position_ = start_;
            Vector2[] points = { start, c1, end };
            float kSpeed = FishConfig.kSpeed;
            FishCommonLogic.BuildBezier(points, 3, ref move_points_, fish_speed_ * kSpeed, speedType);
            duration_ = kSpeed * move_points_.Count;
        }


        public FishActionFishMoveBezier(float fish_speed, Vector2 start, Vector2 c1, Vector2 c2, Vector2 end)
            : base(0)
        {
            start_ = start;
            end_ = end;
            control1_ = c1;
            control2_ = c2;
            fish_speed_ = fish_speed;
            position_ = start_;
            Vector2[] points =
            { start, c1, c2, end };
            float kSpeed = FishConfig.kSpeed;
            FishCommonLogic.BuildBezier(points, 4,ref move_points_, fish_speed_ * kSpeed, FishSpeedType.FISHSPEED_LEVEL0);
            duration_ = kSpeed * move_points_.Count;
        }

        public FishActionFishMoveBezier(float fish_speed, Vector2 start, Vector2 c1, Vector2 end, int fish_order, TraceType traceType, bool isTrue) : base(0)
        {
            end_ = end;
            control1_ = c1;
            fish_speed_ = fish_speed;
            position_ = start_;
            float[] init_x = new float[2];
            float[] init_y = new float[2];
            init_x[1] = start.x;
            init_y[1] = start.y;
            float kSpeed = FishConfig.kSpeed;
            if (init_x[1] > 0)
            {
                init_x[0] = init_x[1] + fish_speed * fish_order * kSpeed * 3 * 20;
            }
            else
                init_x[0] = init_x[1] - fish_speed * fish_order * kSpeed * 3 * 20;
            init_y[0] = init_y[1];
            start_ = new Vector2(init_x[0], init_y[0]);
            Vector2[] points =
            { start, c1, end };

            List<MovePoint> movePointTemp = new List<MovePoint>(6);
            
            if (fish_order != 0)
                FishCommonLogic.BuildLinear(init_x, init_y, 2, ref move_points_, fish_speed_ * kSpeed);

            FishCommonLogic.BuildBezier(points, 3, ref movePointTemp, fish_speed_ * kSpeed, FishSpeedType.FISHSPEED_LEVEL0);
            for (int i = 0; i < movePointTemp.Count; i++)
            {
                move_points_.Add(movePointTemp[i]);
            }
            duration_ = kSpeed * move_points_.Count;
            
        }

        public FishActionFishMoveBezier(float fish_speed, Vector2 start, Vector2 c1, Vector2 c2, Vector2 end, float diatance):base(0)
        {
            end_ = end;
            control1_ = c1;
            control2_ = c2;
            fish_speed_ = fish_speed;
            position_ = start_;
            float[] init_x = new float[2];
            float[] init_y = new float[2];
            float kSpeed = FishConfig.kSpeed;
            init_x[1] = start.x;
            init_y[1] = start.y;
            if (init_x[1] > 0)
            {
                init_x[0] = init_x[1] + fish_speed * diatance * kSpeed;
            }
            else
                init_x[0] = init_x[1] - fish_speed * diatance * kSpeed;

            init_y[0] = init_y[1];
            start_ = new Vector2(init_x[0], init_y[0]);
            Vector2[] points =
            { start, c1, c2, end };
            List<MovePoint> movePointTemp = new List<MovePoint>();


            FishCommonLogic.BuildLinear(init_x, init_y, 2, ref move_points_, fish_speed_ * kSpeed);
            FishCommonLogic.BuildBezier(points, 4,ref movePointTemp, fish_speed_ * kSpeed, FishSpeedType.FISHSPEED_LEVEL0);
            for (int i = 0; i < movePointTemp.Count; i++)
            {
                move_points_.Add(movePointTemp[i]);
            }
            duration_ = kSpeed * move_points_.Count;
        }

        public FishActionFishMoveBezier(float fish_speed, Vector2 start, Vector2 c1, Vector2 end, int fish_order, TraceType traceType):base(0)
        {
            fish_speed_ = fish_speed;
            Vector2[] points = new Vector2[3];
            points[0] = start;
            points[1] = c1;
            points[2] = end;
            float kSpeed = FishConfig.kSpeed;
            fish_speed *= kSpeed * 2;
            float[] speed_change_distance = new float[2];
            float[] speed_change_mult = new float[2];
            speed_change_distance[0] = 0.2f;
            speed_change_distance[1] = 0.7f;
            speed_change_mult[0] = 1.5f;
            speed_change_mult[1] = 3;
            int fish_distance = 3;
            if (traceType == TraceType.TRACE_SPPEND_CHANGE_ONE)
            {
                if (fish_order == 1)
                {
                    points[0].x -= fish_speed * fish_distance * 3;
                    points[0].y -= fish_speed * fish_distance;
                    points[1].x -= fish_speed * fish_distance * 3 * 2;
                    points[1].y -= fish_speed * fish_distance * 2;
                    speed_change_distance[0] = 0.2f;
                    speed_change_distance[1] = 0.5f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 2.3f;
                }
                else if (fish_order == 2)
                {
                    points[0].x += fish_speed * fish_distance * 6;
                    points[0].y -= fish_speed * fish_distance * 3;
                    points[1].x += fish_speed * fish_distance * 6 * 2;
                    points[1].y -= fish_speed * fish_distance * 2 * 3;
                    speed_change_distance[0] = 0.3f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 2.5f;
                }
                else if (fish_order == 3)
                {
                    points[0].x -= fish_speed * fish_distance * 7;
                    points[0].y += fish_speed * fish_distance * 3;
                    points[1].x -= fish_speed * fish_distance * 7 * 2;
                    points[1].y += fish_speed * fish_distance * 2 * 3;
                    speed_change_distance[0] = 0.32f;
                    speed_change_distance[1] = 0.68f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 2.2f;
                }
                else if (fish_order == 4)
                {
                    points[0].x += fish_speed * fish_distance * 6;
                    points[0].y += fish_speed * fish_distance * 2;
                    points[1].x += fish_speed * fish_distance * 6 * 2;
                    points[1].y += fish_speed * fish_distance * 2 * 2;
                    speed_change_distance[0] = 0.3f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 2;
                    speed_change_mult[1] = 2;
                }
                else if (fish_order == 5)
                {
                    points[0].x += fish_speed * fish_distance * 3;
                    points[0].y += fish_speed * fish_distance * 7;
                    points[1].x += fish_speed * fish_distance * 3 * 2;
                    points[1].y += fish_speed * fish_distance * 7 * 2;
                    speed_change_distance[0] = 0.35f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 2;
                    speed_change_mult[1] = 2;
                }
                else if (fish_order == 6)
                {
                    points[0].x -= fish_speed * fish_distance * 7;
                    points[0].y += fish_speed * fish_distance * 4;
                    points[1].x -= fish_speed * fish_distance * 7 * 2;
                    points[1].y += fish_speed * fish_distance * 4 * 2;
                    speed_change_distance[0] = 0.35f;
                    speed_change_distance[1] = 0.55f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 2.3f;
                }
            }
            else if (traceType == TraceType.TRACE_SPPEND_CHANGE_TWO)
            {
                if (fish_order == 1)
                {
                    points[0].x -= fish_speed * fish_distance * 3;
                    points[0].y -= fish_speed * fish_distance;
                    points[1].x -= fish_speed * fish_distance * 3 * 2;
                    points[1].y -= fish_speed * fish_distance * 2;
                }
                else if (fish_order == 2)
                {
                    points[0].x += fish_speed * fish_distance * 4;
                    points[0].y -= fish_speed * fish_distance * 6;
                    points[1].x += fish_speed * fish_distance * 4 * 2;
                    points[1].y -= fish_speed * fish_distance * 6 * 2;
                    speed_change_distance[0] = 0.25f;
                    speed_change_distance[1] = 0.65f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 2.3f;
                }
                else if (fish_order == 3)
                {
                    points[0].x -= fish_speed * fish_distance * 3;
                    points[0].y += fish_speed * fish_distance * 7;
                    points[1].x -= fish_speed * fish_distance * 3 * 2;
                    points[1].y += fish_speed * fish_distance * 7 * 2;
                    speed_change_distance[0] = 0.1f;
                    speed_change_distance[1] = 0.68f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 2.1f;
                }
                else if (fish_order == 4)
                {
                    points[0].x += fish_speed * fish_distance * 3;
                    points[0].y += fish_speed * fish_distance;
                    points[1].x += fish_speed * fish_distance * 3 * 2;
                    points[1].y += fish_speed * fish_distance * 2;
                    speed_change_distance[0] = 0.3f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 2;
                    speed_change_mult[1] = 2;
                }
                else if (fish_order == 5)
                {
                    points[0].x += fish_speed * fish_distance * 5;
                    points[0].y += fish_speed * fish_distance * 4;
                    points[1].x += fish_speed * fish_distance * 5 * 2;
                    points[1].y += fish_speed * fish_distance * 4 * 2;
                    speed_change_distance[0] = 0.35f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 1.8f;
                    speed_change_mult[1] = 1.8f;
                }
                else if (fish_order == 6)
                {
                    points[0].x -= fish_speed * fish_distance * 7;
                    points[0].y += fish_speed * fish_distance * 4;
                    points[1].x -= fish_speed * fish_distance * 7 * 2;
                    points[1].y += fish_speed * fish_distance * 4 * 2;
                    speed_change_distance[0] = 0.4f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 2.0f;
                }
            }
            else if (traceType == TraceType.TRACE_SPPEND_CHANGE_THREE)
            {
                if (fish_order == 1)
                {
                    points[0].x -= fish_speed * fish_distance * 3;
                    points[0].y -= fish_speed * fish_distance;
                    points[1].x -= fish_speed * fish_distance * 3 * 2;
                    points[1].y -= fish_speed * fish_distance * 2;
                }
                else if (fish_order == 2)
                {
                    points[0].x += fish_speed * fish_distance * 4;
                    points[0].y -= fish_speed * fish_distance * 6;
                    points[1].x += fish_speed * fish_distance * 4 * 2;
                    points[1].y -= fish_speed * fish_distance * 6 * 2;

                    speed_change_distance[0] = 0.3f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 3.0f;
                }
                else if (fish_order == 3)
                {
                    points[0].x -= fish_speed * fish_distance * 3;
                    points[0].y += fish_speed * fish_distance * 7;
                    points[1].x -= fish_speed * fish_distance * 3 * 2;
                    points[1].y += fish_speed * fish_distance * 7 * 2;

                    speed_change_distance[0] = 0.32f;
                    speed_change_distance[1] = 0.68f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 3;
                }
                else if (fish_order == 4)
                {
                    points[0].x += fish_speed * fish_distance * 3;
                    points[0].y += fish_speed * fish_distance;
                    points[1].x += fish_speed * fish_distance * 3 * 2;
                    points[1].y += fish_speed * fish_distance * 2;

                    speed_change_distance[0] = 0.3f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 2;
                    speed_change_mult[1] = 2;
                }
                else if (fish_order == 5)
                {
                    points[0].x += fish_speed * fish_distance * 5;
                    points[0].y += fish_speed * fish_distance * 4;
                    points[1].x += fish_speed * fish_distance * 5 * 2;
                    points[1].y += fish_speed * fish_distance * 4 * 2;
                    speed_change_distance[0] = 0.35f;
                    speed_change_distance[1] = 0.6f;
                    speed_change_mult[0] = 2;
                    speed_change_mult[1] = 2;
                }
                else if (fish_order == 6)
                {
                    points[0].x -= fish_speed * fish_distance * 7;
                    points[0].y += fish_speed * fish_distance * 4;
                    points[1].x -= fish_speed * fish_distance * 7 * 2;
                    points[1].y += fish_speed * fish_distance * 4 * 2;
                    speed_change_distance[0] = 0.35f;
                    speed_change_distance[1] = 0.55f;
                    speed_change_mult[0] = 1.5f;
                    speed_change_mult[1] = 3;
                }
            }
            start_ = points[0];
            end_ = points[2];
            control1_ = points[1];
            position_ = points[0];
            FishCommonLogic.BuildBezierChangeSpeed2(points, 3, ref move_points_, fish_speed_ * kSpeed, speed_change_distance, speed_change_mult, 2);
            duration_ = kSpeed * move_points_.Count;
        }


        public FishActionFishMoveBezier(List<MovePoint> movePointVector) : base(0)
        {
            move_points_ = movePointVector;
            float kSpeed = FishConfig.kSpeed;
            duration_ = kSpeed * move_points_.Count;
        }

        public void Create(List<MovePoint> movePointVector)
        {
            move_points_ = movePointVector;
            float kSpeed = FishConfig.kSpeed;
            duration_ = kSpeed * move_points_.Count;
        }

        //virtual ~FishActionFishMoveBezier();

        public override void Start()
        {
            base.Start();
            position_ = start_;
        }

        public override void Update(float time)
        {
            float index = time * move_points_.Count;
            int idx = (int)index;
            float diff = index - idx;
            if (idx >= move_points_.Count)
                idx = move_points_.Count - 1;

            if (idx < move_points_.Count - 1)
            {
                MovePoint point1 = move_points_[idx];
                MovePoint point2 = move_points_[idx + 1];
                position_ = point1.position_ * (1.0f - diff) + point2.position_ * diff;
                //angle_ = point1.angle_ * (1.0f - diff) + point2.angle_ * diff;
                //if (Mathf.Abs(point1.angle_ - point2.angle_) > M_PI)
                angle_ = point1.angle_;
            }
            else
            {
                position_ = move_points_[idx].position_;
                angle_ = move_points_[idx].angle_;
            }
        }

        public override Vector2 FishMoveTo(float elapsed)
        {
            float time = Mathf.Min(1.0f, (elapsed_ + elapsed) / duration_);
            float index = time * move_points_.Count;
            int idx = (int)index;
            float diff = index - idx;
            if (idx >= move_points_.Count)
                idx = move_points_.Count - 1;

            Vector2 move_to = Vector2.zero;
            if (idx < move_points_.Count - 1)
            {
                MovePoint point1 = move_points_[idx];
                MovePoint point2 = move_points_[idx + 1];
                move_to = point1.position_ * (1.0f - diff) + point2.position_ * diff;
            }
            else
            {
                move_to = move_points_[idx].position_;
            }
            return move_to;
        }

        protected Vector2 start_;
        protected Vector2 end_;
        protected Vector2 control1_;
        protected Vector2 control2_;
        float fish_speed_;
        List<MovePoint> move_points_;
    };

    //------------------------------------------------------------------------------
    class FishActionFishMoveFoshou : FishActionFishMove
    {
        public FishActionFishMoveFoshou():base(1)
        {
            start_ = Vector2.zero;
            end_ = Vector2.zero;
            fish_speed_ = 0.0f;
            position_ = start_;
        }

        public void Create(float fish_speed, Vector2 start, Vector2 end)
        {
            start_ = start;
            end_ = end;
            fish_speed_ = fish_speed;
            position_ = start_;

            Vector2 delta = new Vector2(end_.x - start_.x, end_.y - start_.y);
            float length = delta.magnitude;
            if (length > 0)
            {
                if (delta.y >= 0)
                {
                    angle_ = Mathf.Acos(delta.x / length);
                }
                else
                {
                    angle_ = -Mathf.Acos(delta.x / length);
                }
            }
            dx_ = Mathf.Cos(angle_);
            dy_ = Mathf.Sin(angle_);
            duration_ = length / fish_speed_;
        }

        public FishActionFishMoveFoshou(float fish_speed, Vector2 start, Vector2 end) : base(1)
        {
            start_ = start;
            end_ = end;
            fish_speed_ = fish_speed;
            position_ = start_;

            Vector2 delta = new Vector2(end_.x - start_.x, end_.y - start_.y);
            float length = delta.magnitude;
            if (length > 0)
            {
                if (delta.y >= 0)
                {
                    angle_ = Mathf.Acos(delta.x / length);
                }
                else
                {
                    angle_ = -Mathf.Acos(delta.x / length);
                }
            }
            dx_ = Mathf.Cos(angle_);
            dy_ = Mathf.Sin(angle_);
            duration_ = length / fish_speed_;
        }
        //virtual ~FishActionFishMoveFoshou();

        public override bool IsDone()
        {
            return false;
        }

        public override void Start()
        {
            base.Start();
            position_ = start_;
        }

        public override void Step(float dt)
        {
            elapsed_ += dt * speed_;
            position_.x += fish_speed_ * dt * dx_ * speed_;
            position_.y += fish_speed_ * dt * dy_ * speed_;
            if (elapsed_ < duration_)
                return;

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

        public override Vector2 FishMoveTo(float elapsed)
        {
            Vector2 move_to = position_;
            float dx = dx_, dy = dy_;
            if (elapsed_ + elapsed < duration_)
            {
                move_to.x += fish_speed_ * elapsed * dx * speed_;
                move_to.y += fish_speed_ * elapsed * dy * speed_;
                return move_to;
            }
            else
            {
                float kSpeed = FishConfig.kSpeed;
                int count = (int)(elapsed / kSpeed);
                while ((count--) > 0)
                {
                    move_to.x += fish_speed_ * kSpeed * dx * speed_;
                    move_to.y += fish_speed_ * kSpeed * dy * speed_;

                    if (move_to.x < 0.0f)
                    {
                        move_to.x = -move_to.x;
                        dx = -dx;
                    }
                    if (move_to.x > FishConfig.kScreenWidth)
                    {
                        move_to.x = FishConfig.kScreenWidth - (move_to.x - FishConfig.kScreenWidth);
                        dx = -dx;
                    }
                    if (move_to.y < 0.0f)
                    {
                        move_to.y = -move_to.y;
                        dy = -dy;
                    }
                    if (move_to.y > FishConfig.kScreenHeight)
                    {
                        move_to.y = FishConfig.kScreenHeight - (move_to.y - FishConfig.kScreenHeight);
                        dy = -dy;
                    }
                }
                return move_to;
            }
        }

        protected Vector2 start_;
        protected Vector2 end_;
        protected float fish_speed_;
        protected float dx_;
        protected float dy_;
    };

    //------------------------------------------------------------------------------

    class ActionScene3FishMove : FishActionFishMove
    {
        public ActionScene3FishMove():base(0)
        {

        }

        public ActionScene3FishMove(Vector2 center, float radius, float rotate_duration, float start_angle, float rotate_angle, float move_duration, float fish_speed) : base(rotate_duration)
        {
            center_ = center;
            radius_ = radius;
            rotate_duration_ = rotate_duration;
            start_angle_ = start_angle;
            rotate_angle_ = rotate_angle;
            move_duration_ = move_duration;
            fish_speed_ = fish_speed;
            stage_ = 0;
            angle_ = M_PI_2 + start_angle_;
            position_.x = center_.x + radius_ * Mathf.Cos(start_angle_);
            position_.y = center_.y + radius_ * Mathf.Sin(start_angle_);
            duration_ = rotate_duration_;
        }

        public void Create(Vector2 center, float radius, float rotate_duration, float start_angle, float rotate_angle, float move_duration, float fish_speed)
        {
            center_ = center;
            radius_ = radius;
            rotate_duration_ = rotate_duration;
            start_angle_ = start_angle;
            rotate_angle_ = rotate_angle;
            move_duration_ = move_duration;
            fish_speed_ = fish_speed;
            stage_ = 0;
            angle_ = M_PI_2 + start_angle_;
            position_.x = center_.x + radius_ * Mathf.Cos(start_angle_);
            position_.y = center_.y + radius_ * Mathf.Sin(start_angle_);
            duration_ = rotate_duration_;
        }


        public override void Start()
        {
            base.Start();
            angle_ = M_PI_2 + start_angle_;
            duration_ = rotate_duration_;
            position_.x = center_.x + radius_ * Mathf.Cos(start_angle_);
            position_.y = center_.y + radius_ * Mathf.Sin(start_angle_);
        }

        public override void Step(float dt)
        {
            elapsed_ += dt * speed_;
            Update(Mathf.Min(1.0f, elapsed_ / duration_));
            if (stage_ == 0 && elapsed_ >= duration_)
            {
                stage_ = 1;
                elapsed_ -= duration_;
                duration_ = move_duration_;
                delta_.x = Mathf.Cos(angle_);
                delta_.y = Mathf.Sin(angle_);
            }
            if (stage_ != 0)
            {
                position_.x += fish_speed_ * dt * delta_.x * speed_;
                position_.y += fish_speed_ * dt * delta_.y * speed_;
            }
        }
        public override void Update(float time)
        {
            if (stage_ == 0)
            {
                float angle = start_angle_ + rotate_angle_ * time;
                position_.x = center_.x + radius_ * Mathf.Cos(angle);
                position_.y = center_.y + radius_ * Mathf.Sin(angle);
                angle_ = M_PI_2 + angle;
            }
        }

        public override Vector2 FishMoveTo(float elapsed)
        {
            if (stage_ == 0)
            {
                if (elapsed_ + elapsed >= duration_)
                {
                    float angle = start_angle_ + rotate_angle_;
                    Vector2 move_to = new Vector2(center_.x + radius_ * Mathf.Cos(angle), center_.y + radius_ * Mathf.Cos(angle));
                    float el = elapsed_ + elapsed - duration_;
                    int count = (int)(el / FishConfig.kSpeed);
                    while ((count--) > 0)
                    {
                        move_to.x += fish_speed_ * FishConfig.kSpeed * delta_.x * speed_;
                        move_to.y += fish_speed_ * FishConfig.kSpeed * delta_.y * speed_;
                    }
                    return move_to;
                }
                else
                {
                    float time = Mathf.Min(1.0f, (elapsed_ + elapsed) / duration_);
                    float angle = start_angle_ + rotate_angle_ * time;
                    return new Vector2(center_.x + radius_ * Mathf.Cos(angle), center_.y + radius_ * Mathf.Cos(angle));
                }
            }
            else
            {
                int count = (int)(elapsed / FishConfig.kSpeed);
                Vector2 move_to = position_;
                while ((count--) > 0)
                {
                    move_to.x += fish_speed_ * FishConfig.kSpeed * delta_.x * speed_;
                    move_to.y += fish_speed_ * FishConfig.kSpeed * delta_.y * speed_;
                }
                return move_to;
            }
        }

        private Vector2 center_;
        private float radius_;
        private float rotate_duration_;
        private float start_angle_;
        private float rotate_angle_;
        private float move_duration_;
        private Vector2 delta_;
        private float fish_speed_;
        private int stage_;
};

    //------------------------------------------------------------------------------

    class ActionScene4FishMove : FishActionFishMove
    {
        public ActionScene4FishMove():base(0)
        {

        }

        public ActionScene4FishMove(Vector2 center, float radius, float rotate_duration, float start_angle, float rotate_angle, float move_duration, float fish_speed) : base(0)
        {
            center_ = center;
            radius_ = radius;
            rotate_duration_ = rotate_duration;
            start_angle_ = start_angle;
            rotate_angle_ = rotate_angle;
            move_duration_ = move_duration;
            fish_speed_ = fish_speed;
            stage_ = -1;
            angle_ = M_PI_2 + start_angle_;
            if (radius == 0)
                stage_ = 0;
            position_.x = -500.0f;
            position_.y = -500.0f;
            save_position_.x = center_.x + radius_ * Mathf.Cos(start_angle_);
            save_position_.y = center_.y + radius_ * Mathf.Sin(start_angle_);
            if (stage_ != -1)
                position_ = save_position_;
            duration_ = rotate_duration_;
        }

        public void Create(Vector2 center, float radius, float rotate_duration, float start_angle, float rotate_angle, float move_duration, float fish_speed)
        {
            center_ = center;
            radius_ = radius;
            rotate_duration_ = rotate_duration;
            start_angle_ = start_angle;
            rotate_angle_ = rotate_angle;
            move_duration_ = move_duration;
            fish_speed_ = fish_speed;
            stage_ = -1;
            angle_ = M_PI_2 + start_angle_;
            if (radius == 0)
                stage_ = 0;
            position_.x = -500.0f;
            position_.y = -500.0f;
            save_position_.x = center_.x + radius_ * Mathf.Cos(start_angle_);
            save_position_.y = center_.y + radius_ * Mathf.Sin(start_angle_);
            if (stage_ != -1)
                position_ = save_position_;
            duration_ = rotate_duration_;
        }

        public override void Start()
        {
            base.Start();
            angle_ = M_PI_2 + start_angle_;
            duration_ = rotate_duration_;
            position_.x = -500.0f;
            position_.y = -500.0f;
            save_position_.x = center_.x + radius_ * Mathf.Cos(start_angle_);
            save_position_.y = center_.y + radius_ * Mathf.Sin(start_angle_);
            if (stage_ != -1)
                position_ = save_position_;
        }

        public override void Step(float dt)
        {
            elapsed_ += dt * speed_;
            Update(Mathf.Min(1.0f, elapsed_ / duration_));
            if (stage_ == 0 && elapsed_ >= duration_)
            {
                stage_ = 1;
                elapsed_ -= duration_;
                duration_ = move_duration_;
                delta_.x = Mathf.Cos(angle_);
                delta_.y = Mathf.Sin(angle_);
            }
            if (stage_ == 1)
            {
                position_.x += fish_speed_ * dt * delta_.x * speed_;
                position_.y += fish_speed_ * dt * delta_.y * speed_;
            }
        }
        public override void Update(float time)
        {
            if (stage_ != 1)
            {
                float angle = start_angle_ + rotate_angle_ * time;
                save_position_.x = center_.x + radius_ * Mathf.Cos(angle);
                save_position_.y = center_.y + radius_ * Mathf.Sin(angle);
                if (stage_ == -1 && save_position_.x >= center_.x && save_position_.y >= center_.y)
                {
                    stage_ = 0;
                }
                if (stage_ != -1)
                    position_ = save_position_;
                angle_ = M_PI_2 + angle;
            }
        }

        public override Vector2 FishMoveTo(float elapsed)
        {
            if (stage_ == 0)
            {
                if (elapsed_ + elapsed >= duration_)
                {
                    float angle = start_angle_ + rotate_angle_;
                    Vector2 move_to = new Vector2(center_.x + radius_ * Mathf.Cos(angle), center_.y + radius_ * Mathf.Cos(angle));
                    float el = elapsed_ + elapsed - duration_;
                    int count = (int)(el / FishConfig.kSpeed);
                    while ((count--) > 0)
                    {
                        move_to.x += fish_speed_ * FishConfig.kSpeed * delta_.x * speed_;
                        move_to.y += fish_speed_ * FishConfig.kSpeed * delta_.y * speed_;
                    }
                    return move_to;
                }
                else
                {
                    float time = Mathf.Min(1.0f, (elapsed_ + elapsed) / duration_);
                    float angle = start_angle_ + rotate_angle_ * time;
                    return new Vector2(center_.x + radius_ * Mathf.Cos(angle), center_.y + radius_ * Mathf.Cos(angle));
                }
            }
            else if (stage_ == 1)
            {
                int count = (int)(elapsed / FishConfig.kSpeed);
                Vector2 move_to = position_;
                while ((count--) > 0)
                {
                    move_to.x += fish_speed_ * FishConfig.kSpeed * delta_.x * speed_;
                    move_to.y += fish_speed_ * FishConfig.kSpeed * delta_.y * speed_;
                }
                return move_to;
            }
            else
            {
                return new Vector2(-500.0f, -500.0f);
            }
        }

        private Vector2 center_;
        private float radius_;
        private float rotate_duration_;
        private float start_angle_;
        private float rotate_angle_;
        private float move_duration_;
        private Vector2 delta_;
        private float fish_speed_;
        private int stage_;
        private Vector2 save_position_;
    };
}