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

        public static void Open(OnClickMessageBoxOK onOk, OnClickMessageBoxCancel onCancel, string title, string ok, string cancel, int frameId = -1,int msgId = 6)
        {
            MessageBoxFrameData data = new MessageBoxFrameData
            {
                iId = frameId,
                title = title,
                ok = ok,
                cancel = cancel,
                cbOk = onOk,
                cbCancel = onCancel,
            };
            UIManager.Instance().OpenFrame<MessageBoxFrame>(msgId, data, frameId);
        }
    }
}