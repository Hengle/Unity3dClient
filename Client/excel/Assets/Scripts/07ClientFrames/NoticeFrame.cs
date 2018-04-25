using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public enum NoticeType
    {
        NT_STEP_MSG = 0,
        NT_POP_MSG,
        NT_POP_MSG_IMMEDIATELY,
    }
    [LuaCallCSharp]
    public class NoticeData
    {
        public string content;
        public NoticeType noticeType;
    }

    public class NoticeFrame : ClientFrame
    {
        UnityEngine.UI.Text mStepMsg;
        UnityEngine.UI.Text mPopMsg;
        GameClient.ComPanelFade mpanelFade;
        UnityEngine.GameObject mgoStep;
        UnityEngine.GameObject mgoPop;
        protected override void _InitScriptBinder()
        {
            mStepMsg = mScriptBinder.GetObject("StepMsg") as UnityEngine.UI.Text;
            mPopMsg = mScriptBinder.GetObject("PopMsg") as UnityEngine.UI.Text;
            mpanelFade = mScriptBinder.GetObject("panelFade") as GameClient.ComPanelFade;
            mgoStep = mScriptBinder.GetObject("goStep") as UnityEngine.GameObject;
            mgoPop = mScriptBinder.GetObject("goPop") as UnityEngine.GameObject;
        }

        static List<NoticeData> _recycled = new List<NoticeData>(8);
        List<NoticeData> _systemDatas = new List<NoticeData>(8);
        List<NoticeData> _popMsgDatas = new List<NoticeData>(8);

        [LuaCallCSharp]
        public static void AddSystemNotice(string content, NoticeType eNotice)
        {
            NoticeData data = null;
            if (_recycled.Count > 0)
            {
                data = _recycled[0];
                _recycled.RemoveAt(0);
                data.content = content;
                data.noticeType = eNotice;
            }
            else
            {
                data = new NoticeData { content = content, noticeType = eNotice };
            }

            if(!UIManager.Instance().IsFrameOpen(19,-1))
            {
                UIManager.Instance().OpenFrame<NoticeFrame>(19);
            }

            EventManager.Instance().SendEvent(ClientEvent.CE_NOTICE_MSG, data);
        }

        public override bool needLuaBehavior()
        {
            return false;
        }

        protected override void _OnOpenFrame()
        {
            EventManager.Instance().RegisterEvent(ClientEvent.CE_NOTICE_MSG, _OnNoticeMsg);
        }

        void _OnNoticeMsg(object argv)
        {
            NoticeData data = argv as NoticeData;
            if(null != data)
            {
                if(data.noticeType == NoticeType.NT_STEP_MSG)
                {
                    _systemDatas.Add(data);
                    if(_systemDatas.Count == 1)
                    {
                        _StartStepMsg();
                    }
                }
                else if(data.noticeType == NoticeType.NT_POP_MSG)
                {
                    _popMsgDatas.Add(data);
                    if (_popMsgDatas.Count == 1)
                    {
                        _StartPopMsg();
                    }
                }
                else
                {
                    _popMsgDatas.Insert(0, data);
                    _StartPopMsg();
                }
            }
        }

        void _StartStepMsg()
        {

        }

        void _StartPopMsg()
        {
            if(_popMsgDatas.Count > 0)
            {
                if (null != mPopMsg)
                {
                    mPopMsg.text = _popMsgDatas[0].content;
                }
                _recycled.Add(_popMsgDatas[0]);
                _popMsgDatas.RemoveAt(0);
                if(null != mpanelFade)
                {
                    if(null == mpanelFade.onComplete)
                    {
                        mpanelFade.onComplete = new UnityEngine.Events.UnityEvent();
                    }
                    mpanelFade.onComplete.RemoveListener(_StartPopMsg);
                    mpanelFade.onComplete.AddListener(_StartPopMsg);
                    mgoPop.CustomActive(true);
                    mpanelFade.Play();
                }
            }
            else
            {
                mgoPop.CustomActive(false);
            }
        }

        protected override void _OnCloseFrame()
        {
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_NOTICE_MSG, _OnNoticeMsg);
            _recycled.AddRange(_systemDatas);
            _systemDatas.Clear();
            _recycled.AddRange(_popMsgDatas);
            _popMsgDatas.Clear();
            mStepMsg = null;
            mPopMsg = null;
            mpanelFade = null;
            mgoStep = null;
            mgoPop = null;
        }
    }
}