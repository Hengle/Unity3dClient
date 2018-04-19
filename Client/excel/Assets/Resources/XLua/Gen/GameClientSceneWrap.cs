#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class GameClientSceneWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.Scene);
			Utils.BeginObjectRegister(type, L, translator, 0, 11, 7, 7);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Reset", _m_Reset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetID", _m_GetID);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetName", _m_GetName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Create", _m_Create);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAction", _m_SetAction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAction", _m_GetAction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnter", _m_OnEnter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnExit", _m_OnExit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExitGame", _m_ExitGame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSceneBehavior", _m_SetSceneBehavior);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnUpdate", _m_OnUpdate);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "itEnter", _g_get_itEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "itExit", _g_get_itExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onBeginLoading", _g_get_onBeginLoading);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onExit", _g_get_onExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onEnter", _g_get_onEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onRunning", _g_get_onRunning);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onEndLoading", _g_get_onEndLoading);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "itEnter", _s_set_itEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "itExit", _s_set_itExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onBeginLoading", _s_set_onBeginLoading);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onExit", _s_set_onExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onEnter", _s_set_onEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onRunning", _s_set_onRunning);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onEndLoading", _s_set_onEndLoading);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameClient.Scene __cl_gen_ret = new GameClient.Scene();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.Scene constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetID(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetID(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetName(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Create(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int iId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Create( iId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.SceneAction eAction;translator.Get(L, 2, out eAction);
                    
                    __cl_gen_to_be_invoked.SetAction( eAction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameClient.SceneAction __cl_gen_ret = __cl_gen_to_be_invoked.GetAction(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.OnEnter(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnExit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.OnExit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitGame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.ExitGame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSceneBehavior(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaSceneBehavior behavior = (LuaSceneBehavior)translator.GetObject(L, 2, typeof(LuaSceneBehavior));
                    
                    __cl_gen_to_be_invoked.SetSceneBehavior( behavior );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.OnUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_itEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.itEnter);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_itExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.itExit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onBeginLoading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onBeginLoading);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onExit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onEnter);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onRunning(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onRunning);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onEndLoading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onEndLoading);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_itEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.itEnter = (System.Collections.IEnumerator)translator.GetObject(L, 2, typeof(System.Collections.IEnumerator));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_itExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.itExit = (System.Collections.IEnumerator)translator.GetObject(L, 2, typeof(System.Collections.IEnumerator));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onBeginLoading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onBeginLoading = translator.GetDelegate<EAction>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onExit = translator.GetDelegate<EAction>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onEnter = translator.GetDelegate<EAction>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onRunning(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onRunning = translator.GetDelegate<EAction>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onEndLoading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.Scene __cl_gen_to_be_invoked = (GameClient.Scene)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onEndLoading = translator.GetDelegate<EAction>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
