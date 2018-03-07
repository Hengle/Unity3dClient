using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
}
