using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    class GlobalDataManager : Singleton<GlobalDataManager>
    {
        public ComUIConfig uiConfig;

        public bool Initialize(GameFrameWork handle)
        {
            uiConfig = Utility.FindComponent<ComUIConfig>(handle.gameObject, "Environment/UICamera");
            if(null == uiConfig)
            {
                return false;
            }

            return true;
        }
    }
}