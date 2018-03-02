using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LoggerServer
{
    public class LogNetServer
    {
        public string ip;
        public short port;
        Socket socket;
        List<Socket> clientSockets = new List<Socket>();
        System.Byte[] mBuffer = new byte[2048];
        public bool destroyed = false;

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
                System.Console.WriteLine(e.ToString());
            }
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(LogPrintThread, new object[] { clientSockets, this });

            //定义IP地址
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint iep = new IPEndPoint(ipAddress, port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(iep);
                socket.Listen(20);
                socket.BeginAccept(new System.AsyncCallback(Accept), socket);
                Console.WriteLine("日志服务器启动成功!");
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
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
                                if (!string.IsNullOrEmpty(content))
                                {
                                    System.Console.WriteLine(content);
                                }
                            }
                            catch (System.Exception e)
                            {
                                System.Console.WriteLine(e.ToString());
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

            System.Console.WriteLine("<color=#00ff00>thread auto abort !</color>");
        }

        public void Exit()
        {
            destroyed = true;
            clientSockets = null;
            if (null != socket)
            {
                socket.Close();
            }
        }

        ~LogNetServer()
        {
            Exit();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            short port = 8864;

            LogNetServer mServer = new LogNetServer();
            if (args.Length == 2)
            {
                ip = args[0];
                port = 0;
                if(!short.TryParse(args[1],out port))
                {
                    Console.WriteLine("format like : 127.0.0.1 8888 !");
                    return;
                }
            }

            Console.BackgroundColor = ConsoleColor.DarkCyan;

            mServer.ip = ip;
            mServer.port = port;
            mServer.Start();

            Console.ReadLine();
        }
    }
}
