local descriptor = require "descriptor"
local Protocol = require "Protocol"
local ProtocolBase = require "ProtocolBase"

module "ProtocolGuild"

//  ����ְ��

GuildPost = descriptor.def_enum("GuildPost",
	{
		//  ��Чֵ

		descriptor.def_enum_value("GUILD_INVALID", 0),
		//  ��ͨ��Ա

		descriptor.def_enum_value("GUILD_POST_NORMAL", 1),
		//  ��Ӣ

		descriptor.def_enum_value("GUILD_POST_ELITE", 2),
		//  ����

		descriptor.def_enum_value("GUILD_POST_ELDER", 11),
		//  ���᳤

		descriptor.def_enum_value("GUILD_POST_ASSISTANT", 12),
		//  �᳤

		descriptor.def_enum_value("GUILD_POST_LEADER", 13),
	}
)

//  ��������

GuildAttr = descriptor.def_enum("GuildAttr",
	{
		//  ��Ч����

		descriptor.def_enum_value("GA_INVALID", 0),
		//  ����	string	

		descriptor.def_enum_value("GA_NAME", 1),
		//  �ȼ�	UInt8	

		descriptor.def_enum_value("GA_LEVEL", 2),
		//  ���� string

		descriptor.def_enum_value("GA_DECLARATION", 3),
		//  �����ʽ� Int32

		descriptor.def_enum_value("GA_FUND", 4),
		//  ���� string

		descriptor.def_enum_value("GA_ANNOUNCEMENT", 5),
		//  ���Ὠ�� GuildBuilding

		descriptor.def_enum_value("GA_BUILDING", 6),
		//  ��ɢʱ�� UInt32

		descriptor.def_enum_value("GA_DISMISS_TIME", 7),
		//  ��Ա���� UInt16

		descriptor.def_enum_value("GA_MEMBER_NUM", 8),
		//  �᳤���� string

		descriptor.def_enum_value("GA_LEADER_NAME", 9),
		//  �������ID UInt8

		descriptor.def_enum_value("GA_ENROLL_TERRID", 10),
		//  ����ս���� UInt32

		descriptor.def_enum_value("GA_BATTLE_SCORE", 11),
		//  ����ռ����� UInt8

		descriptor.def_enum_value("GA_OCCUPY_TERRID", 12),
		//  ����ս������� UInt8

		descriptor.def_enum_value("GA_INSPIRE", 13),
		//  ����սʤ���齱���� UInt8

		descriptor.def_enum_value("GA_WIN_PROBABILITY", 14),
		//  ����սʧ�ܳ齱���� UInt8

		descriptor.def_enum_value("GA_LOSE_PROBABILITY", 15),
		//  ����ս�ֿ������Ʒ UInt8

		descriptor.def_enum_value("GA_STORAGE_ADD_POST", 16),
		//  ����ս�ֿ�ɾ����Ʒ UInt8

		descriptor.def_enum_value("GA_STORAGE_DEL_POST", 17),
	}
)

// ����ս����

GuildBattleType = descriptor.def_enum("GuildBattleType",
	{
		//  ��Ч

		descriptor.def_enum_value("GBT_INVALID", 0),
		//  ��ͨ

		descriptor.def_enum_value("GBT_NORMAL", 1),
		//  ��ս

		descriptor.def_enum_value("GBT_CHALLENGE", 2),
	}
)

//  ����ս״̬

GuildBattleStatus = descriptor.def_enum("GuildBattleStatus",
	{
		//  ��

		descriptor.def_enum_value("GBS_INVALID", 0),
		//  ����

		descriptor.def_enum_value("GBS_ENROLL", 1),
		//  ׼��

		descriptor.def_enum_value("GBS_PREPARE", 2),
		//  ս��

		descriptor.def_enum_value("GBS_BATTLE", 3),
		//  �콱

		descriptor.def_enum_value("GBS_REWARD", 4),
		descriptor.def_enum_value("GBS_MAX", 5),
	}
)

//  ���Ὠ������

GuildBuildingType = descriptor.def_enum("GuildBuildingType",
	{
		//  ����

		descriptor.def_enum_value("MAIN", 0),
		//  �̵�

		descriptor.def_enum_value("SHOP", 1),
		//  Բ������

		descriptor.def_enum_value("TABLE", 2),
		//  ���³�

		descriptor.def_enum_value("DUNGEON", 3),
		//  ����

		descriptor.def_enum_value("STATUE", 4),
		//  ս����

		descriptor.def_enum_value("BATTLE", 5),
		//  ������

		descriptor.def_enum_value("WELFARE", 6),
	}
)

//  �����������

GuildOperation = descriptor.def_enum("GuildOperation",
	{
		//  �޸Ĺ�������

		descriptor.def_enum_value("MODIFY_DECLAR", 0),
		//  �޸Ĺ�����

		descriptor.def_enum_value("MODIFY_NAME", 1),
		//  �޸Ĺ��ṫ��

		descriptor.def_enum_value("MODIFY_ANNOUNCE", 2),
		//  ���͹����ʼ�

		descriptor.def_enum_value("SEND_MAIL", 3),
		//  ��������

		descriptor.def_enum_value("UPGRADE_BUILDING", 4),
		//  ����

		descriptor.def_enum_value("DONATE", 5),
		//  �һ�

		descriptor.def_enum_value("EXCHANGE", 6),
		//  ��������

		descriptor.def_enum_value("UPGRADE_SKILL", 7),
		//  ��ɢ����

		descriptor.def_enum_value("DISMISS", 8),
		//  ȡ����ɢ����

		descriptor.def_enum_value("CANCEL_DISMISS", 9),
		//  Ĥ��

		descriptor.def_enum_value("ORZ", 10),
		//  Բ������

		descriptor.def_enum_value("TABLE", 11),
		//  �ԷѺ��

		descriptor.def_enum_value("PAY_REDPACKET", 12),
	}
)

//  ����

GuildDonateType = descriptor.def_enum("GuildDonateType",
	{
		//  ��Ҿ���

		descriptor.def_enum_value("GOLD", 0),
		//  �ㄻ����

		descriptor.def_enum_value("POINT", 1),
	}
)

//  Ĥ������

GuildOrzType = descriptor.def_enum("GuildOrzType",
	{
		//  ��ͨĤ��

		descriptor.def_enum_value("GUILD_ORZ_LOW", 0),
		//  �м�Ĥ��

		descriptor.def_enum_value("GUILD_ORZ_MID", 1),
		//  �߼�Ĥ��

		descriptor.def_enum_value("GUILD_ORZ_HIGH", 2),
	}
)

//  ����ֿ���������

GuildStorageSetting = descriptor.def_enum("GuildStorageSetting",
	{
		descriptor.def_enum_value("GUILD_POST_INVALID", 0),
		//  ʤ���齱����

		descriptor.def_enum_value("GSS_WIN_PROBABILITY", 1),
		//  ʧ�ܳ齱����

		descriptor.def_enum_value("GSS_LOSE_PROBABILITY", 2),
		//  �ֿ�����Ȩ��

		descriptor.def_enum_value("GSS_STORAGE_ADD_POST", 3),
		//  �ֿ�ɾ��Ȩ��

		descriptor.def_enum_value("GSS_STORAGE_DEL_POST", 4),
		descriptor.def_enum_value("GSS_MAX", 5),
	}
)

//  �����Ա�齱״̬

GuildBattleLotteryStatus = descriptor.def_enum("GuildBattleLotteryStatus",
	{
		//  ��Ч

		descriptor.def_enum_value("GBLS_INVALID", 0),
		//  ���ܳ齱

		descriptor.def_enum_value("GBLS_NOT", 1),
		//  ���Գ齱

		descriptor.def_enum_value("GBLS_CAN", 2),
		//  �Ѿ��齱

		descriptor.def_enum_value("GBLS_FIN", 3),
		descriptor.def_enum_value("GBLS_MAX", 4),
	}
)

GuildStorageOpType = descriptor.def_enum("GuildStorageOpType",
	{
		descriptor.def_enum_value("GSOT_NONE", 0),
		//  ���

		descriptor.def_enum_value("GSOT_GET", 1),
		//  ����

		descriptor.def_enum_value("GSOT_PUT", 2),
		//  ���򲢴���

		descriptor.def_enum_value("GSOT_BUYPUT", 3),
	}
)

//  ������Ϣ

GuildEntry = descriptor.def_struct("GuildEntry", 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  name

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  ����ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		//  ��������

		descriptor.def_scalar_field("memberNum", descriptor.type_uint8, 0),
		//  �᳤����

		descriptor.def_scalar_field("leaderName", descriptor.type_string, ""),
		//  ����

		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
		//  �Ƿ��Ѿ�����

		descriptor.def_scalar_field("isRequested", descriptor.type_uint8, 0),
	}
)

//  �����Ա

GuildMemberEntry = descriptor.def_struct("GuildMemberEntry", 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  name

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  �ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		//  ְҵ

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  ְ��(��Ӧö��GuildPost)

		descriptor.def_scalar_field("post", descriptor.type_uint8, 0),
		//  ��ʷ����

		descriptor.def_scalar_field("contribution", descriptor.type_uint32, 0),
		//  ����ʱ��(0��������)

		descriptor.def_scalar_field("logoutTime", descriptor.type_uint32, 0),
		//  ��Ծ��

		descriptor.def_scalar_field("activeDegree", descriptor.type_uint32, 0),
		// vip�ȼ�

		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
	}
)

//  ������������Ϣ

GuildRequesterInfo = descriptor.def_struct("GuildRequesterInfo", 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// �ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// ְҵ

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		// vip�ȼ�

		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
		// ����ʱ��

		descriptor.def_scalar_field("requestTime", descriptor.type_uint32, 0),
	}
)

//  ���Ὠ��

GuildBuilding = descriptor.def_struct("GuildBuilding", 
	{
		//  �������ͣ���Ӧö��GuildBuildingType��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  �ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
	}
)

//  Բ�������Ա��Ϣ

GuildTableMember = descriptor.def_struct("GuildTableMember", 
	{
		//  ��ɫID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  �ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		//  ְҵ

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  λ��

		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		//  ��������

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  ����ս��Ա

GuildBattleMember = descriptor.def_struct("GuildBattleMember", 
	{
		//  ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  ��ʤ��

		descriptor.def_scalar_field("winStreak", descriptor.type_uint8, 0),
		//  ��û���

		descriptor.def_scalar_field("gotScore", descriptor.type_uint16, 0),
		//  �ܻ���

		descriptor.def_scalar_field("totalScore", descriptor.type_uint16, 0),
	}
)

GuildBattleRecord = descriptor.def_struct("GuildBattleRecord", 
	{
		descriptor.def_scalar_field("index", descriptor.type_uint32, 0),
		//  ʤ����

		descriptor.def_message_field("winner", GuildBattleMember),
		//  ʧ����

		descriptor.def_message_field("loser", GuildBattleMember),
		//  ʱ��

		descriptor.def_scalar_field("time", descriptor.type_uint32, 0),
	}
)

GuildTerritoryBaseInfo = descriptor.def_struct("GuildTerritoryBaseInfo", 
	{
		//  ���ID

		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		//  ռ�칫������

		descriptor.def_scalar_field("guildName", descriptor.type_string, ""),
		//  �Ѿ���������

		descriptor.def_scalar_field("enrollSize", descriptor.type_uint32, 0),
	}
)

GuildBattleInspireInfo = descriptor.def_struct("GuildBattleInspireInfo", 
	{
		//  ���ID

		descriptor.def_scalar_field("playerId", descriptor.type_uint64, 0),
		//  �������

		descriptor.def_scalar_field("playerName", descriptor.type_string, ""),
		//  �������

		descriptor.def_scalar_field("inspireNum", descriptor.type_uint32, 0),
	}
)

//  ����ս�����Ϣ

GuildBattleBaseInfo = descriptor.def_struct("GuildBattleBaseInfo", 
	{
		//  �������ID

		descriptor.def_scalar_field("enrollTerrId", descriptor.type_uint8, 0),
		//  ����ս����

		descriptor.def_scalar_field("guildBattleScore", descriptor.type_uint32, 0),
		//  �Ѿ�ռ������ID

		descriptor.def_scalar_field("occupyTerrId", descriptor.type_uint8, 0),
		//  �������

		descriptor.def_scalar_field("inspire", descriptor.type_uint8, 0),
		//  �Լ��Ĺ���ս��¼

		descriptor.def_message_vector_field("selfGuildBattleRecord", GuildBattleRecord),
		//  �����Ϣ

		descriptor.def_message_vector_field("terrInfos", GuildTerritoryBaseInfo),
		// ����ս����

		descriptor.def_scalar_field("guildBattleType", descriptor.type_uint8, 0),
		// ����ս״̬

		descriptor.def_scalar_field("guildBattleStatus", descriptor.type_uint8, 0),
		// ����ս״̬����ʱ��

		descriptor.def_scalar_field("guildBattleStatusEndTime", descriptor.type_uint32, 0),
	}
)

//  ���������Ϣ

GuildBaseInfo = descriptor.def_struct("GuildBaseInfo", 
	{
		//  ����ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ������

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  ����ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		//  �����ʽ�

		descriptor.def_scalar_field("fund", descriptor.type_uint32, 0),
		//  ��������

		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
		//  ���ṫ��

		descriptor.def_scalar_field("announcement", descriptor.type_string, ""),
		//  ��ɢʱ��

		descriptor.def_scalar_field("dismissTime", descriptor.type_uint32, 0),
		//  ��Ա����

		descriptor.def_scalar_field("memberNum", descriptor.type_uint16, 0),
		//  �᳤����

		descriptor.def_scalar_field("leaderName", descriptor.type_string, ""),
		//  ����սʤ���齱����

		descriptor.def_scalar_field("winProbability", descriptor.type_uint8, 0),
		//  ����սʧ�ܳ齱����

		descriptor.def_scalar_field("loseProbability", descriptor.type_uint8, 0),
		//  ����ֿ����Ȩ��

		descriptor.def_scalar_field("storageAddPost", descriptor.type_uint8, 0),
		//  ����ֿ����Ȩ��

		descriptor.def_scalar_field("storageDelPost", descriptor.type_uint8, 0),
		//  ������Ϣ

		descriptor.def_message_vector_field("building", GuildBuilding),
		//  ��û��������빫�����

		descriptor.def_scalar_field("hasRequester", descriptor.type_uint8, 0),
		//  Բ�������Ա��Ϣ

		descriptor.def_message_vector_field("tableMembers", GuildTableMember),
		//  ����ս�����Ϣ

		descriptor.def_message_field("guildBattleInfo", GuildBattleBaseInfo),
	}
)

//  ������־

GuildDonateLog = descriptor.def_struct("GuildDonateLog", 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  �������ͣ���Ӧö��GuildDonateType��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ����

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
		//  ��ù���

		descriptor.def_scalar_field("contri", descriptor.type_uint32, 0),
	}
)

//  ����᳤��Ϣ

GuildLeaderInfo = descriptor.def_struct("GuildLeaderInfo", 
	{
		//  ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  ְҵ

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  ���

		descriptor.def_message_field("avatar", ProtocolBase.PlayerAvatar),
		//  ����

		descriptor.def_scalar_field("popularoty", descriptor.type_uint32, 0),
	}
)

GuildBattleEndInfo = descriptor.def_struct("GuildBattleEndInfo", 
	{
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("terrName", descriptor.type_string, ""),
		descriptor.def_scalar_field("guildName", descriptor.type_string, ""),
		descriptor.def_scalar_field("guildLeaderName", descriptor.type_string, ""),
	}
)

GuildStorageItemInfo = descriptor.def_struct("GuildStorageItemInfo", 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("str", descriptor.type_uint8, 0),
	}
)

GuildStorageDelItemInfo = descriptor.def_struct("GuildStorageDelItemInfo", 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

//  �ֿ��¼����

GuildStorageOpRecord = descriptor.def_struct("GuildStorageOpRecord", 
	{
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("opType", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
		descriptor.def_scalar_field("time", descriptor.type_uint32, 0),
	}
)

//  ��������

WorldGuildCreateReq = descriptor.def_message("WorldGuildCreateReq", 601901, 
	{
		// ������

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// ����

		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
	}
)

//  �������᷵��

WorldGuildCreateRes = descriptor.def_message("WorldGuildCreateRes", 601902, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  �뿪����

WorldGuildLeaveReq = descriptor.def_message("WorldGuildLeaveReq", 601903, 
	{
	}
)

//  �뿪���᷵��

WorldGuildLeaveRes = descriptor.def_message("WorldGuildLeaveRes", 601904, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ���빫��

WorldGuildJoinReq = descriptor.def_message("WorldGuildJoinReq", 601905, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  ���빫�᷵��

WorldJoinGuildRes = descriptor.def_message("WorldJoinGuildRes", 601906, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ���󹫻��б�

WorldGuildListReq = descriptor.def_message("WorldGuildListReq", 601907, 
	{
		//  ��ʼλ�� 0��ʼ

		descriptor.def_scalar_field("start", descriptor.type_uint16, 0),
		//  ����

		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

//  ���ع����б�

WorldGuildListRes = descriptor.def_message("WorldGuildListRes", 601908, 
	{
		// ��ʼλ��

		descriptor.def_scalar_field("start", descriptor.type_uint16, 0),
		// ����

		descriptor.def_scalar_field("totalnum", descriptor.type_uint16, 0),
		// �����б�

		descriptor.def_message_vector_field("guilds", GuildEntry),
	}
)

//  ���������빫����б�

WorldGuildRequesterReq = descriptor.def_message("WorldGuildRequesterReq", 601909, 
	{
	}
)

//  ���������빫����б�

WorldGuildRequesterRes = descriptor.def_message("WorldGuildRequesterRes", 601910, 
	{
		//  �������б�

		descriptor.def_message_vector_field("requesters", GuildRequesterInfo),
	}
)

//  ֪ͨ�µ��벿������

WorldGuildNewRequester = descriptor.def_message("WorldGuildNewRequester", 601911, 
	{
	}
)

//  �������Ա����

WorldGuildProcessRequester = descriptor.def_message("WorldGuildProcessRequester", 601912, 
	{
		// id(�����0��������б�)

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// ͬ�����(0:��ͬ�⣬1:ͬ��)

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  ������������󷵻�

WorldGuildProcessRequesterRes = descriptor.def_message("WorldGuildProcessRequesterRes", 601913, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  �³�Ա��Ϣ

		descriptor.def_message_field("entry", GuildMemberEntry),
	}
)

//  ����ְλ

WorldGuildChangePostReq = descriptor.def_message("WorldGuildChangePostReq", 601914, 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// ְλ

		descriptor.def_scalar_field("post", descriptor.type_uint8, 0),
		// ���滻����

		descriptor.def_scalar_field("replacerId", descriptor.type_uint64, 0),
	}
)

//  ����ְλ����

WorldGuildChangePostRes = descriptor.def_message("WorldGuildChangePostRes", 601915, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ����

WorldGuildKick = descriptor.def_message("WorldGuildKick", 601916, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  ���˷���

WorldGuildKickRes = descriptor.def_message("WorldGuildKickRes", 601917, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ���߻��¼��빫�ᷢ�ͳ�ʼ����

WorldGuildSyncInfo = descriptor.def_message("WorldGuildSyncInfo", 601918, 
	{
		//  ���������Ϣ

		descriptor.def_message_field("info", GuildBaseInfo),
	}
)

//  ���󹫻��Ա�б�

WorldGuildMemberListReq = descriptor.def_message("WorldGuildMemberListReq", 601919, 
	{
	}
)

//  ���ع����Ա�б�

WorldGuildMemberListRes = descriptor.def_message("WorldGuildMemberListRes", 601920, 
	{
		//  ��Ա�б�

		descriptor.def_message_vector_field("members", GuildMemberEntry),
	}
)

//  �޸Ĺ�������

WorldGuildModifyDeclaration = descriptor.def_message("WorldGuildModifyDeclaration", 601921, 
	{
		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
	}
)

//  �޸Ĺ�����

WorldGuildModifyName = descriptor.def_message("WorldGuildModifyName", 601922, 
	{
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("itemGUID", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("itemTableID", descriptor.type_uint32, 0),
	}
)

//  �޸Ĺ��ṫ��

WorldGuildModifyAnnouncement = descriptor.def_message("WorldGuildModifyAnnouncement", 601923, 
	{
		descriptor.def_scalar_field("content", descriptor.type_string, ""),
	}
)

//  ���͹����ʼ�

WorldGuildSendMail = descriptor.def_message("WorldGuildSendMail", 601924, 
	{
		descriptor.def_scalar_field("content", descriptor.type_string, ""),
	}
)

//  ͬ�������޸���Ϣ(ʹ�����ķ�ʽͬ��)

WorldGuildSyncStreamInfo = descriptor.def_message("WorldGuildSyncStreamInfo", 601925, 
	{
	}
)

//  ���ͨ�ò�������

WorldGuildOperRes = descriptor.def_message("WorldGuildOperRes", 601926, 
	{
		//  �������ͣ���Ӧö��GuildOperation��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ���

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  ����1

		descriptor.def_scalar_field("param", descriptor.type_uint32, 0),
		//  ����2

		descriptor.def_scalar_field("param2", descriptor.type_uint64, 0),
	}
)

//  ��������

WorldGuildUpgradeBuilding = descriptor.def_message("WorldGuildUpgradeBuilding", 601927, 
	{
		//  �������ͣ���Ӧö��GuildBuildingType��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  �������

WorldGuildDonateReq = descriptor.def_message("WorldGuildDonateReq", 601928, 
	{
		//  �������ͣ���Ӧö��GuildDonateType��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ����

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  ���������־

WorldGuildDonateLogReq = descriptor.def_message("WorldGuildDonateLogReq", 601929, 
	{
	}
)

//  ���ؾ�����־

WorldGuildDonateLogRes = descriptor.def_message("WorldGuildDonateLogRes", 601930, 
	{
		descriptor.def_message_vector_field("logs", GuildDonateLog),
	}
)

//  ��������

WorldGuildUpgradeSkill = descriptor.def_message("WorldGuildUpgradeSkill", 601931, 
	{
		//  ����id

		descriptor.def_scalar_field("skillId", descriptor.type_uint16, 0),
	}
)

//  ��ɢ����

WorldGuildDismissReq = descriptor.def_message("WorldGuildDismissReq", 601932, 
	{
	}
)

//  ȡ����ɢ����

WorldGuildCancelDismissReq = descriptor.def_message("WorldGuildCancelDismissReq", 601933, 
	{
	}
)

//  ����᳤��Ϣ

WorldGuildLeaderInfoReq = descriptor.def_message("WorldGuildLeaderInfoReq", 601934, 
	{
	}
)

//  ���ػ᳤��Ϣ

WorldGuildLeaderInfoRes = descriptor.def_message("WorldGuildLeaderInfoRes", 601935, 
	{
		descriptor.def_message_field("info", GuildLeaderInfo),
	}
)

//  ����Ĥ��

WorldGuildOrzReq = descriptor.def_message("WorldGuildOrzReq", 601936, 
	{
		//  Ĥ�����ͣ���Ӧö�٣�GuildOrzType��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  �������Բ������

WorldGuildTableJoinReq = descriptor.def_message("WorldGuildTableJoinReq", 601937, 
	{
		//  λ��

		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		//  �ǲ���Э��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  ֪ͨ�ͻ������µ�Բ�������Ա

WorldGuildTableNewMember = descriptor.def_message("WorldGuildTableNewMember", 601938, 
	{
		descriptor.def_message_field("member", GuildTableMember),
	}
)

//  ֪ͨ�ͻ���ɾ��Բ�������Ա

WorldGuildTableDelMember = descriptor.def_message("WorldGuildTableDelMember", 601939, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  ֪ͨ�ͻ��˵�Բ���������

WorldGuildTableFinish = descriptor.def_message("WorldGuildTableFinish", 601940, 
	{
	}
)

//  �����ԷѺ��

WorldGuildPayRedPacketReq = descriptor.def_message("WorldGuildPayRedPacketReq", 601941, 
	{
		//  ��Դ

		descriptor.def_scalar_field("reason", descriptor.type_uint16, 0),
		//  ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  ����

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  ����һ�

SceneGuildExchangeReq = descriptor.def_message("SceneGuildExchangeReq", 501901, 
	{
	}
)

//  ���󹫻�ս����

WorldGuildBattleReq = descriptor.def_message("WorldGuildBattleReq", 601942, 
	{
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
	}
)

//  ���󹫻�ս����

WorldGuildBattleRes = descriptor.def_message("WorldGuildBattleRes", 601943, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("enrollSize", descriptor.type_uint32, 0),
	}
)

//  �������

WorldGuildBattleInspireReq = descriptor.def_message("WorldGuildBattleInspireReq", 601944, 
	{
	}
)

//  ���践��

WorldGuildBattleInspireRes = descriptor.def_message("WorldGuildBattleInspireRes", 601945, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("inspire", descriptor.type_uint8, 0),
	}
)

//  ������ȡ����

WorldGuildBattleReceiveReq = descriptor.def_message("WorldGuildBattleReceiveReq", 601946, 
	{
		descriptor.def_scalar_field("boxId", descriptor.type_uint8, 0),
	}
)

//  ��ȡ��������

WorldGuildBattleReceiveRes = descriptor.def_message("WorldGuildBattleReceiveRes", 601947, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("boxId", descriptor.type_uint8, 0),
	}
)

//  �������ս����¼

WorldGuildBattleRecordReq = descriptor.def_message("WorldGuildBattleRecordReq", 601948, 
	{
		descriptor.def_scalar_field("isSelf", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("startIndex", descriptor.type_int32, 0),
		descriptor.def_scalar_field("count", descriptor.type_uint32, 0),
	}
)

//  ���ս����¼����

WorldGuildBattleRecordRes = descriptor.def_message("WorldGuildBattleRecordRes", 601949, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("records", GuildBattleRecord),
	}
)

//  ���ս����¼ͬ��

WorldGuildBattleRecordSync = descriptor.def_message("WorldGuildBattleRecordSync", 601950, 
	{
		descriptor.def_message_field("record", GuildBattleRecord),
	}
)

//  ���������Ϣ

WorldGuildBattleTerritoryReq = descriptor.def_message("WorldGuildBattleTerritoryReq", 601951, 
	{
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
	}
)

//  ���������Ϣ

WorldGuildBattleTerritoryRes = descriptor.def_message("WorldGuildBattleTerritoryRes", 601952, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_field("info", GuildTerritoryBaseInfo),
	}
)

//  ����ս������

WorldGuildBattleRaceEnd = descriptor.def_message("WorldGuildBattleRaceEnd", 601953, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("oldScore", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("newScore", descriptor.type_uint32, 0),
	}
)

//  ����ս����

WorldGuildBattleEnd = descriptor.def_message("WorldGuildBattleEnd", 601954, 
	{
		descriptor.def_message_vector_field("info", GuildBattleEndInfo),
	}
)

//  ��������������

WorldGuildBattleSelfSortListReq = descriptor.def_message("WorldGuildBattleSelfSortListReq", 601955, 
	{
	}
)

//  ����������������Ӧ

WorldGuildBattleSelfSortListRes = descriptor.def_message("WorldGuildBattleSelfSortListRes", 601956, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("memberRanking", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("guildRanking", descriptor.type_uint32, 0),
	}
)

//  ��������֪ͨ���б�����������빫��

WorldGuildInviteNotify = descriptor.def_message("WorldGuildInviteNotify", 601957, 
	{
		//  ������ID

		descriptor.def_scalar_field("inviterId", descriptor.type_uint64, 0),
		//  ����������

		descriptor.def_scalar_field("inviterName", descriptor.type_string, ""),
		//  ����ID

		descriptor.def_scalar_field("guildId", descriptor.type_uint64, 0),
		//  ������

		descriptor.def_scalar_field("guildName", descriptor.type_string, ""),
	}
)

//  ͬ������ս״̬

WorldGuildBattleStatusSync = descriptor.def_message("WorldGuildBattleStatusSync", 601958, 
	{
		//  ����

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ״̬

		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
		//  ״̬����ʱ��

		descriptor.def_scalar_field("time", descriptor.type_uint32, 0),
		//  ����ս������Ϣ

		descriptor.def_message_vector_field("endInfo", GuildBattleEndInfo),
	}
)

//  ���󹫻���ս����

WorldGuildChallengeReq = descriptor.def_message("WorldGuildChallengeReq", 601959, 
	{
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("itemNum", descriptor.type_uint32, 0),
	}
)

//  ���ع�����ս����

WorldGuildChallengeRes = descriptor.def_message("WorldGuildChallengeRes", 601960, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ���󹫻���ս��Ϣ

WorldGuildChallengeInfoReq = descriptor.def_message("WorldGuildChallengeInfoReq", 601961, 
	{
	}
)

//  ������ս��Ϣͬ��

WorldGuildChallengeInfoSync = descriptor.def_message("WorldGuildChallengeInfoSync", 601962, 
	{
		descriptor.def_message_field("info", GuildTerritoryBaseInfo),
		descriptor.def_scalar_field("enrollGuildId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("enrollGuildName", descriptor.type_string, ""),
		descriptor.def_scalar_field("enrollGuildleaderName", descriptor.type_string, ""),
		descriptor.def_scalar_field("enrollGuildLevel", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("itemNum", descriptor.type_uint32, 0),
	}
)

//  ���󹫻�ս������Ϣ

WorldGuildBattleInspireInfoReq = descriptor.def_message("WorldGuildBattleInspireInfoReq", 601963, 
	{
	}
)

//  ���ع���ս������Ϣ

WorldGuildBattleInspireInfoRes = descriptor.def_message("WorldGuildBattleInspireInfoRes", 601964, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  ���ID

		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		//  ������Ϣ

		descriptor.def_message_vector_field("inspireInfos", GuildBattleInspireInfo),
	}
)

//  ���󹫻�ֿ�����

WorldGuildStorageSettingReq = descriptor.def_message("WorldGuildStorageSettingReq", 601965, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("value", descriptor.type_uint32, 0),
	}
)

//  ���ع���ֿ�����

WorldGuildStorageSettingRes = descriptor.def_message("WorldGuildStorageSettingRes", 601966, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ���󹫻�ս�齱

WorldGuildBattleLotteryReq = descriptor.def_message("WorldGuildBattleLotteryReq", 601967, 
	{
	}
)

//  ���ع���ս�齱

WorldGuildBattleLotteryRes = descriptor.def_message("WorldGuildBattleLotteryRes", 601968, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("contribution", descriptor.type_uint32, 0),
	}
)

//  ���󹫻�ֿ��б�

WorldGuildStorageListReq = descriptor.def_message("WorldGuildStorageListReq", 601969, 
	{
	}
)

//  ���ع���ֿ��б�

WorldGuildStorageListRes = descriptor.def_message("WorldGuildStorageListRes", 601970, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("maxSize", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
		descriptor.def_message_vector_field("itemRecords", GuildStorageOpRecord),
	}
)

//  ͬ���ֿ���Ʒ����

WorldGuildStorageItemSync = descriptor.def_message("WorldGuildStorageItemSync", 601971, 
	{
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
		descriptor.def_message_vector_field("records", GuildStorageOpRecord),
	}
)

//  ������빫��ֿ�

WorldGuildAddStorageReq = descriptor.def_message("WorldGuildAddStorageReq", 601972, 
	{
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
	}
)

//  ���ط��빫��ֿ�

WorldGuildAddStorageRes = descriptor.def_message("WorldGuildAddStorageRes", 601973, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ����ɾ������ֿ���Ʒ

WorldGuildDelStorageReq = descriptor.def_message("WorldGuildDelStorageReq", 601974, 
	{
		descriptor.def_message_vector_field("items", GuildStorageDelItemInfo),
	}
)

//  ����ɾ������ֿ���Ʒ

WorldGuildDelStorageRes = descriptor.def_message("WorldGuildDelStorageRes", 601975, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  �鿴�ֿ���Ʒ����

WorldWatchGuildStorageItemReq = descriptor.def_message("WorldWatchGuildStorageItemReq", 601976, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
	}
)

