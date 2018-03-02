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

        class NetSocket
        {
            const float delay = 5.0f;
            SocketStatus eSocketStatus = SocketStatus.SS_INVALID;
            Socket socket;
            bool bFirst = true;
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

            enum SocketStatus
            {
                SS_INVALID = -1,
                SS_CONNECTING,
                SS_CONNECTED,
                SS_RECONNECT,
                SS_DISCONNECTED,
            }

            public bool connected
            {
                get
                {
                    return eSocketStatus == SocketStatus.SS_CONNECTED && null != socket && socket.Connected;
                }
            }

            public bool connecting
            {
                get
                {
                    return eSocketStatus == SocketStatus.SS_CONNECTING;
                }
            }

            public bool disconnected
            {
                get
                {
                    return eSocketStatus == SocketStatus.SS_DISCONNECTED;
                }
            }

            public bool firstConnected
            {
                get
                {
                    return eSocketStatus == SocketStatus.SS_INVALID;
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
                    socket.BeginConnect(ip_end_point, new System.AsyncCallback(OnConnected), socket);
                }
                catch
                {
                    TryReconnect();
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
                }
            }

            void OnConnected(System.IAsyncResult iar)
            {
                Socket client = (Socket)iar.AsyncState;
                try
                {
                    client.EndConnect(iar);
                    eSocketStatus = SocketStatus.SS_CONNECTED;
                    reconnectTimes = 0;
                    if (null != this.onConnectSucceed)
                    {
                        this.onConnectSucceed(this.param);
                    }
                    bFirst = false;
                    this.onConnectSucceed = null;
                    this.onConnectFailed = null;

                    UnityEngine.Debug.LogFormat("<color=#00ff00>connect logserver succeed !!</color>");
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogErrorFormat(e.ToString());
                    TryReconnect();
                }
                finally
                {

                }
            }

            public void Close()
            {
                if(null != socket)
                {
                    if(firstConnected)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                }
                this.onConnectSucceed = null;
                this.onConnectFailed = null;
                eSocketStatus = SocketStatus.SS_DISCONNECTED;
                time = -1.0f;
                if(null != socket)
                {
                    socket.Close();
                }
            }

            public void Send(string data,UnityEngine.Events.UnityAction ok, UnityEngine.Events.UnityAction failed)
            {
                if(null != socket && socket.Connected)
                {
                    // Convert the string data to byte data using ASCII encoding.     
                    byte[] byteData = System.Text.Encoding.ASCII.GetBytes(data);
                    // Begin sending the data to the remote device.     
                    //socket.Send(byteData);
                    socket.BeginSend(byteData, 0, byteData.Length, 0, new System.AsyncCallback(SendCallback),new object[] {ok,failed });
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
                }
                catch (System.Exception e)
                {
                    if(!socket.Connected)
                    {
                        TryReconnect();
                    }
                    else
                    {
                        Close();
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

        void _PrintLogItems()
        {
            var logItems = LogManager.Instance().GetLogItems();
            if (logItems.Count <= 0 || locked)
            {
                return;
            }

            locked = true;
            var content = logItems[0].ToLogValue();
            socket.Send(content, _OnPrintOK, _OnPrintFailed);
        }

        void _OnPrintOK()
        {
            locked = false;
            LogManager.Instance().RecycleFirstLogItem();
        }

        void _OnPrintFailed()
        {
            locked = false;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (socket.disconnected)
            {
                return;
            }

            if (!socket.connected)
            {
                if (!socket.connecting)
                {
                    if(Time.time > socket.nextReconnectTime)
                    {
                        socket.Connect(ip, port, null, null, null);
                    }
                }
                return;
            }

            _PrintLogItems();
        }

        void OnDestroy()
        {
            if(null != socket)
            {
                socket.Close();
            }
        }
    }
}