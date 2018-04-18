using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public enum FrameLayer
    {
        BOTTOM = 0,
        MIDDLE,
        HIGH,
        TOP,
        COUNT,
    }
    [LuaCallCSharp]
    public enum FrameState
    {
        FS_INVALID = 0,
        FS_OPENING,
        FS_OPEN,
        FS_CLOSING,
        FS_CLOSED,
    }

    public class ComUIConfig : MonoBehaviour
    {
        public GameObject[] goLayers = new GameObject[(int)FrameLayer.COUNT];
    }
}