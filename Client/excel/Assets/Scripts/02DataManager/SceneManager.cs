using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	class SceneManager : Singleton<SceneManager>
	{
		Scene current = null;

		public bool Initialize()
		{
			if (!TableManager.Instance ().Initialize ()) 
			{
				return false;
			}
			return true;
		}

		private Scene _CreateScene(int iSceneId)
		{
			var sceneItem = TableManager.Instance ().GetTableItem<ProtoTable.SceneTable> (iSceneId);
			if (null == sceneItem) 
			{
				Debug.LogErrorFormat ("can not find scene resource for sceneid = {0}", iSceneId);
				return null;
			}

			Scene scene = new Scene ();
			//scene.Create (sceneItem,m_environment);

			return scene;
		}

		public void SwitchScene(int iSceneId)
		{
			
		}

		public void UnInitialize()
		{
			
		}
	}
}