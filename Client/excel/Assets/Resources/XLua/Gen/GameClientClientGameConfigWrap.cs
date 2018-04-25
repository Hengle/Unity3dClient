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
    public class GameClientClientGameConfigWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.ClientGameConfig);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 10, 10);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "exchange_ratio_userscore", _g_get_exchange_ratio_userscore);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "exchange_ratio_fishscore", _g_get_exchange_ratio_fishscore);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "exchange_count", _g_get_exchange_count);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "min_bullet_multiple", _g_get_min_bullet_multiple);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "max_bullet_multiple", _g_get_max_bullet_multiple);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fish_speed", _g_get_fish_speed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fish_bounding_radius", _g_get_fish_bounding_radius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fish_bounding_count", _g_get_fish_bounding_count);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bullet_speed", _g_get_bullet_speed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bullet_bounding_radius", _g_get_bullet_bounding_radius);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "exchange_ratio_userscore", _s_set_exchange_ratio_userscore);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "exchange_ratio_fishscore", _s_set_exchange_ratio_fishscore);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "exchange_count", _s_set_exchange_count);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "min_bullet_multiple", _s_set_min_bullet_multiple);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "max_bullet_multiple", _s_set_max_bullet_multiple);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fish_speed", _s_set_fish_speed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fish_bounding_radius", _s_set_fish_bounding_radius);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fish_bounding_count", _s_set_fish_bounding_count);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bullet_speed", _s_set_bullet_speed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bullet_bounding_radius", _s_set_bullet_bounding_radius);
            
			
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
					
					GameClient.ClientGameConfig __cl_gen_ret = new GameClient.ClientGameConfig();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.ClientGameConfig constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exchange_ratio_userscore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.exchange_ratio_userscore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exchange_ratio_fishscore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.exchange_ratio_fishscore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exchange_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.exchange_count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_min_bullet_multiple(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.min_bullet_multiple);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_max_bullet_multiple(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.max_bullet_multiple);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fish_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.fish_speed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fish_bounding_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.fish_bounding_radius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fish_bounding_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.fish_bounding_count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bullet_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.bullet_speed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bullet_bounding_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.bullet_bounding_radius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_exchange_ratio_userscore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.exchange_ratio_userscore = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_exchange_ratio_fishscore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.exchange_ratio_fishscore = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_exchange_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.exchange_count = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_min_bullet_multiple(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.min_bullet_multiple = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_max_bullet_multiple(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.max_bullet_multiple = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fish_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fish_speed = (float[])translator.GetObject(L, 2, typeof(float[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fish_bounding_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fish_bounding_radius = (float[])translator.GetObject(L, 2, typeof(float[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fish_bounding_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fish_bounding_count = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bullet_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.bullet_speed = (float[])translator.GetObject(L, 2, typeof(float[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bullet_bounding_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientGameConfig __cl_gen_to_be_invoked = (GameClient.ClientGameConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.bullet_bounding_radius = (float[])translator.GetObject(L, 2, typeof(float[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
