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

        NetSocket socket = new NetSocket("LogSocket", "127.0.0.1",8864,5,null,null,null,null);

        bool locked = false;
        int recycleCount = 0;
        Object ansyRecycleLogItemLock = new Object();

        void _OnSocketLogOut(string log)
        {
            LogManager.Instance().LogProcessFormat(9850, log);
            UnityEngine.Debug.LogErrorFormat("<color=#00ff00>{0}:{1}</color>", 9850, log);
        }

        void _PrintLogItems()
        {
            var logItems = LogManager.Instance().GetLogItems();
            if (logItems.Count <= 0 || locked)
            {
                return;
            }

            locked = true;
            var content = logItems[0].ToLogValue();
            var bytes = System.Text.Encoding.ASCII.GetBytes(content);

            socket.Send(bytes, () => { ++recycleCount; locked = false; }, ()=> { locked = false; });

            Utility.LogToScreen("_PrintLogItems send {0}", content);
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
                socket.onSocketLogOut = _OnSocketLogOut;

                socket.Update();

                if (socket.connected)
                {
                    _PrintLogItems();
                }
            }

            while (recycleCount > 0)
            {
                LogManager.Instance().RecycleFirstLogItem();
                --recycleCount;
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
            socket.Send(System.Text.Encoding.ASCII.GetBytes("Fuck your mother"), null,null);
            bStart = true;
        }
    }
}