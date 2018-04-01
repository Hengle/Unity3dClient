using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

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
}