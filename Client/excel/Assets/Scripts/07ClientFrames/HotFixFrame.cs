using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.UI;

namespace GameClient
{
    public class HotFixFrame : ClientFrame
    {
        UnityEngine.UI.Text mHotFixStepInfo;
        protected override void _InitScriptBinder()
        {
            mHotFixStepInfo = mScriptBinder.GetObject("HotFixStepInfo") as UnityEngine.UI.Text;
        }

        protected override void _OnOpenFrame()
        {
            StartCoroutine(HotFixProcess());
        }

        enum HotFixStatus
        {
            HFS_INVALID = -1,
            HFS_CONNTING_SERVER,
            HFS_CONNECTED_SERVER_SUCCEED,
            HFS_DOLOAD_RESOURCES_FILE,
            HFS_FAILED,
        }
        HotFixStatus mHotFixStatus = HotFixStatus.HFS_INVALID;

        IEnumerator HotFixProcess()
        {
            mHotFixStatus = HotFixStatus.HFS_INVALID;

            _LogProcessFormat(6000,"start hot fix !!");
            yield return new WaitForSecondsRealtime(1.0f);

            _LogProcessFormat(6000, "ready fetch resourceinfo.txt!!");
            yield return new WaitForSecondsRealtime(1.0f);

            GameObject hotFixObject = new GameObject("hotfix");
            Utility.AttachTo(hotFixObject, root);
            ComClientSocket hotFixSocket = hotFixObject.AddComponent<ComClientSocket>();
            hotFixSocket.SocketName = "HotFix Server";
            hotFixSocket.ServerIp = "192.168.2.27";
            hotFixSocket.ServerPort = 8864;
            hotFixSocket.onConnectedSucceed = new UnityEngine.Events.UnityEvent();
            hotFixSocket.onConnectedSucceed.AddListener(_OnConnectedSucceed);
            hotFixSocket.onConnectedFailed = new UnityEngine.Events.UnityEvent();
            hotFixSocket.onConnectedFailed.AddListener(_OnConnectedFailed);
            hotFixSocket.onReconnectedSucceed = new UnityEngine.Events.UnityEvent();
            hotFixSocket.onReconnectedSucceed.AddListener(_OnReconnectedSucceed);

            _LogProcessFormat(6000, "正在连接热更新服务器 ... !!");
            mHotFixStatus = HotFixStatus.HFS_CONNTING_SERVER;

            if(mHotFixStatus == HotFixStatus.HFS_FAILED)
            {
                _LogProcessFormat(6000, "hot fix Coroutine failed !!!");
                yield break;
            }

            while(mHotFixStatus != HotFixStatus.HFS_CONNECTED_SERVER_SUCCEED)
            {
                yield return new WaitForSecondsRealtime(0.20f);
            }

            mHotFixStatus = HotFixStatus.HFS_DOLOAD_RESOURCES_FILE;
            _LogProcessFormat(6000, "start down load resourceinfo.txt!!!");

            _LogProcessFormat(6000, "hot fix Coroutine finished !!!");
        }

        void _OnConnectedSucceed()
        {
            _LogProcessFormat(6000, "热更新服务器连接成功!!");
            mHotFixStatus = HotFixStatus.HFS_CONNECTED_SERVER_SUCCEED;
        }

        void _OnConnectedFailed()
        {
            _LogProcessFormat(6000, "热更新服务器连接失败!!");
            mHotFixStatus = HotFixStatus.HFS_FAILED;
        }

        void _OnReconnectedSucceed()
        {
            _LogProcessFormat(6000, "重连热更新服务器成功!!");
            mHotFixStatus = HotFixStatus.HFS_CONNECTED_SERVER_SUCCEED;
        }

        void _LogProcessFormat(int Id, string format, params object[] argvs)
        {
            LogManager.Instance().LogProcessFormat(Id, format, argvs);
            if(null != mHotFixStepInfo)
            {
                mHotFixStepInfo.text = string.Format(format, argvs);
            }
        }

        protected override void _OnCloseFrame()
        {

        }
    }
}