using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

public class PackageAsset{

    [MenuItem("Tools/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        Debug.LogErrorFormat(string.Format("<color>{0}</color>",Application.dataPath));
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.LogErrorFormat(string.Format("<color>{0}</color>","打包成功"));
    }

    [MenuItem("Tools/MonoVersion")]
    static void DispalyMonoVersion()
    {
        Type type = Type.GetType("Mono.Runtime");
        if (type != null)
        {
            MethodInfo displayName = type.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static);
            if (displayName != null)
            {
                UnityEngine.Debug.LogFormat("<color=#00ff00>{0}</color>",displayName.Invoke(null, null));
            }
        }
    }
}
