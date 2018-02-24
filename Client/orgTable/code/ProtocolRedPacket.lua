local descriptor = require "descriptor"
local Protocol = require "Protocol"
local ProtocolBase = require "ProtocolBase"

module "ProtocolRedPacket"

RedPacketType = descriptor.def_enum("RedPacketType",
	{
		//  公会红包

		descriptor.def_enum_value("GUILD", 1),
	}
)

//  红包状态

RedPacketStatus = descriptor.def_enum("RedPacketStatus",
	{
		//  初始状态

		descriptor.def_enum_value("INIT", 0),
		//  等待别人领取红包

		descriptor.def_enum_value("WAIT_RECEIVE", 1),
		//  已被领完

		descriptor.def_enum_value("EMPTY", 2),
		//  可摧毁

		descriptor.def_enum_value("DESTORY", 3),
	}
)

//  红包基础信息

RedPacketBaseEntry = descriptor.def_struct("RedPacketBaseEntry", 
	{
		//  红包ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  名字

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  发送者ID

		descriptor.def_scalar_field("ownerId", descriptor.type_uint64, 0),
		//  发送者名字

		descriptor.def_scalar_field("ownerName", descriptor.type_string, ""),
		//  状态（对应枚举RedPacketStatus）

		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
		//  有没有打开过

		descriptor.def_scalar_field("opened", descriptor.type_uint8, 0),
		//  红包类型(对应枚举RedPacketType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  红包来源

		descriptor.def_scalar_field("reason", descriptor.type_uint16, 0),
		//  红包金额

		descriptor.def_scalar_field("totalMoney", descriptor.type_uint32, 0),
		//  红包数量

		descriptor.def_scalar_field("totalNum", descriptor.type_uint8, 0),
	}
)

//  红包领取者信息

RedPacketReceiverEntry = descriptor.def_struct("RedPacketReceiverEntry", 
	{
		//  icon

		descriptor.def_message_field("icon", ProtocolBase.PlayerIcon),
		//  获得金额

		descriptor.def_scalar_field("money", descriptor.type_uint32, 0),
	}
)

//  红包详细信息

RedPacketDetail = descriptor.def_struct("RedPacketDetail", 
	{
		//  基础信息

		descriptor.def_message_field("baseEntry", RedPacketBaseEntry),
		//  拥有者头像

		descriptor.def_message_field("ownerIcon", ProtocolBase.PlayerIcon),
		//  所有领取的玩家

		descriptor.def_message_vector_field("receivers", RedPacketReceiverEntry),
	}
)

//  登录时同步红包基础信息

WorldSyncRedPacket = descriptor.def_message("WorldSyncRedPacket", 607301, 
	{
		//  红包基础信息

		descriptor.def_message_vector_field("entrys", RedPacketBaseEntry),
	}
)

//  通知获得新红包

WorldNotifyGotNewRedPacket = descriptor.def_message("WorldNotifyGotNewRedPacket", 607302, 
	{
		//  红包基础信息

		descriptor.def_message_field("entry", RedPacketBaseEntry),
	}
)

//  通知有新红包可领

WorldNotifyNewRedPacket = descriptor.def_message("WorldNotifyNewRedPacket", 607303, 
	{
		//  红包基础信息

		descriptor.def_message_vector_field("entry", RedPacketBaseEntry),
	}
)

//  通知删除红包

WorldNotifyDelRedPacket = descriptor.def_message("WorldNotifyDelRedPacket", 607304, 
	{
		//  需要删除的红包ID

		descriptor.def_scalar_vector_field("redPacketList", descriptor.type_uint64, 0),
	}
)

//  通知修改红包状态

WorldNotifySyncRedPacketStatus = descriptor.def_message("WorldNotifySyncRedPacketStatus", 607305, 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  状态(对应枚举RedPacketStatus)

		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
	}
)

//  请求发红包

WorldSendRedPacketReq = descriptor.def_message("WorldSendRedPacketReq", 607306, 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  红包数量

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  发红包返回

WorldSendRedPacketRes = descriptor.def_message("WorldSendRedPacketRes", 607307, 
	{
		//  返回码

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  请求打开红包(如果已经打开过了，那就是查看)

WorldOpenRedPacketReq = descriptor.def_message("WorldOpenRedPacketReq", 607308, 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  返回打开红包请求

WorldOpenRedPacketRes = descriptor.def_message("WorldOpenRedPacketRes", 607309, 
	{
		//  返回码

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  红包详细信息

		descriptor.def_message_field("detail", RedPacketDetail),
	}
)

