using System;
using System.Text;

namespace Protocol
{
	public enum RedPacketType
	{
		/// <summary>
		///  公会红包
		/// </summary>
		GUILD = 1,
	}

	/// <summary>
	///  红包状态
	/// </summary>
	public enum RedPacketStatus
	{
		/// <summary>
		///  初始状态
		/// </summary>
		INIT = 0,
		/// <summary>
		///  等待别人领取红包
		/// </summary>
		WAIT_RECEIVE = 1,
		/// <summary>
		///  已被领完
		/// </summary>
		EMPTY = 2,
		/// <summary>
		///  可摧毁
		/// </summary>
		DESTORY = 3,
	}

	/// <summary>
	///  红包基础信息
	/// </summary>
	public class RedPacketBaseEntry : Protocol.IProtocolStream
	{
		/// <summary>
		///  红包ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  名字
		/// </summary>
		public string name;
		/// <summary>
		///  发送者ID
		/// </summary>
		public UInt64 ownerId;
		/// <summary>
		///  发送者名字
		/// </summary>
		public string ownerName;
		/// <summary>
		///  状态（对应枚举RedPacketStatus）
		/// </summary>
		public byte status;
		/// <summary>
		///  有没有打开过
		/// </summary>
		public byte opened;
		/// <summary>
		///  红包类型(对应枚举RedPacketType)
		/// </summary>
		public byte type;
		/// <summary>
		///  红包来源
		/// </summary>
		public UInt16 reason;
		/// <summary>
		///  红包金额
		/// </summary>
		public UInt32 totalMoney;
		/// <summary>
		///  红包数量
		/// </summary>
		public byte totalNum;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint64(buffer, ref pos_, ownerId);
				byte[] ownerNameBytes = StringHelper.StringToUTF8Bytes(ownerName);
				BaseDLL.encode_string(buffer, ref pos_, ownerNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, status);
				BaseDLL.encode_int8(buffer, ref pos_, opened);
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint16(buffer, ref pos_, reason);
				BaseDLL.encode_uint32(buffer, ref pos_, totalMoney);
				BaseDLL.encode_int8(buffer, ref pos_, totalNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_uint64(buffer, ref pos_, ref ownerId);
				UInt16 ownerNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref ownerNameLen);
				byte[] ownerNameBytes = new byte[ownerNameLen];
				for(int i = 0; i < ownerNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref ownerNameBytes[i]);
				}
				ownerName = StringHelper.BytesToString(ownerNameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
				BaseDLL.decode_int8(buffer, ref pos_, ref opened);
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint16(buffer, ref pos_, ref reason);
				BaseDLL.decode_uint32(buffer, ref pos_, ref totalMoney);
				BaseDLL.decode_int8(buffer, ref pos_, ref totalNum);
			}
		#endregion

	}

	/// <summary>
	///  红包领取者信息
	/// </summary>
	public class RedPacketReceiverEntry : Protocol.IProtocolStream
	{
		/// <summary>
		///  icon
		/// </summary>
		public PlayerIcon icon = new PlayerIcon();
		/// <summary>
		///  获得金额
		/// </summary>
		public UInt32 money;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				icon.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, money);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				icon.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref money);
			}
		#endregion

	}

	/// <summary>
	///  红包详细信息
	/// </summary>
	public class RedPacketDetail : Protocol.IProtocolStream
	{
		/// <summary>
		///  基础信息
		/// </summary>
		public RedPacketBaseEntry baseEntry = new RedPacketBaseEntry();
		/// <summary>
		///  拥有者头像
		/// </summary>
		public PlayerIcon ownerIcon = new PlayerIcon();
		/// <summary>
		///  所有领取的玩家
		/// </summary>
		public RedPacketReceiverEntry[] receivers = new RedPacketReceiverEntry[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				baseEntry.encode(buffer, ref pos_);
				ownerIcon.encode(buffer, ref pos_);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)receivers.Length);
				for(int i = 0; i < receivers.Length; i++)
				{
					receivers[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				baseEntry.decode(buffer, ref pos_);
				ownerIcon.decode(buffer, ref pos_);
				UInt16 receiversCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref receiversCnt);
				receivers = new RedPacketReceiverEntry[receiversCnt];
				for(int i = 0; i < receivers.Length; i++)
				{
					receivers[i] = new RedPacketReceiverEntry();
					receivers[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  登录时同步红包基础信息
	/// </summary>
	[Protocol]
	public class WorldSyncRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607301;
		/// <summary>
		///  红包基础信息
		/// </summary>
		public RedPacketBaseEntry[] entrys = new RedPacketBaseEntry[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)entrys.Length);
				for(int i = 0; i < entrys.Length; i++)
				{
					entrys[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 entrysCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref entrysCnt);
				entrys = new RedPacketBaseEntry[entrysCnt];
				for(int i = 0; i < entrys.Length; i++)
				{
					entrys[i] = new RedPacketBaseEntry();
					entrys[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  通知获得新红包
	/// </summary>
	[Protocol]
	public class WorldNotifyGotNewRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607302;
		/// <summary>
		///  红包基础信息
		/// </summary>
		public RedPacketBaseEntry entry = new RedPacketBaseEntry();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				entry.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				entry.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  通知有新红包可领
	/// </summary>
	[Protocol]
	public class WorldNotifyNewRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607303;
		/// <summary>
		///  红包基础信息
		/// </summary>
		public RedPacketBaseEntry[] entry = new RedPacketBaseEntry[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)entry.Length);
				for(int i = 0; i < entry.Length; i++)
				{
					entry[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 entryCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref entryCnt);
				entry = new RedPacketBaseEntry[entryCnt];
				for(int i = 0; i < entry.Length; i++)
				{
					entry[i] = new RedPacketBaseEntry();
					entry[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  通知删除红包
	/// </summary>
	[Protocol]
	public class WorldNotifyDelRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607304;
		/// <summary>
		///  需要删除的红包ID
		/// </summary>
		public UInt64[] redPacketList = new UInt64[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)redPacketList.Length);
				for(int i = 0; i < redPacketList.Length; i++)
				{
					BaseDLL.encode_uint64(buffer, ref pos_, redPacketList[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 redPacketListCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref redPacketListCnt);
				redPacketList = new UInt64[redPacketListCnt];
				for(int i = 0; i < redPacketList.Length; i++)
				{
					BaseDLL.decode_uint64(buffer, ref pos_, ref redPacketList[i]);
				}
			}
		#endregion

	}

	/// <summary>
	///  通知修改红包状态
	/// </summary>
	[Protocol]
	public class WorldNotifySyncRedPacketStatus : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607305;
		/// <summary>
		///  id
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  状态(对应枚举RedPacketStatus)
		/// </summary>
		public byte status;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, status);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
			}
		#endregion

	}

	/// <summary>
	///  请求发红包
	/// </summary>
	[Protocol]
	public class WorldSendRedPacketReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607306;
		/// <summary>
		///  id
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  红包数量
		/// </summary>
		public byte num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  发红包返回
	/// </summary>
	[Protocol]
	public class WorldSendRedPacketRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607307;
		/// <summary>
		///  返回码
		/// </summary>
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

	/// <summary>
	///  请求打开红包(如果已经打开过了，那就是查看)
	/// </summary>
	[Protocol]
	public class WorldOpenRedPacketReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607308;
		/// <summary>
		///  id
		/// </summary>
		public UInt64 id;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
			}
		#endregion

	}

	/// <summary>
	///  返回打开红包请求
	/// </summary>
	[Protocol]
	public class WorldOpenRedPacketRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607309;
		/// <summary>
		///  返回码
		/// </summary>
		public UInt32 result;
		/// <summary>
		///  红包详细信息
		/// </summary>
		public RedPacketDetail detail = new RedPacketDetail();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				detail.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				detail.decode(buffer, ref pos_);
			}
		#endregion

	}

}
