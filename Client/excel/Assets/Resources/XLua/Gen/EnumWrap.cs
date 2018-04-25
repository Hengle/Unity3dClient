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
    
    public class NetWorkHttpRequestErrorWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(NetWork.HttpRequestError), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(NetWork.HttpRequestError), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(NetWork.HttpRequestError), L, null, 7, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRE_SUCCEED", NetWork.HttpRequestError.HRE_SUCCEED);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRE_INVALID_POST_DATA", NetWork.HttpRequestError.HRE_INVALID_POST_DATA);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRE_INVALID_POST_DATA_BYTES", NetWork.HttpRequestError.HRE_INVALID_POST_DATA_BYTES);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRE_INVALID_POST_METHOD", NetWork.HttpRequestError.HRE_INVALID_POST_METHOD);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRE_STATUS_ERROR", NetWork.HttpRequestError.HRE_STATUS_ERROR);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRE_EXCEPTION", NetWork.HttpRequestError.HRE_EXCEPTION);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(NetWork.HttpRequestError), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushNetWorkHttpRequestError(L, (NetWork.HttpRequestError)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "HRE_SUCCEED"))
                {
                    translator.PushNetWorkHttpRequestError(L, NetWork.HttpRequestError.HRE_SUCCEED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HRE_INVALID_POST_DATA"))
                {
                    translator.PushNetWorkHttpRequestError(L, NetWork.HttpRequestError.HRE_INVALID_POST_DATA);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HRE_INVALID_POST_DATA_BYTES"))
                {
                    translator.PushNetWorkHttpRequestError(L, NetWork.HttpRequestError.HRE_INVALID_POST_DATA_BYTES);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HRE_INVALID_POST_METHOD"))
                {
                    translator.PushNetWorkHttpRequestError(L, NetWork.HttpRequestError.HRE_INVALID_POST_METHOD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HRE_STATUS_ERROR"))
                {
                    translator.PushNetWorkHttpRequestError(L, NetWork.HttpRequestError.HRE_STATUS_ERROR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HRE_EXCEPTION"))
                {
                    translator.PushNetWorkHttpRequestError(L, NetWork.HttpRequestError.HRE_EXCEPTION);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for NetWork.HttpRequestError!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for NetWork.HttpRequestError! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class NetWorkHttpRequestStatusWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(NetWork.HttpRequestStatus), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(NetWork.HttpRequestStatus), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(NetWork.HttpRequestStatus), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRS_INVALID", NetWork.HttpRequestStatus.HRS_INVALID);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRS_BEGIN_REQUEST", NetWork.HttpRequestStatus.HRS_BEGIN_REQUEST);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HRS_WAIT_EVENT", NetWork.HttpRequestStatus.HRS_WAIT_EVENT);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(NetWork.HttpRequestStatus), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushNetWorkHttpRequestStatus(L, (NetWork.HttpRequestStatus)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "HRS_INVALID"))
                {
                    translator.PushNetWorkHttpRequestStatus(L, NetWork.HttpRequestStatus.HRS_INVALID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HRS_BEGIN_REQUEST"))
                {
                    translator.PushNetWorkHttpRequestStatus(L, NetWork.HttpRequestStatus.HRS_BEGIN_REQUEST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HRS_WAIT_EVENT"))
                {
                    translator.PushNetWorkHttpRequestStatus(L, NetWork.HttpRequestStatus.HRS_WAIT_EVENT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for NetWork.HttpRequestStatus!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for NetWork.HttpRequestStatus! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
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
    
    public class GameClientFrameStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(GameClient.FrameState), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(GameClient.FrameState), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(GameClient.FrameState), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FS_INVALID", GameClient.FrameState.FS_INVALID);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FS_OPENING", GameClient.FrameState.FS_OPENING);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FS_OPEN", GameClient.FrameState.FS_OPEN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FS_CLOSING", GameClient.FrameState.FS_CLOSING);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FS_CLOSED", GameClient.FrameState.FS_CLOSED);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(GameClient.FrameState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushGameClientFrameState(L, (GameClient.FrameState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "FS_INVALID"))
                {
                    translator.PushGameClientFrameState(L, GameClient.FrameState.FS_INVALID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FS_OPENING"))
                {
                    translator.PushGameClientFrameState(L, GameClient.FrameState.FS_OPENING);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FS_OPEN"))
                {
                    translator.PushGameClientFrameState(L, GameClient.FrameState.FS_OPEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FS_CLOSING"))
                {
                    translator.PushGameClientFrameState(L, GameClient.FrameState.FS_CLOSING);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FS_CLOSED"))
                {
                    translator.PushGameClientFrameState(L, GameClient.FrameState.FS_CLOSED);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for GameClient.FrameState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for GameClient.FrameState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class GameClientTraceTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(GameClient.TraceType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(GameClient.TraceType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(GameClient.TraceType), L, null, 10, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_ONE", GameClient.TraceType.TRACE_SPPEND_CHANGE_ONE);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_TWO", GameClient.TraceType.TRACE_SPPEND_CHANGE_TWO);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_THREE", GameClient.TraceType.TRACE_SPPEND_CHANGE_THREE);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_FOUR", GameClient.TraceType.TRACE_SPPEND_CHANGE_FOUR);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_FIVE", GameClient.TraceType.TRACE_SPPEND_CHANGE_FIVE);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_SIX", GameClient.TraceType.TRACE_SPPEND_CHANGE_SIX);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_SEVEN", GameClient.TraceType.TRACE_SPPEND_CHANGE_SEVEN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_EIGHT", GameClient.TraceType.TRACE_SPPEND_CHANGE_EIGHT);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TRACE_SPPEND_CHANGE_NINE", GameClient.TraceType.TRACE_SPPEND_CHANGE_NINE);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(GameClient.TraceType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushGameClientTraceType(L, (GameClient.TraceType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_ONE"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_ONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_TWO"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_TWO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_THREE"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_THREE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_FOUR"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_FOUR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_FIVE"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_FIVE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_SIX"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_SIX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_SEVEN"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_SEVEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_EIGHT"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_EIGHT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRACE_SPPEND_CHANGE_NINE"))
                {
                    translator.PushGameClientTraceType(L, GameClient.TraceType.TRACE_SPPEND_CHANGE_NINE);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for GameClient.TraceType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for GameClient.TraceType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class GameClientFishKindWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(GameClient.FishKind), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(GameClient.FishKind), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(GameClient.FishKind), L, null, 36, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_WONIUYU", GameClient.FishKind.FISH_WONIUYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_LVCAOYU", GameClient.FishKind.FISH_LVCAOYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_HUANGCAOYU", GameClient.FishKind.FISH_HUANGCAOYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_DAYANYU", GameClient.FishKind.FISH_DAYANYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_HUANGBIANYU", GameClient.FishKind.FISH_HUANGBIANYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_XIAOCHOUYU", GameClient.FishKind.FISH_XIAOCHOUYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_XIAOCIYU", GameClient.FishKind.FISH_XIAOCIYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_LANYU", GameClient.FishKind.FISH_LANYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_DENGLONGYU", GameClient.FishKind.FISH_DENGLONGYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_HAIGUI", GameClient.FishKind.FISH_HAIGUI);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_HUABANYU", GameClient.FishKind.FISH_HUABANYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_HUDIEYU", GameClient.FishKind.FISH_HUDIEYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_KONGQUEYU", GameClient.FishKind.FISH_KONGQUEYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_JIANYU", GameClient.FishKind.FISH_JIANYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_BIANFUYU", GameClient.FishKind.FISH_BIANFUYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_YINSHA", GameClient.FishKind.FISH_YINSHA);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_JINSHA", GameClient.FishKind.FISH_JINSHA);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_BAWANGJING", GameClient.FishKind.FISH_BAWANGJING);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_JINCHAN", GameClient.FishKind.FISH_JINCHAN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_SHENXIANCHUAN", GameClient.FishKind.FISH_SHENXIANCHUAN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_MEIRENYU", GameClient.FishKind.FISH_MEIRENYU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_XIAOQINGLONG", GameClient.FishKind.FISH_XIAOQINGLONG);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_XIAOYINLONG", GameClient.FishKind.FISH_XIAOYINLONG);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_XIAOJINLONG", GameClient.FishKind.FISH_XIAOJINLONG);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_SWK", GameClient.FishKind.FISH_SWK);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_YUWANGDADI", GameClient.FishKind.FISH_YUWANGDADI);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_FOSHOU", GameClient.FishKind.FISH_FOSHOU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_BGLU", GameClient.FishKind.FISH_BGLU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_DNTG", GameClient.FishKind.FISH_DNTG);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_YJSD", GameClient.FishKind.FISH_YJSD);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_YSSN", GameClient.FishKind.FISH_YSSN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_QJF", GameClient.FishKind.FISH_QJF);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_YUQUN", GameClient.FishKind.FISH_YUQUN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_CHAIN", GameClient.FishKind.FISH_CHAIN);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FISH_KIND_COUNT", GameClient.FishKind.FISH_KIND_COUNT);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(GameClient.FishKind), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushGameClientFishKind(L, (GameClient.FishKind)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_WONIUYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_WONIUYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_LVCAOYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_LVCAOYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_HUANGCAOYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_HUANGCAOYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_DAYANYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_DAYANYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_HUANGBIANYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_HUANGBIANYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_XIAOCHOUYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_XIAOCHOUYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_XIAOCIYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_XIAOCIYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_LANYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_LANYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_DENGLONGYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_DENGLONGYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_HAIGUI"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_HAIGUI);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_HUABANYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_HUABANYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_HUDIEYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_HUDIEYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_KONGQUEYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_KONGQUEYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_JIANYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_JIANYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_BIANFUYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_BIANFUYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_YINSHA"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_YINSHA);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_JINSHA"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_JINSHA);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_BAWANGJING"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_BAWANGJING);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_JINCHAN"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_JINCHAN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_SHENXIANCHUAN"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_SHENXIANCHUAN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_MEIRENYU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_MEIRENYU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_XIAOQINGLONG"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_XIAOQINGLONG);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_XIAOYINLONG"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_XIAOYINLONG);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_XIAOJINLONG"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_XIAOJINLONG);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_SWK"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_SWK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_YUWANGDADI"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_YUWANGDADI);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_FOSHOU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_FOSHOU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_BGLU"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_BGLU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_DNTG"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_DNTG);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_YJSD"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_YJSD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_YSSN"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_YSSN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_QJF"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_QJF);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_YUQUN"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_YUQUN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_CHAIN"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_CHAIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FISH_KIND_COUNT"))
                {
                    translator.PushGameClientFishKind(L, GameClient.FishKind.FISH_KIND_COUNT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for GameClient.FishKind!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for GameClient.FishKind! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}