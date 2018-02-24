local descriptor = require "descriptor"

module "ProtocolActivity"

//  活动状态

StateType = descriptor.def_enum("StateType",
	{
		//  结束

		descriptor.def_enum_value("End", 0),
		//  进行中

		descriptor.def_enum_value("Running", 1),
		//  准备中

		descriptor.def_enum_value("Ready", 2),
	}
)

//  通知类型

NotifyType = descriptor.def_enum("NotifyType",
	{
		descriptor.def_enum_value("NT_NONE", 0),
		//  公会战

		descriptor.def_enum_value("NT_GUILD_BATTLE", 1),
		//  武道大会 		

		descriptor.def_enum_value("NT_BUDO", 2),
		// 罐子开放				

		descriptor.def_enum_value("NT_JAR_OPEN", 3),
		// 罐子折扣重置			

		descriptor.def_enum_value("NT_JAR_SALE_RESET", 4),
		descriptor.def_enum_value("NT_MAX", 5),
	}
)

ActivityInfo = descriptor.def_struct("ActivityInfo", 
	{
		// 状态，0 结束, 1 进行中，2 准备中

		descriptor.def_scalar_field("state", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		// 活动名

		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		// 需要等级

		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		// 准备时间

		descriptor.def_scalar_field("preTime", descriptor.type_uint32, 0),
		// 开始时间

		descriptor.def_scalar_field("startTime", descriptor.type_uint32, 0),
		// 到期时间

		descriptor.def_scalar_field("dueTime", descriptor.type_uint32, 0),
	}
)

TaskPair = descriptor.def_struct("TaskPair", 
	{
		descriptor.def_scalar_field("key", descriptor.type_string, ""),
		descriptor.def_scalar_field("value", descriptor.type_string, ""),
	}
)

TaskBriefInfo = descriptor.def_struct("TaskBriefInfo", 
	{
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("taskPairs", TaskPair),
	}
)

//  server->client 同步客户端活动状态

WorldNotifyClientActivity = descriptor.def_message("WorldNotifyClientActivity", 602901, 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint8, 0),
		// 0.结束，1.开始，2.准备

		descriptor.def_scalar_field("id", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("name", descriptor.type_string, ""),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("preTime", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("startTime", descriptor.type_uint32, 0),
		// 开始时间

		descriptor.def_scalar_field("dueTime", descriptor.type_uint32, 0),
	}
)

// 截止时间

//  server->client 同步活动数据

SceneSyncClientActivities = descriptor.def_message("SceneSyncClientActivities", 501136, 
	{
		descriptor.def_message_vector_field("activities", ActivityInfo),
	}
)

// 同步活动任务状态

SceneNotifyActiveTaskStatus = descriptor.def_message("SceneNotifyActiveTaskStatus", 501127, 
	{
		descriptor.def_scalar_field("taskId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
	}
)

// 同步活动任务变量更新

SceneNotifyActiveTaskVar = descriptor.def_message("SceneNotifyActiveTaskVar", 501128, 
	{
		descriptor.def_scalar_field("taskId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("key", descriptor.type_string, ""),
		descriptor.def_scalar_field("val", descriptor.type_string, ""),
	}
)

// 同步活动任务列表

SceneSyncActiveTaskList = descriptor.def_message("SceneSyncActiveTaskList", 501129, 
	{
		descriptor.def_message_vector_field("tasks", TaskBriefInfo),
	}
)

// 提交活动任务

SceneActiveTaskSubmit = descriptor.def_message("SceneActiveTaskSubmit", 501130, 
	{
		descriptor.def_scalar_field("taskId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("param1", descriptor.type_uint32, 0),
	}
)

// 补签

SceneActiveTaskSubmitRp = descriptor.def_message("SceneActiveTaskSubmitRp", 501131, 
	{
		descriptor.def_scalar_vector_field("taskId", descriptor.type_uint32, 0),
	}
)

// 查询七日活动剩余时间

SceneActiveRestTimeReq = descriptor.def_message("SceneActiveRestTimeReq", 501138, 
	{
	}
)

// 查询七日活动剩余时间返回

SceneActiveRestTimeRet = descriptor.def_message("SceneActiveRestTimeRet", 501137, 
	{
		descriptor.def_scalar_field("time1", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("time2", descriptor.type_uint32, 0),
	}
)

// 更新阶段礼包状态

SceneSyncPhaseGift = descriptor.def_message("SceneSyncPhaseGift", 501141, 
	{
		descriptor.def_scalar_field("giftId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("canTake", descriptor.type_uint8, 0),
	}
)

// 1.可领取, 0.未完成

// 领取阶段礼包

SceneTakePhaseGift = descriptor.def_message("SceneTakePhaseGift", 501142, 
	{
		descriptor.def_scalar_field("giftId", descriptor.type_uint32, 0),
	}
)

NotifyInfo = descriptor.def_struct("NotifyInfo", 
	{
		descriptor.def_scalar_field("type", descriptor.type_uint32, 0),
		// 通知类型

		descriptor.def_scalar_field("param", descriptor.type_uint32, 0),
	}
)

// 通知参数

// 初始化通知列表

SceneInitNotifyList = descriptor.def_message("SceneInitNotifyList", 501153, 
	{
		descriptor.def_message_vector_field("notifys", NotifyInfo),
	}
)

// 更新通知列表

SceneUpdateNotifyList = descriptor.def_message("SceneUpdateNotifyList", 501154, 
	{
		descriptor.def_message_field("notify", NotifyInfo),
	}
)

// 请求删除通知

SceneDeleteNotifyList = descriptor.def_message("SceneDeleteNotifyList", 501155, 
	{
		descriptor.def_message_field("notify", NotifyInfo),
	}
)

