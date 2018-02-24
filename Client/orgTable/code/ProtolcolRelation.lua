local descriptor = require "descriptor"
local ProtocolRetinue = require "ProtocolRetinue"
local ProtocolMatch = require "ProtocolMatch"
local ProtocolPet = require "ProtocolPet"

module "ProtolcolRelation"

// 同步关系数据

// 格式 type(UInt8) + id(ObjID_t) + data

WorldSyncRelationData = descriptor.def_message("WorldSyncRelationData", 601707, 
	{
	}
)

// 上线同步关系列表

// datalist格式: type(UInt8) + ObjID_t + isOnline(UInt8) + data + .. + 0(ObjID_t)

WorldSyncRelationList = descriptor.def_message("WorldSyncRelationList", 601708, 
	{
	}
)

// 新关系同步

WorldNotifyNewRelation = descriptor.def_message("WorldNotifyNewRelation", 601705, 
	{
	}
)

// 删除关系同步

WorldNotifyDelRelation = descriptor.def_message("WorldNotifyDelRelation", 601706, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

// 查询推荐好友列表

WorldRelationFindPlayersReq = descriptor.def_message("WorldRelationFindPlayersReq", 601709, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
	}
)

// 1.推荐好友; 2.附近组队

// 快捷加好友结构

QuickFriendInfo = descriptor.def_struct("QuickFriendInfo", 
	{
		// 玩家id

		descriptor.def_scalar_field("playerId", descriptor.type_uint64, 0),
		// 姓名

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// 职业

		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		// 性别

		descriptor.def_scalar_field("seasonLv", descriptor.type_uint32, 0),
		// 等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// vip等级

		descriptor.def_scalar_field("vipLv", descriptor.type_uint8, 0),
	}
)

// 查询推荐好友列表

WorldRelationFindPlayersRet = descriptor.def_message("WorldRelationFindPlayersRet", 601710, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("friendList", QuickFriendInfo),
	}
)

// 删除关系

WorldRemoveRelation = descriptor.def_message("WorldRemoveRelation", 601704, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
	}
)

//  查询玩家信息（可根据角色ID和名字查询，优先使用角色ID）

WorldQueryPlayerReq = descriptor.def_message("WorldQueryPlayerReq", 601701, 
	{
		//  角色ID

		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
	}
)

//  查询玩家详细信息（可根据角色ID和名字查询，优先使用角色ID）

WorldQueryPlayerDetailsReq = descriptor.def_message("WorldQueryPlayerDetailsReq", 601722, 
	{
		//  角色ID

		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
	}
)

//  物品基本信息

ItemBaseInfo = descriptor.def_struct("ItemBaseInfo", 
	{
		//  唯一ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  类型ID

		descriptor.def_scalar_field("typeId", descriptor.type_uint32, 0),
		//  位置

		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		//  强化

		descriptor.def_scalar_field("strengthen", descriptor.type_uint8, 0),
	}
)

//  Pk信息

PkStatisticInfo = descriptor.def_struct("PkStatisticInfo", 
	{
		//  胜场数

		descriptor.def_scalar_field("totalWinNum", descriptor.type_uint32, 0),
		//  负场数

		descriptor.def_scalar_field("totalLoseNum", descriptor.type_uint32, 0),
		//  总场数

		descriptor.def_scalar_field("totalNum", descriptor.type_uint32, 0),
	}
)

//  公会称号

GuildTitle = descriptor.def_struct("GuildTitle", 
	{
		//  公会名

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  职务

		descriptor.def_scalar_field("post", descriptor.type_uint8, 0),
	}
)

//  查看玩家的信息

PlayerWatchInfo = descriptor.def_struct("PlayerWatchInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("occu", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_message_vector_field("equips", ItemBaseInfo),
		descriptor.def_message_vector_field("fashionEquips", ItemBaseInfo),
		descriptor.def_message_field("retinue", ProtocolRetinue.RetinueInfo),
		descriptor.def_message_field("pkInfo", PkStatisticInfo),
		descriptor.def_scalar_field("pkValue", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("matchScore", descriptor.type_uint32, 0),
		//  vip等级

		descriptor.def_scalar_field("vipLevel", descriptor.type_uint8, 0),
		//  公会称号

		descriptor.def_message_field("guildTitle", GuildTitle),
		//  赛季段位等级

		descriptor.def_scalar_field("seasonLevel", descriptor.type_uint32, 0),
		//  赛季段位星级

		descriptor.def_scalar_field("seasonStar", descriptor.type_uint32, 0),
		//  宠物

		descriptor.def_message_vector_field("pets", ProtocolPet.PetBaseInfo),
	}
)

//  返回玩家信息

WorldQueryPlayerRet = descriptor.def_message("WorldQueryPlayerRet", 601702, 
	{
		descriptor.def_message_field("info", PlayerWatchInfo),
	}
)

//  返回玩家信息

WorldQueryPlayerDetailsRet = descriptor.def_message("WorldQueryPlayerDetailsRet", 601723, 
	{
		descriptor.def_message_field("info", ProtocolMatch.RacePlayerInfo),
	}
)

// 好友赠送

WorldRelationPresentGiveReq = descriptor.def_message("WorldRelationPresentGiveReq", 601711, 
	{
		descriptor.def_scalar_field("friendUID", descriptor.type_uint64, 0),
	}
)

// 同步上下线状态

WorldSyncOnOffline = descriptor.def_message("WorldSyncOnOffline", 601713, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("isOnline", descriptor.type_uint8, 0),
	}
)

// 更新关系

WorldUpdateRelation = descriptor.def_message("WorldUpdateRelation", 601712, 
	{
	}
)

// 加黑名单

WorldAddToBlackList = descriptor.def_message("WorldAddToBlackList", 601703, 
	{
		descriptor.def_scalar_field("tarUid", descriptor.type_uint64, 0),
	}
)

//  玩家在线状态

PlayerOnline = descriptor.def_struct("PlayerOnline", 
	{
		descriptor.def_scalar_field("uid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("online", descriptor.type_uint8, 0),
	}
)

// clt->svr更新聊天玩家的在线信息

WorldUpdatePlayerOnlineReq = descriptor.def_message("WorldUpdatePlayerOnlineReq", 601714, 
	{
		descriptor.def_scalar_vector_field("uids", descriptor.type_uint64, 0),
	}
)

// svr->clt更新聊天玩家的在线信息

WorldUpdatePlayerOnlineRes = descriptor.def_message("WorldUpdatePlayerOnlineRes", 601715, 
	{
		descriptor.def_message_vector_field("playerStates", PlayerOnline),
	}
)

