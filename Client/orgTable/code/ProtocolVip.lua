local descriptor = require "descriptor"

module "ProtocolVip"

Vip = descriptor.def_struct("Vip", 
	{
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("exp", descriptor.type_uint32, 0),
	}
)

SceneVipBuyItemReq = descriptor.def_message("SceneVipBuyItemReq", 503301, 
	{
		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
	}
)

SceneVipBuyItemRes = descriptor.def_message("SceneVipBuyItemRes", 503302, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

