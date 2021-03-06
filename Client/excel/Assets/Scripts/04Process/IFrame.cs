﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using Scripts.UI;

namespace GameClient
{
    [LuaCallCSharp]
    public interface IFrame
    {
        int getFrameId();
        int getFrameTypeId();
        int getFrameHashCode();
        void openFrame(int iId, int type,object userData, GameObject parent);
        void closeFrame();
        FrameLayer getLayer();
        string getPrefabPath();
        bool needLuaBehavior();
        FrameState getFrameState();
        object getUserData();

        void RegisterEvent(int eventId, LuaEvent handler);
        void UnRegisterEvent(int eventId, LuaEvent handler);
        void SendEvent(int eventId, object argv);
        void SetObjectStatus(string objName, int status);
        void SetText(string objName, string value);
        void SetImage(string objName, string path);
        Object GetObject(string objName);
        void AddChildFrame(IFrame frame);
        void CloseChildFrame(IFrame frame);
    }
}