using UnityEngine;
using System.Collections;

namespace GameClient
{
	public class AssetBinary : ScriptableObject 
	{
		[HideInInspector]
		public byte[] bytes = new byte[0];
	}
}