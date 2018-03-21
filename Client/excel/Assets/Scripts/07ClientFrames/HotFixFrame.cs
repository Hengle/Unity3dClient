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
            //mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_RESOURCES_FILE;

            //yield return GetAssetBundle();

            //if (mHotFixStatus != HotFixStatus.HFS_DOWNLOAD_SUCCEED)
            //{
            //    yield break;
            //}

            mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_RESOURCES_FILE;
            yield return GetAssemblyDllAssetBundle();
            if (mHotFixStatus != HotFixStatus.HFS_DOWNLOAD_SUCCEED)
            {
                yield break;
            }
        }

        IEnumerator GetAssemblyDllAssetBundle()
        {
            _LogProcessFormat(8500, "HotFix Start DownLoad Assembly-DLL ...");
            string _url = @"http://192.168.2.27:8080/ZZZHotFixTesting/AssetBundles/assembly_charpdll.pak";
            UnityWebRequest www = new UnityWebRequest(_url);
            DownloadHandlerAssetBundle handler = new DownloadHandlerAssetBundle(www.url, 3411610002);
            www.downloadHandler = handler;
            yield return www.Send();

            if (www.isError)
            {
                LogManager.Instance().LogErrorFormat(www.error);
                _LogProcessFormat(8500, "HotFix DownLoad Assembly-DLL File Failed !!!");
            }
            else
            {
                // Extracts AssetBundle
                AssetBundle bundle = handler.assetBundle;
                if (null == bundle)
                {
                    _LogProcessFormat(8500, "HotFix DownLoad Assembly-DLL File Failed !!!");
                    yield break;
                }

                TextAsset asset = bundle.LoadAsset("Assembly-CSharp", typeof(TextAsset)) as TextAsset;
                if(null == asset)
                {
                    _LogProcessFormat(8500, "bundle.LoadAsset Failed !!");
                    yield break;
                }

                _LogProcessFormat(8500, "HotFix DownLoad Assembly-DLL File Succeed !!! length = {0} bytes !", asset.bytes.Length);
                LogManager.Instance().LogErrorFormat("GetAssetBundle SUCCEED !! length = {0} bytes !", asset.bytes.Length);

                var assembly = System.Reflection.Assembly.Load(asset.bytes);
                if(null == assembly)
                {
                    yield break;
                }

                LogManager.Instance().LogErrorFormat("Load Assembly-CSharp.DLL  Assembly !! Succeed !!");
                mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_SUCCEED;
            }
        }


        IEnumerator GetAssemblyDll()
        {
            _LogProcessFormat(8500, "HotFix Start DownLoad Assembly-DLL ...");
            string _url = @"C:\AssetBundles\Assembly-CSharp.bytes";
            UnityWebRequest www = new UnityWebRequest(_url);
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.Send();

            if (www.isError)
            {
                LogManager.Instance().LogErrorFormat(www.error);
                _LogProcessFormat(8500, "HotFix DownLoad Assembly-DLL File Failed !!!");
            }
            else
            {
                mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_SUCCEED;
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
                _LogProcessFormat(8500, "HotFix DownLoad Assembly-DLL File Succeed !!! length = {0} bytes !",results.Length);
                LogManager.Instance().LogErrorFormat("GetAssetBundle SUCCEED !! length = {0} bytes !", results.Length);
            }
        }

        IEnumerator GetAssetBundle()
        {
            _LogProcessFormat(8500, "HotFix Start DownLoad hotfixdata ...");
			string _url = @"C:\AssetBundles\hotfixdata";

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