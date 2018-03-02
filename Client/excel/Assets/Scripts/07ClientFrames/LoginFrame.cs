using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.UI;

namespace GameClient
{
    public class LoginFrame : ClientFrame
    {
        const int Invoke_Fly = 1000;
        const int Invoke_Fly_Repeated = 1001;
        List<string> mValues = new List<string>(32);
        Scripts.UI.ComUIListScript mItemListScript;
        UnityEngine.UI.Button mbtnClose;
        UnityEngine.UI.Button mPlaySound;
        UnityEngine.UI.Button mBtnConnectLog;
        UnityEngine.UI.InputField mInputFiled;

        protected override void _InitScriptBinder()
        {
            mItemListScript = mScriptBinder.GetObject("ItemListScript") as Scripts.UI.ComUIListScript;
            mbtnClose = mScriptBinder.GetObject("btnClose") as UnityEngine.UI.Button;
            mPlaySound = mScriptBinder.GetObject("PlaySound") as UnityEngine.UI.Button;
            mBtnConnectLog = mScriptBinder.GetObject("BtnConnectLog") as UnityEngine.UI.Button;
            mInputFiled = mScriptBinder.GetObject("InputFiled") as UnityEngine.UI.InputField;
        }

        protected override void _OnOpenFrame()
        {
            if(null != mPlaySound)
            {
                mPlaySound.onClick.AddListener(_OnClickPlaySound);
            }

            if(null != mbtnClose)
            {
                mbtnClose.onClick.AddListener(_OnClickCloseFrame);
            }

            if(null != mBtnConnectLog)
            {
                mBtnConnectLog.onClick.AddListener(() =>
                {
                    string value = string.Empty;
                    if(null != mInputFiled)
                    {
                        value = mInputFiled.text;
                    }
                    EventManager.Instance().SendEvent(ClientEvent.CE_ON_LOGIN_FRAME_OPENED,value);
                });
            }

            RegisterEvent(ClientEvent.CE_LOGIN_TEST, _OnLoginTest);
            RegisterEvent(ClientEvent.CE_LOG_TO_SCREEN, _OnLogEvent);

            _InitItemListScript();
            _UpdateItems();

            mScriptBinder.SetAction("lose");
        }

        void _InitItemListScript()
        {
            if (null != mScriptBinder)
            {
                mItemListScript = mScriptBinder.GetObject("ItemListScript") as Scripts.UI.ComUIListScript;
                if (null != mItemListScript)
                {
                    mItemListScript.Initialize();

                    mItemListScript.onBindItem = (GameObject go) =>
                    {
                        if (null != go)
                        {
                            return go.GetComponent<ComItem>();
                        }
                        return null;
                    };

                    mItemListScript.onItemVisiable = (ComUIListElementScript element) =>
                    {
                        if (null != element && element.m_index >= 0 && element.m_index < mValues.Count)
                        {
                            var script = element.gameObjectBindScript as ComItem;
                            if (null != script)
                            {
                                script.OnItemVisible(mValues[element.m_index]);
                            }
                        }
                    };
                }
            }
        }

        void _UpdateItems()
        {
            if(null != mItemListScript)
            {
                mItemListScript.SetElementAmount(mValues.Count);
            }
        }

        protected void _OnLoginTest(object param)
        {
            LogManager.Instance().LogFormat("on recv loginTest !!!");
        }

        protected void _OnLogEvent(object param)
        {
            mValues.Add(param as string);
            _UpdateItems();
        }

        protected void _OnClickCloseFrame()
        {
            UIManager.Instance().CloseFrame(this);
            Application.Quit();
        }

        protected void _OnClickPlaySound()
        {
            AudioManager.Instance().PlaySound(1001);
        }

        protected override void _OnCloseFrame()
        {
            if(null != mItemListScript)
            {
                mItemListScript.onBindItem = null;
                mItemListScript.onItemVisiable = null;
                mItemListScript = null;
            }
        }
    }
}