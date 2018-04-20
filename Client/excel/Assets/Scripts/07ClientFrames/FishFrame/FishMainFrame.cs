using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public sealed class FishMainFrame : ClientFrame 
	{
        UnityEngine.UI.Button mbtnQuit;
        GameClient.ComFishLogic mcomLogic;
        PathNormalList path = null;

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

            path = AssetLoader.Instance().LoadRes("Xml/path", typeof(PathNormalList)).obj as PathNormalList;

            InvokeManager.Instance().Invoke(this, 3.0f, _BuildFishScene6);
            //InvokeManager.Instance().InvokeRepeate(this, 10.0f, _BuildFishScene4, false);
		}

        void _BuildFishScene1()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_4, 0);
        }

        void _BuildFishScene6()
        {
            FishSceneManager.Instance().BuildSceneFish(SceneKind.SCENE_1, 0);
        }

        int m_cmd = 100050;
        void _OnCreateFish()
        {
            for(int i = 0; i < 5; ++i)
            {
                CMD_S_SceneFish cmd = new CMD_S_SceneFish();
                cmd.fish_id = ++m_cmd;
                cmd.fish_kind = (FishKind)(1 + UnityEngine.Random.Range(0, 21));
                cmd.elapsed = 0;
                int pathId = UnityEngine.Random.Range(0, path.pathes.Length - 1);
                cmd.position = path.pathes[pathId].positions;
                cmd.position_count = cmd.position.Length;
                cmd.tag = 0;
                cmd.tick_count = 0;

                FishDataManager.Instance().ExecuteCmd(cmd);
            }
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
            InvokeManager.Instance().RemoveInvoke(this);
		}
	}
}