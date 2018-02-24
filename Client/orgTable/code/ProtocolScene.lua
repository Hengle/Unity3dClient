local descriptor = require "descriptor"

module "ProtocolScene"

SceneObjectStatus = descriptor.def_enum("SceneObjectStatus",
	{
		descriptor.def_enum_value("SOS_STAND", 0),
		descriptor.def_enum_value("SOS_WALK", 2),
	}
)

//  红点标记

RedPointFlag = descriptor.def_enum("RedPointFlag",
	{
		//  公会请求者

		descriptor.def_enum_value("GUILD_REQUESTER", 0),
		//  公会商店

		descriptor.def_enum_value("GUILD_SHOP", 1),
	}
)

ScenePosition = descriptor.def_struct("ScenePosition", 
	{
		descriptor.def_scalar_field("x", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("y", descriptor.type_uint32, 0),
	}
)

SceneDir = descriptor.def_struct("SceneDir", 
	{
		descriptor.def_scalar_field("x", descriptor.type_int16, 0),
		descriptor.def_scalar_field("y", descriptor.type_int16, 0),
		descriptor.def_scalar_field("faceRight", descriptor.type_uint8, 0),
	}
)

SceneNotifyEnterScene = descriptor.def_message("SceneNotifyEnterScene", 500303, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("mapid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_message_field("pos", ScenePosition),
		descriptor.def_message_field("dir", SceneDir),
	}
)

SceneMoveRequire = descriptor.def_message("SceneMoveRequire", 500501, 
	{
		descriptor.def_message_field("pos", ScenePosition),
		descriptor.def_message_field("dir", SceneDir),
	}
)

SceneSyncPlayerMove = descriptor.def_message("SceneSyncPlayerMove", 500502, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_message_field("pos", ScenePosition),
		descriptor.def_message_field("dir", SceneDir),
	}
)

SceneSynSelf = descriptor.def_message("SceneSynSelf", 500601, 
	{
	}
)

SceneSyncSceneObject = descriptor.def_message("SceneSyncSceneObject", 500602, 
	{
	}
)

SceneSyncObjectProperty = descriptor.def_message("SceneSyncObjectProperty", 500603, 
	{
	}
)

SceneDeleteSceneObject = descriptor.def_message("SceneDeleteSceneObject", 500604, 
	{
	}
)

SceneReturnToTown = descriptor.def_message("SceneReturnToTown", 500517, 
	{
	}
)

ScenePlayerChangeSceneReq = descriptor.def_message("ScenePlayerChangeSceneReq", 500503, 
	{
		descriptor.def_scalar_field("curDoorId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("dstSceneId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("dstDoorId", descriptor.type_uint32, 0),
	}
)

//  清除公会红点

SceneClearRedPoint = descriptor.def_message("SceneClearRedPoint", 500617, 
	{
		//  红点类型（对应枚举RedPointFlag）

		descriptor.def_scalar_field("flag", descriptor.type_uint32, 0),
	}
)

//  设置用户自定义字段

SceneSetCustomData = descriptor.def_message("SceneSetCustomData", 500620, 
	{
		descriptor.def_scalar_field("data", descriptor.type_uint32, 0),
	}
)

