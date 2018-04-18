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
    public class GameClientUIFrameLuaWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.UIFrameLua);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "OpenFrameLua", _m_OpenFrameLua_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CloseFrameLua", _m_CloseFrameLua_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CloseFrame", _m_CloseFrame_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameClient.UIFrameLua __cl_gen_ret = new GameClient.UIFrameLua();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.UIFrameLua constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenFrameLua_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.GameObject>(L, 4)) 
                {
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 1);
                    object userData = translator.GetObject(L, 2, typeof(object));
                    int frameId = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.GameObject parent = (UnityEngine.GameObject)translator.GetObject(L, 4, typeof(UnityEngine.GameObject));
                    
                        GameClient.IFrame __cl_gen_ret = GameClient.UIFrameLua.OpenFrameLua( frameTypeId, userData, frameId, parent );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 1);
                    object userData = translator.GetObject(L, 2, typeof(object));
                    int frameId = LuaAPI.xlua_tointeger(L, 3);
                    
                        GameClient.IFrame __cl_gen_ret = GameClient.UIFrameLua.OpenFrameLua( frameTypeId, userData, frameId );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 1);
                    object userData = translator.GetObject(L, 2, typeof(object));
                    
                        GameClient.IFrame __cl_gen_ret = GameClient.UIFrameLua.OpenFrameLua( frameTypeId, userData );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 1);
                    
                        GameClient.IFrame __cl_gen_ret = GameClient.UIFrameLua.OpenFrameLua( frameTypeId );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.UIFrameLua.OpenFrameLua!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseFrameLua_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 1);
                    int frameId = LuaAPI.xlua_tointeger(L, 2);
                    
                    GameClient.UIFrameLua.CloseFrameLua( frameTypeId, frameId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 1);
                    
                    GameClient.UIFrameLua.CloseFrameLua( frameTypeId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.UIFrameLua.CloseFrameLua!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseFrame_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    GameClient.IFrame frame = (GameClient.IFrame)translator.GetObject(L, 1, typeof(GameClient.IFrame));
                    
                    GameClient.UIFrameLua.CloseFrame( frame );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
