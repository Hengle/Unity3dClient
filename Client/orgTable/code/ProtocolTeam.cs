using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	///  ����Ŀ������
	/// </summary>
	public enum TeamTargetType
	{
		/// <summary>
		///  ���³�
		/// </summary>
		Dungeon = 0,
	}

	/// <summary>
	///  ��Ա����
	/// </summary>
	public enum TeamMemberProperty
	{
		/// <summary>
		///  �ȼ�
		/// </summary>
		Level = 0,
		/// <summary>
		///  ����ID
		/// </summary>
		GuildID = 1,
		/// <summary>
		///  ʣ�����
		/// </summary>
		RemainTimes = 2,
		/// <summary>
		///  ְҵ
		/// </summary>
		Occu = 3,
		/// <summary>
		///  ״̬
		/// </summary>
		StatusMask = 4,
		/// <summary>
		///  vip�ȼ�
		/// </summary>
		VipLevel = 5,
	}

	/// <summary>
	///  ��Ա״̬����
	/// </summary>
	public enum TeamMemberStatusMask
	{
		/// <summary>
		///  �Ƿ�����
		/// </summary>
		Online = 1,
		/// <summary>
		///  ׼��
		/// </summary>
		Ready = 2,
		/// <summary>
		///  ��ս
		/// </summary>
		Assist = 4,
		/// <summary>
		///  �Ƿ���ս����
		/// </summary>
		Racing = 8,
	}

	/// <summary>
	///  ����ѡ���޸�����
	/// </summary>
	public enum TeamOptionOperType
	{
		/// <summary>
		///  Ŀ��
		/// </summary>
		Target = 0,
		/// <summary>
		///  �Զ�ͬ��
		/// </summary>
		AutoAgree = 1,
	}

	/// <summary>
	///  �����Ա������Ϣ
	/// </summary>
	public class TeammemberBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		/// id
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// ����
		/// </summary>
		public string name;
		/// <summary>
		/// �ȼ�
		/// </summary>
		public UInt16 level;
		/// <summary>
		/// ְҵ
		/// </summary>
		public byte occu;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, occu);
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
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
			}
		#endregion

	}

	/// <summary>
	///  ��������
	/// </summary>
	[Protocol]
	public class WorldCreateTeam : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601610;
		/// <summary>
		///  ����Ŀ��
		/// </summary>
		public UInt32 target;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, target);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref target);
			}
		#endregion

	}

	/// <summary>
	///  �������鷵��
	/// </summary>
	[Protocol]
	public class WorldCreateTeamRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601627;
		/// <summary>
		///  ������(ErrorCode)
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
	///  ������鷵��
	/// </summary>
	[Protocol]
	public class WorldJoinTeamRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601628;
		/// <summary>
		///  ������(ErrorCode)
		/// </summary>
		public UInt32 result;
		public byte inTeam;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, inTeam);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref inTeam);
			}
		#endregion

	}

	/// <summary>
	///  ���������Ϣ
	/// </summary>
	public class TeamBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  ������
		/// </summary>
		public UInt16 teamId;
		/// <summary>
		///  ����Ŀ��
		/// </summary>
		public UInt32 target;
		/// <summary>
		///  �ӳ���Ϣ
		/// </summary>
		public TeammemberBaseInfo masterInfo = new TeammemberBaseInfo();
		/// <summary>
		///  ��Ա����
		/// </summary>
		public byte memberNum;
		/// <summary>
		///  ��Ա����
		/// </summary>
		public byte maxMemberNum;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, teamId);
				BaseDLL.encode_uint32(buffer, ref pos_, target);
				masterInfo.encode(buffer, ref pos_);
				BaseDLL.encode_int8(buffer, ref pos_, memberNum);
				BaseDLL.encode_int8(buffer, ref pos_, maxMemberNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref teamId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref target);
				masterInfo.decode(buffer, ref pos_);
				BaseDLL.decode_int8(buffer, ref pos_, ref memberNum);
				BaseDLL.decode_int8(buffer, ref pos_, ref maxMemberNum);
			}
		#endregion

	}

	/// <summary>
	///  �����Ա��Ϣ
	/// </summary>
	public class TeammemberInfo : Protocol.IProtocolStream
	{
		/// <summary>
		/// id
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// ����
		/// </summary>
		public string name;
		/// <summary>
		/// �ȼ�
		/// </summary>
		public UInt16 level;
		/// <summary>
		/// ְҵ
		/// </summary>
		public byte occu;
		/// <summary>
		///  ״̬���루��Ӧö��TeamMemberStatusMask��
		/// </summary>
		public byte statusMask;
		/// <summary>
		///  ���
		/// </summary>
		public PlayerAvatar avatar = new PlayerAvatar();
		/// <summary>
		///  ʣ�����
		/// </summary>
		public UInt32 remainTimes;
		/// <summary>
		///  ����ID
		/// </summary>
		public UInt64 guildId;
		/// <summary>
		///  vip�ȼ�
		/// </summary>
		public byte vipLevel;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_int8(buffer, ref pos_, statusMask);
				avatar.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, remainTimes);
				BaseDLL.encode_uint64(buffer, ref pos_, guildId);
				BaseDLL.encode_int8(buffer, ref pos_, vipLevel);
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
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
				BaseDLL.decode_int8(buffer, ref pos_, ref statusMask);
				avatar.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainTimes);
				BaseDLL.decode_uint64(buffer, ref pos_, ref guildId);
				BaseDLL.decode_int8(buffer, ref pos_, ref vipLevel);
			}
		#endregion

	}

	/// <summary>
	///  ͬ��������Ϣ
	/// </summary>
	[Protocol]
	public class WorldSyncTeamInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601601;
		/// <summary>
		///  ������
		/// </summary>
		public UInt16 id;
		/// <summary>
		///  ����Ŀ��
		/// </summary>
		public UInt32 target;
		/// <summary>
		///  �Ƿ��Զ�ͬ��
		/// </summary>
		public byte autoAgree;
		/// <summary>
		///  �ӳ�
		/// </summary>
		public UInt64 master;
		/// <summary>
		///  �����Ա����
		/// </summary>
		public TeammemberInfo[] members = new TeammemberInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, target);
				BaseDLL.encode_int8(buffer, ref pos_, autoAgree);
				BaseDLL.encode_uint64(buffer, ref pos_, master);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)members.Length);
				for(int i = 0; i < members.Length; i++)
				{
					members[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref target);
				BaseDLL.decode_int8(buffer, ref pos_, ref autoAgree);
				BaseDLL.decode_uint64(buffer, ref pos_, ref master);
				UInt16 membersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref membersCnt);
				members = new TeammemberInfo[membersCnt];
				for(int i = 0; i < members.Length; i++)
				{
					members[i] = new TeammemberInfo();
					members[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ�³�Ա����
	/// </summary>
	[Protocol]
	public class WorldNotifyNewTeamMember : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601602;
		/// <summary>
		///  ��Ա��Ϣ
		/// </summary>
		public TeammemberInfo info = new TeammemberInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				info.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				info.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  �����뿪����
	/// </summary>
	[Protocol]
	public class WorldLeaveTeamReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601603;
		/// <summary>
		///  ���˻��Լ�
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
	///  ֪ͨ��Ա�뿪
	/// </summary>
	[Protocol]
	public class WorldNotifyMemberLeave : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601604;
		/// <summary>
		///  ��ԱID
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
	///  ֪ͨ��Ա������
	/// </summary>
	[Protocol]
	public class WorldSyncTeamMemberStatus : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601605;
		/// <summary>
		///  ��ԱID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  ״̬���루��Ӧö��TeamMemberStatusMask��
		/// </summary>
		public byte statusMask;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, statusMask);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref statusMask);
			}
		#endregion

	}

	/// <summary>
	///  ������������뷢����������
	/// </summary>
	[Protocol]
	public class WorldTeamPasswdReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601612;
		/// <summary>
		/// Ŀ��
		/// </summary>
		public UInt64 target;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, target);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref target);
			}
		#endregion

	}

	/// <summary>
	///  ���ö�������
	/// </summary>
	[Protocol]
	public class WorldSetTeamOption : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601625;
		/// <summary>
		///  �������ͣ�TeamOptionOperType��
		/// </summary>
		public byte type;
		/// <summary>
		///  ���治ͬ����´���ͬ������
		/// </summary>
		public string str;
		public UInt32 param1;
		public UInt32 param2;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				byte[] strBytes = StringHelper.StringToUTF8Bytes(str);
				BaseDLL.encode_string(buffer, ref pos_, strBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, param1);
				BaseDLL.encode_uint32(buffer, ref pos_, param2);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				UInt16 strLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref strLen);
				byte[] strBytes = new byte[strLen];
				for(int i = 0; i < strLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref strBytes[i]);
				}
				str = StringHelper.BytesToString(strBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param1);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param2);
			}
		#endregion

	}

	/// <summary>
	///  ͬ����������
	/// </summary>
	[Protocol]
	public class WorldSyncTeamOption : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601626;
		/// <summary>
		///  �������ͣ�TeamOptionOperType��
		/// </summary>
		public byte type;
		/// <summary>
		///  ���治ͬ����´���ͬ������
		/// </summary>
		public string str;
		public UInt32 param1;
		public UInt32 param2;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				byte[] strBytes = StringHelper.StringToUTF8Bytes(str);
				BaseDLL.encode_string(buffer, ref pos_, strBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, param1);
				BaseDLL.encode_uint32(buffer, ref pos_, param2);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				UInt16 strLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref strLen);
				byte[] strBytes = new byte[strLen];
				for(int i = 0; i < strLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref strBytes[i]);
				}
				str = StringHelper.BytesToString(strBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param1);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param2);
			}
		#endregion

	}

	/// <summary>
	///  ����ת�öӳ�
	/// </summary>
	[Protocol]
	public class WorldTransferTeammaster : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601608;
		/// <summary>
		///  ��ԱID
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
	///  ͬ���¶ӳ�
	/// </summary>
	[Protocol]
	public class WorldSyncTeammaster : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601609;
		/// <summary>
		///  �ӳ�ID
		/// </summary>
		public UInt64 master;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, master);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref master);
			}
		#endregion

	}

	/// <summary>
	///  ��ɢ����
	/// </summary>
	[Protocol]
	public class WorldDismissTeam : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601611;

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
	///  ��ѯ�����б�
	/// </summary>
	[Protocol]
	public class WorldQueryTeamList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601623;
		/// <summary>
		///  ���ݶ���������
		/// </summary>
		public UInt16 teamId;
		/// <summary>
		///  ����Ŀ��
		/// </summary>
		public UInt32 targetId;
		/// <summary>
		///  ���ݵ��³�����
		/// </summary>
		public UInt32[] targetList = new UInt32[0];
		/// <summary>
		///  ��ѯ��ʼλ��
		/// </summary>
		public UInt16 startPos;
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
				BaseDLL.encode_uint16(buffer, ref pos_, teamId);
				BaseDLL.encode_uint32(buffer, ref pos_, targetId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)targetList.Length);
				for(int i = 0; i < targetList.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, targetList[i]);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, startPos);
				BaseDLL.encode_int8(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref teamId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref targetId);
				UInt16 targetListCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref targetListCnt);
				targetList = new UInt32[targetListCnt];
				for(int i = 0; i < targetList.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref targetList[i]);
				}
				BaseDLL.decode_uint16(buffer, ref pos_, ref startPos);
				BaseDLL.decode_int8(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  ���ض����б�
	/// </summary>
	[Protocol]
	public class WorldQueryTeamListRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601624;
		/// <summary>
		///  ����Ŀ��
		/// </summary>
		public UInt32 targetId;
		public TeamBaseInfo[] teamList = new TeamBaseInfo[0];
		public UInt16 pos;
		public UInt16 maxNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, targetId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)teamList.Length);
				for(int i = 0; i < teamList.Length; i++)
				{
					teamList[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, pos);
				BaseDLL.encode_uint16(buffer, ref pos_, maxNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref targetId);
				UInt16 teamListCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref teamListCnt);
				teamList = new TeamBaseInfo[teamListCnt];
				for(int i = 0; i < teamList.Length; i++)
				{
					teamList[i] = new TeamBaseInfo();
					teamList[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_uint16(buffer, ref pos_, ref pos);
				BaseDLL.decode_uint16(buffer, ref pos_, ref maxNum);
			}
		#endregion

	}

	/// <summary>
	///  ͬ���ӳ�����
	/// </summary>
	[Protocol]
	public class WorldTeamMasterOperSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601629;
		/// <summary>
		///  ��������
		/// </summary>
		public byte type;
		/// <summary>
		///  �������
		/// </summary>
		public UInt32 param;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, param);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param);
			}
		#endregion

	}

	/// <summary>
	///  �����޸�λ��״̬���򿪻�رգ�
	/// </summary>
	[Protocol]
	public class WorldTeamChangePosStatusReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601630;
		/// <summary>
		///  λ��
		/// </summary>
		public byte pos;
		/// <summary>
		///  0�����λ�ã�1����ر�λ��
		/// </summary>
		public byte open;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				BaseDLL.encode_int8(buffer, ref pos_, open);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				BaseDLL.decode_int8(buffer, ref pos_, ref open);
			}
		#endregion

	}

	/// <summary>
	///  ͬ��λ��״̬�ı�
	/// </summary>
	[Protocol]
	public class WorldTeamChangePosStatusSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601631;
		/// <summary>
		///  λ��
		/// </summary>
		public byte pos;
		/// <summary>
		///  1�����λ�ã�0����ر�λ��
		/// </summary>
		public byte open;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				BaseDLL.encode_int8(buffer, ref pos_, open);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				BaseDLL.decode_int8(buffer, ref pos_, ref open);
			}
		#endregion

	}

	/// <summary>
	///  ׼��
	/// </summary>
	[Protocol]
	public class WorldTeamReadyReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601632;
		/// <summary>
		///  �Ƿ�׼����(0:ȡ�� 1:׼��)
		/// </summary>
		public byte ready;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, ready);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref ready);
			}
		#endregion

	}

	/// <summary>
	///  ͬ�������Ϣ
	/// </summary>
	[Protocol]
	public class WorldSyncTeammemberAvatar : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601636;
		/// <summary>
		///  ��ԱID
		/// </summary>
		public UInt64 memberId;
		/// <summary>
		///  ���
		/// </summary>
		public PlayerAvatar avatar = new PlayerAvatar();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, memberId);
				avatar.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref memberId);
				avatar.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ����������ӵ���
	/// </summary>
	[Protocol]
	public class WorldTeamNotifyNewRequester : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601637;

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
	///  ��ȡ�����б�
	/// </summary>
	[Protocol]
	public class WorldTeamRequesterListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601638;

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
	///  ���������б�
	/// </summary>
	[Protocol]
	public class WorldTeamRequesterListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601639;
		public TeammemberBaseInfo[] requesters = new TeammemberBaseInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)requesters.Length);
				for(int i = 0; i < requesters.Length; i++)
				{
					requesters[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 requestersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref requestersCnt);
				requesters = new TeammemberBaseInfo[requestersCnt];
				for(int i = 0; i < requesters.Length; i++)
				{
					requesters[i] = new TeammemberBaseInfo();
					requesters[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���������ߣ�ͬ�⡢�ܾ���
	/// </summary>
	[Protocol]
	public class WorldTeamProcessRequesterReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601640;
		/// <summary>
		///  Ŀ��ID
		/// </summary>
		public UInt64 targetId;
		/// <summary>
		///  �Ƿ�ͬ��
		/// </summary>
		public byte agree;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, targetId);
				BaseDLL.encode_int8(buffer, ref pos_, agree);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref targetId);
				BaseDLL.decode_int8(buffer, ref pos_, ref agree);
			}
		#endregion

	}

	/// <summary>
	///  ���������߷���
	/// </summary>
	[Protocol]
	public class WorldTeamProcessRequesterRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601641;
		/// <summary>
		///  Ŀ��ID
		/// </summary>
		public UInt64 targetId;
		/// <summary>
		///  ���
		/// </summary>
		public UInt32 result;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, targetId);
				BaseDLL.encode_uint32(buffer, ref pos_, result);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref targetId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ��ʼ���³�ͶƱ
	/// </summary>
	[Protocol]
	public class WorldTeamRaceVoteNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601642;
		/// <summary>
		///  ���³�ID
		/// </summary>
		public UInt32 dungeonId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, dungeonId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungeonId);
			}
		#endregion

	}

	/// <summary>
	///  ����ϱ�ͶƱѡ��
	/// </summary>
	[Protocol]
	public class WorldTeamReportVoteChoice : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601643;
		/// <summary>
		///  �Ƿ�ͬ��
		/// </summary>
		public byte agree;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, agree);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref agree);
			}
		#endregion

	}

	/// <summary>
	///  �������뷵��
	/// </summary>
	[Protocol]
	public class WorldTeamInviteRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601644;
		/// <summary>
		///  Ŀ�����ID
		/// </summary>
		public UInt64 targetId;
		/// <summary>
		///  ���
		/// </summary>
		public UInt32 result;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, targetId);
				BaseDLL.encode_uint32(buffer, ref pos_, result);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref targetId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ��Ҷ�������
	/// </summary>
	[Protocol]
	public class WorldTeamInviteNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601645;
		/// <summary>
		///  ������Ϣ
		/// </summary>
		public TeamBaseInfo info = new TeamBaseInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				info.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				info.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ��Ҷ�����������
	/// </summary>
	[Protocol]
	public class WorldTeamRequestResultNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601646;
		/// <summary>
		///  �Ƿ�ͬ��
		/// </summary>
		public byte agree;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, agree);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref agree);
			}
		#endregion

	}

	/// <summary>
	///  �㲥������ͶƱѡ��
	/// </summary>
	[Protocol]
	public class WorldTeamVoteChoiceNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601647;
		/// <summary>
		///  ��ɫID
		/// </summary>
		public UInt64 roleId;
		/// <summary>
		///  �Ƿ�ͬ��
		/// </summary>
		public byte agree;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_int8(buffer, ref pos_, agree);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_int8(buffer, ref pos_, ref agree);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ�����ӿ���ƥ����
	/// </summary>
	[Protocol]
	public class WorldTeamMatchResultNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601648;
		/// <summary>
		///  ���³�ID
		/// </summary>
		public UInt32 dungeonId;
		/// <summary>
		///  �Ƿ�ͬ��
		/// </summary>
		public PlayerIcon[] players = new PlayerIcon[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, dungeonId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)players.Length);
				for(int i = 0; i < players.Length; i++)
				{
					players[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungeonId);
				UInt16 playersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref playersCnt);
				players = new PlayerIcon[playersCnt];
				for(int i = 0; i < players.Length; i++)
				{
					players[i] = new PlayerIcon();
					players[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ����ȡ�����ƥ��
	/// </summary>
	[Protocol]
	public class WorldTeamMatchCancelReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601650;

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
	///  ȡ�����ƥ�䷵��
	/// </summary>
	[Protocol]
	public class WorldTeamMatchCancelRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601651;
		/// <summary>
		///  ���
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
	///  ����ʼ���ƥ��
	/// </summary>
	[Protocol]
	public class SceneTeamMatchStartReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501604;
		/// <summary>
		///  Ŀ����³�ID
		/// </summary>
		public UInt32 dungeonId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, dungeonId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungeonId);
			}
		#endregion

	}

	/// <summary>
	///  ��ʼ���ƥ�䷵��
	/// </summary>
	[Protocol]
	public class SceneTeamMatchStartRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501605;
		/// <summary>
		///  ���
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
	///  ͬ����Ա����
	/// </summary>
	[Protocol]
	public class WorldSyncTeamMemberProperty : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601654;
		/// <summary>
		///  ��ԱID
		/// </summary>
		public UInt64 memberId;
		/// <summary>
		///  �������ͣ���Ӧö��TeamMemberProperty
		/// </summary>
		public byte type;
		/// <summary>
		///  �µ�ֵ
		/// </summary>
		public UInt64 value;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, memberId);
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, value);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref memberId);
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref value);
			}
		#endregion

	}

	/// <summary>
	///  ͬ����Ա����
	/// </summary>
	[Protocol]
	public class WorldChangeAssistModeReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601655;
		/// <summary>
		///  �Ƿ���ս
		/// </summary>
		public byte isAssist;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, isAssist);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref isAssist);
			}
		#endregion

	}

}
