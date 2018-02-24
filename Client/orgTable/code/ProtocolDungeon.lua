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

//  ��Ԩģʽ

DungeonHellMode = descriptor.def_enum("DungeonHellMode",
	{
		//  ��

		descriptor.def_enum_value("Null", 0),
		//  ��ͨ

		descriptor.def_enum_value("Normal", 1),
		//  ����

		descriptor.def_enum_value("Hard", 2),
	}
)

//  ���־���ӳ�����

DungeonAdditionType = descriptor.def_enum("DungeonAdditionType",
	{
		//  ����ҩˮ

		descriptor.def_enum_value("EXP_BUFF", 0),
		//  VIP����ӳ�

		descriptor.def_enum_value("EXP_VIP", 1),
		//  ���۾���ӳ�

		descriptor.def_enum_value("EXP_SCORE", 2),
		//  �ѶȾ���ӳ�

		descriptor.def_enum_value("EXP_HARD", 3),
		//  ���Ἴ�ܾ���ӳ�

		descriptor.def_enum_value("EXP_GUILD_SKILL", 4),
		//  VIP��Ҽӳ�

		descriptor.def_enum_value("GOLD_VIP", 5),
	}
)

DungeonChestType = descriptor.def_enum("DungeonChestType",
	{
		//  ��ͨ����

		descriptor.def_enum_value("Normal", 0),
		//  Vip����

		descriptor.def_enum_value("Vip", 1),
		//  ���ѱ���

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
		//  Ҫʹ�õ�ҩˮ

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

//  ��Ԩ������Ϣ

DungeonHellWaveInfo = descriptor.def_struct("DungeonHellWaveInfo", 
	{
		descriptor.def_scalar_field("wave", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("monsters", SceneDungeonMonster),
	}
)

//  ��Ԩ��Ϣ

DungeonHellInfo = descriptor.def_struct("DungeonHellInfo", 
	{
		//  ģʽ����Ӧö�٣�DungeonHellMode��

		descriptor.def_scalar_field("mode", descriptor.type_uint8, 0),
		//  ��������

		descriptor.def_scalar_field("areaId", descriptor.type_uint32, 0),
		//  ������Ϣ

		descriptor.def_message_vector_field("waveInfoes", DungeonHellWaveInfo),
		//  ����

		descriptor.def_message_vector_field("dropItems", SceneDungeonDropItem),
	}
)

SceneDungeonStartRes = descriptor.def_message("SceneDungeonStartRes", 506806, 
	{
		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("startAreaId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("areas", SceneDungeonArea),
		//  ��Ԩ��Ϣ

		descriptor.def_message_field("hellInfo", DungeonHellInfo),
		//  �Ƿ������һ�α����״̬

		descriptor.def_scalar_field("isCointnue", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("hp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("mp", descriptor.type_uint32, 0),
		// ��¼RelayServer��session

		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
		//  RelayServer��ַ

		descriptor.def_message_field("addr", ProtocolBase.SockAddr),
		//  ���������Ϣ

		descriptor.def_message_vector_field("players", ProtocolMatch.RacePlayerInfo),
		//  �Ƿ񿪷��Զ�ս��

		descriptor.def_scalar_field("openAutoBattle", descriptor.type_uint8, 0),
		//  boss����

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
		//  ��û�н��㷭��

		descriptor.def_scalar_field("hasRaceEndChest", descriptor.type_uint8, 0),
		//  �¿������ҽ���

		descriptor.def_scalar_field("monthcartGoldReward", descriptor.type_uint32, 0),
	}
)

SceneDungeonChestNotify = descriptor.def_message("SceneDungeonChestNotify", 506816, 
	{
		//  ���丶�ѻ�������

		descriptor.def_scalar_field("payChestCostItemId", descriptor.type_uint32, 0),
		//  ���丶�ѻ�������

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

//  ���󸴻�

SceneDungeonReviveReq = descriptor.def_message("SceneDungeonReviveReq", 506817, 
	{
		//  Ҫ�����Ŀ��

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  ÿһ�θ����һ��ID

		descriptor.def_scalar_field("reviveId", descriptor.type_uint32, 0),
		//  ���ĵĸ��������

		descriptor.def_scalar_field("reviveCoinNum", descriptor.type_uint32, 0),
	}
)

SceneDungeonReviveRes = descriptor.def_message("SceneDungeonReviveRes", 506818, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

// ���ɱ������֪ͨ

SceneDungeonKillMonsterReq = descriptor.def_message("SceneDungeonKillMonsterReq", 506819, 
	{
		descriptor.def_scalar_vector_field("monsterIds", descriptor.type_uint32, 0),
	}
)

// ���ɱ�����ﷵ��

SceneDungeonKillMonsterRes = descriptor.def_message("SceneDungeonKillMonsterRes", 506820, 
	{
		descriptor.def_scalar_vector_field("monsterIds", descriptor.type_uint32, 0),
	}
)

// ���ɱ�����ﷵ��

SceneDungeonClearAreaMonsters = descriptor.def_message("SceneDungeonClearAreaMonsters", 506821, 
	{
		//  ʹ��ʱ��(ms)

		descriptor.def_scalar_field("usedTime", descriptor.type_uint32, 0),
		//  ʣ��Ѫ��

		descriptor.def_scalar_field("remainHp", descriptor.type_uint32, 0),
		//  ʣ������

		descriptor.def_scalar_field("remainMp", descriptor.type_uint32, 0),
	}
)

//  ���³ǿ�����Ϣ

DungeonOpenInfo = descriptor.def_struct("DungeonOpenInfo", 
	{
		//  ���³�ID

		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		//  �Ƿ񿪷���Ԩģʽ(1:���ţ�0:������)

		descriptor.def_scalar_field("hellMode", descriptor.type_uint8, 0),
	}
)

// ͬ���¿��ŵĵ��³��б�

SceneDungeonSyncNewOpenedList = descriptor.def_message("SceneDungeonSyncNewOpenedList", 506822, 
	{
		// �¿��ŵĵ��³��б�

		descriptor.def_message_vector_field("newOpenedList", DungeonOpenInfo),
		// �¹رյ��ĵ��³��б�

		descriptor.def_scalar_vector_field("newClosedList", descriptor.type_uint32, 0),
	}
)

//  ����������

SceneDungeonEndDropReq = descriptor.def_message("SceneDungeonEndDropReq", 506823, 
	{
		//  ����

		descriptor.def_scalar_field("multi", descriptor.type_uint8, 0),
	}
)

//  ���ؽ������

SceneDungeonEndDropRes = descriptor.def_message("SceneDungeonEndDropRes", 506824, 
	{
		//  �ܱ��ʣ�0�����ȡʧ�ܣ�

		descriptor.def_scalar_field("multi", descriptor.type_uint8, 0),
		//  ������Ʒ

		descriptor.def_message_vector_field("items", SceneDungeonDropItem),
	}
)

//  ����ɨ������֮��

SceneTowerWipeoutReq = descriptor.def_message("SceneTowerWipeoutReq", 507201, 
	{
	}
)

//  ɨ������֮������

SceneTowerWipeoutRes = descriptor.def_message("SceneTowerWipeoutRes", 507202, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ��������֮��ɨ������

SceneTowerWipeoutResultReq = descriptor.def_message("SceneTowerWipeoutResultReq", 507203, 
	{
	}
)

//  ����֮��ɨ����������

SceneTowerWipeoutResultRes = descriptor.def_message("SceneTowerWipeoutResultRes", 507204, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", SceneDungeonDropItem),
	}
)

//  ��������������֮��ɨ��

SceneTowerWipeoutQuickFinishReq = descriptor.def_message("SceneTowerWipeoutQuickFinishReq", 507205, 
	{
	}
)

//  �����������֮������

SceneTowerWipeoutQuickFinishRes = descriptor.def_message("SceneTowerWipeoutQuickFinishRes", 507206, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ������������֮��

SceneTowerResetReq = descriptor.def_message("SceneTowerResetReq", 507207, 
	{
	}
)

//  ��������֮������

SceneTowerResetRes = descriptor.def_message("SceneTowerResetRes", 507208, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ��������֮����ͨ����

SceneTowerFloorAwardReq = descriptor.def_message("SceneTowerFloorAwardReq", 507209, 
	{
		descriptor.def_scalar_field("floor", descriptor.type_uint32, 0),
	}
)

//  ��ȡ����֮����ͨ��������

SceneTowerFloorAwardRes = descriptor.def_message("SceneTowerFloorAwardRes", 507210, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", SceneDungeonDropItem),
	}
)

//  ��������³Ǵ���

SceneDungeonBuyTimesReq = descriptor.def_message("SceneDungeonBuyTimesReq", 506831, 
	{
		descriptor.def_scalar_field("subType", descriptor.type_uint8, 0),
	}
)

//  ������³Ǵ�������

SceneDungeonBuyTimesRes = descriptor.def_message("SceneDungeonBuyTimesRes", 506832, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ֪ͨ���������������

WorldDungeonEnterRaceReq = descriptor.def_message("WorldDungeonEnterRaceReq", 606809, 
	{
	}
)

//  ������������ҽ������

WorldDungeonEnterRaceRes = descriptor.def_message("WorldDungeonEnterRaceRes", 606810, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

