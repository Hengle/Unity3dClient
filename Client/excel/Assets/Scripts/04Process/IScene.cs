using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public interface IScene
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
        void SetAction(SceneAction eAction);
        SceneAction GetAction();
    }
}