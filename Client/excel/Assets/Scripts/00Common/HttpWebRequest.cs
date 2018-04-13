using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using XLua;
using GameClient;
using System;

namespace NetWork
{
    [CSharpCallLua]
    public delegate void LocalHttpWebRequestCB(HttpRequestError errCode, string resp);

    [LuaCallCSharp]
    public enum HttpRequestError
    {
        HRE_SUCCEED = 0,
        HRE_INVALID_POST_DATA,
        HRE_INVALID_POST_DATA_BYTES,
        HRE_INVALID_POST_METHOD,
        HRE_STATUS_ERROR,
        HRE_EXCEPTION,
    }

    [LuaCallCSharp]
    public enum HttpRequestStatus
    {
        HRS_INVALID = -1,
        HRS_BEGIN_REQUEST,
        HRS_WAIT_EVENT,
    }

    [LuaCallCSharp]
    public class LocalHttpWebRequest
    {
        HttpRequestStatus _status = HttpRequestStatus.HRS_INVALID;
        HttpRequestStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                lock(this)
                {
                    _status = value;
                }
            }
        }

        HttpWebRequest httpWebRequest = null;
        string _postdata = string.Empty;
        string _result = string.Empty;
        HttpRequestError _errorCode = HttpRequestError.HRE_SUCCEED;
        int _InvokeId = -1;
        LocalHttpWebRequestCB _cb = null;

        [LuaCallCSharp]
        public void HttpPostRequest(string url, string postdata, LocalHttpWebRequestCB cb, int timeout = 5000)
        {
            if(Status != HttpRequestStatus.HRS_INVALID)
            {
                if(null != cb)
                {
                    cb(HttpRequestError.HRE_STATUS_ERROR, "status error ! this status must be HttpRequestStatus.HRS_INVALID !");
                }
                return;
            }

            if (-1 != _InvokeId)
            {
                if (null != cb)
                {
                    cb(HttpRequestError.HRE_STATUS_ERROR, "status error ! _InvokeId must eq -1 !");
                }
                return;
            }

            if (string.IsNullOrEmpty(postdata))
            {
                if (null != cb)
                {
                    cb(HttpRequestError.HRE_INVALID_POST_DATA, "post data is empty !!!");
                }
                return;
            }

            byte[] bs = System.Text.Encoding.Default.GetBytes(postdata);
            if (bs.Length <= 0)
            {
                if (null != cb)
                {
                    cb(HttpRequestError.HRE_INVALID_POST_DATA_BYTES, "post data bytes length is 0 !!!");
                }
                return;
            }

            Status = HttpRequestStatus.HRS_BEGIN_REQUEST;
            httpWebRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = @"POST";
            httpWebRequest.ContentType = @"application/x-www-form-urlencoded";
            httpWebRequest.Timeout = timeout;
            _postdata = postdata;
            _cb = cb;
            _InvokeId = InvokeManager.Instance().InvokeRepeate(this, 0.0f, 99999999, 0.10f, null, UpdateEvent, null,false);

            httpWebRequest.BeginGetRequestStream(EndRequest, this);
        }

        [LuaCallCSharp]
        public void HttpGetRequest(string url, LocalHttpWebRequestCB cb,int timeout=5000)
        {
            if (Status != HttpRequestStatus.HRS_INVALID)
            {
                if (null != cb)
                {
                    cb(HttpRequestError.HRE_STATUS_ERROR, "status error ! this status must be HttpRequestStatus.HRS_INVALID !");
                }
                return;
            }

            if (-1 != _InvokeId)
            {
                if (null != cb)
                {
                    cb(HttpRequestError.HRE_STATUS_ERROR, "status error ! _InvokeId must eq -1 !");
                }
                return;
            }

            Status = HttpRequestStatus.HRS_BEGIN_REQUEST;
            httpWebRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = @"GET";
            httpWebRequest.ContentType = @"application/x-www-form-urlencoded";
            httpWebRequest.Timeout = timeout;
            _postdata = string.Empty;
            _cb = cb;
            _InvokeId = InvokeManager.Instance().InvokeRepeate(this, 0.0f, 99999999, 0.10f, null, UpdateEvent, null,false);

            httpWebRequest.BeginGetResponse(EndResponse, this);
        }

        void EndResponse(IAsyncResult ar)
        {
            LocalHttpWebRequest local = ar.AsyncState as LocalHttpWebRequest;
            try
            {
                //处理响应
                var response = local.httpWebRequest.EndGetResponse(ar) as HttpWebResponse;
                using (Stream responseStm = response.GetResponseStream())
                {
                    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                    _result = redStm.ReadToEnd();
                    responseStm.Close();
                    _errorCode = HttpRequestError.HRE_SUCCEED;
                    Status = HttpRequestStatus.HRS_WAIT_EVENT;
                }
            }
            catch (Exception e)
            {
                _result = e.ToString();
                _errorCode = HttpRequestError.HRE_EXCEPTION;
                Status = HttpRequestStatus.HRS_WAIT_EVENT;
            }
        }

        void EndRequest(IAsyncResult ar)
        {
            LocalHttpWebRequest local = ar.AsyncState as LocalHttpWebRequest;
            try
            {
                httpWebRequest = local.httpWebRequest;
                using (Stream stream = httpWebRequest.EndGetRequestStream(ar))
                {
                    byte[] data = System.Text.Encoding.Default.GetBytes(_postdata);
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream responseStm = response.GetResponseStream())
                {
                    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                    _result = redStm.ReadToEnd();
                    responseStm.Close();
                    _errorCode = HttpRequestError.HRE_SUCCEED;
                    Status = HttpRequestStatus.HRS_WAIT_EVENT;
                }
            }
            catch (Exception ex)
            {
                _errorCode = HttpRequestError.HRE_EXCEPTION;
                _result = ex.ToString();
                Status = HttpRequestStatus.HRS_WAIT_EVENT;
            }
        }

        void UpdateEvent()
        {
            if(Status == HttpRequestStatus.HRS_WAIT_EVENT)
            {
                InvokeManager.Instance().RemoveInvoke(_InvokeId);
                _InvokeId = -1;
                _postdata = string.Empty;
                httpWebRequest = null;
                Status = HttpRequestStatus.HRS_INVALID;
                LocalHttpWebRequestCB _cbTmp = _cb;
                _cb = null;

                if (null != _cbTmp)
                {
                    _cbTmp(_errorCode, _result);
                }
                _errorCode = HttpRequestError.HRE_SUCCEED;
                _result = string.Empty;
            }
        }

        bool DoHttpRequest(string method,string url,string postdata, LocalHttpWebRequestCB cb,int timeout = 5000)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogErrorFormat("url = {0}",url);
#endif
            if (string.IsNullOrEmpty(method))
            {
                if (!method.Equals("POST") && !method.Equals("GET"))
                {
                    if (null != cb)
                    {
                        cb(HttpRequestError.HRE_INVALID_POST_METHOD, "method can only be POST or GET for http request !!!");
                    }
                    return false;
                }
            }

            bool post = method.Equals("POST");
            if(post)
            {
                if (post && string.IsNullOrEmpty(postdata))
                {
                    if (null != cb)
                    {
                        cb(HttpRequestError.HRE_INVALID_POST_DATA, "post data is empty !!!");
                    }
                    return false;
                }

                byte[] bs = System.Text.Encoding.Default.GetBytes(postdata);
                if (bs.Length <= 0)
                {
                    if (null != cb)
                    {
                        cb(HttpRequestError.HRE_INVALID_POST_DATA_BYTES, "post data bytes length is 0 !!!");
                    }
                    return false;
                }

                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Method = method;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bs.Length;
                request.Timeout = timeout;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }

                try
                {
                    //处理响应
                    var response = (HttpWebResponse)request.GetResponse();
                    using (Stream responseStm = response.GetResponseStream())
                    {
                        StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                        string result = redStm.ReadToEnd();
                        responseStm.Close();

                        if (null != cb)
                        {
                            cb(HttpRequestError.HRE_SUCCEED, result);
                        }

                        return true;
                    }
                }
                catch (Exception e)
                {
                    if (null != cb)
                    {
                        cb(HttpRequestError.HRE_EXCEPTION, e.ToString());
                    }
                }
            }
            else
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = 0;
                request.Timeout = timeout;
                try
                {
                    //处理响应
                    var response = (HttpWebResponse)request.GetResponse();
                    using (Stream responseStm = response.GetResponseStream())
                    {
                        StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                        string result = redStm.ReadToEnd();
                        responseStm.Close();

                        if (null != cb)
                        {
                            cb(HttpRequestError.HRE_SUCCEED, result);
                        }

                        return true;
                    }
                }
                catch (Exception e)
                {
                    if (null != cb)
                    {
                        cb(HttpRequestError.HRE_EXCEPTION, e.ToString());
                    }
                }
            }

            return false;
        }
    }
}
