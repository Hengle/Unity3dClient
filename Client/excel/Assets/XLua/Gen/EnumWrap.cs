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
    
    public class GameClientFrameTypeIDWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(GameClient.FrameTypeID), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(GameClient.FrameTypeID), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(GameClient.FrameTypeID), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FTID_INVALID", GameClient.FrameTypeID.FTID_INVALID);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FTID_LOGIN", GameClient.FrameTypeID.FTID_LOGIN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FTID_HOTFIX", GameClient.FrameTypeID.FTID_HOTFIX);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FTID_LOBBY", GameClient.FrameTypeID.FTID_LOBBY);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FTID_SETTING", GameClient.FrameTypeID.FTID_SETTING);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(GameClient.FrameTypeID), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushGameClientFrameTypeID(L, (GameClient.FrameTypeID)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "FTID_INVALID"))
                {
                    translator.PushGameClientFrameTypeID(L, GameClient.FrameTypeID.FTID_INVALID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FTID_LOGIN"))
                {
                    translator.PushGameClientFrameTypeID(L, GameClient.FrameTypeID.FTID_LOGIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FTID_HOTFIX"))
                {
                    translator.PushGameClientFrameTypeID(L, GameClient.FrameTypeID.FTID_HOTFIX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FTID_LOBBY"))
                {
                    translator.PushGameClientFrameTypeID(L, GameClient.FrameTypeID.FTID_LOBBY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FTID_SETTING"))
                {
                    translator.PushGameClientFrameTypeID(L, GameClient.FrameTypeID.FTID_SETTING);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for GameClient.FrameTypeID!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for GameClient.FrameTypeID! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class GameClientFrameLayerWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(GameClient.FrameLayer), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(GameClient.FrameLayer), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(GameClient.FrameLayer), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BOTTOM", GameClient.FrameLayer.BOTTOM);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MIDDLE", GameClient.FrameLayer.MIDDLE);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HIGH", GameClient.FrameLayer.HIGH);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TOP", GameClient.FrameLayer.TOP);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "COUNT", GameClient.FrameLayer.COUNT);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(GameClient.FrameLayer), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushGameClientFrameLayer(L, (GameClient.FrameLayer)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "BOTTOM"))
                {
                    translator.PushGameClientFrameLayer(L, GameClient.FrameLayer.BOTTOM);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MIDDLE"))
                {
                    translator.PushGameClientFrameLayer(L, GameClient.FrameLayer.MIDDLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HIGH"))
                {
                    translator.PushGameClientFrameLayer(L, GameClient.FrameLayer.HIGH);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TOP"))
                {
                    translator.PushGameClientFrameLayer(L, GameClient.FrameLayer.TOP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "COUNT"))
                {
                    translator.PushGameClientFrameLayer(L, GameClient.FrameLayer.COUNT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for GameClient.FrameLayer!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for GameClient.FrameLayer! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}