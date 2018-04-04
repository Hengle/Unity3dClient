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
        public void Get(HttpResponseCb cb, string url)
        {
            StartCoroutine(getRequest(cb, url));
        }

        public void Post(HttpResponseCb cb, string url, string postData)
        {
            StartCoroutine(postRequest(cb, url, postData));
        }

        IEnumerator getRequest(HttpResponseCb cb, string url)
        {
            UnityWebRequest uwr = UnityWebRequest.Get(url);
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



