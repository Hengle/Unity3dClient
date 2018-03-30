using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public interface IFrame
    {
        int getFrameId();
        FrameTypeID getFrameTypeId();
        int getFrameHashCode();
        void openFrame(int iId, FrameTypeID type,object userData);
        void closeFrame();
        FrameLayer getLayer();

        void SetObjectStatus(string objName, int status);
        void SetText(string objName, string value);
        void SetImage(string objName, string path, string name);
    }
}