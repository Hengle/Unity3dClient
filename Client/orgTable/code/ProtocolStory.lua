local descriptor = require "descriptor"

module "ProtocolStory"

SceneNotifyNewBoot = descriptor.def_message("SceneNotifyNewBoot", 505402, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
	}
)

SceneNotifyBootFlag = descriptor.def_message("SceneNotifyBootFlag", 505403, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
	}
)

