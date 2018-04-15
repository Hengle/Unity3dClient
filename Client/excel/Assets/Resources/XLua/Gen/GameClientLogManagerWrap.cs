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
    public class GameClientLogManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.LogManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 11, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLogItems", _m_GetLogItems);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RecycleFirstLogItem", _m_RecycleFirstLogItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogErrorFormat", _m_LogErrorFormat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogWarningFormat", _m_LogWarningFormat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogFormat", _m_LogFormat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogError", _m_LogError);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogWarning", _m_LogWarning);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Log", _m_Log);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogProcessFormat", _m_LogProcessFormat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogProcess", _m_LogProcess);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushLogToFile", _m_PushLogToFile);
			
			
			
			
			
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
					
					GameClient.LogManager __cl_gen_ret = new GameClient.LogManager();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.LogManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Instance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        GameClient.LogManager __cl_gen_ret = GameClient.LogManager.Instance(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLogItems(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<Protocol.LogItem> __cl_gen_ret = __cl_gen_to_be_invoked.GetLogItems(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecycleFirstLogItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.RecycleFirstLogItem(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogErrorFormat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    object[] argvs = translator.GetParams<object>(L, 3);
                    
                    __cl_gen_to_be_invoked.LogErrorFormat( format, argvs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogWarningFormat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    object[] argvs = translator.GetParams<object>(L, 3);
                    
                    __cl_gen_to_be_invoked.LogWarningFormat( format, argvs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogFormat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    object[] argvs = translator.GetParams<object>(L, 3);
                    
                    __cl_gen_to_be_invoked.LogFormat( format, argvs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogError(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.LogError( format );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogWarning(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.LogWarning( format );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Log(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.Log( format );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogProcessFormat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int Id = LuaAPI.xlua_tointeger(L, 2);
                    string format = LuaAPI.lua_tostring(L, 3);
                    object[] argvs = translator.GetParams<object>(L, 4);
                    
                    __cl_gen_to_be_invoked.LogProcessFormat( Id, format, argvs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogProcess(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int Id = LuaAPI.xlua_tointeger(L, 2);
                    string format = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.LogProcess( Id, format );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushLogToFile(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.LogManager __cl_gen_to_be_invoked = (GameClient.LogManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Protocol.LogItem.LogType eLogType;translator.Get(L, 2, out eLogType);
                    int id = LuaAPI.xlua_tointeger(L, 3);
                    string value = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.PushLogToFile( eLogType, id, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
