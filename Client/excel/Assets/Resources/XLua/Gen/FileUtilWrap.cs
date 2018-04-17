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
    public class FileUtilWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FileUtil);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 7, 1, 1);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFileMD5", _m_GetFileMD5_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFileMD5Async", _m_GetFileMD5Async_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFileBytes", _m_GetFileBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FileExists", _m_FileExists_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReadFileFromResource", _m_ReadFileFromResource_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HasFile", _m_HasFile_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "md5", _g_get_md5);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "md5", _s_set_md5);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					FileUtil __cl_gen_ret = new FileUtil();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FileUtil constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileMD5_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string filePath = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = FileUtil.GetFileMD5( filePath );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileMD5Async_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string file = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.IEnumerator __cl_gen_ret = FileUtil.GetFileMD5Async( file );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string path = LuaAPI.lua_tostring(L, 1);
                    
                        long __cl_gen_ret = FileUtil.GetFileBytes( path );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FileExists_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string path = LuaAPI.lua_tostring(L, 1);
                    
                        long __cl_gen_ret = FileUtil.FileExists( path );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadFileFromResource_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string fileName = LuaAPI.lua_tostring(L, 1);
                    
                        byte[] __cl_gen_ret = FileUtil.ReadFileFromResource( fileName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string path = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = FileUtil.HasFile( path );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_md5(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, FileUtil.md5);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_md5(RealStatePtr L)
        {
		    try {
                
			    FileUtil.md5 = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
