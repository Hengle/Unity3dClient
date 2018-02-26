using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public enum FrameTypeID
    {
        FTID_INVALID = -1,
        FTID_LOGIN,
        FTID_COUNT,
    }

    class UIManager : Singleton<UIManager>
    {
        public int MakeFrameHashCode(int frameId, FrameTypeID frameTypeId)
        {
            return (frameId & 0xFFFF) | (((int)frameTypeId & 0xFFFF) << 16);
        }

        public IFrame OpenFrame(FrameTypeID frameTypeId,int frameId = -1)
        {

        }
	}
}