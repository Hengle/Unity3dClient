using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameClient;

public class ExceptionManager : Singleton<ExceptionManager> {
    List<string> logBuffer = new List<string>();
    const int MAX_LOG_NUM = 250;
	const int WRITE_LOG_NUM = 50;

    public void Init()
    {
#if DEBUG_REPORT_ROOT		
        if (DebugSettings.GetInstance().DisableBugly)
            return;
#endif
            
        Application.logMessageReceived += OnExceptionCatch;
		#if EXCEPTION_UPLOAD
		ExceptionUploaderManager.instance.TryUploadOneError();
		#endif
	}

    public void UnInit()
    {
		#if DEBUG_REPORT_ROOT		
		if (DebugSettings.GetInstance().DisableBugly)
            return;
		#endif
        Application.logMessageReceived -= OnExceptionCatch;
    }

    public void OnExceptionCatch(string message, string stacktrace, LogType type)
    {
        if (LogType.Exception == type/* || LogType.Assert == type*/ || LogType.Error == type)
        {
            DateTime Dt = DateTime.Now;
            string strCurTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}", Dt.Year, Dt.Month, Dt.Day, Dt.Hour, Dt.Minute, Dt.Second);
            string butMsg = "{\r\n" +
                "\"message\":" + "\"" + message.Replace("\r\n", "") + "\"" +
                    ",\r\n\"stacktrace\":" + "\"" + stacktrace.Replace("\r\n", "") + "\"" +
                    ",\r\n\"time\":" + "\"" + strCurTime + "\""
                    + "\r\n" +
                    "\"device\":" + "\"";
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                butMsg += "iPhone\"";
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                butMsg += "Android\"";
            }
            else
            {
                butMsg += "PC Unity Editor\"";
            }
            butMsg += "\r\n}";

			if (type == LogType.Exception)
				LogManager.Instance().LogErrorFormat("{0}\n{1}", message, stacktrace);

            RecordLog(butMsg);
        }
    }

    public void RecordLog(string log)
    {
		#if DEBUG_REPORT_ROOT
		if (DebugSettings.GetInstance().DisableBugly)
            return;
		#endif

        //删掉超过MAX_LOG_NUM的部分
        if (logBuffer.Count > MAX_LOG_NUM)
        {
            for(int i=0; i<logBuffer.Count - MAX_LOG_NUM; ++i)
            {
                logBuffer.RemoveAt(0);
            }
        }

        logBuffer.Add(log);
        PrintLogToFile();
    }

	public void PrintPreloadRes(List<string> contents)
	{
		string path = GetLogFolderPath() + "preload.txt";
		FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
		StreamWriter sw = new StreamWriter(fs);
		sw.Flush();
		sw.BaseStream.Seek(0, SeekOrigin.End);
		for(int i=0; i<contents.Count; ++i)
			sw.WriteLine(contents[i]);

		sw.Flush();
		sw.Close();
	}


	public void PrintLogToFile(bool force=false)
    {
		if (logBuffer.Count <= 0)
			return;

		if (!force && logBuffer.Count < WRITE_LOG_NUM)
			return;

        string path = GetLogPath("Exception");
        //Logger.LogWarningFormat("PrintLogToFile:{0}", path);
        FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.Flush();
        sw.BaseStream.Seek(0, SeekOrigin.End);
        for (int i = 0; i < logBuffer.Count; ++i)
            sw.WriteLine(logBuffer[i]);

        sw.Flush();
        sw.Close();
        logBuffer.Clear();

		#if EXCEPTION_UPLOAD
		ExceptionUploaderManager.instance.TryCacheOneErrorLog();
		#endif

        //UploadAll();
    }

	public static string GetLogFolderPath()
	{
		//创建目录
		string path = null;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			path = GetPersistentDataPath() + "/";
		}
		else if (Application.platform == RuntimePlatform.Android)
		{
			path = GetPersistentDataPath() + "/";
		}
		else if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			path = Application.dataPath + "/";
		}
		else
		{
			path = Application.dataPath;
			path = path.Substring(0, path.LastIndexOf('/')) + "/GameLog/";
		}

		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);

		return path;
	}


    public string GetLogPath(string strLogType)
    {
        
        //------------------------------------------------------------------------------
		var path = GetLogFolderPath();

        //创建文件名
        DateTime Dt = DateTime.Now;
        string FileName = string.Format("{0}-{1}-{2}-{3}.txt", strLogType, Dt.Year, Dt.Month, Dt.Day);
        //------------------------------------------------------------------------------------
        return path + FileName;
    }

    private static string GetPersistentDataPath()
    {
        //         if (Application.platform == RuntimePlatform.Android)
        //             return "file://" + Application.persistentDataPath;
        //         else if (Application.platform == RuntimePlatform.IPhonePlayer)
        //             return "file://" + Application.persistentDataPath;
        //         else if (Application.platform == RuntimePlatform.WindowsEditor)
        //             return "file:///" + Application.persistentDataPath;
        //         else
        //             return "file://" + Application.persistentDataPath;

        return Application.persistentDataPath;
    }

    public void Upload(string fieldName, string url, string fileName)
    {
        /*
        if (HttpClient.Instance == null)
        {
            //LogWarning("UpLoadLogFile.Upload: HttpClient.Instance is not inited.");
            return;
        }

        if (System.IO.File.Exists(fieldName))
        {
            HttpClient.Instance.BeginPostRequest();
            //             HttpClient.Instance.AddField("uuid", DeviceInfomation.Instance.DeviceUniqueCode());
            //             HttpClient.Instance.AddField("model", DeviceInfomation.Instance.DeviceMode());
            //             HttpClient.Instance.AddField("gameVersion", MainScript.Instance.InternalVersion);
            //             HttpClient.Instance.AddField("systemVersion", DeviceInfomation.Instance.DeviceOSVersion());
            //             HttpClient.Instance.AddField("manufacturer", DeviceInfomation.Instance.DeviceOSName());

            byte[] content = File.ReadAllBytes(fieldName);
            HttpClient.Instance.AddBinary("dump", content, fileName);
            HttpClient.Instance.PostRequest(url, null);
           // System.IO.File.Delete(fieldName);//上传后就删除本地Log文件
        }
        else
        {
            //LogWarning( fieldName + " not found" ) ;
            //UnityEngine.Debug.LogWarning( fieldName + " not found" ) ;
        }
        */
    }

    public void UploadAll()
    {
        string dumpServerUrl = "ftp://daemon:xampp@192.168.0.103/dnf/ios/";
       // string dumpServerUrl = "http://192.168.108.1:8080/";

        string exceptionFilePath = GetLogPath("Exception");
        Upload(exceptionFilePath, dumpServerUrl, "exception.dump");

    }
}
