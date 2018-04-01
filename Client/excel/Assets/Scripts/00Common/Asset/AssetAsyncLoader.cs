using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public delegate void OnLoadFinishCallback(UnityEngine.Object asset);

public class AssetAsyncLoader : MonoSingleton<AssetAsyncLoader>
{
    // Use this for initialization
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);

        gameObject.transform.position = new Vector3(0, -1000, 0);
    }

    public GameObject root
    {
        get { return gameObject; }
    }
    
    // Update is called once per frame
    void Update ()
    {
        AsyncLoadTaskAllocator<ResourceRequestWrapper, UnityEngine.Object>.Instance().Update();
        AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>.Instance().Update();
        AsyncLoadTaskAllocator<AssetBundleResquestWrapper, UnityEngine.Object>.Instance().Update();

        AssetPackageManager.Instance().UpdateAsync();
        AssetLoader.Instance().Update();
        CGameObjectPool.Instance().Update();
    }
}
