using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public sealed class SettingFrame : ClientFrame
	{
		UnityEngine.UI.Button mbtnReturn;
		GameClient.ComSettingFrameDataBinder mcomSetting;

		protected override void _InitScriptBinder()
		{
			mbtnReturn = mScriptBinder.GetObject("btnReturn") as UnityEngine.UI.Button;
			mcomSetting = mScriptBinder.GetObject("comSetting") as GameClient.ComSettingFrameDataBinder;
		}
	
		protected override sealed void _OnOpenFrame()
		{
			if (null != mbtnReturn) 
			{
				mbtnReturn.onClick.AddListener (_OnClickClose);
			}
			if (null != mcomSetting) 
			{
				mcomSetting.InitTabs ();
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