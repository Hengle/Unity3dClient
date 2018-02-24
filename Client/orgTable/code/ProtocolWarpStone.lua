local descriptor = require "descriptor"

module "ProtocolWarpStone"

WarpStoneInfo = descriptor.def_struct("WarpStoneInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("energy", descriptor.type_uint32, 0),
	}
)

ChargeInfo = descriptor.def_struct("ChargeInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
	}
)

SceneWarpStoneUnlockReq = descriptor.def_message("SceneWarpStoneUnlockReq", 506901, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
	}
)

SceneWarpStoneUnlockRes = descriptor.def_message("SceneWarpStoneUnlockRes", 506902, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneWarpStoneChargeReq = descriptor.def_message("SceneWarpStoneChargeReq", 506903, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("info", ChargeInfo),
	}
)

SceneWarpStoneChargeRes = descriptor.def_message("SceneWarpStoneChargeRes", 506904, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

