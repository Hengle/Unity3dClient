using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    class FishConfig
    {
        public const int kFPS = 60;              // 帧率
        public const float kSpeed = 1.0f / kFPS;  // 速度
        public const float kScreenWidth = 1366.0f;
        public const float kScreenHeight = 768.0f;
        public const int fish_pre_load_count = 5;
        public const double M_E = 2.71828182845904523536;
        public const double M_LOG2E = 1.44269504088896340736;   // log2(e)
        public const double M_LOG10E = 0.434294481903251827651;   // log10(e)
        public const double M_LN2 = 0.693147180559945309417;  // ln(2)
        public const double M_LN10 = 2.30258509299404568402;  // ln(10)
        public const double M_PI = 3.14159265358979323846;  // ln(10)
        public const double M_PI_2 = 1.57079632679489661923;   // pi/2
        public const double M_PI_4 = 0.785398163397448309616;  // pi/4
        public const double M_1_PI = 0.318309886183790671538;  // 1/pi
        public const double M_2_PI = 0.636619772367581343076;  // 2/pi
        public const double M_2_SQRTPI = 1.12837916709551257390;   // 2/sqrt(pi)
        public const double M_SQRT2 = 1.41421356237309504880;   // sqrt(2)
        public const double M_SQRT1_2 = 0.707106781186547524401;  // 1/sqrt(2)
        public const int fish_player_count = 6;
        //玩家坐标
        public Vector2[] USERPOINT = new Vector2[]{
                new Vector2(1039.5f, kScreenHeight - 730.0f),
                new Vector2(608.5f, kScreenHeight - 730.0f),
                new Vector2(177.5f, kScreenHeight - 730.0f ),
                new Vector2(326.5f, kScreenHeight - 38.0f),
                new Vector2(757.5f, kScreenHeight - 38.0f),
                new Vector2(1188.5f, kScreenHeight - 38.0f)
        };
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

        /// <summary>
        /// 两阶贝塞尔曲线
        /// </summary>
        /// <param name="P0"></param>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 BezierCurve(Vector2 P0, Vector2 P1, Vector2 P2, float t)
        {
            Vector2 B = Vector2.zero;
            float t1 = (1 - t) * (1 - t);
            float t2 = t * (1 - t);
            float t3 = t * t;
            B = P0 * t1  + 2 * P1 * t2 + P2 * t3;
            return B;
        }

        /// <summary>
        /// 三阶贝塞尔曲线
        /// </summary>
        /// <param name="P0"></param>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="P3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 BezierCurve(Vector2 P0, Vector2 P1, Vector2 P2, Vector2 P3, float t)
        {
            Vector2 B = Vector2.zero;
            float t1 = (1 - t) * (1 - t) * (1 - t);
            float t2 = t * (1 - t) * (1 - t);
            float t3 = t * t * (1 - t);
            float t4 = t * t * t;
            B = P0 * t1 + 3 * P1 * t2 + 3 * P2 * t3  + P3 * t4;
            return B;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="move_points"></param>
        /// <param name="min_distance">鱼单帧能移动的距离，用来过滤无效的采样点</param>
        /// <param name="speedType">强制重复插点类型</param>
        /// <param name="step">采样精度</param>
        public static void BuildBezier(Vector2[] points, ref List<MovePoint> move_points,float min_distance, FishSpeedType speedType = FishSpeedType.FISHSPEED_LEVEL0,float step = 0.001f)
        {
            if (null == move_points)
            {
                move_points = new List<MovePoint>(100);
            }

            move_points.Clear();

            if (points.Length >= 3 && points.Length <=4)
            {
                float t = 0.0f;
                while (t < 1.0f)
                {
                    Vector2 point = Vector2.zero;

                    if(points.Length == 3)
                    {
                        point = BezierCurve(points[0], points[1], points[2], t);
                    }
                    else
                    {
                        point = BezierCurve(points[0], points[1], points[2], points[3], t);
                    }

                    if(move_points.Count <= 0)
                    {
                        move_points.Add(new MovePoint {  position_ = point, angle_ = 0});

                        for (int i = 0; i < (int)speedType; ++i)
                        {
                            move_points.Add(new MovePoint { position_ = point, angle_ = 0 });
                        }
                    }
                    else
                    {
                        MovePoint back_point = move_points[move_points.Count - 1];
                        Vector2 back_pos = back_point.position_;
                        Vector2 vector = point - back_pos;
                        back_point.angle_ = Mathf.Atan2(vector.y, vector.x);
                        //modify angle for force push_point
                        for(int i = 1; i <= (int)speedType;++i)
                        {
                            int modifyIndex = move_points.Count - 1 - i;
                            if(modifyIndex >= 0)
                            {
                                move_points[move_points.Count - 1].angle_ = back_point.angle_;
                            }
                        }

                        if (vector.magnitude >= min_distance)
                        {
                            move_points.Add(new MovePoint { position_ = point, angle_ = back_point.angle_ });

                            for(int i = 0; i < (int)speedType; ++i)
                            {
                                move_points.Add(new MovePoint { position_ = point, angle_ = back_point.angle_ });
                            }
                        }
                    }
                    t += step;
                }
            }
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

            for(int i = 0; i < move_points.Count; ++i)
            {
                LogManager.Instance().LogFormat("<color=#00ff00>[point[{0}]]:[{1},{2}]</color>", i, move_points[i].position_.x, move_points[i].position_.y);
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

    public enum BulletKind
    {
        BULLET_2_NORMAL = 0,
        BULLET_3_NORMAL,
        BULLET_4_NORMAL,
        BULLET_2_DOUBLE,
        BULLET_3_DOUBLE,
        BULLET_4_DOUBLE,

        BULLET_KIND_COUNT
    };
    public enum TraceType
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
    public enum FishSpeedType
    {
        FISHSPEED_LEVEL0 = 0,
        FISHSPEED_LEVEL1,
        FISHSPEED_LEVEL2,
        FISHSPEED_LEVEL3,
        FISHSPEED_LEVEL4,
        FISHSPEED_LEVEL5,
    };
    public enum SceneKind
    {
        SCENE_1 = 0,
        SCENE_2,
        SCENE_3,
        SCENE_4,
        SCENE_5,
        SCENE_6,

        SCENE_COUNT
    };
    public enum FishKind
    {
        FISH_WONIUYU = 0,         // 蜗牛鱼
        FISH_LVCAOYU,             // 绿草鱼
        FISH_HUANGCAOYU,          // 黄草鱼
        FISH_DAYANYU,             // 大眼鱼
        FISH_HUANGBIANYU,         // 黄边鱼
        FISH_XIAOCHOUYU,          // 小丑鱼
        FISH_XIAOCIYU,            // 小刺鱼
        FISH_LANYU,               // 蓝鱼
        FISH_DENGLONGYU,          // 灯笼鱼
        FISH_HAIGUI,              // 海龟
        FISH_HUABANYU,            // 花斑鱼
        FISH_HUDIEYU,             // 蝴蝶鱼
        FISH_KONGQUEYU,           // 孔雀鱼
        FISH_JIANYU,              // 剑鱼
        FISH_BIANFUYU,            // 蝙蝠鱼
        FISH_YINSHA,              // 银鲨
        FISH_JINSHA,              // 金鲨
        FISH_BAWANGJING,          // 霸王鲸
        FISH_JINCHAN,             // 金蝉
        FISH_SHENXIANCHUAN,       // 神仙船
        FISH_MEIRENYU,            // 美人鱼
        FISH_XIAOQINGLONG,        // 小青龙
        FISH_XIAOYINLONG,         // 小银龙
        FISH_XIAOJINLONG,         // 小金龙
        FISH_SWK,                 // 孙悟空
        FISH_YUWANGDADI,          // 玉皇大帝
        FISH_FOSHOU,              // 佛手
        FISH_BGLU,                // 炼丹炉
        FISH_DNTG,                // 大闹天宫 (FISH_WONIUYU-FISH_HAIGUI)
        FISH_YJSD,                // 一箭双雕
        FISH_YSSN,                // 一石三鸟
        FISH_QJF,                 // 全家福
        FISH_YUQUN,               // 鱼群 (FISH_WONIUYU-FISH_HAIGUI)
        FISH_CHAIN,               // 闪电鱼 (FISH_WONIUYU-FISH_LANYU) 连 (FISH_WONIUYU-FISH_DENGLONGYU)

        FISH_KIND_COUNT
    };
}