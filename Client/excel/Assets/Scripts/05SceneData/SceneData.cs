using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public class SceneData : ScriptableObject
	{
		public DSceneBaseData baseData = new DSceneBaseData ();
	}

	[System.Serializable]
	public class DSceneBaseData
	{
		//唯一id
		public int id;
		//资源id
		public int resId;
		//名称
		public string name;
		//逻辑位置
		public Vector3 position;
		//预制体路径
		public string prefabPath;
		//相机参数
		public float CameraLookHeight = 1.0f;
		public float CameraDistance = 10.0f;
		public float CameraAngle = 20.0f;
		public float CameraNearClip = 0.30f;
		public float CameraFarClip = 50.0f;
		public float CameraSize = 3.0f;
		public Vector2 CameraZRange;
		public Vector2 CameraXRange;
		public bool CameraPersp = false;
		public float CameraX = 0.0f;
		public float CameraZ = 0.0f;
	}
}