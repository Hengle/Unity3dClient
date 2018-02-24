local descriptor = require "descriptor"

module "ProtolcolMission"

TaskPublishType = descriptor.def_enum("TaskPublishType",
	{
		descriptor.def_enum_value("TASK_PUBLISH_NPC", 0),
		descriptor.def_enum_value("TASK_PUBLISH_UI", 1),
		descriptor.def_enum_value("TASK_PUBLISH_CITY", 2),
	}
)

TaskSubmitType = descriptor.def_enum("TaskSubmitType",
	{
		descriptor.def_enum_value("TASK_SUBMIT_AUTO", 0),
		descriptor.def_enum_value("TASK_SUBMIT_NPC", 1),
		descriptor.def_enum_value("TASK_SUBMIT_UI", 2),
	}
)

TaskStatus = descriptor.def_enum("TaskStatus",
	{
		descriptor.def_enum_value("TASK_INIT", 0),
		descriptor.def_enum_value("TASK_UNFINISH", 1),
		descriptor.def_enum_value("TASK_FINISHED", 2),
		descriptor.def_enum_value("TASK_FAILED", 3),
		descriptor.def_enum_value("TASK_SUBMITTING", 4),
		descriptor.def_enum_value("TASK_OVER", 5),
	}
)

DeleteTaskReason = descriptor.def_enum("DeleteTaskReason",
	{
		descriptor.def_enum_value("DELETE_TASK_REASON_SUBMIT", 1),
		descriptor.def_enum_value("DELETE_TASK_REASON_ABANDON", 2),
		descriptor.def_enum_value("DELETE_TASK_REASON_SYSTEM", 3),
		descriptor.def_enum_value("DELETE_TASK_REASON_OTHER", 4),
	}
)

SceneAcceptTaskReq = descriptor.def_message("SceneAcceptTaskReq", 501103, 
	{
		descriptor.def_scalar_field("acceptType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("npcID", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
	}
)

SceneSubmitTaskReq = descriptor.def_message("SceneSubmitTaskReq", 501104, 
	{
		descriptor.def_scalar_field("submitType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("npcID", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
	}
)

SceneAbandonTaskReq = descriptor.def_message("SceneAbandonTaskReq", 501105, 
	{
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
	}
)

MissionPair = descriptor.def_struct("MissionPair", 
	{
		descriptor.def_scalar_field("key", descriptor.type_string, ""),
		descriptor.def_scalar_field("value", descriptor.type_string, ""),
	}
)

MissionInfo = descriptor.def_struct("MissionInfo", 
	{
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
		descriptor.def_message_vector_field("akMissionPairs", MissionPair),
	}
)

SceneTaskListRet = descriptor.def_message("SceneTaskListRet", 501106, 
	{
		descriptor.def_message_vector_field("tasks", MissionInfo),
	}
)

SceneNotifyNewTaskRet = descriptor.def_message("SceneNotifyNewTaskRet", 501107, 
	{
		descriptor.def_message_field("taskInfo", MissionInfo),
	}
)

SceneNotifyDeleteTaskRet = descriptor.def_message("SceneNotifyDeleteTaskRet", 501108, 
	{
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("reasion", descriptor.type_uint8, 0),
	}
)

SceneNotifyTaskStatusRet = descriptor.def_message("SceneNotifyTaskStatusRet", 501109, 
	{
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("status", descriptor.type_uint8, 0),
	}
)

SceneNotifyTaskVarRet = descriptor.def_message("SceneNotifyTaskVarRet", 501110, 
	{
		descriptor.def_scalar_field("taskID", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("key", descriptor.type_string, ""),
		descriptor.def_scalar_field("value", descriptor.type_string, ""),
	}
)

SceneSubmitDailyTask = descriptor.def_message("SceneSubmitDailyTask", 501124, 
	{
		descriptor.def_scalar_field("taskId", descriptor.type_uint32, 0),
	}
)

SceneDailyTaskList = descriptor.def_message("SceneDailyTaskList", 501123, 
	{
		descriptor.def_message_vector_field("tasks", MissionInfo),
	}
)

SceneSubmitAchievementTask = descriptor.def_message("SceneSubmitAchievementTask", 501126, 
	{
		descriptor.def_scalar_field("taskId", descriptor.type_uint32, 0),
	}
)

SceneAchievementTaskList = descriptor.def_message("SceneAchievementTaskList", 501125, 
	{
		descriptor.def_message_vector_field("tasks", MissionInfo),
	}
)

SceneSubmitAllDailyTask = descriptor.def_message("SceneSubmitAllDailyTask", 501132, 
	{
	}
)

SceneSetTaskItemReq = descriptor.def_message("SceneSetTaskItemReq", 501133, 
	{
		descriptor.def_scalar_field("taskId", descriptor.type_uint32, 0),
		descriptor.def_scalar_vector_field("itemIds", descriptor.type_uint64, 0),
	}
)

SceneSetTaskItemRes = descriptor.def_message("SceneSetTaskItemRes", 501134, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneRefreshCycleTask = descriptor.def_message("SceneRefreshCycleTask", 501135, 
	{
	}
)

SceneDailyScoreRewardReq = descriptor.def_message("SceneDailyScoreRewardReq", 501139, 
	{
		descriptor.def_scalar_field("boxId", descriptor.type_uint8, 0),
	}
)

SceneDailyScoreRewardRes = descriptor.def_message("SceneDailyScoreRewardRes", 501140, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneLegendTaskListRes = descriptor.def_message("SceneLegendTaskListRes", 501114, 
	{
		descriptor.def_message_vector_field("tasks", MissionInfo),
	}
)

SceneSubmitLegendTask = descriptor.def_message("SceneSubmitLegendTask", 501115, 
	{
		descriptor.def_scalar_field("taskId", descriptor.type_uint32, 0),
	}
)

