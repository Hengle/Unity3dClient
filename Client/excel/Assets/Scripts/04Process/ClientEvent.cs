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
        CE_ON_SET_LOADING_TITLE,
        CE_ON_SET_LOADING_SUB_TITLE,
        CE_ON_SET_LOADING_PROCESS,
        CE_ON_SET_LOADING_SUB_PROCESS,
        CE_ON_SET_LOADING_FINISH,
        CE_CHANGE_SCENE,

        CE_CREATE_FISH,
        CE_FISH_CHANGE_SCENE,
        CE_FISH_PLAYER_UP_SCORE_CHANGED,
        CE_FISH_PLAYER_CANNON_CHANGED,
        CE_FISH_LOCK_FISH,

        CE_LUA_EVENT_START = 64,
        CE_FIXED_END = 128,

        CE_COUNT = 256,
    }
}