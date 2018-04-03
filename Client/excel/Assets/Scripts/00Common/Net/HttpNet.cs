using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

namespace NetWork
{
    [CSharpCallLua]
    public delegate void HttpResponseCb(bool isError, string resp);

    [LuaCallCSharp]
    public class HttpNet : MonoBehaviour
    {
        public void Log()
        {
            Debug.Log("this is httpnet!");
        }

        public void Post(HttpResponseCb cb, string url, string postData)
        {
            StartCoroutine(postRequest(cb, url, postData));
        }

        IEnumerator postRequest(HttpResponseCb cb, string url, string postData)
        {
            UnityWebRequest uwr = UnityWebRequest.Post(url, postData);
            yield return uwr.Send();

            if (uwr.isError)
            {
                cb(true, uwr.error);
            }
            else
            {
                cb(false, uwr.downloadHandler.text);
            }
        }

    }

}



