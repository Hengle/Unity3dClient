using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public sealed class LobbyFrame : ClientFrame 
	{
        UnityEngine.UI.Button mbtnReturn;

        protected override void _InitScriptBinder()
        {
            mbtnReturn = mScriptBinder.GetObject("btnReturn") as UnityEngine.UI.Button;
        }

        protected override sealed void _OnOpenFrame()
		{
			if(null != mbtnReturn)
            {
                mbtnReturn.onClick.AddListener(_OnClickClose);
            }
		}

        void _OnClickClose()
        {
            UIManager.Instance().CloseFrame(this);
            Application.Quit();
        }

        protected override sealed void _OnCloseFrame()
		{
			
		}
	}
}