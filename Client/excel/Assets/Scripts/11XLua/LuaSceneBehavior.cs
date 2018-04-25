/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;
using GameClient;

[LuaCallCSharp]
public class LuaSceneBehavior : MonoBehaviour
{
    public TextAsset luaScript;
    public object luaParam = null;
    private ELuaOpenAction luaOpenScene;
    private EAction luaUpdateScene;
    private EAction luaCloseScene;

    private LuaTable scriptEnv;

    void Awake()
    {
        scriptEnv = GameClient.GameFrameWork.LuaInstance.NewTable();

        LuaTable meta = GameClient.GameFrameWork.LuaInstance.NewTable();
        meta.Set("__index", GameClient.GameFrameWork.LuaInstance.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();
    }

    public void OnCloseScene()
    {
        if(null != luaCloseScene)
        {
            luaCloseScene();
        }
    }

    public void DestroyWithScene()
    {
        luaParam = null;
        luaCloseScene = null;
        luaUpdateScene = null;
        luaOpenScene = null;
        if (null != scriptEnv)
        {
            scriptEnv.Dispose();
            scriptEnv = null;
        }
        luaScript = null;
    }

    public void OnOpenScene(Scene scene)
    {
        if(null == scene)
        {
            LogManager.Instance().LogErrorFormat("luaSceneBehavior can not execute open, param scene is null !!!");
            return;
        }

        if (null == scriptEnv)
        {
            LogManager.Instance().LogErrorFormat("scriptEnv is Invalid when to open {0} scene", scene.GetName());
            return;
        }

        if (null == luaScript)
        {
            LogManager.Instance().LogErrorFormat("missing luaScript when to open {0} scene", scene.GetName());
            return;
        }

        var tables = GameClient.GameFrameWork.LuaInstance.DoString(luaScript.text, scene.GetName(), scriptEnv);
        if (null == tables || tables.Length <= 0)
        {
            LogManager.Instance().LogErrorFormat("luaScript is Invalid when to open {0} scene", scene.GetName());
            return;
        }

        LuaTable luaTable = (tables[0] as LuaTable);
        if (null == luaTable)
        {
            LogManager.Instance().LogErrorFormat("luaTable convert failed when to open {0} scene", scene.GetName());
            return;
        }

        scriptEnv.Set("self", luaTable);
        luaTable.Set("scene", scene);
        luaOpenScene = luaTable.Get<ELuaOpenAction>("OnCreate");
        luaUpdateScene = luaTable.Get<EAction>("OnUpdate");
        luaCloseScene = luaTable.Get<EAction>("OnDestroy");

        if (null != luaOpenScene)
        {
            luaOpenScene(luaParam);
            luaParam = null;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (luaUpdateScene != null)
        {
            luaUpdateScene();
        }
    }
}
