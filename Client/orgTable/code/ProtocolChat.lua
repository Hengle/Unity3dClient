local descriptor = require "descriptor"

module "ProtocolChat"

SceneChat = descriptor.def_message("SceneChat", 500801, 
	{
		descriptor.def_scalar_field("channel", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("word", descriptor.type_string, ""),
		descriptor.def_scalar_field("bLink", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("voiceKey", descriptor.type_string, ""),
		descriptor.def_scalar_field("voiceDuration", descriptor.type_uint8, 0),
	}
)

SceneNotifyExecGmcmd = descriptor.def_message("SceneNotifyExecGmcmd", 500802, 
	{
		descriptor.def_scalar_field("suc", descriptor.type_uint8, 0),
	}
)

//  系统提示, 服务器主动发出

SysNotify = descriptor.def_message("SysNotify", 11, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("word", descriptor.type_string, ""),
	}
)

//  系统公告, 服务器主动发出

SysAnnouncement = descriptor.def_message("SysAnnouncement", 25, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("word", descriptor.type_string, ""),
	}
)

// 同步聊天

SceneSyncChat = descriptor.def_message("SceneSyncChat", 500803, 
	{
		descriptor.def_scalar_field("channel", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("objid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("sex", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("viplvl", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("objname", descriptor.type_string, ""),
		descriptor.def_scalar_field("receiverId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("word", descriptor.type_string, ""),
		descriptor.def_scalar_field("bLink", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("isGm", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("voiceKey", descriptor.type_string, ""),
		descriptor.def_scalar_field("voiceDuration", descriptor.type_uint8, 0),
	}
)

// 请求聊天链接信息

WorldChatLinkDataReq = descriptor.def_message("WorldChatLinkDataReq", 600802, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
	}
)

// 请求聊天链接信息返回

WorldChatLinkDataRet = descriptor.def_message("WorldChatLinkDataRet", 600803, 
	{
	}
)

//  请求发送喇叭

SceneChatHornReq = descriptor.def_message("SceneChatHornReq", 500808, 
	{
		//  喇叭内容

		descriptor.def_scalar_field("content", descriptor.type_string, ""),
		//  一次性发送的喇叭数量

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  返回发送喇叭结果

SceneChatHornRes = descriptor.def_message("SceneChatHornRes", 500809, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

// 喇叭信息

HornInfo = descriptor.def_struct("HornInfo", 
	{
		// 角色id

		descriptor.def_scalar_field("roldId", descriptor.type_uint64, 0),
		// 名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// 职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		// 等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// vip等级

		descriptor.def_scalar_field("viplvl", descriptor.type_uint8, 0),
		//  内容

		descriptor.def_scalar_field("content", descriptor.type_string, ""),
		//  保护时间

		descriptor.def_scalar_field("minTime", descriptor.type_uint8, 0),
		//  持续时间

		descriptor.def_scalar_field("maxTime", descriptor.type_uint8, 0),
		//  combo数

		descriptor.def_scalar_field("combo", descriptor.type_uint16, 0),
		//  连发数量

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  广播喇叭给客户端

WorldChatHorn = descriptor.def_message("WorldChatHorn", 600815, 
	{
		//  喇叭信息

		descriptor.def_message_field("info", HornInfo),
	}
)

