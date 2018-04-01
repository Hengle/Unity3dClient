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
    public class NetInputBuffer
    {
		//初始化的接收缓存长度
        //临时增加BUFFER长度，以后修改回来     罗亚
        public readonly int DEFAULTSOCKETOUTPUTBUFFERSIZE = 1024 * 1024 ;

        public int m_BufferLen = 0;
        public int m_MaxBufferLen = 0;
        public byte[] m_Buffer;
        public int m_Head = 0;
        public int m_Tail = 0;
		
		public NetInputBuffer ()
		{
			m_Head = 0;
            m_Tail = 0;
            m_Buffer = new byte[DEFAULTSOCKETOUTPUTBUFFERSIZE];
            m_BufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
            m_MaxBufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
		}

        public byte[] GetRawBuffer()
        {
            return m_Buffer ;
        }

        public int GetCurrentOffset ()
        {
            return m_Tail ;
        }

        public int GetCurrentSize ()
        {
            return m_BufferLen - m_Tail ;
        }

        // 返回false表示读取失败 [12/13/2011 ZL]
        public bool Peek(ref byte[] buf, int len)
        {
            if (len == 0)
            {
                //Logger.LogError( "len == 0" ) ;
                return false;
            }
                
            int resLen = Length() ;
            if (len > resLen)
            {
                //Logger.LogError( "len > Length(): " + len + " > " + resLen ) ;
                return false;
            }
                
            int j = m_Head;
            for ( int i = 0; i < len; ++i )
            {
                buf[i] = m_Buffer[j++];
                if (j == m_BufferLen)
                    j = 0;
            }
            return true;
        }

        public int GetPackLength()
        {
            ushort outBuf = 0 ;
            if ( Length() < (int)NET_DEFINE.HEADER_SIZE) return 0;
            outBuf = (ushort)(m_Buffer[m_Head] | (m_Buffer[m_Head + 1] << 8));
            //Skip(4);
            outBuf = (ushort)IPAddress.NetworkToHostOrder( (short)outBuf );
            return outBuf ;
        }


        /// <summary>
        /// 查找包的分隔符
        /// </summary>
        /// <param name="buf">分隔符串</param>
        /// <returns>
        /// true ：成功找到
        /// false：没有找到
        /// </returns>
        public bool Find(ref byte[] buf)
        {
            /*int len = Length();
            for (int i = 0; i < len; ++i)
            {
                int j = 0;
                if (m_Buffer[m_Head] == NET_DEFINE.PACK_COMPART[j])
                {
                    for (++j; j < NET_DEFINE.PACK_COMPART_SIZE; ++j)
                    {
                        if (m_Buffer[(m_Head + j) % m_BufferLen] != NET_DEFINE.PACK_COMPART[j])
                            break;
                    }
                }
                // 找到包分隔符,并跳过包分隔符 [12/13/2011 ZL]
                if (j == NET_DEFINE.PACK_COMPART_SIZE)
                {
                    m_Head += NET_DEFINE.PACK_COMPART_SIZE;
                    if (m_Head >= m_BufferLen)
                        m_Head -= m_BufferLen;
                    return true;
                }
                ++m_Head;
                if (m_Head == m_BufferLen)
                {
                    m_Head -= m_BufferLen;
                }
            }*/
            return false;
        }

        public bool Skip(int len)
        {
            if (len == 0)
                return false;

            if (len > Length())
                return false;

            m_Head = (m_Head + len) % m_BufferLen;

            //Edit by luoya, for leave away from end of the buffer...
            if ( m_Head == m_Tail )
            {
                m_Head = m_Tail = 0 ;
            }

            return true;
        }

        public void Initsize()
        {
            m_Head = m_Tail = 0;
            m_Buffer = new byte[DEFAULTSOCKETOUTPUTBUFFERSIZE];
            m_BufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
            m_MaxBufferLen = DEFAULTSOCKETOUTPUTBUFFERSIZE;
        }
		
        public bool Resize(int size)
        {
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

        public void resetBuffer( bool isNotEnough)
        {
            try
            {
                //如果出现粘包现象，则把上次余留的TCP包拷到缓冲区的头部，否则清空缓冲区
                if (isNotEnough)
                    Array.Copy(m_Buffer, m_Head, m_Buffer, 0, Length());
                else
                    Array.Clear(m_Buffer, 0, m_Buffer.Length);
                
                //重新设置总大小与 当前偏移
                m_Tail = Length();
                m_Head = 0;
            }
            catch (Exception e)
            {
                //Network.NetWork.ErrorString = "resetBuffer: " + e.ToString();
                //WriteFiles.WritFile.Log(LogerType.ERROR, "resetBuffer: " + e.ToString());
            }
        }

        public bool IsEmpty()
        {
            return m_Head == m_Tail;
        }

        public void CleanUp()
        {
            m_Head = m_Tail = 0;
            Array.Clear(m_Buffer, 0, m_Buffer.Length);
        }
	}
}

