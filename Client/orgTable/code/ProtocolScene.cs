using System;
using System.Text;

namespace Protocol
{
	public enum SceneObjectStatus
	{
		SOS_STAND = 0,
		SOS_WALK = 2,
	}

	/// <summary>
	///  红点标记
	/// </summary>
	public enum RedPointFlag
	{
		/// <summary>
		///  公会请求者
		/// </summary>
		GUILD_REQUESTER = 0,
		/// <summary>
		///  公会商店
		/// </summary>
		GUILD_SHOP = 1,
	}

	public class ScenePosition : Protocol.IProtocolStream
	{
		public UInt32 x;
		public UInt32 y;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, x);
				BaseDLL.encode_uint32(buffer, ref pos_, y);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref x);
				BaseDLL.decode_uint32(buffer, ref pos_, ref y);
			}
		#endregion

	}

	public class SceneDir : Protocol.IProtocolStream
	{
		public Int16 x;
		public Int16 y;
		public byte faceRight;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int16(buffer, ref pos_, x);
				BaseDLL.encode_int16(buffer, ref pos_, y);
				BaseDLL.encode_int8(buffer, ref pos_, faceRight);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int16(buffer, ref pos_, ref x);
				BaseDLL.decode_int16(buffer, ref pos_, ref y);
				BaseDLL.decode_int8(buffer, ref pos_, ref faceRight);
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyEnterScene : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500303;
		public UInt32 result;
		public UInt32 mapid;
		public string name;
		public ScenePosition pos = new ScenePosition();
		public SceneDir dir = new SceneDir();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, mapid);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				pos.encode(buffer, ref pos_);
				dir.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref mapid);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				pos.decode(buffer, ref pos_);
				dir.decode(buffer, ref pos_);
			}
		#endregion

	}

	[Protocol]
	public class SceneMoveRequire : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500501;
		public ScenePosition pos = new ScenePosition();
		public SceneDir dir = new SceneDir();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				pos.encode(buffer, ref pos_);
				dir.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				pos.decode(buffer, ref pos_);
				dir.decode(buffer, ref pos_);
			}
		#endregion

	}

	[Protocol]
	public class SceneSyncPlayerMove : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500502;
		public UInt64 id;
		public ScenePosition pos = new ScenePosition();
		public SceneDir dir = new SceneDir();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				pos.encode(buffer, ref pos_);
				dir.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				pos.decode(buffer, ref pos_);
				dir.decode(buffer, ref pos_);
			}
		#endregion

	}

	[Protocol]
	public class SceneSynSelf : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500601;

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
	public class SceneSyncSceneObject : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500602;

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
	public class SceneSyncObjectProperty : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500603;

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
	public class SceneDeleteSceneObject : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500604;

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
	public class SceneReturnToTown : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500517;

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
	public class ScenePlayerChangeSceneReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500503;
		public UInt32 curDoorId;
		public UInt32 dstSceneId;
		public UInt32 dstDoorId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, curDoorId);
				BaseDLL.encode_uint32(buffer, ref pos_, dstSceneId);
				BaseDLL.encode_uint32(buffer, ref pos_, dstDoorId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref curDoorId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dstSceneId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dstDoorId);
			}
		#endregion

	}

	/// <summary>
	///  清除公会红点
	/// </summary>
	[Protocol]
	public class SceneClearRedPoint : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500617;
		/// <summary>
		///  红点类型（对应枚举RedPointFlag）
		/// </summary>
		public UInt32 flag;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, flag);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref flag);
			}
		#endregion

	}

	/// <summary>
	///  设置用户自定义字段
	/// </summary>
	[Protocol]
	public class SceneSetCustomData : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500620;
		public UInt32 data;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, data);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref data);
			}
		#endregion

	}

}
