using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    class MovePoint
    {
        public MovePoint()
        {
            angle_ = 0;
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
    class FishActionFishMove : FishActionInterval
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
            FishCommonLogic.BuildBezier(points, 3, ref move_points_, fish_speed_ * kSpeed, FishSpeedType.FISHSPEED_LEVEL0);
            duration_ = kSpeed * move_points_.Count;
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
                angle_ = point1.angle_ * (1.0f - diff) + point2.angle_ * diff;
                if (Mathf.Abs(point1.angle_ - point2.angle_) > M_PI)
                    angle_ = point1.angle_;
            }
            else
            {
                position_ = move_points_[idx].position_;
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
}