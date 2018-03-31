using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	public class ComSpriteList : MonoBehaviour 
	{
		public Image sprite;
		public string[] paths = new string[0];
		public int loops = 1;
		public int interval = 1;
		public bool playOnAwake = false;
		int _index = 0;
		bool _start = false;
		Sprite[] _pools = null;
		int _count = 0;
		int _loops = 0;

		void _LoadAllSprites()
		{
			if (null == _pools) 
			{
				_pools = new Sprite[paths.Length];
			}

			if (paths.Length > 0) 
			{
				for (int i = 0; i < paths.Length; ++i) 
				{
                    _pools[i] = AssetLoader.Instance().LoadRes(paths[i], typeof(Sprite)).obj as Sprite;
                }
			}
		}

		Sprite _GetSprite(int index)
		{
			if (index >= 0 && null != _pools && index < _pools.Length) 
			{
				return _pools [index];
			}
			return null;
		}

		bool _StepNext()
		{
			if (_index >= 0 && _index < _pools.Length) 
			{
				int _pre = _index;
				_index = (_index + 1 ) % _pools.Length;
				return _pre != _index;
			}
			return false;
		}

		void _Reset()
		{
			_index = 0;
			_start = false;
			_count = 0;
			_loops = 0;
		}

		void Awake()
		{
			_LoadAllSprites ();
			_Reset ();
			Utility.LoadSprite (ref sprite, _GetSprite (_index));
		}

		void Update()
		{
			if (!_start) 
			{
				return;
			}

			++_count;
			if (_count >= interval) 
			{
				_count = 0;
				if (_StepNext ()) 
				{
					Utility.LoadSprite (ref sprite,_GetSprite(_index));
				}

				if (_pools.Length == 0 || _pools.Length - 1 == _index) 
				{
					if (loops >= 0) 
					{
						++_loops;
						if (_loops >= loops) 
						{
							_Reset ();
						}
					}
				}
			}
		}
	}
}