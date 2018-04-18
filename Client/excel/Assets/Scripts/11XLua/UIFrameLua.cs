using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    class UIFrameLua
    {
        public static IFrame OpenFrameLua(int frameTypeId, object userData = null, int frameId = -1,GameObject parent = null)
        {
            return UIManager.Instance().OpenFrame(frameTypeId, userData, frameId,parent);
        }

        public static void CloseFrameLua(int frameTypeId, int frameId = -1)
        {
            UIManager.Instance().CloseFrame(frameTypeId, frameId);
        }

        public static void CloseFrame(IFrame frame)
        {
            if(null != frame)
            {
                UIManager.Instance().CloseFrame(frame.getFrameTypeId(), frame.getFrameId());
            }
        }
    }
}
