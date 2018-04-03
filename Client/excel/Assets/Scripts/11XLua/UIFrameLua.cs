using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    class UIFrameLua
    {
        public static IFrame OpenFrameLua(int frameTypeId, object userData = null, int frameId = -1)
        {
            return UIManager.Instance().OpenFrameLua(frameTypeId, userData, frameId);
        }

        public static void CloseFrameLua(int frameTypeId, int frameId = -1)
        {
            UIManager.Instance().CloseFrameLua(frameTypeId, frameId);
        }

        public static void CloseFrame(IFrame frame)
        {
            if(null != frame)
            {
                UIManager.Instance().CloseFrameLua(frame.getFrameTypeId(), frame.getFrameId());
            }
        }
    }
}
