local descriptor = require "descriptor"
local ProtocolBase = require "ProtocolBase"
local ProtocolRetinue = require "ProtocolRetinue"
local ProtocolItem = require "ProtocolItem"

module "ProtocolMatch"

//  ս������

RaceType = descriptor.def_enum("RaceType",
	{
		//  �ؿ�

		descriptor.def_enum_value("Dungeon", 0),
		//  PK

		descriptor.def_enum_value("PK", 1),
		//  ����ս

		descriptor.def_enum_value("GuildBattle", 2),
	}
)

//  ����״̬

FriendMatchStatus = descriptor.def_enum("FriendMatchStatus",
	{
		//  ����

		descriptor.def_enum_value("Idle", 0),
		//  æµ

		descriptor.def_enum_value("Busy", 1),
		//  ����

		descriptor.def_enum_value("Offlie", 2),
	}
)

//  ����״̬

SeasonPlayStatus = descriptor.def_enum("SeasonPlayStatus",
	{
		descriptor.def_enum_value("SPS_INVALID", 0),
		descriptor.def_enum_value("SPS_NEW", 1),
		descriptor.def_enum_value("SPS_NEW_ATTR", 2),
	}
)

WorldMatchStartReq = descriptor.def_message("WorldMatchStartReq", 506701, 
	{
		//  ƥ�����ͣ���ӦMatchType

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

WorldMatchStartRes = descriptor.def_message("WorldMatchStartRes", 606702, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

WorldMatchCancelReq = descriptor.def_message("WorldMatchCancelReq", 506702, 
	{
	}
)

WorldMatchCancelRes = descriptor.def_message("WorldMatchCancelRes", 606703, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

RaceSkillInfo = descriptor.def_struct("RaceSkillInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("slot", descriptor.type_uint8, 0),
	}
)

RaceItemRandProperty = descriptor.def_struct("RaceItemRandProperty", 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("value", descriptor.type_uint32, 0),
	}
)

RaceEquip = descriptor.def_struct("RaceEquip", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("phyAtk", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("magAtk", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("phydef", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("magdef", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("strenth", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("stamina", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("intellect", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("spirit", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("properties", RaceItemRandProperty),
		descriptor.def_scalar_field("magicCard", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("disphyAtk", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("disMagAtk", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("disphydef", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("dismagdef", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("strengthen", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("fashionAttrId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("phyDefPercent", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("magDefPercent", descriptor.type_uint32, 0),
	}
)

RaceItem = descriptor.def_struct("RaceItem", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

RaceBuffInfo = descriptor.def_struct("RaceBuffInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("overlayNums", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("startTime", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("duration", descriptor.type_uint32, 0),
	}
)

RaceWarpStone = descriptor.def_struct("RaceWarpStone", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
	}
)

RaceRetinue = descriptor.def_struct("RaceRetinue", 
	{
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("star", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("isMain", descriptor.type_uint8, 0),
		descriptor.def_scalar_vector_field("buffIds", descriptor.type_uint32, 0),
	}
)

RacePet = descriptor.def_struct("RacePet", 
	{
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("hunger", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("skillIndex", descriptor.type_uint8, 0),
	}
)

RacePlayerInfo = descriptor.def_struct("RacePlayerInfo", 
	{
		//  ai�Ѷȣ�0������Чֵ��˵�����ǻ�����

		descriptor.def_scalar_field("robotAIType", descriptor.type_uint8, 0),
		//  �������Ѷȣ�0������Ѫ��

		descriptor.def_scalar_field("robotHard", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("guildName", descriptor.type_string, ""),
		descriptor.def_scalar_field("occupation", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("pkValue", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("matchScore", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("remainHp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("remainMp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonLevel", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonStar", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonAttr", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("monthcard", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("skills", RaceSkillInfo),
		descriptor.def_message_vector_field("equips", RaceEquip),
		descriptor.def_message_vector_field("raceItems", RaceItem),
		descriptor.def_message_vector_field("buffs", RaceBuffInfo),
		descriptor.def_message_vector_field("warpStones", RaceWarpStone),
		descriptor.def_message_vector_field("retinues", RaceRetinue),
		descriptor.def_message_vector_field("pets", RacePet),
		descriptor.def_scalar_vector_field("potionPos", descriptor.type_uint32, 0),
	}
)

WorldNotifyRaceStart = descriptor.def_message("WorldNotifyRaceStart", 606701, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("sessionId", descriptor.type_uint64, 0),
		descriptor.def_message_field("addr", ProtocolBase.SockAddr),
		//  ��Ӧö�٣�RaceType��

		descriptor.def_scalar_field("raceType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("players", RacePlayerInfo),
	}
)

PkOccuRecord = descriptor.def_struct("PkOccuRecord", 
	{
		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("winNum", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("loseNum", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("totalNum", descriptor.type_uint32, 0),
	}
)

SceneSyncPkStatisticInfo = descriptor.def_message("SceneSyncPkStatisticInfo", 506703, 
	{
	}
)

SceneSyncPkStatisticProperty = descriptor.def_message("SceneSyncPkStatisticProperty", 506704, 
	{
	}
)

//  ����

SceneMatchPkRaceEnd = descriptor.def_message("SceneMatchPkRaceEnd", 506705, 
	{
		//  PK���ͣ���Ӧö��(PkType)

		descriptor.def_scalar_field("pkType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("oldPkValue", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("newPkValue", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("oldMatchScore", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("newMatchScore", descriptor.type_uint32, 0),
		//  ��ʼ����������

		descriptor.def_scalar_field("oldPkCoin", descriptor.type_uint32, 0),
		//  ս����õľ�����

		descriptor.def_scalar_field("addPkCoinFromRace", descriptor.type_uint32, 0),
		//  ����ս����õ�ȫ��������

		descriptor.def_scalar_field("totalPkCoinFromRace", descriptor.type_uint32, 0),
		//  �Ƿ���PVP��ڼ�

		descriptor.def_scalar_field("isInPvPActivity", descriptor.type_uint8, 0),
		//  ������õľ�����

		descriptor.def_scalar_field("addPkCoinFromActivity", descriptor.type_uint32, 0),
		//  ���ջ��õ�ȫ��������

		descriptor.def_scalar_field("totalPkCoinFromActivity", descriptor.type_uint32, 0),
		//  ԭ��λ

		descriptor.def_scalar_field("oldSeasonLevel", descriptor.type_uint32, 0),
		//  �ֶ�λ

		descriptor.def_scalar_field("newSeasonLevel", descriptor.type_uint32, 0),
		//  ԭ��

		descriptor.def_scalar_field("oldSeasonStar", descriptor.type_uint32, 0),
		//  ����

		descriptor.def_scalar_field("newSeasonStar", descriptor.type_uint32, 0),
		//  ԭ����

		descriptor.def_scalar_field("oldSeasonExp", descriptor.type_uint32, 0),
		//  �־���

		descriptor.def_scalar_field("newSeasonExp", descriptor.type_uint32, 0),
		//  �ı�ľ���

		descriptor.def_scalar_field("changeSeasonExp", descriptor.type_int32, 0),
	}
)

//  ����μ�������

SceneWudaoJoinReq = descriptor.def_message("SceneWudaoJoinReq", 506706, 
	{
	}
)

//  �μ������᷵��

SceneWudaoJoinRes = descriptor.def_message("SceneWudaoJoinRes", 506707, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ������ȡ�����ά��

SceneWudaoRewardReq = descriptor.def_message("SceneWudaoRewardReq", 506708, 
	{
	}
)

//  ��ȡ�����ά������

SceneWudaoRewardRes = descriptor.def_message("SceneWudaoRewardRes", 506709, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("getItems", ProtocolItem.ItemReward),
	}
)

//  ����״̬��Ϣ

FriendMatchStatusInfo = descriptor.def_struct("FriendMatchStatusInfo", 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		//  ״̬����Ӧö�٣�FriendMatchStatus��

		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
	}
)

//  �����ѯ����״̬

WorldMatchQueryFriendStatusReq = descriptor.def_message("WorldMatchQueryFriendStatusReq", 606706, 
	{
	}
)

//  ��ѯ����״̬����

WorldMatchQueryFriendStatusRes = descriptor.def_message("WorldMatchQueryFriendStatusRes", 606707, 
	{
		descriptor.def_message_vector_field("infoes", FriendMatchStatusInfo),
	}
)

// ֪ͨ��λ��Ϣ

SceneSyncSeasonLevel = descriptor.def_message("SceneSyncSeasonLevel", 506711, 
	{
		descriptor.def_scalar_field("oldSeasonLevel", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("oldSeasonStar", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonLevel", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonStar", descriptor.type_uint32, 0),
	}
)

// �ͻ���֪ͨ��������״̬

SceneSeasonPlayStatus = descriptor.def_message("SceneSeasonPlayStatus", 506712, 
	{
		descriptor.def_scalar_field("seasonId", descriptor.type_uint32, 0),
	}
)

// ֪ͨ�ͻ���������Ϣ

SceneSyncSeasonInfo = descriptor.def_message("SceneSyncSeasonInfo", 506713, 
	{
		descriptor.def_scalar_field("seasonId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("endTime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonAttrEndTime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonAttrLevel", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonAttr", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("seasonLevel", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonStar", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonExp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("seasonStatus", descriptor.type_uint8, 0),
	}
)

