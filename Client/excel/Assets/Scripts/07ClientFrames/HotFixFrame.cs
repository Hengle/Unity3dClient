using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.UI;
using UnityEngine.Networking;
using ProtoBuf;
using ProtoBuf.Meta;
using System.IO;

namespace GameClient
{
    public class HotFixFrame : ClientFrame
    {
        UnityEngine.UI.Text mHotFixStepInfo;
        protected override void _InitScriptBinder()
        {
            mHotFixStepInfo = mScriptBinder.GetObject("HotFixStepInfo") as UnityEngine.UI.Text;
        }

        protected override void _OnOpenFrame()
        {
            LogManager.Instance().LogErrorFormat("pd = {0}", Application.persistentDataPath);
            StartCoroutine(HotFixProcess());
        }

        enum HotFixStatus
        {
            HFS_INVALID = -1,

            HFS_DOWNLOAD_RESOURCES_FILE,
            HFS_DOWNLOAD_SUCCEED,
            HFS_DOWNLOAD_FAILED,
        }

        HotFixStatus mHotFixStatus = HotFixStatus.HFS_INVALID;

        IEnumerator HotFixProcess()
        {
            mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_RESOURCES_FILE;

            yield return GetAssetBundle();

            if(mHotFixStatus != HotFixStatus.HFS_DOWNLOAD_SUCCEED)
            {
                yield break;
            }

            yield return new WaitForSeconds(1.0f);
        }

        IEnumerator GetAssetBundle()
        {
            _LogProcessFormat(8500, "HotFix Start DownLoad hotfixdata ...");
			string _url = "file:/Users/shenshaojun/HotFixDir";

			UnityWebRequest www = new UnityWebRequest(_url);
            DownloadHandlerAssetBundle handler = new DownloadHandlerAssetBundle(www.url, 4215391504);
            www.downloadHandler = handler;
            yield return www.Send();

            if (www.isError)
            {
                LogManager.Instance().LogErrorFormat(www.error);
                mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_FAILED;
                _LogProcessFormat(8500, "HotFix DownLoad hotfixdata File Failed !!!");
            }
            else
            {
                mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_SUCCEED;
                _LogProcessFormat(8500, "HotFix DownLoad hotfixdata File Succeed !!!");
                LogManager.Instance().LogErrorFormat("GetAssetBundle SUCCEED !!");
                // Extracts AssetBundle
                if(null != handler)
                {
                    LogManager.Instance().LogErrorFormat("GetAssetBundle handler SUCCEED !!");
                    AssetBundle bundle = handler.assetBundle;
                    //Object obj0 = bundle.LoadAsset("hotfixdata");
                    AssetBinary hotFixData = bundle.LoadAsset("HotFixTable") as AssetBinary;
                    if (null != hotFixData)
                    {
                        LogManager.Instance().LogErrorFormat("Load HotFixTable AssetBinary SUCCEED !!");

                        var table = AssetManager.Instance()._ConvertTableObject(hotFixData, typeof(ProtoTable.HotFixTable)) as Dictionary<int, object>;
                        if (null != table)
                        {
                            _LogProcessFormat(8500,"Load HotFixTable TableData SUCCEED !!");

                            var enumerator = table.GetEnumerator();
                            while(enumerator.MoveNext())
                            {
                                ProtoTable.HotFixTable hotFixItem = enumerator.Current.Value as ProtoTable.HotFixTable;
                                if(null != hotFixItem)
                                {
                                    LogManager.Instance().LogErrorFormat("[ITEM] ID = [{0}] Desc = {1} ResName = {2}", hotFixItem.ID,hotFixItem.Descrip,hotFixItem.ResourceName);
                                }
                            }
                        }
                    }
                }
            }
        }

        void _LogProcessFormat(int Id, string format, params object[] argvs)
        {
            LogManager.Instance().LogProcessFormat(Id, format, argvs);
            if(null != mHotFixStepInfo)
            {
                mHotFixStepInfo.text = string.Format(format, argvs);
            }
        }

        protected override void _OnCloseFrame()
        {

        }
    }
}