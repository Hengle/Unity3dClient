using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
    public enum ClientEvent
    {
        CE_INVALID = -1,
        CE_LOGIN_TEST,
        CE_FIXED_END = 128,
        CE_COUNT = 256,
    }
}