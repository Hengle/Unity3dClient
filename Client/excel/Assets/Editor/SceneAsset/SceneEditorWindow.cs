using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GameClient;
using System;
using System.IO;

namespace SceneEditor
{
	class SceneEditorWindow : EditorWindow 
	{
		[MenuItem ("GameNative/SceneEdit/Window")]
		static void AddWindow ()
		{       
			//创建窗口
			Rect  wr = new Rect (0,0,480,600);
			SceneEditorWindow window = (SceneEditorWindow)EditorWindow.GetWindowWithRect (typeof (SceneEditorWindow),wr,true,"场景编辑");	
			window.Show();

		}

		private void LoadEnvironment()
		{
			//load editor root
			if (null == goEditorRoot)
			{
				goEditorRoot = new GameObject ("EditorRoot");
				AttachTo (goEditorRoot, null);
			}
			//load scene root
			if (null == goSceneRoot)
			{
				goSceneRoot = new GameObject ("SceneRoot");
				AttachTo (goSceneRoot, goEditorRoot);
			}
			//load environment
			if (null == goEnvironment) 
			{
				UnityEngine.Object obj = Resources.Load<GameObject> (EnvironmentPath);
				if (null != obj) {
					goEnvironment = PrefabUtility.InstantiatePrefab (obj) as GameObject;
					AttachTo (goEnvironment, goEditorRoot);
				}
			}
			//load camera
			if (null == camera3D)
			{
				if (null != goEnvironment) 
				{
					var goCamera = GameClient.Utility.FindChild (goEnvironment, "FollowPlayer/Main Camera");
					if (null != goCamera) {
						camera3D = goCamera.GetComponent<Camera> ();
					}
				}
			}
		}

		private void _LoadScenePrefab(GameObject curPrefab)
		{
			string assetPath = null == curPrefab ? baseData.prefabPath : AssetDatabase.GetAssetPath (curPrefab);
			if (!string.Equals (assetPath, baseData.prefabPath)) 
			{
				//destroy first
				if (null != goScene) 
				{
					GameObject.DestroyImmediate (goScene);
					goScene = null;
				}
				//assign path
				baseData.prefabPath = assetPath.Substring (17, assetPath.Length - 17 - 7);
			}

			//load scene prefab
			if (!string.IsNullOrEmpty (baseData.prefabPath)) 
			{
				UnityEngine.Object SceneObj = Resources.Load (baseData.prefabPath);
				if (null == SceneObj)
				{
					Debug.LogFormat ("load {0} failed !!!", baseData.prefabPath);
				} 
				else
				{
					goScene = GameObject.Instantiate (SceneObj) as GameObject;
				}
				prefab = SceneObj as GameObject;
			}

			if (null != goScene && null != goSceneRoot)
			{
				goScene.transform.SetParent (goSceneRoot.transform,true);
			}
		}

		protected void LoadDefaultAsset(string path =  "Sailiya.asset")
		{
			var assetPath = SCENE_DATA_ASSET_PATH + path;
			if (File.Exists (assetPath)) 
			{
				SceneData oldAsset = AssetDatabase.LoadAssetAtPath<SceneData> (assetPath);
				baseData = oldAsset.baseData;
				LoadEnvironment ();
				_LoadScenePrefab (null);
				_ApplyData ();
			}
			else 
			{
				baseData = new DSceneBaseData ();
			}
		}

		GameObject goEditorRoot = null;
		GameObject goSceneRoot = null;
		GameObject goScene = null;
		GameObject goEnvironment = null;
		Camera camera3D = null;
		GameObject prefab = null;

		protected void OnEnable()
		{
			LoadDefaultAsset ();
		}

		protected void OnDestroy()
		{
			if (null != goEditorRoot) 
			{
				GameObject.DestroyImmediate (goEditorRoot);
				goEditorRoot = null;
			}
			goSceneRoot = null;
			goScene = null;
			goEnvironment = null;
			camera3D = null;
		}

		protected void AttachTo(GameObject goChild,GameObject goRoot)
		{
			if (null != goChild) 
			{
				goChild.transform.SetParent (null == goRoot ? null : goRoot.transform);
				goChild.transform.localPosition = Vector3.zero;
				goChild.transform.localScale = Vector3.one;
				goChild.transform.localRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
			}
		}

		protected void _ApplyData()
		{
			//1 update scene position
			if (null != goSceneRoot) 
			{
				goSceneRoot.transform.localPosition = baseData.position;
			}
			//2 update camera
			if (null != camera3D) 
			{
				Debug.LogFormat ("<color=#00ff00>load camera succeed !!!</color>");
				camera3D.transform.localPosition = new Vector3 (baseData.CameraX, camera3D.transform.localPosition.y, baseData.CameraZ);
				camera3D.orthographicSize = baseData.CameraSize;
				camera3D.nearClipPlane = baseData.CameraNearClip;
				camera3D.farClipPlane = baseData.CameraFarClip;
				camera3D.transform.localRotation = Quaternion.Euler (new Vector3 (baseData.CameraAngle, 0.0f, 0.0f));
			} 
			else 
			{
				Debug.LogErrorFormat ("<color=#ff0000>load camera failed !!!</color>");
			}
		}

		DSceneBaseData baseData = null;
		public static string SCENE_DATA_ASSET_PATH = "Assets/Resources/Data/SceneData/";
		public static string EnvironmentPath = "Prefabs/Environment";

		protected void OnGUI()
		{
			_OnGUIScene ();
			_OnGUICamera ();

			if (GUI.changed) 
			{
				_LoadScenePrefab (prefab);
				_ApplyData ();
			}

			EditorGUILayout.BeginHorizontal ();
			_SaveData ();
			EditorGUILayout.EndHorizontal ();
		}

		protected void _OnGUIScene()
		{
			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("场景ID",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.id = EditorGUILayout.IntField (baseData.id,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("资源ID",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.resId = EditorGUILayout.IntField (baseData.resId,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("场景名称",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.name = EditorGUILayout.TextField (baseData.name,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			baseData.position = EditorGUILayout.Vector3Field ("初始位置",baseData.position);
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("场景预制体",GUILayout.Width(100));
			GUI.color = Color.white;
			prefab = EditorGUILayout.ObjectField (prefab,typeof(GameObject),GUILayout.Width(100)) as GameObject;
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("预制体路径",GUILayout.Width(100));
			GUI.color = Color.white;
			EditorGUILayout.LabelField(baseData.prefabPath);
			EditorGUILayout.EndHorizontal ();
		}

		protected void _OnGUICamera()
		{
			EditorGUILayout.BeginVertical ();
			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("相机高度",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraLookHeight = EditorGUILayout.FloatField (baseData.CameraLookHeight,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("相机距离",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraDistance = EditorGUILayout.FloatField (baseData.CameraDistance,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("相机角度",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraAngle = EditorGUILayout.FloatField (baseData.CameraAngle,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("近裁剪面",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraNearClip = EditorGUILayout.FloatField (baseData.CameraNearClip,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("远裁剪面",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraFarClip = EditorGUILayout.FloatField (baseData.CameraFarClip,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("CameraSize",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraSize = EditorGUILayout.FloatField (baseData.CameraSize,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("透视投影",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraPersp = EditorGUILayout.Toggle(baseData.CameraPersp,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("相机x位置",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraX = EditorGUILayout.FloatField(baseData.CameraX,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			baseData.CameraXRange = EditorGUILayout.Vector2Field("相机x范围",baseData.CameraXRange);

			EditorGUILayout.BeginHorizontal ();
			GUI.color = Color.green;
			EditorGUILayout.LabelField("相机z位置",GUILayout.Width(100));
			GUI.color = Color.white;
			baseData.CameraZ = EditorGUILayout.FloatField(baseData.CameraZ,GUILayout.Width(100));
			EditorGUILayout.EndHorizontal ();

			baseData.CameraZRange = EditorGUILayout.Vector2Field("相机z范围",baseData.CameraZRange);

			EditorGUILayout.EndVertical ();
		}

		protected void _SaveData()
		{
			if (GUILayout.Button ("保存场景")) 
			{
				try
				{
					var assetPath = SCENE_DATA_ASSET_PATH + baseData.name + ".asset";
					if (File.Exists (assetPath)) 
					{
						SceneData oldAsset = AssetDatabase.LoadAssetAtPath<SceneData> (assetPath);
						oldAsset.baseData = baseData;
						EditorUtility.SetDirty (oldAsset);
						AssetDatabase.SaveAssets ();
					} 
					else
					{
						SceneData asset = ScriptableSingleton<SceneData>.CreateInstance<SceneData> ();
						asset.baseData = baseData;
						AssetDatabase.CreateAsset (asset, assetPath);
					}
					Debug.LogFormat("<color=#00ff00> save scene <color=#ffff00>{0}.asset</color> succeed !!!</color>",baseData.name);
				}
				catch(Exception e) 
				{
					Debug.LogErrorFormat ("save scene {0}.asset failed !!!", baseData.name);
					Debug.LogErrorFormat (e.ToString ());
				}
			}
		}
	}
}