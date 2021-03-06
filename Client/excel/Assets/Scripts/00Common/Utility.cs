﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameClient;
using System;
using System.Security.Cryptography;
using System.Text;

public static class Utility
{
    public static GameObject FindChild(GameObject goRoot, string path)
    {
        if (null != goRoot)
        {
            var paths = path.Split('/');
            Transform root = goRoot.transform;
            for (int i = 0; i < paths.Length && root != null; ++i)
            {
                if (!string.IsNullOrEmpty(paths[i]))
                {
                    root = root.Find(paths[i]);
                }
            }

            if (null != root)
            {
                return root.gameObject;
            }
        }

        if (null != goRoot)
        {
            Debug.LogErrorFormat("can not find child path = {0}", path);
        }
        else
        {
            Debug.LogErrorFormat("can not find child ,goRoot is null");
        }

        return null;
    }

    public static T FindComponent<T>(GameObject root, string path) where T : Component
    {
        GameObject go = FindChild(root, path);
        if (null != go)
        {
            T com = go.GetComponent<T>() as T;
            if (null != com)
            {
                return com;
            }
        }

        Debug.LogErrorFormat("find component failed ,has not component on {0}", path);

        return null;
    }

    public static void AttachTo(GameObject child, GameObject parent)
    {
        if (null != child && null != parent)
        {
            child.transform.SetParent(parent.transform, false);
        }
    }

    public static void CustomActive(this MonoBehaviour com, bool bActive)
    {
        if (com == null)
        {
            return;
        }

        if (com != null)
        {
            com.gameObject.CustomActive(bActive);
        }
    }

    public static void SetAction(this GameClient.ComScriptBinder script,string action)
    {
        if(null != script)
        {
            script._SetAction(action);
        }
    }

    public static void CustomActive(this GameObject gameObject, bool bActive)
    {
        if (gameObject == null)
        {
            return;
        }

        if (gameObject.activeSelf != bActive)
        {
            gameObject.SetActive(bActive);
        }
    }

	public static void LoadSprite(ref Image img,Sprite sprite)
	{
		if (null != img) 
		{
			img.sprite = sprite;
		}
	}

    public static void LogToScreen(string fmt, params object[] argvs)
    {
        string value = string.Format(fmt, argvs);
        if (!string.IsNullOrEmpty(value))
        {
            EventManager.Instance().SendEvent(ClientEvent.CE_LOG_TO_SCREEN, value);
        }
    }

    public static string GetAssetPath()
    {
        string url = string.Empty;
#if UNITY_ANDROID   //Android
        url = "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE  //iPhone
        url = Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        url = "file://" + Application.dataPath + "/StreamingAssets/";
#endif
        return url;
    }
    
}