using UnityEngine;
using GameClient;

public class AssetProxy : MonoBehaviour
{
    public bool m_LogWhenDispose = false;
    protected AssetInst m_AssetInst = null;

    public void AddResRef(AssetProxy assetProxy)
    {
        if (null != assetProxy && null != assetProxy.m_AssetInst)
        {
            //if (Global.Settings.enableAssetInstPool) TODO:DJM
            if (false)
            {
                m_AssetInst = AssetInstPool.Instance().GetAssetInst(assetProxy.m_AssetInst.assetDesc, gameObject,1);
            }
            else
            {
                m_AssetInst = new AssetInst();
                m_AssetInst.Init(assetProxy.m_AssetInst.assetDesc, gameObject, 1);
            }
        }

        if(null != m_AssetInst)
        {
            if (m_AssetInst.obj as GameObject == assetProxy.m_AssetInst.obj as GameObject)
            {
                LogManager.Instance().LogErrorFormat("m_AssetInst.obj == assetProxy.m_AssetInst.obj reference copy error!");
                //ExceptionManager.Instance().RecordLog("m_AssetInst.obj == assetProxy.m_AssetInst.obj reference copy error!"); TODO:DJM
            }
        }
    }



    public bool Init(AssetInst assetInst)
    {
        if (assetInst == m_AssetInst)
            return true;
        else
        {
            if (null == m_AssetInst)
            {
                if (null != assetInst)
                {
                    if (null == assetInst.obj)
                        LogManager.Instance().LogErrorFormat("Invalid asset instance!");

                    m_AssetInst = assetInst;
                    return true;
                }
                else
                    ExceptionManager.Instance().RecordLog("null == assetInst!");
            }
            else
                ExceptionManager.Instance().RecordLog("null == m_AssetInst!");
        }

        m_AssetInst = null;
        return false;
    }

    void OnEnable()
    {
        do 
        {
        } while (false);
    }

    void OnDestroy()
    {
        if (m_LogWhenDispose)
            LogManager.Instance().LogErrorFormat("AssetProxy OnDestroy![{0}]", m_AssetInst.assetDesc.m_FullPath);

        if (null != m_AssetInst)
        {
            m_AssetInst.Release();
            m_AssetInst = null;
        }
        else
            LogManager.Instance().LogErrorFormat( "Destroy proxy without init!");

        m_LogWhenDispose = false;
    }
}