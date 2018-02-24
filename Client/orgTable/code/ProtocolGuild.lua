local descriptor = require "descriptor"
local Protocol = require "Protocol"
local ProtocolBase = require "ProtocolBase"

module "ProtocolGuild"

//  公会职务

GuildPost = descriptor.def_enum("GuildPost",
	{
		//  无效值

		descriptor.def_enum_value("GUILD_INVALID", 0),
		//  普通成员

		descriptor.def_enum_value("GUILD_POST_NORMAL", 1),
		//  精英

		descriptor.def_enum_value("GUILD_POST_ELITE", 2),
		//  长老

		descriptor.def_enum_value("GUILD_POST_ELDER", 11),
		//  副会长

		descriptor.def_enum_value("GUILD_POST_ASSISTANT", 12),
		//  会长

		descriptor.def_enum_value("GUILD_POST_LEADER", 13),
	}
)

//  公会属性

GuildAttr = descriptor.def_enum("GuildAttr",
	{
		//  无效属性

		descriptor.def_enum_value("GA_INVALID", 0),
		//  名字	string	

		descriptor.def_enum_value("GA_NAME", 1),
		//  等级	UInt8	

		descriptor.def_enum_value("GA_LEVEL", 2),
		//  宣言 string

		descriptor.def_enum_value("GA_DECLARATION", 3),
		//  部落资金 Int32

		descriptor.def_enum_value("GA_FUND", 4),
		//  公告 string

		descriptor.def_enum_value("GA_ANNOUNCEMENT", 5),
		//  公会建筑 GuildBuilding

		descriptor.def_enum_value("GA_BUILDING", 6),
		//  解散时间 UInt32

		descriptor.def_enum_value("GA_DISMISS_TIME", 7),
		//  成员数量 UInt16

		descriptor.def_enum_value("GA_MEMBER_NUM", 8),
		//  会长名字 string

		descriptor.def_enum_value("GA_LEADER_NAME", 9),
		//  报名领地ID UInt8

		descriptor.def_enum_value("GA_ENROLL_TERRID", 10),
		//  公会战分数 UInt32

		descriptor.def_enum_value("GA_BATTLE_SCORE", 11),
		//  公会占领领地 UInt8

		descriptor.def_enum_value("GA_OCCUPY_TERRID", 12),
		//  公会战鼓舞次数 UInt8

		descriptor.def_enum_value("GA_INSPIRE", 13),
		//  公会战胜利抽奖几率 UInt8

		descriptor.def_enum_value("GA_WIN_PROBABILITY", 14),
		//  公会战失败抽奖几率 UInt8

		descriptor.def_enum_value("GA_LOSE_PROBABILITY", 15),
		//  公会战仓库放入物品 UInt8

		descriptor.def_enum_value("GA_STORAGE_ADD_POST", 16),
		//  公会战仓库删除物品 UInt8

		descriptor.def_enum_value("GA_STORAGE_DEL_POST", 17),
	}
)

// 公会战类型

GuildBattleType = descriptor.def_enum("GuildBattleType",
	{
		//  无效

		descriptor.def_enum_value("GBT_INVALID", 0),
		//  普通

		descriptor.def_enum_value("GBT_NORMAL", 1),
		//  宣战

		descriptor.def_enum_value("GBT_CHALLENGE", 2),
	}
)

//  公会战状态

GuildBattleStatus = descriptor.def_enum("GuildBattleStatus",
	{
		//  无

		descriptor.def_enum_value("GBS_INVALID", 0),
		//  报名

		descriptor.def_enum_value("GBS_ENROLL", 1),
		//  准备

		descriptor.def_enum_value("GBS_PREPARE", 2),
		//  战斗

		descriptor.def_enum_value("GBS_BATTLE", 3),
		//  领奖

		descriptor.def_enum_value("GBS_REWARD", 4),
		descriptor.def_enum_value("GBS_MAX", 5),
	}
)

//  公会建筑类型

GuildBuildingType = descriptor.def_enum("GuildBuildingType",
	{
		//  主城

		descriptor.def_enum_value("MAIN", 0),
		//  商店

		descriptor.def_enum_value("SHOP", 1),
		//  圆桌会议

		descriptor.def_enum_value("TABLE", 2),
		//  地下城

		descriptor.def_enum_value("DUNGEON", 3),
		//  雕像

		descriptor.def_enum_value("STATUE", 4),
		//  战争坊

		descriptor.def_enum_value("BATTLE", 5),
		//  福利社

		descriptor.def_enum_value("WELFARE", 6),
	}
)

//  公会操作类型

GuildOperation = descriptor.def_enum("GuildOperation",
	{
		//  修改公会宣言

		descriptor.def_enum_value("MODIFY_DECLAR", 0),
		//  修改公会名

		descriptor.def_enum_value("MODIFY_NAME", 1),
		//  修改公会公告

		descriptor.def_enum_value("MODIFY_ANNOUNCE", 2),
		//  发送公会邮件

		descriptor.def_enum_value("SEND_MAIL", 3),
		//  升级建筑

		descriptor.def_enum_value("UPGRADE_BUILDING", 4),
		//  捐献

		descriptor.def_enum_value("DONATE", 5),
		//  兑换

		descriptor.def_enum_value("EXCHANGE", 6),
		//  升级技能

		descriptor.def_enum_value("UPGRADE_SKILL", 7),
		//  解散工会

		descriptor.def_enum_value("DISMISS", 8),
		//  取消解散工会

		descriptor.def_enum_value("CANCEL_DISMISS", 9),
		//  膜拜

		descriptor.def_enum_value("ORZ", 10),
		//  圆桌会议

		descriptor.def_enum_value("TABLE", 11),
		//  自费红包

		descriptor.def_enum_value("PAY_REDPACKET", 12),
	}
)

//  捐献

GuildDonateType = descriptor.def_enum("GuildDonateType",
	{
		//  金币捐献

		descriptor.def_enum_value("GOLD", 0),
		//  点劵捐献

		descriptor.def_enum_value("POINT", 1),
	}
)

//  膜拜类型

GuildOrzType = descriptor.def_enum("GuildOrzType",
	{
		//  普通膜拜

		descriptor.def_enum_value("GUILD_ORZ_LOW", 0),
		//  中级膜拜

		descriptor.def_enum_value("GUILD_ORZ_MID", 1),
		//  高级膜拜

		descriptor.def_enum_value("GUILD_ORZ_HIGH", 2),
	}
)

//  公会仓库设置类型

GuildStorageSetting = descriptor.def_enum("GuildStorageSetting",
	{
		descriptor.def_enum_value("GUILD_POST_INVALID", 0),
		//  胜利抽奖几率

		descriptor.def_enum_value("GSS_WIN_PROBABILITY", 1),
		//  失败抽奖几率

		descriptor.def_enum_value("GSS_LOSE_PROBABILITY", 2),
		//  仓库增加权限

		descriptor.def_enum_value("GSS_STORAGE_ADD_POST", 3),
		//  仓库删除权限

		descriptor.def_enum_value("GSS_STORAGE_DEL_POST", 4),
		descriptor.def_enum_value("GSS_MAX", 5),
	}
)

//  公会成员抽奖状态

GuildBattleLotteryStatus = descriptor.def_enum("GuildBattleLotteryStatus",
	{
		//  无效

		descriptor.def_enum_value("GBLS_INVALID", 0),
		//  不能抽奖

		descriptor.def_enum_value("GBLS_NOT", 1),
		//  可以抽奖

		descriptor.def_enum_value("GBLS_CAN", 2),
		//  已经抽奖

		descriptor.def_enum_value("GBLS_FIN", 3),
		descriptor.def_enum_value("GBLS_MAX", 4),
	}
)

GuildStorageOpType = descriptor.def_enum("GuildStorageOpType",
	{
		descriptor.def_enum_value("GSOT_NONE", 0),
		//  获得

		descriptor.def_enum_value("GSOT_GET", 1),
		//  存入

		descriptor.def_enum_value("GSOT_PUT", 2),
		//  购买并存入

		descriptor.def_enum_value("GSOT_BUYPUT", 3),
	}
)

//  公会信息

GuildEntry = descriptor.def_struct("GuildEntry", 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  name

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  公会等级

		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		//  公会人数

		descriptor.def_scalar_field("memberNum", descriptor.type_uint8, 0),
		//  会长名字

		descriptor.def_scalar_field("leaderName", descriptor.type_string, ""),
		//  宣言

		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
		//  是否已经申请

		descriptor.def_scalar_field("isRequested", descriptor.type_uint8, 0),
	}
)

//  公会成员

GuildMemberEntry = descriptor.def_struct("GuildMemberEntry", 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  name

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		//  职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  职务(对应枚举GuildPost)

		descriptor.def_scalar_field("post", descriptor.type_uint8, 0),
		//  历史贡献

		descriptor.def_scalar_field("contribution", descriptor.type_uint32, 0),
		//  离线时间(0代表在线)

		descriptor.def_scalar_field("logoutTime", descriptor.type_uint32, 0),
		//  活跃度

		descriptor.def_scalar_field("activeDegree", descriptor.type_uint32, 0),
		// vip等级

		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
	}
)

//  公会请求者信息

GuildRequesterInfo = descriptor.def_struct("GuildRequesterInfo", 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// 名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// 等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// 职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		// vip等级

		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
		// 申请时间

		descriptor.def_scalar_field("requestTime", descriptor.type_uint32, 0),
	}
)

//  公会建筑

GuildBuilding = descriptor.def_struct("GuildBuilding", 
	{
		//  建筑类型（对应枚举GuildBuildingType）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  等级

		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
	}
)

//  圆桌会议成员信息

GuildTableMember = descriptor.def_struct("GuildTableMember", 
	{
		//  角色ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		//  职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  位置

		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		//  参与类型

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  公会战成员

GuildBattleMember = descriptor.def_struct("GuildBattleMember", 
	{
		//  ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// 名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  连胜数

		descriptor.def_scalar_field("winStreak", descriptor.type_uint8, 0),
		//  获得积分

		descriptor.def_scalar_field("gotScore", descriptor.type_uint16, 0),
		//  总积分

		descriptor.def_scalar_field("totalScore", descriptor.type_uint16, 0),
	}
)

GuildBattleRecord = descriptor.def_struct("GuildBattleRecord", 
	{
		descriptor.def_scalar_field("index", descriptor.type_uint32, 0),
		//  胜利者

		descriptor.def_message_field("winner", GuildBattleMember),
		//  失败者

		descriptor.def_message_field("loser", GuildBattleMember),
		//  时间

		descriptor.def_scalar_field("time", descriptor.type_uint32, 0),
	}
)

GuildTerritoryBaseInfo = descriptor.def_struct("GuildTerritoryBaseInfo", 
	{
		//  领地ID

		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		//  占领公会名称

		descriptor.def_scalar_field("guildName", descriptor.type_string, ""),
		//  已经报名数量

		descriptor.def_scalar_field("enrollSize", descriptor.type_uint32, 0),
	}
)

GuildBattleInspireInfo = descriptor.def_struct("GuildBattleInspireInfo", 
	{
		//  玩家ID

		descriptor.def_scalar_field("playerId", descriptor.type_uint64, 0),
		//  玩家名字

		descriptor.def_scalar_field("playerName", descriptor.type_string, ""),
		//  鼓舞次数

		descriptor.def_scalar_field("inspireNum", descriptor.type_uint32, 0),
	}
)

//  公会战相关信息

GuildBattleBaseInfo = descriptor.def_struct("GuildBattleBaseInfo", 
	{
		//  报名领地ID

		descriptor.def_scalar_field("enrollTerrId", descriptor.type_uint8, 0),
		//  公会战积分

		descriptor.def_scalar_field("guildBattleScore", descriptor.type_uint32, 0),
		//  已经占领的领地ID

		descriptor.def_scalar_field("occupyTerrId", descriptor.type_uint8, 0),
		//  鼓舞次数

		descriptor.def_scalar_field("inspire", descriptor.type_uint8, 0),
		//  自己的公会战记录

		descriptor.def_message_vector_field("selfGuildBattleRecord", GuildBattleRecord),
		//  领地信息

		descriptor.def_message_vector_field("terrInfos", GuildTerritoryBaseInfo),
		// 公会战类型

		descriptor.def_scalar_field("guildBattleType", descriptor.type_uint8, 0),
		// 公会战状态

		descriptor.def_scalar_field("guildBattleStatus", descriptor.type_uint8, 0),
		// 公会战状态结束时间

		descriptor.def_scalar_field("guildBattleStatusEndTime", descriptor.type_uint32, 0),
	}
)

//  公会基础信息

GuildBaseInfo = descriptor.def_struct("GuildBaseInfo", 
	{
		//  公会ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  公会名

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  公会等级

		descriptor.def_scalar_field("level", descriptor.type_uint8, 0),
		//  公会资金

		descriptor.def_scalar_field("fund", descriptor.type_uint32, 0),
		//  公会宣言

		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
		//  公会公告

		descriptor.def_scalar_field("announcement", descriptor.type_string, ""),
		//  解散时间

		descriptor.def_scalar_field("dismissTime", descriptor.type_uint32, 0),
		//  成员数量

		descriptor.def_scalar_field("memberNum", descriptor.type_uint16, 0),
		//  会长名字

		descriptor.def_scalar_field("leaderName", descriptor.type_string, ""),
		//  公会战胜利抽奖几率

		descriptor.def_scalar_field("winProbability", descriptor.type_uint8, 0),
		//  公会战失败抽奖几率

		descriptor.def_scalar_field("loseProbability", descriptor.type_uint8, 0),
		//  公会仓库放入权限

		descriptor.def_scalar_field("storageAddPost", descriptor.type_uint8, 0),
		//  公会仓库放入权限

		descriptor.def_scalar_field("storageDelPost", descriptor.type_uint8, 0),
		//  建筑信息

		descriptor.def_message_vector_field("building", GuildBuilding),
		//  有没有申请加入公会的人

		descriptor.def_scalar_field("hasRequester", descriptor.type_uint8, 0),
		//  圆桌会议成员信息

		descriptor.def_message_vector_field("tableMembers", GuildTableMember),
		//  公会战相关信息

		descriptor.def_message_field("guildBattleInfo", GuildBattleBaseInfo),
	}
)

//  捐献日志

GuildDonateLog = descriptor.def_struct("GuildDonateLog", 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  捐献类型（对应枚举GuildDonateType）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  次数

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
		//  获得贡献

		descriptor.def_scalar_field("contri", descriptor.type_uint32, 0),
	}
)

//  公会会长信息

GuildLeaderInfo = descriptor.def_struct("GuildLeaderInfo", 
	{
		//  ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		//  外观

		descriptor.def_message_field("avatar", ProtocolBase.PlayerAvatar),
		//  人气

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

//  仓库记录类型

GuildStorageOpRecord = descriptor.def_struct("GuildStorageOpRecord", 
	{
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("opType", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
		descriptor.def_scalar_field("time", descriptor.type_uint32, 0),
	}
)

//  创建公会

WorldGuildCreateReq = descriptor.def_message("WorldGuildCreateReq", 601901, 
	{
		// 公会名

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// 宣言

		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
	}
)

//  创建公会返回

WorldGuildCreateRes = descriptor.def_message("WorldGuildCreateRes", 601902, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  离开公会

WorldGuildLeaveReq = descriptor.def_message("WorldGuildLeaveReq", 601903, 
	{
	}
)

//  离开公会返回

WorldGuildLeaveRes = descriptor.def_message("WorldGuildLeaveRes", 601904, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  加入公会

WorldGuildJoinReq = descriptor.def_message("WorldGuildJoinReq", 601905, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  加入公会返回

WorldJoinGuildRes = descriptor.def_message("WorldJoinGuildRes", 601906, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求公会列表

WorldGuildListReq = descriptor.def_message("WorldGuildListReq", 601907, 
	{
		//  开始位置 0开始

		descriptor.def_scalar_field("start", descriptor.type_uint16, 0),
		//  数量

		descriptor.def_scalar_field("num", descriptor.type_uint16, 0),
	}
)

//  返回公会列表

WorldGuildListRes = descriptor.def_message("WorldGuildListRes", 601908, 
	{
		// 开始位置

		descriptor.def_scalar_field("start", descriptor.type_uint16, 0),
		// 总数

		descriptor.def_scalar_field("totalnum", descriptor.type_uint16, 0),
		// 部落列表

		descriptor.def_message_vector_field("guilds", GuildEntry),
	}
)

//  请求申请入公会的列表

WorldGuildRequesterReq = descriptor.def_message("WorldGuildRequesterReq", 601909, 
	{
	}
)

//  返回申请入公会的列表

WorldGuildRequesterRes = descriptor.def_message("WorldGuildRequesterRes", 601910, 
	{
		//  申请人列表

		descriptor.def_message_vector_field("requesters", GuildRequesterInfo),
	}
)

//  通知新的入部落请求

WorldGuildNewRequester = descriptor.def_message("WorldGuildNewRequester", 601911, 
	{
	}
)

//  处理公会成员请求

WorldGuildProcessRequester = descriptor.def_message("WorldGuildProcessRequester", 601912, 
	{
		// id(如果是0代表清空列表)

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// 同意进入(0:不同意，1:同意)

		descriptor.def_scalar_field("agree", descriptor.type_uint8, 0),
	}
)

//  处理公会加入请求返回

WorldGuildProcessRequesterRes = descriptor.def_message("WorldGuildProcessRequesterRes", 601913, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  新成员信息

		descriptor.def_message_field("entry", GuildMemberEntry),
	}
)

//  任命职位

WorldGuildChangePostReq = descriptor.def_message("WorldGuildChangePostReq", 601914, 
	{
		// id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		// 职位

		descriptor.def_scalar_field("post", descriptor.type_uint8, 0),
		// 被替换的人

		descriptor.def_scalar_field("replacerId", descriptor.type_uint64, 0),
	}
)

//  任命职位返回

WorldGuildChangePostRes = descriptor.def_message("WorldGuildChangePostRes", 601915, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  踢人

WorldGuildKick = descriptor.def_message("WorldGuildKick", 601916, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  踢人返回

WorldGuildKickRes = descriptor.def_message("WorldGuildKickRes", 601917, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  上线或新加入公会发送初始数据

WorldGuildSyncInfo = descriptor.def_message("WorldGuildSyncInfo", 601918, 
	{
		//  公会基础信息

		descriptor.def_message_field("info", GuildBaseInfo),
	}
)

//  请求公会成员列表

WorldGuildMemberListReq = descriptor.def_message("WorldGuildMemberListReq", 601919, 
	{
	}
)

//  返回公会成员列表

WorldGuildMemberListRes = descriptor.def_message("WorldGuildMemberListRes", 601920, 
	{
		//  成员列表

		descriptor.def_message_vector_field("members", GuildMemberEntry),
	}
)

//  修改公会宣言

WorldGuildModifyDeclaration = descriptor.def_message("WorldGuildModifyDeclaration", 601921, 
	{
		descriptor.def_scalar_field("declaration", descriptor.type_string, ""),
	}
)

//  修改公会名

WorldGuildModifyName = descriptor.def_message("WorldGuildModifyName", 601922, 
	{
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("itemGUID", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("itemTableID", descriptor.type_uint32, 0),
	}
)

//  修改公会公告

WorldGuildModifyAnnouncement = descriptor.def_message("WorldGuildModifyAnnouncement", 601923, 
	{
		descriptor.def_scalar_field("content", descriptor.type_string, ""),
	}
)

//  发送公会邮件

WorldGuildSendMail = descriptor.def_message("WorldGuildSendMail", 601924, 
	{
		descriptor.def_scalar_field("content", descriptor.type_string, ""),
	}
)

//  同步公会修改信息(使用流的方式同步)

WorldGuildSyncStreamInfo = descriptor.def_message("WorldGuildSyncStreamInfo", 601925, 
	{
	}
)

//  帮会通用操作返回

WorldGuildOperRes = descriptor.def_message("WorldGuildOperRes", 601926, 
	{
		//  操作类型（对应枚举GuildOperation）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  结果

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  参数1

		descriptor.def_scalar_field("param", descriptor.type_uint32, 0),
		//  参数2

		descriptor.def_scalar_field("param2", descriptor.type_uint64, 0),
	}
)

//  升级建筑

WorldGuildUpgradeBuilding = descriptor.def_message("WorldGuildUpgradeBuilding", 601927, 
	{
		//  建筑类型（对应枚举GuildBuildingType）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  请求捐赠

WorldGuildDonateReq = descriptor.def_message("WorldGuildDonateReq", 601928, 
	{
		//  捐赠类型（对应枚举GuildDonateType）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  次数

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  请求捐赠日志

WorldGuildDonateLogReq = descriptor.def_message("WorldGuildDonateLogReq", 601929, 
	{
	}
)

//  返回捐赠日志

WorldGuildDonateLogRes = descriptor.def_message("WorldGuildDonateLogRes", 601930, 
	{
		descriptor.def_message_vector_field("logs", GuildDonateLog),
	}
)

//  升级技能

WorldGuildUpgradeSkill = descriptor.def_message("WorldGuildUpgradeSkill", 601931, 
	{
		//  技能id

		descriptor.def_scalar_field("skillId", descriptor.type_uint16, 0),
	}
)

//  解散公会

WorldGuildDismissReq = descriptor.def_message("WorldGuildDismissReq", 601932, 
	{
	}
)

//  取消解散公会

WorldGuildCancelDismissReq = descriptor.def_message("WorldGuildCancelDismissReq", 601933, 
	{
	}
)

//  请求会长信息

WorldGuildLeaderInfoReq = descriptor.def_message("WorldGuildLeaderInfoReq", 601934, 
	{
	}
)

//  返回会长信息

WorldGuildLeaderInfoRes = descriptor.def_message("WorldGuildLeaderInfoRes", 601935, 
	{
		descriptor.def_message_field("info", GuildLeaderInfo),
	}
)

//  请求膜拜

WorldGuildOrzReq = descriptor.def_message("WorldGuildOrzReq", 601936, 
	{
		//  膜拜类型，对应枚举（GuildOrzType）

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  请求加入圆桌会议

WorldGuildTableJoinReq = descriptor.def_message("WorldGuildTableJoinReq", 601937, 
	{
		//  位置

		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		//  是不是协助

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

//  通知客户端有新的圆桌会议成员

WorldGuildTableNewMember = descriptor.def_message("WorldGuildTableNewMember", 601938, 
	{
		descriptor.def_message_field("member", GuildTableMember),
	}
)

//  通知客户端删除圆桌会议成员

WorldGuildTableDelMember = descriptor.def_message("WorldGuildTableDelMember", 601939, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  通知客户端的圆桌会议完成

WorldGuildTableFinish = descriptor.def_message("WorldGuildTableFinish", 601940, 
	{
	}
)

//  请求发自费红包

WorldGuildPayRedPacketReq = descriptor.def_message("WorldGuildPayRedPacketReq", 601941, 
	{
		//  来源

		descriptor.def_scalar_field("reason", descriptor.type_uint16, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  数量

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  公会兑换

SceneGuildExchangeReq = descriptor.def_message("SceneGuildExchangeReq", 501901, 
	{
	}
)

//  请求公会战报名

WorldGuildBattleReq = descriptor.def_message("WorldGuildBattleReq", 601942, 
	{
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
	}
)

//  请求公会战返回

WorldGuildBattleRes = descriptor.def_message("WorldGuildBattleRes", 601943, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("enrollSize", descriptor.type_uint32, 0),
	}
)

//  请求鼓舞

WorldGuildBattleInspireReq = descriptor.def_message("WorldGuildBattleInspireReq", 601944, 
	{
	}
)

//  鼓舞返回

WorldGuildBattleInspireRes = descriptor.def_message("WorldGuildBattleInspireRes", 601945, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("inspire", descriptor.type_uint8, 0),
	}
)

//  请求领取奖励

WorldGuildBattleReceiveReq = descriptor.def_message("WorldGuildBattleReceiveReq", 601946, 
	{
		descriptor.def_scalar_field("boxId", descriptor.type_uint8, 0),
	}
)

//  领取奖励返回

WorldGuildBattleReceiveRes = descriptor.def_message("WorldGuildBattleReceiveRes", 601947, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("boxId", descriptor.type_uint8, 0),
	}
)

//  请求领地战斗记录

WorldGuildBattleRecordReq = descriptor.def_message("WorldGuildBattleRecordReq", 601948, 
	{
		descriptor.def_scalar_field("isSelf", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("startIndex", descriptor.type_int32, 0),
		descriptor.def_scalar_field("count", descriptor.type_uint32, 0),
	}
)

//  领地战斗记录返回

WorldGuildBattleRecordRes = descriptor.def_message("WorldGuildBattleRecordRes", 601949, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("records", GuildBattleRecord),
	}
)

//  领地战斗记录同步

WorldGuildBattleRecordSync = descriptor.def_message("WorldGuildBattleRecordSync", 601950, 
	{
		descriptor.def_message_field("record", GuildBattleRecord),
	}
)

//  请求领地信息

WorldGuildBattleTerritoryReq = descriptor.def_message("WorldGuildBattleTerritoryReq", 601951, 
	{
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
	}
)

//  返回领地信息

WorldGuildBattleTerritoryRes = descriptor.def_message("WorldGuildBattleTerritoryRes", 601952, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_message_field("info", GuildTerritoryBaseInfo),
	}
)

//  单次战斗结束

WorldGuildBattleRaceEnd = descriptor.def_message("WorldGuildBattleRaceEnd", 601953, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("oldScore", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("newScore", descriptor.type_uint32, 0),
	}
)

//  公会战结束

WorldGuildBattleEnd = descriptor.def_message("WorldGuildBattleEnd", 601954, 
	{
		descriptor.def_message_vector_field("info", GuildBattleEndInfo),
	}
)

//  请求自身公会排行

WorldGuildBattleSelfSortListReq = descriptor.def_message("WorldGuildBattleSelfSortListReq", 601955, 
	{
	}
)

//  请求自身公会排行响应

WorldGuildBattleSelfSortListRes = descriptor.def_message("WorldGuildBattleSelfSortListRes", 601956, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("memberRanking", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("guildRanking", descriptor.type_uint32, 0),
	}
)

//  公会邀请通知，有别的玩家邀请加入公会

WorldGuildInviteNotify = descriptor.def_message("WorldGuildInviteNotify", 601957, 
	{
		//  邀请者ID

		descriptor.def_scalar_field("inviterId", descriptor.type_uint64, 0),
		//  邀请者名字

		descriptor.def_scalar_field("inviterName", descriptor.type_string, ""),
		//  公会ID

		descriptor.def_scalar_field("guildId", descriptor.type_uint64, 0),
		//  公会名

		descriptor.def_scalar_field("guildName", descriptor.type_string, ""),
	}
)

//  同步公会战状态

WorldGuildBattleStatusSync = descriptor.def_message("WorldGuildBattleStatusSync", 601958, 
	{
		//  类型

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  状态

		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
		//  状态存在时间

		descriptor.def_scalar_field("time", descriptor.type_uint32, 0),
		//  公会战结束信息

		descriptor.def_message_vector_field("endInfo", GuildBattleEndInfo),
	}
)

//  请求公会宣战报名

WorldGuildChallengeReq = descriptor.def_message("WorldGuildChallengeReq", 601959, 
	{
		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("itemId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("itemNum", descriptor.type_uint32, 0),
	}
)

//  返回公会宣战报名

WorldGuildChallengeRes = descriptor.def_message("WorldGuildChallengeRes", 601960, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求公会宣战信息

WorldGuildChallengeInfoReq = descriptor.def_message("WorldGuildChallengeInfoReq", 601961, 
	{
	}
)

//  公会宣战信息同步

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

//  请求公会战鼓舞信息

WorldGuildBattleInspireInfoReq = descriptor.def_message("WorldGuildBattleInspireInfoReq", 601963, 
	{
	}
)

//  返回公会战鼓舞信息

WorldGuildBattleInspireInfoRes = descriptor.def_message("WorldGuildBattleInspireInfoRes", 601964, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  领地ID

		descriptor.def_scalar_field("terrId", descriptor.type_uint8, 0),
		//  鼓舞信息

		descriptor.def_message_vector_field("inspireInfos", GuildBattleInspireInfo),
	}
)

//  请求公会仓库设置

WorldGuildStorageSettingReq = descriptor.def_message("WorldGuildStorageSettingReq", 601965, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("value", descriptor.type_uint32, 0),
	}
)

//  返回公会仓库设置

WorldGuildStorageSettingRes = descriptor.def_message("WorldGuildStorageSettingRes", 601966, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求公会战抽奖

WorldGuildBattleLotteryReq = descriptor.def_message("WorldGuildBattleLotteryReq", 601967, 
	{
	}
)

//  返回公会战抽奖

WorldGuildBattleLotteryRes = descriptor.def_message("WorldGuildBattleLotteryRes", 601968, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("contribution", descriptor.type_uint32, 0),
	}
)

//  请求公会仓库列表

WorldGuildStorageListReq = descriptor.def_message("WorldGuildStorageListReq", 601969, 
	{
	}
)

//  返回公会仓库列表

WorldGuildStorageListRes = descriptor.def_message("WorldGuildStorageListRes", 601970, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("maxSize", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
		descriptor.def_message_vector_field("itemRecords", GuildStorageOpRecord),
	}
)

//  同步仓库物品数据

WorldGuildStorageItemSync = descriptor.def_message("WorldGuildStorageItemSync", 601971, 
	{
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
		descriptor.def_message_vector_field("records", GuildStorageOpRecord),
	}
)

//  请求放入公会仓库

WorldGuildAddStorageReq = descriptor.def_message("WorldGuildAddStorageReq", 601972, 
	{
		descriptor.def_message_vector_field("items", GuildStorageItemInfo),
	}
)

//  返回放入公会仓库

WorldGuildAddStorageRes = descriptor.def_message("WorldGuildAddStorageRes", 601973, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求删除公会仓库物品

WorldGuildDelStorageReq = descriptor.def_message("WorldGuildDelStorageReq", 601974, 
	{
		descriptor.def_message_vector_field("items", GuildStorageDelItemInfo),
	}
)

//  返回删除公会仓库物品

WorldGuildDelStorageRes = descriptor.def_message("WorldGuildDelStorageRes", 601975, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  查看仓库物品详情

WorldWatchGuildStorageItemReq = descriptor.def_message("WorldWatchGuildStorageItemReq", 601976, 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
	}
)

