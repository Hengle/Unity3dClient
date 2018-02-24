local descriptor = require "descriptor"
local ProtocolItem = require "ProtocolItem"

module "ProtolcolBilling"

//  充值商城类型

ChargeMallType = descriptor.def_enum("ChargeMallType",
	{
		//  充值商品

		descriptor.def_enum_value("Charge", 0),
		//  人民币礼包

		descriptor.def_enum_value("Packet", 1),
	}
)

ChargeGoodsTag = descriptor.def_enum("ChargeGoodsTag",
	{
		//  推荐

		descriptor.def_enum_value("Recommend", 1),
	}
)

//  充值商品

ChargeGoods = descriptor.def_struct("ChargeGoods", 
	{
		//  商品ID

		descriptor.def_scalar_field("id", descriptor.type_uint8, 0),
		//  描述

		descriptor.def_scalar_field("desc", descriptor.type_string, ""),
		//  标签（位组合）

		descriptor.def_scalar_field("tags", descriptor.type_uint32, 0),
		//  充值金额

		descriptor.def_scalar_field("money", descriptor.type_uint16, 0),
		//  获得的vip积分

		descriptor.def_scalar_field("vipScore", descriptor.type_uint16, 0),
		//  道具ID

		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		//  道具数量

		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
		//  首冲数量补偿

		descriptor.def_scalar_field("firstAddNum", descriptor.type_uint16, 0),
		//  非首充数量补偿

		descriptor.def_scalar_field("unfirstAddNum", descriptor.type_uint16, 0),
		//  是否是首充

		descriptor.def_scalar_field("isFirstCharge", descriptor.type_uint8, 0),
		//  icon

		descriptor.def_scalar_field("icon", descriptor.type_string, ""),
		//  剩余天数

		descriptor.def_scalar_field("remainDays", descriptor.type_uint32, 0),
		//  剩余次数

		descriptor.def_scalar_field("remainTimes", descriptor.type_uint8, 0),
	}
)

//  充值礼包

ChargePacket = descriptor.def_struct("ChargePacket", 
	{
		//  商品ID

		descriptor.def_scalar_field("id", descriptor.type_uint8, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  原价

		descriptor.def_scalar_field("oldPrice", descriptor.type_uint16, 0),
		//  价格

		descriptor.def_scalar_field("money", descriptor.type_uint16, 0),
		//  获得的vip积分

		descriptor.def_scalar_field("vipScore", descriptor.type_uint16, 0),
		//  icon

		descriptor.def_scalar_field("icon", descriptor.type_string, ""),
		//  开始时间

		descriptor.def_scalar_field("startTime", descriptor.type_uint32, 0),
		//  结束时间

		descriptor.def_scalar_field("endTime", descriptor.type_uint32, 0),
		//  当天剩余次数

		descriptor.def_scalar_field("limitDailyNum", descriptor.type_uint16, 0),
		//  当天剩余次数

		descriptor.def_scalar_field("limitTotalNum", descriptor.type_uint16, 0),
		//  礼包内容

		descriptor.def_message_vector_field("rewards", ProtocolItem.ItemReward),
	}
)

WorldBillingGoodsReq = descriptor.def_message("WorldBillingGoodsReq", 604007, 
	{
	}
)

WorldBillingGoodsRes = descriptor.def_message("WorldBillingGoodsRes", 604008, 
	{
		descriptor.def_message_vector_field("goods", ChargeGoods),
	}
)

//  获取充值礼包商品

WorldBillingChargePacketReq = descriptor.def_message("WorldBillingChargePacketReq", 604009, 
	{
	}
)

//  返回充值礼包商品

WorldBillingChargePacketRes = descriptor.def_message("WorldBillingChargePacketRes", 604010, 
	{
		descriptor.def_message_vector_field("goods", ChargePacket),
	}
)

//  请求购买商品(这里只判断能不能买)

WorldBillingChargeReq = descriptor.def_message("WorldBillingChargeReq", 604011, 
	{
		//  商城类型

		descriptor.def_scalar_field("mallType", descriptor.type_uint8, 0),
		//  商品ID

		descriptor.def_scalar_field("goodsId", descriptor.type_uint32, 0),
	}
)

//  返回能否购买商品

WorldBillingChargeRes = descriptor.def_message("WorldBillingChargeRes", 604012, 
	{
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  通知客户端发货了

SceneBillingSendGoodsNotify = descriptor.def_message("SceneBillingSendGoodsNotify", 504003, 
	{
	}
)

