using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public interface IScene
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
        void SetAction(SceneAction eAction);
        SceneAction GetAction();
        string GetName();
        int GetID();
        bool Create(int iId);
    }
}