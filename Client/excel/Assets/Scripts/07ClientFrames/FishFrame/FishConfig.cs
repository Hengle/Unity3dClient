using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    class FishConfig
    {
        public const int kFPS = 60;              // 帧率
        public const float kSpeed = 1.0f / kFPS;  // 速度
    }

    class FishCommonLogic
    {
        public static int Factorial(int number)
        {
            int factorial = 1;
            int temp = number;
            for (int i = 0; i < number; ++i)
            {
                factorial *= temp;
                --temp;
            }

            return factorial;
        }

        public static int Combination(int count, int r)
        {
            return Factorial(count) / (Factorial(r) * Factorial(count - r));
        }

        public static float CalcDistance(float x1, float y1, float x2, float y2)
        {
            return Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        public static void BuildBezier(Vector2[] points, int points_count, ref List<MovePoint> move_points, float distance, FishSpeedType speedType)
        {
            if(null == move_points)
            {
                move_points = new List<MovePoint>();
            }

            if (!(points_count >= 2 && points_count <= 4))
                return;
            //if(distance>200*kSpeed)
            //	distance*=	kSpeed;
            move_points.Clear();
            MovePoint point = new MovePoint(points[0], 0.0f);
            move_points.Add(point);

            int index = 0;
            MovePoint temp_pos0 = new MovePoint();
            MovePoint temp_pos = new MovePoint();
            float t = 0.0f;
            int count = points_count - 1;
            float temp_value = 0.0f;

            while (t < 1.0f)
            {
                temp_pos.position_.x = 0.0f;
                temp_pos.position_.y = 0.0f;
                index = 0;
                while (index <= count)
                {
                    temp_value = Mathf.Pow(t, (float)index) * Mathf.Pow(1.0f - t, (float)(count - index)) * Combination(count, index);
                    temp_pos.position_.x += points[index].x * temp_value;
                    temp_pos.position_.y += points[index].y * temp_value;
                    ++index;
                }

                MovePoint back_pos = move_points[move_points.Count - 1];
                temp_value = CalcDistance(back_pos.position_.x, back_pos.position_.y, temp_pos.position_.x, temp_pos.position_.y);

                if (temp_value >= distance)
                {
                    float temp_dis = CalcDistance(temp_pos.position_.x, temp_pos.position_.y, temp_pos0.position_.x, temp_pos0.position_.y);
                    if (temp_dis != 0.0f)
                    {
                        temp_value = (temp_pos.position_.x - temp_pos0.position_.x) / temp_dis;
                        if ((temp_pos.position_.y - temp_pos0.position_.y) >= 0.0f)
                        {
                            temp_pos.angle_ = Mathf.Acos(temp_value);
                        }
                        else
                        {
                            temp_pos.angle_ = -Mathf.Acos(temp_value);
                        }
                    }
                    else
                    {
                        temp_pos.angle_ = 0.0f;
                    }
                    move_points.Add(temp_pos);

                    for (int i = 0; i < (int)speedType; ++i)
                    {
                        move_points.Add(temp_pos);
                    }
                    temp_pos0.position_.x = temp_pos.position_.x;
                    temp_pos0.position_.y = temp_pos.position_.y;
                }

                t += 0.001f;
            }
        }

        public static void BuildBezierChangeSpeed1(Vector2[] points, int points_count, ref List<MovePoint> move_points, float distance, int multiplying, float[] speed_change_distance, float[] speed_change_mult, int changeSize)
        {

            if (!(points_count >= 2 && points_count <= 4))
                return;
            //if(distance>200*kSpeed)
            //	distance*=	kSpeed;
            move_points.Clear();
            MovePoint point = new MovePoint(points[0], 0.0f);
            move_points.Add(point);
            float countDistance = CalcDistance(points[0].x, points[0].y, points[2].x, points[2].y);
            int index = 0;
            MovePoint temp_pos0 = new MovePoint();
            MovePoint temp_pos = new MovePoint();
            float t = 0.0f;
            int count = points_count - 1;
            float temp_value = 0.0f;

            while (t < 1.0f)
            {
                temp_pos.position_.x = 0.0f;
                temp_pos.position_.y = 0.0f;
                index = 0;
                while (index <= count)
                {
                    temp_value = Mathf.Pow(t, (float)index) * Mathf.Pow(1.0f - t, (float)(count - index)) * Combination(count, index);
                    temp_pos.position_.x += points[index].x * temp_value;
                    temp_pos.position_.y += points[index].y * temp_value;
                    ++index;
                }

                MovePoint back_pos = move_points[move_points.Count - 1];
                temp_value = CalcDistance(back_pos.position_.x, back_pos.position_.y, temp_pos.position_.x, temp_pos.position_.y);
                for (int i = 0; i < changeSize; i++)
                {
                    if (i == changeSize - 1)
                    {
                        if (t >= (speed_change_distance[i] - multiplying * distance / countDistance))
                            distance *= speed_change_mult[i];
                    }
                    else
                    {
                        if (t >= (speed_change_distance[i] - multiplying * distance / countDistance) && t < (speed_change_distance[i + 1] - multiplying * distance / countDistance))
                            distance *= speed_change_mult[i];
                    }
                }
                if (temp_value >= distance)
                {
                    float temp_dis = CalcDistance(temp_pos.position_.x, temp_pos.position_.y, temp_pos0.position_.x, temp_pos0.position_.y);
                    if (temp_dis != 0.0f)
                    {
                        temp_value = (temp_pos.position_.x - temp_pos0.position_.x) / temp_dis;
                        if ((temp_pos.position_.y - temp_pos0.position_.y) >= 0.0f)
                        {
                            temp_pos.angle_ = Mathf.Acos(temp_value);
                        }
                        else
                        {
                            temp_pos.angle_ = -Mathf.Acos(temp_value);
                        }
                    }
                    else
                    {
                        temp_pos.angle_ = 0.0f;
                    }
                    move_points.Add(temp_pos);
                    temp_pos0.position_.x = temp_pos.position_.x;
                    temp_pos0.position_.y = temp_pos.position_.y;
                }
                for (int i = 0; i < changeSize; i++)
                {
                    if (i == changeSize - 1)
                    {
                        if (t >= (speed_change_distance[i] - multiplying * distance / countDistance))
                            distance /= speed_change_mult[i];
                    }
                    else
                    {
                        if (t >= (speed_change_distance[i] - multiplying * distance / countDistance) && t < (speed_change_distance[i + 1] - multiplying * distance / countDistance))
                            distance /= speed_change_mult[i];
                    }
                }
                t += 0.001f;
            }
        }
        public static void BuildBezierChangeSpeed2(Vector2[] points, int points_count, ref List<MovePoint> move_points, float distance, float[] speed_change_distance, float[] speed_change_mult, int changeSize)
        {

            if (!(points_count >= 2 && points_count <= 4))
                return;
            move_points.Clear();
            MovePoint point = new MovePoint(points[0], 0.0f);
            move_points.Add(point);
            float countDistance = CalcDistance(points[0].x, points[0].y, points[2].x, points[2].y);
            int index = 0;
            MovePoint temp_pos0 = new MovePoint();
            MovePoint temp_pos = new MovePoint();
            float t = 0.0f;
            int count = points_count - 1;
            float temp_value = 0.0f;

            while (t < 1.0f)
            {
                temp_pos.position_.x = 0.0f;
                temp_pos.position_.y = 0.0f;
                index = 0;
                while (index <= count)
                {
                    temp_value = Mathf.Pow(t, (float)index) * Mathf.Pow(1.0f - t, (float)(count - index)) * Combination(count, index);
                    temp_pos.position_.x += points[index].x * temp_value;
                    temp_pos.position_.y += points[index].y * temp_value;
                    ++index;
                }

                MovePoint back_pos = move_points[move_points.Count - 1];
                temp_value = CalcDistance(back_pos.position_.x, back_pos.position_.y, temp_pos.position_.x, temp_pos.position_.y);
                for (int i = 0; i < changeSize; i++)
                {
                    if (i == changeSize - 1)
                    {
                        if (t >= (speed_change_distance[i]))
                            distance *= speed_change_mult[i];
                    }
                    else
                    {
                        if (t >= (speed_change_distance[i]) && t < (speed_change_distance[i + 1]))
                            distance *= speed_change_mult[i];
                    }
                }
                if (temp_value >= distance)
                {
                    float temp_dis = CalcDistance(temp_pos.position_.x, temp_pos.position_.y, temp_pos0.position_.x, temp_pos0.position_.y);
                    if (temp_dis != 0.0f)
                    {
                        temp_value = (temp_pos.position_.x - temp_pos0.position_.x) / temp_dis;
                        if ((temp_pos.position_.y - temp_pos0.position_.y) >= 0.0f)
                        {
                            temp_pos.angle_ = Mathf.Acos(temp_value);
                        }
                        else
                        {
                            temp_pos.angle_ = -Mathf.Acos(temp_value);
                        }
                    }
                    else
                    {
                        temp_pos.angle_ = 0.0f;
                    }
                    move_points.Add(temp_pos);
                    temp_pos0.position_.x = temp_pos.position_.x;
                    temp_pos0.position_.y = temp_pos.position_.y;
                }
                for (int i = 0; i < changeSize; i++)
                {
                    if (i == changeSize - 1)
                    {
                        if (t >= (speed_change_distance[i]))
                            distance /= speed_change_mult[i];
                    }
                    else
                    {
                        if (t >= (speed_change_distance[i]) && t < (speed_change_distance[i + 1]))
                            distance /= speed_change_mult[i];
                    }
                }
                t += 0.001f;
            }
        }
        public static void BuildLinear(float[] init_x, float[] init_y, int init_count, ref List<MovePoint> move_points, float distance)
        {
            if (null == move_points)
            {
                move_points = new List<MovePoint>();
            }
            move_points.Clear();
            if (init_count < 2) return;
            if (distance <= 0.0f) return;
            float distance_total = CalcDistance(init_x[init_count - 1], init_y[init_count - 1], init_x[0], init_y[0]);
            if (distance_total <= 0.0f) return;

            float cos_value = Mathf.Abs(init_y[init_count - 1] - init_y[0]) / distance_total;
            float temp_angle = Mathf.Acos(cos_value);

            MovePoint point = new MovePoint();
            point.position_.x = init_x[0];
            point.position_.y = init_y[0];
            point.angle_ = 1.0f;
            move_points.Add(point);
            float temp_distance = 0.0f;
            MovePoint temp_pos = new MovePoint();
            int size;
            while (temp_distance < distance_total)
            {
                size = move_points.Count;
                if (init_x[init_count - 1] < init_x[0])
                {
                    point.position_.x = init_x[0] - Mathf.Sin(temp_angle) * (distance * size);
                }
                else
                {
                    point.position_.x = init_x[0] + Mathf.Sin(temp_angle) * (distance * size);
                }
                if (init_y[init_count - 1] < init_y[0])
                {
                    point.position_.y = init_y[0] - Mathf.Cos(temp_angle) * (distance * size);
                }
                else
                {
                    point.position_.y = init_y[0] + Mathf.Cos(temp_angle) * (distance * size);
                }
                float temp_dis = CalcDistance(point.position_.x, point.position_.y, temp_pos.position_.x, temp_pos.position_.y);
                if (temp_dis != 0.0f)
                {
                    float temp_value = (point.position_.x - temp_pos.position_.x) / temp_dis;
                    if ((point.position_.y - temp_pos.position_.y) >= 0.0f) point.angle_ = Mathf.Acos(temp_value);
                    else point.angle_ = -Mathf.Acos(temp_value);
                }
                else
                {
                    point.angle_ = 1.0f;
                }
                temp_pos.position_.x = point.position_.x;
                temp_pos.position_.y = point.position_.y;
                move_points.Add(point);
                temp_distance = CalcDistance(point.position_.x, point.position_.y, init_x[0], init_y[0]);
            }
            MovePoint temp_point = move_points[move_points.Count - 1];
            temp_point.position_.x = init_x[init_count - 1];
            temp_point.position_.y = init_y[init_count - 1];
        }
    }

    enum BulletKind
    {
        BULLET_2_NORMAL = 0,
        BULLET_3_NORMAL,
        BULLET_4_NORMAL,
        BULLET_2_DOUBLE,
        BULLET_3_DOUBLE,
        BULLET_4_DOUBLE,

        BULLET_KIND_COUNT
    };
    enum TraceType
    {
        TRACE_SPPEND_CHANGE_ONE = 0,
        TRACE_SPPEND_CHANGE_TWO = 1,
        TRACE_SPPEND_CHANGE_THREE = 2,
        TRACE_SPPEND_CHANGE_FOUR = 3,
        TRACE_SPPEND_CHANGE_FIVE = 4,
        TRACE_SPPEND_CHANGE_SIX = 5,
        TRACE_SPPEND_CHANGE_SEVEN = 6,
        TRACE_SPPEND_CHANGE_EIGHT = 7,
        TRACE_SPPEND_CHANGE_NINE = 8
    };
    enum FishSpeedType
    {
        FISHSPEED_LEVEL0 = 0,
        FISHSPEED_LEVEL1,
        FISHSPEED_LEVEL2,
        FISHSPEED_LEVEL3,
        FISHSPEED_LEVEL4,
        FISHSPEED_LEVEL5,
    };
    enum SceneKind
    {
        SCENE_1 = 0,
        SCENE_2,
        SCENE_3,
        SCENE_4,
        SCENE_5,
        SCENE_6,

        SCENE_COUNT
    };
}