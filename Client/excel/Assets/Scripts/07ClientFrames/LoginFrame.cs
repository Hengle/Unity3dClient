using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.UI;

namespace GameClient
{
    public sealed class LoginFrame : ClientFrame
    {
		UnityEngine.UI.Button mbtnClose;

		protected override void _InitScriptBinder()
		{
			mbtnClose = mScriptBinder.GetObject("btnClose") as UnityEngine.UI.Button;
		}
		
		protected override sealed void _OnOpenFrame()
        {
			if (null != mbtnClose) 
			{
				mbtnClose.onClick.AddListener (_OnClickClose);
			}
        }

        protected void _OnClickCloseFrame()
        {
            UIManager.Instance().CloseFrame(this);
        }

		protected override sealed void _OnCloseFrame()
        {
			mbtnClose = null;
        }

		protected void _OnClickClose()
		{
			UIManager.Instance().CloseFrame(this);
		}
    }
}