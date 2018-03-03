using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NetWork;

namespace GameClient
{
    class ComClientSocket : MonoBehaviour
    {
        public UnityEvent onConnectedSucceed;
        public UnityEvent onConnectedFailed;
        public UnityEvent onReconnectedSucceed;
        public string SocketName = string.Empty;
        public string ServerIp = string.Empty;
        public short ServerPort = 8864;
        public int maxReconnectTimes = 5;
        NetSocket mSocket = null;

        void Awake()
        {
            EventManager.Instance().RegisterEvent(ClientEvent.CE_SEND_MSG_TO_NORMAL_SOCKET, OnHandleNetEvent);
        }

        void OnHandleNetEvent(object argv)
        {

        }

        // Use this for initialization
        void Start()
        {
            mSocket = new NetSocket(SocketName, ServerIp, ServerPort, maxReconnectTimes, _OnConnectedSucceed, _OnConnectedFailed, _OnReConnectedSucceed);
        }

        void _OnConnectedSucceed(object argv)
        {
            if(null != onConnectedSucceed)
            {
                onConnectedSucceed.Invoke();
            }
        }

        void _OnConnectedFailed(object argv)
        {
            if (null != onConnectedFailed)
            {
                onConnectedFailed.Invoke();
            }
        }

        void _OnReConnectedSucceed(object argv)
        {
            if (null != onReconnectedSucceed)
            {
                onReconnectedSucceed.Invoke();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(null != mSocket)
            {
                mSocket.Update();
            }
        }

        private void OnDestroy()
        {
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_SEND_MSG_TO_NORMAL_SOCKET, OnHandleNetEvent);
            if(null != onConnectedSucceed)
            {
                onConnectedSucceed.RemoveAllListeners();
            }
            if(null != onConnectedFailed)
            {
                onConnectedFailed.RemoveAllListeners();
            }
            if(null != onReconnectedSucceed)
            {
                onReconnectedSucceed.RemoveAllListeners();
            }
            if (null != mSocket)
            {
                mSocket.Close();
            }
        }
    }
}