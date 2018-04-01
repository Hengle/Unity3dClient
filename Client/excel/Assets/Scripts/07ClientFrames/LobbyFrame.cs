using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public sealed class LobbyFrame : ClientFrame 
	{
        UnityEngine.UI.Button mbtnReturn;
        UnityEngine.UI.Button mbtnSetting;
        UnityEngine.UI.Button mbtnFish;
        GameClient.ComStateMachine mbtnChargeStatus;
        UnityEngine.UI.Text mplayerName;
        UnityEngine.UI.Image mplayerHead;

        protected override void _InitScriptBinder()
        {
            mbtnReturn = mScriptBinder.GetObject("btnReturn") as UnityEngine.UI.Button;
            mbtnSetting = mScriptBinder.GetObject("btnSetting") as UnityEngine.UI.Button;
            mbtnFish = mScriptBinder.GetObject("btnFish") as UnityEngine.UI.Button;
            mbtnChargeStatus = mScriptBinder.GetObject("btnChargeStatus") as GameClient.ComStateMachine;
            mplayerName = mScriptBinder.GetObject("playerName") as UnityEngine.UI.Text;
            mplayerHead = mScriptBinder.GetObject("playerHead") as UnityEngine.UI.Image;
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
            if(null != mbtnFish)
            {
                mbtnFish.onClick.AddListener(_OnClickEnterFish);
            }
		}

        void _OnClickEnterFish()
        {
            UIManager.Instance().OpenFrame<FishMainFrame>(5);
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