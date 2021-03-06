﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace GameClient
{
	public class TableManager : Singleton<TableManager> 
	{
        Dictionary<Type, Dictionary<int, object>> mTableDic = null;

		public bool Initialize()
		{
			var begin = System.DateTime.Now.Ticks;
			if (!AssetManager.Instance ().LoadAllTables (ref mTableDic)) 
			{
                return false;
			}
			var delta = System.DateTime.Now.Ticks - begin;
            LogManager.Instance().LogFormat("<color=#00ff00>load table cost {0} ms</color>", delta / 10000);
			return true;
		}

        public void ClearAll()
        {
            if (null != mTableDic)
            {
                mTableDic.Clear();
                mTableDic = null;
            }
        }

        public bool IsValid()
        {
            return null != mTableDic;
        }

        public void LoadTableResources(Dictionary<Type, Dictionary<int, object>> table)
        {
            mTableDic = table;
        }

		public T GetTableItem<T> (int id) where T : class,new()
		{
			return GetTableItem (typeof(T), id) as T;
		}

		public object GetTableItem(Type type,int id)
		{
			if (null != type && mTableDic.ContainsKey (type)) 
			{
				if (mTableDic [type].ContainsKey (id)) 
				{
					return mTableDic [type] [id];
				}
			}
			return null;
		}

		public Dictionary<int,object> GetTable(Type type)
		{
			if (null != type && mTableDic.ContainsKey (type)) 
			{
				return mTableDic [type];
			}
			return null;
		}

		public void Travel<T>(UnityAction<T> action,System.Predicate<T> condition = null) where T : class,new()
		{
			var tableItems = GetTable (typeof(T));
			if (null != tableItems) 
			{
				var enumerator = tableItems.GetEnumerator ();
				while (enumerator.MoveNext ()) 
				{
					if (null == condition || condition (enumerator.Current.Value as T)) 
					{
						if (null != action) 
						{
							action.Invoke (enumerator.Current.Value as T);
						}
					}
				}
			}
		}
	}
}