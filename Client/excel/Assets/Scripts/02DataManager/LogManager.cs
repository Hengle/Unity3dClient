using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public enum LogType
    {
        LT_NORMAL = (1 << 0),
        LT_WARNING = (1 << 1),
        LT_ERROR = (1 << 2),
        LT_PROCESS = (1 << 3),
    }

    class LogManager : Singleton<LogManager>
    {
        public class LogItem
        {
            public int logId = 0;
            public LogType eLogType = LogType.LT_NORMAL;
            public string logValue = string.Empty;
            public void Reset()
            {
                logId = 0;
                eLogType = LogType.LT_NORMAL;
                logValue = string.Empty;
            }

            public string ToLogValue()
            {
                return string.Format("{0}|{1}|{2}", eLogType, logId, logValue);
            }
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

        public void LogErrorFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if UNITY_EDITOR
            UnityEngine.Debug.LogError(value);
#else
            PushLogToFile(LogType.LT_ERROR, 0, value);
#endif
        }

        public void LogWarningFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(value);
#else
            PushLogToFile(LogType.LT_WARNING, 0, value);
#endif
        }

        public void LogFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if UNITY_EDITOR
            UnityEngine.Debug.Log(value);
#else
            PushLogToFile(LogType.LT_NORMAL, 0, value);
#endif
        }

        public void LogError(string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogError(format);
#else
            PushLogToFile(LogType.LT_ERROR, 0, format);
#endif
        }

        public void LogWarning(string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(format);
#else
            PushLogToFile(LogType.LT_WARNING, 0, format);
#endif
        }

        public void Log(string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(format);
#else
            PushLogToFile(LogType.LT_NORMAL, 0, format);
#endif
        }

        public void LogProcessFormat(int Id, string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
#if !UNITY_EDITOR
            UnityEngine.Debug.LogWarningFormat("<color=#00ff00>[PID={0}]</color>:{1}",Id,value);
#else
            PushLogToFile(LogType.LT_PROCESS, Id, value);
#endif
        }

        public void LogProcess(int Id, string format)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarningFormat("<color=#00ff00>[PID={0}]</color>:{1}", Id, format);
#else
            PushLogToFile(LogType.LT_PROCESS, Id, format);
#endif
        }

        public void PushLogToFile(LogType eLogType,int id,string value)
        {
            LogItem logItem = null;
            if (mLogItems.Count < LogLimit)
            {
                if (mCachedLogs.Count > 0)
                {
                    logItem = mCachedLogs[0];
                    mCachedLogs.RemoveAt(0);
                    logItem.Reset();
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
                logItem.Reset();
            }

            logItem.eLogType = eLogType;
            logItem.logId = id;
            logItem.logValue = value;
            mLogItems.Add(logItem);
        }
    }
}