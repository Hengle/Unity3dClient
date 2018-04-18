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
    public class GameClientClientFrameWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.ClientFrame);
			Utils.BeginObjectRegister(type, L, translator, 0, 18, 3, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getFrameId", _m_getFrameId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getFrameTypeId", _m_getFrameTypeId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getFrameState", _m_getFrameState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getFrameHashCode", _m_getFrameHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "needLuaBehavior", _m_needLuaBehavior);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPrefabPath", _m_getPrefabPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLayer", _m_getLayer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "openFrame", _m_openFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "closeFrame", _m_closeFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterEvent", _m_RegisterEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnRegisterEvent", _m_UnRegisterEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendEvent", _m_SendEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetObjectStatus", _m_SetObjectStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetText", _m_SetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetImage", _m_SetImage);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetObject", _m_GetObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddChildFrame", _m_AddChildFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseChildFrame", _m_CloseChildFrame);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "FrameID", _g_get_FrameID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FrameTypeID", _g_get_FrameTypeID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FrameHashCode", _g_get_FrameHashCode);
            
			
			
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
					
					GameClient.ClientFrame __cl_gen_ret = new GameClient.ClientFrame();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.ClientFrame constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getFrameId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.getFrameId(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getFrameTypeId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.getFrameTypeId(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getFrameState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameClient.FrameState __cl_gen_ret = __cl_gen_to_be_invoked.getFrameState(  );
                        translator.PushGameClientFrameState(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getFrameHashCode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.getFrameHashCode(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_needLuaBehavior(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.needLuaBehavior(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getPrefabPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.getPrefabPath(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getLayer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameClient.FrameLayer __cl_gen_ret = __cl_gen_to_be_invoked.getLayer(  );
                        translator.PushGameClientFrameLayer(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_openFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<object>(L, 4)&& translator.Assignable<UnityEngine.GameObject>(L, 5)) 
                {
                    int iId = LuaAPI.xlua_tointeger(L, 2);
                    int type = LuaAPI.xlua_tointeger(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    UnityEngine.GameObject parent = (UnityEngine.GameObject)translator.GetObject(L, 5, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.openFrame( iId, type, userData, parent );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    int iId = LuaAPI.xlua_tointeger(L, 2);
                    int type = LuaAPI.xlua_tointeger(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.openFrame( iId, type, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int iId = LuaAPI.xlua_tointeger(L, 2);
                    int type = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.openFrame( iId, type );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int iId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.openFrame( iId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.openFrame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.ClientFrame.openFrame!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_closeFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.closeFrame(  );
                    
                    
                    
                    return 0;
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
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int eventId = LuaAPI.xlua_tointeger(L, 2);
                    GameClient.LuaEvent handler = translator.GetDelegate<GameClient.LuaEvent>(L, 3);
                    
                    __cl_gen_to_be_invoked.RegisterEvent( eventId, handler );
                    
                    
                    
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
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int eventId = LuaAPI.xlua_tointeger(L, 2);
                    GameClient.LuaEvent handler = translator.GetDelegate<GameClient.LuaEvent>(L, 3);
                    
                    __cl_gen_to_be_invoked.UnRegisterEvent( eventId, handler );
                    
                    
                    
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
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int eventId = LuaAPI.xlua_tointeger(L, 2);
                    object argv = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.SendEvent( eventId, argv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetObjectStatus(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string objName = LuaAPI.lua_tostring(L, 2);
                    int status = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.SetObjectStatus( objName, status );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string objName = LuaAPI.lua_tostring(L, 2);
                    string value = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.SetText( objName, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetImage(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string objName = LuaAPI.lua_tostring(L, 2);
                    string path = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.SetImage( objName, path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string objName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Object __cl_gen_ret = __cl_gen_to_be_invoked.GetObject( objName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddChildFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.IFrame frame = (GameClient.IFrame)translator.GetObject(L, 2, typeof(GameClient.IFrame));
                    
                    __cl_gen_to_be_invoked.AddChildFrame( frame );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseChildFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.IFrame frame = (GameClient.IFrame)translator.GetObject(L, 2, typeof(GameClient.IFrame));
                    
                    __cl_gen_to_be_invoked.CloseChildFrame( frame );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FrameID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.FrameID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FrameTypeID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.FrameTypeID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FrameHashCode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.ClientFrame __cl_gen_to_be_invoked = (GameClient.ClientFrame)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.FrameHashCode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
