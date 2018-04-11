using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace NetWork
{
    public delegate void OnConnectedSucceed(object param);
    public delegate void OnConnectedFailed(object param);
    public delegate void OnReconnectedSucceed(object param);
    public delegate void OnSocketLogOut(string log);
    public delegate void SendCallBack();
    public delegate void NetWorkReceiveCallback(bool isDone, int bytesRead, string errInfo);

    public class NetSocket
    {
        public string targetName = string.Empty;
        public string ip;
        public short port;
        public int maxReconnectTimes = 5;
        public OnConnectedSucceed onConnecteSucceed;
        public OnConnectedFailed onConnecteFailed;
        public OnReconnectedSucceed onReconnectedSucceed;
        public OnSocketLogOut onSocketLogOut;
        public object param = null;
        protected NetWorkReceiveCallback recvCB = null;

        protected NetInputBuffer inBuffer = null;
        protected NetOutputBuffer outBuffer = null;

        public NetSocket(string targetName, string ip, short port,
            int maxReconnectTimes = 5,
            OnConnectedSucceed onConnecteSucceed = null,
            OnConnectedFailed onConnecteFailed = null,
            OnReconnectedSucceed onReconnectedSucceed = null,
            OnSocketLogOut onSocketLogOut = null)
        {
            this.targetName = targetName;
            this.ip = ip;
            this.port = port;
            this.onConnecteSucceed = onConnecteSucceed;
            this.onConnecteFailed = onConnecteFailed;
            this.onReconnectedSucceed = onReconnectedSucceed;
            this.onSocketLogOut = onSocketLogOut;
        }

        const float delay = 5.0f;
        SocketStatus eSocketStatus = SocketStatus.SS_INVALID;
        public SocketStatus EStatus
        {
            get
            {
                return eSocketStatus;
            }
            set
            {
                lock(SocketStatusLock)
                {
                    eSocketStatus = value;
                }
            }
        }
        Socket socket;
        List<SendCallBack> mSendCB = new List<SendCallBack>(16);
        
        int reconnectTimes = -1;
        float time = -1.0f;
        public float nextReconnectTime
        {
            get
            {
                return time;
            }
        }

        object SocketStatusLock = new object();

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
                return EStatus == SocketStatus.SS_CONNECTED && null != socket && socket.Connected;
            }
        }

        public bool Connect(string ip, short port)
        {
            try
            {
                if(-1 == reconnectTimes)
                {
                    reconnectTimes = maxReconnectTimes;
                }
                IPAddress ipAddr = IPAddress.Parse(ip);
                IPEndPoint ip_end_point = new IPEndPoint(ipAddr, port);
                if (null != socket)
                {
                    socket.Close();
                }
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                EStatus = SocketStatus.SS_CONNECTING;
                socket.BeginConnect(ip_end_point, new System.AsyncCallback(OnThreadConnected), socket);

                LogPrint("{0} BeginConnect {1} {2}", targetName, ip, port);
            }
            catch (System.Exception e)
            {
                LogPrint(targetName + e.ToString());

                EStatus = SocketStatus.SS_TRYCONNECT;
            }
            return true;
        }

        int mInvokeHandle = -1;
        public void TryReconnect()
        {
            if (reconnectTimes > 0)
            {
                --reconnectTimes;
                EStatus = SocketStatus.SS_RECONNECT;
                time = Time.time + delay;

                LogPrint("{0} TryReconnect reconnectTimes = {1}", targetName, reconnectTimes);
                if(-1 != mInvokeHandle)
                {
                    GameClient.InvokeManager.Instance().RemoveInvoke(mInvokeHandle);
                    mInvokeHandle = -1;
                }
                mInvokeHandle = GameClient.InvokeManager.Instance().InvokeRepeate(this, 0.0f, (int)((0.50f + delay) / 1.0f), 1.0f,
                    null,
                    () =>
                    {
                        float delta = Mathf.Clamp(time - Time.time, 0, delay);
                        LogPrint("{0} TryReconnect will start after {1} seconds !!!", targetName, (int)(0.50f + delta));
                    },
                    ()=>
                    {
                        if (-1 != mInvokeHandle)
                        {
                            GameClient.InvokeManager.Instance().RemoveInvoke(mInvokeHandle);
                            mInvokeHandle = -1;
                        }
                        Connect(ip, port);
                    });
            }
            else
            {
                if (null != this.onConnecteFailed)
                {
                    this.onConnecteFailed(this.param);
                }
                this.onConnecteFailed = null;
                this.onConnecteSucceed = null;
                this.onReconnectedSucceed = null;
                EStatus = SocketStatus.SS_DISCONNECTED;
                time = -1.0f;
                socket.Close();

                LogPrint("{0} socket closed!!!", targetName, reconnectTimes);
            }
        }

        void OnThreadConnected(System.IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                EStatus = SocketStatus.SS_TRYCONNECTED;
            }
            catch (System.Exception e)
            {
                EStatus = SocketStatus.SS_TRYCONNECT;
            }
            finally
            {

            }
        }

        void LogPrint(string format,params object[] argv)
        {
            if (null != onSocketLogOut)
            {
                string log = string.Format(format, argv);
                onSocketLogOut.Invoke(log);
            }
        }

        public void OnConnected()
        {
            LogPrint("{0} socket connect server succeed !!", targetName);
            EStatus = SocketStatus.SS_CONNECTED;
            if(reconnectTimes == maxReconnectTimes)
            {
                if (null != this.onConnecteSucceed)
                {
                    this.onConnecteSucceed(this.param);
                }
            }
            else
            {
                if (null != this.onReconnectedSucceed)
                {
                    this.onReconnectedSucceed(this.param);
                }
            }
            reconnectTimes = maxReconnectTimes;
        }

        public void Close()
        {
            if (null != socket)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            this.onConnecteSucceed = null;
            this.onConnecteFailed = null;
            this.onReconnectedSucceed = null;
            EStatus = SocketStatus.SS_DISCONNECTED;
            time = -1.0f;
            if (null != socket)
            {
                socket.Close();
            }
            if (-1 != mInvokeHandle)
            {
                GameClient.InvokeManager.Instance().RemoveInvoke(mInvokeHandle);
                mInvokeHandle = -1;
            }
        }

        public void Send(byte[] bytes, SendCallBack ok = null, SendCallBack failed = null)
        {
            if (null != socket && socket.Connected)
            {
                socket.BeginSend(bytes, 0, bytes.Length, 0, new System.AsyncCallback(OnThreadSendSucceed), new object[] { ok, failed });
            }
            else
            {
                if (null != failed)
                {
                    failed.Invoke();
                }
            }
        }

        void OnThreadSendSucceed(System.IAsyncResult ar)
        {
            object[] callbacks = (object[])ar.AsyncState;
            var ok = callbacks[0] as SendCallBack;
            var failed = callbacks[1] as SendCallBack;

            try
            {
                // Complete sending the data to the remote device.     
                int bytesSent = socket.EndSend(ar);
                if (null != ok)
                {
                    lock(mSendCB)
                    {
                        mSendCB.Add(ok);
                    }
                }
            }
            catch (System.Exception e)
            {
                if (!socket.Connected)
                {
                    EStatus = SocketStatus.SS_TRYCONNECT;
                }
                else
                {
                    EStatus = SocketStatus.SS_TRYDISCONNECTED;
                }

                if (null != failed)
                {
                    lock (mSendCB)
                    {
                        mSendCB.Add(failed);
                    }
                }
            }
        }

        private void ReceiveCallback(System.IAsyncResult ar)
        {
            try
            {
                if (socket == null)
                {
                    //NetManager.Instance().Log("{0} NetworkBase ReceiveCallback: Socket is not created.", serverType);
                    if (recvCB != null)
                    {
                        recvCB(false, -1, "NetworkBase ReceiveCallback: Socket is not created.");
                    }
                    return;
                }

                if (eSocketStatus != SocketStatus.SS_DISCONNECTED)
                {
                    //NetManager.Instance().Log("{0} NetworkBase ReceiveCallback: invalid netStatus {1}.", serverType, netStatus);
                    if (recvCB != null)
                    {
                        recvCB(false, -1, "NetworkBase ReceiveCallback: netStatus is not CONNECT_SUCESS.");
                    }
                    return;
                }

                //收消息的
                SocketError errCode = SocketError.Success;
                int bytesRead = socket.EndReceive(ar, out errCode);

                if (errCode != SocketError.Success)
                {
                    //Logger.LogForNet("socket recv error: {0}", errCode);
                }

                if (errCode != SocketError.Success && errCode != SocketError.WouldBlock && errCode != SocketError.TryAgain && errCode != SocketError.Interrupted)
                {
                    //NetManager.Instance().Log("Error while receive data from server. Error Code: " + errCode);
                    throw new Exception("Connect Failed");
                }

                //具体如何收取数据交给回调函数处理
                if (recvCB != null)
                {
                    recvCB(true, bytesRead, "NetworkBase ReceiveCallback: netStatus is not CONNECT_SUCESS.");
                }
            }
            catch (Exception e)
            {
                //Logger.Log("NetworkBase ReceiveCallback Exception: Connect is shutdown.");
                if (recvCB != null)
                {
                    recvCB(false, -1, "NetworkBase ReceiveCallback Exception: Connect is shutdown.");
                }
                //ShutDown() ;
            }
        }

        public void Receive(byte[] byteData, int offset, int size, NetWorkReceiveCallback cb = null)
        {
            recvCB = cb;
            
            try
            {
                if (socket == null)
                {
                    //NetManager.Instance().Log("{0} NetworkBase Receive: Socket is not created.", serverType);
                    if (recvCB != null)
                    {
                        recvCB(false, -1, "Network Receive: Socket is not created.");
                    }
                    return;
                }

                if (eSocketStatus != SocketStatus.SS_DISCONNECTED)
                {
                    //NetManager.Instance().Log("{0} NetworkBase Receive: netStatus is not CONNECT_SUCESS.", serverType);
                    if (recvCB != null)
                    {
                        recvCB(false, -1, "NetworkBase Receive: netStatus is not CONNECT_SUCESS.");
                    }
                    return;
                }

                socket.BeginReceive(byteData, offset, size, SocketFlags.None,
                                   new System.AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception e)
            {
                //NetManager.Instance().Log("{0} receive exception: {1}", serverType, e.ToString());
                //ShutDown();
                //SetCurrentStatus(NETMANAGER_STATUS.NO_CONNECT);
                //Logger.Log(e.ToString());
                if (recvCB != null)
                {
                    recvCB(false, -1, "NetworkBase Receive Exception: " + e.ToString());
                }
            }
        }

        public void Update()
        {
            lock (mSendCB)
            {
                for(int i = 0; i < mSendCB.Count; ++i)
                {
                    if(null != mSendCB[i])
                    {
                        mSendCB[i].Invoke();
                    }
                }
                mSendCB.Clear();
            }

            if (EStatus == SocketStatus.SS_DISCONNECTED)
            {
                return;
            }

            if (EStatus == SocketStatus.SS_TRYCONNECT)
            {
                TryReconnect();
            }
            else if (EStatus == NetSocket.SocketStatus.SS_TRYCONNECTED)
            {
                OnConnected();
            }
            else if (EStatus == NetSocket.SocketStatus.SS_RECONNECT)
            {
                //if (Time.time > nextReconnectTime)
                //{
                //    if (-1 != mInvokeHandle)
                //    {
                //        GameClient.InvokeManager.Instance().RemoveInvoke(mInvokeHandle);
                //        mInvokeHandle = -1;
                //    }
                //    Connect(ip, port);
                //}
            }
            else if (EStatus == NetSocket.SocketStatus.SS_INVALID)
            {
                Connect(ip, port);
            }

            if (EStatus == NetSocket.SocketStatus.SS_CONNECTED)
            {
                Receive(inBuffer.GetRawBuffer(),
                            inBuffer.GetCurrentOffset(),
                            inBuffer.GetCurrentSize(),
                            recvCB);
            }
        }
    }
}
