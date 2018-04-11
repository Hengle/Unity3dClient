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
    public class NetWorkNetSocketWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(NetWork.NetSocket);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 19, 17);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Connect", _m_Connect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DisConnect", _m_DisConnect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnConnected", _m_OnConnected);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Close", _m_Close);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Send", _m_Send);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Receive", _m_Receive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "EStatus", _g_get_EStatus);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nextReconnectTime", _g_get_nextReconnectTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "connected", _g_get_connected);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "targetName", _g_get_targetName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ip", _g_get_ip);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "port", _g_get_port);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxReconnectTimes", _g_get_maxReconnectTimes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onConnecteSucceed", _g_get_onConnecteSucceed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onConnecteFailed", _g_get_onConnecteFailed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onReconnectedSucceed", _g_get_onReconnectedSucceed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onSocketLogOut", _g_get_onSocketLogOut);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "param", _g_get_param);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onClose", _g_get_onClose);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onClosed", _g_get_onClosed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "socket", _g_get_socket);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mSendCB", _g_get_mSendCB);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onRecv", _g_get_onRecv);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mRecvEvents", _g_get_mRecvEvents);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mRecvCB", _g_get_mRecvCB);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "EStatus", _s_set_EStatus);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "targetName", _s_set_targetName);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ip", _s_set_ip);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "port", _s_set_port);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxReconnectTimes", _s_set_maxReconnectTimes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onConnecteSucceed", _s_set_onConnecteSucceed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onConnecteFailed", _s_set_onConnecteFailed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onReconnectedSucceed", _s_set_onReconnectedSucceed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onSocketLogOut", _s_set_onSocketLogOut);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "param", _s_set_param);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onClose", _s_set_onClose);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onClosed", _s_set_onClosed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "socket", _s_set_socket);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mSendCB", _s_set_mSendCB);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onRecv", _s_set_onRecv);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mRecvEvents", _s_set_mRecvEvents);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mRecvCB", _s_set_mRecvCB);
            
			
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
				if(LuaAPI.lua_gettop(L) == 10 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && translator.Assignable<NetWork.OnConnectedSucceed>(L, 6) && translator.Assignable<NetWork.OnConnectedFailed>(L, 7) && translator.Assignable<NetWork.OnSocketRecv>(L, 8) && translator.Assignable<NetWork.OnConnectClose>(L, 9) && translator.Assignable<NetWork.OnConnectClosed>(L, 10))
				{
					string targetName = LuaAPI.lua_tostring(L, 2);
					string ip = LuaAPI.lua_tostring(L, 3);
					short port = (short)LuaAPI.xlua_tointeger(L, 4);
					int maxReconnectTimes = LuaAPI.xlua_tointeger(L, 5);
					NetWork.OnConnectedSucceed onConnecteSucceed = translator.GetDelegate<NetWork.OnConnectedSucceed>(L, 6);
					NetWork.OnConnectedFailed onConnecteFailed = translator.GetDelegate<NetWork.OnConnectedFailed>(L, 7);
					NetWork.OnSocketRecv onRecved = translator.GetDelegate<NetWork.OnSocketRecv>(L, 8);
					NetWork.OnConnectClose onClose = translator.GetDelegate<NetWork.OnConnectClose>(L, 9);
					NetWork.OnConnectClosed onClosed = translator.GetDelegate<NetWork.OnConnectClosed>(L, 10);
					
					NetWork.NetSocket __cl_gen_ret = new NetWork.NetSocket(targetName, ip, port, maxReconnectTimes, onConnecteSucceed, onConnecteFailed, onRecved, onClose, onClosed);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 9 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && translator.Assignable<NetWork.OnConnectedSucceed>(L, 6) && translator.Assignable<NetWork.OnConnectedFailed>(L, 7) && translator.Assignable<NetWork.OnSocketRecv>(L, 8) && translator.Assignable<NetWork.OnConnectClose>(L, 9))
				{
					string targetName = LuaAPI.lua_tostring(L, 2);
					string ip = LuaAPI.lua_tostring(L, 3);
					short port = (short)LuaAPI.xlua_tointeger(L, 4);
					int maxReconnectTimes = LuaAPI.xlua_tointeger(L, 5);
					NetWork.OnConnectedSucceed onConnecteSucceed = translator.GetDelegate<NetWork.OnConnectedSucceed>(L, 6);
					NetWork.OnConnectedFailed onConnecteFailed = translator.GetDelegate<NetWork.OnConnectedFailed>(L, 7);
					NetWork.OnSocketRecv onRecved = translator.GetDelegate<NetWork.OnSocketRecv>(L, 8);
					NetWork.OnConnectClose onClose = translator.GetDelegate<NetWork.OnConnectClose>(L, 9);
					
					NetWork.NetSocket __cl_gen_ret = new NetWork.NetSocket(targetName, ip, port, maxReconnectTimes, onConnecteSucceed, onConnecteFailed, onRecved, onClose);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 8 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && translator.Assignable<NetWork.OnConnectedSucceed>(L, 6) && translator.Assignable<NetWork.OnConnectedFailed>(L, 7) && translator.Assignable<NetWork.OnSocketRecv>(L, 8))
				{
					string targetName = LuaAPI.lua_tostring(L, 2);
					string ip = LuaAPI.lua_tostring(L, 3);
					short port = (short)LuaAPI.xlua_tointeger(L, 4);
					int maxReconnectTimes = LuaAPI.xlua_tointeger(L, 5);
					NetWork.OnConnectedSucceed onConnecteSucceed = translator.GetDelegate<NetWork.OnConnectedSucceed>(L, 6);
					NetWork.OnConnectedFailed onConnecteFailed = translator.GetDelegate<NetWork.OnConnectedFailed>(L, 7);
					NetWork.OnSocketRecv onRecved = translator.GetDelegate<NetWork.OnSocketRecv>(L, 8);
					
					NetWork.NetSocket __cl_gen_ret = new NetWork.NetSocket(targetName, ip, port, maxReconnectTimes, onConnecteSucceed, onConnecteFailed, onRecved);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 7 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && translator.Assignable<NetWork.OnConnectedSucceed>(L, 6) && translator.Assignable<NetWork.OnConnectedFailed>(L, 7))
				{
					string targetName = LuaAPI.lua_tostring(L, 2);
					string ip = LuaAPI.lua_tostring(L, 3);
					short port = (short)LuaAPI.xlua_tointeger(L, 4);
					int maxReconnectTimes = LuaAPI.xlua_tointeger(L, 5);
					NetWork.OnConnectedSucceed onConnecteSucceed = translator.GetDelegate<NetWork.OnConnectedSucceed>(L, 6);
					NetWork.OnConnectedFailed onConnecteFailed = translator.GetDelegate<NetWork.OnConnectedFailed>(L, 7);
					
					NetWork.NetSocket __cl_gen_ret = new NetWork.NetSocket(targetName, ip, port, maxReconnectTimes, onConnecteSucceed, onConnecteFailed);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 6 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && translator.Assignable<NetWork.OnConnectedSucceed>(L, 6))
				{
					string targetName = LuaAPI.lua_tostring(L, 2);
					string ip = LuaAPI.lua_tostring(L, 3);
					short port = (short)LuaAPI.xlua_tointeger(L, 4);
					int maxReconnectTimes = LuaAPI.xlua_tointeger(L, 5);
					NetWork.OnConnectedSucceed onConnecteSucceed = translator.GetDelegate<NetWork.OnConnectedSucceed>(L, 6);
					
					NetWork.NetSocket __cl_gen_ret = new NetWork.NetSocket(targetName, ip, port, maxReconnectTimes, onConnecteSucceed);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5))
				{
					string targetName = LuaAPI.lua_tostring(L, 2);
					string ip = LuaAPI.lua_tostring(L, 3);
					short port = (short)LuaAPI.xlua_tointeger(L, 4);
					int maxReconnectTimes = LuaAPI.xlua_tointeger(L, 5);
					
					NetWork.NetSocket __cl_gen_ret = new NetWork.NetSocket(targetName, ip, port, maxReconnectTimes);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					string targetName = LuaAPI.lua_tostring(L, 2);
					string ip = LuaAPI.lua_tostring(L, 3);
					short port = (short)LuaAPI.xlua_tointeger(L, 4);
					
					NetWork.NetSocket __cl_gen_ret = new NetWork.NetSocket(targetName, ip, port);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to NetWork.NetSocket constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Connect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string ip = LuaAPI.lua_tostring(L, 2);
                    short port = (short)LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Connect( ip, port );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DisConnect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.DisConnect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnConnected(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.OnConnected(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Close(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Send(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<NetWork.SendCallBack>(L, 3)&& translator.Assignable<NetWork.SendCallBack>(L, 4)) 
                {
                    byte[] bytes = LuaAPI.lua_tobytes(L, 2);
                    NetWork.SendCallBack ok = translator.GetDelegate<NetWork.SendCallBack>(L, 3);
                    NetWork.SendCallBack failed = translator.GetDelegate<NetWork.SendCallBack>(L, 4);
                    
                    __cl_gen_to_be_invoked.Send( bytes, ok, failed );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<NetWork.SendCallBack>(L, 3)) 
                {
                    byte[] bytes = LuaAPI.lua_tobytes(L, 2);
                    NetWork.SendCallBack ok = translator.GetDelegate<NetWork.SendCallBack>(L, 3);
                    
                    __cl_gen_to_be_invoked.Send( bytes, ok );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] bytes = LuaAPI.lua_tobytes(L, 2);
                    
                    __cl_gen_to_be_invoked.Send( bytes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to NetWork.NetSocket.Send!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Receive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Receive(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EStatus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.EStatus);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nextReconnectTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.nextReconnectTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_connected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.connected);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targetName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.targetName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_port(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.port);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxReconnectTimes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.maxReconnectTimes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onConnecteSucceed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onConnecteSucceed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onConnecteFailed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onConnecteFailed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onReconnectedSucceed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onReconnectedSucceed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSocketLogOut(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onSocketLogOut);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_param(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.param);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onClose);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onClosed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onClosed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_socket(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.socket);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSendCB(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mSendCB);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onRecv(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onRecv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mRecvEvents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mRecvEvents);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mRecvCB(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mRecvCB);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EStatus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                NetWork.NetSocket.SocketStatus __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.EStatus = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targetName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.targetName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ip = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_port(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.port = (short)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxReconnectTimes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.maxReconnectTimes = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onConnecteSucceed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onConnecteSucceed = translator.GetDelegate<NetWork.OnConnectedSucceed>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onConnecteFailed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onConnecteFailed = translator.GetDelegate<NetWork.OnConnectedFailed>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onReconnectedSucceed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onReconnectedSucceed = translator.GetDelegate<NetWork.OnReconnectedSucceed>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSocketLogOut(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onSocketLogOut = translator.GetDelegate<NetWork.OnSocketLogOut>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_param(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.param = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onClose = translator.GetDelegate<NetWork.OnConnectClose>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onClosed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onClosed = translator.GetDelegate<NetWork.OnConnectClosed>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_socket(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.socket = (System.Net.Sockets.Socket)translator.GetObject(L, 2, typeof(System.Net.Sockets.Socket));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSendCB(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSendCB = (System.Collections.Generic.List<NetWork.SendCallBack>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<NetWork.SendCallBack>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onRecv(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onRecv = translator.GetDelegate<NetWork.OnSocketRecv>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mRecvEvents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mRecvEvents = (System.Collections.Generic.Queue<NetWork.RecvEvent>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Queue<NetWork.RecvEvent>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mRecvCB(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NetWork.NetSocket __cl_gen_to_be_invoked = (NetWork.NetSocket)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mRecvCB = translator.GetDelegate<NetWork.AsyncRecvCb>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
