local descriptor = require "descriptor"

module "ProtocolBase"

//  请求类型

RequestType = descriptor.def_enum("RequestType",
	{
		//  邀请组队

		descriptor.def_enum_value("InviteTeam", 1),
		//  根据玩家ID请求入队

		descriptor.def_enum_value("JoinTeam", 2),
		descriptor.def_enum_value("RequestFriend", 3),
		//  根据队伍ID加入队伍

		descriptor.def_enum_value("JoinTeamByTeamID", 21),
		descriptor.def_enum_value("RequestFriendByName", 29),
		//  挑战

		descriptor.def_enum_value("Request_Challenge_PK", 30),
		//  邀请公会

		descriptor.def_enum_value("InviteJoinGuild", 31),
	}
)

HeartBeatMsg = descriptor.def_message("HeartBeatMsg", 0, 
	{
	}
)

GateSyncServerTime = descriptor.def_message("GateSyncServerTime", 300309, 
	{
		descriptor.def_scalar_field("time", descriptor.type_uint32, 0),
	}
)

SockAddr = descriptor.def_struct("SockAddr", 
	{
		descriptor.def_scalar_field("ip", descriptor.type_string, ""),
		descriptor.def_scalar_field("port", descriptor.type_uint16, 0),
	}
)

PlayerAvatar = descriptor.def_struct("PlayerAvatar", 
	{
		descriptor.def_scalar_vector_field("equipItemIds", descriptor.type_uint32, 0),
		//  武器强化等级

		descriptor.def_scalar_field("weaponStrengthen", descriptor.type_uint8, 0),
	}
)

RoleInfo = descriptor.def_struct("RoleInfo", 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("strRoleId", descriptor.type_string, ""),
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("sex", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("occupation", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("offlineTime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("deleteTime", descriptor.type_uint32, 0),
		descriptor.def_message_field("avatar", PlayerAvatar),
		descriptor.def_scalar_field("newboot", descriptor.type_uint32, 0),
	}
)

//  发出请求

SceneRequest = descriptor.def_message("SceneRequest", 500804, 
	{
		//  类型(对应枚举RequestType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  目标ID

		descriptor.def_scalar_field("target", descriptor.type_uint64, 0),
		//  目标名字

		descriptor.def_scalar_field("targetName", descriptor.type_string, ""),
		//  附加参数

		descriptor.def_scalar_field("param", descriptor.type_uint32, 0),
	}
)

//  同步请求

SceneSyncRequest = descriptor.def_message("SceneSyncRequest", 500805, 
	{
		//  类型(对应枚举RequestType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  请求者

		descriptor.def_scalar_field("requester", descriptor.type_uint64, 0),
		//  请求者名字

		descriptor.def_scalar_field("requesterName", descriptor.type_string, ""),
		//  请求者性别

		descriptor.def_scalar_field("requesterOccu", descriptor.type_uint8, 0),
		//  请求者等级

		descriptor.def_scalar_field("requesterLevel", descriptor.type_uint16, 0),
		//  附带参数1

		descriptor.def_scalar_field("param1", descriptor.type_string, ""),
		// vip等级

		descriptor.def_scalar_field("requesterVipLv", descriptor.type_uint8, 0),
	}
)

//  答复

SceneReply = descriptor.def_message("SceneReply", 500806, 
	{
		// 类型(对应枚举RequestType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		// 请求者

		descriptor.def_scalar_field("requester", descriptor.type_uint64, 0),
		// 结果	1为接收 0为拒接

		descriptor.def_scalar_field("result", descriptor.type_uint8, 0),
	}
)

//  头像

PlayerIcon = descriptor.def_struct("PlayerIcon", 
	{
		//  ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
	}
)

