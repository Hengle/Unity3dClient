local descriptor = require "descriptor"

module "ProtocolRetinue"

RetinueUpType = descriptor.def_enum("RetinueUpType",
	{
		//  升级

		descriptor.def_enum_value("RUT_UPLEVEL", 1),
		// 升星

		descriptor.def_enum_value("RUT_UPSTAR", 2),
	}
)

RetinueSkill = descriptor.def_struct("RetinueSkill", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("bufferId", descriptor.type_uint32, 0),
	}
)

RetinueInfo = descriptor.def_struct("RetinueInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("starLevel", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("skills", RetinueSkill),
	}
)

SceneRetinue = descriptor.def_struct("SceneRetinue", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
	}
)

SceneSyncRetinueList = descriptor.def_message("SceneSyncRetinueList", 507001, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_vector_field("offRetinueIds", descriptor.type_uint64, 0),
		descriptor.def_message_vector_field("retinueList", RetinueInfo),
	}
)

SceneSyncRetinue = descriptor.def_message("SceneSyncRetinue", 507002, 
	{
		descriptor.def_message_field("info", RetinueInfo),
	}
)

SceneChanageRetinueReq = descriptor.def_message("SceneChanageRetinueReq", 507003, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("index", descriptor.type_uint8, 0),
	}
)

SceneChanageRetinueRes = descriptor.def_message("SceneChanageRetinueRes", 507004, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_vector_field("offRetinueIds", descriptor.type_uint64, 0),
	}
)

SceneRetinueChangeSkillReq = descriptor.def_message("SceneRetinueChangeSkillReq", 507005, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_vector_field("skillIds", descriptor.type_uint32, 0),
	}
)

SceneRetinueChangeSkillRes = descriptor.def_message("SceneRetinueChangeSkillRes", 507006, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneRetinueUnlockReq = descriptor.def_message("SceneRetinueUnlockReq", 507007, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
	}
)

SceneRetinueUnlockRes = descriptor.def_message("SceneRetinueUnlockRes", 507008, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
	}
)

SceneRetinueUpLevelReq = descriptor.def_message("SceneRetinueUpLevelReq", 507009, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

SceneRetinueUpLevelRes = descriptor.def_message("SceneRetinueUpLevelRes", 507010, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

