local descriptor = require "descriptor"
local Protocol = require "Protocol"
local ProtocolBase = require "ProtocolBase"

module "ProtocolRedPacket"

RedPacketType = descriptor.def_enum("RedPacketType",
	{
		//  ������

		descriptor.def_enum_value("GUILD", 1),
	}
)

//  ���״̬

RedPacketStatus = descriptor.def_enum("RedPacketStatus",
	{
		//  ��ʼ״̬

		descriptor.def_enum_value("INIT", 0),
		//  �ȴ�������ȡ���

		descriptor.def_enum_value("WAIT_RECEIVE", 1),
		//  �ѱ�����

		descriptor.def_enum_value("EMPTY", 2),
		//  �ɴݻ�

		descriptor.def_enum_value("DESTORY", 3),
	}
)

//  ���������Ϣ

RedPacketBaseEntry = descriptor.def_struct("RedPacketBaseEntry", 
	{
		//  ���ID

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ����

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		//  ������ID

		descriptor.def_scalar_field("ownerId", descriptor.type_uint64, 0),
		//  ����������

		descriptor.def_scalar_field("ownerName", descriptor.type_string, ""),
		//  ״̬����Ӧö��RedPacketStatus��

		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
		//  ��û�д򿪹�

		descriptor.def_scalar_field("opened", descriptor.type_uint8, 0),
		//  �������(��Ӧö��RedPacketType)

		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		//  �����Դ

		descriptor.def_scalar_field("reason", descriptor.type_uint16, 0),
		//  ������

		descriptor.def_scalar_field("totalMoney", descriptor.type_uint32, 0),
		//  �������

		descriptor.def_scalar_field("totalNum", descriptor.type_uint8, 0),
	}
)

//  �����ȡ����Ϣ

RedPacketReceiverEntry = descriptor.def_struct("RedPacketReceiverEntry", 
	{
		//  icon

		descriptor.def_message_field("icon", ProtocolBase.PlayerIcon),
		//  ��ý��

		descriptor.def_scalar_field("money", descriptor.type_uint32, 0),
	}
)

//  �����ϸ��Ϣ

RedPacketDetail = descriptor.def_struct("RedPacketDetail", 
	{
		//  ������Ϣ

		descriptor.def_message_field("baseEntry", RedPacketBaseEntry),
		//  ӵ����ͷ��

		descriptor.def_message_field("ownerIcon", ProtocolBase.PlayerIcon),
		//  ������ȡ�����

		descriptor.def_message_vector_field("receivers", RedPacketReceiverEntry),
	}
)

//  ��¼ʱͬ�����������Ϣ

WorldSyncRedPacket = descriptor.def_message("WorldSyncRedPacket", 607301, 
	{
		//  ���������Ϣ

		descriptor.def_message_vector_field("entrys", RedPacketBaseEntry),
	}
)

//  ֪ͨ����º��

WorldNotifyGotNewRedPacket = descriptor.def_message("WorldNotifyGotNewRedPacket", 607302, 
	{
		//  ���������Ϣ

		descriptor.def_message_field("entry", RedPacketBaseEntry),
	}
)

//  ֪ͨ���º������

WorldNotifyNewRedPacket = descriptor.def_message("WorldNotifyNewRedPacket", 607303, 
	{
		//  ���������Ϣ

		descriptor.def_message_vector_field("entry", RedPacketBaseEntry),
	}
)

//  ֪ͨɾ�����

WorldNotifyDelRedPacket = descriptor.def_message("WorldNotifyDelRedPacket", 607304, 
	{
		//  ��Ҫɾ���ĺ��ID

		descriptor.def_scalar_vector_field("redPacketList", descriptor.type_uint64, 0),
	}
)

//  ֪ͨ�޸ĺ��״̬

WorldNotifySyncRedPacketStatus = descriptor.def_message("WorldNotifySyncRedPacketStatus", 607305, 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  ״̬(��Ӧö��RedPacketStatus)

		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
	}
)

//  ���󷢺��

WorldSendRedPacketReq = descriptor.def_message("WorldSendRedPacketReq", 607306, 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		//  �������

		descriptor.def_scalar_field("num", descriptor.type_uint8, 0),
	}
)

//  ���������

WorldSendRedPacketRes = descriptor.def_message("WorldSendRedPacketRes", 607307, 
	{
		//  ������

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ����򿪺��(����Ѿ��򿪹��ˣ��Ǿ��ǲ鿴)

WorldOpenRedPacketReq = descriptor.def_message("WorldOpenRedPacketReq", 607308, 
	{
		//  id

		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

//  ���ش򿪺������

WorldOpenRedPacketRes = descriptor.def_message("WorldOpenRedPacketRes", 607309, 
	{
		//  ������

		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		//  �����ϸ��Ϣ

		descriptor.def_message_field("detail", RedPacketDetail),
	}
)

