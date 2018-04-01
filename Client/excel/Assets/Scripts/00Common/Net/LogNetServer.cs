using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GameClient
{
    public class LogNetServer : MonoBehaviour
    {
        public string ip;
        public short port;
        Socket socket;
        List<Socket> clientSockets = new List<Socket>();
        System.Byte[] mBuffer = new byte[2048];
        public bool destroyed = false;

        // Use this for initialization
        void Start()
        {
            ThreadPool.QueueUserWorkItem(LogPrintThread, new object[] { clientSockets,this });

            //定义IP地址
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint iep = new IPEndPoint(ipAddress, port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(iep);
                socket.Listen(20);
                socket.BeginAccept(new System.AsyncCallback(Accept), socket);
            }
            catch(System.Exception e)
            {
                UnityEngine.Debug.LogErrorFormat(e.ToString());
            }
        }

        void Accept(System.IAsyncResult iar)
        {
            try
            {
                //还原传入的原始套接字
                Socket MyServer = (Socket)iar.AsyncState;
                //在原始套接字上调用EndAccept方法，返回新的套接字
                Socket clientSocket = MyServer.EndAccept(iar);
                clientSockets.Add(clientSocket);
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogErrorFormat(e.ToString());
            }
        }

        private static void LogPrintThread(object userdata)
        {
            System.Byte[] mBuffer = new byte[2048];
            object[] datas = userdata as object[];
            List<Socket> clientSockets = datas[0] as List<Socket>;
            LogNetServer logNetServer = datas[1] as LogNetServer;

            while (!logNetServer.destroyed)
            {
                if (null != clientSockets)
                {
                    for (int i = 0; i < clientSockets.Count && !logNetServer.destroyed; ++i)
                    {
                        var clientSocket = clientSockets[i];
                        if (clientSocket.Connected)
                        {
                            try
                            {
                                int recv = clientSocket.Receive(mBuffer);
                                var content = System.Text.Encoding.ASCII.GetString(mBuffer, 0, recv);
                                if(!string.IsNullOrEmpty(content))
                                {
                                    System.Console.WriteLine(content);
                                }
                            }
                            catch (System.Exception e)
                            {
                                UnityEngine.Debug.LogErrorFormat(e.ToString());
                            }
                        }
                    }
                }

                System.Threading.Thread.Sleep(30);
            }

            for (int i = 0; i < clientSockets.Count; ++i)
            {
                var clientSocket = clientSockets[i];
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }

            UnityEngine.Debug.LogFormat("<color=#00ff00>thread auto abort !</color>");
        }

        private void OnDestroy()
        {
            destroyed = true;

            if (null != socket)
            {
                socket.Close();
            }
        }
    }
}