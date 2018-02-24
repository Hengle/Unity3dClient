local descriptor = require "descriptor"
local ProtocolBase = require "ProtocolBase"

module "ProtocolTeam"

//  队伍目标类型

TeamTargetType = descriptor.def_enum("TeamTargetType",
	{
		//  地下城

		descriptor.def_enum_value("Dungeon", 0),
	}
)

//  队员属性

TeamMemberProperty = descriptor.def_enum("TeamMemberProperty",
	{
		//  等级

		descriptor.def_enum_value("Level", 0),
		//  公会ID

		descriptor.def_enum_value("GuildID", 1),
		//  剩余次数

		descriptor.def_enum_value("RemainTimes", 2),
		//  职业

		descriptor.def_enum_value("Occu", 3),
		//  状态

		descriptor.def_enum_value("StatusMask", 4),
		//  vip等级

		descriptor.def_enum_value("VipLevel", 5),
	}
)

//  成员状态掩码

TeamMemberStatusMask = descriptor.def_enum("TeamMemberStatusMask",
	{
		//  是否在线

		descriptor.def_enum_value("Online", 1),
		//  准备

		descriptor.def_enum_value("Ready", 2),
		//  助战

		descriptor.def_enum_value("Assist", 4),
		//  是否在战斗中

		descriptor.def_enum_value("Racing", 8),
	}
)

//  队伍选项修改类型

TeamOptionOperType = descriptor.def_enum("TeamOptionOperType",
	{
		//  目标

		descriptor.def_enum_value("Target", 0),
		//  自动同意

		descriptor.def_enum_value("AutoAgree", 1),
	}
)

//  队伍成员基本信息

TeammemberBaseInfo = descriptor.def_struct("TeammemberBaseInfo", 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// 名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// 等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// 职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
	}
)

//  创建队伍

WorldCreateTeam = descriptor.def_message("WorldCreateTeam", 601610, 
	{
		//  队伍目标

		descriptor.def_scalar_field("target", descriptor.type_uint32, 0),
	}
)

//  创建队伍返回

WorldCreateTeamRes = descriptor.def_message("WorldCreateTeamRes", 601627, 
	{
		//  返回码(ErrorCode)

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  加入队伍返回

WorldJoinTeamRes = descriptor.def_message("WorldJoinTeamRes", 601628, 
	{
		//  返回码(ErrorCode)

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("inTeam", descriptor.type_uint8, 0),
	}
)

//  队伍基础信息

TeamBaseInfo = descriptor.def_struct("TeamBaseInfo", 
	{
		//  队伍编号

		descriptor.def_scalar_field("teamId", descriptor.type_uint16, 0),
		//  队伍目标

		descriptor.def_scalar_field("target", descriptor.type_uint32, 0),
		//  队长信息

		descriptor.def_message_field("masterInfo", TeammemberBaseInfo),
		//  成员数量

		descriptor.def_scalar_field("memberNum", descriptor.type_uint8, 0),
		//  成员上限

		descriptor.def_scalar_field("maxMemberNum", descriptor.type_uint8, 0),
	}
)

//  队伍成员信息

TeammemberInfo = descriptor.def_struct("TeammemberInfo", 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// 名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// 等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// 职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  状态掩码（对应枚举TeamMemberStatusMask）

		descriptor.def_scalar_field("statusMask", descriptor.type_uint8, 0),
		//  外观

		descriptor.def_message_field("avatar", ProtocolBase.PlayerAvatar),
		//  剩余次数

		descriptor.def_scalar_field("remainTimes", descriptor.type_uint32, 0),
		//  公会ID

		descriptor.def_scalar_field("guildId", descriptor.type_uint64, 0),
		//  vip等级

		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
	}
)

//  同步队伍信息

WorldSyncTeamInfo = descriptor.def_message("WorldSyncTeamInfo", 601601, 
	{
		//  队伍编号

		descriptor.def_scalar_field("id", descriptor.type_uint16, 0),
		//  队伍目标

		descriptor.def_scalar_field("target", descriptor.type_uint32, 0),
		//  是否自动同意

		descriptor.def_scalar_field("autoAgree", descriptor.type_uint8, 0),
		//  队长

		descriptor.def_scalar_field("master", descriptor.type_uint64, 0),
		//  队伍成员链表

		descriptor.def_message_vector_field("members", TeammemberInfo),
	}
)

//  通知新成员加入

WorldNotifyNewTeamMember = descriptor.def_message("WorldNotifyNewTeamMember", 601602, 
	{
		//  队员信息

		descriptor.def_message_field("info", TeammemberInfo),
	}
)

//  请求离开队伍

WorldLeaveTeamReq = descriptor.def_message("WorldLeaveTeamReq", 601603, 
	{
		//  踢人或自己

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  通知成员离开

WorldNotifyMemberLeave = descriptor.def_message("WorldNotifyMemberLeave", 601604, 
	{
		//  队员ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  通知成员上下线

WorldSyncTeamMemberStatus = descriptor.def_message("WorldSyncTeamMemberStatus", 601605, 
	{
		//  队员ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  状态掩码（对应枚举TeamMemberStatusMask）

		descriptor.def_scalar_field("statusMask", descriptor.type_uint8, 0),
	}
)

//  队伍如果有密码发起请求密码

WorldTeamPasswdReq = descriptor.def_message("WorldTeamPasswdReq", 601612, 
	{
		// 目标

		descriptor.def_scalar_field("target", descriptor.type_uint64, 0),
	}
)

//  设置队伍属性

WorldSetTeamOption = descriptor.def_message("WorldSetTeamOption", 601625, 
	{
		//  操作类型（TeamOptionOperType）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  下面不同情况下代表不同的意义

		descriptor.def_scalar_field("str", descriptor.type_string, ""),
		descriptor.def_scalar_field("param1", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("param2", descriptor.type_uint32, 0),
	}
)

//  同步队伍属性

WorldSyncTeamOption = descriptor.def_message("WorldSyncTeamOption", 601626, 
	{
		//  操作类型（TeamOptionOperType）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  下面不同情况下代表不同的意义

		descriptor.def_scalar_field("str", descriptor.type_string, ""),
		descriptor.def_scalar_field("param1", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("param2", descriptor.type_uint32, 0),
	}
)

//  请求转让队长

WorldTransferTeammaster = descriptor.def_message("WorldTransferTeammaster", 601608, 
	{
		//  队员ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  同步新队长

WorldSyncTeammaster = descriptor.def_message("WorldSyncTeammaster", 601609, 
	{
		//  队长ID

		descriptor.def_scalar_field("master", descriptor.type_uint64, 0),
	}
)

//  解散队伍

WorldDismissTeam = descriptor.def_message("WorldDismissTeam", 601611, 
	{
	}
)

//  查询队伍列表

WorldQueryTeamList = descriptor.def_message("WorldQueryTeamList", 601623, 
	{
		//  根据队伍编号搜索

		descriptor.def_scalar_field("teamId", descriptor.type_uint16, 0),
		//  队伍目标

		descriptor.def_scalar_field("targetId", descriptor.type_uint32, 0),
		//  根据地下城搜索

		descriptor.def_scalar_vector_field("targetList", descriptor.type_uint32, 0),
		//  查询起始位置

		descriptor.def_scalar_field("startPos", descriptor.type_uint16, 0),
		//  请求个数

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  返回队伍列表

WorldQueryTeamListRet = descriptor.def_message("WorldQueryTeamListRet", 601624, 
	{
		//  队伍目标

		descriptor.def_scalar_field("targetId", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("teamList", TeamBaseInfo),
		descriptor.def_scalar_field("pos", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("maxNum", descriptor.type_uint16, 0),
	}
)

//  同步队长操作

WorldTeamMasterOperSync = descriptor.def_message("WorldTeamMasterOperSync", 601629, 
	{
		//  操作类型

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  具体操作

		descriptor.def_scalar_field("param", descriptor.type_uint32, 0),
	}
)

//  请求修改位置状态（打开或关闭）

WorldTeamChangePosStatusReq = descriptor.def_message("WorldTeamChangePosStatusReq", 601630, 
	{
		//  位置

		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		//  0代表打开位置，1代表关闭位置

		descriptor.def_scalar_field("open", descriptor.type_uint8, 0),
	}
)

//  同步位置状态改变

WorldTeamChangePosStatusSync = descriptor.def_message("WorldTeamChangePosStatusSync", 601631, 
	{
		//  位置

		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		//  1代表打开位置，0代表关闭位置

		descriptor.def_scalar_field("open", descriptor.type_uint8, 0),
	}
)

//  准备

WorldTeamReadyReq = descriptor.def_message("WorldTeamReadyReq", 601632, 
	{
		//  是否准备好(0:取消 1:准备)

		descriptor.def_scalar_field("ready", descriptor.type_uint8, 0),
	}
)

//  同步外观信息

WorldSyncTeammemberAvatar = descriptor.def_message("WorldSyncTeammemberAvatar", 601636, 
	{
		//  成员ID

		descriptor.def_scalar_field("memberId", descriptor.type_uint64, 0),
		//  外观

		descriptor.def_message_field("avatar", ProtocolBase.PlayerAvatar),
	}
)

//  通知有新申请入队的人

WorldTeamNotifyNewRequester = descriptor.def_message("WorldTeamNotifyNewRequester", 601637, 
	{
	}
)

//  获取申请列表

WorldTeamRequesterListReq = descriptor.def_message("WorldTeamRequesterListReq", 601638, 
	{
	}
)

//  返回申请列表

WorldTeamRequesterListRes = descriptor.def_message("WorldTeamRequesterListRes", 601639, 
	{
		descriptor.def_message_vector_field("requesters", TeammemberBaseInfo),
	}
)

//  处理申请者（同意、拒绝）

WorldTeamProcessRequesterReq = descriptor.def_message("WorldTeamProcessRequesterReq", 601640, 
	{
		//  目标ID

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  是否同意

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  处理请求者返回

WorldTeamProcessRequesterRes = descriptor.def_message("WorldTeamProcessRequesterRes", 601641, 
	{
		//  目标ID

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  通知开始地下城投票

WorldTeamRaceVoteNotify = descriptor.def_message("WorldTeamRaceVoteNotify", 601642, 
	{
		//  地下城ID

		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
	}
)

//  玩家上报投票选项

WorldTeamReportVoteChoice = descriptor.def_message("WorldTeamReportVoteChoice", 601643, 
	{
		//  是否同意

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  队伍邀请返回

WorldTeamInviteRes = descriptor.def_message("WorldTeamInviteRes", 601644, 
	{
		//  目标玩家ID

		descriptor.def_scalar_field("targetId", descriptor.type_uint64, 0),
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  通知玩家队伍邀请

WorldTeamInviteNotify = descriptor.def_message("WorldTeamInviteNotify", 601645, 
	{
		//  队伍信息

		descriptor.def_message_field("info", TeamBaseInfo),
	}
)

//  通知玩家队伍请求处理结果

WorldTeamRequestResultNotify = descriptor.def_message("WorldTeamRequestResultNotify", 601646, 
	{
		//  是否同意

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  广播玩家玩家投票选项

WorldTeamVoteChoiceNotify = descriptor.def_message("WorldTeamVoteChoiceNotify", 601647, 
	{
		//  角色ID

		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		//  是否同意

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  通知玩家组队快速匹配结果

WorldTeamMatchResultNotify = descriptor.def_message("WorldTeamMatchResultNotify", 601648, 
	{
		//  地下城ID

		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
		//  是否同意

		descriptor.def_message_vector_field("players", ProtocolBase.PlayerIcon),
	}
)

//  请求取消组队匹配

WorldTeamMatchCancelReq = descriptor.def_message("WorldTeamMatchCancelReq", 601650, 
	{
	}
)

//  取消组队匹配返回

WorldTeamMatchCancelRes = descriptor.def_message("WorldTeamMatchCancelRes", 601651, 
	{
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求开始组队匹配

SceneTeamMatchStartReq = descriptor.def_message("SceneTeamMatchStartReq", 501604, 
	{
		//  目标地下城ID

		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
	}
)

//  开始组队匹配返回

SceneTeamMatchStartRes = descriptor.def_message("SceneTeamMatchStartRes", 501605, 
	{
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  同步队员属性

WorldSyncTeamMemberProperty = descriptor.def_message("WorldSyncTeamMemberProperty", 601654, 
	{
		//  成员ID

		descriptor.def_scalar_field("memberId", descriptor.type_uint64, 0),
		//  属性类型，对应枚举TeamMemberProperty

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  新的值

		descriptor.def_scalar_field("value", descriptor.type_uint64, 0),
	}
)

//  同步队员属性

WorldChangeAssistModeReq = descriptor.def_message("WorldChangeAssistModeReq", 601655, 
	{
		//  是否助战

		descriptor.def_scalar_field("isAssist", descriptor.type_uint8, 0),
	}
)

