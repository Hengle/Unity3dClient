using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.Net.Sockets;

namespace GameClient
{
    public class LogSocket : MonoBehaviour
    {
        public string ip;
        public short port;
        public bool bStart = false;

        class NetSocket
        {
            const float delay = 5.0f;
            SocketStatus eSocketStatus = SocketStatus.SS_INVALID;
            public SocketStatus EStatus
            {
                get
                {
                    return eSocketStatus;
                }
            }
            Socket socket;
            int reconnectTimes = 5;
            float time = -1.0f;
            public float nextReconnectTime
            {
                get
                {
                    return time;
                }
            }

            UnityEngine.Events.UnityAction<object> onConnectSucceed;
            UnityEngine.Events.UnityAction<object> onConnectFailed;
            object param = null;

            public enum SocketStatus
            {
                SS_INVALID = -1,
                SS_CONNECTING,
                SS_CONNECTED,
                SS_RECONNECT,
                SS_DISCONNECTED,

                SS_TRYCONNECT,
                SS_TRYCONNECTED,
                SS_TRYDISCONNECTED,
            }

            public bool connected
            {
                get
                {
                    return eSocketStatus == SocketStatus.SS_CONNECTED && null != socket && socket.Connected;
                }
            }

            public bool Connect(string ip,short port, UnityEngine.Events.UnityAction<object> onConnectSucceed, UnityEngine.Events.UnityAction<object> onConnectFailed,object param = null)
            {
                try
                {
                    this.onConnectSucceed = onConnectSucceed;
                    this.onConnectFailed = onConnectFailed;
                    this.param = param;
                    IPAddress ipAddr = IPAddress.Parse(ip);
                    IPEndPoint ip_end_point = new IPEndPoint(ipAddr, port);
                    if(null == socket)
                    {
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    }
                    eSocketStatus = SocketStatus.SS_CONNECTING;

                    LogToScreen("LogSocket BeginConnect {0} {1}", ip, port);
                    socket.BeginConnect(ip_end_point, new System.AsyncCallback(OnConnected), socket);
                }
                catch(System.Exception e)
                {
                    LogToScreen(e.ToString());
                    eSocketStatus = SocketStatus.SS_TRYCONNECT;
                }
                return true;
            }

            public void TryReconnect()
            {
                if (reconnectTimes > 0)
                {
                    --reconnectTimes;
                    eSocketStatus = SocketStatus.SS_RECONNECT;
                    time = Time.time + delay;

                    LogToScreen("LogSocket TryReconnect reconnectTimes = {0}", reconnectTimes);
                }
                else
                {
                    if (null != this.onConnectFailed)
                    {
                        this.onConnectFailed(this.param);
                    }
                    this.onConnectSucceed = null;
                    this.onConnectFailed = null;
                    eSocketStatus = SocketStatus.SS_DISCONNECTED;
                    time = -1.0f;
                    socket.Close();

                    LogToScreen("LogSocket socket closed!!!", reconnectTimes);
                }
            }

            void OnConnected(System.IAsyncResult iar)
            {
                Socket client = (Socket)iar.AsyncState;
                try
                {
                    client.EndConnect(iar);
                    eSocketStatus = SocketStatus.SS_TRYCONNECTED;
                }
                catch (System.Exception e)
                {
                    eSocketStatus = SocketStatus.SS_TRYCONNECT;
                }
                finally
                {

                }
            }

            public void OnConnected()
            {
                LogToScreen("LogSocket socket connect logserver succeed !!");
                eSocketStatus = SocketStatus.SS_CONNECTED;
                reconnectTimes = 0;
                if (null != this.onConnectSucceed)
                {
                    this.onConnectSucceed(this.param);
                }
                this.onConnectSucceed = null;
                this.onConnectFailed = null;
            }

            public void Close()
            {
                if(null != socket)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                this.onConnectSucceed = null;
                this.onConnectFailed = null;
                eSocketStatus = SocketStatus.SS_DISCONNECTED;
                time = -1.0f;
                if(null != socket)
                {
                    socket.Close();
                }
                //LogToScreen("LogSocket closed !!");
            }

            public void Send(string data,UnityEngine.Events.UnityAction ok, UnityEngine.Events.UnityAction failed)
            {
                if (null != socket && socket.Connected)
                {
                    // Convert the string data to byte data using ASCII encoding.     
                    byte[] byteData = System.Text.Encoding.ASCII.GetBytes(data);
                    // Begin sending the data to the remote device.     
                    //socket.Send(byteData);
                    socket.BeginSend(byteData, 0, byteData.Length, 0, new System.AsyncCallback(SendCallback),new object[] {ok,failed });
                    LogToScreen("LogSocket socket BeginSend !! {0} !", data);
                }
                else
                {
                    if(null != failed)
                    {
                        failed.Invoke();
                    }
                }
            }

            void SendCallback(System.IAsyncResult ar)
            {
                object[] callbacks = (object[])ar.AsyncState;
                var ok = callbacks[0] as UnityEngine.Events.UnityAction;
                var failed = callbacks[1] as UnityEngine.Events.UnityAction;

                try
                {
                    // Complete sending the data to the remote device.     
                    int bytesSent = socket.EndSend(ar);
                    if(null != ok)
                    {
                        ok.Invoke();
                    }
                    //LogToScreen("LogSocket socket EndSend succeed !!");
                }
                catch (System.Exception e)
                {
                    //LogToScreen("LogSocket socket SendCallback {0} !!",e.ToString());

                    if (!socket.Connected)
                    {
                        eSocketStatus = SocketStatus.SS_TRYCONNECT;
                    }
                    else
                    {
                        eSocketStatus = SocketStatus.SS_TRYDISCONNECTED;
                    }

                    if(null != failed)
                    {
                        failed.Invoke();
                    }
                }
            }
        }

        NetSocket socket = new NetSocket();
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

            LogToScreen("_PrintLogItems send {0}", content);
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

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(bStart)
            {
                if (socket.EStatus == NetSocket.SocketStatus.SS_DISCONNECTED)
                {
                    return;
                }

                if(socket.EStatus == NetSocket.SocketStatus.SS_TRYCONNECT)
                {
                    socket.TryReconnect();
                }
                else if(socket.EStatus == NetSocket.SocketStatus.SS_TRYCONNECTED)
                {
                    socket.OnConnected();
                }
                else if(socket.EStatus == NetSocket.SocketStatus.SS_RECONNECT)
                {
                    if (Time.time > socket.nextReconnectTime)
                    {
                        socket.Connect(ip, port, null, null, null);
                    }
                }
                else if(socket.EStatus == NetSocket.SocketStatus.SS_INVALID)
                {
                    socket.Connect(ip, port, null, null, null);
                }

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

        public static void LogToScreen(string fmt, params object[] argvs)
        {
            string value = string.Format(fmt, argvs);
            if(!string.IsNullOrEmpty(value))
            {
                EventManager.Instance().SendEvent(ClientEvent.CE_LOG_TO_SCREEN, value);
            }
        }

        void _OnLoginFrameOpened(object argv)
        {
            this.ip = argv as string;
            UnityEngine.Debug.LogFormat("<color=#00ff00>_OnLoginFrameOpened !!</color>");
            bStart = true;
        }
    }
}