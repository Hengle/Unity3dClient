using System;
using System.Text;

namespace Protocol
{
	public enum TaskPublishType
	{
		TASK_PUBLISH_NPC = 0,
		TASK_PUBLISH_UI = 1,
		TASK_PUBLISH_CITY = 2,
	}

	public enum TaskSubmitType
	{
		TASK_SUBMIT_AUTO = 0,
		TASK_SUBMIT_NPC = 1,
		TASK_SUBMIT_UI = 2,
	}

	public enum TaskStatus
	{
		TASK_INIT = 0,
		TASK_UNFINISH = 1,
		TASK_FINISHED = 2,
		TASK_FAILED = 3,
		TASK_SUBMITTING = 4,
		TASK_OVER = 5,
	}

	public enum DeleteTaskReason
	{
		DELETE_TASK_REASON_SUBMIT = 1,
		DELETE_TASK_REASON_ABANDON = 2,
		DELETE_TASK_REASON_SYSTEM = 3,
		DELETE_TASK_REASON_OTHER = 4,
	}

	[Protocol]
	public class SceneAcceptTaskReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501103;
		public byte acceptType;
		public UInt32 npcID;
		public UInt32 taskID;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, acceptType);
				BaseDLL.encode_uint32(buffer, ref pos_, npcID);
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref acceptType);
				BaseDLL.decode_uint32(buffer, ref pos_, ref npcID);
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
			}
		#endregion

	}

	[Protocol]
	public class SceneSubmitTaskReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501104;
		public byte submitType;
		public UInt32 npcID;
		public UInt32 taskID;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, submitType);
				BaseDLL.encode_uint32(buffer, ref pos_, npcID);
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref submitType);
				BaseDLL.decode_uint32(buffer, ref pos_, ref npcID);
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
			}
		#endregion

	}

	[Protocol]
	public class SceneAbandonTaskReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501105;
		public UInt32 taskID;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
			}
		#endregion

	}

	public class MissionPair : Protocol.IProtocolStream
	{
		public string key;
		public string value;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] keyBytes = StringHelper.StringToUTF8Bytes(key);
				BaseDLL.encode_string(buffer, ref pos_, keyBytes, (UInt16)(buffer.Length - pos_));
				byte[] valueBytes = StringHelper.StringToUTF8Bytes(value);
				BaseDLL.encode_string(buffer, ref pos_, valueBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 keyLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref keyLen);
				byte[] keyBytes = new byte[keyLen];
				for(int i = 0; i < keyLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref keyBytes[i]);
				}
				key = StringHelper.BytesToString(keyBytes);
				UInt16 valueLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref valueLen);
				byte[] valueBytes = new byte[valueLen];
				for(int i = 0; i < valueLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref valueBytes[i]);
				}
				value = StringHelper.BytesToString(valueBytes);
			}
		#endregion

	}

	public class MissionInfo : Protocol.IProtocolStream
	{
		public UInt32 taskID;
		public byte status;
		public MissionPair[] akMissionPairs = new MissionPair[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
				BaseDLL.encode_int8(buffer, ref pos_, status);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)akMissionPairs.Length);
				for(int i = 0; i < akMissionPairs.Length; i++)
				{
					akMissionPairs[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
				UInt16 akMissionPairsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref akMissionPairsCnt);
				akMissionPairs = new MissionPair[akMissionPairsCnt];
				for(int i = 0; i < akMissionPairs.Length; i++)
				{
					akMissionPairs[i] = new MissionPair();
					akMissionPairs[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneTaskListRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501106;
		public MissionInfo[] tasks = new MissionInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)tasks.Length);
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 tasksCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref tasksCnt);
				tasks = new MissionInfo[tasksCnt];
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i] = new MissionInfo();
					tasks[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyNewTaskRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501107;
		public MissionInfo taskInfo = new MissionInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				taskInfo.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				taskInfo.decode(buffer, ref pos_);
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyDeleteTaskRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501108;
		public UInt32 taskID;
		public byte reasion;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
				BaseDLL.encode_int8(buffer, ref pos_, reasion);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
				BaseDLL.decode_int8(buffer, ref pos_, ref reasion);
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyTaskStatusRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501109;
		public UInt32 taskID;
		public byte status;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
				BaseDLL.encode_int8(buffer, ref pos_, status);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyTaskVarRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501110;
		public UInt32 taskID;
		public string key;
		public string value;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
				byte[] keyBytes = StringHelper.StringToUTF8Bytes(key);
				BaseDLL.encode_string(buffer, ref pos_, keyBytes, (UInt16)(buffer.Length - pos_));
				byte[] valueBytes = StringHelper.StringToUTF8Bytes(value);
				BaseDLL.encode_string(buffer, ref pos_, valueBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
				UInt16 keyLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref keyLen);
				byte[] keyBytes = new byte[keyLen];
				for(int i = 0; i < keyLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref keyBytes[i]);
				}
				key = StringHelper.BytesToString(keyBytes);
				UInt16 valueLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref valueLen);
				byte[] valueBytes = new byte[valueLen];
				for(int i = 0; i < valueLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref valueBytes[i]);
				}
				value = StringHelper.BytesToString(valueBytes);
			}
		#endregion

	}

	[Protocol]
	public class SceneSubmitDailyTask : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501124;
		public UInt32 taskId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskId);
			}
		#endregion

	}

	[Protocol]
	public class SceneDailyTaskList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501123;
		public MissionInfo[] tasks = new MissionInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)tasks.Length);
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 tasksCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref tasksCnt);
				tasks = new MissionInfo[tasksCnt];
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i] = new MissionInfo();
					tasks[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneSubmitAchievementTask : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501126;
		public UInt32 taskId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskId);
			}
		#endregion

	}

	[Protocol]
	public class SceneAchievementTaskList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501125;
		public MissionInfo[] tasks = new MissionInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)tasks.Length);
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 tasksCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref tasksCnt);
				tasks = new MissionInfo[tasksCnt];
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i] = new MissionInfo();
					tasks[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneSubmitAllDailyTask : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501132;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
			}

			public void decode(byte[] buffer, ref int pos_)
			{
			}
		#endregion

	}

	[Protocol]
	public class SceneSetTaskItemReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501133;
		public UInt32 taskId;
		public UInt64[] itemIds = new UInt64[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)itemIds.Length);
				for(int i = 0; i < itemIds.Length; i++)
				{
					BaseDLL.encode_uint64(buffer, ref pos_, itemIds[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskId);
				UInt16 itemIdsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemIdsCnt);
				itemIds = new UInt64[itemIdsCnt];
				for(int i = 0; i < itemIds.Length; i++)
				{
					BaseDLL.decode_uint64(buffer, ref pos_, ref itemIds[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneSetTaskItemRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501134;
		public UInt32 result;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
			}
		#endregion

	}

	[Protocol]
	public class SceneRefreshCycleTask : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501135;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
			}

			public void decode(byte[] buffer, ref int pos_)
			{
			}
		#endregion

	}

	[Protocol]
	public class SceneDailyScoreRewardReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501139;
		public byte boxId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, boxId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref boxId);
			}
		#endregion

	}

	[Protocol]
	public class SceneDailyScoreRewardRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501140;
		public UInt32 result;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
			}
		#endregion

	}

	[Protocol]
	public class SceneLegendTaskListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501114;
		public MissionInfo[] tasks = new MissionInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)tasks.Length);
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 tasksCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref tasksCnt);
				tasks = new MissionInfo[tasksCnt];
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i] = new MissionInfo();
					tasks[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneSubmitLegendTask : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501115;
		public UInt32 taskId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskId);
			}
		#endregion

	}

}
