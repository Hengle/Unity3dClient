using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;

public class PackageAsset
{
    static protected string m_OutputBundlePath = "Assets/StreamingAssets/AssetBundles/";
    static protected string m_StreamingBundlePath = "AssetBundles/";
    static protected string m_TempAssetPath = "Assets/PackAssetTemp/";
    static protected string m_OutputBundleExt = ".pck";

    //[MenuItem("Tools/Build AssetBundles")]
    //static void BuildAllAssetBundles()
    //{
    //    Debug.LogErrorFormat(string.Format("<color>{0}</color>",Application.dataPath));
    //    BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android);
    //    AssetDatabase.SaveAssets();
    //    AssetDatabase.Refresh();
    //    Debug.LogErrorFormat(string.Format("<color>{0}</color>","打包成功"));
    //}

    [MenuItem("Tools/Build Android Dll")]
    static void BuildAnroidDll()
    {
        AssetBundleBuild[] bundlePackageInfoBuild = new AssetBundleBuild[1];
        bundlePackageInfoBuild[0].assetBundleName = "Assembly_CharpDll.pak";
        bundlePackageInfoBuild[0].assetNames = new string[1] { "Assets/AssetBundles/Assembly-CSharp.bytes" };
        bundlePackageInfoBuild[0].assetBundleVariant = string.Empty;
        AssetBundleManifest assetManifestPackageInfo = BuildPipeline.BuildAssetBundles(m_OutputBundlePath, bundlePackageInfoBuild, BuildAssetBundleOptions.None,BuildTarget.Android);
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

    [MenuItem("Tools/Build AssetBundles(Assets/AssetBundles)")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}