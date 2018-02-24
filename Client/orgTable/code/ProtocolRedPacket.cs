using System;
using System.Text;

namespace Protocol
{
	public enum RedPacketType
	{
		/// <summary>
		///  ������
		/// </summary>
		GUILD = 1,
	}

	/// <summary>
	///  ���״̬
	/// </summary>
	public enum RedPacketStatus
	{
		/// <summary>
		///  ��ʼ״̬
		/// </summary>
		INIT = 0,
		/// <summary>
		///  �ȴ�������ȡ���
		/// </summary>
		WAIT_RECEIVE = 1,
		/// <summary>
		///  �ѱ�����
		/// </summary>
		EMPTY = 2,
		/// <summary>
		///  �ɴݻ�
		/// </summary>
		DESTORY = 3,
	}

	/// <summary>
	///  ���������Ϣ
	/// </summary>
	public class RedPacketBaseEntry : Protocol.IProtocolStream
	{
		/// <summary>
		///  ���ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  ����
		/// </summary>
		public string name;
		/// <summary>
		///  ������ID
		/// </summary>
		public UInt64 ownerId;
		/// <summary>
		///  ����������
		/// </summary>
		public string ownerName;
		/// <summary>
		///  ״̬����Ӧö��RedPacketStatus��
		/// </summary>
		public byte status;
		/// <summary>
		///  ��û�д򿪹�
		/// </summary>
		public byte opened;
		/// <summary>
		///  �������(��Ӧö��RedPacketType)
		/// </summary>
		public byte type;
		/// <summary>
		///  �����Դ
		/// </summary>
		public UInt16 reason;
		/// <summary>
		///  ������
		/// </summary>
		public UInt32 totalMoney;
		/// <summary>
		///  �������
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
	///  �����ȡ����Ϣ
	/// </summary>
	public class RedPacketReceiverEntry : Protocol.IProtocolStream
	{
		/// <summary>
		///  icon
		/// </summary>
		public PlayerIcon icon = new PlayerIcon();
		/// <summary>
		///  ��ý��
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
	///  �����ϸ��Ϣ
	/// </summary>
	public class RedPacketDetail : Protocol.IProtocolStream
	{
		/// <summary>
		///  ������Ϣ
		/// </summary>
		public RedPacketBaseEntry baseEntry = new RedPacketBaseEntry();
		/// <summary>
		///  ӵ����ͷ��
		/// </summary>
		public PlayerIcon ownerIcon = new PlayerIcon();
		/// <summary>
		///  ������ȡ�����
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
	///  ��¼ʱͬ�����������Ϣ
	/// </summary>
	[Protocol]
	public class WorldSyncRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607301;
		/// <summary>
		///  ���������Ϣ
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
	///  ֪ͨ����º��
	/// </summary>
	[Protocol]
	public class WorldNotifyGotNewRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607302;
		/// <summary>
		///  ���������Ϣ
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
	///  ֪ͨ���º������
	/// </summary>
	[Protocol]
	public class WorldNotifyNewRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607303;
		/// <summary>
		///  ���������Ϣ
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
	///  ֪ͨɾ�����
	/// </summary>
	[Protocol]
	public class WorldNotifyDelRedPacket : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607304;
		/// <summary>
		///  ��Ҫɾ���ĺ��ID
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
	///  ֪ͨ�޸ĺ��״̬
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
		///  ״̬(��Ӧö��RedPacketStatus)
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
	///  ���󷢺��
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
		///  �������
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
	///  ���������
	/// </summary>
	[Protocol]
	public class WorldSendRedPacketRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607307;
		/// <summary>
		///  ������
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
	///  ����򿪺��(����Ѿ��򿪹��ˣ��Ǿ��ǲ鿴)
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
	///  ���ش򿪺������
	/// </summary>
	[Protocol]
	public class WorldOpenRedPacketRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 607309;
		/// <summary>
		///  ������
		/// </summary>
		public UInt32 result;
		/// <summary>
		///  �����ϸ��Ϣ
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
