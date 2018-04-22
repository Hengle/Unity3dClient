using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

//#include "math_aide.h"
//#include <math.h>

namespace GameClient
{
    public class FishSceneManager : Singleton<FishSceneManager>
    {
        FishActionAsset[,] mAssets = new FishActionAsset[0,2];
        public void LoadAsset(FishActionAsset[,] assets)
        {
            mAssets = assets;
        }
        public void ClearAssets()
        {
            for(int i = 0; i < mAssets.Length/2; ++i)
            {
                mAssets[i,0] = null;
                mAssets[i,1] = null;
            }
        }
#if UNITY_EDITOR
        public void BuildFishScene6ToAsset(FishActionMoveBezier[] datas,string path = "Scene/Fish/fish_scene_6")
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var assetPath = "Assets/Resources/" + path + ".asset";

            try
            {
                if (File.Exists(assetPath))
                {
                    FishActionAsset oldAsset = AssetDatabase.LoadAssetAtPath<FishActionAsset>(assetPath);
                    oldAsset.pathes = datas;
                    //oldAsset.pathes = _tmpPathes.ToArray();
                    EditorUtility.SetDirty(oldAsset);
                    AssetDatabase.SaveAssets();
                }
                else
                {
                    var assetData = ScriptableObject.CreateInstance<FishActionAsset>();
                    assetData.pathes = datas;
                    AssetDatabase.CreateAsset(assetData, assetPath);
                }
                Debug.LogFormat("<color=#00ff00>create asset {0} succeed !!!</color>", assetPath);
            }
            catch (System.Exception e)
            {
                Debug.LogErrorFormat(e.ToString());
            }
        }
        public void BuildFishScene1ToAsset(FishActionMoveLiner[] datas, string path = "Scene/Fish/fish_scene_1")
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var assetPath = "Assets/Resources/" + path + ".asset";

            try
            {
                if (File.Exists(assetPath))
                {
                    FishActionAsset oldAsset = AssetDatabase.LoadAssetAtPath<FishActionAsset>(assetPath);
                    oldAsset.line_pathes = datas;
                    //oldAsset.pathes = _tmpPathes.ToArray();
                    EditorUtility.SetDirty(oldAsset);
                    AssetDatabase.SaveAssets();
                }
                else
                {
                    var assetData = ScriptableObject.CreateInstance<FishActionAsset>();
                    assetData.line_pathes = datas;
                    AssetDatabase.CreateAsset(assetData, assetPath);
                }
                Debug.LogFormat("<color=#00ff00>create asset {0} succeed !!!</color>", assetPath);
            }
            catch (System.Exception e)
            {
                Debug.LogErrorFormat(e.ToString());
            }
        }
        public void BuildFishScene3ToAsset(FishActionMoveScene3[] datas, string path = "Scene/Fish/fish_scene_3")
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var assetPath = "Assets/Resources/" + path + ".asset";

            try
            {
                if (File.Exists(assetPath))
                {
                    FishActionAsset oldAsset = AssetDatabase.LoadAssetAtPath<FishActionAsset>(assetPath);
                    oldAsset.scene3_pathes = datas;
                    //oldAsset.pathes = _tmpPathes.ToArray();
                    EditorUtility.SetDirty(oldAsset);
                    AssetDatabase.SaveAssets();
                }
                else
                {
                    var assetData = ScriptableObject.CreateInstance<FishActionAsset>();
                    assetData.scene3_pathes = datas;
                    AssetDatabase.CreateAsset(assetData, assetPath);
                }
                Debug.LogFormat("<color=#00ff00>create asset {0} succeed !!!</color>", assetPath);
            }
            catch (System.Exception e)
            {
                Debug.LogErrorFormat(e.ToString());
            }
        }
#endif

        public void BuildSceneFish(SceneKind scene_kind, int me_chair_id)
        {
            switch (scene_kind)
            {
                case SceneKind.SCENE_1:
                    {
                        if (me_chair_id < 3)
                        {
                            FishActionAsset asset = mAssets[0,0];
                            if(null == asset)
                            {
                                asset = AssetLoader.Instance().LoadRes("Scene/Fish/fish_scene_6", typeof(FishActionAsset)).obj as FishActionAsset;
                            }
                            if (null == asset)
                            {
#if UNITY_EDITOR
                                DateTime start = DateTime.Now;
                                List<FishActionMoveBezier> assetDatas = new List<FishActionMoveBezier>();
                                BuildSceneFish6(me_chair_id, assetDatas);
                                BuildFishScene6ToAsset(assetDatas.ToArray(), "Scene/Fish/fish_scene_6");
                                DateTime end = DateTime.Now;
                                TimeSpan ts = end - start;
                                Debug.LogErrorFormat("BuildSceneFish6 delta = {0}", ts.TotalMilliseconds.ToString());
#endif
                            }
                            else
                            {
                                DateTime start = DateTime.Now;
                                for (int i = 0; i < asset.pathes.Length; ++i)
                                {
                                    var current = asset.pathes[i];
                                    if (null != current)
                                    {
                                        FishActionFishMoveBezier action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                                        action.Create(asset.pathes[i]._points);
                                        //DateTime item_start = DateTime.Now;
                                        FishDataManager.Instance().CreateFish(current._kind, current._fish_id, action);
                                        //DateTime item_end = DateTime.Now;
                                        //TimeSpan item_ts = item_end - item_start;
                                        //Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", item_ts.TotalMilliseconds.ToString());
                                    }
                                }
                                DateTime end = DateTime.Now;
                                TimeSpan ts = end - start;
                                Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", ts.TotalMilliseconds.ToString());
                            }

                        }
                        else
                        {
                            FishActionAsset asset = mAssets[0,1];
                            if(null == asset)
                            {
                                asset = AssetLoader.Instance().LoadRes("Scene/Fish/fish_scene_6r", typeof(FishActionAsset)).obj as FishActionAsset;
                            }
                            if (null == asset)
                            {
#if UNITY_EDITOR
                                DateTime start = DateTime.Now;
                                List<FishActionMoveBezier> assetDatas = new List<FishActionMoveBezier>();
                                BuildSceneFish6Switch(me_chair_id, assetDatas);
                                BuildFishScene6ToAsset(assetDatas.ToArray(), "Scene/Fish/fish_scene_6r");
                                DateTime end = DateTime.Now;
                                TimeSpan ts = end - start;
                                Debug.LogErrorFormat("BuildSceneFish6r delta = {0}", ts.TotalMilliseconds.ToString());
#endif
                            }
                            else
                            {
                                DateTime start = DateTime.Now;
                                for (int i = 0; i < asset.pathes.Length; ++i)
                                {
                                    var current = asset.pathes[i];
                                    if (null != current)
                                    {
                                        FishActionFishMoveBezier action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                                        action.Create(asset.pathes[i]._points);
                                        //DateTime item_start = DateTime.Now;
                                        FishDataManager.Instance().CreateFish(current._kind, current._fish_id, action);
                                        //DateTime item_end = DateTime.Now;
                                        //TimeSpan item_ts = item_end - item_start;
                                        //Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", item_ts.TotalMilliseconds.ToString());
                                    }
                                }
                                DateTime end = DateTime.Now;
                                TimeSpan ts = end - start;
                                Debug.LogErrorFormat("BuildSceneFish6r delta = <color=#00ff00>{0}</color> ms", ts.TotalMilliseconds.ToString());
                            }
                        }
                        break;
                    }
                case SceneKind.SCENE_2:
                    {
                        FishActionAsset asset = null;
                        string scene_res_path = string.Empty;
                        if (me_chair_id < 3)
                        {
                            scene_res_path = "Scene/Fish/fish_scene_5";
                            asset = mAssets[1, 0];
                        }
                        else
                        {
                            scene_res_path = "Scene/Fish/fish_scene_5r";
                            asset = mAssets[1, 1];
                        }
                        if (null == asset)
                        {
                            asset = AssetLoader.Instance().LoadRes(scene_res_path, typeof(FishActionAsset)).obj as FishActionAsset;
                        }
                        if (null == asset)
                        {
#if UNITY_EDITOR
                            DateTime start = DateTime.Now;
                            List<FishActionMoveLiner> assetDatas = new List<FishActionMoveLiner>();
                            BuildSceneFish5(me_chair_id, assetDatas);
                            BuildFishScene1ToAsset(assetDatas.ToArray(), scene_res_path);
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish5 delta = {0}", ts.TotalMilliseconds.ToString());
#endif
                        }
                        else
                        {
                            DateTime start = DateTime.Now;
                            for (int i = 0; i < asset.line_pathes.Length; ++i)
                            {
                                var current = asset.line_pathes[i];
                                if (null != current)
                                {
                                    FishActionFishMoveLinear action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                                    action.Create(current._speed, current._start, current._end);
                                    //DateTime item_start = DateTime.Now;
                                    FishDataManager.Instance().CreateFish(current._kind, current._fish_id, action);
                                    //DateTime item_end = DateTime.Now;
                                    //TimeSpan item_ts = item_end - item_start;
                                    //Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", item_ts.TotalMilliseconds.ToString());
                                }
                            }
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish5 delta = <color=#00ff00>{0}</color> ms", ts.TotalMilliseconds.ToString());
                        }
                        break;
                    }
                case SceneKind.SCENE_3:
                    {
                        FishActionAsset asset = null;
                        string scene_res_path = string.Empty;
                        if (me_chair_id < 3)
                        {
                            scene_res_path = "Scene/Fish/fish_scene_3";
                            asset = mAssets[2, 0];
                        }
                        else
                        {
                            scene_res_path = "Scene/Fish/fish_scene_3r";
                            asset = mAssets[2, 1];
                        }
                        if (null == asset)
                        {
                            asset = AssetLoader.Instance().LoadRes(scene_res_path, typeof(FishActionAsset)).obj as FishActionAsset;
                        }
                        if (null == asset)
                        {
#if UNITY_EDITOR
                            DateTime start = DateTime.Now;
                            List<FishActionMoveScene3> assetDatas = new List<FishActionMoveScene3>();
                            BuildSceneFish3(me_chair_id, assetDatas);
                            BuildFishScene3ToAsset(assetDatas.ToArray(), scene_res_path);
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish3 delta = {0}", ts.TotalMilliseconds.ToString());
#endif
                        }
                        else
                        {
                            DateTime start = DateTime.Now;
                            for (int i = 0; i < asset.scene3_pathes.Length; ++i)
                            {
                                var current = asset.scene3_pathes[i];
                                if (null != current)
                                {
                                    ActionScene3FishMove action = FishAction.CreateActionFromPool<ActionScene3FishMove>();
                                    action.Create(current.center, current.radius, current.rotate_duration, current.start_angle, current.rotate_angle, current.move_duration, current.fish_speed);
                                    //DateTime item_start = DateTime.Now;
                                    FishDataManager.Instance().CreateFish(current._kind, current._fish_id, action);
                                    //DateTime item_end = DateTime.Now;
                                    //TimeSpan item_ts = item_end - item_start;
                                    //Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", item_ts.TotalMilliseconds.ToString());
                                }
                            }
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish1 delta = <color=#00ff00>{0}</color> ms", ts.TotalMilliseconds.ToString());
                        }
                        break;
                    }
                case SceneKind.SCENE_4:
                    {
                        FishActionAsset asset = null;
                        string scene_res_path = string.Empty;
                        if (me_chair_id < 3)
                        {
                            scene_res_path = "Scene/Fish/fish_scene_1";
                            asset = mAssets[3, 0];
                        }
                        else
                        {
                            scene_res_path = "Scene/Fish/fish_scene_1r";
                            asset = mAssets[3, 1];
                        }

                        if(null == asset)
                        {
                            asset = AssetLoader.Instance().LoadRes(scene_res_path, typeof(FishActionAsset)).obj as FishActionAsset;
                        }
                        if (null == asset)
                        {
#if UNITY_EDITOR
                            DateTime start = DateTime.Now;
                            List<FishActionMoveLiner> assetDatas = new List<FishActionMoveLiner>();
                            BuildSceneFish1(me_chair_id, assetDatas);
                            BuildFishScene1ToAsset(assetDatas.ToArray(), scene_res_path);
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish1 delta = {0}", ts.TotalMilliseconds.ToString());
#endif
                        }
                        else
                        {
                            DateTime start = DateTime.Now;
                            for (int i = 0; i < asset.line_pathes.Length; ++i)
                            {
                                var current = asset.line_pathes[i];
                                if (null != current)
                                {
                                    FishActionFishMoveLinear action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                                    action.Create(current._speed, current._start, current._end);
                                    //DateTime item_start = DateTime.Now;
                                    FishDataManager.Instance().CreateFish(current._kind, current._fish_id, action);
                                    //DateTime item_end = DateTime.Now;
                                    //TimeSpan item_ts = item_end - item_start;
                                    //Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", item_ts.TotalMilliseconds.ToString());
                                }
                            }
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish1 delta = <color=#00ff00>{0}</color> ms", ts.TotalMilliseconds.ToString());
                        }
                        break;
                    }
                case SceneKind.SCENE_5:
                    {
                        FishActionAsset asset = null;
                        string scene_res_path = string.Empty;
                        if (me_chair_id < 3)
                        {
                            scene_res_path = "Scene/Fish/fish_scene_4";
                            asset = mAssets[4, 0];
                        }
                        else
                        {
                            scene_res_path = "Scene/Fish/fish_scene_4r";
                            asset = mAssets[4, 1];
                        }
                        if (null == asset)
                        {
                            asset = AssetLoader.Instance().LoadRes(scene_res_path, typeof(FishActionAsset)).obj as FishActionAsset;
                        }
                        if (null == asset)
                        {
#if UNITY_EDITOR
                            DateTime start = DateTime.Now;
                            List<FishActionMoveScene3> assetDatas = new List<FishActionMoveScene3>();
                            BuildSceneFish4(me_chair_id, assetDatas);
                            BuildFishScene3ToAsset(assetDatas.ToArray(), scene_res_path);
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish4 delta = {0}", ts.TotalMilliseconds.ToString());
#endif
                        }
                        else
                        {
                            DateTime start = DateTime.Now;
                            for (int i = 0; i < asset.scene3_pathes.Length; ++i)
                            {
                                var current = asset.scene3_pathes[i];
                                if (null != current)
                                {
                                    ActionScene3FishMove action = FishAction.CreateActionFromPool<ActionScene3FishMove>();
                                    action.Create(current.center, current.radius, current.rotate_duration, current.start_angle, current.rotate_angle, current.move_duration, current.fish_speed);
                                    //DateTime item_start = DateTime.Now;
                                    FishDataManager.Instance().CreateFish(current._kind, current._fish_id, action);
                                    //DateTime item_end = DateTime.Now;
                                    //TimeSpan item_ts = item_end - item_start;
                                    //Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", item_ts.TotalMilliseconds.ToString());
                                }
                            }
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish4 delta = <color=#00ff00>{0}</color> ms", ts.TotalMilliseconds.ToString());
                        }
                        break;
                    }
                case SceneKind.SCENE_6:
                    {
                        FishActionAsset asset = null;
                        string scene_res_path = string.Empty;
                        if (me_chair_id < 3)
                        {
                            scene_res_path = "Scene/Fish/fish_scene_2";
                            asset = mAssets[5, 0];
                        }
                        else
                        {
                            scene_res_path = "Scene/Fish/fish_scene_2r";
                            asset = mAssets[5, 1];
                        }
                        if (null == asset)
                        {
                            asset = AssetLoader.Instance().LoadRes(scene_res_path, typeof(FishActionAsset)).obj as FishActionAsset;
                        }
                        if (null == asset)
                        {
#if UNITY_EDITOR
                            DateTime start = DateTime.Now;
                            List<FishActionMoveLiner> assetDatas = new List<FishActionMoveLiner>();
                            BuildSceneFish2(me_chair_id, assetDatas);
                            BuildFishScene1ToAsset(assetDatas.ToArray(), scene_res_path);
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish2 delta = {0}", ts.TotalMilliseconds.ToString());
#endif
                        }
                        else
                        {
                            DateTime start = DateTime.Now;
                            for (int i = 0; i < asset.line_pathes.Length; ++i)
                            {
                                var current = asset.line_pathes[i];
                                if (null != current)
                                {
                                    FishActionFishMoveLinear action = FishAction.CreateActionFromPool<FishActionFishMoveLinear>();
                                    action.Create(current._speed, current._start, current._end);
                                    //DateTime item_start = DateTime.Now;
                                    FishDataManager.Instance().CreateFish(current._kind, current._fish_id, action);
                                    //DateTime item_end = DateTime.Now;
                                    //TimeSpan item_ts = item_end - item_start;
                                    //Debug.LogErrorFormat("BuildSceneFish6 delta = <color=#00ff00>{0}</color> ms", item_ts.TotalMilliseconds.ToString());
                                }
                            }
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            Debug.LogErrorFormat("BuildSceneFish2 delta = <color=#00ff00>{0}</color> ms", ts.TotalMilliseconds.ToString());
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        void BuildSceneFish1(int me_chair_id, List<FishActionMoveLiner> assetDatas)
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
            assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
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
            assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
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
                assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
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
                assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
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
                assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
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
                assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
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
                assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
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
                assetDatas.Add(new FishActionMoveLiner { _fish_id = fish_id, _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
        }
        void BuildSceneFish6(int me_chair_id,List<FishActionMoveBezier> outAssetData = null)
        {
            List<MovePoint>[] movePointVector = new List<MovePoint>[300];//300
            for(int i = 0; i < movePointVector.Length; ++i)
            {
                movePointVector[i] = new List<MovePoint>();
            }
            FishKind fish_kind;
            int fish_id = 0;
            int fish_pos_count = 0;
            int fish_pos_count_temp = 0;
            const float kFishSpeed = 120 * FishConfig.kSpeed;
            const float kLFish1Rotate = (float)(720.0f * FishConfig.M_PI / 180.0f * 1 / 2);
            const float kRotateSpeed = (float)(1.2f * FishConfig.M_PI / 180);
            const float radiusLittle = FishConfig.kScreenHeight / 8;
            const float radiusBig = FishConfig.kScreenHeight / 4;
            float littleDistance = Mathf.Sqrt(FishConfig.kScreenWidth * FishConfig.kScreenWidth * 1.0f + FishConfig.kScreenHeight * FishConfig.kScreenHeight) / 2 - (Mathf.Sqrt(2 * radiusLittle * 2 * radiusLittle * 2 * 1.0f) - 2 * radiusLittle) / 2 - 2 * radiusLittle - radiusBig;
            float littleDistanceLk = littleDistance + 2 * radiusLittle + 2 * radiusBig;
            float littleSpeed = littleDistance / (radiusBig / kFishSpeed);
            float littleSpeedLk = littleDistanceLk / (radiusBig / kFishSpeed);
            Vector2[] fish_pos_start = new Vector2[20];
            Vector2[] fish_pos_end = new Vector2[20];
            Vector2[] fish_pos = new Vector2[40];
            Vector2 center;
            center.x = FishConfig.kScreenWidth / 2;
            center.y = FishConfig.kScreenHeight / 2;
            FishActionFishMove action = null;
            fish_kind = FishKind.FISH_WONIUYU;
            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig, ref fish_pos,40);
            float[] init_x = new float[2];
            float[] init_y = new float[2];
            int stopCount = 0;
            int countTemp = 0;
            for (int i = 0; i < 40; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }

                MathAide.BuildCircle(center.x, center.y, radiusBig, ref fish_point, 40, rotate, kRotateSpeed);
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            countTemp = movePointVector[fish_id].Count;

            int n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }

                MathAide.BuildCircle(center.x - n, center.y, radiusBig,ref fish_point, 40, rotate, kRotateSpeed);
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 40; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }

            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 40;
            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 9, ref fish_pos, 40);
            for (int i = 0; i < 40; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 9,ref fish_point, 40, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x - n, center.y, radiusBig / 10 * 9, ref fish_point, 40, rotate, kRotateSpeed);
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            for (int i = 0; i < 40; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_WONIUYU;
            fish_id += 40;
            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 8, ref fish_pos, 30);
            for (int i = 0; i < 30; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 8, ref fish_point, 30, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x - n, center.y, radiusBig / 10 * 8, ref fish_point, 30, rotate, kRotateSpeed);
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 30; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 30;

            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 7, ref fish_pos, 30);
            for (int i = 0; i < 30; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 7, ref fish_point, 30, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x - n, center.y, radiusBig / 10 * 7, ref fish_point, 30, rotate, kRotateSpeed);
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            for (int i = 0; i < 30; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_WONIUYU;
            fish_id += 30;

            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 6, ref fish_pos, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 6, ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x - n, center.y, radiusBig / 10 * 6,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            for (int i = 0; i < 20; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 20;

            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 5,ref fish_pos, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 5, ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x - n, center.y, radiusBig / 10 * 5,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            for (int i = 0; i < 20; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_WONIUYU;
            fish_id += 20;

            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 4,ref fish_pos, 10);
            for (int i = 0; i < 10; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 4,ref fish_point, 10, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x - n, center.y, radiusBig / 10 * 4,ref fish_point, 10, rotate, kRotateSpeed);
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 10; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 10;
            //TODO:
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 3,ref  fish_pos, 10);
            for (int i = 0; i < 10; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 3, ref fish_point, 10, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x - n, center.y, radiusBig / 10 * 3, ref fish_point, 10, rotate, kRotateSpeed);
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 10; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_HUANGCAOYU;
            fish_id += 10;
            //右上
            //TODO:
            MathAide.BuildCircle(FishConfig.kScreenWidth - radiusLittle, radiusLittle, radiusLittle, ref fish_pos_start, 20);
            float angle = Mathf.Atan(FishConfig.kScreenWidth / FishConfig.kScreenHeight);
            Vector2 centerRight;
            centerRight.x = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x - n, centerRight.y, radiusLittle, ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 20; ++i)
            {
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_DAYANYU;
            fish_id += 20;
            //左上
            //TODO:
            MathAide.BuildCircle(radiusLittle, radiusLittle, radiusLittle, ref fish_pos_start, 20);
            centerRight.x = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle, ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle, ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x - n, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 20; ++i)
            {
                //action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_HUANGBIANYU;
            fish_id += 20;
            //左下
            //TODO:
            MathAide.BuildCircle(radiusLittle, FishConfig.kScreenHeight - radiusLittle, radiusLittle, ref fish_pos_start, 20);
            centerRight.x = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y + (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle, ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x - n, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 20; ++i)
            {
                //action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_XIAOCHOUYU;
            fish_id += 20;
            //右下
            //TODO:
            MathAide.BuildCircle(FishConfig.kScreenWidth - radiusLittle, FishConfig.kScreenHeight - radiusLittle, radiusLittle, ref fish_pos_start, 20);
            centerRight.x = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y + (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle, ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                //TODO:
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }

            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x - n, centerRight.y, radiusLittle, ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }

            for (int i = 0; i < 20; ++i)
            {
                //action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
                (action as FishActionFishMoveBezier).Create(movePointVector[fish_id + i]);
                outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //TODO:
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_SWK;
            fish_id += 20;
            init_x[0] = FishConfig.kScreenWidth - radiusLittle;
            init_y[0] = radiusLittle;
            init_x[1] = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] - n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            //action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            //TODO:
            action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
            (action as FishActionFishMoveBezier).Create(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_kind = FishKind.FISH_SWK;
            fish_id += 1;
            init_x[0] = radiusLittle;
            init_y[0] = radiusLittle;
            init_x[1] = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] - n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            //action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
            (action as FishActionFishMoveBezier).Create(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
            //TODO:
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_kind = FishKind.FISH_SWK;
            fish_id += 1;
            init_x[0] = radiusLittle;
            init_y[0] = FishConfig.kScreenHeight - radiusLittle;
            init_x[1] = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y + (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] - n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            //action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
            (action as FishActionFishMoveBezier).Create(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
            //TODO:
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_kind = FishKind.FISH_SWK;
            fish_id += 1;
            init_x[0] = FishConfig.kScreenWidth - radiusLittle;
            init_y[0] = FishConfig.kScreenHeight - radiusLittle;
            init_x[1] = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y + (radiusLittle + radiusBig) * Mathf.Sin(angle);
            //TODO:
            MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] - n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            //action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            action = FishAction.CreateActionFromPool<FishActionFishMoveBezier>();
            (action as FishActionFishMoveBezier).Create(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
            //TODO:
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_id += 1;
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

        void BuildSceneFish6Switch(int me_chair_id, List<FishActionMoveBezier> outAssetData = null)
        {
            List<MovePoint>[] movePointVector = new List<MovePoint>[300];
            for(int i = 0; i < movePointVector.Length; ++i)
            {
                movePointVector[i] = new List<MovePoint>(100);
            }
            FishKind fish_kind;
            int fish_id = 0;
            int fish_pos_count = 0;
            int fish_pos_count_temp = 0;
            const float kFishSpeed = 120 * FishConfig.kSpeed;
            const float kLFish1Rotate = (float)(720.0f * FishConfig.M_PI / 180.0f * 1 / 2);
            const float kRotateSpeed = (float)(1.2f * FishConfig.M_PI / 180);
            const float radiusLittle = FishConfig.kScreenHeight / 8;
            const float radiusBig = FishConfig.kScreenHeight / 4;
            float littleDistance = Mathf.Sqrt(FishConfig.kScreenWidth * FishConfig.kScreenWidth * 1.0f + FishConfig.kScreenHeight * FishConfig.kScreenHeight) / 2 - (Mathf.Sqrt(2 * radiusLittle * 2 * radiusLittle * 2 * 1.0f) - 2 * radiusLittle) / 2 - 2 * radiusLittle - radiusBig;
            float littleDistanceLk = littleDistance + 2 * radiusLittle + 2 * radiusBig;
            float littleSpeed = littleDistance / (radiusBig / kFishSpeed);
            float littleSpeedLk = littleDistanceLk / (radiusBig / kFishSpeed);
            Vector2[] fish_pos_start = new Vector2[20];
            Vector2[] fish_pos_end = new Vector2[20];
            Vector2[] fish_pos = new Vector2[40];
            Vector2 center;
            center.x = FishConfig.kScreenWidth / 2;
            center.y = FishConfig.kScreenHeight / 2;
            FishActionFishMove action = null;
            fish_kind = FishKind.FISH_WONIUYU;
            MathAide.BuildCircle(center.x, center.y, radiusBig,ref fish_pos, 40);
            float[] init_x = new float[2];
            float[] init_y = new float[2];
            int stopCount = 0;
            int countTemp = 0;
            int tempHalf = 0;
            for (int i = 0; i < 40; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }

                MathAide.BuildCircle(center.x, center.y, radiusBig,ref fish_point, 40, rotate, kRotateSpeed);
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            countTemp = movePointVector[fish_id].Count;
            int n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x + n, center.y, radiusBig,ref fish_point, 40, rotate, kRotateSpeed);
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 20;
            for (int i = 0; i < 40; ++i)
            {
                //action = new FishActionFishMoveBezier(movePointVector[i]);
                if (i + tempHalf < 40)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 40;
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 9,ref fish_pos, 40);
            for (int i = 0; i < 40; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 9,ref fish_point, 40, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }

                MathAide.BuildCircle(center.x + n, center.y, radiusBig / 10 * 9,ref fish_point, 40, rotate, kRotateSpeed);
                for (int j = 0; j < 40; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 20;
            for (int i = 0; i < 40; ++i)
            {
                //action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 40)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_WONIUYU;
            fish_id += 40;
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 8, ref fish_pos, 30);
            for (int i = 0; i < 30; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 8,ref fish_point, 30, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x + n, center.y, radiusBig / 10 * 8, ref fish_point, 30, rotate, kRotateSpeed);
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 15;
            for (int i = 0; i < 30; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 30)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 30;
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 7,ref fish_pos, 30);
            for (int i = 0; i < 30; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 7,ref fish_point, 30, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }

                MathAide.BuildCircle(center.x + n, center.y, radiusBig / 10 * 7,ref fish_point, 30, rotate, kRotateSpeed);
                for (int j = 0; j < 30; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 15;
            for (int i = 0; i < 30; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 30)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_kind = FishKind.FISH_WONIUYU;
            fish_id += 30;
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 6,ref fish_pos, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 6,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }

                MathAide.BuildCircle(center.x + n, center.y, radiusBig / 10 * 6,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 10;
            for (int i = 0; i < 20; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 20)
                    //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i + tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                    //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i - tempHalf, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }
            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 20;
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 5,ref fish_pos, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2, ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 5,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x + n, center.y, radiusBig / 10 * 5,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 10;
            for (int i = 0; i < 20; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 20)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }
            fish_kind = FishKind.FISH_WONIUYU;
            fish_id += 20;
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 4,ref fish_pos, 10);
            for (int i = 0; i < 10; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 4, ref fish_point, 10, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x + n, center.y, radiusBig / 10 * 4,ref fish_point, 10, rotate, kRotateSpeed);
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 5;
            for (int i = 0; i < 10; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 10)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }
            fish_kind = FishKind.FISH_LVCAOYU;
            fish_id += 10;
            MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 3,ref fish_pos, 10);
            for (int i = 0; i < 10; ++i)
            {
                init_x[0] = center.x;
                init_y[0] = center.y;
                init_x[1] = fish_pos[i].x;
                init_y[1] = fish_pos[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], kFishSpeed, stopCount);
            }
            stopCount = movePointVector[fish_id].Count;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x, center.y, radiusBig / 10 * 3,ref fish_point, 10, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(center.x + n, center.y, radiusBig / 10 * 3,ref fish_point, 10, rotate, kRotateSpeed);
                for (int j = 0; j < 10; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 5;
            for (int i = 0; i < 10; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 10)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }
            fish_kind = FishKind.FISH_HUANGCAOYU;
            fish_id += 10;
            //右上
            MathAide.BuildCircle(radiusLittle, FishConfig.kScreenHeight - radiusLittle, radiusLittle, ref fish_pos_start, 20);
            float angle = Mathf.Atan(FishConfig.kScreenWidth / FishConfig.kScreenHeight);
            Vector2 centerRight;
            centerRight.x = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y + (radiusLittle + radiusBig) * Mathf.Sign(angle);
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x + n, centerRight.y, radiusLittle, ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 10;
            for (int i = 0; i < 20; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 20)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }

            fish_kind = FishKind.FISH_DAYANYU;
            fish_id += 20;
            //左上
            MathAide.BuildCircle(FishConfig.kScreenWidth - radiusLittle,FishConfig.kScreenHeight - radiusLittle, radiusLittle,ref fish_pos_start, 20);
            centerRight.x = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y + (radiusLittle + radiusBig) * Mathf.Sin(angle);
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x + n, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 10;
            for (int i = 0; i < 20; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 20)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }
            fish_kind = FishKind.FISH_HUANGBIANYU;
            fish_id += 20;
            //左下
            MathAide.BuildCircle(FishConfig.kScreenWidth - radiusLittle, radiusLittle, radiusLittle,ref fish_pos_start, 20);
            centerRight.x = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x + n, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 10;
            for (int i = 0; i < 20; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 20)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }
            fish_kind = FishKind.FISH_XIAOCHOUYU;
            fish_id += 20;
            //右下
            MathAide.BuildCircle(radiusLittle, radiusLittle, radiusLittle,ref fish_pos_start, 20);
            centerRight.x = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            centerRight.y = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_pos_end, 20);
            for (int i = 0; i < 20; ++i)
            {
                init_x[0] = fish_pos_start[i].x;
                init_y[0] = fish_pos_start[i].y;
                init_x[1] = fish_pos_end[i].x;
                init_y[1] = fish_pos_end[i].y;
                MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id + i], littleSpeed);
            }
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint[] fish_point = new MovePoint[40];
                for (int i = 0; i < fish_point.Length; ++i)
                {
                    fish_point[i] = new MovePoint();
                }
                MathAide.BuildCircle(centerRight.x + n, centerRight.y, radiusLittle,ref fish_point, 20, rotate, kRotateSpeed);
                for (int j = 0; j < 20; ++j)
                {
                    movePointVector[fish_id + j].Add(fish_point[j]);
                }
                n += 1;
            }
            tempHalf = 10;
            for (int i = 0; i < 20; ++i)
            {
                action = new FishActionFishMoveBezier(movePointVector[fish_id + i]);
                if (i + tempHalf < 20)
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i + tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
                else
                    outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id + i - tempHalf, _kind = fish_kind, _points = movePointVector[fish_id + i] });
            }
            fish_kind = FishKind.FISH_SWK;
            fish_id += 20;
            init_x[0] = radiusLittle;
            init_y[0] = FishConfig.kScreenHeight - radiusLittle;
            init_x[1] = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y + (radiusLittle + radiusBig) * Mathf.Sin(angle);
            MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] + n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_kind = FishKind.FISH_SWK;
            fish_id += 1;
            init_x[0] = FishConfig.kScreenWidth - radiusLittle;
            init_y[0] = FishConfig.kScreenHeight - radiusLittle;
            init_x[1] = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y + (radiusLittle + radiusBig) * Mathf.Sin(angle);
            MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] + n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_kind = FishKind.FISH_SWK;
            fish_id += 1;
            init_x[0] = FishConfig.kScreenWidth - radiusLittle;
            init_y[0] = radiusLittle;
            init_x[1] = center.x + (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] + n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_kind = FishKind.FISH_SWK;
            fish_id += 1;
            init_x[0] = radiusLittle;
            init_y[0] = radiusLittle;
            init_x[1] = center.x - (radiusLittle + radiusBig) * Mathf.Cos(angle);
            init_y[1] = center.y - (radiusLittle + radiusBig) * Mathf.Sin(angle);
            MathAide.BuildLinear(init_x, init_y, 2,ref movePointVector[fish_id], littleSpeed);
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 3; rotate += kRotateSpeed)
            {
                if (movePointVector[fish_id].Count > countTemp)
                    break;
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1];
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
            }
            n = 0;
            for (float rotate = 0.0f; rotate <= kLFish1Rotate * 4; rotate += kRotateSpeed)
            {
                MovePoint movePoint = new MovePoint();
                movePoint.position_.x = init_x[1] + n;
                movePoint.position_.y = init_y[1];
                movePoint.angle_ = rotate;
                movePointVector[fish_id].Add(movePoint);
                n += 1;
            }
            action = new FishActionFishMoveBezier(movePointVector[fish_id]);
            outAssetData.Add(new FishActionMoveBezier { _fish_id = fish_id, _kind = fish_kind, _points = movePointVector[fish_id] });
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            fish_id += 1;
        }

        void BuildSceneFish2(int me_chair_id, List<FishActionMoveLiner> assetDatas)
        {
            const float kFishSpeed = 60.0f;
            int fish_id = 0;
            FishKind fish_kind;
            FishActionFishMove action = null;
            Vector2 start, end;
            const float kOffset = 100.0f;
            float sub_offset;

            // 绿草鱼 16 * 4 // 200
            sub_offset = 168.0f;
            fish_kind = FishKind.FISH_LVCAOYU;
            for (int i = 0; i < 16; ++i)
            {
                end.y = start.y = 150 + 12;
                end.x = FishConfig.kScreenWidth + 60.0f;
                start.x = -kOffset - sub_offset - i * 54;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 16;
            for (int i = 0; i < 16; ++i)
            {
                end.y = start.y = 150 + 12 + 100;
                end.x = FishConfig.kScreenWidth + 60.0f;
                start.x = -kOffset - sub_offset - i * 54;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 16;
            for (int i = 0; i < 16; ++i)
            {
                end.y = start.y = FishConfig.kScreenHeight - 150 - 100;
                end.x = FishConfig.kScreenWidth + 60.0f;
                start.x = -kOffset - sub_offset - i * 54;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 16;
            for (int i = 0; i < 16; ++i)
            {
                end.y = start.y = FishConfig.kScreenHeight - 150;
                end.x = FishConfig.kScreenWidth + 60.0f;
                start.x = -kOffset - sub_offset - i * 54;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 16;

            // 小刺鱼 10 + 10 + 3 + 3
            fish_kind = FishKind.FISH_XIAOCIYU;
            for (int i = 0; i < 10; ++i)
            {
                end.y = start.y = 150 + 12 + 50;
                end.x = FishConfig.kScreenWidth + 150.0f;
                start.x = -kOffset - i * 120;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 10;
            for (int i = 0; i < 10; ++i)
            {
                end.y = start.y = FishConfig.kScreenHeight - 150 - 50;
                end.x = FishConfig.kScreenWidth + 150.0f;
                start.x = -kOffset - i * 120;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 10;
            for (int i = 0; i < 3; ++i)
            {
                end.y = start.y = 150.0f + 12 + 50 + (i + 1) * 100;
                end.x = FishConfig.kScreenWidth + 150.0f;
                start.x = -kOffset;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 3;
            for (int i = 0; i < 3; ++i)
            {
                end.y = start.y = 150.0f + 12 + 50 + (i + 1) * 100;
                end.x = FishConfig.kScreenWidth + 150.0f;
                start.x = -kOffset - 9 * 120;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 3;

            // 大闹天宫 绿草鱼和小刺鱼
            fish_kind = FishKind.FISH_DNTG;
            end.y = start.y = 150 + 12;
            end.x = FishConfig.kScreenWidth + 150.0f;
            start.x = -kOffset - 256;
            SwitchViewPosition(me_chair_id, ref start, ref end);
            assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id });
            //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, FISH_LVCAOYU, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            ++fish_id;
            end.y = start.y = 150 + 40;
            end.x = FishConfig.kScreenWidth + 150.0f;
            start.x = -kOffset - 128;
            SwitchViewPosition(me_chair_id, ref start, ref end);
            //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
            assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id });
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, FISH_XIAOCIYU, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            ++fish_id;

            // 大眼鱼 4 + 4
            fish_kind = FishKind.FISH_DAYANYU;
            Vector2 center = new Vector2(-kOffset - sub_offset - 2 * 54, 150.0f + 12 + 50 + 165);
            float radius = 50.0f;
            float angle = 0.0f;
            for (int i = 0; i < 4; ++i)
            {
                start.x = center.x + radius * Mathf.Cos(angle);
                start.y = center.y + radius * Mathf.Sin(angle);
                end.x = FishConfig.kScreenWidth + 150.0f;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i});
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                angle += (float)FishConfig.M_PI_2;
            }
            fish_id += 4;
            center.x = -kOffset - sub_offset - 13 * 54;
            angle = 0.0f;
            for (int i = 0; i < 4; ++i)
            {
                start.x = center.x + radius * Mathf.Cos(angle);
                start.y = center.y + radius * Mathf.Sin(angle);
                end.x = FishConfig.kScreenWidth + 150.0f;
                end.y = start.y;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id + i });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
                angle += (float)FishConfig.M_PI_2;
            }
            fish_id += 4;

            // 悟空
            fish_kind = FishKind.FISH_SWK;
            end.y = start.y = FishConfig.kScreenHeight / 2.0f; //- 150 - 100;
            end.x = FishConfig.kScreenWidth + 380.0f;
            start.x = -kOffset - 620;
            SwitchViewPosition(me_chair_id, ref start, ref end);
            //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
            assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _speed = kFishSpeed, _start = start, _end = end, _fish_id = fish_id });
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            ++fish_id;
        }

        void BuildSceneFish3(int me_chair_id, List<FishActionMoveScene3> assetDatas)
        {
            const float kFishSpeed = 150.0f;
            int fish_id = 0;
            FishKind fish_kind;
            FishActionFishMove action = null;
            Vector2 center = new Vector2(FishConfig.kScreenWidth / 2.0f, FishConfig.kScreenHeight / 2.0f);
            float radius;
            float cell_radian;
            float angle;

            // 玉皇大帝
            fish_kind = FishKind.FISH_YUWANGDADI;
            //action = new ActionScene3FishMove(center, 0, 28.0f, me_chair_id < 3 ? (float)FishConfig.M_PI : 0, (float)(4 * FishConfig.M_PI + FishConfig.M_PI_2), 5.0f, kFishSpeed);
            action = FishAction.CreateActionFromPool<ActionScene3FishMove>();
            (action as ActionScene3FishMove).Create(center, 0, 28.0f, me_chair_id < 3 ? (float)FishConfig.M_PI : 0, (float)(4 * FishConfig.M_PI + FishConfig.M_PI_2), 5.0f, kFishSpeed);
            assetDatas.Add(new FishActionMoveScene3 {_fish_id = fish_id,_kind = fish_kind, center = center, radius = 0.0f, rotate_duration = 28.0f, start_angle = me_chair_id < 3 ? (float)FishConfig.M_PI : 0, rotate_angle = (float)(4 * FishConfig.M_PI + FishConfig.M_PI_2), move_duration = 5.0f, fish_speed = kFishSpeed });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            ++fish_id;

            // 小丑鱼
            fish_kind = FishKind.FISH_XIAOCHOUYU;
            radius = 150.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 10);
            for (int i = 0; i < 10; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene3FishMove(center, radius, 27.0f, angle, (float)(4 * FishConfig.M_PI), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene3FishMove>();
                (action as ActionScene3FishMove).Create(center, radius, 27.0f, angle, (float)(4 * FishConfig.M_PI), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 27.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);

                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 10;

            // 大眼鱼
            fish_kind = FishKind.FISH_DAYANYU;
            radius = 150.0f + 52.0f + 42.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 18);
            for (int i = 0; i < 18; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene3FishMove(center, radius, 26.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene3FishMove>();
                (action as ActionScene3FishMove).Create(center, radius, 26.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 26.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);

                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 18;

            // 黄草鱼
            fish_kind = FishKind.FISH_HUANGCAOYU;
            radius = 150.0f + 52.0f + 42.0f * 2 + 30;
            cell_radian = (float)(2 * FishConfig.M_PI / 30);
            for (int i = 0; i < 30; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene3FishMove(center, radius, 25.0f, angle,(float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 2), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene3FishMove>();
                (action as ActionScene3FishMove).Create(center, radius, 25.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 2), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 25.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 2), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 30;

            // 蜗牛鱼
            fish_kind = FishKind.FISH_WONIUYU;
            radius = 150.0f + 52.0f + 42.0f * 2 + 30 * 2 + 35;
            cell_radian = (float)(2 * FishConfig.M_PI / 30);
            for (int i = 0; i < 30; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene3FishMove(center, radius, 24.0f, angle,(float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 3), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene3FishMove>();
                (action as ActionScene3FishMove).Create(center, radius, 24.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 3), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 24.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 3), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 30;
        }

        void BuildSceneFish4(int me_chair_id, List<FishActionMoveScene3> assetDatas)
        {
            const float kFishSpeed = 150.0f;
            int fish_id = 0;
            FishKind fish_kind;
            FishActionFishMove action = null;
            Vector2 center = new Vector2(FishConfig.kScreenWidth / 2.0f, FishConfig.kScreenHeight / 2.0f);
            float radius;
            float cell_radian;
            float angle;
            // 玉皇大帝
            fish_kind = FishKind.FISH_SWK;
            //action = new ActionScene4FishMove(center, 0, 28.0f, me_chair_id < 3 ? (float)FishConfig.M_PI : 0, (float)(4 * FishConfig.M_PI + FishConfig.M_PI_2), 5.0f, kFishSpeed);

            action = FishAction.CreateActionFromPool<ActionScene4FishMove>();
            (action as ActionScene4FishMove).Create(center, 0, 28.0f, me_chair_id < 3 ? (float)FishConfig.M_PI : 0, (float)(4 * FishConfig.M_PI + FishConfig.M_PI_2), 5.0f, kFishSpeed);
            assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id, _kind = fish_kind, center = center, radius = 0, rotate_duration = 28.0f, start_angle = me_chair_id < 3 ? (float)FishConfig.M_PI : 0, rotate_angle = (float)(4 * FishConfig.M_PI + FishConfig.M_PI_2), move_duration = 5.0f, fish_speed = kFishSpeed });
            FishDataManager.Instance().CreateFish(fish_kind, fish_id, action);
            //m_FishItemLayer->ActiveFish(fish_kind, fish_id, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            ++fish_id;

            // 小丑鱼
            fish_kind = FishKind.FISH_XIAOCHOUYU;
            radius = 150.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 10);
            for (int i = 0; i < 10; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene4FishMove(center, radius, 27.0f, angle, (float)(4 * FishConfig.M_PI), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene4FishMove>();
                (action as ActionScene4FishMove).Create(center, radius, 27.0f, angle, (float)(4 * FishConfig.M_PI), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 27.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 10;

            // 大眼鱼
            fish_kind = FishKind.FISH_DAYANYU;
            radius = 150.0f + 52.0f + 42.0f;
            cell_radian = (float)(2 * FishConfig.M_PI / 18);
            for (int i = 0; i < 18; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene4FishMove(center, radius, 26.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene4FishMove>();
                (action as ActionScene4FishMove).Create(center, radius, 26.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 26.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 18;

            // 黄草鱼
            fish_kind = FishKind.FISH_HUANGCAOYU;
            radius = 150.0f + 52.0f + 42.0f * 2 + 30;
            cell_radian = (float)(2 * FishConfig.M_PI / 30);
            for (int i = 0; i < 30; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene4FishMove(center, radius, 25.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 2), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene4FishMove>();
                (action as ActionScene4FishMove).Create(center, radius, 25.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 2), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 25.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 2), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 30;

            // 蜗牛鱼
            fish_kind = FishKind.FISH_WONIUYU;
            radius = 150.0f + 52.0f + 42.0f * 2 + 30 * 2 + 35;
            cell_radian = (float)(2 * FishConfig.M_PI / 30);
            for (int i = 0; i < 30; ++i)
            {
                angle = i * cell_radian;
                if (me_chair_id < 3)
                    angle += (float)FishConfig.M_PI;
                //action = new ActionScene4FishMove(center, radius, 24.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 3), 5.0f, kFishSpeed);

                action = FishAction.CreateActionFromPool<ActionScene4FishMove>();
                (action as ActionScene4FishMove).Create(center, radius, 24.0f, angle, (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 3), 5.0f, kFishSpeed);
                assetDatas.Add(new FishActionMoveScene3 { _fish_id = fish_id + i, _kind = fish_kind, center = center, radius = radius, rotate_duration = 24.0f, start_angle = angle, rotate_angle = (float)(4 * FishConfig.M_PI - FishConfig.M_PI_2 * 3), move_duration = 5.0f, fish_speed = kFishSpeed });
                FishDataManager.Instance().CreateFish(fish_kind, fish_id + i, action);
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 30;
        }

        void BuildSceneFish5(int me_chair_id, List<FishActionMoveLiner> assetDatas)
        {
            float kFishSpeed = 50.0f;
            int fish_id = 0;
            FishKind fish_kind;
            FishActionFishMove action = null;
            Vector2 start, end;

            // 蜗牛鱼 上50 下50
            float hinterval = FishConfig.kScreenWidth / 13.0f;
            float vinterval = FishConfig.kScreenHeight / 6.0f;
            fish_kind = FishKind.FISH_WONIUYU;
            for (int i = 0; i < 50; ++i)
            {
                start.x = hinterval + (hinterval + (hinterval / 5.0f)) * (i % 10);
                start.y = -100.0f - (i / 10) * vinterval - (i % 3) * vinterval / 5.0f;
                end.x = start.x;
                end.y = FishConfig.kScreenHeight + 100.0f;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _fish_id = fish_id + i, _start = start, _end = end, _speed = kFishSpeed });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }

            fish_id += 50;
            for (int i = 0; i < 50; ++i)
            {
                start.x = hinterval + (hinterval + (hinterval / 5.0f)) * (i % 10) + hinterval / 2;
                start.y = FishConfig.kScreenHeight + 100.0f + 4 * vinterval - (i / 10) * vinterval + (i % 3) * vinterval / 5.0f;
                end.x = start.x;
                end.y = -100.0f;
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _fish_id = fish_id + i, _start = start, _end = end, _speed = kFishSpeed });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 50;

            // 蝙蝠鱼 银鲨 金鲨
            kFishSpeed = 100.0f;
            fish_kind = FishKind.FISH_BIANFUYU;
            Vector2[] kFishStart1 = new Vector2[5]{ new Vector2(FishConfig.kScreenWidth + 200,FishConfig.kScreenHeight / 2.0f), new Vector2(FishConfig.kScreenWidth + 500,FishConfig.kScreenHeight / 2.0f - 50), new Vector2(FishConfig.kScreenWidth + 800,FishConfig.kScreenHeight / 2.0f + 60), new Vector2(FishConfig.kScreenWidth + 1100,FishConfig.kScreenHeight / 2.0f - 60), new Vector2(FishConfig.kScreenWidth + 1400,FishConfig.kScreenHeight / 2.0f - 60) };
            Vector2[] kFishEnd1 = new Vector2[5] { new Vector2(-200, FishConfig.kScreenHeight / 2.0f), new Vector2(-200, FishConfig.kScreenHeight / 2.0f - 100), new Vector2(-200, FishConfig.kScreenHeight / 2.0f + 100), new Vector2(-200, FishConfig.kScreenHeight / 2.0f + 60), new Vector2(-200, FishConfig.kScreenHeight / 2.0f - 60) };
            for (int i = 0; i < 5; ++i)
            {
                start = kFishStart1[i];
                end = kFishEnd1[i];
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _fish_id = fish_id + i, _start = start, _end = end, _speed = kFishSpeed });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 5;
            fish_kind = FishKind.FISH_YINSHA;
            Vector2[] kFishStart2 = new Vector2[5]{ new Vector2(FishConfig.kScreenWidth + 200, FishConfig.kScreenHeight / 2.0f), new Vector2(FishConfig.kScreenWidth + 500, FishConfig.kScreenHeight / 2.0f - 50), new Vector2(FishConfig.kScreenWidth + 800, FishConfig.kScreenHeight / 2.0f + 60), new Vector2(FishConfig.kScreenWidth + 1100, FishConfig.kScreenHeight / 2.0f - 60), new Vector2(FishConfig.kScreenWidth + 1400, FishConfig.kScreenHeight / 2.0f - 60) };
            Vector2[] kFishEnd2 = new Vector2[5]{ new Vector2(-200.0f, FishConfig.kScreenHeight - 100.0f), new Vector2(-300.0f, FishConfig.kScreenHeight + 1.0f), new Vector2(-400.0f, FishConfig.kScreenHeight + 100.0f), new Vector2(-500.0f, FishConfig.kScreenHeight + 60.0f), new Vector2(-600, FishConfig.kScreenHeight - 60.0f) };
            for (int i = 0; i < 5; ++i)
            {
                start = kFishStart2[i];
                end = kFishEnd2[i];
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _fish_id = fish_id + i, _start = start, _end = end, _speed = kFishSpeed });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 5;
            fish_kind = FishKind.FISH_JINSHA;
            Vector2[] kFishStart3 = new Vector2[5]{ new Vector2(FishConfig.kScreenWidth + 200, FishConfig.kScreenHeight / 2.0f), new Vector2(FishConfig.kScreenWidth + 500, FishConfig.kScreenHeight / 2.0f - 50), new Vector2(FishConfig.kScreenWidth + 800, FishConfig.kScreenHeight / 2.0f + 60), new Vector2(FishConfig.kScreenWidth + 1100, FishConfig.kScreenHeight / 2.0f - 60), new Vector2(FishConfig.kScreenWidth + 1400, FishConfig.kScreenHeight / 2.0f - 60) };
            Vector2[] kFishEnd3 = new Vector2[5]{ new Vector2(-200, 100.0f), new Vector2(-300, 0), new Vector2(-400, -100), new Vector2(-500, -60), new Vector2(-600, 60) };
            for (int i = 0; i < 5; ++i)
            {
                start = kFishStart3[i];
                end = kFishEnd3[i];
                SwitchViewPosition(me_chair_id, ref start, ref end);
                //action = new FishActionFishMoveLinear(kFishSpeed, start, end);
                assetDatas.Add(new FishActionMoveLiner { _kind = fish_kind, _fish_id = fish_id + i, _start = start, _end = end, _speed = kFishSpeed });
                //m_FishItemLayer->ActiveFish(fish_kind, fish_id + i, 0, game_config_.fish_bounding_radius[fish_kind], game_config_.fish_bounding_count[fish_kind], action);
            }
            fish_id += 5;
        }
    }
}