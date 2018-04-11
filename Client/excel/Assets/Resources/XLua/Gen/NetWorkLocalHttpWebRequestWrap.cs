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
    public class NetWorkLocalHttpWebRequestWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(NetWork.LocalHttpWebRequest);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HttpPostRequest", _m_HttpPostRequest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HttpGetRequest", _m_HttpGetRequest);
			
			
			
			
			
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
					
					NetWork.LocalHttpWebRequest __cl_gen_ret = new NetWork.LocalHttpWebRequest();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to NetWork.LocalHttpWebRequest constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HttpPostRequest(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.LocalHttpWebRequest __cl_gen_to_be_invoked = (NetWork.LocalHttpWebRequest)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<NetWork.LocalHttpWebRequestCB>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string postdata = LuaAPI.lua_tostring(L, 3);
                    NetWork.LocalHttpWebRequestCB cb = translator.GetDelegate<NetWork.LocalHttpWebRequestCB>(L, 4);
                    int timeout = LuaAPI.xlua_tointeger(L, 5);
                    
                    __cl_gen_to_be_invoked.HttpPostRequest( url, postdata, cb, timeout );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<NetWork.LocalHttpWebRequestCB>(L, 4)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string postdata = LuaAPI.lua_tostring(L, 3);
                    NetWork.LocalHttpWebRequestCB cb = translator.GetDelegate<NetWork.LocalHttpWebRequestCB>(L, 4);
                    
                    __cl_gen_to_be_invoked.HttpPostRequest( url, postdata, cb );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to NetWork.LocalHttpWebRequest.HttpPostRequest!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HttpGetRequest(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.LocalHttpWebRequest __cl_gen_to_be_invoked = (NetWork.LocalHttpWebRequest)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<NetWork.LocalHttpWebRequestCB>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    NetWork.LocalHttpWebRequestCB cb = translator.GetDelegate<NetWork.LocalHttpWebRequestCB>(L, 3);
                    int timeout = LuaAPI.xlua_tointeger(L, 4);
                    
                    __cl_gen_to_be_invoked.HttpGetRequest( url, cb, timeout );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<NetWork.LocalHttpWebRequestCB>(L, 3)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    NetWork.LocalHttpWebRequestCB cb = translator.GetDelegate<NetWork.LocalHttpWebRequestCB>(L, 3);
                    
                    __cl_gen_to_be_invoked.HttpGetRequest( url, cb );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to NetWork.LocalHttpWebRequest.HttpGetRequest!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
