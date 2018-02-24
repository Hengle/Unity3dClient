local descriptor = require "descriptor"
local ProtocolBase = require "ProtocolBase"

module "ProtocolTeam"

//  ����Ŀ������

TeamTargetType = descriptor.def_enum("TeamTargetType",
	{
		//  ���³�

		descriptor.def_enum_value("Dungeon", 0),
	}
)

//  ��Ա����

TeamMemberProperty = descriptor.def_enum("TeamMemberProperty",
	{
		//  �ȼ�

		descriptor.def_enum_value("Level", 0),
		//  ����ID

		descriptor.def_enum_value("GuildID", 1),
		//  ʣ�����

		descriptor.def_enum_value("RemainTimes", 2),
		//  ְҵ

		descriptor.def_enum_value("Occu", 3),
		//  ״̬

		descriptor.def_enum_value("StatusMask", 4),
		//  vip�ȼ�

		descriptor.def_enum_value("VipLevel", 5),
	}
)

//  ��Ա״̬����

TeamMemberStatusMask = descriptor.def_enum("TeamMemberStatusMask",
	{
		//  �Ƿ�����

		descriptor.def_enum_value("Online", 1),
		//  ׼��

		descriptor.def_enum_value("Ready", 2),
		//  ��ս

		descriptor.def_enum_value("Assist", 4),
		//  �Ƿ���ս����

		descriptor.def_enum_value("Racing", 8),
	}
)

//  ����ѡ���޸�����

TeamOptionOperType = descriptor.def_enum("TeamOptionOperType",
	{
		//  Ŀ��

		descriptor.def_enum_value("Target", 0),
		//  �Զ�ͬ��

		descriptor.def_enum_value("AutoAgree", 1),
	}
)

//  �����Ա������Ϣ

TeammemberBaseInfo = descriptor.def_struct("TeammemberBaseInfo", 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// �ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// ְҵ

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
	}
)

//  ��������

WorldCreateTeam = descriptor.def_message("WorldCreateTeam", 601610, 
	{
		//  ����Ŀ��

		descriptor.def_scalar_field("target", descriptor.type_uint32, 0),
	}
)

//  �������鷵��

WorldCreateTeamRes = descriptor.def_message("WorldCreateTeamRes", 601627, 
	{
		//  ������(ErrorCode)

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ������鷵��

WorldJoinTeamRes = descriptor.def_message("WorldJoinTeamRes", 601628, 
	{
		//  ������(ErrorCode)

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("inTeam", descriptor.type_uint8, 0),
	}
)

//  ���������Ϣ

TeamBaseInfo = descriptor.def_struct("TeamBaseInfo", 
	{
		//  ������

		descriptor.def_scalar_field("teamId", descriptor.type_uint16, 0),
		//  ����Ŀ��

		descriptor.def_scalar_field("target", descriptor.type_uint32, 0),
		//  �ӳ���Ϣ

		descriptor.def_message_field("masterInfo", TeammemberBaseInfo),
		//  ��Ա����

		descriptor.def_scalar_field("memberNum", descriptor.type_uint8, 0),
		//  ��Ա����

		descriptor.def_scalar_field("maxMemberNum", descriptor.type_uint8, 0),
	}
)

//  �����Ա��Ϣ

TeammemberInfo = descriptor.def_struct("TeammemberInfo", 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// �ȼ�

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// ְҵ

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  ״̬���루��Ӧö��TeamMemberStatusMask��

		descriptor.def_scalar_field("statusMask", descriptor.type_uint8, 0),
		//  ���

		descriptor.def_message_field("avatar", ProtocolBase.PlayerAvatar),
		//  ʣ�����

		descriptor.def_scalar_field("remainTimes", descriptor.type_uint32, 0),
		//  ����ID

		descriptor.def_scalar_field("guildId", descriptor.type_uint64, 0),
		//  vip�ȼ�

		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
	}
)

//  ͬ��������Ϣ

WorldSyncTeamInfo = descriptor.def_message("WorldSyncTeamInfo", 601601, 
	{
		//  ������

		descriptor.def_scalar_field("id", descriptor.type_uint16, 0),
		//  ����Ŀ��

		descriptor.def_scalar_field("target", descriptor.type_uint32, 0),
		//  �Ƿ��Զ�ͬ��

		descriptor.def_scalar_field("autoAgree", descriptor.type_uint8, 0),
		//  �ӳ�

		descriptor.def_scalar_field("master", descriptor.type_uint64, 0),
		//  �����Ա����

		descriptor.def_message_vector_field("members", TeammemberInfo),
	}
)

//  ֪ͨ�³�Ա����

WorldNotifyNewTeamMember = descriptor.def_message("WorldNotifyNewTeamMember", 601602, 
	{
		//  ��Ա��Ϣ

		descriptor.def_message_field("info", TeammemberInfo),
	}
)

//  �����뿪����

WorldLeaveTeamReq = descriptor.def_message("WorldLeaveTeamReq", 601603, 
	{
		//  ���˻��Լ�

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  ֪ͨ��Ա�뿪

WorldNotifyMemberLeave = descriptor.def_message("WorldNotifyMemberLeave", 601604, 
	{
		//  ��ԱID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  ֪ͨ��Ա������

WorldSyncTeamMemberStatus = descriptor.def_message("WorldSyncTeamMemberStatus", 601605, 
	{
		//  ��ԱID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ״̬���루��Ӧö��TeamMemberStatusMask��

		descriptor.def_scalar_field("statusMask", descriptor.type_uint8, 0),
	}
)

//  ������������뷢����������

WorldTeamPasswdReq = descriptor.def_message("WorldTeamPasswdReq", 601612, 
	{
		// Ŀ��

		descriptor.def_scalar_field("target", descriptor.type_uint64, 0),
	}
)

//  ���ö�������

WorldSetTeamOption = descriptor.def_message("WorldSetTeamOption", 601625, 
	{
		//  �������ͣ�TeamOptionOperType��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ���治ͬ����´���ͬ������

		descriptor.def_scalar_field("str", descriptor.type_string, ""),
		descriptor.def_scalar_field("param1", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("param2", descriptor.type_uint32, 0),
	}
)

//  ͬ����������

WorldSyncTeamOption = descriptor.def_message("WorldSyncTeamOption", 601626, 
	{
		//  �������ͣ�TeamOptionOperType��

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  ���治ͬ����´���ͬ������

		descriptor.def_scalar_field("str", descriptor.type_string, ""),
		descriptor.def_scalar_field("param1", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("param2", descriptor.type_uint32, 0),
	}
)

//  ����ת�öӳ�

WorldTransferTeammaster = descriptor.def_message("WorldTransferTeammaster", 601608, 
	{
		//  ��ԱID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  ͬ���¶ӳ�

WorldSyncTeammaster = descriptor.def_message("WorldSyncTeammaster", 601609, 
	{
		//  �ӳ�ID

		descriptor.def_scalar_field("master", descriptor.type_uint64, 0),
	}
)

//  ��ɢ����

WorldDismissTeam = descriptor.def_message("WorldDismissTeam", 601611, 
	{
	}
)

//  ��ѯ�����б�

WorldQueryTeamList = descriptor.def_message("WorldQueryTeamList", 601623, 
	{
		//  ���ݶ���������

		descriptor.def_scalar_field("teamId", descriptor.type_uint16, 0),
		//  ����Ŀ��

		descriptor.def_scalar_field("targetId", descriptor.type_uint32, 0),
		//  ���ݵ��³�����

		descriptor.def_scalar_vector_field("targetList", descriptor.type_uint32, 0),
		//  ��ѯ��ʼλ��

		descriptor.def_scalar_field("startPos", descriptor.type_uint16, 0),
		//  �������

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  ���ض����б�

WorldQueryTeamListRet = descriptor.def_message("WorldQueryTeamListRet", 601624, 
	{
		//  ����Ŀ��

		descriptor.def_scalar_field("targetId", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("teamList", TeamBaseInfo),
		descriptor.def_scalar_field("pos", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("maxNum", descriptor.type_uint16, 0),
	}
)

//  ͬ���ӳ�����

WorldTeamMasterOperSync = descriptor.def_message("WorldTeamMasterOperSync", 601629, 
	{
		//  ��������

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  �������

		descriptor.def_scalar_field("param", descriptor.type_uint32, 0),
	}
)

//  �����޸�λ��״̬���򿪻�رգ�

WorldTeamChangePosStatusReq = descriptor.def_message("WorldTeamChangePosStatusReq", 601630, 
	{
		//  λ��

		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		//  0�����λ�ã�1����ر�λ��

		descriptor.def_scalar_field("open", descriptor.type_uint8, 0),
	}
)

//  ͬ��λ��״̬�ı�

WorldTeamChangePosStatusSync = descriptor.def_message("WorldTeamChangePosStatusSync", 601631, 
	{
		//  λ��

		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		//  1�����λ�ã�0����ر�λ��

		descriptor.def_scalar_field("open", descriptor.type_uint8, 0),
	}
)

//  ׼��

WorldTeamReadyReq = descriptor.def_message("WorldTeamReadyReq", 601632, 
	{
		//  �Ƿ�׼����(0:ȡ�� 1:׼��)

		descriptor.def_scalar_field("ready", descriptor.type_uint8, 0),
	}
)

//  ͬ�������Ϣ

WorldSyncTeammemberAvatar = descriptor.def_message("WorldSyncTeammemberAvatar", 601636, 
	{
		//  ��ԱID

		descriptor.def_scalar_field("memberId", descriptor.type_uint64, 0),
		//  ���

		descriptor.def_message_field("avatar", ProtocolBase.PlayerAvatar),
	}
)

//  ֪ͨ����������ӵ���

WorldTeamNotifyNewRequester = descriptor.def_message("WorldTeamNotifyNewRequester", 601637, 
	{
	}
)

//  ��ȡ�����б�

WorldTeamRequesterListReq = descriptor.def_message("WorldTeamRequesterListReq", 601638, 
	{
	}
)

//  ���������б�

WorldTeamRequesterListRes = descriptor.def_message("WorldTeamRequesterListRes", 601639, 
	{
		descriptor.def_message_vector_field("requesters", TeammemberBaseInfo),
	}
)

//  ���������ߣ�ͬ�⡢�ܾ���

WorldTeamProcessRequesterReq = descriptor.def_message("WorldTeamProcessRequesterReq", 601640, 
	{
		//  Ŀ��ID

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  �Ƿ�ͬ��

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  ���������߷���

WorldTeamProcessRequesterRes = descriptor.def_message("WorldTeamProcessRequesterRes", 601641, 
	{
		//  Ŀ��ID

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  ���

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ֪ͨ��ʼ���³�ͶƱ

WorldTeamRaceVoteNotify = descriptor.def_message("WorldTeamRaceVoteNotify", 601642, 
	{
		//  ���³�ID

		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
	}
)

//  ����ϱ�ͶƱѡ��

WorldTeamReportVoteChoice = descriptor.def_message("WorldTeamReportVoteChoice", 601643, 
	{
		//  �Ƿ�ͬ��

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  �������뷵��

WorldTeamInviteRes = descriptor.def_message("WorldTeamInviteRes", 601644, 
	{
		//  Ŀ�����ID

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  ���

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ֪ͨ��Ҷ�������

WorldTeamInviteNotify = descriptor.def_message("WorldTeamInviteNotify", 601645, 
	{
		//  ������Ϣ

		descriptor.def_message_field("info", TeamBaseInfo),
	}
)

//  ֪ͨ��Ҷ�����������

WorldTeamRequestResultNotify = descriptor.def_message("WorldTeamRequestResultNotify", 601646, 
	{
		//  �Ƿ�ͬ��

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  �㲥������ͶƱѡ��

WorldTeamVoteChoiceNotify = descriptor.def_message("WorldTeamVoteChoiceNotify", 601647, 
	{
		//  ��ɫID

		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		//  �Ƿ�ͬ��

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  ֪ͨ�����ӿ���ƥ����

WorldTeamMatchResultNotify = descriptor.def_message("WorldTeamMatchResultNotify", 601648, 
	{
		//  ���³�ID

		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
		//  �Ƿ�ͬ��

		descriptor.def_message_vector_field("players", ProtocolBase.PlayerIcon),
	}
)

//  ����ȡ�����ƥ��

WorldTeamMatchCancelReq = descriptor.def_message("WorldTeamMatchCancelReq", 601650, 
	{
	}
)

//  ȡ�����ƥ�䷵��

WorldTeamMatchCancelRes = descriptor.def_message("WorldTeamMatchCancelRes", 601651, 
	{
		//  ���

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ����ʼ���ƥ��

SceneTeamMatchStartReq = descriptor.def_message("SceneTeamMatchStartReq", 501604, 
	{
		//  Ŀ����³�ID

		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
	}
)

//  ��ʼ���ƥ�䷵��

SceneTeamMatchStartRes = descriptor.def_message("SceneTeamMatchStartRes", 501605, 
	{
		//  ���

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ͬ����Ա����

WorldSyncTeamMemberProperty = descriptor.def_message("WorldSyncTeamMemberProperty", 601654, 
	{
		//  ��ԱID

		descriptor.def_scalar_field("memberId", descriptor.type_uint64, 0),
		//  �������ͣ���Ӧö��TeamMemberProperty

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  �µ�ֵ

		descriptor.def_scalar_field("value", descriptor.type_uint64, 0),
	}
)

//  ͬ����Ա����

WorldChangeAssistModeReq = descriptor.def_message("WorldChangeAssistModeReq", 601655, 
	{
		//  �Ƿ���ս

		descriptor.def_scalar_field("isAssist", descriptor.type_uint8, 0),
	}
)

