local descriptor = require "descriptor"

module "ProtocolSetting"

SkillBarGrid = descriptor.def_struct("SkillBarGrid", 
	{
		descriptor.def_scalar_field("slot", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint16, 0),
	}
)

SkillBar = descriptor.def_struct("SkillBar", 
	{
		descriptor.def_scalar_field("index", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("grids", SkillBarGrid),
	}
)

SkillBars = descriptor.def_struct("SkillBars", 
	{
		descriptor.def_scalar_field("index", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("bar", SkillBar),
	}
)

SceneExchangeSkillBarReq = descriptor.def_message("SceneExchangeSkillBarReq", 501201, 
	{
		descriptor.def_message_field("skillBars", SkillBars),
	}
)

SceneExchangeSkillBarRes = descriptor.def_message("SceneExchangeSkillBarRes", 501202, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneChangeOccu = descriptor.def_message("SceneChangeOccu", 501212, 
	{
		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
	}
)

SceneSyncFuncUnlock = descriptor.def_message("SceneSyncFuncUnlock", 501213, 
	{
		descriptor.def_scalar_field("funcId", descriptor.type_uint8, 0),
	}
)

