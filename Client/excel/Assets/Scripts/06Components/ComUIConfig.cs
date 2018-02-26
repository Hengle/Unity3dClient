using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public enum UILayer
    {
        UL_BOTTOM = 0,
        UL_MIDDLE,
        UL_HIGH,
        UI_TOP,
        UI_COUNT,
    }

    public class ComUIConfig : MonoBehaviour
    {
        public GameObject[] goLayers = new GameObject[(int)UILayer.UI_COUNT];
    }
}