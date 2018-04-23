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
        public int msgId = -1;
        public string title = string.Empty;
        public string ok = string.Empty;
        public string cancel = string.Empty;
        public string desc = string.Empty;
        public OnClickMessageBoxOK cbOk = null;
        public OnClickMessageBoxCancel cbCancel = null;
        public object[] argvs = null;
    }

    [LuaCallCSharp]
    public class MessageBoxFrame : ClientFrame
    {
        static string ms_empty = "-";
        public static void Open(OnClickMessageBoxOK onOk, OnClickMessageBoxCancel onCancel, int messageId, int frameTypeId = 6, int frameId = -1,object[] argvs = null)
        {
            var messageTable = TableManager.Instance().GetTableItem<ProtoTable.CommonMessageTable>(messageId);
            if(null != messageTable)
            {
                MessageBoxFrameData data = new MessageBoxFrameData
                {
                    msgId = messageId,
                    title = messageTable.TitleText,
                    ok = messageTable.OkText,
                    cancel = messageTable.CancelText,
                    desc = messageTable.Descs,
                    cbOk = onOk,
                    cbCancel = onCancel,
                    argvs = argvs,
                };
                UIManager.Instance().OpenFrame<MessageBoxFrame>(frameTypeId, data, frameId);
            }
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
                    if(null != data.argvs && data.argvs.Length > 0 && null != data.argvs[0])
                    {
                        var messageItem = TableManager.Instance().GetTableItem<ProtoTable.CommonMessageTable>(data.msgId);
                        if(null != messageItem)
                        {
                            mDesc.text = string.Format(messageItem.Descs, data.argvs[0]);
                        }
                        else
                        {
                            mDesc.text = data.desc;
                        }
                    }
                    else
                    {
                        mDesc.text = data.desc;
                    }
                }
                if(null != mOkText)
                {
                    mOkText.text = data.ok;
                    mgoOK.CustomActive(_IsValidContent(data.ok));
                }
                if(null != mCancelText)
                {
                    mCancelText.text = data.cancel;
                    mgoCancel.CustomActive(_IsValidContent(data.cancel));
                }
                if(null != mTitleText)
                {
                    mTitleText.text = data.title;
                    mgoTitle.CustomActive(_IsValidContent(data.title));
                }
            }
        }

        bool _IsValidContent(string content)
        {
            return !string.IsNullOrEmpty(content) && !content.Equals(ms_empty);
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
            data.argvs = null;
            data = null;
        }
    }
}