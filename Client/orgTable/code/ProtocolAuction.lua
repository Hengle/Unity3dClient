local descriptor = require "descriptor"

module "ProtocolAuction"

AuctionType = descriptor.def_enum("AuctionType",
	{
		descriptor.def_enum_value("Item", 0),
		descriptor.def_enum_value("Gold", 1),
	}
)

AuctionSortType = descriptor.def_enum("AuctionSortType",
	{
		//  按价格升序

		descriptor.def_enum_value("PriceAsc", 0),
		//  按价格降序

		descriptor.def_enum_value("PriceDesc", 1),
	}
)

AuctionSellDuration = descriptor.def_enum("AuctionSellDuration",
	{
		//  24小时

		descriptor.def_enum_value("Hour_24", 0),
		//  48小时

		descriptor.def_enum_value("Hour_48", 1),
	}
)

AuctionMainItemType = descriptor.def_enum("AuctionMainItemType",
	{
		//  无效

		descriptor.def_enum_value("AMIT_INVALID", 0),
		//  武器

		descriptor.def_enum_value("AMIT_WEAPON", 1),
		//  防具

		descriptor.def_enum_value("AMIT_ARMOR", 2),
		//  首饰

		descriptor.def_enum_value("AMIT_JEWELRY", 3),
		//  消耗品

		descriptor.def_enum_value("AMIT_COST", 4),
		//  材料

		descriptor.def_enum_value("AMIT_MATERIAL", 5),
		//  其它

		descriptor.def_enum_value("AMIT_OTHER", 6),
		//  数量

		descriptor.def_enum_value("AMIT_NUM", 7),
	}
)

//  拍卖行刷新原因

AuctionRefreshReason = descriptor.def_enum("AuctionRefreshReason",
	{
		//  购买

		descriptor.def_enum_value("SRR_BUY", 0),
		//  上架

		descriptor.def_enum_value("SRR_SELL", 1),
		//  下架

		descriptor.def_enum_value("SRR_CANCEL", 2),
	}
)

AuctionQueryCondition = descriptor.def_struct("AuctionQueryCondition", 
	{
		//  拍卖类型

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  物品主类型(AuctionMainItemType)

		descriptor.def_scalar_field("itemMainType", descriptor.type_uint8, 0),
		//  物品子类型

		descriptor.def_scalar_vector_field("itemSubTypes", descriptor.type_uint32, 0),
		//  物品ID

		descriptor.def_scalar_field("itemTypeID", descriptor.type_uint32, 0),
		//  品质

		descriptor.def_scalar_field("quality", descriptor.type_uint8, 0),
		//  最低物品等级

		descriptor.def_scalar_field("minLevel", descriptor.type_uint8, 0),
		//  最高物品等级

		descriptor.def_scalar_field("maxLevel", descriptor.type_uint8, 0),
		//  最低强化等级

		descriptor.def_scalar_field("minStrength", descriptor.type_uint8, 0),
		//  最高强化等级

		descriptor.def_scalar_field("maxStrength", descriptor.type_uint8, 0),
		//  排序方式（对应枚举AuctionSortType）

		descriptor.def_scalar_field("sortType", descriptor.type_uint8, 0),
		//  页数

		descriptor.def_scalar_field("page", descriptor.type_uint16, 0),
		//  每页物品数量

		descriptor.def_scalar_field("itemNumPerPage", descriptor.type_uint8, 0),
	}
)

//  拍卖行道具基本信息（类型，数量）

AuctionItemBaseInfo = descriptor.def_struct("AuctionItemBaseInfo", 
	{
		//  道具ID

		descriptor.def_scalar_field("itemTypeId", descriptor.type_uint32, 0),
		//  道具数量

		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
	}
)

WorldAuctionListReq = descriptor.def_message("WorldAuctionListReq", 603901, 
	{
		descriptor.def_message_field("cond", AuctionQueryCondition),
	}
)

AuctionBaseInfo = descriptor.def_struct("AuctionBaseInfo", 
	{
		//  唯一id

		descriptor.def_scalar_field("guid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("price", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("pricetype", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("duetime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("itemTypeId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("strengthed", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("itemScore", descriptor.type_uint32, 0),
	}
)

WorldAuctionListQueryRet = descriptor.def_message("WorldAuctionListQueryRet", 603902, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("data", AuctionBaseInfo),
		descriptor.def_scalar_field("curPage", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("maxPage", descriptor.type_uint32, 0),
	}
)

WorldAuctionSelfListReq = descriptor.def_message("WorldAuctionSelfListReq", 603904, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

WorldAuctionSelfListRes = descriptor.def_message("WorldAuctionSelfListRes", 603905, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("data", AuctionBaseInfo),
	}
)

WorldAuctionRequest = descriptor.def_message("WorldAuctionRequest", 603906, 
	{
		//  拍卖类型

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  拍卖道具id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  拍卖道具类型id

		descriptor.def_scalar_field("typeId", descriptor.type_uint32, 0),
		//  数量

		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
		//  价格

		descriptor.def_scalar_field("price", descriptor.type_uint32, 0),
		//  持续时间(AuctionSellDuration)

		descriptor.def_scalar_field("duration", descriptor.type_uint8, 0),
	}
)

WorldAuctionBuy = descriptor.def_message("WorldAuctionBuy", 603908, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
	}
)

WorldAuctionCancel = descriptor.def_message("WorldAuctionCancel", 603909, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

WorldAuctionNotifyRefresh = descriptor.def_message("WorldAuctionNotifyRefresh", 603911, 
	{
		//  拍卖行类型

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  原因

		descriptor.def_scalar_field("reason", descriptor.type_uint8, 0),
	}
)

WorldAuctionQueryItemReq = descriptor.def_message("WorldAuctionQueryItemReq", 603916, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

WorldAuctionQueryItemRet = descriptor.def_message("WorldAuctionQueryItemRet", 603917, 
	{
	}
)

WorldAuctionRecommendPriceReq = descriptor.def_message("WorldAuctionRecommendPriceReq", 603918, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("itemTypeId", descriptor.type_uint32, 0),
	}
)

WorldAuctionRecommendPriceRes = descriptor.def_message("WorldAuctionRecommendPriceRes", 603919, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("itemTypeId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("price", descriptor.type_uint32, 0),
	}
)

//  查询拍卖行道具数量

WorldAuctionItemNumReq = descriptor.def_message("WorldAuctionItemNumReq", 603920, 
	{
		descriptor.def_message_field("cond", AuctionQueryCondition),
	}
)

//  返回拍卖行道具数量

WorldAuctionItemNumRes = descriptor.def_message("WorldAuctionItemNumRes", 603921, 
	{
		descriptor.def_message_vector_field("items", AuctionItemBaseInfo),
	}
)

//  刷新拍卖行时间请求

SceneAuctionRefreshReq = descriptor.def_message("SceneAuctionRefreshReq", 503901, 
	{
	}
)

//  刷新拍卖行时间返回

SceneAuctionRefreshRes = descriptor.def_message("SceneAuctionRefreshRes", 503902, 
	{
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  购买拍卖行栏位请求

SceneAuctionBuyBoothReq = descriptor.def_message("SceneAuctionBuyBoothReq", 503903, 
	{
	}
)

//  购买拍卖行栏位返回

SceneAuctionBuyBoothRes = descriptor.def_message("SceneAuctionBuyBoothRes", 503904, 
	{
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  栏位数

		descriptor.def_scalar_field("boothNum", descriptor.type_uint32, 0),
	}
)

