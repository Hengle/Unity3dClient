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
    public class ScriptsUIComUIListScriptWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Scripts.UI.ComUIListScript);
			Utils.BeginObjectRegister(type, L, translator, 0, 21, 24, 23);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetElemenet", _m_GetElemenet);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetElementRect", _m_GetElementRect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EnsureElementVisable", _m_EnsureElementVisable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetElementAmount", _m_GetElementAmount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLastSelectedElement", _m_GetLastSelectedElement);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLastSelectedIndex", _m_GetLastSelectedIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetScrollValue", _m_GetScrollValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSelectedElement", _m_GetSelectedElement);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSelectedIndex", _m_GetSelectedIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HideExtraContent", _m_HideExtraContent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsInitialised", _m_IsInitialised);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Initialize", _m_Initialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsElementInScrollArea", _m_IsElementInScrollArea);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsSelectedIndex", _m_IsSelectedIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveElementInScrollArea", _m_MoveElementInScrollArea);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AutoScroll2Bottom", _m_AutoScroll2Bottom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetContentPosition", _m_ResetContentPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SelectElement", _m_SelectElement);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetElementAmount", _m_SetElementAmount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ShowExtraContent", _m_ShowExtraContent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsActive", _m_IsActive);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "contentSize", _g_get_contentSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onBindItem", _g_get_onBindItem);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onItemSelected", _g_get_onItemSelected);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onItemVisiable", _g_get_onItemVisiable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onItemChageDisplay", _g_get_onItemChageDisplay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnItemRecycle", _g_get_OnItemRecycle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_alwaysDispatchSelectedChangeEvent", _g_get_m_alwaysDispatchSelectedChangeEvent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_autoAdjustScrollAreaSize", _g_get_m_autoAdjustScrollAreaSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_autoCenteredElements", _g_get_m_autoCenteredElements);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_elementAmount", _g_get_m_elementAmount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_elementLayoutOffset", _g_get_m_elementLayoutOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_elementPadding", _g_get_m_elementPadding);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_elementSpacing", _g_get_m_elementSpacing);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_externalElementPrefabPath", _g_get_m_externalElementPrefabPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_extraContent", _g_get_m_extraContent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_fSpeed", _g_get_m_fSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_listType", _g_get_m_listType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_scrollAreaSize", _g_get_m_scrollAreaSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_scrollExternal", _g_get_m_scrollExternal);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_scrollRect", _g_get_m_scrollRect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_scrollRectAreaMaxSize", _g_get_m_scrollRectAreaMaxSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_useExternalElement", _g_get_m_useExternalElement);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_useOptimized", _g_get_m_useOptimized);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_ZeroTipsObj", _g_get_m_ZeroTipsObj);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "onBindItem", _s_set_onBindItem);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onItemSelected", _s_set_onItemSelected);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onItemVisiable", _s_set_onItemVisiable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onItemChageDisplay", _s_set_onItemChageDisplay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnItemRecycle", _s_set_OnItemRecycle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_alwaysDispatchSelectedChangeEvent", _s_set_m_alwaysDispatchSelectedChangeEvent);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_autoAdjustScrollAreaSize", _s_set_m_autoAdjustScrollAreaSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_autoCenteredElements", _s_set_m_autoCenteredElements);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_elementAmount", _s_set_m_elementAmount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_elementLayoutOffset", _s_set_m_elementLayoutOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_elementPadding", _s_set_m_elementPadding);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_elementSpacing", _s_set_m_elementSpacing);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_externalElementPrefabPath", _s_set_m_externalElementPrefabPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_extraContent", _s_set_m_extraContent);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_fSpeed", _s_set_m_fSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_listType", _s_set_m_listType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_scrollAreaSize", _s_set_m_scrollAreaSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_scrollExternal", _s_set_m_scrollExternal);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_scrollRect", _s_set_m_scrollRect);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_scrollRectAreaMaxSize", _s_set_m_scrollRectAreaMaxSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_useExternalElement", _s_set_m_useExternalElement);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_useOptimized", _s_set_m_useOptimized);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_ZeroTipsObj", _s_set_m_ZeroTipsObj);
            
			
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
					
					Scripts.UI.ComUIListScript __cl_gen_ret = new Scripts.UI.ComUIListScript();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Scripts.UI.ComUIListScript constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetElemenet(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        Scripts.UI.ComUIListElementScript __cl_gen_ret = __cl_gen_to_be_invoked.GetElemenet( index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetElementRect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        Scripts.UI.stRect __cl_gen_ret = __cl_gen_to_be_invoked.GetElementRect( index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnsureElementVisable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.EnsureElementVisable( index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetElementAmount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetElementAmount(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLastSelectedElement(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        Scripts.UI.ComUIListElementScript __cl_gen_ret = __cl_gen_to_be_invoked.GetLastSelectedElement(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLastSelectedIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetLastSelectedIndex(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetScrollValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector2 __cl_gen_ret = __cl_gen_to_be_invoked.GetScrollValue(  );
                        translator.PushUnityEngineVector2(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSelectedElement(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        Scripts.UI.ComUIListElementScript __cl_gen_ret = __cl_gen_to_be_invoked.GetSelectedElement(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSelectedIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetSelectedIndex(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideExtraContent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.HideExtraContent(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInitialised(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInitialised(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Initialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsElementInScrollArea(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsElementInScrollArea( index );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSelectedIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsSelectedIndex( index );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveElementInScrollArea(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    bool moveImmediately = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.MoveElementInScrollArea( index, moveImmediately );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AutoScroll2Bottom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.AutoScroll2Bottom(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetContentPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.ResetContentPosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SelectElement(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    bool isDispatchSelectedChangeEvent = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SelectElement( index, isDispatchSelectedChangeEvent );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SelectElement( index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Scripts.UI.ComUIListScript.SelectElement!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetElementAmount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int amount = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetElementAmount( amount );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Vector2>>(L, 3)) 
                {
                    int amount = LuaAPI.xlua_tointeger(L, 2);
                    System.Collections.Generic.List<UnityEngine.Vector2> elementsSize = (System.Collections.Generic.List<UnityEngine.Vector2>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector2>));
                    
                    __cl_gen_to_be_invoked.SetElementAmount( amount, elementsSize );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Scripts.UI.ComUIListScript.SetElementAmount!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowExtraContent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.ShowExtraContent(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsActive(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_contentSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.contentSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onBindItem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onBindItem);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onItemSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onItemSelected);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onItemVisiable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onItemVisiable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onItemChageDisplay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onItemChageDisplay);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnItemRecycle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnItemRecycle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_alwaysDispatchSelectedChangeEvent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_alwaysDispatchSelectedChangeEvent);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_autoAdjustScrollAreaSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_autoAdjustScrollAreaSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_autoCenteredElements(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_autoCenteredElements);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_elementAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.m_elementAmount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_elementLayoutOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.m_elementLayoutOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_elementPadding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.m_elementPadding);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_elementSpacing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.m_elementSpacing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_externalElementPrefabPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.m_externalElementPrefabPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_extraContent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_extraContent);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_fSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.m_fSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_listType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_listType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_scrollAreaSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.m_scrollAreaSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_scrollExternal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_scrollExternal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_scrollRect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_scrollRect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_scrollRectAreaMaxSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.m_scrollRectAreaMaxSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_useExternalElement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_useExternalElement);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_useOptimized(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_useOptimized);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ZeroTipsObj(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_ZeroTipsObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onBindItem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onBindItem = translator.GetDelegate<Scripts.UI.ComUIListScript.OnBindItemDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onItemSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onItemSelected = translator.GetDelegate<Scripts.UI.ComUIListScript.OnItemSelectedDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onItemVisiable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onItemVisiable = translator.GetDelegate<Scripts.UI.ComUIListScript.OnItemVisiableDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onItemChageDisplay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onItemChageDisplay = translator.GetDelegate<Scripts.UI.ComUIListScript.OnItemChangeDisplayDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnItemRecycle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnItemRecycle = translator.GetDelegate<Scripts.UI.ComUIListScript.OnItemRecycleDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_alwaysDispatchSelectedChangeEvent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_alwaysDispatchSelectedChangeEvent = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_autoAdjustScrollAreaSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_autoAdjustScrollAreaSize = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_autoCenteredElements(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_autoCenteredElements = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_elementAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_elementAmount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_elementLayoutOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_elementLayoutOffset = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_elementPadding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_elementPadding = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_elementSpacing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_elementSpacing = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_externalElementPrefabPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_externalElementPrefabPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_extraContent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_extraContent = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_fSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_fSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_listType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                Scripts.UI.ComUIListScript.enUIListType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_listType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_scrollAreaSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_scrollAreaSize = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_scrollExternal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_scrollExternal = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_scrollRect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_scrollRect = (UnityEngine.UI.ScrollRect)translator.GetObject(L, 2, typeof(UnityEngine.UI.ScrollRect));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_scrollRectAreaMaxSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_scrollRectAreaMaxSize = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_useExternalElement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_useExternalElement = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_useOptimized(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_useOptimized = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ZeroTipsObj(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Scripts.UI.ComUIListScript __cl_gen_to_be_invoked = (Scripts.UI.ComUIListScript)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ZeroTipsObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
