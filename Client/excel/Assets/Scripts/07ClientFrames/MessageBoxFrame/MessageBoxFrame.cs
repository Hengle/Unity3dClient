using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [CSharpCallLua]
    public delegate void OnClickMessageBoxOK();
    [CSharpCallLua]
    public delegate void OnClickMessageBoxCancel();

    class MessageBoxFrameData
    {
        public int iId = -1;
        public string title = string.Empty;
        public string ok = string.Empty;
        public string cancel = string.Empty;
        public string desc = string.Empty;
        public OnClickMessageBoxOK cbOk = null;
        public OnClickMessageBoxCancel cbCancel = null;
    }

    [LuaCallCSharp]
    public class MessageBoxFrame : ClientFrame
    {
        public static string FormatMessage(int iId,params object[] objs)
        {
            return string.Empty;
        }

        public static void Open(OnClickMessageBoxOK onOk, OnClickMessageBoxCancel onCancel, string title, string desc,string ok, string cancel, int frameId = -1,int msgId = 6)
        {
            MessageBoxFrameData data = new MessageBoxFrameData
            {
                iId = frameId,
                title = title,
                ok = ok,
                cancel = cancel,
                cbOk = onOk,
                cbCancel = onCancel,
                desc = desc,
            };
            UIManager.Instance().OpenFrame<MessageBoxFrame>(msgId, data, frameId);
        }

        MessageBoxFrameData data = null;

        UnityEngine.UI.Button mbtnOK;
        UnityEngine.UI.Button mbtnCancel;
        UnityEngine.UI.Button mbtnClose;
        UnityEngine.UI.Text mDesc;
        UnityEngine.UI.Text mOkText;
        UnityEngine.UI.Text mCancelText;
        UnityEngine.UI.Text mTitleText;
        UnityEngine.GameObject mgoOK;
        UnityEngine.GameObject mgoCancel;
        UnityEngine.GameObject mgoTitle;

        protected override void _InitScriptBinder()
        {
            mbtnOK = mScriptBinder.GetObject("btnOK") as UnityEngine.UI.Button;
            mbtnCancel = mScriptBinder.GetObject("btnCancel") as UnityEngine.UI.Button;
            mbtnClose = mScriptBinder.GetObject("btnClose") as UnityEngine.UI.Button;
            mDesc = mScriptBinder.GetObject("Desc") as UnityEngine.UI.Text;
            mOkText = mScriptBinder.GetObject("OkText") as UnityEngine.UI.Text;
            mCancelText = mScriptBinder.GetObject("CancelText") as UnityEngine.UI.Text;
            mTitleText = mScriptBinder.GetObject("TitleText") as UnityEngine.UI.Text;
            mgoOK = mScriptBinder.GetObject("goOK") as UnityEngine.GameObject;
            mgoCancel = mScriptBinder.GetObject("goCancel") as UnityEngine.GameObject;
            mgoTitle = mScriptBinder.GetObject("goTitle") as UnityEngine.GameObject;
        }

        protected override void _OnOpenFrame()
        {
            data = userData as MessageBoxFrameData;
            if (null != mbtnOK)
            {
                mbtnOK.onClick.AddListener(_OnOK);
            }
            if (null != mbtnCancel)
            {
                mbtnCancel.onClick.AddListener(_OnCancel);
            }
            if(null != mbtnClose)
            {
                mbtnClose.onClick.AddListener(_OnClose);
            }

            if (null != data)
            {
                if (null != mDesc)
                {
                    mDesc.text = data.desc;
                }
                if(null != mOkText)
                {
                    mOkText.text = data.ok;
                    mgoOK.CustomActive(!string.IsNullOrEmpty(data.ok));
                }
                if(null != mCancelText)
                {
                    mCancelText.text = data.cancel;
                    mgoCancel.CustomActive(!string.IsNullOrEmpty(data.cancel));
                }
                if(null != mTitleText)
                {
                    mTitleText.text = data.title;
                    mgoTitle.CustomActive(!string.IsNullOrEmpty(data.title));
                }
            }
        }

        void _OnOK()
        {
            if(null != data && null != data.cbOk)
            {
                data.cbOk.Invoke();
            }
            UIManager.Instance().CloseFrame(this);
        }

        void _OnCancel()
        {
            if (null != data && null != data.cbCancel)
            {
                data.cbCancel.Invoke();
            }
            UIManager.Instance().CloseFrame(this);
        }

        void _OnClose()
        {
            UIManager.Instance().CloseFrame(this);
        }

        protected override void _OnCloseFrame()
        {
            data = null;
        }
    }
}