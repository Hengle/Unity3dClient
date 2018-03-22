using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.UI;
using UnityEngine.Networking;
using ProtoBuf;
using ProtoBuf.Meta;
using System.IO;
using System;

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
        string _LocalVersion = @"1.0.0.0";
        string _RemoteVersion = string.Empty;

        IEnumerator HotFixProcess()
        {
            mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_RESOURCES_FILE;
            yield return DownLoadRemoteVersion();
            if (mHotFixStatus != HotFixStatus.HFS_DOWNLOAD_SUCCEED)
            {
                yield break;
            }

            if (_LocalVersion == _RemoteVersion)
            {
                _LogProcessFormat(8500, "Your Client is the New Version !!");
                yield break;
            }

            mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_RESOURCES_FILE;
            yield return GetAssemblyDll();
            if (mHotFixStatus != HotFixStatus.HFS_DOWNLOAD_SUCCEED)
            {
                yield break;
            }
        }

        void SaveBytes(string path, string filename, byte[] bytes)
        {
            _LogProcessFormat(8500, "HotFix SaveBytes path = {0}", path);
            _LogProcessFormat(8500, "HotFix SaveBytes name = {0}", path);
            try
            {
                Directory.CreateDirectory(path);
                FileInfo file = new FileInfo(path + filename);
                if (file.Exists)
                {
                    file.Delete();
                }
                var sw = file.Create();
                sw.Write(bytes, 0, bytes.Length);
                sw.Close();
                sw.Dispose();
            }
            catch(Exception e)
            {
                _LogProcessFormat(8500, "HotFix SaveBytes {0} failed", path + filename);
                _LogProcessFormat(8500, "HotFix SaveBytes Error {0}",e.ToString());
            }
        }

        void RestartApplication()
        {
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = jc.GetStatic <AndroidJavaObject> ("currentActivity");
            _LogProcessFormat(8500,"restartApplication [1]");
            jo.Call("restartApplication");
            _LogProcessFormat(8500,"restartApplication [2]");
        }

        IEnumerator DownLoadRemoteVersion()
        {
            _RemoteVersion = string.Empty;
            _LogProcessFormat(8500, "HotFix Start DownLoad RemoteVersion ... LocalVersion = {0}",_LocalVersion);
            string _url = @"http://192.168.3.110:8080/AssetBundles/version.txt";
            UnityWebRequest www = new UnityWebRequest(_url);
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.Send();

            if (www.isError)
            {
                LogManager.Instance().LogErrorFormat(www.error);
                _LogProcessFormat(8500, "HotFix DownLoad RemoteVersion File Failed !!!");
            }
            else
            {
                // Or retrieve results as binary data
                _RemoteVersion = www.downloadHandler.text;
                _LogProcessFormat(8500, "HotFix DownLoad RemoteVersion File Succeed !!! version = {0} !", _RemoteVersion);
                mHotFixStatus = HotFixStatus.HFS_DOWNLOAD_SUCCEED;
            }
        }

        IEnumerator GetAssemblyDll()
        {
            _LogProcessFormat(8500, "HotFix Start DownLoad Assembly-DLL ...");
            string _url = @"http://192.168.3.110:8080/AssetBundles/Assembly-CSharp.bytes";
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

                string path = string.Empty;

                if(Application.platform == RuntimePlatform.Android)
                {
                    string datapath = Application.dataPath;
                    int start = datapath.IndexOf("com.");
                    int end = datapath.IndexOf("-");
                    string packagename = datapath.Substring(start, end - start);
                    path = "/data/data/" + packagename + "/files/";
                }
                else if(Application.platform == RuntimePlatform.WindowsEditor)
                {
                    path = Application.persistentDataPath + "/" + "Assembly-CSharp.dll";
                }

                if(!string.IsNullOrEmpty(path))
                {
                    _LogProcessFormat(8500, "ready save dll to {0}{1} !", path, "Assembly-CSharp.dll");
					try
					{
						SaveBytes(path, "Assembly-CSharp.dll", results);
						_LogProcessFormat(8500, "save dll to {0}{1} succeed!", path, "Assembly-CSharp.dll");
					}
					catch (Exception e) 
					{
						_LogProcessFormat(8500, "save dll to {0}{1} failed!", path, "Assembly-CSharp.dll");
						_LogProcessFormat(8500, e.ToString());
						yield break;
					}
                }

                if (Application.platform == RuntimePlatform.Android)
                {
					_LogProcessFormat(8500, "ready to restart application after 1 seconds !");
					yield return new WaitForSecondsRealtime(1);
                    RestartApplication();
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
                if (null != handler)
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
                            _LogProcessFormat(8500, "Load HotFixTable TableData SUCCEED !!");

                            var enumerator = table.GetEnumerator();
                            while (enumerator.MoveNext())
                            {
                                ProtoTable.HotFixTable hotFixItem = enumerator.Current.Value as ProtoTable.HotFixTable;
                                if (null != hotFixItem)
                                {
                                    LogManager.Instance().LogErrorFormat("[ITEM] ID = [{0}] Desc = {1} ResName = {2}", hotFixItem.ID, hotFixItem.Descrip, hotFixItem.ResourceName);
                                }
                            }
                        }
                    }
                }
            }
        }

        IEnumerator GetAssemblyDllAssetBundle()
        {
            _LogProcessFormat(8500, "HotFix Start DownLoad Assembly-DLL ...");
            string _url = @"http://192.168.3.102:8080/AssetBundles/assembly_charpdll.pak";
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
    }
}