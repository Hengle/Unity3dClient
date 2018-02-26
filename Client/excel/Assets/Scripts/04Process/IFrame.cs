using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public interface IFrame
    {
        int getFrameId();
        FrameTypeID getFrameTypeId();
        int getFrameHashCode();
        void openFrame(int iId, FrameTypeID type,object userData);
        void closeFrame(int iHashCode);
    }
}