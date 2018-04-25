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
    public class GameClientCMD_S_GameStatusWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.CMD_S_GameStatus);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 5, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "tick_count", _g_get_tick_count);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "game_config", _g_get_game_config);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fish_score", _g_get_fish_score);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "exchange_fish_score", _g_get_exchange_fish_score);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "szGameRoomName", _g_get_szGameRoomName);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "tick_count", _s_set_tick_count);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "game_config", _s_set_game_config);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fish_score", _s_set_fish_score);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "exchange_fish_score", _s_set_exchange_fish_score);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "szGameRoomName", _s_set_szGameRoomName);
            
			
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
					
					GameClient.CMD_S_GameStatus __cl_gen_ret = new GameClient.CMD_S_GameStatus();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.CMD_S_GameStatus constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tick_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.tick_count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_game_config(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.game_config);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fish_score(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.fish_score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exchange_fish_score(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.exchange_fish_score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szGameRoomName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.szGameRoomName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tick_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.tick_count = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_game_config(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.game_config = (GameClient.ClientGameConfig)translator.GetObject(L, 2, typeof(GameClient.ClientGameConfig));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fish_score(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fish_score = (long[])translator.GetObject(L, 2, typeof(long[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_exchange_fish_score(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.exchange_fish_score = (long[])translator.GetObject(L, 2, typeof(long[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szGameRoomName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.CMD_S_GameStatus __cl_gen_to_be_invoked = (GameClient.CMD_S_GameStatus)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.szGameRoomName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
