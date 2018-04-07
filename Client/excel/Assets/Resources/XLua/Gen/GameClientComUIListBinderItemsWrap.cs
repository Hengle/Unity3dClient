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
    public class GameClientComUIListBinderItemsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.ComUIListBinderItems);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 4, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Initialize", _m_Initialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetElementAmount", _m_SetElementAmount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnInitialize", _m_UnInitialize);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "comUiListScript", _g_get_comUiListScript);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mOnListElementVisible", _g_get_mOnListElementVisible);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mOnListElementSelected", _g_get_mOnListElementSelected);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mOnListElementChangeDisplay", _g_get_mOnListElementChangeDisplay);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "comUiListScript", _s_set_comUiListScript);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mOnListElementVisible", _s_set_mOnListElementVisible);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mOnListElementSelected", _s_set_mOnListElementSelected);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mOnListElementChangeDisplay", _s_set_mOnListElementChangeDisplay);
            
			
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
					
					GameClient.ComUIListBinderItems __cl_gen_ret = new GameClient.ComUIListBinderItems();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.ComUIListBinderItems constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Initialize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Initialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetElementAmount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Vector2>>(L, 3)) 
                {
                    int elementCount = LuaAPI.xlua_tointeger(L, 2);
                    System.Collections.Generic.List<UnityEngine.Vector2> elementsSize = (System.Collections.Generic.List<UnityEngine.Vector2>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector2>));
                    
                    __cl_gen_to_be_invoked.SetElementAmount( elementCount, elementsSize );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int elementCount = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetElementAmount( elementCount );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.ComUIListBinderItems.SetElementAmount!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnInitialize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.UnInitialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_comUiListScript(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.comUiListScript);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mOnListElementVisible(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mOnListElementVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mOnListElementSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mOnListElementSelected);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mOnListElementChangeDisplay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mOnListElementChangeDisplay);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_comUiListScript(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.comUiListScript = (Scripts.UI.ComUIListScript)translator.GetObject(L, 2, typeof(Scripts.UI.ComUIListScript));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mOnListElementVisible(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mOnListElementVisible = translator.GetDelegate<GameClient.ComUIListBinderItems.OnListElementVisible>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mOnListElementSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mOnListElementSelected = translator.GetDelegate<GameClient.ComUIListBinderItems.OnListElementSelected>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mOnListElementChangeDisplay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ComUIListBinderItems __cl_gen_to_be_invoked = (GameClient.ComUIListBinderItems)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mOnListElementChangeDisplay = translator.GetDelegate<GameClient.ComUIListBinderItems.OnListElementChangeDisplay>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
