using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	///  ����ְ��
	/// </summary>
	public enum GuildPost
	{
		/// <summary>
		///  ��Чֵ
		/// </summary>
		GUILD_INVALID = 0,
		/// <summary>
		///  ��ͨ��Ա
		/// </summary>
		GUILD_POST_NORMAL = 1,
		/// <summary>
		///  ��Ӣ
		/// </summary>
		GUILD_POST_ELITE = 2,
		/// <summary>
		///  ����
		/// </summary>
		GUILD_POST_ELDER = 11,
		/// <summary>
		///  ���᳤
		/// </summary>
		GUILD_POST_ASSISTANT = 12,
		/// <summary>
		///  �᳤
		/// </summary>
		GUILD_POST_LEADER = 13,
	}

	/// <summary>
	///  ��������
	/// </summary>
	public enum GuildAttr
	{
		/// <summary>
		///  ��Ч����
		/// </summary>
		GA_INVALID = 0,
		/// <summary>
		///  ����	string	
		/// </summary>
		GA_NAME = 1,
		/// <summary>
		///  �ȼ�	UInt8	
		/// </summary>
		GA_LEVEL = 2,
		/// <summary>
		///  ���� string
		/// </summary>
		GA_DECLARATION = 3,
		/// <summary>
		///  �����ʽ� Int32
		/// </summary>
		GA_FUND = 4,
		/// <summary>
		///  ���� string
		/// </summary>
		GA_ANNOUNCEMENT = 5,
		/// <summary>
		///  ���Ὠ�� GuildBuilding
		/// </summary>
		GA_BUILDING = 6,
		/// <summary>
		///  ��ɢʱ�� UInt32
		/// </summary>
		GA_DISMISS_TIME = 7,
		/// <summary>
		///  ��Ա���� UInt16
		/// </summary>
		GA_MEMBER_NUM = 8,
		/// <summary>
		///  �᳤���� string
		/// </summary>
		GA_LEADER_NAME = 9,
		/// <summary>
		///  �������ID UInt8
		/// </summary>
		GA_ENROLL_TERRID = 10,
		/// <summary>
		///  ����ս���� UInt32
		/// </summary>
		GA_BATTLE_SCORE = 11,
		/// <summary>
		///  ����ռ����� UInt8
		/// </summary>
		GA_OCCUPY_TERRID = 12,
		/// <summary>
		///  ����ս������� UInt8
		/// </summary>
		GA_INSPIRE = 13,
		/// <summary>
		///  ����սʤ���齱���� UInt8
		/// </summary>
		GA_WIN_PROBABILITY = 14,
		/// <summary>
		///  ����սʧ�ܳ齱���� UInt8
		/// </summary>
		GA_LOSE_PROBABILITY = 15,
		/// <summary>
		///  ����ս�ֿ������Ʒ UInt8
		/// </summary>
		GA_STORAGE_ADD_POST = 16,
		/// <summary>
		///  ����ս�ֿ�ɾ����Ʒ UInt8
		/// </summary>
		GA_STORAGE_DEL_POST = 17,
	}

	/// <summary>
	/// ����ս����
	/// </summary>
	public enum GuildBattleType
	{
		/// <summary>
		///  ��Ч
		/// </summary>
		GBT_INVALID = 0,
		/// <summary>
		///  ��ͨ
		/// </summary>
		GBT_NORMAL = 1,
		/// <summary>
		///  ��ս
		/// </summary>
		GBT_CHALLENGE = 2,
	}

	/// <summary>
	///  ����ս״̬
	/// </summary>
	public enum GuildBattleStatus
	{
		/// <summary>
		///  ��
		/// </summary>
		GBS_INVALID = 0,
		/// <summary>
		///  ����
		/// </summary>
		GBS_ENROLL = 1,
		/// <summary>
		///  ׼��
		/// </summary>
		GBS_PREPARE = 2,
		/// <summary>
		///  ս��
		/// </summary>
		GBS_BATTLE = 3,
		/// <summary>
		///  �콱
		/// </summary>
		GBS_REWARD = 4,
		GBS_MAX = 5,
	}

	/// <summary>
	///  ���Ὠ������
	/// </summary>
	public enum GuildBuildingType
	{
		/// <summary>
		///  ����
		/// </summary>
		MAIN = 0,
		/// <summary>
		///  �̵�
		/// </summary>
		SHOP = 1,
		/// <summary>
		///  Բ������
		/// </summary>
		TABLE = 2,
		/// <summary>
		///  ���³�
		/// </summary>
		DUNGEON = 3,
		/// <summary>
		///  ����
		/// </summary>
		STATUE = 4,
		/// <summary>
		///  ս����
		/// </summary>
		BATTLE = 5,
		/// <summary>
		///  ������
		/// </summary>
		WELFARE = 6,
	}

	/// <summary>
	///  �����������
	/// </summary>
	public enum GuildOperation
	{
		/// <summary>
		///  �޸Ĺ�������
		/// </summary>
		MODIFY_DECLAR = 0,
		/// <summary>
		///  �޸Ĺ�����
		/// </summary>
		MODIFY_NAME = 1,
		/// <summary>
		///  �޸Ĺ��ṫ��
		/// </summary>
		MODIFY_ANNOUNCE = 2,
		/// <summary>
		///  ���͹����ʼ�
		/// </summary>
		SEND_MAIL = 3,
		/// <summary>
		///  ��������
		/// </summary>
		UPGRADE_BUILDING = 4,
		/// <summary>
		///  ����
		/// </summary>
		DONATE = 5,
		/// <summary>
		///  �һ�
		/// </summary>
		EXCHANGE = 6,
		/// <summary>
		///  ��������
		/// </summary>
		UPGRADE_SKILL = 7,
		/// <summary>
		///  ��ɢ����
		/// </summary>
		DISMISS = 8,
		/// <summary>
		///  ȡ����ɢ����
		/// </summary>
		CANCEL_DISMISS = 9,
		/// <summary>
		///  Ĥ��
		/// </summary>
		ORZ = 10,
		/// <summary>
		///  Բ������
		/// </summary>
		TABLE = 11,
		/// <summary>
		///  �ԷѺ��
		/// </summary>
		PAY_REDPACKET = 12,
	}

	/// <summary>
	///  ����
	/// </summary>
	public enum GuildDonateType
	{
		/// <summary>
		///  ��Ҿ���
		/// </summary>
		GOLD = 0,
		/// <summary>
		///  �ㄻ����
		/// </summary>
		POINT = 1,
	}

	/// <summary>
	///  Ĥ������
	/// </summary>
	public enum GuildOrzType
	{
		/// <summary>
		///  ��ͨĤ��
		/// </summary>
		GUILD_ORZ_LOW = 0,
		/// <summary>
		///  �м�Ĥ��
		/// </summary>
		GUILD_ORZ_MID = 1,
		/// <summary>
		///  �߼�Ĥ��
		/// </summary>
		GUILD_ORZ_HIGH = 2,
	}

	/// <summary>
	///  ����ֿ���������
	/// </summary>
	public enum GuildStorageSetting
	{
		GUILD_POST_INVALID = 0,
		/// <summary>
		///  ʤ���齱����
		/// </summary>
		GSS_WIN_PROBABILITY = 1,
		/// <summary>
		///  ʧ�ܳ齱����
		/// </summary>
		GSS_LOSE_PROBABILITY = 2,
		/// <summary>
		///  �ֿ�����Ȩ��
		/// </summary>
		GSS_STORAGE_ADD_POST = 3,
		/// <summary>
		///  �ֿ�ɾ��Ȩ��
		/// </summary>
		GSS_STORAGE_DEL_POST = 4,
		GSS_MAX = 5,
	}

	/// <summary>
	///  �����Ա�齱״̬
	/// </summary>
	public enum GuildBattleLotteryStatus
	{
		/// <summary>
		///  ��Ч
		/// </summary>
		GBLS_INVALID = 0,
		/// <summary>
		///  ���ܳ齱
		/// </summary>
		GBLS_NOT = 1,
		/// <summary>
		///  ���Գ齱
		/// </summary>
		GBLS_CAN = 2,
		/// <summary>
		///  �Ѿ��齱
		/// </summary>
		GBLS_FIN = 3,
		GBLS_MAX = 4,
	}

	public enum GuildStorageOpType
	{
		GSOT_NONE = 0,
		/// <summary>
		///  ���
		/// </summary>
		GSOT_GET = 1,
		/// <summary>
		///  ����
		/// </summary>
		GSOT_PUT = 2,
		/// <summary>
		///  ���򲢴���
		/// </summary>
		GSOT_BUYPUT = 3,
	}

	/// <summary>
	///  ������Ϣ
	/// </summary>
	public class GuildEntry : Protocol.IProtocolStream
	{
		/// <summary>
		///  id
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  name
		/// </summary>
		public string name;
		/// <summary>
		///  ����ȼ�
		/// </summary>
		public byte level;
		/// <summary>
		///  ��������
		/// </summary>
		public byte memberNum;
		/// <summary>
		///  �᳤����
		/// </summary>
		public string leaderName;
		/// <summary>
		///  ����
		/// </summary>
		public string declaration;
		/// <summary>
		///  �Ƿ��Ѿ�����
		/// </summary>
		public byte isRequested;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, memberNum);
				byte[] leaderNameBytes = StringHelper.StringToUTF8Bytes(leaderName);
				BaseDLL.encode_string(buffer, ref pos_, leaderNameBytes, (UInt16)(buffer.Length - pos_));
				byte[] declarationBytes = StringHelper.StringToUTF8Bytes(declaration);
				BaseDLL.encode_string(buffer, ref pos_, declarationBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, isRequested);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref memberNum);
				UInt16 leaderNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref leaderNameLen);
				byte[] leaderNameBytes = new byte[leaderNameLen];
				for(int i = 0; i < leaderNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref leaderNameBytes[i]);
				}
				leaderName = StringHelper.BytesToString(leaderNameBytes);
				UInt16 declarationLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref declarationLen);
				byte[] declarationBytes = new byte[declarationLen];
				for(int i = 0; i < declarationLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref declarationBytes[i]);
				}
				declaration = StringHelper.BytesToString(declarationBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref isRequested);
			}
		#endregion

	}

	/// <summary>
	///  �����Ա
	/// </summary>
	public class GuildMemberEntry : Protocol.IProtocolStream
	{
		/// <summary>
		///  id
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  name
		/// </summary>
		public string name;
		/// <summary>
		///  �ȼ�
		/// </summary>
		public UInt16 level;
		/// <summary>
		///  ְҵ
		/// </summary>
		public byte occu;
		/// <summary>
		///  ְ��(��Ӧö��GuildPost)
		/// </summary>
		public byte post;
		/// <summary>
		///  ��ʷ����
		/// </summary>
		public UInt32 contribution;
		/// <summary>
		///  ����ʱ��(0��������)
		/// </summary>
		public UInt32 logoutTime;
		/// <summary>
		///  ��Ծ��
		/// </summary>
		public UInt32 activeDegree;
		/// <summary>
		/// vip�ȼ�
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
				BaseDLL.encode_int8(buffer, ref pos_, post);
				BaseDLL.encode_uint32(buffer, ref pos_, contribution);
				BaseDLL.encode_uint32(buffer, ref pos_, logoutTime);
				BaseDLL.encode_uint32(buffer, ref pos_, activeDegree);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref post);
				BaseDLL.decode_uint32(buffer, ref pos_, ref contribution);
				BaseDLL.decode_uint32(buffer, ref pos_, ref logoutTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref activeDegree);
				BaseDLL.decode_int8(buffer, ref pos_, ref vipLevel);
			}
		#endregion

	}

	/// <summary>
	///  ������������Ϣ
	/// </summary>
	public class GuildRequesterInfo : Protocol.IProtocolStream
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
		/// vip�ȼ�
		/// </summary>
		public byte vipLevel;
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public UInt32 requestTime;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_int8(buffer, ref pos_, vipLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, requestTime);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref vipLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref requestTime);
			}
		#endregion

	}

	/// <summary>
	///  ���Ὠ��
	/// </summary>
	public class GuildBuilding : Protocol.IProtocolStream
	{
		/// <summary>
		///  �������ͣ���Ӧö��GuildBuildingType��
		/// </summary>
		public byte type;
		/// <summary>
		///  �ȼ�
		/// </summary>
		public byte level;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, level);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref level);
			}
		#endregion

	}

	/// <summary>
	///  Բ�������Ա��Ϣ
	/// </summary>
	public class GuildTableMember : Protocol.IProtocolStream
	{
		/// <summary>
		///  ��ɫID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  �ȼ�
		/// </summary>
		public UInt16 level;
		/// <summary>
		///  ְҵ
		/// </summary>
		public byte occu;
		/// <summary>
		///  ����
		/// </summary>
		public string name;
		/// <summary>
		///  λ��
		/// </summary>
		public byte seat;
		/// <summary>
		///  ��������
		/// </summary>
		public byte type;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				BaseDLL.encode_int8(buffer, ref pos_, type);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
			}
		#endregion

	}

	/// <summary>
	///  ����ս��Ա
	/// </summary>
	public class GuildBattleMember : Protocol.IProtocolStream
	{
		/// <summary>
		///  ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// ����
		/// </summary>
		public string name;
		/// <summary>
		///  ��ʤ��
		/// </summary>
		public byte winStreak;
		/// <summary>
		///  ��û���
		/// </summary>
		public UInt16 gotScore;
		/// <summary>
		///  �ܻ���
		/// </summary>
		public UInt16 totalScore;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, winStreak);
				BaseDLL.encode_uint16(buffer, ref pos_, gotScore);
				BaseDLL.encode_uint16(buffer, ref pos_, totalScore);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref winStreak);
				BaseDLL.decode_uint16(buffer, ref pos_, ref gotScore);
				BaseDLL.decode_uint16(buffer, ref pos_, ref totalScore);
			}
		#endregion

	}

	public class GuildBattleRecord : Protocol.IProtocolStream
	{
		public UInt32 index;
		/// <summary>
		///  ʤ����
		/// </summary>
		public GuildBattleMember winner = new GuildBattleMember();
		/// <summary>
		///  ʧ����
		/// </summary>
		public GuildBattleMember loser = new GuildBattleMember();
		/// <summary>
		///  ʱ��
		/// </summary>
		public UInt32 time;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, index);
				winner.encode(buffer, ref pos_);
				loser.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, time);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref index);
				winner.decode(buffer, ref pos_);
				loser.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref time);
			}
		#endregion

	}

	public class GuildTerritoryBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  ���ID
		/// </summary>
		public byte terrId;
		/// <summary>
		///  ռ�칫������
		/// </summary>
		public string guildName;
		/// <summary>
		///  �Ѿ���������
		/// </summary>
		public UInt32 enrollSize;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, terrId);
				byte[] guildNameBytes = StringHelper.StringToUTF8Bytes(guildName);
				BaseDLL.encode_string(buffer, ref pos_, guildNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, enrollSize);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref terrId);
				UInt16 guildNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref guildNameLen);
				byte[] guildNameBytes = new byte[guildNameLen];
				for(int i = 0; i < guildNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref guildNameBytes[i]);
				}
				guildName = StringHelper.BytesToString(guildNameBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref enrollSize);
			}
		#endregion

	}

	public class GuildBattleInspireInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  ���ID
		/// </summary>
		public UInt64 playerId;
		/// <summary>
		///  �������
		/// </summary>
		public string playerName;
		/// <summary>
		///  �������
		/// </summary>
		public UInt32 inspireNum;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, playerId);
				byte[] playerNameBytes = StringHelper.StringToUTF8Bytes(playerName);
				BaseDLL.encode_string(buffer, ref pos_, playerNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, inspireNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref playerId);
				UInt16 playerNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref playerNameLen);
				byte[] playerNameBytes = new byte[playerNameLen];
				for(int i = 0; i < playerNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref playerNameBytes[i]);
				}
				playerName = StringHelper.BytesToString(playerNameBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref inspireNum);
			}
		#endregion

	}

	/// <summary>
	///  ����ս�����Ϣ
	/// </summary>
	public class GuildBattleBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  �������ID
		/// </summary>
		public byte enrollTerrId;
		/// <summary>
		///  ����ս����
		/// </summary>
		public UInt32 guildBattleScore;
		/// <summary>
		///  �Ѿ�ռ������ID
		/// </summary>
		public byte occupyTerrId;
		/// <summary>
		///  �������
		/// </summary>
		public byte inspire;
		/// <summary>
		///  �Լ��Ĺ���ս��¼
		/// </summary>
		public GuildBattleRecord[] selfGuildBattleRecord = new GuildBattleRecord[0];
		/// <summary>
		///  �����Ϣ
		/// </summary>
		public GuildTerritoryBaseInfo[] terrInfos = new GuildTerritoryBaseInfo[0];
		/// <summary>
		/// ����ս����
		/// </summary>
		public byte guildBattleType;
		/// <summary>
		/// ����ս״̬
		/// </summary>
		public byte guildBattleStatus;
		/// <summary>
		/// ����ս״̬����ʱ��
		/// </summary>
		public UInt32 guildBattleStatusEndTime;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, enrollTerrId);
				BaseDLL.encode_uint32(buffer, ref pos_, guildBattleScore);
				BaseDLL.encode_int8(buffer, ref pos_, occupyTerrId);
				BaseDLL.encode_int8(buffer, ref pos_, inspire);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)selfGuildBattleRecord.Length);
				for(int i = 0; i < selfGuildBattleRecord.Length; i++)
				{
					selfGuildBattleRecord[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)terrInfos.Length);
				for(int i = 0; i < terrInfos.Length; i++)
				{
					terrInfos[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_int8(buffer, ref pos_, guildBattleType);
				BaseDLL.encode_int8(buffer, ref pos_, guildBattleStatus);
				BaseDLL.encode_uint32(buffer, ref pos_, guildBattleStatusEndTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref enrollTerrId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref guildBattleScore);
				BaseDLL.decode_int8(buffer, ref pos_, ref occupyTerrId);
				BaseDLL.decode_int8(buffer, ref pos_, ref inspire);
				UInt16 selfGuildBattleRecordCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref selfGuildBattleRecordCnt);
				selfGuildBattleRecord = new GuildBattleRecord[selfGuildBattleRecordCnt];
				for(int i = 0; i < selfGuildBattleRecord.Length; i++)
				{
					selfGuildBattleRecord[i] = new GuildBattleRecord();
					selfGuildBattleRecord[i].decode(buffer, ref pos_);
				}
				UInt16 terrInfosCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref terrInfosCnt);
				terrInfos = new GuildTerritoryBaseInfo[terrInfosCnt];
				for(int i = 0; i < terrInfos.Length; i++)
				{
					terrInfos[i] = new GuildTerritoryBaseInfo();
					terrInfos[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_int8(buffer, ref pos_, ref guildBattleType);
				BaseDLL.decode_int8(buffer, ref pos_, ref guildBattleStatus);
				BaseDLL.decode_uint32(buffer, ref pos_, ref guildBattleStatusEndTime);
			}
		#endregion

	}

	/// <summary>
	///  ���������Ϣ
	/// </summary>
	public class GuildBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  ����ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  ������
		/// </summary>
		public string name;
		/// <summary>
		///  ����ȼ�
		/// </summary>
		public byte level;
		/// <summary>
		///  �����ʽ�
		/// </summary>
		public UInt32 fund;
		/// <summary>
		///  ��������
		/// </summary>
		public string declaration;
		/// <summary>
		///  ���ṫ��
		/// </summary>
		public string announcement;
		/// <summary>
		///  ��ɢʱ��
		/// </summary>
		public UInt32 dismissTime;
		/// <summary>
		///  ��Ա����
		/// </summary>
		public UInt16 memberNum;
		/// <summary>
		///  �᳤����
		/// </summary>
		public string leaderName;
		/// <summary>
		///  ����սʤ���齱����
		/// </summary>
		public byte winProbability;
		/// <summary>
		///  ����սʧ�ܳ齱����
		/// </summary>
		public byte loseProbability;
		/// <summary>
		///  ����ֿ����Ȩ��
		/// </summary>
		public byte storageAddPost;
		/// <summary>
		///  ����ֿ����Ȩ��
		/// </summary>
		public byte storageDelPost;
		/// <summary>
		///  ������Ϣ
		/// </summary>
		public GuildBuilding[] building = new GuildBuilding[0];
		/// <summary>
		///  ��û��������빫�����
		/// </summary>
		public byte hasRequester;
		/// <summary>
		///  Բ�������Ա��Ϣ
		/// </summary>
		public GuildTableMember[] tableMembers = new GuildTableMember[0];
		/// <summary>
		///  ����ս�����Ϣ
		/// </summary>
		public GuildBattleBaseInfo guildBattleInfo = new GuildBattleBaseInfo();

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, level);
				BaseDLL.encode_uint32(buffer, ref pos_, fund);
				byte[] declarationBytes = StringHelper.StringToUTF8Bytes(declaration);
				BaseDLL.encode_string(buffer, ref pos_, declarationBytes, (UInt16)(buffer.Length - pos_));
				byte[] announcementBytes = StringHelper.StringToUTF8Bytes(announcement);
				BaseDLL.encode_string(buffer, ref pos_, announcementBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, dismissTime);
				BaseDLL.encode_uint16(buffer, ref pos_, memberNum);
				byte[] leaderNameBytes = StringHelper.StringToUTF8Bytes(leaderName);
				BaseDLL.encode_string(buffer, ref pos_, leaderNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, winProbability);
				BaseDLL.encode_int8(buffer, ref pos_, loseProbability);
				BaseDLL.encode_int8(buffer, ref pos_, storageAddPost);
				BaseDLL.encode_int8(buffer, ref pos_, storageDelPost);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)building.Length);
				for(int i = 0; i < building.Length; i++)
				{
					building[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_int8(buffer, ref pos_, hasRequester);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)tableMembers.Length);
				for(int i = 0; i < tableMembers.Length; i++)
				{
					tableMembers[i].encode(buffer, ref pos_);
				}
				guildBattleInfo.encode(buffer, ref pos_);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref level);
				BaseDLL.decode_uint32(buffer, ref pos_, ref fund);
				UInt16 declarationLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref declarationLen);
				byte[] declarationBytes = new byte[declarationLen];
				for(int i = 0; i < declarationLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref declarationBytes[i]);
				}
				declaration = StringHelper.BytesToString(declarationBytes);
				UInt16 announcementLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref announcementLen);
				byte[] announcementBytes = new byte[announcementLen];
				for(int i = 0; i < announcementLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref announcementBytes[i]);
				}
				announcement = StringHelper.BytesToString(announcementBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dismissTime);
				BaseDLL.decode_uint16(buffer, ref pos_, ref memberNum);
				UInt16 leaderNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref leaderNameLen);
				byte[] leaderNameBytes = new byte[leaderNameLen];
				for(int i = 0; i < leaderNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref leaderNameBytes[i]);
				}
				leaderName = StringHelper.BytesToString(leaderNameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref winProbability);
				BaseDLL.decode_int8(buffer, ref pos_, ref loseProbability);
				BaseDLL.decode_int8(buffer, ref pos_, ref storageAddPost);
				BaseDLL.decode_int8(buffer, ref pos_, ref storageDelPost);
				UInt16 buildingCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref buildingCnt);
				building = new GuildBuilding[buildingCnt];
				for(int i = 0; i < building.Length; i++)
				{
					building[i] = new GuildBuilding();
					building[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_int8(buffer, ref pos_, ref hasRequester);
				UInt16 tableMembersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref tableMembersCnt);
				tableMembers = new GuildTableMember[tableMembersCnt];
				for(int i = 0; i < tableMembers.Length; i++)
				{
					tableMembers[i] = new GuildTableMember();
					tableMembers[i].decode(buffer, ref pos_);
				}
				guildBattleInfo.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ������־
	/// </summary>
	public class GuildDonateLog : Protocol.IProtocolStream
	{
		/// <summary>
		///  id
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  ����
		/// </summary>
		public string name;
		/// <summary>
		///  �������ͣ���Ӧö��GuildDonateType��
		/// </summary>
		public byte type;
		/// <summary>
		///  ����
		/// </summary>
		public byte num;
		/// <summary>
		///  ��ù���
		/// </summary>
		public UInt32 contri;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, num);
				BaseDLL.encode_uint32(buffer, ref pos_, contri);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref num);
				BaseDLL.decode_uint32(buffer, ref pos_, ref contri);
			}
		#endregion

	}

	/// <summary>
	///  ����᳤��Ϣ
	/// </summary>
	public class GuildLeaderInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  ����
		/// </summary>
		public string name;
		/// <summary>
		///  ְҵ
		/// </summary>
		public byte occu;
		/// <summary>
		///  ���
		/// </summary>
		public PlayerAvatar avatar = new PlayerAvatar();
		/// <summary>
		///  ����
		/// </summary>
		public UInt32 popularoty;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				avatar.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, popularoty);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
				avatar.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref popularoty);
			}
		#endregion

	}

	public class GuildBattleEndInfo : Protocol.IProtocolStream
	{
		public byte terrId;
		public string terrName;
		public string guildName;
		public string guildLeaderName;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, terrId);
				byte[] terrNameBytes = StringHelper.StringToUTF8Bytes(terrName);
				BaseDLL.encode_string(buffer, ref pos_, terrNameBytes, (UInt16)(buffer.Length - pos_));
				byte[] guildNameBytes = StringHelper.StringToUTF8Bytes(guildName);
				BaseDLL.encode_string(buffer, ref pos_, guildNameBytes, (UInt16)(buffer.Length - pos_));
				byte[] guildLeaderNameBytes = StringHelper.StringToUTF8Bytes(guildLeaderName);
				BaseDLL.encode_string(buffer, ref pos_, guildLeaderNameBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref terrId);
				UInt16 terrNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref terrNameLen);
				byte[] terrNameBytes = new byte[terrNameLen];
				for(int i = 0; i < terrNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref terrNameBytes[i]);
				}
				terrName = StringHelper.BytesToString(terrNameBytes);
				UInt16 guildNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref guildNameLen);
				byte[] guildNameBytes = new byte[guildNameLen];
				for(int i = 0; i < guildNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref guildNameBytes[i]);
				}
				guildName = StringHelper.BytesToString(guildNameBytes);
				UInt16 guildLeaderNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref guildLeaderNameLen);
				byte[] guildLeaderNameBytes = new byte[guildLeaderNameLen];
				for(int i = 0; i < guildLeaderNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref guildLeaderNameBytes[i]);
				}
				guildLeaderName = StringHelper.BytesToString(guildLeaderNameBytes);
			}
		#endregion

	}

	public class GuildStorageItemInfo : Protocol.IProtocolStream
	{
		public UInt64 uid;
		public UInt32 dataId;
		public UInt16 num;
		public byte str;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, uid);
				BaseDLL.encode_uint32(buffer, ref pos_, dataId);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
				BaseDLL.encode_int8(buffer, ref pos_, str);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref uid);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dataId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
				BaseDLL.decode_int8(buffer, ref pos_, ref str);
			}
		#endregion

	}

	public class GuildStorageDelItemInfo : Protocol.IProtocolStream
	{
		public UInt64 uid;
		public UInt16 num;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, uid);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref uid);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  �ֿ��¼����
	/// </summary>
	public class GuildStorageOpRecord : Protocol.IProtocolStream
	{
		public string name;
		public UInt32 opType;
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];
		public UInt32 time;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, opType);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint32(buffer, ref pos_, time);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref opType);
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new GuildStorageItemInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new GuildStorageItemInfo();
					items[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_uint32(buffer, ref pos_, ref time);
			}
		#endregion

	}

	/// <summary>
	///  ��������
	/// </summary>
	[Protocol]
	public class WorldGuildCreateReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601901;
		/// <summary>
		/// ������
		/// </summary>
		public string name;
		/// <summary>
		/// ����
		/// </summary>
		public string declaration;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				byte[] declarationBytes = StringHelper.StringToUTF8Bytes(declaration);
				BaseDLL.encode_string(buffer, ref pos_, declarationBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				UInt16 declarationLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref declarationLen);
				byte[] declarationBytes = new byte[declarationLen];
				for(int i = 0; i < declarationLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref declarationBytes[i]);
				}
				declaration = StringHelper.BytesToString(declarationBytes);
			}
		#endregion

	}

	/// <summary>
	///  �������᷵��
	/// </summary>
	[Protocol]
	public class WorldGuildCreateRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601902;
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
	///  �뿪����
	/// </summary>
	[Protocol]
	public class WorldGuildLeaveReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601903;

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
	///  �뿪���᷵��
	/// </summary>
	[Protocol]
	public class WorldGuildLeaveRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601904;
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
	///  ���빫��
	/// </summary>
	[Protocol]
	public class WorldGuildJoinReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601905;
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
	///  ���빫�᷵��
	/// </summary>
	[Protocol]
	public class WorldJoinGuildRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601906;
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
	///  ���󹫻��б�
	/// </summary>
	[Protocol]
	public class WorldGuildListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601907;
		/// <summary>
		///  ��ʼλ�� 0��ʼ
		/// </summary>
		public UInt16 start;
		/// <summary>
		///  ����
		/// </summary>
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, start);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref start);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  ���ع����б�
	/// </summary>
	[Protocol]
	public class WorldGuildListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601908;
		/// <summary>
		/// ��ʼλ��
		/// </summary>
		public UInt16 start;
		/// <summary>
		/// ����
		/// </summary>
		public UInt16 totalnum;
		/// <summary>
		/// �����б�
		/// </summary>
		public GuildEntry[] guilds = new GuildEntry[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, start);
				BaseDLL.encode_uint16(buffer, ref pos_, totalnum);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)guilds.Length);
				for(int i = 0; i < guilds.Length; i++)
				{
					guilds[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref start);
				BaseDLL.decode_uint16(buffer, ref pos_, ref totalnum);
				UInt16 guildsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref guildsCnt);
				guilds = new GuildEntry[guildsCnt];
				for(int i = 0; i < guilds.Length; i++)
				{
					guilds[i] = new GuildEntry();
					guilds[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���������빫����б�
	/// </summary>
	[Protocol]
	public class WorldGuildRequesterReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601909;

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
	///  ���������빫����б�
	/// </summary>
	[Protocol]
	public class WorldGuildRequesterRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601910;
		/// <summary>
		///  �������б�
		/// </summary>
		public GuildRequesterInfo[] requesters = new GuildRequesterInfo[0];

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
				requesters = new GuildRequesterInfo[requestersCnt];
				for(int i = 0; i < requesters.Length; i++)
				{
					requesters[i] = new GuildRequesterInfo();
					requesters[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ�µ��벿������
	/// </summary>
	[Protocol]
	public class WorldGuildNewRequester : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601911;

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
	///  �������Ա����
	/// </summary>
	[Protocol]
	public class WorldGuildProcessRequester : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601912;
		/// <summary>
		/// id(�����0��������б�)
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// ͬ�����(0:��ͬ�⣬1:ͬ��)
		/// </summary>
		public byte agree;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, agree);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref agree);
			}
		#endregion

	}

	/// <summary>
	///  ������������󷵻�
	/// </summary>
	[Protocol]
	public class WorldGuildProcessRequesterRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601913;
		public UInt32 result;
		/// <summary>
		///  �³�Ա��Ϣ
		/// </summary>
		public GuildMemberEntry entry = new GuildMemberEntry();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				entry.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				entry.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ����ְλ
	/// </summary>
	[Protocol]
	public class WorldGuildChangePostReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601914;
		/// <summary>
		/// id
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// ְλ
		/// </summary>
		public byte post;
		/// <summary>
		/// ���滻����
		/// </summary>
		public UInt64 replacerId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, post);
				BaseDLL.encode_uint64(buffer, ref pos_, replacerId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref post);
				BaseDLL.decode_uint64(buffer, ref pos_, ref replacerId);
			}
		#endregion

	}

	/// <summary>
	///  ����ְλ����
	/// </summary>
	[Protocol]
	public class WorldGuildChangePostRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601915;
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
	///  ����
	/// </summary>
	[Protocol]
	public class WorldGuildKick : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601916;
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
	///  ���˷���
	/// </summary>
	[Protocol]
	public class WorldGuildKickRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601917;
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
	///  ���߻��¼��빫�ᷢ�ͳ�ʼ����
	/// </summary>
	[Protocol]
	public class WorldGuildSyncInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601918;
		/// <summary>
		///  ���������Ϣ
		/// </summary>
		public GuildBaseInfo info = new GuildBaseInfo();

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
	///  ���󹫻��Ա�б�
	/// </summary>
	[Protocol]
	public class WorldGuildMemberListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601919;

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
	///  ���ع����Ա�б�
	/// </summary>
	[Protocol]
	public class WorldGuildMemberListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601920;
		/// <summary>
		///  ��Ա�б�
		/// </summary>
		public GuildMemberEntry[] members = new GuildMemberEntry[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)members.Length);
				for(int i = 0; i < members.Length; i++)
				{
					members[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 membersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref membersCnt);
				members = new GuildMemberEntry[membersCnt];
				for(int i = 0; i < members.Length; i++)
				{
					members[i] = new GuildMemberEntry();
					members[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  �޸Ĺ�������
	/// </summary>
	[Protocol]
	public class WorldGuildModifyDeclaration : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601921;
		public string declaration;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] declarationBytes = StringHelper.StringToUTF8Bytes(declaration);
				BaseDLL.encode_string(buffer, ref pos_, declarationBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 declarationLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref declarationLen);
				byte[] declarationBytes = new byte[declarationLen];
				for(int i = 0; i < declarationLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref declarationBytes[i]);
				}
				declaration = StringHelper.BytesToString(declarationBytes);
			}
		#endregion

	}

	/// <summary>
	///  �޸Ĺ�����
	/// </summary>
	[Protocol]
	public class WorldGuildModifyName : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601922;
		public string name;
		public UInt64 itemGUID;
		public UInt32 itemTableID;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint64(buffer, ref pos_, itemGUID);
				BaseDLL.encode_uint32(buffer, ref pos_, itemTableID);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_uint64(buffer, ref pos_, ref itemGUID);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemTableID);
			}
		#endregion

	}

	/// <summary>
	///  �޸Ĺ��ṫ��
	/// </summary>
	[Protocol]
	public class WorldGuildModifyAnnouncement : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601923;
		public string content;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] contentBytes = StringHelper.StringToUTF8Bytes(content);
				BaseDLL.encode_string(buffer, ref pos_, contentBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 contentLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref contentLen);
				byte[] contentBytes = new byte[contentLen];
				for(int i = 0; i < contentLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref contentBytes[i]);
				}
				content = StringHelper.BytesToString(contentBytes);
			}
		#endregion

	}

	/// <summary>
	///  ���͹����ʼ�
	/// </summary>
	[Protocol]
	public class WorldGuildSendMail : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601924;
		public string content;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] contentBytes = StringHelper.StringToUTF8Bytes(content);
				BaseDLL.encode_string(buffer, ref pos_, contentBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 contentLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref contentLen);
				byte[] contentBytes = new byte[contentLen];
				for(int i = 0; i < contentLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref contentBytes[i]);
				}
				content = StringHelper.BytesToString(contentBytes);
			}
		#endregion

	}

	/// <summary>
	///  ͬ�������޸���Ϣ(ʹ�����ķ�ʽͬ��)
	/// </summary>
	[Protocol]
	public class WorldGuildSyncStreamInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601925;

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
	///  ���ͨ�ò�������
	/// </summary>
	[Protocol]
	public class WorldGuildOperRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601926;
		/// <summary>
		///  �������ͣ���Ӧö��GuildOperation��
		/// </summary>
		public byte type;
		/// <summary>
		///  ���
		/// </summary>
		public UInt32 result;
		/// <summary>
		///  ����1
		/// </summary>
		public UInt32 param;
		/// <summary>
		///  ����2
		/// </summary>
		public UInt64 param2;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, param);
				BaseDLL.encode_uint64(buffer, ref pos_, param2);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param);
				BaseDLL.decode_uint64(buffer, ref pos_, ref param2);
			}
		#endregion

	}

	/// <summary>
	///  ��������
	/// </summary>
	[Protocol]
	public class WorldGuildUpgradeBuilding : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601927;
		/// <summary>
		///  �������ͣ���Ӧö��GuildBuildingType��
		/// </summary>
		public byte type;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
			}
		#endregion

	}

	/// <summary>
	///  �������
	/// </summary>
	[Protocol]
	public class WorldGuildDonateReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601928;
		/// <summary>
		///  �������ͣ���Ӧö��GuildDonateType��
		/// </summary>
		public byte type;
		/// <summary>
		///  ����
		/// </summary>
		public byte num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  ���������־
	/// </summary>
	[Protocol]
	public class WorldGuildDonateLogReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601929;

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
	///  ���ؾ�����־
	/// </summary>
	[Protocol]
	public class WorldGuildDonateLogRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601930;
		public GuildDonateLog[] logs = new GuildDonateLog[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)logs.Length);
				for(int i = 0; i < logs.Length; i++)
				{
					logs[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 logsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref logsCnt);
				logs = new GuildDonateLog[logsCnt];
				for(int i = 0; i < logs.Length; i++)
				{
					logs[i] = new GuildDonateLog();
					logs[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ��������
	/// </summary>
	[Protocol]
	public class WorldGuildUpgradeSkill : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601931;
		/// <summary>
		///  ����id
		/// </summary>
		public UInt16 skillId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, skillId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref skillId);
			}
		#endregion

	}

	/// <summary>
	///  ��ɢ����
	/// </summary>
	[Protocol]
	public class WorldGuildDismissReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601932;

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
	///  ȡ����ɢ����
	/// </summary>
	[Protocol]
	public class WorldGuildCancelDismissReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601933;

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
	///  ����᳤��Ϣ
	/// </summary>
	[Protocol]
	public class WorldGuildLeaderInfoReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601934;

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
	///  ���ػ᳤��Ϣ
	/// </summary>
	[Protocol]
	public class WorldGuildLeaderInfoRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601935;
		public GuildLeaderInfo info = new GuildLeaderInfo();

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
	///  ����Ĥ��
	/// </summary>
	[Protocol]
	public class WorldGuildOrzReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601936;
		/// <summary>
		///  Ĥ�����ͣ���Ӧö�٣�GuildOrzType��
		/// </summary>
		public byte type;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
			}
		#endregion

	}

	/// <summary>
	///  �������Բ������
	/// </summary>
	[Protocol]
	public class WorldGuildTableJoinReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601937;
		/// <summary>
		///  λ��
		/// </summary>
		public byte seat;
		/// <summary>
		///  �ǲ���Э��
		/// </summary>
		public byte type;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				BaseDLL.encode_int8(buffer, ref pos_, type);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ�ͻ������µ�Բ�������Ա
	/// </summary>
	[Protocol]
	public class WorldGuildTableNewMember : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601938;
		public GuildTableMember member = new GuildTableMember();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				member.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				member.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ�ͻ���ɾ��Բ�������Ա
	/// </summary>
	[Protocol]
	public class WorldGuildTableDelMember : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601939;
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
	///  ֪ͨ�ͻ��˵�Բ���������
	/// </summary>
	[Protocol]
	public class WorldGuildTableFinish : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601940;

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
	///  �����ԷѺ��
	/// </summary>
	[Protocol]
	public class WorldGuildPayRedPacketReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601941;
		/// <summary>
		///  ��Դ
		/// </summary>
		public UInt16 reason;
		/// <summary>
		///  ����
		/// </summary>
		public string name;
		/// <summary>
		///  ����
		/// </summary>
		public byte num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, reason);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref reason);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  ����һ�
	/// </summary>
	[Protocol]
	public class SceneGuildExchangeReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501901;

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
	///  ���󹫻�ս����
	/// </summary>
	[Protocol]
	public class WorldGuildBattleReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601942;
		public byte terrId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, terrId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref terrId);
			}
		#endregion

	}

	/// <summary>
	///  ���󹫻�ս����
	/// </summary>
	[Protocol]
	public class WorldGuildBattleRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601943;
		public UInt32 result;
		public byte terrId;
		public UInt32 enrollSize;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, terrId);
				BaseDLL.encode_uint32(buffer, ref pos_, enrollSize);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref terrId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref enrollSize);
			}
		#endregion

	}

	/// <summary>
	///  �������
	/// </summary>
	[Protocol]
	public class WorldGuildBattleInspireReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601944;

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
	///  ���践��
	/// </summary>
	[Protocol]
	public class WorldGuildBattleInspireRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601945;
		public UInt32 result;
		public byte inspire;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, inspire);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref inspire);
			}
		#endregion

	}

	/// <summary>
	///  ������ȡ����
	/// </summary>
	[Protocol]
	public class WorldGuildBattleReceiveReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601946;
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

	/// <summary>
	///  ��ȡ��������
	/// </summary>
	[Protocol]
	public class WorldGuildBattleReceiveRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601947;
		public UInt32 result;
		public byte boxId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, boxId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref boxId);
			}
		#endregion

	}

	/// <summary>
	///  �������ս����¼
	/// </summary>
	[Protocol]
	public class WorldGuildBattleRecordReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601948;
		public byte isSelf;
		public Int32 startIndex;
		public UInt32 count;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, isSelf);
				BaseDLL.encode_int32(buffer, ref pos_, startIndex);
				BaseDLL.encode_uint32(buffer, ref pos_, count);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref isSelf);
				BaseDLL.decode_int32(buffer, ref pos_, ref startIndex);
				BaseDLL.decode_uint32(buffer, ref pos_, ref count);
			}
		#endregion

	}

	/// <summary>
	///  ���ս����¼����
	/// </summary>
	[Protocol]
	public class WorldGuildBattleRecordRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601949;
		public UInt32 result;
		public GuildBattleRecord[] records = new GuildBattleRecord[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)records.Length);
				for(int i = 0; i < records.Length; i++)
				{
					records[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 recordsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref recordsCnt);
				records = new GuildBattleRecord[recordsCnt];
				for(int i = 0; i < records.Length; i++)
				{
					records[i] = new GuildBattleRecord();
					records[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���ս����¼ͬ��
	/// </summary>
	[Protocol]
	public class WorldGuildBattleRecordSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601950;
		public GuildBattleRecord record = new GuildBattleRecord();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				record.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				record.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ���������Ϣ
	/// </summary>
	[Protocol]
	public class WorldGuildBattleTerritoryReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601951;
		public byte terrId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, terrId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref terrId);
			}
		#endregion

	}

	/// <summary>
	///  ���������Ϣ
	/// </summary>
	[Protocol]
	public class WorldGuildBattleTerritoryRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601952;
		public UInt32 result;
		public GuildTerritoryBaseInfo info = new GuildTerritoryBaseInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				info.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				info.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ����ս������
	/// </summary>
	[Protocol]
	public class WorldGuildBattleRaceEnd : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601953;
		public byte result;
		public UInt32 oldScore;
		public UInt32 newScore;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, oldScore);
				BaseDLL.encode_uint32(buffer, ref pos_, newScore);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldScore);
				BaseDLL.decode_uint32(buffer, ref pos_, ref newScore);
			}
		#endregion

	}

	/// <summary>
	///  ����ս����
	/// </summary>
	[Protocol]
	public class WorldGuildBattleEnd : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601954;
		public GuildBattleEndInfo[] info = new GuildBattleEndInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)info.Length);
				for(int i = 0; i < info.Length; i++)
				{
					info[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 infoCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref infoCnt);
				info = new GuildBattleEndInfo[infoCnt];
				for(int i = 0; i < info.Length; i++)
				{
					info[i] = new GuildBattleEndInfo();
					info[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ��������������
	/// </summary>
	[Protocol]
	public class WorldGuildBattleSelfSortListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601955;

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
	///  ����������������Ӧ
	/// </summary>
	[Protocol]
	public class WorldGuildBattleSelfSortListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601956;
		public UInt32 result;
		public UInt32 memberRanking;
		public UInt32 guildRanking;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, memberRanking);
				BaseDLL.encode_uint32(buffer, ref pos_, guildRanking);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref memberRanking);
				BaseDLL.decode_uint32(buffer, ref pos_, ref guildRanking);
			}
		#endregion

	}

	/// <summary>
	///  ��������֪ͨ���б�����������빫��
	/// </summary>
	[Protocol]
	public class WorldGuildInviteNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601957;
		/// <summary>
		///  ������ID
		/// </summary>
		public UInt64 inviterId;
		/// <summary>
		///  ����������
		/// </summary>
		public string inviterName;
		/// <summary>
		///  ����ID
		/// </summary>
		public UInt64 guildId;
		/// <summary>
		///  ������
		/// </summary>
		public string guildName;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, inviterId);
				byte[] inviterNameBytes = StringHelper.StringToUTF8Bytes(inviterName);
				BaseDLL.encode_string(buffer, ref pos_, inviterNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint64(buffer, ref pos_, guildId);
				byte[] guildNameBytes = StringHelper.StringToUTF8Bytes(guildName);
				BaseDLL.encode_string(buffer, ref pos_, guildNameBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref inviterId);
				UInt16 inviterNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref inviterNameLen);
				byte[] inviterNameBytes = new byte[inviterNameLen];
				for(int i = 0; i < inviterNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref inviterNameBytes[i]);
				}
				inviterName = StringHelper.BytesToString(inviterNameBytes);
				BaseDLL.decode_uint64(buffer, ref pos_, ref guildId);
				UInt16 guildNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref guildNameLen);
				byte[] guildNameBytes = new byte[guildNameLen];
				for(int i = 0; i < guildNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref guildNameBytes[i]);
				}
				guildName = StringHelper.BytesToString(guildNameBytes);
			}
		#endregion

	}

	/// <summary>
	///  ͬ������ս״̬
	/// </summary>
	[Protocol]
	public class WorldGuildBattleStatusSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601958;
		/// <summary>
		///  ����
		/// </summary>
		public byte type;
		/// <summary>
		///  ״̬
		/// </summary>
		public byte status;
		/// <summary>
		///  ״̬����ʱ��
		/// </summary>
		public UInt32 time;
		/// <summary>
		///  ����ս������Ϣ
		/// </summary>
		public GuildBattleEndInfo[] endInfo = new GuildBattleEndInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, status);
				BaseDLL.encode_uint32(buffer, ref pos_, time);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)endInfo.Length);
				for(int i = 0; i < endInfo.Length; i++)
				{
					endInfo[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
				BaseDLL.decode_uint32(buffer, ref pos_, ref time);
				UInt16 endInfoCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref endInfoCnt);
				endInfo = new GuildBattleEndInfo[endInfoCnt];
				for(int i = 0; i < endInfo.Length; i++)
				{
					endInfo[i] = new GuildBattleEndInfo();
					endInfo[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���󹫻���ս����
	/// </summary>
	[Protocol]
	public class WorldGuildChallengeReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601959;
		public byte terrId;
		public UInt32 itemId;
		public UInt32 itemNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, terrId);
				BaseDLL.encode_uint32(buffer, ref pos_, itemId);
				BaseDLL.encode_uint32(buffer, ref pos_, itemNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref terrId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemNum);
			}
		#endregion

	}

	/// <summary>
	///  ���ع�����ս����
	/// </summary>
	[Protocol]
	public class WorldGuildChallengeRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601960;
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
	///  ���󹫻���ս��Ϣ
	/// </summary>
	[Protocol]
	public class WorldGuildChallengeInfoReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601961;

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
	///  ������ս��Ϣͬ��
	/// </summary>
	[Protocol]
	public class WorldGuildChallengeInfoSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601962;
		public GuildTerritoryBaseInfo info = new GuildTerritoryBaseInfo();
		public UInt64 enrollGuildId;
		public string enrollGuildName;
		public string enrollGuildleaderName;
		public byte enrollGuildLevel;
		public UInt32 itemId;
		public UInt32 itemNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				info.encode(buffer, ref pos_);
				BaseDLL.encode_uint64(buffer, ref pos_, enrollGuildId);
				byte[] enrollGuildNameBytes = StringHelper.StringToUTF8Bytes(enrollGuildName);
				BaseDLL.encode_string(buffer, ref pos_, enrollGuildNameBytes, (UInt16)(buffer.Length - pos_));
				byte[] enrollGuildleaderNameBytes = StringHelper.StringToUTF8Bytes(enrollGuildleaderName);
				BaseDLL.encode_string(buffer, ref pos_, enrollGuildleaderNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, enrollGuildLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, itemId);
				BaseDLL.encode_uint32(buffer, ref pos_, itemNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				info.decode(buffer, ref pos_);
				BaseDLL.decode_uint64(buffer, ref pos_, ref enrollGuildId);
				UInt16 enrollGuildNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref enrollGuildNameLen);
				byte[] enrollGuildNameBytes = new byte[enrollGuildNameLen];
				for(int i = 0; i < enrollGuildNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref enrollGuildNameBytes[i]);
				}
				enrollGuildName = StringHelper.BytesToString(enrollGuildNameBytes);
				UInt16 enrollGuildleaderNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref enrollGuildleaderNameLen);
				byte[] enrollGuildleaderNameBytes = new byte[enrollGuildleaderNameLen];
				for(int i = 0; i < enrollGuildleaderNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref enrollGuildleaderNameBytes[i]);
				}
				enrollGuildleaderName = StringHelper.BytesToString(enrollGuildleaderNameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref enrollGuildLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemNum);
			}
		#endregion

	}

	/// <summary>
	///  ���󹫻�ս������Ϣ
	/// </summary>
	[Protocol]
	public class WorldGuildBattleInspireInfoReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601963;

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
	///  ���ع���ս������Ϣ
	/// </summary>
	[Protocol]
	public class WorldGuildBattleInspireInfoRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601964;
		public UInt32 result;
		/// <summary>
		///  ���ID
		/// </summary>
		public byte terrId;
		/// <summary>
		///  ������Ϣ
		/// </summary>
		public GuildBattleInspireInfo[] inspireInfos = new GuildBattleInspireInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, terrId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)inspireInfos.Length);
				for(int i = 0; i < inspireInfos.Length; i++)
				{
					inspireInfos[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref terrId);
				UInt16 inspireInfosCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref inspireInfosCnt);
				inspireInfos = new GuildBattleInspireInfo[inspireInfosCnt];
				for(int i = 0; i < inspireInfos.Length; i++)
				{
					inspireInfos[i] = new GuildBattleInspireInfo();
					inspireInfos[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���󹫻�ֿ�����
	/// </summary>
	[Protocol]
	public class WorldGuildStorageSettingReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601965;
		public byte type;
		public UInt32 value;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, value);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref value);
			}
		#endregion

	}

	/// <summary>
	///  ���ع���ֿ�����
	/// </summary>
	[Protocol]
	public class WorldGuildStorageSettingRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601966;
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
	///  ���󹫻�ս�齱
	/// </summary>
	[Protocol]
	public class WorldGuildBattleLotteryReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601967;

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
	///  ���ع���ս�齱
	/// </summary>
	[Protocol]
	public class WorldGuildBattleLotteryRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601968;
		public UInt32 result;
		public UInt32 contribution;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, contribution);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref contribution);
			}
		#endregion

	}

	/// <summary>
	///  ���󹫻�ֿ��б�
	/// </summary>
	[Protocol]
	public class WorldGuildStorageListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601969;

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
	///  ���ع���ֿ��б�
	/// </summary>
	[Protocol]
	public class WorldGuildStorageListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601970;
		public UInt32 result;
		public UInt32 maxSize;
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];
		public GuildStorageOpRecord[] itemRecords = new GuildStorageOpRecord[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, maxSize);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)itemRecords.Length);
				for(int i = 0; i < itemRecords.Length; i++)
				{
					itemRecords[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref maxSize);
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new GuildStorageItemInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new GuildStorageItemInfo();
					items[i].decode(buffer, ref pos_);
				}
				UInt16 itemRecordsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemRecordsCnt);
				itemRecords = new GuildStorageOpRecord[itemRecordsCnt];
				for(int i = 0; i < itemRecords.Length; i++)
				{
					itemRecords[i] = new GuildStorageOpRecord();
					itemRecords[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ͬ���ֿ���Ʒ����
	/// </summary>
	[Protocol]
	public class WorldGuildStorageItemSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601971;
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];
		public GuildStorageOpRecord[] records = new GuildStorageOpRecord[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)records.Length);
				for(int i = 0; i < records.Length; i++)
				{
					records[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new GuildStorageItemInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new GuildStorageItemInfo();
					items[i].decode(buffer, ref pos_);
				}
				UInt16 recordsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref recordsCnt);
				records = new GuildStorageOpRecord[recordsCnt];
				for(int i = 0; i < records.Length; i++)
				{
					records[i] = new GuildStorageOpRecord();
					records[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ������빫��ֿ�
	/// </summary>
	[Protocol]
	public class WorldGuildAddStorageReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601972;
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new GuildStorageItemInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new GuildStorageItemInfo();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���ط��빫��ֿ�
	/// </summary>
	[Protocol]
	public class WorldGuildAddStorageRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601973;
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
	///  ����ɾ������ֿ���Ʒ
	/// </summary>
	[Protocol]
	public class WorldGuildDelStorageReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601974;
		public GuildStorageDelItemInfo[] items = new GuildStorageDelItemInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new GuildStorageDelItemInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new GuildStorageDelItemInfo();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ����ɾ������ֿ���Ʒ
	/// </summary>
	[Protocol]
	public class WorldGuildDelStorageRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601975;
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
	///  �鿴�ֿ���Ʒ����
	/// </summary>
	[Protocol]
	public class WorldWatchGuildStorageItemReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601976;
		public UInt64 uid;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, uid);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref uid);
			}
		#endregion

	}

}
