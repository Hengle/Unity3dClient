local descriptor = require "descriptor"

module "ProtocolItem"

// 商城玩家绑定礼包激活条件

MallGiftPackActivateCond = descriptor.def_enum("MallGiftPackActivateCond",
	{
		// 无

		descriptor.def_enum_value("INVALID", 0),
		// 强化到10

		descriptor.def_enum_value("STRENGEN_TEN", 1),
		// 强化资源不足	

		descriptor.def_enum_value("STRENGEN_NO_RESOURCE", 2),
		// 品级调整箱不足

		descriptor.def_enum_value("NO_QUILTY_ADJUST_BOX", 3),
		// 疲劳不足，且背包中无疲劳药水

		descriptor.def_enum_value("NO_FATIGUE", 4),
		// 刷深渊门票不足	

		descriptor.def_enum_value("NO_HELL_TICKET", 5),
		// 刷远古门票不足	

		descriptor.def_enum_value("NO_ANCIENT_TICKET", 6),
		// 死亡

		descriptor.def_enum_value("DIE", 7),
		// 强化装备碎掉,推送10级装备

		descriptor.def_enum_value("STRENGEN_BROKE_TEN", 8),
		// 强化装备碎掉,推送15级装备

		descriptor.def_enum_value("STRENGEN_BROKE_FIFTEEN", 9),
		// 强化装备碎掉,推送20级装备

		descriptor.def_enum_value("STRENGEN_BROKE_TWENTY", 10),
		// 强化装备碎掉,推送25级装备

		descriptor.def_enum_value("STRENGEN_BROKE_TWENTY_FIVE", 11),
		// 强化装备碎掉,推送30级装备

		descriptor.def_enum_value("STRENGEN_BROKE_THIRTY", 12),
		// 强化装备碎掉,推送35级装备

		descriptor.def_enum_value("STRENGEN_BROKE_THIRTY_FIVE", 13),
		// 强化装备碎掉,推送40级装备

		descriptor.def_enum_value("STRENGEN_BROKE_FORTY", 14),
		// 强化装备碎掉,推送45级装备

		descriptor.def_enum_value("STRENGEN_BROKE_FORTY_FIVE", 15),
		// 强化装备碎掉,推送50级装备

		descriptor.def_enum_value("STRENGEN_BROKE_FIFTY", 16),
	}
)

// 商城商品类型

MallGoodsType = descriptor.def_enum("MallGoodsType",
	{
		// 普通商品

		descriptor.def_enum_value("INVALID", 0),
		// 礼包：可每日刷新

		descriptor.def_enum_value("GIFT_DAILY_REFRESH", 1),
		// 礼包：账号激活限制一次

		descriptor.def_enum_value("GIFT_ACTIVATE_ONCE", 2),
		// 礼包：账号激活限制三次礼包

		descriptor.def_enum_value("GIFT_ACTIVATE_THREE_TIMES", 3),
		// 普通商品：可多选一

		descriptor.def_enum_value("COMMON_CHOOSE_ONE", 4),
		// 礼包：限时活动

		descriptor.def_enum_value("GIFT_ACTIVITY", 5),
		// 礼包: 普通不刷新礼包

		descriptor.def_enum_value("GIFT_COMMON", 6),
	}
)

// 商城礼包活动状态

MallGiftPackActivityState = descriptor.def_enum("MallGiftPackActivityState",
	{
		// 无效

		descriptor.def_enum_value("GPAS_INVALID", 0),
		// 开放

		descriptor.def_enum_value("GPAS_OPEN", 1),
		// 关闭

		descriptor.def_enum_value("GPAS_CLOSED", 2),
	}
)

//  快速购买目标类型

QuickBuyTargetType = descriptor.def_enum("QuickBuyTargetType",
	{
		//  复活

		descriptor.def_enum_value("QUICK_BUY_REVIVE", 0),
		//  购买道具

		descriptor.def_enum_value("QUICK_BUY_ITEM", 1),
	}
)

FashionMergeResultType = descriptor.def_enum("FashionMergeResultType",
	{
		descriptor.def_enum_value("FMRT_NORMAL", 1),
		descriptor.def_enum_value("FMRT_SPECIAL", 2),
	}
)

ItemRandProp = descriptor.def_struct("ItemRandProp", 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("value", descriptor.type_uint32, 0),
	}
)

GemStone = descriptor.def_struct("GemStone", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
	}
)

ItemMagicProperty = descriptor.def_struct("ItemMagicProperty", 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		// 1.随机属性，2.buff

		descriptor.def_scalar_field("param1", descriptor.type_uint32, 0),
		// 随机属性: 属性id，buff:buffid

		descriptor.def_scalar_field("param2", descriptor.type_uint32, 0),
	}
)

// 随机属性: 属性值，buff:无用

ItemReward = descriptor.def_struct("ItemReward", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
		//  强化等级

		descriptor.def_scalar_field("strength", descriptor.type_uint8, 0),
	}
)

OpenJarResult = descriptor.def_struct("OpenJarResult", 
	{
		descriptor.def_scalar_field("jarItemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("itemUid", descriptor.type_uint64, 0),
	}
)

ItemCD = descriptor.def_struct("ItemCD", 
	{
		descriptor.def_scalar_field("groupid", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("endtime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("maxtime", descriptor.type_uint32, 0),
	}
)

MallItemInfo = descriptor.def_struct("MallItemInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("subtype", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("jobtype", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("itemid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("itemnum", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("price", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("discountprice", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("moneytype", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("limit", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("limitnum", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("gift", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("vipscore", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("icon", descriptor.type_string, ""),
		descriptor.def_scalar_field("starttime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("endtime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("limittotalnum", descriptor.type_uint16, 0),
		descriptor.def_message_vector_field("giftItems", ItemReward),
		descriptor.def_scalar_field("giftName", descriptor.type_string, ""),
		descriptor.def_scalar_field("tagType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("sortIdx", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("hotSortIdx", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("goodsSubType", descriptor.type_uint16, 0),
	}
)

SceneSynItem = descriptor.def_message("SceneSynItem", 500905, 
	{
	}
)

SceneSyncItemProp = descriptor.def_message("SceneSyncItemProp", 500906, 
	{
	}
)

SceneNotifyDeleteItem = descriptor.def_message("SceneNotifyDeleteItem", 500907, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
	}
)

SceneUseItem = descriptor.def_message("SceneUseItem", 500901, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("useAll", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("param1", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("param2", descriptor.type_uint32, 0),
	}
)

SceneUseItemRet = descriptor.def_message("SceneUseItemRet", 500902, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneSellItem = descriptor.def_message("SceneSellItem", 500903, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

SceneSellItemRet = descriptor.def_message("SceneSellItemRet", 500904, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneEnlargePackage = descriptor.def_message("SceneEnlargePackage", 500908, 
	{
	}
)

SceneEnlargePackageRet = descriptor.def_message("SceneEnlargePackageRet", 500917, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

ScenePushStorage = descriptor.def_message("ScenePushStorage", 500909, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

ScenePushStorageRet = descriptor.def_message("ScenePushStorageRet", 500911, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

ScenePullStorage = descriptor.def_message("ScenePullStorage", 500910, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

ScenePullStorageRet = descriptor.def_message("ScenePullStorageRet", 500912, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneEnlargeStorage = descriptor.def_message("SceneEnlargeStorage", 500913, 
	{
	}
)

SceneTrimItem = descriptor.def_message("SceneTrimItem", 500914, 
	{
		descriptor.def_scalar_field("pack", descriptor.type_uint8, 0),
	}
)

SceneTrimItemRet = descriptor.def_message("SceneTrimItemRet", 500915, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneNotifyGetItem = descriptor.def_message("SceneNotifyGetItem", 500916, 
	{
		descriptor.def_scalar_field("itemid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("quality", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
	}
)

SceneEquipDecompose = descriptor.def_message("SceneEquipDecompose", 500918, 
	{
		descriptor.def_scalar_vector_field("uids", descriptor.type_uint64, 0),
	}
)

SceneEquipDecomposeRet = descriptor.def_message("SceneEquipDecomposeRet", 500919, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("getItems", ItemReward),
	}
)

// 抽到的道具

SceneEquipStrengthen = descriptor.def_message("SceneEquipStrengthen", 500920, 
	{
		descriptor.def_scalar_field("euqipUid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("useUnbreak", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("strTickt", descriptor.type_uint64, 0),
	}
)

SceneEquipStrengthenRet = descriptor.def_message("SceneEquipStrengthenRet", 500921, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

// ------------商店start------------------------------

SceneShopQuery = descriptor.def_message("SceneShopQuery", 500922, 
	{
		descriptor.def_scalar_field("shopId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("cache", descriptor.type_uint8, 0),
	}
)

SceneShopQueryRet = descriptor.def_message("SceneShopQueryRet", 500923, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneShopBuy = descriptor.def_message("SceneShopBuy", 500924, 
	{
		descriptor.def_scalar_field("shopId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("shopItemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

SceneShopBuyRet = descriptor.def_message("SceneShopBuyRet", 500925, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("shopItemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("newNum", descriptor.type_uint16, 0),
	}
)

SceneShopSync = descriptor.def_message("SceneShopSync", 500926, 
	{
	}
)

SceneShopItemSync = descriptor.def_message("SceneShopItemSync", 500927, 
	{
	}
)

SceneShopRefresh = descriptor.def_message("SceneShopRefresh", 500932, 
	{
		descriptor.def_scalar_field("shopId", descriptor.type_uint8, 0),
	}
)

SceneShopRefreshRet = descriptor.def_message("SceneShopRefreshRet", 500933, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneShopRefreshNumReq = descriptor.def_message("SceneShopRefreshNumReq", 500956, 
	{
		descriptor.def_scalar_field("shopId", descriptor.type_uint8, 0),
	}
)

SceneShopRefreshNumRes = descriptor.def_message("SceneShopRefreshNumRes", 500957, 
	{
		descriptor.def_scalar_field("shopId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("restRefreshNum", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("maxRefreshNum", descriptor.type_uint8, 0),
	}
)

// ------------商店end------------------------------

SceneOneKeyPushStorage = descriptor.def_message("SceneOneKeyPushStorage", 500928, 
	{
	}
)

SceneOneKeyPushStorageRet = descriptor.def_message("SceneOneKeyPushStorageRet", 500929, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneEnlargeStorageRet = descriptor.def_message("SceneEnlargeStorageRet", 500930, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneUpdateNewItem = descriptor.def_message("SceneUpdateNewItem", 500931, 
	{
		descriptor.def_scalar_field("pack", descriptor.type_uint8, 0),
	}
)

SceneDungeonUseItem = descriptor.def_message("SceneDungeonUseItem", 500934, 
	{
		descriptor.def_scalar_field("itemid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

SceneSealEquipReq = descriptor.def_message("SceneSealEquipReq", 500937, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
	}
)

//  装备uid

SceneSealEquipRet = descriptor.def_message("SceneSealEquipRet", 500938, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

// 返回码

SceneCheckSealEquipReq = descriptor.def_message("SceneCheckSealEquipReq", 500939, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
	}
)

//  装备uid

SceneCheckSealEquipRet = descriptor.def_message("SceneCheckSealEquipRet", 500940, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		// 返回码

		descriptor.def_scalar_field("matID", descriptor.type_uint32, 0),
		// 材料ID

		descriptor.def_scalar_field("needNum", descriptor.type_uint16, 0),
	}
)

// 需要材料数量

SceneRandEquipQlvReq = descriptor.def_message("SceneRandEquipQlvReq", 500941, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		// 装备uid

		descriptor.def_scalar_field("bUsePoint", descriptor.type_uint8, 0),
	}
)

// 是否使用绑点代替

SceneRandEquipQlvRet = descriptor.def_message("SceneRandEquipQlvRet", 500942, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

// 返回码

// 开罐子返回

SceneUseMagicJarRet = descriptor.def_message("SceneUseMagicJarRet", 500943, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		// 返回码

		descriptor.def_scalar_field("jarID", descriptor.type_uint32, 0),
		// 罐子ID

		descriptor.def_message_vector_field("getItems", OpenJarResult),
		// 抽到的道具

		descriptor.def_message_field("baseItem", ItemReward),
		// 保底道具

		descriptor.def_scalar_field("getPointId", descriptor.type_uint32, 0),
		// 获得积分id

		descriptor.def_scalar_field("getPoint", descriptor.type_uint32, 0),
		// 获得积分数量

		descriptor.def_scalar_field("crit", descriptor.type_uint32, 0),
	}
)

// 暴击倍数

// 罐子积分请求

SceneJarPointReq = descriptor.def_message("SceneJarPointReq", 500960, 
	{
	}
)

// 罐子积分请求响应

SceneJarPointRes = descriptor.def_message("SceneJarPointRes", 500961, 
	{
		descriptor.def_scalar_field("goldPoint", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("magPoint", descriptor.type_uint32, 0),
	}
)

// 附魔请求

SceneAddMagicReq = descriptor.def_message("SceneAddMagicReq", 500944, 
	{
		descriptor.def_scalar_field("cardUid", descriptor.type_uint64, 0),
		// 附魔卡uid

		descriptor.def_scalar_field("itemUid", descriptor.type_uint64, 0),
	}
)

// 装备uid

// 附魔请求返回

SceneAddMagicRet = descriptor.def_message("SceneAddMagicRet", 500945, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		// 返回码

		descriptor.def_scalar_field("itemUid", descriptor.type_uint64, 0),
		// 附魔的道具

		descriptor.def_scalar_field("cardId", descriptor.type_uint32, 0),
	}
)

// 附魔的附魔卡表ID

// 附魔卡合成

SceneMagicCardCompReq = descriptor.def_message("SceneMagicCardCompReq", 500946, 
	{
		descriptor.def_scalar_field("cardA", descriptor.type_uint64, 0),
		// 附魔卡A

		descriptor.def_scalar_field("cardB", descriptor.type_uint64, 0),
	}
)

// 附魔卡B

// 附魔卡合成返回

SceneMagicCardCompRet = descriptor.def_message("SceneMagicCardCompRet", 500947, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		// 返回码

		descriptor.def_scalar_field("cardId", descriptor.type_uint32, 0),
	}
)

// 合成的附魔卡id	

// ------------商城相关-----------------------

// 激活商城限时礼包请求

WorldMallGiftPackActivateReq = descriptor.def_message("WorldMallGiftPackActivateReq", 602814, 
	{
		//  对应枚举MallGiftPackActivateCond

		descriptor.def_scalar_field("giftPackActCond", descriptor.type_uint8, 0),
	}
)

// 激活条件

// 激活商城限时礼包返回

WorldMallGiftPackActivateRet = descriptor.def_message("WorldMallGiftPackActivateRet", 602815, 
	{
		descriptor.def_message_vector_field("items", MallItemInfo),
		// 一个礼包

		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

// 错误码

// 同步商城礼包活动状态

SyncWorldMallGiftPackActivityState = descriptor.def_message("SyncWorldMallGiftPackActivityState", 602817, 
	{
		// 对应枚举MallGiftPackActivityState

		descriptor.def_scalar_field("state", descriptor.type_uint8, 0),
	}
)

// 商城礼包活动状态

// 查询商城道具请求

WorldMallQueryItemReq = descriptor.def_message("WorldMallQueryItemReq", 602803, 
	{
		descriptor.def_scalar_field("tagType", descriptor.type_uint8, 0),
		// 商城热门类索引,1-热门

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		// 商城主页签

		descriptor.def_scalar_field("subType", descriptor.type_uint8, 0),
		// 商城子页签

		descriptor.def_scalar_field("moneyType", descriptor.type_uint8, 0),
		// 货币类别

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		// 职业

		descriptor.def_scalar_field("updateTime", descriptor.type_uint32, 0),
	}
)

// 本地数据更新时间

// 查询商城道具返回

WorldMallQueryItemRet = descriptor.def_message("WorldMallQueryItemRet", 602804, 
	{
		descriptor.def_message_vector_field("items", MallItemInfo),
	}
)

// 商城道具

// 购买商城道具请求

WorldMallBuy = descriptor.def_message("WorldMallBuy", 602801, 
	{
		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		// 商城道具ID

		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

// 购买数量

// 购买商城道具返回

WorldMallBuyRet = descriptor.def_message("WorldMallBuyRet", 602802, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		// 返回码

		descriptor.def_scalar_field("mallitemid", descriptor.type_uint32, 0),
		// 商城道具id

		descriptor.def_scalar_field("restLimitNum", descriptor.type_int32, 0),
	}
)

// 剩余限购数,-1是没有限购

// 商城批量购买请求

CWMallBatchBuyReq = descriptor.def_message("CWMallBatchBuyReq", 602812, 
	{
		descriptor.def_message_vector_field("items", ItemReward),
	}
)

// 商城批量购买返回

SCMallBatchBuyRes = descriptor.def_message("SCMallBatchBuyRes", 602813, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
		descriptor.def_scalar_vector_field("itemUids", descriptor.type_uint64, 0),
	}
)

// 请求商城礼包详情

WorldMallQueryItemDetailReq = descriptor.def_message("WorldMallQueryItemDetailReq", 602805, 
	{
		descriptor.def_scalar_field("mallItemId", descriptor.type_uint32, 0),
	}
)

// 商城道具id

MallGiftDetail = descriptor.def_struct("MallGiftDetail", 
	{
		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

// 请求商城礼包详情返回

WorldMallQueryItemDetailRet = descriptor.def_message("WorldMallQueryItemDetailRet", 602806, 
	{
		descriptor.def_message_vector_field("details", MallGiftDetail),
	}
)

// 快速购买请求

SceneQuickBuyReq = descriptor.def_message("SceneQuickBuyReq", 507101, 
	{
		//  类型(对应枚举QuickBuyTargetType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  参数

		descriptor.def_scalar_field("param1", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("param2", descriptor.type_uint64, 0),
	}
)

// 快速购买返回

SceneQuickBuyRes = descriptor.def_message("SceneQuickBuyRes", 507102, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

// 开罐子

SceneUseMagicJarReq = descriptor.def_message("SceneUseMagicJarReq", 500948, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint32, 0),
		// 开罐类型

		descriptor.def_scalar_field("combo", descriptor.type_uint8, 0),
	}
)

// 是否连开

SceneNotifyCostItem = descriptor.def_message("SceneNotifyCostItem", 500949, 
	{
		descriptor.def_scalar_field("itemid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("quality", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

// 请求快捷使用关卡道具

SceneQuickUseItemReq = descriptor.def_message("SceneQuickUseItemReq", 500950, 
	{
		descriptor.def_scalar_field("idx", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("dungenid", descriptor.type_uint32, 0),
	}
)

// 请求快捷使用关卡道具返回

SceneQuickUseItemRet = descriptor.def_message("SceneQuickUseItemRet", 500951, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneFashionMergeReq = descriptor.def_message("SceneFashionMergeReq", 500952, 
	{
		descriptor.def_scalar_field("leftid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("rightid", descriptor.type_uint64, 0),
	}
)

SceneFashionMergeRes = descriptor.def_message("SceneFashionMergeRes", 500953, 
	{
		descriptor.def_scalar_field("result", descriptor.type_int32, 0),
		descriptor.def_scalar_field("resultType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("itemA", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("numA", descriptor.type_int32, 0),
		descriptor.def_scalar_field("itemB", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("numB", descriptor.type_int32, 0),
	}
)

SceneEquipMakeReq = descriptor.def_message("SceneEquipMakeReq", 500954, 
	{
		descriptor.def_scalar_field("equipId", descriptor.type_uint32, 0),
	}
)

SceneEquipMakeRet = descriptor.def_message("SceneEquipMakeRet", 500955, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

SceneFashionAttributeSelectReq = descriptor.def_message("SceneFashionAttributeSelectReq", 500958, 
	{
		descriptor.def_scalar_field("guid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("attributeId", descriptor.type_int32, 0),
	}
)

SceneFashionAttributeSelectRes = descriptor.def_message("SceneFashionAttributeSelectRes", 500959, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

// 开罐记录数据

OpenJarRecord = descriptor.def_struct("OpenJarRecord", 
	{
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
	}
)

// 请求开罐记录

SceneOpenJarRecordReq = descriptor.def_message("SceneOpenJarRecordReq", 600901, 
	{
		descriptor.def_scalar_field("jarId", descriptor.type_uint32, 0),
	}
)

// 返回开罐记录

SceneOpenJarRecordRes = descriptor.def_message("SceneOpenJarRecordRes", 600902, 
	{
		descriptor.def_scalar_field("jarId", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("records", OpenJarRecord),
	}
)

// 设置关卡药水配置

SceneSetDungeonPotionReq = descriptor.def_message("SceneSetDungeonPotionReq", 500964, 
	{
		descriptor.def_scalar_field("potionId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
	}
)

SceneSetDungeonPotionRes = descriptor.def_message("SceneSetDungeonPotionRes", 500965, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

// 续费时限道具

SceneRenewTimeItemReq = descriptor.def_message("SceneRenewTimeItemReq", 500966, 
	{
		descriptor.def_scalar_field("itemUid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("duration", descriptor.type_uint32, 0),
	}
)

SceneRenewTimeItemRes = descriptor.def_message("SceneRenewTimeItemRes", 500967, 
	{
		descriptor.def_scalar_field("code", descriptor.type_uint32, 0),
	}
)

