using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	///  公会职务
	/// </summary>
	public enum GuildPost
	{
		/// <summary>
		///  无效值
		/// </summary>
		GUILD_INVALID = 0,
		/// <summary>
		///  普通成员
		/// </summary>
		GUILD_POST_NORMAL = 1,
		/// <summary>
		///  精英
		/// </summary>
		GUILD_POST_ELITE = 2,
		/// <summary>
		///  长老
		/// </summary>
		GUILD_POST_ELDER = 11,
		/// <summary>
		///  副会长
		/// </summary>
		GUILD_POST_ASSISTANT = 12,
		/// <summary>
		///  会长
		/// </summary>
		GUILD_POST_LEADER = 13,
	}

	/// <summary>
	///  公会属性
	/// </summary>
	public enum GuildAttr
	{
		/// <summary>
		///  无效属性
		/// </summary>
		GA_INVALID = 0,
		/// <summary>
		///  名字	string	
		/// </summary>
		GA_NAME = 1,
		/// <summary>
		///  等级	UInt8	
		/// </summary>
		GA_LEVEL = 2,
		/// <summary>
		///  宣言 string
		/// </summary>
		GA_DECLARATION = 3,
		/// <summary>
		///  部落资金 Int32
		/// </summary>
		GA_FUND = 4,
		/// <summary>
		///  公告 string
		/// </summary>
		GA_ANNOUNCEMENT = 5,
		/// <summary>
		///  公会建筑 GuildBuilding
		/// </summary>
		GA_BUILDING = 6,
		/// <summary>
		///  解散时间 UInt32
		/// </summary>
		GA_DISMISS_TIME = 7,
		/// <summary>
		///  成员数量 UInt16
		/// </summary>
		GA_MEMBER_NUM = 8,
		/// <summary>
		///  会长名字 string
		/// </summary>
		GA_LEADER_NAME = 9,
		/// <summary>
		///  报名领地ID UInt8
		/// </summary>
		GA_ENROLL_TERRID = 10,
		/// <summary>
		///  公会战分数 UInt32
		/// </summary>
		GA_BATTLE_SCORE = 11,
		/// <summary>
		///  公会占领领地 UInt8
		/// </summary>
		GA_OCCUPY_TERRID = 12,
		/// <summary>
		///  公会战鼓舞次数 UInt8
		/// </summary>
		GA_INSPIRE = 13,
		/// <summary>
		///  公会战胜利抽奖几率 UInt8
		/// </summary>
		GA_WIN_PROBABILITY = 14,
		/// <summary>
		///  公会战失败抽奖几率 UInt8
		/// </summary>
		GA_LOSE_PROBABILITY = 15,
		/// <summary>
		///  公会战仓库放入物品 UInt8
		/// </summary>
		GA_STORAGE_ADD_POST = 16,
		/// <summary>
		///  公会战仓库删除物品 UInt8
		/// </summary>
		GA_STORAGE_DEL_POST = 17,
	}

	/// <summary>
	/// 公会战类型
	/// </summary>
	public enum GuildBattleType
	{
		/// <summary>
		///  无效
		/// </summary>
		GBT_INVALID = 0,
		/// <summary>
		///  普通
		/// </summary>
		GBT_NORMAL = 1,
		/// <summary>
		///  宣战
		/// </summary>
		GBT_CHALLENGE = 2,
	}

	/// <summary>
	///  公会战状态
	/// </summary>
	public enum GuildBattleStatus
	{
		/// <summary>
		///  无
		/// </summary>
		GBS_INVALID = 0,
		/// <summary>
		///  报名
		/// </summary>
		GBS_ENROLL = 1,
		/// <summary>
		///  准备
		/// </summary>
		GBS_PREPARE = 2,
		/// <summary>
		///  战斗
		/// </summary>
		GBS_BATTLE = 3,
		/// <summary>
		///  领奖
		/// </summary>
		GBS_REWARD = 4,
		GBS_MAX = 5,
	}

	/// <summary>
	///  公会建筑类型
	/// </summary>
	public enum GuildBuildingType
	{
		/// <summary>
		///  主城
		/// </summary>
		MAIN = 0,
		/// <summary>
		///  商店
		/// </summary>
		SHOP = 1,
		/// <summary>
		///  圆桌会议
		/// </summary>
		TABLE = 2,
		/// <summary>
		///  地下城
		/// </summary>
		DUNGEON = 3,
		/// <summary>
		///  雕像
		/// </summary>
		STATUE = 4,
		/// <summary>
		///  战争坊
		/// </summary>
		BATTLE = 5,
		/// <summary>
		///  福利社
		/// </summary>
		WELFARE = 6,
	}

	/// <summary>
	///  公会操作类型
	/// </summary>
	public enum GuildOperation
	{
		/// <summary>
		///  修改公会宣言
		/// </summary>
		MODIFY_DECLAR = 0,
		/// <summary>
		///  修改公会名
		/// </summary>
		MODIFY_NAME = 1,
		/// <summary>
		///  修改公会公告
		/// </summary>
		MODIFY_ANNOUNCE = 2,
		/// <summary>
		///  发送公会邮件
		/// </summary>
		SEND_MAIL = 3,
		/// <summary>
		///  升级建筑
		/// </summary>
		UPGRADE_BUILDING = 4,
		/// <summary>
		///  捐献
		/// </summary>
		DONATE = 5,
		/// <summary>
		///  兑换
		/// </summary>
		EXCHANGE = 6,
		/// <summary>
		///  升级技能
		/// </summary>
		UPGRADE_SKILL = 7,
		/// <summary>
		///  解散工会
		/// </summary>
		DISMISS = 8,
		/// <summary>
		///  取消解散工会
		/// </summary>
		CANCEL_DISMISS = 9,
		/// <summary>
		///  膜拜
		/// </summary>
		ORZ = 10,
		/// <summary>
		///  圆桌会议
		/// </summary>
		TABLE = 11,
		/// <summary>
		///  自费红包
		/// </summary>
		PAY_REDPACKET = 12,
	}

	/// <summary>
	///  捐献
	/// </summary>
	public enum GuildDonateType
	{
		/// <summary>
		///  金币捐献
		/// </summary>
		GOLD = 0,
		/// <summary>
		///  点劵捐献
		/// </summary>
		POINT = 1,
	}

	/// <summary>
	///  膜拜类型
	/// </summary>
	public enum GuildOrzType
	{
		/// <summary>
		///  普通膜拜
		/// </summary>
		GUILD_ORZ_LOW = 0,
		/// <summary>
		///  中级膜拜
		/// </summary>
		GUILD_ORZ_MID = 1,
		/// <summary>
		///  高级膜拜
		/// </summary>
		GUILD_ORZ_HIGH = 2,
	}

	/// <summary>
	///  公会仓库设置类型
	/// </summary>
	public enum GuildStorageSetting
	{
		GUILD_POST_INVALID = 0,
		/// <summary>
		///  胜利抽奖几率
		/// </summary>
		GSS_WIN_PROBABILITY = 1,
		/// <summary>
		///  失败抽奖几率
		/// </summary>
		GSS_LOSE_PROBABILITY = 2,
		/// <summary>
		///  仓库增加权限
		/// </summary>
		GSS_STORAGE_ADD_POST = 3,
		/// <summary>
		///  仓库删除权限
		/// </summary>
		GSS_STORAGE_DEL_POST = 4,
		GSS_MAX = 5,
	}

	/// <summary>
	///  公会成员抽奖状态
	/// </summary>
	public enum GuildBattleLotteryStatus
	{
		/// <summary>
		///  无效
		/// </summary>
		GBLS_INVALID = 0,
		/// <summary>
		///  不能抽奖
		/// </summary>
		GBLS_NOT = 1,
		/// <summary>
		///  可以抽奖
		/// </summary>
		GBLS_CAN = 2,
		/// <summary>
		///  已经抽奖
		/// </summary>
		GBLS_FIN = 3,
		GBLS_MAX = 4,
	}

	public enum GuildStorageOpType
	{
		GSOT_NONE = 0,
		/// <summary>
		///  获得
		/// </summary>
		GSOT_GET = 1,
		/// <summary>
		///  存入
		/// </summary>
		GSOT_PUT = 2,
		/// <summary>
		///  购买并存入
		/// </summary>
		GSOT_BUYPUT = 3,
	}

	/// <summary>
	///  公会信息
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
		///  公会等级
		/// </summary>
		public byte level;
		/// <summary>
		///  公会人数
		/// </summary>
		public byte memberNum;
		/// <summary>
		///  会长名字
		/// </summary>
		public string leaderName;
		/// <summary>
		///  宣言
		/// </summary>
		public string declaration;
		/// <summary>
		///  是否已经申请
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
	///  公会成员
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
		///  等级
		/// </summary>
		public UInt16 level;
		/// <summary>
		///  职业
		/// </summary>
		public byte occu;
		/// <summary>
		///  职务(对应枚举GuildPost)
		/// </summary>
		public byte post;
		/// <summary>
		///  历史贡献
		/// </summary>
		public UInt32 contribution;
		/// <summary>
		///  离线时间(0代表在线)
		/// </summary>
		public UInt32 logoutTime;
		/// <summary>
		///  活跃度
		/// </summary>
		public UInt32 activeDegree;
		/// <summary>
		/// vip等级
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
	///  公会请求者信息
	/// </summary>
	public class GuildRequesterInfo : Protocol.IProtocolStream
	{
		/// <summary>
		/// id
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// 名字
		/// </summary>
		public string name;
		/// <summary>
		/// 等级
		/// </summary>
		public UInt16 level;
		/// <summary>
		/// 职业
		/// </summary>
		public byte occu;
		/// <summary>
		/// vip等级
		/// </summary>
		public byte vipLevel;
		/// <summary>
		/// 申请时间
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
	///  公会建筑
	/// </summary>
	public class GuildBuilding : Protocol.IProtocolStream
	{
		/// <summary>
		///  建筑类型（对应枚举GuildBuildingType）
		/// </summary>
		public byte type;
		/// <summary>
		///  等级
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
	///  圆桌会议成员信息
	/// </summary>
	public class GuildTableMember : Protocol.IProtocolStream
	{
		/// <summary>
		///  角色ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  等级
		/// </summary>
		public UInt16 level;
		/// <summary>
		///  职业
		/// </summary>
		public byte occu;
		/// <summary>
		///  名字
		/// </summary>
		public string name;
		/// <summary>
		///  位置
		/// </summary>
		public byte seat;
		/// <summary>
		///  参与类型
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
	///  公会战成员
	/// </summary>
	public class GuildBattleMember : Protocol.IProtocolStream
	{
		/// <summary>
		///  ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// 名字
		/// </summary>
		public string name;
		/// <summary>
		///  连胜数
		/// </summary>
		public byte winStreak;
		/// <summary>
		///  获得积分
		/// </summary>
		public UInt16 gotScore;
		/// <summary>
		///  总积分
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
		///  胜利者
		/// </summary>
		public GuildBattleMember winner = new GuildBattleMember();
		/// <summary>
		///  失败者
		/// </summary>
		public GuildBattleMember loser = new GuildBattleMember();
		/// <summary>
		///  时间
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
		///  领地ID
		/// </summary>
		public byte terrId;
		/// <summary>
		///  占领公会名称
		/// </summary>
		public string guildName;
		/// <summary>
		///  已经报名数量
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
		///  玩家ID
		/// </summary>
		public UInt64 playerId;
		/// <summary>
		///  玩家名字
		/// </summary>
		public string playerName;
		/// <summary>
		///  鼓舞次数
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
	///  公会战相关信息
	/// </summary>
	public class GuildBattleBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  报名领地ID
		/// </summary>
		public byte enrollTerrId;
		/// <summary>
		///  公会战积分
		/// </summary>
		public UInt32 guildBattleScore;
		/// <summary>
		///  已经占领的领地ID
		/// </summary>
		public byte occupyTerrId;
		/// <summary>
		///  鼓舞次数
		/// </summary>
		public byte inspire;
		/// <summary>
		///  自己的公会战记录
		/// </summary>
		public GuildBattleRecord[] selfGuildBattleRecord = new GuildBattleRecord[0];
		/// <summary>
		///  领地信息
		/// </summary>
		public GuildTerritoryBaseInfo[] terrInfos = new GuildTerritoryBaseInfo[0];
		/// <summary>
		/// 公会战类型
		/// </summary>
		public byte guildBattleType;
		/// <summary>
		/// 公会战状态
		/// </summary>
		public byte guildBattleStatus;
		/// <summary>
		/// 公会战状态结束时间
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
	///  公会基础信息
	/// </summary>
	public class GuildBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  公会ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  公会名
		/// </summary>
		public string name;
		/// <summary>
		///  公会等级
		/// </summary>
		public byte level;
		/// <summary>
		///  公会资金
		/// </summary>
		public UInt32 fund;
		/// <summary>
		///  公会宣言
		/// </summary>
		public string declaration;
		/// <summary>
		///  公会公告
		/// </summary>
		public string announcement;
		/// <summary>
		///  解散时间
		/// </summary>
		public UInt32 dismissTime;
		/// <summary>
		///  成员数量
		/// </summary>
		public UInt16 memberNum;
		/// <summary>
		///  会长名字
		/// </summary>
		public string leaderName;
		/// <summary>
		///  公会战胜利抽奖几率
		/// </summary>
		public byte winProbability;
		/// <summary>
		///  公会战失败抽奖几率
		/// </summary>
		public byte loseProbability;
		/// <summary>
		///  公会仓库放入权限
		/// </summary>
		public byte storageAddPost;
		/// <summary>
		///  公会仓库放入权限
		/// </summary>
		public byte storageDelPost;
		/// <summary>
		///  建筑信息
		/// </summary>
		public GuildBuilding[] building = new GuildBuilding[0];
		/// <summary>
		///  有没有申请加入公会的人
		/// </summary>
		public byte hasRequester;
		/// <summary>
		///  圆桌会议成员信息
		/// </summary>
		public GuildTableMember[] tableMembers = new GuildTableMember[0];
		/// <summary>
		///  公会战相关信息
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
	///  捐献日志
	/// </summary>
	public class GuildDonateLog : Protocol.IProtocolStream
	{
		/// <summary>
		///  id
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  名字
		/// </summary>
		public string name;
		/// <summary>
		///  捐献类型（对应枚举GuildDonateType）
		/// </summary>
		public byte type;
		/// <summary>
		///  次数
		/// </summary>
		public byte num;
		/// <summary>
		///  获得贡献
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
	///  公会会长信息
	/// </summary>
	public class GuildLeaderInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  名字
		/// </summary>
		public string name;
		/// <summary>
		///  职业
		/// </summary>
		public byte occu;
		/// <summary>
		///  外观
		/// </summary>
		public PlayerAvatar avatar = new PlayerAvatar();
		/// <summary>
		///  人气
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
	///  仓库记录类型
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
	///  创建公会
	/// </summary>
	[Protocol]
	public class WorldGuildCreateReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601901;
		/// <summary>
		/// 公会名
		/// </summary>
		public string name;
		/// <summary>
		/// 宣言
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
	///  创建公会返回
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
	///  离开公会
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
	///  离开公会返回
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
	///  加入公会
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
	///  加入公会返回
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
	///  请求公会列表
	/// </summary>
	[Protocol]
	public class WorldGuildListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601907;
		/// <summary>
		///  开始位置 0开始
		/// </summary>
		public UInt16 start;
		/// <summary>
		///  数量
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
	///  返回公会列表
	/// </summary>
	[Protocol]
	public class WorldGuildListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601908;
		/// <summary>
		/// 开始位置
		/// </summary>
		public UInt16 start;
		/// <summary>
		/// 总数
		/// </summary>
		public UInt16 totalnum;
		/// <summary>
		/// 部落列表
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
	///  请求申请入公会的列表
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
	///  返回申请入公会的列表
	/// </summary>
	[Protocol]
	public class WorldGuildRequesterRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601910;
		/// <summary>
		///  申请人列表
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
	///  通知新的入部落请求
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
	///  处理公会成员请求
	/// </summary>
	[Protocol]
	public class WorldGuildProcessRequester : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601912;
		/// <summary>
		/// id(如果是0代表清空列表)
		/// </summary>
		public UInt64 id;
		/// <summary>
		/// 同意进入(0:不同意，1:同意)
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
	///  处理公会加入请求返回
	/// </summary>
	[Protocol]
	public class WorldGuildProcessRequesterRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601913;
		public UInt32 result;
		/// <summary>
		///  新成员信息
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
	///  任命职位
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
		/// 职位
		/// </summary>
		public byte post;
		/// <summary>
		/// 被替换的人
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
	///  任命职位返回
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
	///  踢人
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
	///  踢人返回
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
	///  上线或新加入公会发送初始数据
	/// </summary>
	[Protocol]
	public class WorldGuildSyncInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601918;
		/// <summary>
		///  公会基础信息
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
	///  请求公会成员列表
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
	///  返回公会成员列表
	/// </summary>
	[Protocol]
	public class WorldGuildMemberListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601920;
		/// <summary>
		///  成员列表
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
	///  修改公会宣言
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
	///  修改公会名
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
	///  修改公会公告
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
	///  发送公会邮件
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
	///  同步公会修改信息(使用流的方式同步)
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
	///  帮会通用操作返回
	/// </summary>
	[Protocol]
	public class WorldGuildOperRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601926;
		/// <summary>
		///  操作类型（对应枚举GuildOperation）
		/// </summary>
		public byte type;
		/// <summary>
		///  结果
		/// </summary>
		public UInt32 result;
		/// <summary>
		///  参数1
		/// </summary>
		public UInt32 param;
		/// <summary>
		///  参数2
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
	///  升级建筑
	/// </summary>
	[Protocol]
	public class WorldGuildUpgradeBuilding : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601927;
		/// <summary>
		///  建筑类型（对应枚举GuildBuildingType）
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
	///  请求捐赠
	/// </summary>
	[Protocol]
	public class WorldGuildDonateReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601928;
		/// <summary>
		///  捐赠类型（对应枚举GuildDonateType）
		/// </summary>
		public byte type;
		/// <summary>
		///  次数
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
	///  请求捐赠日志
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
	///  返回捐赠日志
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
	///  升级技能
	/// </summary>
	[Protocol]
	public class WorldGuildUpgradeSkill : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601931;
		/// <summary>
		///  技能id
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
	///  解散公会
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
	///  取消解散公会
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
	///  请求会长信息
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
	///  返回会长信息
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
	///  请求膜拜
	/// </summary>
	[Protocol]
	public class WorldGuildOrzReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601936;
		/// <summary>
		///  膜拜类型，对应枚举（GuildOrzType）
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
	///  请求加入圆桌会议
	/// </summary>
	[Protocol]
	public class WorldGuildTableJoinReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601937;
		/// <summary>
		///  位置
		/// </summary>
		public byte seat;
		/// <summary>
		///  是不是协助
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
	///  通知客户端有新的圆桌会议成员
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
	///  通知客户端删除圆桌会议成员
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
	///  通知客户端的圆桌会议完成
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
	///  请求发自费红包
	/// </summary>
	[Protocol]
	public class WorldGuildPayRedPacketReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601941;
		/// <summary>
		///  来源
		/// </summary>
		public UInt16 reason;
		/// <summary>
		///  名字
		/// </summary>
		public string name;
		/// <summary>
		///  数量
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
	///  公会兑换
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
	///  请求公会战报名
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
	///  请求公会战返回
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
	///  请求鼓舞
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
	///  鼓舞返回
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
	///  请求领取奖励
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
	///  领取奖励返回
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
	///  请求领地战斗记录
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
	///  领地战斗记录返回
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
	///  领地战斗记录同步
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
	///  请求领地信息
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
	///  返回领地信息
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
	///  单次战斗结束
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
	///  公会战结束
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
	///  请求自身公会排行
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
	///  请求自身公会排行响应
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
	///  公会邀请通知，有别的玩家邀请加入公会
	/// </summary>
	[Protocol]
	public class WorldGuildInviteNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601957;
		/// <summary>
		///  邀请者ID
		/// </summary>
		public UInt64 inviterId;
		/// <summary>
		///  邀请者名字
		/// </summary>
		public string inviterName;
		/// <summary>
		///  公会ID
		/// </summary>
		public UInt64 guildId;
		/// <summary>
		///  公会名
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
	///  同步公会战状态
	/// </summary>
	[Protocol]
	public class WorldGuildBattleStatusSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601958;
		/// <summary>
		///  类型
		/// </summary>
		public byte type;
		/// <summary>
		///  状态
		/// </summary>
		public byte status;
		/// <summary>
		///  状态存在时间
		/// </summary>
		public UInt32 time;
		/// <summary>
		///  公会战结束信息
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
	///  请求公会宣战报名
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
	///  返回公会宣战报名
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
	///  请求公会宣战信息
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
	///  公会宣战信息同步
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
	///  请求公会战鼓舞信息
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
	///  返回公会战鼓舞信息
	/// </summary>
	[Protocol]
	public class WorldGuildBattleInspireInfoRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601964;
		public UInt32 result;
		/// <summary>
		///  领地ID
		/// </summary>
		public byte terrId;
		/// <summary>
		///  鼓舞信息
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
	///  请求公会仓库设置
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
	///  返回公会仓库设置
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
	///  请求公会战抽奖
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
	///  返回公会战抽奖
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
	///  请求公会仓库列表
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
	///  返回公会仓库列表
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
	///  同步仓库物品数据
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
	///  请求放入公会仓库
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
	///  返回放入公会仓库
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
	///  请求删除公会仓库物品
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
	///  返回删除公会仓库物品
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
	///  查看仓库物品详情
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
