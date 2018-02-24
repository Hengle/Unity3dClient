local descriptor = require "descriptor"

module "ProtocolRelayServer"

//  单局命令帧类型

FrameCommandID = descriptor.def_enum("FrameCommandID",
	{
		//  战斗开始

		descriptor.def_enum_value("GameStart", 0),
		//  移动

		descriptor.def_enum_value("Move", 1),
		//  停止

		descriptor.def_enum_value("Stop", 2),
		//  放技能

		descriptor.def_enum_value("Skill", 3),
		//  玩家离开战斗

		descriptor.def_enum_value("Leave", 4),
		//  玩家复活

		descriptor.def_enum_value("Reborn", 5),
		//  开始重连

		descriptor.def_enum_value("ReconnectBegin", 6),
		//  重连结束

		descriptor.def_enum_value("ReconnectEnd", 7),
		//  使用物品

		descriptor.def_enum_value("UseItem", 8),
		// 升级

		descriptor.def_enum_value("LevelChange", 9),
		// 自动战斗

		descriptor.def_enum_value("AutoFight", 10),
		// 双击配置

		descriptor.def_enum_value("DoublePressConfig", 11),
		//  玩家退出战斗(真正的退出)

		descriptor.def_enum_value("PlayerQuit", 12),
		//  战斗结束

		descriptor.def_enum_value("RaceEnd", 13),
		//  网络质量

		descriptor.def_enum_value("NetQuality", 14),
	}
)

//  比赛结束原因

RaceEndReason = descriptor.def_enum("RaceEndReason",
	{
		//  正常退出

		descriptor.def_enum_value("Normal", 0),
		//  对战持续时间超时

		descriptor.def_enum_value("Timeout", 1),
		//  等待开始超时

		descriptor.def_enum_value("LoginTimeout", 2),
		//  异常结束

		descriptor.def_enum_value("Errro", 3),
		//  系统解散

		descriptor.def_enum_value("System", 4),
		//  等待结束超时

		descriptor.def_enum_value("WaitRaceEndTimeout", 5),
		//  由于参战方离线

		descriptor.def_enum_value("GamerOffline", 6),
		//  帧校验超时

		descriptor.def_enum_value("FrameChecksumTimeout", 7),
		//  帧校验不一致

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
		// 剩余血量(百分比)

		descriptor.def_scalar_field("remainHp", descriptor.type_uint32, 0),
		// 剩余魔量(百分比)

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

//  玩家PK结算

PkPlayerRaceEndInfo = descriptor.def_struct("PkPlayerRaceEndInfo", 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("result", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("remainHp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("remainMp", descriptor.type_uint32, 0),
	}
)

//  pk结算

PkRaceEndInfo = descriptor.def_struct("PkRaceEndInfo", 
	{
		descriptor.def_scalar_field("gamesessionId", descriptor.type_uint64, 0),
		// 所有玩家的结算信息

		descriptor.def_message_vector_field("infoes", PkPlayerRaceEndInfo),
		// 录像评分

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
		//  各玩家的结算信息

		descriptor.def_message_vector_field("infoes", DungeonPlayerRaceEndInfo),
	}
)

//  地下城结算

RelaySvrDungeonRaceEndReq = descriptor.def_message("RelaySvrDungeonRaceEndReq", 1300008, 
	{
		descriptor.def_scalar_field("roleId", descriptor.type_uint64, 0),
		descriptor.def_message_field("raceEndInfo", DungeonRaceEndInfo),
	}
)

//  通知比赛结束

RelaySvrRaceEndNotify = descriptor.def_message("RelaySvrRaceEndNotify", 1300009, 
	{
		//  结束原因（对应枚举RaceEndReason）

		descriptor.def_scalar_field("reason", descriptor.type_uint8, 0),
	}
)

//  上报单局校验数据

RelaySvrFrameChecksumRequest = descriptor.def_message("RelaySvrFrameChecksumRequest", 1300011, 
	{
		//  帧序号

		descriptor.def_scalar_field("frame", descriptor.type_uint32, 0),
		//  帧校验值

		descriptor.def_scalar_field("checksum", descriptor.type_uint32, 0),
	}
)

//  请求重连

RelaySvrReconnectReq = descriptor.def_message("RelaySvrReconnectReq", 1300012, 
	{
		descriptor.def_scalar_field("seat", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("accid", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("roleid", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("session", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("lastFrame", descriptor.type_uint64, 0),
	}
)

//  重连返回

RelaySvrReconnectRes = descriptor.def_message("RelaySvrReconnectRes", 1300013, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

//  重连帧数据

RelaySvrReconnectFrameData = descriptor.def_message("RelaySvrReconnectFrameData", 1300014, 
	{
		descriptor.def_scalar_field("finish", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("frames", Frame),
	}
)

//  上报加载进度

RelaySvrReportLoadProgress = descriptor.def_message("RelaySvrReportLoadProgress", 1300015, 
	{
		//  加载进度

		descriptor.def_scalar_field("progress", descriptor.type_uint8, 0),
	}
)

//  通知加载进度

RelaySvrNotifyLoadProgress = descriptor.def_message("RelaySvrNotifyLoadProgress", 1300016, 
	{
		//  座位号

		descriptor.def_scalar_field("pos", descriptor.type_uint8, 0),
		//  加载进度

		descriptor.def_scalar_field("progress", descriptor.type_uint8, 0),
	}
)

