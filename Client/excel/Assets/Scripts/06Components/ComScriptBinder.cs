﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

namespace GameClient
{
    [System.Serializable]
    public class ScriptBinderItem
    {
        public int iHashCode;
        public UnityEngine.Object component;
        public string varName;
        public bool locked;
    }

    [System.Serializable]
    public class ScriptStateItem
    {
        public int iHashCode;
        public string statusName;
        public UnityEvent action;
        public bool locked;
    }

    public class ComScriptBinder : MonoBehaviour
    {
        [HideInInspector]
        public string labelSpace = string.Empty;
        [HideInInspector]
        public int labelTypeId = -1;
        public string[] argumentsString = new string[0];
        public int[] argumentsInt = new int[0];
        public float[] argumentsFloat = new float[0];
        [HideInInspector]
        public ScriptBinderItem[] scriptItems = new ScriptBinderItem[0];
        [HideInInspector]
        public ScriptStateItem[] scriptStatus = new ScriptStateItem[0];

        protected int findItemLabel(string key)
        {
            int iHashCode = key.GetHashCode();
            for(int i = 0; i < scriptItems.Length; ++i)
            {
                if(iHashCode == scriptItems[i].iHashCode)
                {
                    return i;
                }
            }
            return -1;
        }

        protected int findStatusLabel(string key)
        {
            int iHashCode = key.GetHashCode();
            for (int i = 0; i < scriptStatus.Length; ++i)
            {
                if (iHashCode == scriptStatus[i].iHashCode)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SetText(string key,string value)
        {
            var find = findItemLabel(key);
            if (find >= 0 && find < scriptItems.Length)
            {
                var text = scriptItems[find].component as Text;
                if(null != text)
                {
                    text.text = value;
                    return;
                }
            }

            LogManager.Instance().LogErrorFormat("ComScriptBinder SetText label = {0} error !!!", key);
        }

        public void _SetAction(string key)
        {
            var find = findStatusLabel(key);
            if(find >= 0 && find < scriptStatus.Length)
            {
                if(null != scriptStatus[find].action)
                {
                    scriptStatus[find].action.Invoke();
                    return;
                }
            }

            LogManager.Instance().LogErrorFormat("ComScriptBinder SetAction label = {0} is failed!!!", key);
        }

        public void SetText(string key, int argumentsIndex)
        {
            if(argumentsIndex >= 0 && argumentsIndex < argumentsString.Length)
            {
                SetText(key, argumentsString[argumentsIndex]);
                return;
            }
            LogManager.Instance().LogErrorFormat("ComScriptBinder SetText argumentsIndex = {0} is out of range !!!", argumentsIndex);
        }

        public void SetImage(string key, string value)
        {
            var find = findItemLabel(key);
            if (find >= 0 && find < scriptItems.Length)
            {
                var image = scriptItems[find].component as Image;
                if(null != image)
                {
                    image.sprite = AssetLoader.Instance().LoadRes(value, typeof(Sprite)).obj as Sprite;
                    return;
                }
            }
            LogManager.Instance().LogErrorFormat("ComScriptBinder SetImage label = {0} error !!!", key);
        }

        public void SetImage(string key, int argumentsIndex)
        {
            if (argumentsIndex >= 0 && argumentsIndex < argumentsString.Length)
            {
                SetImage(key, argumentsString[argumentsIndex]);
                return;
            }
            LogManager.Instance().LogErrorFormat("ComScriptBinder SetText argumentsIndex = {0} is out of range !!!", argumentsIndex);
        }

        public T GetScript<T>(string key) where T : Component
        {
            var find = findItemLabel(key);
            if (find >= 0 && find < scriptItems.Length)
            {
                return scriptItems[find].component as T;
            }

            LogManager.Instance().LogErrorFormat("ComScriptBinder GetScript label = {0} error !!!", key);
            return null;
        }

        public UnityEngine.Object GetObject(string key)
        {
            var find = findItemLabel(key);
            if (find >= 0 && find < scriptItems.Length)
            {
                return scriptItems[find].component;
            }
            return null;
        }
        public int GetIntArgv(int index)
        {
            if (index >= 0 && index < argumentsInt.Length)
            {
                return argumentsInt[index];
            }

            LogManager.Instance().LogErrorFormat("GetIntArgv index ={0} is out of range len = {1}!", index, argumentsInt.Length);
            return 0;
        }

        public string GetStringArgv(int index)
        {
            if (index >= 0 && index < argumentsString.Length)
            {
                return argumentsString[index];
            }

            LogManager.Instance().LogErrorFormat("GetStringArgv index = {0} is out of range len = {1}!", index, argumentsString.Length);
            return string.Empty;
        }

        public float GetFloatArgv(int index)
        {
            if (index >= 0 && index < argumentsFloat.Length)
            {
                return argumentsFloat[index];
            }

            LogManager.Instance().LogErrorFormat("GetFloatArgv index = {0} is out of range len = {1}!",index, argumentsFloat.Length);
            return 0.0f;
        }

        List<KeyValuePair<ClientEvent, System.Action<object>>> mRegistertedEvents = null;
        public void RegisterEvent(ClientEvent id, System.Action<object> handle)
        {
            if(null == mRegistertedEvents)
            {
                mRegistertedEvents = new List<KeyValuePair<ClientEvent, System.Action<object>>>(16);
            }
            EventManager.Instance().RegisterEvent(id, handle);
            mRegistertedEvents.Add(new KeyValuePair<ClientEvent, System.Action<object>>(id,handle));
        }

        public void UnRegisterEvent(ClientEvent id, System.Action<object> handle)
        {
            if(null != mRegistertedEvents)
            {
                for (int i = 0; i < mRegistertedEvents.Count; ++i)
                {
                    if(id == mRegistertedEvents[i].Key && handle == mRegistertedEvents[i].Value)
                    {
                        EventManager.Instance().UnRegisterEvent(id, handle);
                        mRegistertedEvents.RemoveAt(i--);
                        break;
                    }
                }
            }
        }

        public void RegisterButtonEvent(string key, UnityAction callback)
        {
            Button button = GetObject(key) as Button;
            if(null != button && null != callback)
            {
                button.onClick.AddListener(callback);
            }
        }

        public void UnRegisterButtonEvent(string key, UnityAction callback)
        {
            Button button = GetObject(key) as Button;
            if (null != button && null != callback)
            {
                button.onClick.RemoveListener(callback);
            }
        }

        public void RegisterToggleEvent(string key, UnityAction<bool> callback)
        {
            Toggle toggle = GetObject(key) as Toggle;
            if(null != toggle)
            {
                toggle.onValueChanged.AddListener(callback);
            }
        }

        public void UnRegisterToggleEvent(string key, UnityAction<bool> callback)
        {
            Toggle toggle = GetObject(key) as Toggle;
            if (null != toggle)
            {
                toggle.onValueChanged.RemoveListener(callback);
            }
        }

        public void OnClickLinkInfo(string argv)
        {
            if(!string.IsNullOrEmpty(argv))
            {
                //ActiveManager.GetInstance().OnClickLinkInfo(argv);
            }
        }

        void OnDestroy()
        {
            if(null != mRegistertedEvents)
            {
                for (int i = 0; i < mRegistertedEvents.Count; ++i)
                {
                    EventManager.Instance().UnRegisterEvent(mRegistertedEvents[i].Key, mRegistertedEvents[i].Value);
                }
                mRegistertedEvents.Clear();
            }

            for(int i = 0; i < scriptItems.Length; ++i)
            {
                var scriptItem = scriptItems[i];
                if(null != scriptItem)
                {
                    if(scriptItem.component is Button)
                    {
                        (scriptItem.component as Button).onClick.RemoveAllListeners();
                    }
                    else if(scriptItem.component is Toggle)
                    {
                        (scriptItem.component as Toggle).onValueChanged.RemoveAllListeners();
                    }
                }
                scriptItems[i] = null;
            }
        }
    }
}