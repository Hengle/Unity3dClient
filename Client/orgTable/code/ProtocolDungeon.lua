local descriptor = require "descriptor"
local ProtocolBase = require "ProtocolBase"
local ProtocolMatch = require "ProtocolMatch"
local ProtocolItem = require "ProtocolItem"

module "ProtocolDungeon"

DungeonScore = descriptor.def_enum("DungeonScore",
	{
		descriptor.def_enum_value("C", 0),
		descriptor.def_enum_value("B", 1),
		descriptor.def_enum_value("A", 2),
		descriptor.def_enum_value("S", 3),
		descriptor.def_enum_value("SS", 4),
		descriptor.def_enum_value("SSS", 5),
	}
)

//  深渊模式

DungeonHellMode = descriptor.def_enum("DungeonHellMode",
	{
		//  无

		descriptor.def_enum_value("Null", 0),
		//  普通

		descriptor.def_enum_value("Normal", 1),
		//  困难

		descriptor.def_enum_value("Hard", 2),
	}
)

//  各种经验加成类型

DungeonAdditionType = descriptor.def_enum("DungeonAdditionType",
	{
		//  经验药水

		descriptor.def_enum_value("EXP_BUFF", 0),
		//  VIP经验加成

		descriptor.def_enum_value("EXP_VIP", 1),
		//  评价经验加成

		descriptor.def_enum_value("EXP_SCORE", 2),
		//  难度经验加成

		descriptor.def_enum_value("EXP_HARD", 3),
		//  公会技能经验加成

		descriptor.def_enum_value("EXP_GUILD_SKILL", 4),
		//  VIP金币加成

		descriptor.def_enum_value("GOLD_VIP", 5),
	}
)

DungeonChestType = descriptor.def_enum("DungeonChestType",
	{
		//  普通宝箱

		descriptor.def_enum_value("Normal", 0),
		//  Vip宝箱

		descriptor.def_enum_value("Vip", 1),
		//  付费宝箱

		descriptor.def_enum_value("Pay", 2),
	}
)

SceneDungeonInfo = descriptor.def_struct("SceneDungeonInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("bestScore", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("bestRecordTime", descriptor.type_uint32, 0),
	}
)

DungeonAdditionInfo = descriptor.def_struct("DungeonAdditionInfo", 
	{
		descriptor.def_scalar_vector_field("addition", descriptor.type_uint32, 0),
	}
)

SceneDungeonInit = descriptor.def_message("SceneDungeonInit", 506801, 
	{
		descriptor.def_message_vector_field("allInfo", SceneDungeonInfo),
	}
)

SceneDungeonUpdate = descriptor.def_message("SceneDungeonUpdate", 506802, 
	{
		descriptor.def_message_field("info", SceneDungeonInfo),
	}
)

SceneDungeonHardInfo = descriptor.def_struct("SceneDungeonHardInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("unlockedHardType", descriptor.type_uint8, 0),
	}
)

SceneDungeonHardInit = descriptor.def_message("SceneDungeonHardInit", 506803, 
	{
		descriptor.def_message_vector_field("allInfo", SceneDungeonHardInfo),
	}
)

SceneDungeonHardUpdate = descriptor.def_message("SceneDungeonHardUpdate", 506804, 
	{
		descriptor.def_message_field("info", SceneDungeonHardInfo),
	}
)

SceneDungeonStartReq = descriptor.def_message("SceneDungeonStartReq", 506805, 
	{
		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
		//  要使用的药水

		descriptor.def_scalar_vector_field("buffDrugs", descriptor.type_uint32, 0),
	}
)

SceneDungeonDropItem = descriptor.def_struct("SceneDungeonDropItem", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("typeId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
	}
)

SceneDungeonMonster = descriptor.def_struct("SceneDungeonMonster", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("pointId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("typeId", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("dropItems", SceneDungeonDropItem),
		descriptor.def_scalar_vector_field("prefixes", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("summonerId", descriptor.type_uint32, 0),
	}
)

SceneDungeonArea = descriptor.def_struct("SceneDungeonArea", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("monsters", SceneDungeonMonster),
		descriptor.def_message_vector_field("destructs", SceneDungeonMonster),
	}
)

//  深渊波次信息

DungeonHellWaveInfo = descriptor.def_struct("DungeonHellWaveInfo", 
	{
		descriptor.def_scalar_field("wave", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("monsters", SceneDungeonMonster),
	}
)

//  深渊信息

DungeonHellInfo = descriptor.def_struct("DungeonHellInfo", 
	{
		//  模式，对应枚举（DungeonHellMode）

		descriptor.def_scalar_field("mode", descriptor.type_uint8, 0),
		//  所在区域

		descriptor.def_scalar_field("areaId", descriptor.type_uint32, 0),
		//  波次信息

		descriptor.def_message_vector_field("waveInfoes", DungeonHellWaveInfo),
		//  掉落

		descriptor.def_message_vector_field("dropItems", SceneDungeonDropItem),
	}
)

SceneDungeonStartRes = descriptor.def_message("SceneDungeonStartRes", 506806, 
	{
		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("startAreaId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("areas", SceneDungeonArea),
		//  深渊信息

		descriptor.def_message_field("hellInfo", DungeonHellInfo),
		//  是否接着上一次保存的状态

		descriptor.def_scalar_field("isCointnue", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("hp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("mp", descriptor.type_uint32, 0),
		// 登录RelayServer的session

		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
		//  RelayServer地址

		descriptor.def_message_field("addr", ProtocolBase.SockAddr),
		//  所有玩家信息

		descriptor.def_message_vector_field("players", ProtocolMatch.RacePlayerInfo),
		//  是否开放自动战斗

		descriptor.def_scalar_field("openAutoBattle", descriptor.type_uint8, 0),
		//  boss掉落

		descriptor.def_message_vector_field("bossDropItems", SceneDungeonDropItem),
	}
)

SceneDungeonAddMonsterDropItemNotify = descriptor.def_message("SceneDungeonAddMonsterDropItemNotify", 506815, 
	{
		descriptor.def_scalar_field("monsterId", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("dropItems", SceneDungeonDropItem),
	}
)

SceneDungeonEnterNextAreaReq = descriptor.def_message("SceneDungeonEnterNextAreaReq", 506807, 
	{
		descriptor.def_scalar_field("areaId", descriptor.type_uint32, 0),
	}
)

SceneDungeonEnterNextAreaRes = descriptor.def_message("SceneDungeonEnterNextAreaRes", 506808, 
	{
		descriptor.def_scalar_field("areaId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneDungeonRewardReq = descriptor.def_message("SceneDungeonRewardReq", 506809, 
	{
		descriptor.def_scalar_vector_field("dropItemIds", descriptor.type_uint32, 0),
	}
)

SceneDungeonRewardRes = descriptor.def_message("SceneDungeonRewardRes", 506810, 
	{
		descriptor.def_scalar_vector_field("pickedItems", descriptor.type_uint32, 0),
	}
)

SceneDungeonRaceEndReq = descriptor.def_message("SceneDungeonRaceEndReq", 506811, 
	{
		descriptor.def_scalar_field("score", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("beHitCount", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("usedTime", descriptor.type_uint32, 0),
	}
)

SceneDungeonRaceEndRes = descriptor.def_message("SceneDungeonRaceEndRes", 506812, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("score", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("usedTime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("killMonsterTotalExp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("raceEndExp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("hasRaceEndDrop", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("raceEndDropBaseMulti", descriptor.type_uint8, 0),
		descriptor.def_message_field("addition", DungeonAdditionInfo),
		descriptor.def_message_field("teamReward", ProtocolItem.ItemReward),
		//  有没有结算翻牌

		descriptor.def_scalar_field("hasRaceEndChest", descriptor.type_uint8, 0),
		//  月卡结算金币奖励

		descriptor.def_scalar_field("monthcartGoldReward", descriptor.type_uint32, 0),
	}
)

SceneDungeonChestNotify = descriptor.def_message("SceneDungeonChestNotify", 506816, 
	{
		//  宝箱付费货币类型

		descriptor.def_scalar_field("payChestCostItemId", descriptor.type_uint32, 0),
		//  宝箱付费货币数量

		descriptor.def_scalar_field("payChestCost", descriptor.type_uint32, 0),
	}
)

SceneDungeonOpenChestReq = descriptor.def_message("SceneDungeonOpenChestReq", 506813, 
	{
		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
	}
)

DungeonChest = descriptor.def_struct("DungeonChest", 
	{
		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("goldReward", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("isRareControl", descriptor.type_uint8, 0),
	}
)

SceneDungeonOpenChestRes = descriptor.def_message("SceneDungeonOpenChestRes", 506814, 
	{
		descriptor.def_scalar_field("owner", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		descriptor.def_message_field("chest", DungeonChest),
	}
)

//  请求复活

SceneDungeonReviveReq = descriptor.def_message("SceneDungeonReviveReq", 506817, 
	{
		//  要复活的目标

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  每一次复活都有一个ID

		descriptor.def_scalar_field("reviveId", descriptor.type_uint32, 0),
		//  消耗的复活币数量

		descriptor.def_scalar_field("reviveCoinNum", descriptor.type_uint32, 0),
	}
)

SceneDungeonReviveRes = descriptor.def_message("SceneDungeonReviveRes", 506818, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

// 玩家杀死怪物通知

SceneDungeonKillMonsterReq = descriptor.def_message("SceneDungeonKillMonsterReq", 506819, 
	{
		descriptor.def_scalar_vector_field("monsterIds", descriptor.type_uint32, 0),
	}
)

// 玩家杀死怪物返回

SceneDungeonKillMonsterRes = descriptor.def_message("SceneDungeonKillMonsterRes", 506820, 
	{
		descriptor.def_scalar_vector_field("monsterIds", descriptor.type_uint32, 0),
	}
)

// 玩家杀死怪物返回

SceneDungeonClearAreaMonsters = descriptor.def_message("SceneDungeonClearAreaMonsters", 506821, 
	{
		//  使用时间(ms)

		descriptor.def_scalar_field("usedTime", descriptor.type_uint32, 0),
		//  剩余血量

		descriptor.def_scalar_field("remainHp", descriptor.type_uint32, 0),
		//  剩余蓝量

		descriptor.def_scalar_field("remainMp", descriptor.type_uint32, 0),
	}
)

//  地下城开放信息

DungeonOpenInfo = descriptor.def_struct("DungeonOpenInfo", 
	{
		//  地下城ID

		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		//  是否开放深渊模式(1:开放，0:不开放)

		descriptor.def_scalar_field("hellMode", descriptor.type_uint8, 0),
	}
)

// 同步新开放的地下城列表

SceneDungeonSyncNewOpenedList = descriptor.def_message("SceneDungeonSyncNewOpenedList", 506822, 
	{
		// 新开放的地下城列表

		descriptor.def_message_vector_field("newOpenedList", DungeonOpenInfo),
		// 新关闭掉的地下城列表

		descriptor.def_scalar_vector_field("newClosedList", descriptor.type_uint32, 0),
	}
)

//  请求结算掉落

SceneDungeonEndDropReq = descriptor.def_message("SceneDungeonEndDropReq", 506823, 
	{
		//  倍率

		descriptor.def_scalar_field("multi", descriptor.type_uint8, 0),
	}
)

//  返回结算掉落

SceneDungeonEndDropRes = descriptor.def_message("SceneDungeonEndDropRes", 506824, 
	{
		//  总倍率（0代表获取失败）

		descriptor.def_scalar_field("multi", descriptor.type_uint8, 0),
		//  掉落物品

		descriptor.def_message_vector_field("items", SceneDungeonDropItem),
	}
)

//  请求扫荡死亡之塔

SceneTowerWipeoutReq = descriptor.def_message("SceneTowerWipeoutReq", 507201, 
	{
	}
)

//  扫荡死亡之塔返回

SceneTowerWipeoutRes = descriptor.def_message("SceneTowerWipeoutRes", 507202, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求死亡之塔扫荡奖励

SceneTowerWipeoutResultReq = descriptor.def_message("SceneTowerWipeoutResultReq", 507203, 
	{
	}
)

//  死亡之塔扫荡奖励返回

SceneTowerWipeoutResultRes = descriptor.def_message("SceneTowerWipeoutResultRes", 507204, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", SceneDungeonDropItem),
	}
)

//  请求快速完成死亡之塔扫荡

SceneTowerWipeoutQuickFinishReq = descriptor.def_message("SceneTowerWipeoutQuickFinishReq", 507205, 
	{
	}
)

//  快速完成死亡之塔返回

SceneTowerWipeoutQuickFinishRes = descriptor.def_message("SceneTowerWipeoutQuickFinishRes", 507206, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求重置死亡之塔

SceneTowerResetReq = descriptor.def_message("SceneTowerResetReq", 507207, 
	{
	}
)

//  重置死亡之塔返回

SceneTowerResetRes = descriptor.def_message("SceneTowerResetRes", 507208, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求死亡之塔首通奖励

SceneTowerFloorAwardReq = descriptor.def_message("SceneTowerFloorAwardReq", 507209, 
	{
		descriptor.def_scalar_field("floor", descriptor.type_uint32, 0),
	}
)

//  领取死亡之塔首通奖励返回

SceneTowerFloorAwardRes = descriptor.def_message("SceneTowerFloorAwardRes", 507210, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", SceneDungeonDropItem),
	}
)

//  请求购买地下城次数

SceneDungeonBuyTimesReq = descriptor.def_message("SceneDungeonBuyTimesReq", 506831, 
	{
		descriptor.def_scalar_field("subType", descriptor.type_uint8, 0),
	}
)

//  购买地下城次数返回

SceneDungeonBuyTimesRes = descriptor.def_message("SceneDungeonBuyTimesRes", 506832, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  通知服务器进入比赛了

WorldDungeonEnterRaceReq = descriptor.def_message("WorldDungeonEnterRaceReq", 606809, 
	{
	}
)

//  服务器返回玩家进入比赛

WorldDungeonEnterRaceRes = descriptor.def_message("WorldDungeonEnterRaceRes", 606810, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

