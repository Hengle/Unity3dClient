using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

namespace GameClient
{
    public class LogNetServer : MonoBehaviour
    {
        public string ip;
        public short port;
        Socket socket;
        System.Byte[] mBuffer = new byte[2048];

        // Use this for initialization
        void Start()
        {
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
                Socket service = MyServer.EndAccept(iar);

                int recv = service.Receive(mBuffer);
                var content = System.Text.Encoding.ASCII.GetString(mBuffer, 0, recv);
                UnityEngine.Debug.LogFormat("<color=#00ff00>{0}</color>", content);
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogErrorFormat(e.ToString());
            }
        }

        private void OnDestroy()
        {
            if(null != socket)
            {
                socket.Close();
            }
        }
    }
}