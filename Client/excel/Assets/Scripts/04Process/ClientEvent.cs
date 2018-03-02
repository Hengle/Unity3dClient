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
        CE_LOG_TO_SCREEN,
        CE_SEND_MSG_TO_NORMAL_SOCKET,
        CE_ON_LOGIN_FRAME_OPENED,
        CE_FIXED_END = 128,
        CE_COUNT = 256,
    }
}