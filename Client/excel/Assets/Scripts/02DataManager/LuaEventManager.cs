using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;

namespace GameClient
{
    [CSharpCallLua]
    public delegate void LuaEvent(object argv);
    [LuaCallCSharp]
    public class LuaEventManager : Singleton<LuaEventManager>
    {
        const int event_max = 256;
        LuaEvent[] mLuaEventsDic = new LuaEvent[event_max];

        private bool OnHandlerAdding(int eventId, LuaEvent handler)
        {
            bool flag = true;
            Delegate delegate2 = this.mLuaEventsDic[eventId - 1];
            if (null == handler || (delegate2 != null) && (delegate2.GetType() != handler.GetType()))
            {
                flag = false;
            }
            return flag;
        }

        private bool OnHandlerRemoving(int eventId, LuaEvent handler)
        {
            bool flag = true;
            if (null != this.mLuaEventsDic[eventId - 1] && null != handler)
            {
                Delegate delegate2 = this.mLuaEventsDic[eventId - 1];
                return ((delegate2 != null) && ((delegate2.GetType() == handler.GetType()) && flag));
            }
            return false;
        }

        private bool OnBroadCasting(int eventId)
        {
            return null != this.mLuaEventsDic[eventId - 1];
        }

        public void RegisterEvent(int eventId, LuaEvent handler)
        {
            if(eventId < 1 || eventId > event_max)
            {
                LogManager.Instance().LogErrorFormat("reg lua event error, id must in range 1 to {0}", event_max);
                return;
            }

            if(OnHandlerAdding(eventId,handler))
            {
                mLuaEventsDic[eventId - 1] = (LuaEvent)Delegate.Combine((LuaEvent)this.mLuaEventsDic[eventId - 1], handler);
            }
        }

        public void UnRegisterEvent(int eventId, LuaEvent handler)
        {
            if (eventId < 1 || eventId > event_max)
            {
                LogManager.Instance().LogErrorFormat("reg lua event error, id must in range 1 to {0}", event_max);
                return;
            }

            if(this.OnHandlerRemoving(eventId, handler))
            {
                this.mLuaEventsDic[eventId - 1] = (LuaEvent)Delegate.Remove((LuaEvent)this.mLuaEventsDic[eventId - 1], handler);
                UnityEngine.Debug.LogErrorFormat("handles.Remove succeed !!");
            }
        }

        public void SendEvent(int eventId,object argv)
        {
            if (eventId < 1 || eventId > event_max)
            {
                LogManager.Instance().LogErrorFormat("reg lua event error, id must in range 1 to {0}", event_max);
                return;
            }

            if (this.OnBroadCasting(eventId))
            {
                LuaEvent action = this.mLuaEventsDic[eventId - 1] as LuaEvent;
                if (action != null)
                {
                    action.Invoke(argv);
                }
            }
        }
    }
}