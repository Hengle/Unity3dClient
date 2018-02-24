local descriptor = require "descriptor"

module "ProtocolRelayServer"

//  ��������֡����

FrameCommandID = descriptor.def_enum("FrameCommandID",
	{
		//  ս����ʼ

		descriptor.def_enum_value("GameStart", 0),
		//  �ƶ�

		descriptor.def_enum_value("Move", 1),
		//  ֹͣ

		descriptor.def_enum_value("Stop", 2),
		//  �ż���

		descriptor.def_enum_value("Skill", 3),
		//  ����뿪ս��

		descriptor.def_enum_value("Leave", 4),
		//  ��Ҹ���

		descriptor.def_enum_value("Reborn", 5),
		//  ��ʼ����

		descriptor.def_enum_value("ReconnectBegin", 6),
		//  ��������

		descriptor.def_enum_value("ReconnectEnd", 7),
		//  ʹ����Ʒ

		descriptor.def_enum_value("UseItem", 8),
		// ����

		descriptor.def_enum_value("LevelChange", 9),
		// �Զ�ս��

		descriptor.def_enum_value("AutoFight", 10),
		// ˫������

		descriptor.def_enum_value("DoublePressConfig", 11),
		//  ����˳�ս��(�������˳�)

		descriptor.def_enum_value("PlayerQuit", 12),
		//  ս������

		descriptor.def_enum_value("RaceEnd", 13),
		//  ��������

		descriptor.def_enum_value("NetQuality", 14),
	}
)

//  ��������ԭ��

RaceEndReason = descriptor.def_enum("RaceEndReason",
	{
		//  �����˳�

		descriptor.def_enum_value("Normal", 0),
		//  ��ս����ʱ�䳬ʱ

		descriptor.def_enum_value("Timeout", 1),
		//  �ȴ���ʼ��ʱ

		descriptor.def_enum_value("LoginTimeout", 2),
		//  �쳣����

		descriptor.def_enum_value("Errro", 3),
		//  ϵͳ��ɢ

		descriptor.def_enum_value("System", 4),
		//  �ȴ�������ʱ

		descriptor.def_enum_value("WaitRaceEndTimeout", 5),
		//  ���ڲ�ս������

		descriptor.def_enum_value("GamerOffline", 6),
		//  ֡У�鳬ʱ

		descriptor.def_enum_value("FrameChecksumTimeout", 7),
		//  ֡У�鲻һ��

		descriptor.def_enum_value("FrameChecksumDifferent", 8),
	}
)

RelaySvrLoginReq = descriptor.def_message("RelaySvrLoginReq", 1300001, 
	{
		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("roleid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
	}
)

RelaySvrLoginRes = descriptor.def_message("RelaySvrLoginRes", 1300002, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("currentTime", descriptor.type_uint64, 0),
	}
)

RelaySvrNotifyGameStart = descriptor.def_message("RelaySvrNotifyGameStart", 1300003, 
	{
		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("startTime", descriptor.type_uint64, 0),
	}
)

_inputData = descriptor.def_struct("_inputData", 
	{
		descriptor.def_scalar_field("sendTime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("data1", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("data2", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("data3", descriptor.type_uint32, 0),
	}
)

_fighterInput = descriptor.def_struct("_fighterInput", 
	{
		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		descriptor.def_message_field("input", _inputData),
	}
)

Frame = descriptor.def_struct("Frame", 
	{
		descriptor.def_scalar_field("sequence", descriptor.type_uint32, 0),
		descriptor.def_message_vector_field("data", _fighterInput),
	}
)

RelaySvrFrameDataNotify = descriptor.def_message("RelaySvrFrameDataNotify", 1300004, 
	{
		descriptor.def_message_vector_field("frames", Frame),
	}
)

RelaySvrPlayerInputReq = descriptor.def_message("RelaySvrPlayerInputReq", 1300005, 
	{
		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("roleid", descriptor.type_uint64, 0),
		descriptor.def_message_field("input", _inputData),
	}
)

FightergResult = descriptor.def_struct("FightergResult", 
	{
		descriptor.def_scalar_field("flag", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("roldid", descriptor.type_uint64, 0),
		// ʣ��Ѫ��(�ٷֱ�)

		descriptor.def_scalar_field("remainHp", descriptor.type_uint32, 0),
		// ʣ��ħ��(�ٷֱ�)

		descriptor.def_scalar_field("remainMp", descriptor.type_uint32, 0),
	}
)

RelaySvrGameResultNotify = descriptor.def_message("RelaySvrGameResultNotify", 1300006, 
	{
		descriptor.def_scalar_field("reason", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
		descriptor.def_message_vector_field("results", FightergResult),
	}
)

//  ���PK����

PkPlayerRaceEndInfo = descriptor.def_struct("PkPlayerRaceEndInfo", 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("remainHp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("remainMp", descriptor.type_uint32, 0),
	}
)

//  pk����

PkRaceEndInfo = descriptor.def_struct("PkRaceEndInfo", 
	{
		descriptor.def_scalar_field("gamesessionId", descriptor.type_uint64, 0),
		// ������ҵĽ�����Ϣ

		descriptor.def_message_vector_field("infoes", PkPlayerRaceEndInfo),
		// ¼������

		descriptor.def_scalar_field("replayScore", descriptor.type_uint32, 0),
	}
)

RelaySvrEndGameReq = descriptor.def_message("RelaySvrEndGameReq", 1300007, 
	{
		descriptor.def_message_field("end", PkRaceEndInfo),
	}
)

DungeonPlayerRaceEndInfo = descriptor.def_struct("DungeonPlayerRaceEndInfo", 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("score", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("beHitCount", descriptor.type_uint16, 0),
	}
)

DungeonRaceEndInfo = descriptor.def_struct("DungeonRaceEndInfo", 
	{
		descriptor.def_scalar_field("sessionId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("dungeonId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("usedTime", descriptor.type_uint32, 0),
		//  ����ҵĽ�����Ϣ

		descriptor.def_message_vector_field("infoes", DungeonPlayerRaceEndInfo),
	}
)

//  ���³ǽ���

RelaySvrDungeonRaceEndReq = descriptor.def_message("RelaySvrDungeonRaceEndReq", 1300008, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_message_field("raceEndInfo", DungeonRaceEndInfo),
	}
)

//  ֪ͨ��������

RelaySvrRaceEndNotify = descriptor.def_message("RelaySvrRaceEndNotify", 1300009, 
	{
		//  ����ԭ�򣨶�Ӧö��RaceEndReason��

		descriptor.def_scalar_field("reason", descriptor.type_uint8, 0),
	}
)

//  �ϱ�����У������

RelaySvrFrameChecksumRequest = descriptor.def_message("RelaySvrFrameChecksumRequest", 1300011, 
	{
		//  ֡���

		descriptor.def_scalar_field("frame", descriptor.type_uint32, 0),
		//  ֡У��ֵ

		descriptor.def_scalar_field("checksum", descriptor.type_uint32, 0),
	}
)

//  ��������

RelaySvrReconnectReq = descriptor.def_message("RelaySvrReconnectReq", 1300012, 
	{
		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("roleid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("lastFrame", descriptor.type_uint64, 0),
	}
)

//  ��������

RelaySvrReconnectRes = descriptor.def_message("RelaySvrReconnectRes", 1300013, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  ����֡����

RelaySvrReconnectFrameData = descriptor.def_message("RelaySvrReconnectFrameData", 1300014, 
	{
		descriptor.def_scalar_field("finish", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("frames", Frame),
	}
)

//  �ϱ����ؽ���

RelaySvrReportLoadProgress = descriptor.def_message("RelaySvrReportLoadProgress", 1300015, 
	{
		//  ���ؽ���

		descriptor.def_scalar_field("progress", descriptor.type_uint8, 0),
	}
)

//  ֪ͨ���ؽ���

RelaySvrNotifyLoadProgress = descriptor.def_message("RelaySvrNotifyLoadProgress", 1300016, 
	{
		//  ��λ��

		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		//  ���ؽ���

		descriptor.def_scalar_field("progress", descriptor.type_uint8, 0),
	}
)

