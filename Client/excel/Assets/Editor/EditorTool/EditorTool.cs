using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
}