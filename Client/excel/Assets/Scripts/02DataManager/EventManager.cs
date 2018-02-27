using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    class EventManager : Singleton<EventManager>
    {
        protected EventRouter<ClientEvent> eventRouter = new EventRouter<ClientEvent>();

        public void RegisterEvent(ClientEvent ce,System.Action<object> handler)
        {
            eventRouter.AddEventHandler(ce, handler);
        }

        public void UnRegisterEvent(ClientEvent ce, System.Action<object> handler)
        {
            eventRouter.RemoveEventHandler(ce, handler);
        }

        public void SendEvent(ClientEvent ce,object param)
        {
            eventRouter.BroadCastEvent(ce, param);
        }
    }
}