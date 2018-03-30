using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using GameClient;

public class AssetPackageLoader : MonoSingleton<AssetPackageLoader>
{
    public AssetBundle LoadPackage(AssetPackage package)
    {
        if (null == package)
            return null;
        
        AssetBundle newAssetBundle = null;
        newAssetBundle = _LoadPackageSync(package);

        return newAssetBundle;
    }
    public IAsyncLoadRequest<AssetBundle> LoadPackageAsync(AssetPackage package)
    {
        if (null == package)
            return AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>.INVALID_LOAD_REQUEST;

        return _LoadPackageAsync(package);
    }

    public AssetBundle _LoadPackageSync(AssetPackage package)
    {
        AssetBundle bundle = _LoadPackageSync(package,false,true);
        if(null == bundle)
        {
            bundle = _LoadPackageSync(package, false, false);
            if (null == bundle)
            {
                bundle = _LoadPackageSync(package,true,false);
            }
        }

        return bundle;
    }

    public IAsyncLoadRequest<AssetBundle> _LoadPackageAsync(AssetPackage package)
    {
        IAsyncLoadRequest<AssetBundle> packageRequest = _LoadPackageAsync(package,false,true);
        if (!packageRequest.IsValid())
        {
            packageRequest = _LoadPackageAsync(package, false, false);
            if (!packageRequest.IsValid())
            {
                packageRequest = _LoadPackageAsync(package, true,false);
            }
        }

        return packageRequest;
    }

    /// public AssetBundle _LoadPackageFromNativeSync(AssetPackage package)
    /// {
    ///     string packagePath = Path.Combine(Application.streamingAssetsPath, package.packageFullPath);
    ///     //if (!File.Exists(packagePath))
    ///     //{
    ///     //    LogManager.Instance().LogErrorFormat("Asset package with Path [{0}] does not exist!" ,packagePath);
    ///     //    return null;
    ///     //}
    /// 
    ///     AssetBundle bundle = AssetBundle.LoadFromFile(packagePath);
    ///     if (null != bundle)
    ///     {
    ///         return bundle;
    ///     }
    ///     else
    ///         LogManager.Instance().LogErrorFormat("Load asset bundle from file has failed![AssetBundle:{0}]", packagePath);
    ///     /*
    ///     byte[] content = File.ReadAllBytes(packagePath);
    ///     if(null != content)
    ///     {
    ///         AssetBundle bundle = AssetBundle.LoadFromMemory(content);
    ///         if (null != bundle)
    ///         {
    ///             packageBytes = content.Length;
    ///             content = null;
    /// 
    ///             //GC.Collect();
    ///             return bundle;
    ///         }
    ///         else
    ///             LogManager.Instance().LogErrorFormat( "Load asset bundle from memory has failed(Maybe can not allocate no more memory) [AssetBundle:{0}]!", packagePath);
    ///     }
    ///     */
    ///     return null;
    /// }
    /// public AssetBundle _LoadPackageFromHotFixSync(AssetPackage package)
    /// {
    ///     string packagePath = Path.Combine(Application.persistentDataPath, package.packageFullPath);
    ///     if (!File.Exists(packagePath))
    ///     {
    ///         LogManager.Instance().LogErrorFormat("Asset package with Path [{0}] does not exist!", packagePath);
    ///         return null;
    ///     }
    /// 
    ///     AssetBundle bundle = AssetBundle.LoadFromFile(packagePath);
    ///     if (null != bundle)
    ///     {
    ///         return bundle;
    ///     }
    ///     else
    ///         LogManager.Instance().LogErrorFormat("Load asset bundle from file has failed![AssetBundle:{0}]", packagePath);
    /// 
    ///     //byte[] content = File.ReadAllBytes(packagePath);
    ///     //if (null != content)
    ///     //{
    ///     //    AssetBundle bundle = AssetBundle.LoadFromMemory(content);
    ///     //    if (null != bundle)
    ///     //    {
    ///     //        packageBytes = content.Length;
    ///     //        content = null;
    ///     //
    ///     //        //GC.Collect();
    ///     //        return bundle;
    ///     //    }
    ///     //    else
    ///     //        LogManager.Instance().LogErrorFormat("Load asset bundle from memory has failed(Maybe can not allocate no more memory) [AssetBundle:{0}]!", packagePath);
    ///     //}
    /// 
    ///     return null;
    /// }

    public AssetBundle _LoadPackageSync(AssetPackage package, bool fromNative,bool fromHotfix)
    {
        /// if (package.packageName.Equals("data_table.pck", StringComparison.OrdinalIgnoreCase))
        /// {/// 临时的特殊处理
        ///     byte[] data_table = null;
        ///     if (fromNative)
        ///         FileArchiveAccessor.LoadFileInLocalFileArchive(package.packageFullPath, out data_table);
        ///     else
        ///         FileArchiveAccessor.LoadFileInPersistentFileArchive(fromHotfix ? package.packageHotfixPath : package.packageFullPath, out data_table);
        /// 
        ///     if(null != data_table)
        ///     {/// data_table.pck memory
        ///         AssetBundle bundle = AssetBundle.LoadFromMemory(data_table);
        ///         if (null != bundle)
        ///         {
        ///             return bundle;
        ///         }
        ///         else
        ///             LogManager.Instance().LogErrorFormat("Load asset bundle from file has failed![AssetBundle:{0}]", package.packageFullPath);
        ///     }
        /// }
        /// else
        /// {
        ///     string assetPackagePath = null;
        ///     if (fromNative)
        ///         assetPackagePath = Application.streamingAssetsPath;
        ///     else
        ///         assetPackagePath = Application.persistentDataPath;
        /// 
        ///     assetPackagePath = Path.Combine(assetPackagePath, fromHotfix ? package.packageHotfixPath : package.packageFullPath);
        /// 
        ///     if (!fromNative)
        ///         if (!File.Exists(assetPackagePath))
        ///             return null;
        /// 
        ///     AssetBundle bundle = AssetBundle.LoadFromFile(assetPackagePath);
        ///     if (null != bundle)
        ///     {
        ///         return bundle;
        ///     }
        ///     else
        ///         LogManager.Instance().LogErrorFormat("Load asset bundle from file has failed![AssetBundle:{0}]", assetPackagePath);
        /// }
        /// 
        /// return null;
        /// 

        string assetPackagePath = null;
        if (fromNative)
            assetPackagePath = Application.streamingAssetsPath;
        else
            assetPackagePath = Application.persistentDataPath;

        assetPackagePath = Path.Combine(assetPackagePath, fromHotfix ? package.packageHotfixPath : package.packageFullPath);

        if (!fromNative)
            if (!File.Exists(assetPackagePath))
                return null;

        AssetBundle bundle = AssetBundle.LoadFromFile(assetPackagePath);
        if (null != bundle)
        {
            return bundle;
        }
        else
            LogManager.Instance().LogErrorFormat("Load asset bundle from file has failed![AssetBundle:{0}]", assetPackagePath);

        return null;
    }


    public IAsyncLoadRequest<AssetBundle> _LoadPackageAsync(AssetPackage package,bool fromNative, bool fromHotfix)
    {
        string assetPackagePath = null;
        if (fromNative)
        {
            return AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>.Instance().AllocAsyncTask(
                Path.Combine(Application.streamingAssetsPath, package.packageFullPath), new AssetBundleCreateRequestData());
        }
        else
        {
            assetPackagePath = Path.Combine(Application.persistentDataPath, fromHotfix ? package.packageHotfixPath : package.packageFullPath);
            if (File.Exists(assetPackagePath))
            {
                return AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>.Instance().AllocAsyncTask(
                    assetPackagePath, new AssetBundleCreateRequestData());
            }
            else
                return AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>.INVALID_LOAD_REQUEST;
        }
    }

    public AssetBundle _LoadPackageFromWWW(AssetPackage package, out long packageBytes, bool bAsync = false)
    {
        packageBytes = 0;

        return null;
    }
}
