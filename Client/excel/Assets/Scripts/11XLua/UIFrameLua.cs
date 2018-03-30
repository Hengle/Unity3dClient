using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    class UIFrameLua
    {
        public static IFrame OpenFrameLua(FrameTypeID frameTypeId, object userData = null, int frameId = -1)
        {
            return UIManager.Instance().OpenFrameLua(frameTypeId, userData, frameId);
        }

        public static void CloseFrameLua(FrameTypeID frameTypeId, int frameId = -1)
        {
            UIManager.Instance().CloseFrameLua(frameTypeId, frameId);
        }
    }
}
