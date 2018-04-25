#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class DelegateBridge : DelegateBridgeBase
    {
		
		public void __Gen_Delegate_Imp0(NetWork.HttpRequestError p0, string p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushNetWorkHttpRequestError(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp1(bool p0, string p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushboolean(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp2(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, p0);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp3(int p0, GameClient.ComScriptBinder p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                translator.Push(L, p1);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp4(int p0, GameClient.ComScriptBinder p1, bool p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                translator.Push(L, p1);
                LuaAPI.lua_pushboolean(L, p2);
                
                int __gen_error = LuaAPI.lua_pcall(L, 3, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public object __Gen_Delegate_Imp5(UnityEngine.GameObject p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, p0);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                object __gen_ret = translator.GetObject(L, err_func + 1, typeof(object));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp6(Scripts.UI.ComUIListElementScript p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, p0);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp7(Scripts.UI.ComUIListElementScript p0, bool p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, p0);
                LuaAPI.lua_pushboolean(L, p1);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp8()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                
                int __gen_error = LuaAPI.lua_pcall(L, 0, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp9(bool p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushboolean(L, p0);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
        
		static DelegateBridge()
		{
		    Gen_Flag = true;
		}
		
		public override Delegate GetDelegateByType(Type type)
		{
		
		    if (type == typeof(NetWork.LocalHttpWebRequestCB))
			{
			    return new NetWork.LocalHttpWebRequestCB(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(NetWork.HttpResponseCb))
			{
			    return new NetWork.HttpResponseCb(__Gen_Delegate_Imp1);
			}
		
		    if (type == typeof(GameClient.LuaEvent))
			{
			    return new GameClient.LuaEvent(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(GameClient.LuaSocketEvent))
			{
			    return new GameClient.LuaSocketEvent(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(GameClient.ComUIListBinderItems.OnListElementVisible))
			{
			    return new GameClient.ComUIListBinderItems.OnListElementVisible(__Gen_Delegate_Imp3);
			}
		
		    if (type == typeof(GameClient.ComUIListBinderItems.OnListElementSelected))
			{
			    return new GameClient.ComUIListBinderItems.OnListElementSelected(__Gen_Delegate_Imp3);
			}
		
		    if (type == typeof(GameClient.ComUIListBinderItems.OnListElementChangeDisplay))
			{
			    return new GameClient.ComUIListBinderItems.OnListElementChangeDisplay(__Gen_Delegate_Imp4);
			}
		
		    if (type == typeof(Scripts.UI.ComUIListScript.OnBindItemDelegate))
			{
			    return new Scripts.UI.ComUIListScript.OnBindItemDelegate(__Gen_Delegate_Imp5);
			}
		
		    if (type == typeof(Scripts.UI.ComUIListScript.OnItemSelectedDelegate))
			{
			    return new Scripts.UI.ComUIListScript.OnItemSelectedDelegate(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(Scripts.UI.ComUIListScript.OnItemVisiableDelegate))
			{
			    return new Scripts.UI.ComUIListScript.OnItemVisiableDelegate(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(Scripts.UI.ComUIListScript.OnItemRecycleDelegate))
			{
			    return new Scripts.UI.ComUIListScript.OnItemRecycleDelegate(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(Scripts.UI.ComUIListScript.OnItemChangeDisplayDelegate))
			{
			    return new Scripts.UI.ComUIListScript.OnItemChangeDisplayDelegate(__Gen_Delegate_Imp7);
			}
		
		    if (type == typeof(GameClient.OnClickMessageBoxOK))
			{
			    return new GameClient.OnClickMessageBoxOK(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(GameClient.OnClickMessageBoxCancel))
			{
			    return new GameClient.OnClickMessageBoxCancel(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(EAction))
			{
			    return new EAction(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(EToggleAction))
			{
			    return new EToggleAction(__Gen_Delegate_Imp9);
			}
		
		    return null;
		}
	}
    
}