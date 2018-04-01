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


    public class ComUIConfig : MonoBehaviour
    {
        public GameObject[] goLayers = new GameObject[(int)FrameLayer.COUNT];
    }
}