using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public class LoadingFrame : ClientFrame
    {
        UnityEngine.UI.Text mloadTitle;
        UnityEngine.UI.Text mloadInfo;
        UnityEngine.UI.Slider mloadProcess;

        protected override void _InitScriptBinder()
        {
            mloadTitle = mScriptBinder.GetObject("loadTitle") as UnityEngine.UI.Text;
            mloadInfo = mScriptBinder.GetObject("loadInfo") as UnityEngine.UI.Text;
            mloadProcess = mScriptBinder.GetObject("loadProcess") as UnityEngine.UI.Slider;
        }

        protected void _OnSetLoadingTitle(object argv)
        {
            string value = argv as string;
            if(null != value && null != mloadTitle)
            {
                mloadTitle.text = value;
            }
        }

        protected void _OnSetLoadingSubTitle(object argv)
        {
            string value = argv as string;
            if (null != value && null != mloadInfo)
            {
                mloadInfo.text = value;
            }
        }

        protected void _OnSetLoadingProcess(object argv)
        {
            float value = (float)argv;
            if(null != mloadProcess)
            {
                mloadProcess.value = value;
            }
        }

        protected void _OnSetLoadingSubProcess(object argv)
        {

        }

        protected void _OnSetLoadingFinish(object argv)
        {
            UIManager.Instance().CloseFrame(this);
        }

        protected override void _OnOpenFrame()
        {
            EventManager.Instance().RegisterEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, _OnSetLoadingTitle);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_ON_SET_LOADING_SUB_TITLE, _OnSetLoadingSubTitle);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, _OnSetLoadingProcess);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_ON_SET_LOADING_SUB_PROCESS, _OnSetLoadingSubProcess);
            EventManager.Instance().RegisterEvent(ClientEvent.CE_ON_SET_LOADING_FINISH, _OnSetLoadingFinish);
        }

        protected override void _OnCloseFrame()
        {
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_ON_SET_LOADING_TITLE, _OnSetLoadingTitle);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_ON_SET_LOADING_SUB_TITLE, _OnSetLoadingSubTitle);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_ON_SET_LOADING_PROCESS, _OnSetLoadingProcess);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_ON_SET_LOADING_SUB_PROCESS, _OnSetLoadingSubProcess);
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_ON_SET_LOADING_FINISH, _OnSetLoadingFinish);
        }
    }
}