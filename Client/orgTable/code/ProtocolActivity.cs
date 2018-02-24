using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	///  活动状态
	/// </summary>
	public enum StateType
	{
		/// <summary>
		///  结束
		/// </summary>
		End = 0,
		/// <summary>
		///  进行中
		/// </summary>
		Running = 1,
		/// <summary>
		///  准备中
		/// </summary>
		Ready = 2,
	}

	/// <summary>
	///  通知类型
	/// </summary>
	public enum NotifyType
	{
		NT_NONE = 0,
		/// <summary>
		///  公会战
		/// </summary>
		NT_GUILD_BATTLE = 1,
		/// <summary>
		///  武道大会 		
		/// </summary>
		NT_BUDO = 2,
		/// <summary>
		/// 罐子开放				
		/// </summary>
		NT_JAR_OPEN = 3,
		/// <summary>
		/// 罐子折扣重置			
		/// </summary>
		NT_JAR_SALE_RESET = 4,
		NT_MAX = 5,
	}

	public class ActivityInfo : Protocol.IProtocolStream
	{
		/// <summary>
		/// 状态，0 结束, 1 进行中，2 准备中
		/// </summary>
		public byte state;
		public UInt32 id;
		/// <summary>
		/// 活动名
		/// </summary>
		public string name;
		/// <summary>
		/// 需要等级
		/// </summary>
		public UInt16 level;
		/// <summary>
		/// 准备时间
		/// </summary>
		public UInt32 preTime;
		/// <summary>
		/// 开始时间
		/// </summary>
		public UInt32 startTime;
		/// <summary>
		/// 到期时间
		/// </summary>
		public UInt32 dueTime;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, state);
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_uint32(buffer, ref pos_, preTime);
				BaseDLL.encode_uint32(buffer, ref pos_, startTime);
				BaseDLL.encode_uint32(buffer, ref pos_, dueTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref state);
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_uint32(buffer, ref pos_, ref preTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref startTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dueTime);
			}
		#endregion

	}

	public class TaskPair : Protocol.IProtocolStream
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

	public class TaskBriefInfo : Protocol.IProtocolStream
	{
		public UInt32 taskID;
		public byte status;
		public TaskPair[] taskPairs = new TaskPair[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskID);
				BaseDLL.encode_int8(buffer, ref pos_, status);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)taskPairs.Length);
				for(int i = 0; i < taskPairs.Length; i++)
				{
					taskPairs[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskID);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
				UInt16 taskPairsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref taskPairsCnt);
				taskPairs = new TaskPair[taskPairsCnt];
				for(int i = 0; i < taskPairs.Length; i++)
				{
					taskPairs[i] = new TaskPair();
					taskPairs[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  server->client 同步客户端活动状态
	/// </summary>
	[Protocol]
	public class WorldNotifyClientActivity : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602901;
		public byte type;
		/// <summary>
		/// 0.结束，1.开始，2.准备
		/// </summary>
		public UInt32 id;
		public string name;
		public UInt16 level;
		public UInt32 preTime;
		public UInt32 startTime;
		/// <summary>
		/// 开始时间
		/// </summary>
		public UInt32 dueTime;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_uint32(buffer, ref pos_, preTime);
				BaseDLL.encode_uint32(buffer, ref pos_, startTime);
				BaseDLL.encode_uint32(buffer, ref pos_, dueTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_uint32(buffer, ref pos_, ref preTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref startTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dueTime);
			}
		#endregion

	}

	/// <summary>
	/// 截止时间
	/// </summary>
	/// <summary>
	///  server->client 同步活动数据
	/// </summary>
	[Protocol]
	public class SceneSyncClientActivities : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501136;
		public ActivityInfo[] activities = new ActivityInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)activities.Length);
				for(int i = 0; i < activities.Length; i++)
				{
					activities[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 activitiesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref activitiesCnt);
				activities = new ActivityInfo[activitiesCnt];
				for(int i = 0; i < activities.Length; i++)
				{
					activities[i] = new ActivityInfo();
					activities[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 同步活动任务状态
	/// </summary>
	[Protocol]
	public class SceneNotifyActiveTaskStatus : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501127;
		public UInt32 taskId;
		public byte status;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskId);
				BaseDLL.encode_int8(buffer, ref pos_, status);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskId);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
			}
		#endregion

	}

	/// <summary>
	/// 同步活动任务变量更新
	/// </summary>
	[Protocol]
	public class SceneNotifyActiveTaskVar : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501128;
		public UInt32 taskId;
		public string key;
		public string val;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskId);
				byte[] keyBytes = StringHelper.StringToUTF8Bytes(key);
				BaseDLL.encode_string(buffer, ref pos_, keyBytes, (UInt16)(buffer.Length - pos_));
				byte[] valBytes = StringHelper.StringToUTF8Bytes(val);
				BaseDLL.encode_string(buffer, ref pos_, valBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskId);
				UInt16 keyLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref keyLen);
				byte[] keyBytes = new byte[keyLen];
				for(int i = 0; i < keyLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref keyBytes[i]);
				}
				key = StringHelper.BytesToString(keyBytes);
				UInt16 valLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref valLen);
				byte[] valBytes = new byte[valLen];
				for(int i = 0; i < valLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref valBytes[i]);
				}
				val = StringHelper.BytesToString(valBytes);
			}
		#endregion

	}

	/// <summary>
	/// 同步活动任务列表
	/// </summary>
	[Protocol]
	public class SceneSyncActiveTaskList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501129;
		public TaskBriefInfo[] tasks = new TaskBriefInfo[0];

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
				tasks = new TaskBriefInfo[tasksCnt];
				for(int i = 0; i < tasks.Length; i++)
				{
					tasks[i] = new TaskBriefInfo();
					tasks[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 提交活动任务
	/// </summary>
	[Protocol]
	public class SceneActiveTaskSubmit : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501130;
		public UInt32 taskId;
		public UInt32 param1;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, taskId);
				BaseDLL.encode_uint32(buffer, ref pos_, param1);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref taskId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param1);
			}
		#endregion

	}

	/// <summary>
	/// 补签
	/// </summary>
	[Protocol]
	public class SceneActiveTaskSubmitRp : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501131;
		public UInt32[] taskId = new UInt32[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)taskId.Length);
				for(int i = 0; i < taskId.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, taskId[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 taskIdCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref taskIdCnt);
				taskId = new UInt32[taskIdCnt];
				for(int i = 0; i < taskId.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref taskId[i]);
				}
			}
		#endregion

	}

	/// <summary>
	/// 查询七日活动剩余时间
	/// </summary>
	[Protocol]
	public class SceneActiveRestTimeReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501138;

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

	/// <summary>
	/// 查询七日活动剩余时间返回
	/// </summary>
	[Protocol]
	public class SceneActiveRestTimeRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501137;
		public UInt32 time1;
		public UInt32 time2;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, time1);
				BaseDLL.encode_uint32(buffer, ref pos_, time2);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref time1);
				BaseDLL.decode_uint32(buffer, ref pos_, ref time2);
			}
		#endregion

	}

	/// <summary>
	/// 更新阶段礼包状态
	/// </summary>
	[Protocol]
	public class SceneSyncPhaseGift : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501141;
		public UInt32 giftId;
		public byte canTake;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, giftId);
				BaseDLL.encode_int8(buffer, ref pos_, canTake);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref giftId);
				BaseDLL.decode_int8(buffer, ref pos_, ref canTake);
			}
		#endregion

	}

	/// <summary>
	/// 1.可领取, 0.未完成
	/// </summary>
	/// <summary>
	/// 领取阶段礼包
	/// </summary>
	[Protocol]
	public class SceneTakePhaseGift : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501142;
		public UInt32 giftId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, giftId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref giftId);
			}
		#endregion

	}

	public class NotifyInfo : Protocol.IProtocolStream
	{
		public UInt32 type;
		/// <summary>
		/// 通知类型
		/// </summary>
		public UInt32 param;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, param);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param);
			}
		#endregion

	}

	/// <summary>
	/// 通知参数
	/// </summary>
	/// <summary>
	/// 初始化通知列表
	/// </summary>
	[Protocol]
	public class SceneInitNotifyList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501153;
		public NotifyInfo[] notifys = new NotifyInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)notifys.Length);
				for(int i = 0; i < notifys.Length; i++)
				{
					notifys[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 notifysCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref notifysCnt);
				notifys = new NotifyInfo[notifysCnt];
				for(int i = 0; i < notifys.Length; i++)
				{
					notifys[i] = new NotifyInfo();
					notifys[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 更新通知列表
	/// </summary>
	[Protocol]
	public class SceneUpdateNotifyList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501154;
		public NotifyInfo notify = new NotifyInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				notify.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				notify.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	/// 请求删除通知
	/// </summary>
	[Protocol]
	public class SceneDeleteNotifyList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501155;
		public NotifyInfo notify = new NotifyInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				notify.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				notify.decode(buffer, ref pos_);
			}
		#endregion

	}

}
