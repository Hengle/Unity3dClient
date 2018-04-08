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

[CSharpCallLua]
public delegate void EAction();

[LuaCallCSharp]
public class LuaBehaviour : MonoBehaviour
{
    public TextAsset luaScript;
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 

    private EAction luaOpenFrame;
    private EAction luaUpdateFrame;
    private EAction luaCloseFrame;

    private LuaTable scriptEnv;

    void Awake()
    {
        scriptEnv = GameClient.GameFrameWork.LuaInstance.NewTable();

        LuaTable meta = GameClient.GameFrameWork.LuaInstance.NewTable();
        meta.Set("__index", GameClient.GameFrameWork.LuaInstance.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();
    }

    public void OnCloseFrame()
    {
        if(null != luaCloseFrame)
        {
            luaCloseFrame();
            luaCloseFrame = null;
        }
        luaUpdateFrame = null;
        luaOpenFrame = null;
        if(null != scriptEnv)
        {
            scriptEnv.Dispose();
            scriptEnv = null;
        }
        luaScript = null;
    }

    public void OnOpenFrame(ClientFrame clientFrame)
    {
        if(null == scriptEnv)
        {
            LogManager.Instance().LogErrorFormat("scriptEnv is Invalid when to open {0} frame", clientFrame.GetType());
            return;
        }
        scriptEnv.Set("self", clientFrame);
        if(null == luaScript)
        {
            LogManager.Instance().LogErrorFormat("missing luaScript when to open {0} frame", clientFrame.GetType());
            return;
        }

        var tables = GameClient.GameFrameWork.LuaInstance.DoString(luaScript.text, "LuaBehaviour", scriptEnv);
        if(null == tables || tables.Length <= 0)
        {
            LogManager.Instance().LogErrorFormat("luaScript is Invalid when to open {0} frame", clientFrame.GetType());
            return;
        }

        LuaTable luaTable = (tables[0] as LuaTable);
        if(null == luaTable)
        {
            LogManager.Instance().LogErrorFormat("luaTable convert failed when to open {0} frame", clientFrame.GetType());
            return;
        }

        luaOpenFrame = luaTable.Get<EAction>("OnOpenFrame");
        luaUpdateFrame = luaTable.Get<EAction>("OnUpdateFrame");
        luaCloseFrame = luaTable.Get<EAction>("OnCloseFrame");

        if (null != luaOpenFrame)
        {
            luaOpenFrame();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (luaUpdateFrame != null)
        {
            luaUpdateFrame();
        }
	}
}
