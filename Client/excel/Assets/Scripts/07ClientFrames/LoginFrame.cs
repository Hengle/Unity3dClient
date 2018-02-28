using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    public class LoginFrame : ClientFrame
    {
        const int Invoke_Fly = 1000;
        const int Invoke_Fly_Repeated = 1001;

        protected override void _OnOpenFrame()
        {
            Button btnClose = Utility.FindComponent<Button>(root, "Close");
            if(null != btnClose)
            {
                btnClose.onClick.AddListener(_OnClickCloseFrame);
            }

            RegisterEvent(ClientEvent.CE_LOGIN_TEST, _OnLoginTest);

            Invoke(Invoke_Fly, 1.0f, () => { LogManager.Instance().LogErrorFormat("start fly !"); });
            InvokeRepeate(Invoke_Fly_Repeated, 0.0f, 6, 0.50f, () =>
                {
                    LogManager.Instance().LogErrorFormat("repeat start !");
                },
            () =>
            {
                LogManager.Instance().LogErrorFormat("repeat update !");
            },
            () =>
            {
                LogManager.Instance().LogErrorFormat("repeat end !");
            });
        }

        protected void _OnLoginTest(object param)
        {
            LogManager.Instance().LogErrorFormat("On Recv Login Test Event !!!");
        }

        protected void _OnClickCloseFrame()
        {
            UIManager.Instance().CloseFrame(this);
        }

        protected override void _OnCloseFrame()
        {

        }
    }
}