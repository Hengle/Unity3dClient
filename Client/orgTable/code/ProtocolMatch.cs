using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	///  战斗类型
	/// </summary>
	public enum RaceType
	{
		/// <summary>
		///  关卡
		/// </summary>
		Dungeon = 0,
		/// <summary>
		///  PK
		/// </summary>
		PK = 1,
		/// <summary>
		///  公会战
		/// </summary>
		GuildBattle = 2,
	}

	/// <summary>
	///  好友状态
	/// </summary>
	public enum FriendMatchStatus
	{
		/// <summary>
		///  空闲
		/// </summary>
		Idle = 0,
		/// <summary>
		///  忙碌
		/// </summary>
		Busy = 1,
		/// <summary>
		///  下线
		/// </summary>
		Offlie = 2,
	}

	/// <summary>
	///  赛季状态
	/// </summary>
	public enum SeasonPlayStatus
	{
		SPS_INVALID = 0,
		SPS_NEW = 1,
		SPS_NEW_ATTR = 2,
	}

	[Protocol]
	public class WorldMatchStartReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506701;
		/// <summary>
		///  匹配类型，对应MatchType
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

	[Protocol]
	public class WorldMatchStartRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 606702;
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
	public class WorldMatchCancelReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506702;

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
	public class WorldMatchCancelRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 606703;
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

	public class RaceSkillInfo : Protocol.IProtocolStream
	{
		public UInt16 id;
		public byte level;
		public byte slot;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, slot);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref slot);
			}
		#endregion

	}

	public class RaceItemRandProperty : Protocol.IProtocolStream
	{
		public byte type;
		public UInt32 value;

		#region METHOD

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

	public class RaceEquip : Protocol.IProtocolStream
	{
		public UInt32 id;
		public byte pos;
		public UInt32 phyAtk;
		public UInt32 magAtk;
		public UInt32 phydef;
		public UInt32 magdef;
		public UInt32 strenth;
		public UInt32 stamina;
		public UInt32 intellect;
		public UInt32 spirit;
		public RaceItemRandProperty[] properties = new RaceItemRandProperty[0];
		public UInt32 magicCard;
		public UInt32 disphyAtk;
		public UInt32 disMagAtk;
		public UInt32 disphydef;
		public UInt32 dismagdef;
		public byte strengthen;
		public UInt32 fashionAttrId;
		public UInt32 phyDefPercent;
		public UInt32 magDefPercent;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				BaseDLL.encode_uint32(buffer, ref pos_, phyAtk);
				BaseDLL.encode_uint32(buffer, ref pos_, magAtk);
				BaseDLL.encode_uint32(buffer, ref pos_, phydef);
				BaseDLL.encode_uint32(buffer, ref pos_, magdef);
				BaseDLL.encode_uint32(buffer, ref pos_, strenth);
				BaseDLL.encode_uint32(buffer, ref pos_, stamina);
				BaseDLL.encode_uint32(buffer, ref pos_, intellect);
				BaseDLL.encode_uint32(buffer, ref pos_, spirit);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)properties.Length);
				for(int i = 0; i < properties.Length; i++)
				{
					properties[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint32(buffer, ref pos_, magicCard);
				BaseDLL.encode_uint32(buffer, ref pos_, disphyAtk);
				BaseDLL.encode_uint32(buffer, ref pos_, disMagAtk);
				BaseDLL.encode_uint32(buffer, ref pos_, disphydef);
				BaseDLL.encode_uint32(buffer, ref pos_, dismagdef);
				BaseDLL.encode_int8(buffer, ref pos_, strengthen);
				BaseDLL.encode_uint32(buffer, ref pos_, fashionAttrId);
				BaseDLL.encode_uint32(buffer, ref pos_, phyDefPercent);
				BaseDLL.encode_uint32(buffer, ref pos_, magDefPercent);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				BaseDLL.decode_uint32(buffer, ref pos_, ref phyAtk);
				BaseDLL.decode_uint32(buffer, ref pos_, ref magAtk);
				BaseDLL.decode_uint32(buffer, ref pos_, ref phydef);
				BaseDLL.decode_uint32(buffer, ref pos_, ref magdef);
				BaseDLL.decode_uint32(buffer, ref pos_, ref strenth);
				BaseDLL.decode_uint32(buffer, ref pos_, ref stamina);
				BaseDLL.decode_uint32(buffer, ref pos_, ref intellect);
				BaseDLL.decode_uint32(buffer, ref pos_, ref spirit);
				UInt16 propertiesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref propertiesCnt);
				properties = new RaceItemRandProperty[propertiesCnt];
				for(int i = 0; i < properties.Length; i++)
				{
					properties[i] = new RaceItemRandProperty();
					properties[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_uint32(buffer, ref pos_, ref magicCard);
				BaseDLL.decode_uint32(buffer, ref pos_, ref disphyAtk);
				BaseDLL.decode_uint32(buffer, ref pos_, ref disMagAtk);
				BaseDLL.decode_uint32(buffer, ref pos_, ref disphydef);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dismagdef);
				BaseDLL.decode_int8(buffer, ref pos_, ref strengthen);
				BaseDLL.decode_uint32(buffer, ref pos_, ref fashionAttrId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref phyDefPercent);
				BaseDLL.decode_uint32(buffer, ref pos_, ref magDefPercent);
			}
		#endregion

	}

	public class RaceItem : Protocol.IProtocolStream
	{
		public UInt32 id;
		public UInt16 num;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	public class RaceBuffInfo : Protocol.IProtocolStream
	{
		public UInt32 id;
		public UInt32 overlayNums;
		public UInt64 startTime;
		public UInt32 duration;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, overlayNums);
				BaseDLL.encode_uint64(buffer, ref pos_, startTime);
				BaseDLL.encode_uint32(buffer, ref pos_, duration);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref overlayNums);
				BaseDLL.decode_uint64(buffer, ref pos_, ref startTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref duration);
			}
		#endregion

	}

	public class RaceWarpStone : Protocol.IProtocolStream
	{
		public UInt32 id;
		public byte level;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, level);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref level);
			}
		#endregion

	}

	public class RaceRetinue : Protocol.IProtocolStream
	{
		public UInt32 dataId;
		public byte level;
		public byte star;
		public byte isMain;
		public UInt32[] buffIds = new UInt32[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, dataId);
				BaseDLL.encode_int8(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, star);
				BaseDLL.encode_int8(buffer, ref pos_, isMain);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)buffIds.Length);
				for(int i = 0; i < buffIds.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, buffIds[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref dataId);
				BaseDLL.decode_int8(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref star);
				BaseDLL.decode_int8(buffer, ref pos_, ref isMain);
				UInt16 buffIdsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref buffIdsCnt);
				buffIds = new UInt32[buffIdsCnt];
				for(int i = 0; i < buffIds.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref buffIds[i]);
				}
			}
		#endregion

	}

	public class RacePet : Protocol.IProtocolStream
	{
		public UInt32 dataId;
		public UInt16 level;
		public UInt16 hunger;
		public byte skillIndex;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, dataId);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_uint16(buffer, ref pos_, hunger);
				BaseDLL.encode_int8(buffer, ref pos_, skillIndex);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref dataId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_uint16(buffer, ref pos_, ref hunger);
				BaseDLL.decode_int8(buffer, ref pos_, ref skillIndex);
			}
		#endregion

	}

	public class RacePlayerInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  ai难度，0代表无效值，说明不是机器人
		/// </summary>
		public byte robotAIType;
		/// <summary>
		///  机器人难度（0代表满血）
		/// </summary>
		public byte robotHard;
		public UInt64 roleId;
		public UInt32 accid;
		public string name;
		public string guildName;
		public byte occupation;
		public UInt16 level;
		public UInt32 pkValue;
		public UInt32 matchScore;
		public byte seat;
		public UInt32 remainHp;
		public UInt32 remainMp;
		public UInt32 seasonLevel;
		public UInt32 seasonStar;
		public byte seasonAttr;
		public byte monthcard;
		public RaceSkillInfo[] skills = new RaceSkillInfo[0];
		public RaceEquip[] equips = new RaceEquip[0];
		public RaceItem[] raceItems = new RaceItem[0];
		public RaceBuffInfo[] buffs = new RaceBuffInfo[0];
		public RaceWarpStone[] warpStones = new RaceWarpStone[0];
		public RaceRetinue[] retinues = new RaceRetinue[0];
		public RacePet[] pets = new RacePet[0];
		public UInt32[] potionPos = new UInt32[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, robotAIType);
				BaseDLL.encode_int8(buffer, ref pos_, robotHard);
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_uint32(buffer, ref pos_, accid);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				byte[] guildNameBytes = StringHelper.StringToUTF8Bytes(guildName);
				BaseDLL.encode_string(buffer, ref pos_, guildNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, occupation);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_uint32(buffer, ref pos_, pkValue);
				BaseDLL.encode_uint32(buffer, ref pos_, matchScore);
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				BaseDLL.encode_uint32(buffer, ref pos_, remainHp);
				BaseDLL.encode_uint32(buffer, ref pos_, remainMp);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonStar);
				BaseDLL.encode_int8(buffer, ref pos_, seasonAttr);
				BaseDLL.encode_int8(buffer, ref pos_, monthcard);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)skills.Length);
				for(int i = 0; i < skills.Length; i++)
				{
					skills[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)equips.Length);
				for(int i = 0; i < equips.Length; i++)
				{
					equips[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)raceItems.Length);
				for(int i = 0; i < raceItems.Length; i++)
				{
					raceItems[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)buffs.Length);
				for(int i = 0; i < buffs.Length; i++)
				{
					buffs[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)warpStones.Length);
				for(int i = 0; i < warpStones.Length; i++)
				{
					warpStones[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)retinues.Length);
				for(int i = 0; i < retinues.Length; i++)
				{
					retinues[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)pets.Length);
				for(int i = 0; i < pets.Length; i++)
				{
					pets[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)potionPos.Length);
				for(int i = 0; i < potionPos.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, potionPos[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref robotAIType);
				BaseDLL.decode_int8(buffer, ref pos_, ref robotHard);
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref accid);
				UInt16 nameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref nameLen);
				byte[] nameBytes = new byte[nameLen];
				for(int i = 0; i < nameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref nameBytes[i]);
				}
				name = StringHelper.BytesToString(nameBytes);
				UInt16 guildNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref guildNameLen);
				byte[] guildNameBytes = new byte[guildNameLen];
				for(int i = 0; i < guildNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref guildNameBytes[i]);
				}
				guildName = StringHelper.BytesToString(guildNameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref occupation);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_uint32(buffer, ref pos_, ref pkValue);
				BaseDLL.decode_uint32(buffer, ref pos_, ref matchScore);
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainHp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainMp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonStar);
				BaseDLL.decode_int8(buffer, ref pos_, ref seasonAttr);
				BaseDLL.decode_int8(buffer, ref pos_, ref monthcard);
				UInt16 skillsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref skillsCnt);
				skills = new RaceSkillInfo[skillsCnt];
				for(int i = 0; i < skills.Length; i++)
				{
					skills[i] = new RaceSkillInfo();
					skills[i].decode(buffer, ref pos_);
				}
				UInt16 equipsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref equipsCnt);
				equips = new RaceEquip[equipsCnt];
				for(int i = 0; i < equips.Length; i++)
				{
					equips[i] = new RaceEquip();
					equips[i].decode(buffer, ref pos_);
				}
				UInt16 raceItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref raceItemsCnt);
				raceItems = new RaceItem[raceItemsCnt];
				for(int i = 0; i < raceItems.Length; i++)
				{
					raceItems[i] = new RaceItem();
					raceItems[i].decode(buffer, ref pos_);
				}
				UInt16 buffsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref buffsCnt);
				buffs = new RaceBuffInfo[buffsCnt];
				for(int i = 0; i < buffs.Length; i++)
				{
					buffs[i] = new RaceBuffInfo();
					buffs[i].decode(buffer, ref pos_);
				}
				UInt16 warpStonesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref warpStonesCnt);
				warpStones = new RaceWarpStone[warpStonesCnt];
				for(int i = 0; i < warpStones.Length; i++)
				{
					warpStones[i] = new RaceWarpStone();
					warpStones[i].decode(buffer, ref pos_);
				}
				UInt16 retinuesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref retinuesCnt);
				retinues = new RaceRetinue[retinuesCnt];
				for(int i = 0; i < retinues.Length; i++)
				{
					retinues[i] = new RaceRetinue();
					retinues[i].decode(buffer, ref pos_);
				}
				UInt16 petsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref petsCnt);
				pets = new RacePet[petsCnt];
				for(int i = 0; i < pets.Length; i++)
				{
					pets[i] = new RacePet();
					pets[i].decode(buffer, ref pos_);
				}
				UInt16 potionPosCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref potionPosCnt);
				potionPos = new UInt32[potionPosCnt];
				for(int i = 0; i < potionPos.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref potionPos[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class WorldNotifyRaceStart : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 606701;
		public UInt64 roleId;
		public UInt64 sessionId;
		public SockAddr addr = new SockAddr();
		/// <summary>
		///  对应枚举（RaceType）
		/// </summary>
		public byte raceType;
		public UInt32 dungeonId;
		public RacePlayerInfo[] players = new RacePlayerInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_uint64(buffer, ref pos_, sessionId);
				addr.encode(buffer, ref pos_);
				BaseDLL.encode_int8(buffer, ref pos_, raceType);
				BaseDLL.encode_uint32(buffer, ref pos_, dungeonId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)players.Length);
				for(int i = 0; i < players.Length; i++)
				{
					players[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_uint64(buffer, ref pos_, ref sessionId);
				addr.decode(buffer, ref pos_);
				BaseDLL.decode_int8(buffer, ref pos_, ref raceType);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungeonId);
				UInt16 playersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref playersCnt);
				players = new RacePlayerInfo[playersCnt];
				for(int i = 0; i < players.Length; i++)
				{
					players[i] = new RacePlayerInfo();
					players[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	public class PkOccuRecord : Protocol.IProtocolStream
	{
		public byte occu;
		public UInt32 winNum;
		public UInt32 loseNum;
		public UInt32 totalNum;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_uint32(buffer, ref pos_, winNum);
				BaseDLL.encode_uint32(buffer, ref pos_, loseNum);
				BaseDLL.encode_uint32(buffer, ref pos_, totalNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
				BaseDLL.decode_uint32(buffer, ref pos_, ref winNum);
				BaseDLL.decode_uint32(buffer, ref pos_, ref loseNum);
				BaseDLL.decode_uint32(buffer, ref pos_, ref totalNum);
			}
		#endregion

	}

	[Protocol]
	public class SceneSyncPkStatisticInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506703;

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
	public class SceneSyncPkStatisticProperty : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506704;

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
	///  结算
	/// </summary>
	[Protocol]
	public class SceneMatchPkRaceEnd : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506705;
		/// <summary>
		///  PK类型，对应枚举(PkType)
		/// </summary>
		public byte pkType;
		public byte result;
		public UInt32 oldPkValue;
		public UInt32 newPkValue;
		public UInt32 oldMatchScore;
		public UInt32 newMatchScore;
		/// <summary>
		///  初始决斗币数量
		/// </summary>
		public UInt32 oldPkCoin;
		/// <summary>
		///  战斗获得的决斗币
		/// </summary>
		public UInt32 addPkCoinFromRace;
		/// <summary>
		///  今日战斗获得的全部决斗币
		/// </summary>
		public UInt32 totalPkCoinFromRace;
		/// <summary>
		///  是否在PVP活动期间
		/// </summary>
		public byte isInPvPActivity;
		/// <summary>
		///  活动额外获得的决斗币
		/// </summary>
		public UInt32 addPkCoinFromActivity;
		/// <summary>
		///  今日活动获得的全部决斗币
		/// </summary>
		public UInt32 totalPkCoinFromActivity;
		/// <summary>
		///  原段位
		/// </summary>
		public UInt32 oldSeasonLevel;
		/// <summary>
		///  现段位
		/// </summary>
		public UInt32 newSeasonLevel;
		/// <summary>
		///  原星
		/// </summary>
		public UInt32 oldSeasonStar;
		/// <summary>
		///  现星
		/// </summary>
		public UInt32 newSeasonStar;
		/// <summary>
		///  原经验
		/// </summary>
		public UInt32 oldSeasonExp;
		/// <summary>
		///  现经验
		/// </summary>
		public UInt32 newSeasonExp;
		/// <summary>
		///  改变的经验
		/// </summary>
		public Int32 changeSeasonExp;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, pkType);
				BaseDLL.encode_int8(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, oldPkValue);
				BaseDLL.encode_uint32(buffer, ref pos_, newPkValue);
				BaseDLL.encode_uint32(buffer, ref pos_, oldMatchScore);
				BaseDLL.encode_uint32(buffer, ref pos_, newMatchScore);
				BaseDLL.encode_uint32(buffer, ref pos_, oldPkCoin);
				BaseDLL.encode_uint32(buffer, ref pos_, addPkCoinFromRace);
				BaseDLL.encode_uint32(buffer, ref pos_, totalPkCoinFromRace);
				BaseDLL.encode_int8(buffer, ref pos_, isInPvPActivity);
				BaseDLL.encode_uint32(buffer, ref pos_, addPkCoinFromActivity);
				BaseDLL.encode_uint32(buffer, ref pos_, totalPkCoinFromActivity);
				BaseDLL.encode_uint32(buffer, ref pos_, oldSeasonLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, newSeasonLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, oldSeasonStar);
				BaseDLL.encode_uint32(buffer, ref pos_, newSeasonStar);
				BaseDLL.encode_uint32(buffer, ref pos_, oldSeasonExp);
				BaseDLL.encode_uint32(buffer, ref pos_, newSeasonExp);
				BaseDLL.encode_int32(buffer, ref pos_, changeSeasonExp);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref pkType);
				BaseDLL.decode_int8(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldPkValue);
				BaseDLL.decode_uint32(buffer, ref pos_, ref newPkValue);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldMatchScore);
				BaseDLL.decode_uint32(buffer, ref pos_, ref newMatchScore);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldPkCoin);
				BaseDLL.decode_uint32(buffer, ref pos_, ref addPkCoinFromRace);
				BaseDLL.decode_uint32(buffer, ref pos_, ref totalPkCoinFromRace);
				BaseDLL.decode_int8(buffer, ref pos_, ref isInPvPActivity);
				BaseDLL.decode_uint32(buffer, ref pos_, ref addPkCoinFromActivity);
				BaseDLL.decode_uint32(buffer, ref pos_, ref totalPkCoinFromActivity);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldSeasonLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref newSeasonLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldSeasonStar);
				BaseDLL.decode_uint32(buffer, ref pos_, ref newSeasonStar);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldSeasonExp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref newSeasonExp);
				BaseDLL.decode_int32(buffer, ref pos_, ref changeSeasonExp);
			}
		#endregion

	}

	/// <summary>
	///  请求参加武道大会
	/// </summary>
	[Protocol]
	public class SceneWudaoJoinReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506706;

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
	///  参加武道大会返回
	/// </summary>
	[Protocol]
	public class SceneWudaoJoinRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506707;
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
	///  请求领取武道大会奖励
	/// </summary>
	[Protocol]
	public class SceneWudaoRewardReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506708;

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
	///  领取武道大会奖励返回
	/// </summary>
	[Protocol]
	public class SceneWudaoRewardRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506709;
		public UInt32 result;
		public ItemReward[] getItems = new ItemReward[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)getItems.Length);
				for(int i = 0; i < getItems.Length; i++)
				{
					getItems[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 getItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref getItemsCnt);
				getItems = new ItemReward[getItemsCnt];
				for(int i = 0; i < getItems.Length; i++)
				{
					getItems[i] = new ItemReward();
					getItems[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  好友状态信息
	/// </summary>
	public class FriendMatchStatusInfo : Protocol.IProtocolStream
	{
		public UInt64 roleId;
		/// <summary>
		///  状态，对应枚举（FriendMatchStatus）
		/// </summary>
		public byte status;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_int8(buffer, ref pos_, status);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_int8(buffer, ref pos_, ref status);
			}
		#endregion

	}

	/// <summary>
	///  请求查询好友状态
	/// </summary>
	[Protocol]
	public class WorldMatchQueryFriendStatusReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 606706;

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
	///  查询好友状态返回
	/// </summary>
	[Protocol]
	public class WorldMatchQueryFriendStatusRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 606707;
		public FriendMatchStatusInfo[] infoes = new FriendMatchStatusInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)infoes.Length);
				for(int i = 0; i < infoes.Length; i++)
				{
					infoes[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 infoesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref infoesCnt);
				infoes = new FriendMatchStatusInfo[infoesCnt];
				for(int i = 0; i < infoes.Length; i++)
				{
					infoes[i] = new FriendMatchStatusInfo();
					infoes[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 通知段位信息
	/// </summary>
	[Protocol]
	public class SceneSyncSeasonLevel : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506711;
		public UInt32 oldSeasonLevel;
		public UInt32 oldSeasonStar;
		public UInt32 seasonLevel;
		public UInt32 seasonStar;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, oldSeasonLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, oldSeasonStar);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonStar);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldSeasonLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref oldSeasonStar);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonStar);
			}
		#endregion

	}

	/// <summary>
	/// 客户端通知赛季播放状态
	/// </summary>
	[Protocol]
	public class SceneSeasonPlayStatus : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506712;
		public UInt32 seasonId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, seasonId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonId);
			}
		#endregion

	}

	/// <summary>
	/// 通知客户端赛季信息
	/// </summary>
	[Protocol]
	public class SceneSyncSeasonInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506713;
		public UInt32 seasonId;
		public UInt32 endTime;
		public UInt32 seasonAttrEndTime;
		public UInt32 seasonAttrLevel;
		public byte seasonAttr;
		public UInt32 seasonLevel;
		public UInt32 seasonStar;
		public UInt32 seasonExp;
		public byte seasonStatus;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, seasonId);
				BaseDLL.encode_uint32(buffer, ref pos_, endTime);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonAttrEndTime);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonAttrLevel);
				BaseDLL.encode_int8(buffer, ref pos_, seasonAttr);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonLevel);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonStar);
				BaseDLL.encode_uint32(buffer, ref pos_, seasonExp);
				BaseDLL.encode_int8(buffer, ref pos_, seasonStatus);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref endTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonAttrEndTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonAttrLevel);
				BaseDLL.decode_int8(buffer, ref pos_, ref seasonAttr);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonLevel);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonStar);
				BaseDLL.decode_uint32(buffer, ref pos_, ref seasonExp);
				BaseDLL.decode_int8(buffer, ref pos_, ref seasonStatus);
			}
		#endregion

	}

}
