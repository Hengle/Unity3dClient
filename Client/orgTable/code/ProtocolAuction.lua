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
		//  ���۸�����

		descriptor.def_enum_value("PriceAsc", 0),
		//  ���۸���

		descriptor.def_enum_value("PriceDesc", 1),
	}
)

AuctionSellDuration = descriptor.def_enum("AuctionSellDuration",
	{
		//  24Сʱ

		descriptor.def_enum_value("Hour_24", 0),
		//  48Сʱ

		descriptor.def_enum_value("Hour_48", 1),
	}
)

AuctionMainItemType = descriptor.def_enum("AuctionMainItemType",
	{
		//  ��Ч

		descriptor.def_enum_value("AMIT_INVALID", 0),
		//  ����

		descriptor.def_enum_value("AMIT_WEAPON", 1),
		//  ����

		descriptor.def_enum_value("AMIT_ARMOR", 2),
		//  ����

		descriptor.def_enum_value("AMIT_JEWELRY", 3),
		//  ����Ʒ

		descriptor.def_enum_value("AMIT_COST", 4),
		//  ����

		descriptor.def_enum_value("AMIT_MATERIAL", 5),
		//  ����

		descriptor.def_enum_value("AMIT_OTHER", 6),
		//  ����

		descriptor.def_enum_value("AMIT_NUM", 7),
	}
)

//  ������ˢ��ԭ��

AuctionRefreshReason = descriptor.def_enum("AuctionRefreshReason",
	{
		//  ����

		descriptor.def_enum_value("SRR_BUY", 0),
		//  �ϼ�

		descriptor.def_enum_value("SRR_SELL", 1),
		//  �¼�

		descriptor.def_enum_value("SRR_CANCEL", 2),
	}
)

AuctionQueryCondition = descriptor.def_struct("AuctionQueryCondition", 
	{
		//  ��������

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ��Ʒ������(AuctionMainItemType)

		descriptor.def_scalar_field("itemMainType", descriptor.type_uint8, 0),
		//  ��Ʒ������

		descriptor.def_scalar_vector_field("itemSubTypes", descriptor.type_uint32, 0),
		//  ��ƷID

		descriptor.def_scalar_field("itemTypeID", descriptor.type_uint32, 0),
		//  Ʒ��

		descriptor.def_scalar_field("quality", descriptor.type_uint8, 0),
		//  �����Ʒ�ȼ�

		descriptor.def_scalar_field("minLevel", descriptor.type_uint8, 0),
		//  �����Ʒ�ȼ�

		descriptor.def_scalar_field("maxLevel", descriptor.type_uint8, 0),
		//  ���ǿ���ȼ�

		descriptor.def_scalar_field("minStrength", descriptor.type_uint8, 0),
		//  ���ǿ���ȼ�

		descriptor.def_scalar_field("maxStrength", descriptor.type_uint8, 0),
		//  ����ʽ����Ӧö��AuctionSortType��

		descriptor.def_scalar_field("sortType", descriptor.type_uint8, 0),
		//  ҳ��

		descriptor.def_scalar_field("page", descriptor.type_uint16, 0),
		//  ÿҳ��Ʒ����

		descriptor.def_scalar_field("itemNumPerPage", descriptor.type_uint8, 0),
	}
)

//  �����е��߻�����Ϣ�����ͣ�������

AuctionItemBaseInfo = descriptor.def_struct("AuctionItemBaseInfo", 
	{
		//  ����ID

		descriptor.def_scalar_field("itemTypeId", descriptor.type_uint32, 0),
		//  ��������

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
		//  Ψһid

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
		//  ��������

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ��������id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ������������id

		descriptor.def_scalar_field("typeId", descriptor.type_uint32, 0),
		//  ����

		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
		//  �۸�

		descriptor.def_scalar_field("price", descriptor.type_uint32, 0),
		//  ����ʱ��(AuctionSellDuration)

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
		//  ����������

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ԭ��

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

//  ��ѯ�����е�������

WorldAuctionItemNumReq = descriptor.def_message("WorldAuctionItemNumReq", 603920, 
	{
		descriptor.def_message_field("cond", AuctionQueryCondition),
	}
)

//  ���������е�������

WorldAuctionItemNumRes = descriptor.def_message("WorldAuctionItemNumRes", 603921, 
	{
		descriptor.def_message_vector_field("items", AuctionItemBaseInfo),
	}
)

//  ˢ��������ʱ������

SceneAuctionRefreshReq = descriptor.def_message("SceneAuctionRefreshReq", 503901, 
	{
	}
)

//  ˢ��������ʱ�䷵��

SceneAuctionRefreshRes = descriptor.def_message("SceneAuctionRefreshRes", 503902, 
	{
		//  ���

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ������������λ����

SceneAuctionBuyBoothReq = descriptor.def_message("SceneAuctionBuyBoothReq", 503903, 
	{
	}
)

//  ������������λ����

SceneAuctionBuyBoothRes = descriptor.def_message("SceneAuctionBuyBoothRes", 503904, 
	{
		//  ���

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  ��λ��

		descriptor.def_scalar_field("boothNum", descriptor.type_uint32, 0),
	}
)

