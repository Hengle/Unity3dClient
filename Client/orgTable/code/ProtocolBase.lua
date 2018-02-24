local descriptor = require "descriptor"

module "ProtocolBase"

//  ��������

RequestType = descriptor.def_enum("RequestType",
	{
		//  �������

		descriptor.def_enum_value("InviteTeam", 1),
		//  �������ID�������

		descriptor.def_enum_value("JoinTeam", 2),
		descriptor.def_enum_value("RequestFriend", 3),
		//  ���ݶ���ID�������

		descriptor.def_enum_value("JoinTeamByTeamID", 21),
		descriptor.def_enum_value("RequestFriendByName", 29),
		//  ��ս

		descriptor.def_enum_value("Request_Challenge_PK", 30),
		//  ���빫��

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
		//  ����ǿ���ȼ�

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

//  ��������

SceneRequest = descriptor.def_message("SceneRequest", 500804, 
	{
		//  ����(��Ӧö��RequestType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  Ŀ��ID

		descriptor.def_scalar_field("target", descriptor.type_uint64, 0),
		//  Ŀ������

		descriptor.def_scalar_field("targetName", descriptor.type_string, ""),
		//  ���Ӳ���

		descriptor.def_scalar_field("param", descriptor.type_uint32, 0),
	}
)

//  ͬ������

SceneSyncRequest = descriptor.def_message("SceneSyncRequest", 500805, 
	{
		//  ����(��Ӧö��RequestType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ������

		descriptor.def_scalar_field("requester", descriptor.type_uint64, 0),
		//  ����������

		descriptor.def_scalar_field("requesterName", descriptor.type_string, ""),
		//  �������Ա�

		descriptor.def_scalar_field("requesterOccu", descriptor.type_uint8, 0),
		//  �����ߵȼ�

		descriptor.def_scalar_field("requesterLevel", descriptor.type_uint16, 0),
		//  ��������1

		descriptor.def_scalar_field("param1", descriptor.type_string, ""),
		// vip�ȼ�

		descriptor.def_scalar_field("requesterVipLv", descriptor.type_uint8, 0),
	}
)

//  ��

SceneReply = descriptor.def_message("SceneReply", 500806, 
	{
		// ����(��Ӧö��RequestType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		// ������

		descriptor.def_scalar_field("requester", descriptor.type_uint64, 0),
		// ���	1Ϊ���� 0Ϊ�ܽ�

		descriptor.def_scalar_field("result", descriptor.type_uint8, 0),
	}
)

//  ͷ��

PlayerIcon = descriptor.def_struct("PlayerIcon", 
	{
		//  ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  ְҵ

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  �ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
	}
)

