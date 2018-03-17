using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetWork;
using Protocol;

namespace GameClient
{
    [RequireComponent(typeof(ComClientSocket))]
    public class ComProtobufTest : MonoBehaviour
    {
        ComClientSocket comClientSocket;

        void Awake()
        {
            comClientSocket = GetComponent<ComClientSocket>();
        }

        public void OnSucceed()
        {
            if (null != comClientSocket)
            {
                Person person = new Person();
                person.id = 19888;
                person.name = "shenshaojun";
                person.email = "370119386@qq.com";
                NetManager.Instance().Send(person, comClientSocket.Handle);
            }
        }
    }
}