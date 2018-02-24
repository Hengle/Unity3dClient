using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	/// 同步关系数据
	/// </summary>
	/// <summary>
	/// 格式 type(UInt8) + id(ObjID_t) + data
	/// </summary>
	[Protocol]
	public class WorldSyncRelationData : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601707;

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
	/// 上线同步关系列表
	/// </summary>
	/// <summary>
	/// datalist格式: type(UInt8) + ObjID_t + isOnline(UInt8) + data + .. + 0(ObjID_t)
	/// </summary>
	[Protocol]
	public class WorldSyncRelationList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601708;

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
	/// 新关系同步
	/// </summary>
	[Protocol]
	public class WorldNotifyNewRelation : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601705;

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
	/// 删除关系同步
	/// </summary>
	[Protocol]
	public class WorldNotifyDelRelation : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601706;
		public byte type;
		public UInt64 id;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, id);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
			}
		#endregion

	}

	/// <summary>
	/// 查询推荐好友列表
	/// </summary>
	[Protocol]
	public class WorldRelationFindPlayersReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601709;
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
	/// 1.推荐好友; 2.附近组队
	/// </summary>
	/// <summary>
	/// 快捷加好友结构
	/// </summary>
	public class QuickFriendInfo : Protocol.IProtocolStream
	{
		/// <summary>
		/// 玩家id
		/// </summary>
		public UInt64 playerId;
		/// <summary>
		/// 姓名
		/// </summary>
		public string name;
		/// <summary>
		/// 职业
		/// </summary>
		public byte occu;
		/// <summary>
		/// 性别
		/// </summary>
		public UInt32 seasonLv;
		/// <summary>
		/// 等级
		/// </summary>
		public UInt16 level;
		/// <summary>
		/// vip等级
		/// </summary>
		public byte vipLv;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, playerId);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonLv);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, vipLv);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref playerId);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonLv);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref vipLv);
			}
		#endregion

	}

	/// <summary>
	/// 查询推荐好友列表
	/// </summary>
	[Protocol]
	public class WorldRelationFindPlayersRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601710;
		public byte type;
		public QuickFriendInfo[] friendList = new QuickFriendInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)friendList.Length);
				for(int i = 0; i < friendList.Length; i++)
				{
					friendList[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				UInt16 friendListCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref friendListCnt);
				friendList = new QuickFriendInfo[friendListCnt];
				for(int i = 0; i < friendList.Length; i++)
				{
					friendList[i] = new QuickFriendInfo();
					friendList[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 删除关系
	/// </summary>
	[Protocol]
	public class WorldRemoveRelation : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601704;
		public byte type;
		public UInt64 uid;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, uid);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref uid);
			}
		#endregion

	}

	/// <summary>
	///  查询玩家信息（可根据角色ID和名字查询，优先使用角色ID）
	/// </summary>
	[Protocol]
	public class WorldQueryPlayerReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601701;
		/// <summary>
		///  角色ID
		/// </summary>
		public UInt64 roleId;
		/// <summary>
		///  名字
		/// </summary>
		public string name;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
			}
		#endregion

	}

	/// <summary>
	///  查询玩家详细信息（可根据角色ID和名字查询，优先使用角色ID）
	/// </summary>
	[Protocol]
	public class WorldQueryPlayerDetailsReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601722;
		/// <summary>
		///  角色ID
		/// </summary>
		public UInt64 roleId;
		/// <summary>
		///  名字
		/// </summary>
		public string name;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
			}
		#endregion

	}

	/// <summary>
	///  物品基本信息
	/// </summary>
	public class ItemBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  唯一ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  类型ID
		/// </summary>
		public UInt32 typeId;
		/// <summary>
		///  位置
		/// </summary>
		public byte pos;
		/// <summary>
		///  强化
		/// </summary>
		public byte strengthen;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, typeId);
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				BaseDLL.encode_int8(buffer, ref pos_, strengthen);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref typeId);
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				BaseDLL.decode_int8(buffer, ref pos_, ref strengthen);
			}
		#endregion

	}

	/// <summary>
	///  Pk信息
	/// </summary>
	public class PkStatisticInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  胜场数
		/// </summary>
		public UInt32 totalWinNum;
		/// <summary>
		///  负场数
		/// </summary>
		public UInt32 totalLoseNum;
		/// <summary>
		///  总场数
		/// </summary>
		public UInt32 totalNum;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, totalWinNum);
				BaseDLL.encode_uint32(buffer, ref pos_, totalLoseNum);
				BaseDLL.encode_uint32(buffer, ref pos_, totalNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref totalWinNum);
				BaseDLL.decode_uint32(buffer, ref pos_, ref totalLoseNum);
				BaseDLL.decode_uint32(buffer, ref pos_, ref totalNum);
			}
		#endregion

	}

	/// <summary>
	///  公会称号
	/// </summary>
	public class GuildTitle : Protocol.IProtocolStream
	{
		/// <summary>
		///  公会名
		/// </summary>
		public string name;
		/// <summary>
		///  职务
		/// </summary>
		public byte post;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, post);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref post);
			}
		#endregion

	}

	/// <summary>
	///  查看玩家的信息
	/// </summary>
	public class PlayerWatchInfo : Protocol.IProtocolStream
	{
		public UInt64 id;
		public string name;
		public byte occu;
		public UInt16 level;
		public ItemBaseInfo[] equips = new ItemBaseInfo[0];
		public ItemBaseInfo[] fashionEquips = new ItemBaseInfo[0];
		public RetinueInfo retinue = new RetinueInfo();
		public PkStatisticInfo pkInfo = new PkStatisticInfo();
		public UInt32 pkValue;
		public UInt32 matchScore;
		/// <summary>
		///  vip等级
		/// </summary>
		public byte vipLevel;
		/// <summary>
		///  公会称号
		/// </summary>
		public GuildTitle guildTitle = new GuildTitle();
		/// <summary>
		///  赛季段位等级
		/// </summary>
		public UInt32 seasonLevel;
		/// <summary>
		///  赛季段位星级
		/// </summary>
		public UInt32 seasonStar;
		/// <summary>
		///  宠物
		/// </summary>
		public PetBaseInfo[] pets = new PetBaseInfo[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)equips.Length);
				for(int i = 0; i < equips.Length; i++)
				{
					equips[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)fashionEquips.Length);
				for(int i = 0; i < fashionEquips.Length; i++)
				{
					fashionEquips[i].encode(buffer, ref pos_);
				}
				retinue.encode(buffer, ref pos_);
				pkInfo.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, pkValue);
				BaseDLL.encode_uint32(buffer, ref pos_, matchScore);
				BaseDLL.encode_int8(buffer, ref pos_, vipLevel);
				guildTitle.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonStar);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)pets.Length);
				for(int i = 0; i < pets.Length; i++)
				{
					pets[i].encode(buffer, ref pos_);
				}
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
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				UInt16 equipsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref equipsCnt);
				equips = new ItemBaseInfo[equipsCnt];
				for(int i = 0; i < equips.Length; i++)
				{
					equips[i] = new ItemBaseInfo();
					equips[i].decode(buffer, ref pos_);
				}
				UInt16 fashionEquipsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref fashionEquipsCnt);
				fashionEquips = new ItemBaseInfo[fashionEquipsCnt];
				for(int i = 0; i < fashionEquips.Length; i++)
				{
					fashionEquips[i] = new ItemBaseInfo();
					fashionEquips[i].decode(buffer, ref pos_);
				}
				retinue.decode(buffer, ref pos_);
				pkInfo.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref pkValue);
				BaseDLL.decode_uint32(buffer, ref pos_, ref matchScore);
				BaseDLL.decode_int8(buffer, ref pos_, ref vipLevel);
				guildTitle.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonStar);
				UInt16 petsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref petsCnt);
				pets = new PetBaseInfo[petsCnt];
				for(int i = 0; i < pets.Length; i++)
				{
					pets[i] = new PetBaseInfo();
					pets[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  返回玩家信息
	/// </summary>
	[Protocol]
	public class WorldQueryPlayerRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601702;
		public PlayerWatchInfo info = new PlayerWatchInfo();

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
	///  返回玩家信息
	/// </summary>
	[Protocol]
	public class WorldQueryPlayerDetailsRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601723;
		public RacePlayerInfo info = new RacePlayerInfo();

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
	/// 好友赠送
	/// </summary>
	[Protocol]
	public class WorldRelationPresentGiveReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601711;
		public UInt64 friendUID;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, friendUID);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref friendUID);
			}
		#endregion

	}

	/// <summary>
	/// 同步上下线状态
	/// </summary>
	[Protocol]
	public class WorldSyncOnOffline : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601713;
		public UInt64 id;
		public byte isOnline;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, isOnline);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref isOnline);
			}
		#endregion

	}

	/// <summary>
	/// 更新关系
	/// </summary>
	[Protocol]
	public class WorldUpdateRelation : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601712;

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
	/// 加黑名单
	/// </summary>
	[Protocol]
	public class WorldAddToBlackList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601703;
		public UInt64 tarUid;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, tarUid);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref tarUid);
			}
		#endregion

	}

	/// <summary>
	///  玩家在线状态
	/// </summary>
	public class PlayerOnline : Protocol.IProtocolStream
	{
		public UInt64 uid;
		public byte online;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, uid);
				BaseDLL.encode_int8(buffer, ref pos_, online);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref uid);
				BaseDLL.decode_int8(buffer, ref pos_, ref online);
			}
		#endregion

	}

	/// <summary>
	/// clt->svr更新聊天玩家的在线信息
	/// </summary>
	[Protocol]
	public class WorldUpdatePlayerOnlineReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601714;
		public UInt64[] uids = new UInt64[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)uids.Length);
				for(int i = 0; i < uids.Length; i++)
				{
					BaseDLL.encode_uint64(buffer, ref pos_, uids[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 uidsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref uidsCnt);
				uids = new UInt64[uidsCnt];
				for(int i = 0; i < uids.Length; i++)
				{
					BaseDLL.decode_uint64(buffer, ref pos_, ref uids[i]);
				}
			}
		#endregion

	}

	/// <summary>
	/// svr->clt更新聊天玩家的在线信息
	/// </summary>
	[Protocol]
	public class WorldUpdatePlayerOnlineRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 601715;
		public PlayerOnline[] playerStates = new PlayerOnline[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)playerStates.Length);
				for(int i = 0; i < playerStates.Length; i++)
				{
					playerStates[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 playerStatesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref playerStatesCnt);
				playerStates = new PlayerOnline[playerStatesCnt];
				for(int i = 0; i < playerStates.Length; i++)
				{
					playerStates[i] = new PlayerOnline();
					playerStates[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

}
