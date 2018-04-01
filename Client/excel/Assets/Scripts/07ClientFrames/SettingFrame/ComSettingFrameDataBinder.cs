using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	public class ComSettingFrameDataBinder : MonoBehaviour 
	{
		enum TabSettingType
		{
			TAB_PERSONALINFO = 0,
			TAB_SOUND_SETTING,
			TAB_ABOUT_US,
			TAB_COUNT,
		}

		public Toggle[] toggles = new Toggle[0];
		public ComStateMachine[] status = new ComStateMachine[0];
		public void InitTabs()
		{
			for (int i = 0; i < toggles.Length; ++i) 
			{
				if (null != toggles [i]) 
				{
					toggles [i].onValueChanged.RemoveAllListeners ();
					int k = i;
					ComStateMachine state = null;
					if (i < status.Length) 
					{
						state = status [i];
					}
					toggles [i].onValueChanged.AddListener ((bool bValue) => {
						if(bValue)
						{
							if(null != state)
							{
								state.Key = 1;
							}
							OnTabSelected(k);
						}
						else
						{
							if(null != state)
							{
								state.Key = 0;
							}
						}
					});
				}
			}
			toggles [0].isOn = true;
		}

		public void OnTabSelected(int tabId)
		{
			if (tabId >= (int)TabSettingType.TAB_PERSONALINFO && tabId < (int)TabSettingType.TAB_COUNT) 
			{
				switch ((TabSettingType)tabId) 
				{
				case TabSettingType.TAB_PERSONALINFO:
					{
						
					}
					break;
				case TabSettingType.TAB_SOUND_SETTING:
					{
						
					}
					break;
				case TabSettingType.TAB_ABOUT_US:
					{
						
					}
					break;
				}

				Debug.LogFormat ("tab selected {0} !!", (TabSettingType)tabId);
			}
		}

		void OnDestroy()
		{
			for (int i = 0; i < toggles.Length; ++i) 
			{
				if (null != toggles [i]) 
				{
					toggles [i].onValueChanged.RemoveAllListeners ();
					toggles [i] = null;
				}
			}
		}
	}
}