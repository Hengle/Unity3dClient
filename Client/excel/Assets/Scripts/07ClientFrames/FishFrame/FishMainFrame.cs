using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public sealed class FishMainFrame : ClientFrame 
	{
        UnityEngine.UI.Button mbtnQuit;
        GameClient.ComFishLogic mcomLogic;

        protected override void _InitScriptBinder()
        {
            mbtnQuit = mScriptBinder.GetObject("btnQuit") as UnityEngine.UI.Button;
            mcomLogic = mScriptBinder.GetObject("comLogic") as GameClient.ComFishLogic;
        }

        protected override sealed void _OnOpenFrame()
		{
			if(null != mbtnQuit)
            {
                mbtnQuit.onClick.AddListener(_OnClickClose);
            }
            //if(null != mcomLogic)
            //{
            //    mcomLogic.createFish(1001, 1);
            //    mcomLogic.createFish(1002, 2);
            //    mcomLogic.createFish(1003, 3);
            //}
            CMD_S_SceneFish cmd = new CMD_S_SceneFish();
            cmd.fish_id = 100050;
            cmd.fish_kind =  FishKind.FISH_HUANGBIANYU;
            cmd.elapsed = 0;
            cmd.position = new Vector2[] { new Vector2 (0, 0), new Vector2(100, 10), new Vector2(150, 350)};
            cmd.position_count = 3;
            cmd.tag = 0;
            cmd.tick_count = 0;
            FishDataManager.Instance().ExecuteCmd(cmd);
		}

        public override bool needLuaBehavior()
        {
            return false;
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