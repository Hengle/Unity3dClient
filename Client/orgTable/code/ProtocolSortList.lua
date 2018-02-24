local descriptor = require "descriptor"

module "ProtocolSortList"

WorldSortListReq = descriptor.def_message("WorldSortListReq", 602601, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("start", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

WorldSortListRet = descriptor.def_message("WorldSortListRet", 602602, 
	{
	}
)

WorldSortListSelfInfoReq = descriptor.def_message("WorldSortListSelfInfoReq", 602610, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

WorldSortListSelfInfoRet = descriptor.def_message("WorldSortListSelfInfoRet", 602611, 
	{
		descriptor.def_scalar_field("ranking", descriptor.type_uint32, 0),
	}
)

WorldSortListWatchDataReq = descriptor.def_message("WorldSortListWatchDataReq", 602603, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

