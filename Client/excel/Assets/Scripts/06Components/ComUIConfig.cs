using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
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