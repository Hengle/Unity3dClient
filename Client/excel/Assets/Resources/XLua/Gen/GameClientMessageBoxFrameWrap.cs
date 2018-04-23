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
    public class GameClientMessageBoxFrameWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.MessageBoxFrame);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Open", _m_Open_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameClient.MessageBoxFrame __cl_gen_ret = new GameClient.MessageBoxFrame();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.MessageBoxFrame constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Open_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 6&& translator.Assignable<GameClient.OnClickMessageBoxOK>(L, 1)&& translator.Assignable<GameClient.OnClickMessageBoxCancel>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<object[]>(L, 6)) 
                {
                    GameClient.OnClickMessageBoxOK onOk = translator.GetDelegate<GameClient.OnClickMessageBoxOK>(L, 1);
                    GameClient.OnClickMessageBoxCancel onCancel = translator.GetDelegate<GameClient.OnClickMessageBoxCancel>(L, 2);
                    int messageId = LuaAPI.xlua_tointeger(L, 3);
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 4);
                    int frameId = LuaAPI.xlua_tointeger(L, 5);
                    object[] argvs = (object[])translator.GetObject(L, 6, typeof(object[]));
                    
                    GameClient.MessageBoxFrame.Open( onOk, onCancel, messageId, frameTypeId, frameId, argvs );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<GameClient.OnClickMessageBoxOK>(L, 1)&& translator.Assignable<GameClient.OnClickMessageBoxCancel>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    GameClient.OnClickMessageBoxOK onOk = translator.GetDelegate<GameClient.OnClickMessageBoxOK>(L, 1);
                    GameClient.OnClickMessageBoxCancel onCancel = translator.GetDelegate<GameClient.OnClickMessageBoxCancel>(L, 2);
                    int messageId = LuaAPI.xlua_tointeger(L, 3);
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 4);
                    int frameId = LuaAPI.xlua_tointeger(L, 5);
                    
                    GameClient.MessageBoxFrame.Open( onOk, onCancel, messageId, frameTypeId, frameId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<GameClient.OnClickMessageBoxOK>(L, 1)&& translator.Assignable<GameClient.OnClickMessageBoxCancel>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    GameClient.OnClickMessageBoxOK onOk = translator.GetDelegate<GameClient.OnClickMessageBoxOK>(L, 1);
                    GameClient.OnClickMessageBoxCancel onCancel = translator.GetDelegate<GameClient.OnClickMessageBoxCancel>(L, 2);
                    int messageId = LuaAPI.xlua_tointeger(L, 3);
                    int frameTypeId = LuaAPI.xlua_tointeger(L, 4);
                    
                    GameClient.MessageBoxFrame.Open( onOk, onCancel, messageId, frameTypeId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<GameClient.OnClickMessageBoxOK>(L, 1)&& translator.Assignable<GameClient.OnClickMessageBoxCancel>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    GameClient.OnClickMessageBoxOK onOk = translator.GetDelegate<GameClient.OnClickMessageBoxOK>(L, 1);
                    GameClient.OnClickMessageBoxCancel onCancel = translator.GetDelegate<GameClient.OnClickMessageBoxCancel>(L, 2);
                    int messageId = LuaAPI.xlua_tointeger(L, 3);
                    
                    GameClient.MessageBoxFrame.Open( onOk, onCancel, messageId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.MessageBoxFrame.Open!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
