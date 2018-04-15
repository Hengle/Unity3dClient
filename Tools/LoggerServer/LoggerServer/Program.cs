using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;

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
                Console.WriteLine("IP:{0}", ip);
                Console.WriteLine("port:{0}", port);
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
        /// <summary>  
        /// 获取客户端内网IPv4地址  
        /// </summary>  
        /// <returns>客户端内网IPv4地址</returns>  
        public static string GetClientLocalIPv4Address()
        {
            string strLocalIP = string.Empty;
            try
            {
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHost.AddressList[0];
                strLocalIP = ipAddress.ToString();
                return strLocalIP;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>  
        /// 获取客户端内网IPv6地址  
        /// </summary>  
        /// <returns>客户端内网IPv6地址</returns>  
        public static string GetClientLocalIPv6Address()
        {
            string strLocalIP = string.Empty;
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHost.AddressList[0];
                strLocalIP = ipAddress.ToString();
                return strLocalIP;
            }
            catch
            {
                return string.Empty;
            }
        }

        static void HandleIPAuto(ref string ip)
        {
            string ipAddress = GetClientLocalIPv4Address();
            if (!string.IsNullOrEmpty(ipAddress))
            {
                ip = ipAddress;
                Console.WriteLine("get ip by GetClientLocalIPv4Address :" + ip);
            }
            else
            {
                Console.WriteLine("get ip by default :" + ip);
            }
        }

        static void Main(string[] args)
        {
            string ip = "192.168.2.27";
            short port = 8864;

            LogNetServer mServer = new LogNetServer();

            try
            {
                var lines = System.IO.File.ReadAllLines("../../ipconfig.cfg");
                if (lines.Length == 2)
                {
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        int iFindIndex = lines[i].IndexOf("=");
                        if (iFindIndex >= 0 && iFindIndex < lines[i].Length)
                        {
                            lines[i] = lines[i].Substring(iFindIndex + 1, lines[i].Length - (iFindIndex + 1));
                        }
                    }
                    ip = lines[0];
                    port = 0;
                    if (!short.TryParse(lines[1], out port))
                    {
                        Console.WriteLine("port error!");
                        return;
                    }

                    Console.WriteLine("get ip from ipconfig.cfg:" + ip);
                }
                else
                {
                    HandleIPAuto(ref ip);
                }
            }
            catch
            {
                HandleIPAuto(ref ip);
            }

            Console.BackgroundColor = ConsoleColor.DarkCyan;

            mServer.ip = ip;
            mServer.port = port;
            mServer.Start();

            Console.ReadLine();
        }
    }
}
