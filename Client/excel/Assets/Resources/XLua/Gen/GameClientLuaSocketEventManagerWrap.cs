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
    public class GameClientLuaSocketEventManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.LuaSocketEventManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterEvent", _m_RegisterEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnRegisterEvent", _m_UnRegisterEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnRegisterSocketEvent", _m_UnRegisterSocketEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendEvent", _m_SendEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Instance", _m_Instance_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameClient.LuaSocketEventManager __cl_gen_ret = new GameClient.LuaSocketEventManager();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.LuaSocketEventManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Instance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        GameClient.LuaSocketEventManager __cl_gen_ret = GameClient.LuaSocketEventManager.Instance(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LuaSocketEventManager __cl_gen_to_be_invoked = (GameClient.LuaSocketEventManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object socket = translator.GetObject(L, 2, typeof(object));
                    int eventId = LuaAPI.xlua_tointeger(L, 3);
                    GameClient.LuaSocketEvent handler = translator.GetDelegate<GameClient.LuaSocketEvent>(L, 4);
                    
                    __cl_gen_to_be_invoked.RegisterEvent( socket, eventId, handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnRegisterEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LuaSocketEventManager __cl_gen_to_be_invoked = (GameClient.LuaSocketEventManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object socket = translator.GetObject(L, 2, typeof(object));
                    int eventId = LuaAPI.xlua_tointeger(L, 3);
                    GameClient.LuaSocketEvent handler = translator.GetDelegate<GameClient.LuaSocketEvent>(L, 4);
                    
                    __cl_gen_to_be_invoked.UnRegisterEvent( socket, eventId, handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnRegisterSocketEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LuaSocketEventManager __cl_gen_to_be_invoked = (GameClient.LuaSocketEventManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object socket = translator.GetObject(L, 2, typeof(object));
                    
                    __cl_gen_to_be_invoked.UnRegisterSocketEvent( socket );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LuaSocketEventManager __cl_gen_to_be_invoked = (GameClient.LuaSocketEventManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object socket = translator.GetObject(L, 2, typeof(object));
                    int eventId = LuaAPI.xlua_tointeger(L, 3);
                    object argv = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.SendEvent( socket, eventId, argv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LuaSocketEventManager __cl_gen_to_be_invoked = (GameClient.LuaSocketEventManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
