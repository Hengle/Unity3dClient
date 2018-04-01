using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GameClient;

public enum AssetCollectType
{
    None            = 0x00,
    Spirte          = 0x01,
    AudioClip       = 0x02,
    AnimationClip   = 0x04,
    GameObject      = 0x08,
    All             = Spirte | AudioClip | AnimationClip | GameObject,
}

public class AssetGabageCollector : MonoSingleton<AssetGabageCollector>
{
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
        AssetGabageCollectorHelper.Instance().Update();

        if (!m_NeedClearAsset)
            return;

        ++m_FrameCntAfterGC;
        if (m_FrameCntAfterGC >= 3)
        {
            AssetLoader.Instance().PurgeUnusedRes(true);
            AssetPackageManager.Instance().UnloadUnusedPackage();

            m_FrameCntAfterGC = 0;
            m_NeedClearAsset = false;
            StartCoroutine(_CleanSync());
            LogManager.Instance().LogErrorFormat("################## Finish purge unused res!#####################");
        }
    }

	public void ClearUnusedAsset(List<string> keys=null)
    {
        if (m_NeedClearAsset)
            return;

		//低画质clear skill cache
		int level = 0;
        //TODO:DJM
		//GeGraphicSetting.Instance().GetSetting("GraphicLevel", ref level);
		//if (level == 2)
		//{
		//	BeActionFrameMgr.Clear();
		//}

        LogManager.Instance().LogErrorFormat( "################## Begin purge unused res!#####################");

        AssetLoader.Instance().ResetPurgeTick();

		if (keys == null)
        	CGameObjectPool.Instance().ExecuteClearPooledObjects();
		else
			CGameObjectPool.Instance().ExecuteClearPooledObjects(keys);

        GC.Collect();

        m_NeedClearAsset = true;
    }

    protected IEnumerator _CleanSync()
    {
        yield return Resources.UnloadUnusedAssets();
        //TODO:DJM
        //ObjectLeakDitector.DumpObjectRef();
    }

    protected int m_FrameCntAfterGC = 0;
    protected bool m_NeedClearAsset = false;
}
