using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;

namespace GameClient
{
    [CSharpCallLua]
    public delegate void LuaSocketEvent(object data);

    class SocketEventManager
    {
        Dictionary<int, LuaSocketEvent> mEventDispatcher = new Dictionary<int, LuaSocketEvent>();
        public void RegisterEvent(int eventId, LuaSocketEvent handler)
        {
            if(null != handler)
            {
                mEventDispatcher[eventId] = (LuaSocketEvent)Delegate.Remove((LuaSocketEvent)mEventDispatcher[eventId], handler);
                mEventDispatcher[eventId] = (LuaSocketEvent)Delegate.Combine((LuaSocketEvent)mEventDispatcher[eventId], handler);
                LogManager.Instance().LogFormat("<color=#00ff00>reg net socket event {0} succeed !</color>", eventId);
            }
        }

        public void UnRegisterEvent(int eventId, LuaSocketEvent handler)
        {
            if(mEventDispatcher.ContainsKey(eventId))
            {
                mEventDispatcher[eventId] = (LuaSocketEvent)Delegate.Remove((LuaSocketEvent)mEventDispatcher[eventId], handler);
                LogManager.Instance().LogFormat("<color=#00ff00>un reg net socket event {0} succeed !</color>", eventId);
            }
        }

        public void RemoveAllEvent()
        {
            mEventDispatcher.Clear();
        }

        public void SendEvent(int eventId, object argv)
        {
            if (mEventDispatcher.ContainsKey(eventId))
            {
                var action = mEventDispatcher[eventId];
                if(null != action)
                {
                    action.Invoke(argv);
                }
            }
        }
    }

    [LuaCallCSharp]
    public class LuaSocketEventManager : Singleton<LuaSocketEventManager>
    {
        Dictionary<int, SocketEventManager> socketMgr = new Dictionary<int, SocketEventManager>();

        [LuaCallCSharp]
        public void RegisterEvent(object socket,int eventId, LuaSocketEvent handler)
        {
            if(null != socket)
            {
                int hash = socket.GetHashCode();
                if(!socketMgr.ContainsKey(hash))
                {
                    socketMgr.Add(hash, new SocketEventManager());
                }
                SocketEventManager dispatcher = socketMgr[hash];
                dispatcher.RegisterEvent(eventId, handler);
            }
        }

        [LuaCallCSharp]
        public void UnRegisterEvent(object socket,int eventId, LuaSocketEvent handler)
        {
            if (null != socket)
            {
                int hash = socket.GetHashCode();
                if (socketMgr.ContainsKey(hash))
                {
                    socketMgr[hash].UnRegisterEvent(eventId, handler);
                }
            }
        }

        [LuaCallCSharp]
        public void UnRegisterSocketEvent(object socket)
        {
            if (null != socket)
            {
                int hash = socket.GetHashCode();
                if (socketMgr.ContainsKey(hash))
                {
                    socketMgr[hash].RemoveAllEvent();
                    socketMgr.Remove(hash);
                }
            }
        }

        [LuaCallCSharp]
        public void Clear()
        {
            socketMgr.Clear();
        }
    }
}