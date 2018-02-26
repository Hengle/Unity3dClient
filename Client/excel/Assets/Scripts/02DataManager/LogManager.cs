using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    class LogManager : Singleton<LogManager>
    {
        public void LogErrorFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
            UnityEngine.Debug.LogError(value);
        }

        public void LogWarningFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
            UnityEngine.Debug.LogWarning(value);
        }

        public void LogFormat(string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
            UnityEngine.Debug.Log(value);
        }

        public void LogError(string format)
        {
            UnityEngine.Debug.LogError(format);
        }

        public void LogWarning(string format)
        {
            UnityEngine.Debug.LogWarning(format);
        }

        public void Log(string format)
        {
            UnityEngine.Debug.Log(format);
        }

        public void LogProcessFormat(int Id, string format, params object[] argvs)
        {
            var value = string.Format(format, argvs);
            UnityEngine.Debug.LogWarningFormat("<color=#00ff00>[PID={0}]</color>:{1}",Id,value);
        }

        public void LogProcess(int Id, string format)
        {
            UnityEngine.Debug.LogWarningFormat("<color=#00ff00>[PID={0}]</color>:{1}", Id, format);
        }
    }
}