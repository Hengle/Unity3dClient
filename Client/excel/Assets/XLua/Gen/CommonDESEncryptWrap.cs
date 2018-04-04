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
    public class CommonDESEncryptWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Common.DESEncrypt);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "MyEncode", _m_MyEncode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MyDecode", _m_MyDecode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DesEncrypt", _m_DesEncrypt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DesDecrypt", _m_DesDecrypt_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Common.DESEncrypt does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MyEncode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string Text = LuaAPI.lua_tostring(L, 1);
                    long tm = LuaAPI.lua_toint64(L, 2);
                    
                        string __cl_gen_ret = Common.DESEncrypt.MyEncode( Text, tm );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MyDecode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string Text = LuaAPI.lua_tostring(L, 1);
                    long tm = LuaAPI.lua_toint64(L, 2);
                    
                        string __cl_gen_ret = Common.DESEncrypt.MyDecode( Text, tm );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DesEncrypt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string encryptString = LuaAPI.lua_tostring(L, 1);
                    string key = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = Common.DESEncrypt.DesEncrypt( encryptString, key );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DesDecrypt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string decryptString = LuaAPI.lua_tostring(L, 1);
                    string key = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = Common.DESEncrypt.DesDecrypt( decryptString, key );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
