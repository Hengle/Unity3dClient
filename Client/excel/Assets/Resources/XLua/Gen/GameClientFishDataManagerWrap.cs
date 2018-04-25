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
    public class GameClientFishDataManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameClient.FishDataManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 26, 6, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSceneBG", _m_GetSceneBG);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRealChairID", _m_GetRealChairID);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearLockFish", _m_ClearLockFish);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Get", _m_Get);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendCmdCatchFish", _m_SendCmdCatchFish);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateFish", _m_CreateFish);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Release", _m_Release);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Initialize", _m_Initialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCurrentTime", _m_getCurrentTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "fixCurrentTime", _m_fixCurrentTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpDataUpScoreHitFish", _m_UpDataUpScoreHitFish);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpDataUpScore", _m_UpDataUpScore);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSuperPao", _m_SetSuperPao);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUserScore", _m_SetUserScore);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpDataBeiLv", _m_UpDataBeiLv);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPlayerScore", _m_GetPlayerScore);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBulletType", _m_GetBulletType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBulletPower", _m_GetBulletPower);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCannonPath", _m_GetCannonPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLockedFishId", _m_GetLockedFishId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetLockedFishId", _m_SetLockedFishId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateCatchChainCmd", _m_CreateCatchChainCmd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateSwitchScene", _m_CreateSwitchScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SwitchChairID", _m_SwitchChairID);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExecuteCmd", _m_ExecuteCmd);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "BgCount", _g_get_BgCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FishScene", _g_get_FishScene);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CanSend", _g_get_CanSend);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GameConfig", _g_get_GameConfig);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "chairId", _g_get_chairId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sceneAudioHandle", _g_get_sceneAudioHandle);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "CanSend", _s_set_CanSend);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "chairId", _s_set_chairId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "sceneAudioHandle", _s_set_sceneAudioHandle);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Instance", _m_Instance_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameClient.FishDataManager __cl_gen_ret = new GameClient.FishDataManager();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.FishDataManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSceneBG(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetSceneBG( index );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRealChairID(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int local = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetRealChairID( local );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearLockFish(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.ClearLockFish(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Get(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameClient.FishData __cl_gen_ret = __cl_gen_to_be_invoked.Get(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendCmdCatchFish(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.CMD_C_CatchFish cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.SendCmdCatchFish( cmd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateFish(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.FishKind kind;translator.Get(L, 2, out kind);
                    int fish_id = LuaAPI.xlua_tointeger(L, 3);
                    GameClient.FishActionFishMove action = (GameClient.FishActionFishMove)translator.GetObject(L, 4, typeof(GameClient.FishActionFishMove));
                    
                    __cl_gen_to_be_invoked.CreateFish( kind, fish_id, action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Release(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.FishData data = (GameClient.FishData)translator.GetObject(L, 2, typeof(GameClient.FishData));
                    
                    __cl_gen_to_be_invoked.Release( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Instance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        GameClient.FishDataManager __cl_gen_ret = GameClient.FishDataManager.Instance(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
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
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Initialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getCurrentTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.getCurrentTime(  );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_fixCurrentTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ulong current = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.fixCurrentTime( current );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpDataUpScoreHitFish(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    long UpScore = LuaAPI.lua_toint64(L, 3);
                    
                    __cl_gen_to_be_invoked.UpDataUpScoreHitFish( chairID, UpScore );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpDataUpScore(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    long UpScore = LuaAPI.lua_toint64(L, 3);
                    
                    __cl_gen_to_be_invoked.UpDataUpScore( chairID, UpScore );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSuperPao(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    bool bSuperPao = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetSuperPao( chairID, bSuperPao );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUserScore(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    long userScore = LuaAPI.lua_toint64(L, 3);
                    
                    __cl_gen_to_be_invoked.SetUserScore( chairID, userScore );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpDataBeiLv(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    int BeiLv = LuaAPI.xlua_tointeger(L, 3);
                    bool Runaction = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.UpDataBeiLv( chairID, BeiLv, Runaction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerScore(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    
                        long __cl_gen_ret = __cl_gen_to_be_invoked.GetPlayerScore( chairID );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBulletType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetBulletType( chairID );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBulletPower(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetBulletPower( chairID );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCannonPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int cannonId = LuaAPI.xlua_tointeger(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetCannonPath( cannonId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLockedFishId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetLockedFishId( chairID );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLockedFishId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int chairID = LuaAPI.xlua_tointeger(L, 2);
                    int fishId = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.SetLockedFishId( chairID, fishId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateCatchChainCmd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.CreateCatchChainCmd(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateSwitchScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameClient.SceneKind scene;translator.Get(L, 2, out scene);
                    
                    __cl_gen_to_be_invoked.CreateSwitchScene( scene );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchChairID(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    short nCurChairId = (short)LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.SwitchChairID( nCurChairId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExecuteCmd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_SwitchScene>(L, 2)) 
                {
                    GameClient.CMD_S_SwitchScene cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_UserFire>(L, 2)) 
                {
                    GameClient.CMD_S_UserFire cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_BulletDoubleTimeout>(L, 2)) 
                {
                    GameClient.CMD_S_BulletDoubleTimeout cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_ExchangeFishScore>(L, 2)) 
                {
                    GameClient.CMD_S_ExchangeFishScore cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_CatchChain>(L, 2)) 
                {
                    GameClient.CMD_S_CatchChain cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_CatchFishGroup>(L, 2)) 
                {
                    GameClient.CMD_S_CatchFishGroup catch_fish_group;translator.Get(L, 2, out catch_fish_group);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( catch_fish_group );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_SceneFish>(L, 2)) 
                {
                    GameClient.CMD_S_SceneFish cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_DistributeFish>(L, 2)) 
                {
                    GameClient.CMD_S_DistributeFish cmd;translator.Get(L, 2, out cmd);
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<GameClient.CMD_S_GameStatus>(L, 2)) 
                {
                    GameClient.CMD_S_GameStatus cmd = (GameClient.CMD_S_GameStatus)translator.GetObject(L, 2, typeof(GameClient.CMD_S_GameStatus));
                    
                    __cl_gen_to_be_invoked.ExecuteCmd( cmd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameClient.FishDataManager.ExecuteCmd!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BgCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.BgCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FishScene(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FishScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanSend(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanSend);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GameConfig(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GameConfig);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_chairId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.chairId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sceneAudioHandle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.sceneAudioHandle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanSend(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanSend = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_chairId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.chairId = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sceneAudioHandle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameClient.FishDataManager __cl_gen_to_be_invoked = (GameClient.FishDataManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sceneAudioHandle = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
