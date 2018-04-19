using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#include "math_aide.h"
//#include <math.h>

namespace GameClient
{
    public class FishSceneManager : Singleton<FishSceneManager>
    {
        public void BuildSceneFish(SceneKind scene_kind, int me_chair_id)
        {
            switch (scene_kind)
            {
                case SceneKind.SCENE_1:
                    {
                        //if (me_chair_id < 3)
                        //    BuildSceneFish6(me_chair_id);
                        //else
                        //    BuildSceneFish6Switch(me_chair_id);
                        break;
                    }
                case SceneKind.SCENE_2:
                    {
                        //BuildSceneFish5(me_chair_id);
                        break;
                    }
                case SceneKind.SCENE_3:
                    {
                        //BuildSceneFish3(me_chair_id);
                        break;
                    }
                case SceneKind.SCENE_4:
                    {
                        //BuildSceneFish1(me_chair_id);
                        break;
                    }
                case SceneKind.SCENE_5:
                    {
                        //BuildSceneFish4(me_chair_id);
                        break;
                    }
                case SceneKind.SCENE_6:
                    {
                        //BuildSceneFish2(me_chair_id);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        void BuildSceneFish1(int me_chair_id)
        {
            const float kFishSpeed = 60.0f;
            Vector2 kBenchmarkPos = new Vector2(520.0f, FishConfig.kScreenHeight / 2.0f);
            Vector2 center1 = new Vector2(-kBenchmarkPos.x, kBenchmarkPos.y);
            Vector2 center2 = new Vector2(FishConfig.kScreenWidth + kBenchmarkPos.x, kBenchmarkPos.y);
            int fish_id = 0;
            FishKind fish_kind;
            FishActionFishMove action = null;
            Vector2 start, end;
            // 中心2条大鱼 银龙和金龙
            fish_id = 0;
            fish_kind = FishKind.FISH_SWK;
            start.x = -kBenchmarkPos.x;
            start.y = kBenchmarkPos.y;
            end.x = FishConfig.kScreenWidth + kBenchmarkPos.x;
            end.y = kBenchmarkPos.y;
            SwitchViewPosition(me_chair_id, ref start, ref end);
            action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
            (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);

            //TODO:
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);


            fish_id = 1;
            fish_kind = FishKind.FISH_YUWANGDADI;
            start.x = FishConfig.kScreenWidth + kBenchmarkPos.x;
            start.y = kBenchmarkPos.y;
            end.x = -kBenchmarkPos.x;
            end.y = kBenchmarkPos.y;
            SwitchViewPosition(me_chair_id, ref start, ref end);
            action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
            (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);
            //TODO:
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);

            // 第1环左边
            fish_id = 2;
            fish_kind = FishKind.FISH_XIAOCHOUYU;
            float radius = 185.0f;
            float cell_radian = (float)(2 * FishConfig.M_PI / 25);
            for (int i = 0; i < 25; ++i)
            {
                start.x = center1.x + radius * Mathf.Cos(i * cell_radian);
                start.y = center1.y + radius * Mathf.Sin(i * cell_radian);
                end.x = start.x + FishConfig.kScreenWidth + kBenchmarkPos.x * 2;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);

                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }

            // 第1环右边
            fish_id += 25;
            fish_kind = FishKind.FISH_HUANGBIANYU;
            radius = 195.0f;
            for (int i = 0; i < 25; ++i)
            {
                start.x = center2.x + radius * Mathf.Cos(i * cell_radian);
                start.y = center2.y + radius * Mathf.Sin(i * cell_radian);
                end.x = start.x - FishConfig.kScreenWidth - kBenchmarkPos.x * 2;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }

            // 第2环左边
            fish_id += 25;
            fish_kind = FishKind.FISH_DAYANYU;
            radius = 287.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 30);
            for (int i = 0; i < 30; ++i)
            {
                start.x = center1.x + radius * Mathf.Cos(i * cell_radian);
                start.y = center1.y + radius * Mathf.Sin(i * cell_radian);
                end.x = start.x + FishConfig.kScreenWidth + kBenchmarkPos.x * 2;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }

            // 第2环右边
            fish_id += 30;
            fish_kind = FishKind.FISH_HUANGCAOYU;
            radius = 296.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 30);
            for (int i = 0; i < 30; ++i)
            {
                start.x = center2.x + radius * Mathf.Cos(i * cell_radian);
                start.y = center2.y + radius * Mathf.Sin(i * cell_radian);
                end.x = start.x - FishConfig.kScreenWidth - kBenchmarkPos.x * 2;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }

            // 第3环左边
            fish_id += 30;
            fish_kind = FishKind.FISH_LVCAOYU;
            radius = 363.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 35);
            for (int i = 0; i < 35; ++i)
            {
                start.x = center1.x + radius * Mathf.Cos(i * cell_radian);
                start.y = center1.y + radius * Mathf.Sin(i * cell_radian);
                end.x = start.x + FishConfig.kScreenWidth + kBenchmarkPos.x * 2;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }

            // 第3环右边
            fish_id += 35;
            fish_kind = FishKind.FISH_HUANGBIANYU;
            radius = 370.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 35);
            for (int i = 0; i < 35; ++i)
            {
                start.x = center2.x + radius * Mathf.Cos(i * cell_radian);
                start.y = center2.y + radius * Mathf.Sin(i * cell_radian);
                end.x = start.x - FishConfig.kScreenWidth - kBenchmarkPos.x * 2;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                (action as FishActionFishMoveLinear).Create(kFishSpeed, start, end);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
        }

        void SwitchViewPosition(int me_chair_id,ref Vector2 start, ref Vector2 end)
        {
            if (me_chair_id >= 3)
                return;
            start.x = FishConfig.kScreenWidth - start.x;
            start.y = FishConfig.kScreenHeight - start.y;
            end.x = FishConfig.kScreenWidth - end.x;
            end.y = FishConfig.kScreenHeight - end.y;
        }
    }
}

//SceneFishManager::SceneFishManager(CCFishItemLayer* fish_manager, const ClientGameConfig& client_game_config)
//	: m_FishItemLayer(fish_manager), game_config_(client_game_config)
//{
//}

//SceneFishManager::~SceneFishManager()
//{
//}
/*
void SceneFishManager::BuildSceneFish6(int me_chair_id)
{
    MovePointVector movePointVector[300];
    FishKind fish_kind;
    int fish_id = 0;
    int fish_pos_count = 0;
    int fish_pos_count_temp = 0;
    const float kFishSpeed = 120 * kSpeed;
    const float kLFish1Rotate = 720.f * M_PI / 180.f * 1 / 2;
    const float kRotateSpeed = 1.2f * M_PI / 180;
    const float radiusLittle = kScreenHeight / 8;
    const float radiusBig = kScreenHeight / 4;
    float littleDistance = sqrt(kScreenWidth * kScreenWidth * 1.0f + kScreenHeight * kScreenHeight) / 2 - (sqrt(2 * radiusLittle * 2 * radiusLittle * 2 * 1.0f) - 2 * radiusLittle) / 2 - 2 * radiusLittle - radiusBig;
    float littleDistanceLk = littleDistance + 2 * radiusLittle + 2 * radiusBig;
    float littleSpeed = littleDistance / (radiusBig / kFishSpeed);
    float littleSpeedLk = littleDistanceLk / (radiusBig / kFishSpeed);
    hgeVector fish_pos_start[20];
    hgeVector fish_pos_end[20];
    hgeVector fish_pos[40];
    MovePoint fish_point[40];
    hgeVector center;
    center.x = kScreenWidth / 2;
    center.y = kScreenHeight / 2;
    FishActionFishMove* action = NULL;
    fish_kind = FISH_WONIUYU;
    MathAide::BuildCircle(center.x, center.y, radiusBig, fish_pos, 40);
    float init_x[2], init_y[2];
    int stopCount = 0;
    int countTemp = 0;
    for (int i = 0; i < 40; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig, fish_point, 40, rotate, kRotateSpeed);
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    countTemp = movePointVector[fish_id].size();
    int n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig, fish_point, 40, rotate, kRotateSpeed);
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 40; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 40;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 9, fish_pos, 40);
    for (int i = 0; i < 40; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 9, fish_point, 40, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig / 10 * 9, fish_point, 40, rotate, kRotateSpeed);
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 40; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_WONIUYU;
    fish_id += 40;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 8, fish_pos, 30);
    for (int i = 0; i < 30; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 8, fish_point, 30, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig / 10 * 8, fish_point, 30, rotate, kRotateSpeed);
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 30; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 30;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 7, fish_pos, 30);
    for (int i = 0; i < 30; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 7, fish_point, 30, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig / 10 * 7, fish_point, 30, rotate, kRotateSpeed);
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 30; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_WONIUYU;
    fish_id += 30;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 6, fish_pos, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 6, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig / 10 * 6, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 20;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 5, fish_pos, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 5, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig / 10 * 5, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_WONIUYU;
    fish_id += 20;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 4, fish_pos, 10);
    for (int i = 0; i < 10; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 4, fish_point, 10, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig / 10 * 4, fish_point, 10, rotate, kRotateSpeed);
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 10; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 10;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 3, fish_pos, 10);
    for (int i = 0; i < 10; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 3, fish_point, 10, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x - n, center.y, radiusBig / 10 * 3, fish_point, 10, rotate, kRotateSpeed);
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 10; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_HUANGCAOYU;
    fish_id += 10;
    //右上
    MathAide::BuildCircle(kScreenWidth - radiusLittle, radiusLittle, radiusLittle, fish_pos_start, 20);
    float angle = atanf(kScreenWidth / kScreenHeight);
    hgeVector centerRight;
    centerRight.x = center.x + (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x - n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_DAYANYU;
    fish_id += 20;
    //左上
    MathAide::BuildCircle(radiusLittle, radiusLittle, radiusLittle, fish_pos_start, 20);
    centerRight.x = center.x - (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x - n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_HUANGBIANYU;
    fish_id += 20;
    //左下
    MathAide::BuildCircle(radiusLittle, kScreenHeight - radiusLittle, radiusLittle, fish_pos_start, 20);
    centerRight.x = center.x - (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x - n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_XIAOCHOUYU;
    fish_id += 20;
    //右下
    MathAide::BuildCircle(kScreenWidth - radiusLittle, kScreenHeight - radiusLittle, radiusLittle, fish_pos_start, 20);
    centerRight.x = center.x + (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x - n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_SWK;
    fish_id += 20;
    init_x[0] = kScreenWidth - radiusLittle;
    init_y[0] = radiusLittle;
    init_x[1] = center.x + (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    MovePoint movePoint;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] - n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_kind = FISH_SWK;
    fish_id += 1;
    init_x[0] = radiusLittle;
    init_y[0] = radiusLittle;
    init_x[1] = center.x - (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] - n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_kind = FISH_SWK;
    fish_id += 1;
    init_x[0] = radiusLittle;
    init_y[0] = kScreenHeight - radiusLittle;
    init_x[1] = center.x - (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] - n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_kind = FISH_SWK;
    fish_id += 1;
    init_x[0] = kScreenWidth - radiusLittle;
    init_y[0] = kScreenHeight - radiusLittle;
    init_x[1] = center.x + (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] - n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_id += 1;
}
void SceneFishManager::BuildSceneFish6Switch(int me_chair_id)
{
    MovePointVector movePointVector[300];
    FishKind fish_kind;
    int fish_id = 0;
    int fish_pos_count = 0;
    int fish_pos_count_temp = 0;
    const float kFishSpeed = 120 * kSpeed;
    const float kLFish1Rotate = 720.f * M_PI / 180.f * 1 / 2;
    const float kRotateSpeed = 1.2f * M_PI / 180;
    const float radiusLittle = kScreenHeight / 8;
    const float radiusBig = kScreenHeight / 4;
    float littleDistance = sqrt(kScreenWidth * kScreenWidth * 1.0f + kScreenHeight * kScreenHeight) / 2 - (sqrt(2 * radiusLittle * 2 * radiusLittle * 2 * 1.0f) - 2 * radiusLittle) / 2 - 2 * radiusLittle - radiusBig;
    float littleDistanceLk = littleDistance + 2 * radiusLittle + 2 * radiusBig;
    float littleSpeed = littleDistance / (radiusBig / kFishSpeed);
    float littleSpeedLk = littleDistanceLk / (radiusBig / kFishSpeed);
    hgeVector fish_pos_start[20];
    hgeVector fish_pos_end[20];
    hgeVector fish_pos[40];
    MovePoint fish_point[40];
    hgeVector center;
    center.x = kScreenWidth / 2;
    center.y = kScreenHeight / 2;
    FishActionFishMove* action = NULL;
    fish_kind = FISH_WONIUYU;
    MathAide::BuildCircle(center.x, center.y, radiusBig, fish_pos, 40);
    float init_x[2], init_y[2];
    int stopCount = 0;
    int countTemp = 0;
    int tempHalf = 0;
    for (int i = 0; i < 40; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig, fish_point, 40, rotate, kRotateSpeed);
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    countTemp = movePointVector[fish_id].size();
    int n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig, fish_point, 40, rotate, kRotateSpeed);
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 20;
    for (int i = 0; i < 40; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[i]);
        if (i + tempHalf < 40)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 40;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 9, fish_pos, 40);
    for (int i = 0; i < 40; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 9, fish_point, 40, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig / 10 * 9, fish_point, 40, rotate, kRotateSpeed);
        for (int j = 0; j < 40; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 20;
    for (int i = 0; i < 40; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 40)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_WONIUYU;
    fish_id += 40;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 8, fish_pos, 30);
    for (int i = 0; i < 30; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 8, fish_point, 30, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig / 10 * 8, fish_point, 30, rotate, kRotateSpeed);
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 15;
    for (int i = 0; i < 30; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 30)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 30;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 7, fish_pos, 30);
    for (int i = 0; i < 30; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 7, fish_point, 30, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig / 10 * 7, fish_point, 30, rotate, kRotateSpeed);
        for (int j = 0; j < 30; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 15;
    for (int i = 0; i < 30; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 30)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_WONIUYU;
    fish_id += 30;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 6, fish_pos, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 6, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig / 10 * 6, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 10;
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 20)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 20;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 5, fish_pos, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 5, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig / 10 * 5, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 10;
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 20)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_WONIUYU;
    fish_id += 20;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 4, fish_pos, 10);
    for (int i = 0; i < 10; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 4, fish_point, 10, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig / 10 * 4, fish_point, 10, rotate, kRotateSpeed);
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 5;
    for (int i = 0; i < 10; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 10)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_LVCAOYU;
    fish_id += 10;
    MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 3, fish_pos, 10);
    for (int i = 0; i < 10; ++i)
    {
        init_x[0] = center.x;
        init_y[0] = center.y;
        init_x[1] = fish_pos[i].x;
        init_y[1] = fish_pos[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], kFishSpeed, stopCount);
    }
    stopCount = movePointVector[fish_id].size();
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x, center.y, radiusBig / 10 * 3, fish_point, 10, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(center.x + n, center.y, radiusBig / 10 * 3, fish_point, 10, rotate, kRotateSpeed);
        for (int j = 0; j < 10; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 5;
    for (int i = 0; i < 10; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 10)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_HUANGCAOYU;
    fish_id += 10;
    //右上
    MathAide::BuildCircle(radiusLittle, kScreenHeight - radiusLittle, radiusLittle, fish_pos_start, 20);
    float angle = atanf(kScreenWidth / kScreenHeight);
    hgeVector centerRight;
    centerRight.x = center.x - (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x + n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 10;
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 20)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }

    fish_kind = FISH_DAYANYU;
    fish_id += 20;
    //左上
    MathAide::BuildCircle(kScreenWidth - radiusLittle, kScreenHeight - radiusLittle, radiusLittle, fish_pos_start, 20);
    centerRight.x = center.x + (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x + n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 10;
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 20)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_HUANGBIANYU;
    fish_id += 20;
    //左下
    MathAide::BuildCircle(kScreenWidth - radiusLittle, radiusLittle, radiusLittle, fish_pos_start, 20);
    centerRight.x = center.x + (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x + n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 10;
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 20)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_XIAOCHOUYU;
    fish_id += 20;
    //右下
    MathAide::BuildCircle(radiusLittle, radiusLittle, radiusLittle, fish_pos_start, 20);
    centerRight.x = center.x - (radiusLittle + radiusBig) * cosf(angle);
    centerRight.y = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_pos_end, 20);
    for (int i = 0; i < 20; ++i)
    {
        init_x[0] = fish_pos_start[i].x;
        init_y[0] = fish_pos_start[i].y;
        init_x[1] = fish_pos_end[i].x;
        init_y[1] = fish_pos_end[i].y;
        MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id + i], littleSpeed);
    }
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        if (movePointVector[fish_id].size() > countTemp)
            break;
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        MathAide::BuildCircle(centerRight.x + n, centerRight.y, radiusLittle, fish_point, 20, rotate, kRotateSpeed);
        for (int j = 0; j < 20; ++j)
        {
            movePointVector[fish_id + j].push_back(fish_point[j]);
        }
        n += 1;
    }
    tempHalf = 10;
    for (int i = 0; i < 20; ++i)
    {
        action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
        if (i + tempHalf < 20)
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        else
            m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_kind = FISH_SWK;
    fish_id += 20;
    init_x[0] = radiusLittle;
    init_y[0] = kScreenHeight - radiusLittle;
    init_x[1] = center.x - (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    MovePoint movePoint;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] + n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_kind = FISH_SWK;
    fish_id += 1;
    init_x[0] = kScreenWidth - radiusLittle;
    init_y[0] = kScreenHeight - radiusLittle;
    init_x[1] = center.x + (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y + (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] + n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_kind = FISH_SWK;
    fish_id += 1;
    init_x[0] = kScreenWidth - radiusLittle;
    init_y[0] = radiusLittle;
    init_x[1] = center.x + (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] + n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_kind = FISH_SWK;
    fish_id += 1;
    init_x[0] = radiusLittle;
    init_y[0] = radiusLittle;
    init_x[1] = center.x - (radiusLittle + radiusBig) * cosf(angle);
    init_y[1] = center.y - (radiusLittle + radiusBig) * sinf(angle);
    MathAide::BuildLinear(init_x, init_y, 2, movePointVector[fish_id], littleSpeed);
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
    {
        if (movePointVector[fish_id].size() > countTemp)
            break;
        movePoint.position_.x = init_x[1];
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
    }
    n = 0;
    for (float rotate = 0.f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
    {
        movePoint.position_.x = init_x[1] + n;
        movePoint.position_.y = init_y[1];
        movePoint.angle_ = rotate;
        movePointVector[fish_id].push_back(movePoint);
        n += 1;
    }
    action = new FishActionFishMoveBezier(movePointVector[fish_id]);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    fish_id += 1;
}
void SceneFishManager::BuildSceneFish2(int me_chair_id)
{
    const float kFishSpeed = 60.0f;
    int fish_id = 0;
    FishKind fish_kind;
    FishActionFishMove* action = NULL;
    hgeVector start, end;
    const float kOffset = 100.f;
    float sub_offset;

    // 绿草鱼 16 * 4 // 200
    sub_offset = 168.f;
    fish_kind = FISH_LVCAOYU;
    for (int i = 0; i < 16; ++i)
    {
        end.y = start.y = 150 + 12;
        end.x = kScreenWidth + 60.f;
        start.x = -kOffset - sub_offset - i * 54;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 16;
    for (int i = 0; i < 16; ++i)
    {
        end.y = start.y = 150 + 12 + 100;
        end.x = kScreenWidth + 60.f;
        start.x = -kOffset - sub_offset - i * 54;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 16;
    for (int i = 0; i < 16; ++i)
    {
        end.y = start.y = kScreenHeight - 150 - 100;
        end.x = kScreenWidth + 60.f;
        start.x = -kOffset - sub_offset - i * 54;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 16;
    for (int i = 0; i < 16; ++i)
    {
        end.y = start.y = kScreenHeight - 150;
        end.x = kScreenWidth + 60.f;
        start.x = -kOffset - sub_offset - i * 54;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 16;

    // 小刺鱼 10 + 10 + 3 + 3
    fish_kind = FISH_XIAOCIYU;
    for (int i = 0; i < 10; ++i)
    {
        end.y = start.y = 150 + 12 + 50;
        end.x = kScreenWidth + 150.f;
        start.x = -kOffset - i * 120;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 10;
    for (int i = 0; i < 10; ++i)
    {
        end.y = start.y = kScreenHeight - 150 - 50;
        end.x = kScreenWidth + 150.f;
        start.x = -kOffset - i * 120;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 10;
    for (int i = 0; i < 3; ++i)
    {
        end.y = start.y = 150.f + 12 + 50 + (i + 1) * 100;
        end.x = kScreenWidth + 150.f;
        start.x = -kOffset;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 3;
    for (int i = 0; i < 3; ++i)
    {
        end.y = start.y = 150.f + 12 + 50 + (i + 1) * 100;
        end.x = kScreenWidth + 150.f;
        start.x = -kOffset - 9 * 120;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 3;

    // 大闹天宫 绿草鱼和小刺鱼
    fish_kind = FISH_DNTG;
    end.y = start.y = 150 + 12;
    end.x = kScreenWidth + 150.f;
    start.x = -kOffset - 256;
    SwitchViewPosition(me_chair_id, &start, &end);
    action = new FishActionFishMoveLinear(kFishSpeed, start, end);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, FISH_LVCAOYU, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    ++fish_id;
    end.y = start.y = 150 + 40;
    end.x = kScreenWidth + 150.f;
    start.x = -kOffset - 128;
    SwitchViewPosition(me_chair_id, &start, &end);
    action = new FishActionFishMoveLinear(kFishSpeed, start, end);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, FISH_XIAOCIYU, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    ++fish_id;

    // 大眼鱼 4 + 4
    fish_kind = FISH_DAYANYU;
    hgeVector center(-kOffset - sub_offset - 2 * 54, 150.f + 12 + 50 + 165);
    float radius = 50.f;
    float angle = 0.f;
    for (int i = 0; i < 4; ++i)
    {
        start.x = center.x + radius * cos(angle);
        start.y = center.y + radius * sin(angle);
        end.x = kScreenWidth + 150.f;
        end.y = start.y;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        angle += M_PI_2;
    }
    fish_id += 4;
    center.x = -kOffset - sub_offset - 13 * 54;
    angle = 0.f;
    for (int i = 0; i < 4; ++i)
    {
        start.x = center.x + radius * cos(angle);
        start.y = center.y + radius * sin(angle);
        end.x = kScreenWidth + 150.f;
        end.y = start.y;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
        angle += M_PI_2;
    }
    fish_id += 4;

    // 悟空
    fish_kind = FISH_SWK;
    end.y = start.y = kScreenHeight / 2.0f; //- 150 - 100;
    end.x = kScreenWidth + 380.f;
    start.x = -kOffset - 620;
    SwitchViewPosition(me_chair_id, &start, &end);
    action = new FishActionFishMoveLinear(kFishSpeed, start, end);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    ++fish_id;
}

void SceneFishManager::BuildSceneFish3(int me_chair_id)
{
    const float kFishSpeed = 150.f;
    int fish_id = 0;
    FishKind fish_kind;
    FishActionFishMove* action = NULL;
    const hgeVector center(kScreenWidth / 2.f, kScreenHeight / 2.f);
    float radius;
    float cell_radian;
    float angle;

    // 玉皇大帝
    fish_kind = FISH_YUWANGDADI;
    action = new ActionScene3FishMove(center, 0, 28.f, me_chair_id < 3 ? M_PI : 0, 4 * M_PI + M_PI_2, 5.f, kFishSpeed);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    ++fish_id;

    // 小丑鱼
    fish_kind = FISH_XIAOCHOUYU;
    radius = 150.f;
    cell_radian = 2 * M_PI / 10;
    for (int i = 0; i < 10; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene3FishMove(center, radius, 27.f, angle, 4 * M_PI, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 10;

    // 大眼鱼
    fish_kind = FISH_DAYANYU;
    radius = 150.f + 52.f + 42.f;
    cell_radian = 2 * M_PI / 18;
    for (int i = 0; i < 18; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene3FishMove(center, radius, 26.f, angle, 4 * M_PI - M_PI_2, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 18;

    // 黄草鱼
    fish_kind = FISH_HUANGCAOYU;
    radius = 150.f + 52.f + 42.f * 2 + 30;
    cell_radian = 2 * M_PI / 30;
    for (int i = 0; i < 30; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene3FishMove(center, radius, 25.f, angle, 4 * M_PI - M_PI_2 * 2, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 30;

    // 蜗牛鱼
    fish_kind = FISH_WONIUYU;
    radius = 150.f + 52.f + 42.f * 2 + 30 * 2 + 35;
    cell_radian = 2 * M_PI / 30;
    for (int i = 0; i < 30; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene3FishMove(center, radius, 24.f, angle, 4 * M_PI - M_PI_2 * 3, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 30;
}

void SceneFishManager::BuildSceneFish4(int me_chair_id)
{

    const float kFishSpeed = 150.f;
    int fish_id = 0;
    FishKind fish_kind;
    FishActionFishMove* action = NULL;
    const hgeVector center(kScreenWidth / 2.f, kScreenHeight / 2.f);
    float radius;
    float cell_radian;
    float angle;
    // 玉皇大帝
    fish_kind = FISH_SWK;
    action = new ActionScene4FishMove(center, 0, 28.f, me_chair_id < 3 ? M_PI : 0, 4 * M_PI + M_PI_2, 5.f, kFishSpeed);
    m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    ++fish_id;

    // 小丑鱼
    fish_kind = FISH_XIAOCHOUYU;
    radius = 150.f;
    cell_radian = 2 * M_PI / 10;
    for (int i = 0; i < 10; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene4FishMove(center, radius, 27.f, angle, 4 * M_PI, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 10;

    // 大眼鱼
    fish_kind = FISH_DAYANYU;
    radius = 150.f + 52.f + 42.f;
    cell_radian = 2 * M_PI / 18;
    for (int i = 0; i < 18; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene4FishMove(center, radius, 26.f, angle, 4 * M_PI - M_PI_2, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 18;

    // 黄草鱼
    fish_kind = FISH_HUANGCAOYU;
    radius = 150.f + 52.f + 42.f * 2 + 30;
    cell_radian = 2 * M_PI / 30;
    for (int i = 0; i < 30; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene4FishMove(center, radius, 25.f, angle, 4 * M_PI - M_PI_2 * 2, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 30;

    // 蜗牛鱼
    fish_kind = FISH_WONIUYU;
    radius = 150.f + 52.f + 42.f * 2 + 30 * 2 + 35;
    cell_radian = 2 * M_PI / 30;
    for (int i = 0; i < 30; ++i)
    {
        angle = i * cell_radian;
        if (me_chair_id < 3)
            angle += M_PI;
        action = new ActionScene4FishMove(center, radius, 24.f, angle, 4 * M_PI - M_PI_2 * 3, 5.f, kFishSpeed);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 30;
}

void SceneFishManager::BuildSceneFish5(int me_chair_id)
{
    float kFishSpeed = 50.0f;
    int fish_id = 0;
    FishKind fish_kind;
    FishActionFishMove* action = NULL;
    hgeVector start, end;

    // 蜗牛鱼 上50 下50
    float hinterval = kScreenWidth / 13.f;
    float vinterval = kScreenHeight / 6.f;
    fish_kind = FISH_WONIUYU;
    for (int i = 0; i < 50; ++i)
    {
        start.x = hinterval + (hinterval + (hinterval / 5.f)) * (i % 10);
        start.y = -100.f - (i / 10) * vinterval - (i % 3) * vinterval / 5.f;
        end.x = start.x;
        end.y = kScreenHeight + 100.f;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }

    fish_id += 50;
    for (int i = 0; i < 50; ++i)
    {
        start.x = hinterval + (hinterval + (hinterval / 5.f)) * (i % 10) + hinterval / 2;
        start.y = kScreenHeight + 100.f + 4 * vinterval - (i / 10) * vinterval + (i % 3) * vinterval / 5.f;
        end.x = start.x;
        end.y = -100.f;
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 50;

    // 蝙蝠鱼 银鲨 金鲨
    kFishSpeed = 100.0f;
    fish_kind = FISH_BIANFUYU;
    const hgeVector kFishStart1[5] = { hgeVector(kScreenWidth + 200, kScreenHeight / 2.f), hgeVector(kScreenWidth + 500, kScreenHeight / 2.f - 50), hgeVector(kScreenWidth + 800, kScreenHeight / 2.f + 60), hgeVector(kScreenWidth + 1100, kScreenHeight / 2.f - 60), hgeVector(kScreenWidth + 1400, kScreenHeight / 2.f - 60) };
    const hgeVector kFishEnd1[5] = { hgeVector(-200, kScreenHeight / 2.f), hgeVector(-200, kScreenHeight / 2.f - 100), hgeVector(-200, kScreenHeight / 2.f + 100), hgeVector(-200, kScreenHeight / 2.f + 60), hgeVector(-200, kScreenHeight / 2.f - 60) };
    for (int i = 0; i < 5; ++i)
    {
        start = kFishStart1[i];
        end = kFishEnd1[i];
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 5;
    fish_kind = FISH_YINSHA;
    const hgeVector kFishStart2[5] = { hgeVector(kScreenWidth + 200, kScreenHeight / 2.f), hgeVector(kScreenWidth + 500, kScreenHeight / 2.f - 50), hgeVector(kScreenWidth + 800, kScreenHeight / 2.f + 60), hgeVector(kScreenWidth + 1100, kScreenHeight / 2.f - 60), hgeVector(kScreenWidth + 1400, kScreenHeight / 2.f - 60) };
    const hgeVector kFishEnd2[5] = { hgeVector(-200.f, kScreenHeight - 100.f), hgeVector(-300.f, kScreenHeight + 1.f), hgeVector(-400.f, kScreenHeight + 100.f), hgeVector(-500.f, kScreenHeight + 60.f), hgeVector(-600, kScreenHeight - 60.f) };
    for (int i = 0; i < 5; ++i)
    {
        start = kFishStart2[i];
        end = kFishEnd2[i];
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 5;
    fish_kind = FISH_JINSHA;
    const hgeVector kFishStart3[5] = { hgeVector(kScreenWidth + 200, kScreenHeight / 2.f), hgeVector(kScreenWidth + 500, kScreenHeight / 2.f - 50), hgeVector(kScreenWidth + 800, kScreenHeight / 2.f + 60), hgeVector(kScreenWidth + 1100, kScreenHeight / 2.f - 60), hgeVector(kScreenWidth + 1400, kScreenHeight / 2.f - 60) };
    const hgeVector kFishEnd3[5] = { hgeVector(-200, 100.f), hgeVector(-300, 0), hgeVector(-400, -100), hgeVector(-500, -60), hgeVector(-600, 60) };
    for (int i = 0; i < 5; ++i)
    {
        start = kFishStart3[i];
        end = kFishEnd3[i];
        SwitchViewPosition(me_chair_id, &start, &end);
        action = new FishActionFishMoveLinear(kFishSpeed, start, end);
        m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
    }
    fish_id += 5;
}

void SceneFishManager::SwitchViewPosition(int me_chair_id, hgeVector* start, hgeVector* end)
{
    if (me_chair_id >= 3)
        return;
    start->x = kScreenWidth - start->x;
    start->y = kScreenHeight - start->y;
    end->x = kScreenWidth - end->x;
    end->y = kScreenHeight - end->y;
}

    */