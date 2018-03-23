using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Protocol;
using System;
using System.Net;
using System.Net.Sockets;

namespace NetWork
{
    class NetManager : GameClient.Singleton<NetManager>
    {
        private byte[] Serialize<T>(T model) where T : global::ProtoBuf.IExtensible
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize<T>(ms, model);
                    byte[] result = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(result, 0, result.Length);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.LogErrorFormat("Serialize {0} Failed: {1}" ,typeof(T),ex.ToString());
                return null;
            }
        }

        private T DeSerialize<T>(byte[] msg)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(msg, 0, msg.Length);
                    ms.Position = 0;
                    T result = ProtoBuf.Serializer.Deserialize<T>(ms);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.LogErrorFormat("DeSerialize {0} Failed: {1}", typeof(T), ex.ToString());
                return default(T);
            }
        }

        public void Send<T>(T msg,NetSocket socket, SendCallBack ok = null, SendCallBack failed = null) where T : global::ProtoBuf.IExtensible
        {
            byte[] bytes = Serialize(msg);
            if(null != socket && bytes.Length > 0)
            {
                socket.Send(bytes,ok,failed);
            }
        }
    }
}