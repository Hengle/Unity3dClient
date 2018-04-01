using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;



namespace NetWork
{
	public class NetOutputBuffer
	{
		//初始化的发送缓存长度
		public readonly int DEFAULTSOCKETOUTPUTBUFFERSIZE = 8196;//8*1024
		public int m_BufferLen = 0;
		public int m_MaxBufferLen = 0;
		
		//发送缓冲区
        public byte[] m_Buffer;
        // 多线程发送数据缓冲区，有好的方法，可以去除，不然用的时候就得拷贝！！ [3/12/2012 adomi]
        public byte[] m_SendData;
        public int m_Head;
        public int m_Tail;

        protected NetSocket netSocket = null;
		
		public NetOutputBuffer (NetSocket netWork)
		{
            netSocket = netWork;
            m_Head = 0;
            m_Tail = 0;
            m_Buffer = new byte[DEFAULTSOCKETOUTPUTBUFFERSIZE];
            m_BufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
            m_MaxBufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
            m_SendData = new byte[DEFAULTSOCKETOUTPUTBUFFERSIZE];
		}
		
		
		/// <summary>
        /// 发送缓冲区里的所有逻辑包
        /// </summary>
        /// <param name="socket">Socket对象</param>
        /// <param name="buffLen">发送长度</param>
        /// <returns></returns>
        protected bool Send ( int buffLen )
        {
            // 拷贝要发送的 [3/12/2012 adomi]
            Array.Clear(m_SendData, 0, m_SendData.Length);
            Array.Copy(m_Buffer, m_Head, m_SendData, 0, buffLen);

            netSocket.Send(m_SendData) ;

            //NetManager.Instance().Log("output buffer send data:{0}->{1} len:{2}", m_Head, m_Head + buffLen, buffLen);
            return true;
        }
		
		/// <summary>
        /// 发送缓冲区里的消息
        /// </summary>
        /// <returns>
        /// -1：出错
        /// >=0：正常
        /// </returns>
        public int Flush()
        {
            int nFlushed = 0;
            int nSent = 0;
            int nLeft;

            /*if (NetManager.Instance().Show)
            {
                NetManager.Instance().Log("output buffer flushing... head:{0} tail:{1}", m_Head, m_Tail);
            }*/

            if (m_BufferLen > m_MaxBufferLen)
            {
                //NetManager.Instance().Log("output buffer error, len:{0} max:{1}.", m_BufferLen, m_MaxBufferLen);
                //如果单个客户端的缓存太大，则重新设置缓存，并将此客户端断开连接
                Initsize();
                return -1;
            }

            if (m_Head < m_Tail)
            {
                nLeft = m_Tail - m_Head;

                while (nLeft > 0)
                {
                    //发送包
                    Send( nLeft ) ;

                    nSent = nLeft;
                    nFlushed += nSent;
                    nLeft -= nSent;
                    m_Head += nSent;
                }

            }
            else if (m_Head > m_Tail)
            {
                nLeft = m_BufferLen - m_Head;

                while (nLeft > 0)
                {
                    //发送包
                    Send( nLeft ) ;

                    nSent = nLeft;
                    nFlushed += nSent;
                    nLeft -= nSent;
                    m_Head += nSent;
                }

                m_Head = 0;

                nLeft = m_Tail;

                while (nLeft > 0)
                {
                    //发送包
                    Send( nLeft ) ;

                    nSent = nLeft;
                    nFlushed += nSent;
                    nLeft -= nSent;
                    m_Head += nSent;
                }
            }

            m_Head = m_Tail = 0;

            return nFlushed;
        }
		
		public void Initsize()
        {
            m_Head = m_Tail = 0;
            m_Buffer = new byte[DEFAULTSOCKETOUTPUTBUFFERSIZE];
            m_BufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
            m_MaxBufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
        }

        // 暂时不做内存的重新分配 [12/13/2011 ZL]
        public bool Resize(int size)
        {
            //NetManager.Instance().Log("output buffer resize{0} failed.", size);
            return false;
        }

        public int Capacity()
        {
            return m_BufferLen;
        }

        public int Length()
        {
            if (m_Head < m_Tail)
                return m_Tail - m_Head;

            else if (m_Head > m_Tail)
                return m_BufferLen - m_Head + m_Tail;

            return 0;
        }

        public bool IsEmpty()
        {
            return m_Head == m_Tail;
        }

        public void CleanUp()
        {
            m_Head = m_Tail = 0;
            Array.Clear(m_Buffer, 0, m_Buffer.Length);
            Array.Clear(m_SendData, 0, m_SendData.Length);
        }
		
	}
}

