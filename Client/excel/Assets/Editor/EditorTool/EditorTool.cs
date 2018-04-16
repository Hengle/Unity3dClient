using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;

public class EditorTool
{
    [MenuItem("Assets/预览预制体", false)]
    public static GameObject PreviewPrefab()
    {
        UnityEngine.Object[] selection = Selection.GetFiltered(typeof(UnityEngine.Object), UnityEditor.SelectionMode.Assets);
        GameObject select = PrefabUtility.InstantiatePrefab(selection[0]) as GameObject;
        if (select != null)
        {
            GameObject layer = GameObject.Find("GameFrameWork/Environment/UICamera/Top");
            if(null == layer)
            {
                UnityEngine.Debug.LogError("layer can not be found for path GameFrameWork/Environment/UICamera/Top !!!");
                return null;
            }

            for(int i = 0; i < layer.transform.childCount; ++i)
            {
                GameObject.DestroyImmediate(layer.transform.GetChild(i).gameObject);
            }

            Utility.AttachTo(select, layer);
            EditorGUIUtility.PingObject(select);
            return select;
        }
        else
        {
            UnityEngine.Debug.LogError("请选择一个Prefab对象 !!");
            return null;
        }

    }

    [MenuItem("Assets/CopyAssetsPath", false)]
    public static void CopyAssetsPath()
    {
        UnityEngine.Object[] selection = Selection.GetFiltered(typeof(UnityEngine.Object), UnityEditor.SelectionMode.Assets);
        if (selection.Length > 0)
        {
            if (selection[0] is Texture2D)
            {
                string path = GetAssetPath(Selection.activeObject);
                GUIUtility.systemCopyBuffer = path + ":" + Selection.activeObject.name;
            }
            else
            {
                string path = GetAssetPath(selection[0]);
                if (path.Contains(".prefab"))
                    path = path.Replace(".prefab", "");
                GUIUtility.systemCopyBuffer = path;
            }
        }
    }

    static public string GetAssetFullPath(Object assets)
    {
        return AssetDatabase.GetAssetPath(assets);
    }

    private static string ResourceRootPath = "Assets/Resources/";

    static public string GetAssetPath(Object assets)
    {
        StringBuilder path = new StringBuilder(GetAssetFullPath(assets));
        path = path.Replace(ResourceRootPath, "");
        return path.ToString();
    }

    private static string LuaSourceRootPath = "/Resources/XLuaCode/";

    [MenuItem("XLua/Lua2Txt(给UNITY用)", false)]
    static public void Lua2Txt()
    {
        try
        {
            var fullPath = Path.GetFullPath(Application.dataPath + LuaSourceRootPath);
            var dirs = Directory.GetDirectories(fullPath);
            for (int j = 0; j < dirs.Length; ++j)
            {
                Debug.LogFormat("<color=#00ff00>convert dir : {0}</color>", dirs[j]);
                var files = Directory.GetFiles(dirs[j] + "/", "*.lua");
                for (int i = 0; i < files.Length; ++i)
                {
                    var file = Path.GetFileName(files[i]);
                    if (!string.IsNullOrEmpty(file))
                    {
                        Debug.LogFormat("<color=#00ff00>convert file : {0}</color>", file);
                        File.Move(files[i], files[i] + ".txt");
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogErrorFormat(e.ToString());
            return;
        }

        Debug.LogFormat("<color=#00ff00>convert all .lua to .lua.txt succeed !!</color>");

        AssetDatabase.Refresh();
    }

    [MenuItem("GameClient/Scene/Login", false)]
    static public void SwitchSceneToLogin()
    {
        GameClient.EventManager.Instance().SendEvent(GameClient.ClientEvent.CE_CHANGE_SCENE, GameClient.SceneType.ST_LOGIN);
    }

    [MenuItem("XLua/Txt2Lua(方便Lua编辑器读)", false)]
    static public void Txt2Lua()
    {
        try
        {
            var fullPath = Path.GetFullPath(Application.dataPath + LuaSourceRootPath);
            var dirs = Directory.GetDirectories(fullPath);
            for (int j = 0; j < dirs.Length; ++j)
            {
                Debug.LogFormat("<color=#00ff00>convert dir : {0}</color>", dirs[j]);
                var files = Directory.GetFiles(dirs[j] + "/", "*.txt");
                for (int i = 0; i < files.Length; ++i)
                {
                    var file = Path.GetFileName(files[i]);
                    if (!string.IsNullOrEmpty(file))
                    {
                        Debug.LogFormat("<color=#00ff00>convert file : {0}</color>", file);
                        File.Move(files[i], files[i].Substring(0, files[i].Length - 4));
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogErrorFormat(e.ToString());
            return;
        }

        Debug.LogFormat("<color=#00ff00>convert all .lua.txt to .lua succeed !!</color>");

        AssetDatabase.Refresh();
    }
}