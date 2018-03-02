using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetWork;

namespace GameClient
{
    public class LogSocket : MonoBehaviour
    {
        public string ip;
        public short port;
        public bool bStart = false;

        NetSocket socket = new NetSocket("LogSocket", "127.0.0.1",8864);

        bool locked = false;
        Object printLogLock = new Object();
        int recycleCount = 0;
        Object ansyRecycleLogItemLock = new Object();

        void _PrintLogItems()
        {
            var logItems = LogManager.Instance().GetLogItems();
            if (logItems.Count <= 0 || locked)
            {
                return;
            }

            lock (printLogLock)
            {
                locked = true;
            }
            var content = logItems[0].ToLogValue();
            socket.Send(content, _OnPrintOK, _OnPrintFailed);

            Utility.LogToScreen("_PrintLogItems send {0}", content);
        }

        void _OnPrintOK()
        {
            lock (printLogLock)
            {
                locked = false;
            }

            lock(ansyRecycleLogItemLock)
            {
                ++recycleCount;
            }
        }

        void _OnPrintFailed()
        {
            lock (printLogLock)
            {
                locked = false;
            }
        }

        void Awake()
        {
            EventManager.Instance().RegisterEvent(ClientEvent.CE_ON_LOGIN_FRAME_OPENED, _OnLoginFrameOpened);
        }

        // Update is called once per frame
        void Update()
        {
            if(bStart)
            {
                socket.ip = this.ip;
                socket.port = this.port;

                socket.Update();

                if (socket.connected)
                {
                    _PrintLogItems();
                }
            }

            if(recycleCount > 0)
            {
                lock(ansyRecycleLogItemLock)
                {
                    while(recycleCount > 0)
                    {
                        LogManager.Instance().RecycleFirstLogItem();
                        --recycleCount;
                    }
                }
            }
        }

        void OnDestroy()
        {
            if(null != socket)
            {
                socket.Close();
            }
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_ON_LOGIN_FRAME_OPENED, _OnLoginFrameOpened);
        }

        void _OnLoginFrameOpened(object argv)
        {
            this.ip = argv as string;
            UnityEngine.Debug.LogFormat("<color=#00ff00>_OnLoginFrameOpened !!</color>");
            bStart = true;
        }
    }
}