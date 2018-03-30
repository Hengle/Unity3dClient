using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public sealed class LobbyFrame : ClientFrame 
	{
		UnityEngine.UI.Button mbtnReturn;
		UnityEngine.UI.Button mbtnSetting;

		protected override void _InitScriptBinder()
		{
			mbtnReturn = mScriptBinder.GetObject("btnReturn") as UnityEngine.UI.Button;
			mbtnSetting = mScriptBinder.GetObject("btnSetting") as UnityEngine.UI.Button;
		}

        protected override sealed void _OnOpenFrame()
		{
			if(null != mbtnReturn)
            {
                mbtnReturn.onClick.AddListener(_OnClickClose);
            }
			if (null != mbtnSetting) 
			{
				mbtnSetting.onClick.AddListener (_OnClickSetting);
			}
		}

        void _OnClickClose()
        {
            UIManager.Instance().CloseFrame(this);
            Application.Quit();
        }

		void _OnClickSetting()
		{
			UIManager.Instance ().OpenFrame<SettingFrame> (4);
		}

        protected override sealed void _OnCloseFrame()
		{
			
		}
	}
}