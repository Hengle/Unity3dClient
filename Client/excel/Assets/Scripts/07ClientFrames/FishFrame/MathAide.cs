using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameClient;

public class MathAide
{
    public static float CalcDistance(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }

    public static float CalcAngle(float x1, float y1, float x2, float y2)
    {
        float distance = CalcDistance(x1, y1, x2, y2);
        if (distance == 0.0f) return 0.0f;
        float sin_value = (x1 - x2) / distance;
        float angle = Mathf.Acos(sin_value);
        if (y1 < y2) angle = (float)(2 * FishConfig.M_PI - angle);
        angle += (float)(FishConfig.M_PI_2);
        return angle;
    }
    public static void BuildCircle(float center_x, float center_y, float radius, ref Vector2[] fish_pos,int fish_count)
    {
        //  assert(fish_count > 0);
        if(fish_pos == null)
        {
            fish_count = 0;
        }
        else
        {
            fish_count = Mathf.Min(fish_pos.Length, fish_count);
        }
        if (fish_count <= 0) return;
        float cell_radian = (float)(2 * FishConfig.M_PI / fish_count);
        // x = xo + r * cos(α)
        // y = yo + r * sin(α)
        for (int i = 0; i < fish_count; ++i)
        {
            fish_pos[i].y = center_y + radius * Mathf.Sin(i * cell_radian);
            fish_pos[i].x = center_x + radius * Mathf.Cos(i * cell_radian);
        }
    }
    public static void BuildCircle(float center_x, float center_y, float radius, ref MovePoint[] fish_pos, int fish_count, float rotate, float rotate_speed)
    {
        //assert(fish_count > 0);
        if (fish_count <= 0) return;
        float cell_radian = (float)(2 * FishConfig.M_PI / fish_count);

        // x = xo + r * cos(α)
        // y = yo + r * sin(α)
        Vector2 last_pos;
        // 这里计算好像有问题
        for (int i = 0; i < fish_count; ++i)
        {
            last_pos.x = center_x + radius * Mathf.Cos(i * cell_radian + rotate - rotate_speed);
            last_pos.y = center_y + radius * Mathf.Sin(i * cell_radian + rotate - rotate_speed);

            fish_pos[i].position_.x = center_x + radius * Mathf.Cos(i * cell_radian + rotate);
            fish_pos[i].position_.y = center_y + radius * Mathf.Sin(i * cell_radian + rotate);
            float temp_dis = CalcDistance(fish_pos[i].position_.x, fish_pos[i].position_.y, last_pos.x, last_pos.y);
            if (temp_dis != 0.0f)
            {
                float temp_value = (fish_pos[i].position_.x - last_pos.x) / temp_dis;
                if ((fish_pos[i].position_.y - last_pos.y) >= 0.0f)
                {
                    fish_pos[i].angle_ = Mathf.Acos(temp_value);
                }
                else
                {
                    fish_pos[i].angle_ = -Mathf.Acos(temp_value);
                }
            }
            else
            {
                fish_pos[i].angle_ = (float)FishConfig.M_PI_2;
            }
        }
    }

    public static void BuildLinear(float[] init_x, float[] init_y, int init_count, ref List<MovePoint> move_points, float distance)
    {
        move_points.Clear();
        if (init_count < 2) return;
        if (distance <= 0.0f) return;
        float distance_total = CalcDistance(init_x[init_count - 1], init_y[init_count - 1], init_x[0], init_y[0]);
        if (distance_total <= 0.0f) return;

        float cos_value = Mathf.Abs(init_y[init_count - 1] - init_y[0]) / distance_total;
        float temp_angle = Mathf.Acos(cos_value);

        if(true)
        {
            MovePoint point = new MovePoint();
            point.position_.x = init_x[0];
            point.position_.y = init_y[0];
            point.angle_ = 1.0f;
            move_points.Add(point);
        }
        float temp_distance = 0.0f;
        MovePoint temp_pos = new MovePoint();
        int size;
        while (temp_distance < distance_total)
        {
            MovePoint point = new MovePoint();
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
    public static void BuildLinear(float[] init_x, float[] init_y, int init_count, ref List<MovePoint> move_points, float distance, int firstCount)
    {
        if(null == move_points)
        {
            move_points = new List<MovePoint>();
        }
        move_points.Clear();
        for (int i = 0; i < firstCount; i++)
        {
            MovePoint pointFirst = new MovePoint();
            pointFirst.position_.x = -200;
            pointFirst.position_.y = -200;
            pointFirst.angle_ = 0;
            move_points.Add(pointFirst);
        }
        List<MovePoint> move_points_temp = new List<MovePoint>();
        if (init_count < 2) return;
        if (distance <= 0.0f) return;
        float distance_total = CalcDistance(init_x[init_count - 1], init_y[init_count - 1], init_x[0], init_y[0]);
        if (distance_total <= 0.0f) return;

        float cos_value = Mathf.Abs(init_y[init_count - 1] - init_y[0]) / distance_total;
        float temp_angle = Mathf.Acos(cos_value);

        if(true)
        {
            MovePoint point = new MovePoint();
            point.position_.x = init_x[0];
            point.position_.y = init_y[0];
            point.angle_ = 1.0f;
            move_points_temp.Add(point);
        }
        float temp_distance = 0.0f;
        MovePoint temp_pos = new MovePoint();
        int size;
        while (temp_distance < distance_total)
        {
            MovePoint point = new MovePoint();
            size = move_points_temp.Count;
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
            move_points_temp.Add(point);
            temp_distance = CalcDistance(point.position_.x, point.position_.y, init_x[0], init_y[0]);
        }
        for (int i = 0; i < move_points_temp.Count; i++)
        {
            move_points.Add(move_points_temp[i]);
        }
        MovePoint temp_point = move_points[move_points.Count - 1];
        temp_point.position_.x = init_x[init_count - 1];
        temp_point.position_.y = init_y[init_count - 1];
    }
}
