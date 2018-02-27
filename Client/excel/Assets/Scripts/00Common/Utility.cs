using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	public  class Utility
	{
		public static GameObject FindChild(GameObject goRoot,string path)
		{
			if (null != goRoot) 
			{
				var paths = path.Split ('/');
				Transform root = goRoot.transform;
				for (int i = 0; i < paths.Length && root != null; ++i) 
				{
					if (!string.IsNullOrEmpty (paths [i])) 
					{
						root = root.Find (paths [i]);
					}
				}

				if (null != root) 
				{
					return root.gameObject;
				}
			}

			if (null != goRoot) 
			{
				Debug.LogErrorFormat ("can not find child path = {0}", path);
			} 
			else 
			{
				Debug.LogErrorFormat ("can not find child ,goRoot is null");
			}

			return null;
		}

		public static T FindComponent<T>(GameObject root,string path) where T : Component
		{
			GameObject go = FindChild (root, path);
			if (null != go) 
			{
				T com = go.GetComponent<T> () as T;
				if (null != com) 
				{
					return com;
				}
			}

			Debug.LogErrorFormat ("find component failed ,has not component on {0}", path);

			return null;
		}

        public static void AttachTo(GameObject child,GameObject parent)
        {
            if(null != child && null != parent)
            {
                child.transform.SetParent(parent.transform,false);
            }
        }

    }
}