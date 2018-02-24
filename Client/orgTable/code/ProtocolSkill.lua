local descriptor = require "descriptor"

module "ProtocolSkill"

Skill = descriptor.def_struct("Skill", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
	}
)

ChangeSkill = descriptor.def_struct("ChangeSkill", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("dif", descriptor.type_uint8, 0),
	}
)

Buff = descriptor.def_struct("Buff", 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("overlay", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("duration", descriptor.type_uint32, 0),
	}
)

SceneChangeSkillsReq = descriptor.def_message("SceneChangeSkillsReq", 500701, 
	{
		descriptor.def_message_vector_field("skills", ChangeSkill),
	}
)

SceneChangeSkillsRes = descriptor.def_message("SceneChangeSkillsRes", 500702, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneAddBuff = descriptor.def_message("SceneAddBuff", 500711, 
	{
		descriptor.def_scalar_field("buffId", descriptor.type_uint32, 0),
	}
)

SceneNotifyRemoveBuff = descriptor.def_message("SceneNotifyRemoveBuff", 500712, 
	{
		descriptor.def_scalar_field("buffId", descriptor.type_uint32, 0),
	}
)

