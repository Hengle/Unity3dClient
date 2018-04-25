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
    public class GameClientSceneManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.SceneManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterScene", _m_RegisterScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Initialize", _m_Initialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SwitchScene", _m_SwitchScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AnsySwitchScene", _m_AnsySwitchScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExitGame", _m_ExitGame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnInitialize", _m_UnInitialize);
			
			
			
			
			
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
					
					GameClient.SceneManager __cl_gen_ret = new GameClient.SceneManager();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.SceneManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Instance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        GameClient.SceneManager __cl_gen_ret = GameClient.SceneManager.Instance(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.SceneManager __cl_gen_to_be_invoked = (GameClient.SceneManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.SceneType eScene;translator.Get(L, 2, out eScene);
                    GameClient.SceneManager.EActionCreate cb = translator.GetDelegate<GameClient.SceneManager.EActionCreate>(L, 3);
                    
                    __cl_gen_to_be_invoked.RegisterScene( eScene, cb );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Initialize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.SceneManager __cl_gen_to_be_invoked = (GameClient.SceneManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Initialize(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.SceneManager __cl_gen_to_be_invoked = (GameClient.SceneManager)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    int iSceneId = LuaAPI.xlua_tointeger(L, 2);
                    object luaParam = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.SwitchScene( iSceneId, luaParam );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<GameClient.SceneType>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    GameClient.SceneType eSceneType;translator.Get(L, 2, out eSceneType);
                    object luaParam = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.SwitchScene( eSceneType, luaParam );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.SceneType>(L, 2)) 
                {
                    GameClient.SceneType eSceneType;translator.Get(L, 2, out eSceneType);
                    
                    __cl_gen_to_be_invoked.SwitchScene( eSceneType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.SceneManager.SwitchScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AnsySwitchScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.SceneManager __cl_gen_to_be_invoked = (GameClient.SceneManager)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& translator.Assignable<GameClient.SceneType>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    GameClient.SceneType eSceneType;translator.Get(L, 2, out eSceneType);
                    object luaParam = translator.GetObject(L, 3, typeof(object));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.AnsySwitchScene( eSceneType, luaParam );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.SceneType>(L, 2)) 
                {
                    GameClient.SceneType eSceneType;translator.Get(L, 2, out eSceneType);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.AnsySwitchScene( eSceneType );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.SceneManager.AnsySwitchScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.SceneManager __cl_gen_to_be_invoked = (GameClient.SceneManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool bGlobal = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Clear( bGlobal );
                    
                    
                    
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
            
            
                GameClient.SceneManager __cl_gen_to_be_invoked = (GameClient.SceneManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.ExitGame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnInitialize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.SceneManager __cl_gen_to_be_invoked = (GameClient.SceneManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.UnInitialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
