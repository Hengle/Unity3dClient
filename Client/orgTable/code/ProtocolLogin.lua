local descriptor = require "descriptor"
local ProtocolBase = require "ProtocolBase"

module "ProtocolLogin"

AdminLoginVerifyReq = descriptor.def_message("AdminLoginVerifyReq", 200201, 
	{
		descriptor.def_scalar_field("param", descriptor.type_string, ""),
		descriptor.def_scalar_vector_field("hashValue", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("source1", descriptor.type_string, ""),
		descriptor.def_scalar_field("source2", descriptor.type_string, ""),
		descriptor.def_scalar_field("version", descriptor.type_uint32, 0),
	}
)

AdminLoginVerifyRet = descriptor.def_message("AdminLoginVerifyRet", 200202, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("errMsg", descriptor.type_string, ""),
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_message_field("addr", ProtocolBase.SockAddr),
		//  目录服务器校验签名

		descriptor.def_scalar_field("dirSig", descriptor.type_string, ""),
		//  录像服务器地址

		descriptor.def_scalar_field("replayAgentAddr", descriptor.type_string, ""),
		//  手机绑定的角色ID

		descriptor.def_scalar_field("phoneBindRoleId", descriptor.type_uint64, 0),
	}
)

GateClientLoginReq = descriptor.def_message("GateClientLoginReq", 300203, 
	{
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_scalar_vector_field("hashValue", descriptor.type_uint8, 0),
	}
)

GateClientLoginRet = descriptor.def_message("GateClientLoginRet", 300204, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("hasrole", descriptor.type_uint8, 0),
		//  需要等待的玩家数

		descriptor.def_scalar_field("waitPlayerNum", descriptor.type_uint32, 0),
	}
)

GateSendRoleInfo = descriptor.def_message("GateSendRoleInfo", 300301, 
	{
		descriptor.def_message_vector_field("roles", ProtocolBase.RoleInfo),
	}
)

GateCreateRoleReq = descriptor.def_message("GateCreateRoleReq", 300302, 
	{
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("sex", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("occupation", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("isnewer", descriptor.type_uint8, 0),
	}
)

GateCreateRoleRet = descriptor.def_message("GateCreateRoleRet", 300303, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

GateDeleteRoleReq = descriptor.def_message("GateDeleteRoleReq", 300304, 
	{
		descriptor.def_scalar_field("roldId", descriptor.type_uint64, 0),
	}
)

GateEnterGameReq = descriptor.def_message("GateEnterGameReq", 300306, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("option", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("city", descriptor.type_string, ""),
		descriptor.def_scalar_field("inviter", descriptor.type_uint32, 0),
	}
)

GateEnterGameRet = descriptor.def_message("GateEnterGameRet", 300307, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  离开游戏

GateLeaveGameReq = descriptor.def_message("GateLeaveGameReq", 300401, 
	{
	}
)

GateReconnectGameReq = descriptor.def_message("GateReconnectGameReq", 300311, 
	{
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("sequence", descriptor.type_uint32, 0),
		descriptor.def_scalar_vector_field("session", descriptor.type_uint8, 0),
	}
)

GateReconnectGameRes = descriptor.def_message("GateReconnectGameRes", 300312, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

GateRecoverRoleReq = descriptor.def_message("GateRecoverRoleReq", 300305, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
	}
)

//  恢复角色返回

GateRecoverRoleRes = descriptor.def_message("GateRecoverRoleRes", 300314, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("roleUpdateLimit", descriptor.type_string, ""),
	}
)

//  删除角色返回

GateDeleteRoleRes = descriptor.def_message("GateDeleteRoleRes", 300315, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("roleUpdateLimit", descriptor.type_string, ""),
	}
)

//  更新排队信息

GateNotifyLoginWaitInfo = descriptor.def_message("GateNotifyLoginWaitInfo", 300316, 
	{
		descriptor.def_scalar_field("waitPlayerNum", descriptor.type_uint32, 0),
	}
)

//  通知玩家可以登录了

GateNotifyAllowLogin = descriptor.def_message("GateNotifyAllowLogin", 300317, 
	{
	}
)

GateFinishNewbeeGuide = descriptor.def_message("GateFinishNewbeeGuide", 300313, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
	}
)

//  通知客户端被踢

GateNotifyKickoff = descriptor.def_message("GateNotifyKickoff", 300404, 
	{
		descriptor.def_scalar_field("errorCode", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("msg", descriptor.type_string, ""),
	}
)

