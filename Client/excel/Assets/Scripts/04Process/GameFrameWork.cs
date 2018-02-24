using UnityEngine;
using System.Collections;

namespace GameClient
{
	class GameFrameWork : MonoBehaviour 
	{
		// Use this for initialization
		void Start() 
		{
			GameObject.DontDestroyOnLoad (this);
			//initialize data here , for table data ,net work, and so on ...
			SceneManager.Instance ().Initialize ();
		}

		void OnDestroy()
		{
			SceneManager.Instance ().UnInitialize ();
		}
	}
}