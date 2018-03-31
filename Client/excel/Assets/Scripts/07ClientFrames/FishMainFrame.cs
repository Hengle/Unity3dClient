using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public sealed class FishMainFrame : ClientFrame 
	{
        UnityEngine.UI.Button mbtnQuit;

        protected override void _InitScriptBinder()
        {
            mbtnQuit = mScriptBinder.GetObject("btnQuit") as UnityEngine.UI.Button;
        }

        protected override sealed void _OnOpenFrame()
		{
			if(null != mbtnQuit)
            {
                mbtnQuit.onClick.AddListener(_OnClickClose);
            }
		}

        void _OnClickClose()
        {
            UIManager.Instance().CloseFrame(this);
        }

        protected override sealed void _OnCloseFrame()
		{
			
		}
	}
}