using UnityEngine;
using System.Collections;
using System;
using ProtoBuf;
using ProtoBuf.Meta;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GameClient
{
	public class AssetManager : Singleton<AssetManager> 
	{
		private const string RES_CONFIG_TABLE_DATA_PATH = "Data/Table/";

        public string GetTablePath(Type type)
		{
			if (null != type) 
			{
				return RES_CONFIG_TABLE_DATA_PATH + type.Name;
			}
			return string.Empty;
		}

		public bool LoadAllTables(ref Dictionary<Type,Dictionary<int,object>> tableDic)
		{
			tableDic.Clear ();
            for (int i = 0; i < TableList.Values.Length; ++i) 
			{
				var type = TableList.Values[i];
                Dictionary<int, object> table = null;

                if (!_LoadTable(type, ref table))
                {
                    return false;
                }

                tableDic.Add (type, table);
			}
			return true;
		}

        bool _LoadTable(Type type,ref Dictionary<int, object> table)
        {
            table = null;

            var path = GetTablePath(type);
            AssetBinary res = AssetLoader.Instance().LoadRes(path, typeof(AssetBinary)).obj as AssetBinary;
            if (null == res)
            {
                Debug.LogErrorFormat("can not find textasset type = {0}", type.Name);
                return false;
            }

            table = _ConvertTableObject(res, type) as Dictionary<int, object>;
            if (null == table)
            {
                Debug.LogErrorFormat("table load failed name = {0}", type.Name);
                return false;
            }

            return true;
        }

        public bool LoadTable(Type type, ref Dictionary<int, object> table)
        {
            if(!_LoadTable(type,ref table))
            {
                return false;
            }

            return true;
        }

        public object _ConvertTableObject(AssetBinary asset,Type type)
		{
			if (asset == null || null == type)
			{
				return null;
			}
				
			var IDMap = type.GetProperty("ID").GetGetMethod();
			if (null == IDMap)
			{
				return null;
			}

			Dictionary<int,object> table = new Dictionary<int, object> ();
            bool bCanParse = Serializer.CanParse(type);
			byte[] data = asset.bytes;
            
            for (int i = 0; i < data.Length;)
			{
				int len = 0;
				for (int j = i; j < i + 8; ++j)
				{
					if (data[j] > 0)
						len = len * 10 + (data[j] - '0');
				}

				i += 8;

                MemoryStream mDataStream = new MemoryStream(data, i, len);

                try
				{
					object tableData = null;

					if(bCanParse) 
					{
						tableData = Serializer.ParseEx(type, mDataStream);
					}
					else
					{
						tableData = Serializer.DeserializeEx(type, mDataStream);
					}

					if (tableData == null)
					{
						Debug.LogErrorFormat("table data is nil {0}, {1}", type.Name, i);
					}
					else
					{
						var id = (int)IDMap.Invoke(tableData,null);
						if(!table.ContainsKey(id))
						{
							table.Add(id,tableData);
						}
						else
						{
							Debug.LogErrorFormat("table {0} key repeated id = {1}",type.Name,id);
							return null;
						}
					}
				}
				catch (Exception e)
				{
					Debug.LogErrorFormat("{0} : *.cs don't match the *.xls, delete the *.proto, regenerate the *.cs", type.Name);
					Debug.LogErrorFormat("error deserialize at line {0}, with error {1}", i + 1, e.ToString());

					string ErrorMsg = "表格："+type.Name+" 加载失败，原因："+e.Message;

					Debug.LogErrorFormat("【读表错误!】 {0}",ErrorMsg);

					return null;
				}

				i += len;
			}

			return table;
		}

		public bool Initilaize()
		{
			return true;
		}
	}
}