using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Protocol;
using XLua;
using System.Diagnostics;

namespace GameClient
{
    [LuaCallCSharp]
    class LogManager
    {
        protected static LogManager ms_handle = null;
        [LuaCallCSharp]
        public static LogManager Instance()
        {
            if (null == ms_handle)
            {
                ms_handle = new LogManager();
            }
            return ms_handle;
        }

        const int LogLimit = 256;
        List<LogItem> mLogItems = new List<LogItem>(LogLimit);
        List<LogItem> mCachedLogs = new List<LogItem>(LogLimit);

        public List<LogItem> GetLogItems()
        {
            return mLogItems;
        }

        public void RecycleFirstLogItem()
        {
            if(mLogItems.Count > 0)
            {
                mCachedLogs.Add(mLogItems[0]);
                mLogItems.RemoveAt(0);
            }
        }
        [Conditional("LOG_OPEN")]
        public void LogErrorFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if UNITY_EDITOR
            UnityEngine.Debug.LogError(value);
#else
            PushLogToFile(LogItem.LogType.LT_ERROR, 0, value);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void LogWarningFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(value);
#else
            PushLogToFile(LogItem.LogType.LT_WARNING, 0, value);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void LogFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if UNITY_EDITOR
            UnityEngine.Debug.Log(value);
#else
            PushLogToFile(LogItem.LogType.LT_NORMAL, 0, value);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void LogError(string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogError(format);
#else
            PushLogToFile(LogItem.LogType.LT_ERROR, 0, format);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void LogWarning(string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(format);
#else
            PushLogToFile(LogItem.LogType.LT_WARNING, 0, format);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void Log(string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(format);
#else
            PushLogToFile(LogItem.LogType.LT_NORMAL, 0, format);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void LogProcessFormat(int Id, string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarningFormat("<color=#00ff00>[PID={0}]</color>:{1}",Id,value);
            PushLogToFile(LogItem.LogType.LT_PROCESS, Id, value);
#else
			PushLogToFile(LogItem.LogType.LT_PROCESS, Id, value);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void LogProcess(int Id, string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarningFormat("<color=#00ff00>[PID={0}]</color>:{1}", Id, format);
#else
			PushLogToFile(LogItem.LogType.LT_PROCESS, Id, format);
#endif
        }
        [Conditional("LOG_OPEN")]
        public void PushLogToFile(LogItem.LogType eLogType,int id,string value)
        {
            LogItem logItem = null;
            if (mLogItems.Count < LogLimit)
            {
                if (mCachedLogs.Count > 0)
                {
                    logItem = mCachedLogs[0];
                    mCachedLogs.RemoveAt(0);
                }
                else
                {
                    logItem = new LogItem();
                }
            }
            else
            {
                logItem = mLogItems[0];
                mLogItems.RemoveAt(0);
            }

            logItem.eLogType = eLogType;
            logItem.logId = id;
            logItem.logValue = value;
            mLogItems.Add(logItem);
        }
    }
}