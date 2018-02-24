using System;
using System.Text;

namespace Protocol
{
	public enum DungeonScore
	{
		C = 0,
		B = 1,
		A = 2,
		S = 3,
		SS = 4,
		SSS = 5,
	}

	/// <summary>
	///  深渊模式
	/// </summary>
	public enum DungeonHellMode
	{
		/// <summary>
		///  无
		/// </summary>
		Null = 0,
		/// <summary>
		///  普通
		/// </summary>
		Normal = 1,
		/// <summary>
		///  困难
		/// </summary>
		Hard = 2,
	}

	/// <summary>
	///  各种经验加成类型
	/// </summary>
	public enum DungeonAdditionType
	{
		/// <summary>
		///  经验药水
		/// </summary>
		EXP_BUFF = 0,
		/// <summary>
		///  VIP经验加成
		/// </summary>
		EXP_VIP = 1,
		/// <summary>
		///  评价经验加成
		/// </summary>
		EXP_SCORE = 2,
		/// <summary>
		///  难度经验加成
		/// </summary>
		EXP_HARD = 3,
		/// <summary>
		///  公会技能经验加成
		/// </summary>
		EXP_GUILD_SKILL = 4,
		/// <summary>
		///  VIP金币加成
		/// </summary>
		GOLD_VIP = 5,
	}

	public enum DungeonChestType
	{
		/// <summary>
		///  普通宝箱
		/// </summary>
		Normal = 0,
		/// <summary>
		///  Vip宝箱
		/// </summary>
		Vip = 1,
		/// <summary>
		///  付费宝箱
		/// </summary>
		Pay = 2,
	}

	public class SceneDungeonInfo : Protocol.IProtocolStream
	{
		public UInt32 id;
		public byte bestScore;
		public UInt32 bestRecordTime;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, bestScore);
				BaseDLL.encode_uint32(buffer, ref pos_, bestRecordTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref bestScore);
				BaseDLL.decode_uint32(buffer, ref pos_, ref bestRecordTime);
			}
		#endregion

	}

	public class DungeonAdditionInfo : Protocol.IProtocolStream
	{
		public UInt32[] addition = new UInt32[6];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				for(int i = 0; i < addition.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, addition[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				for(int i = 0; i < addition.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref addition[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonInit : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506801;
		public SceneDungeonInfo[] allInfo = new SceneDungeonInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)allInfo.Length);
				for(int i = 0; i < allInfo.Length; i++)
				{
					allInfo[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 allInfoCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref allInfoCnt);
				allInfo = new SceneDungeonInfo[allInfoCnt];
				for(int i = 0; i < allInfo.Length; i++)
				{
					allInfo[i] = new SceneDungeonInfo();
					allInfo[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonUpdate : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506802;
		public SceneDungeonInfo info = new SceneDungeonInfo();

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

	public class SceneDungeonHardInfo : Protocol.IProtocolStream
	{
		public UInt32 id;
		public byte unlockedHardType;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, unlockedHardType);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref unlockedHardType);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonHardInit : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506803;
		public SceneDungeonHardInfo[] allInfo = new SceneDungeonHardInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)allInfo.Length);
				for(int i = 0; i < allInfo.Length; i++)
				{
					allInfo[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 allInfoCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref allInfoCnt);
				allInfo = new SceneDungeonHardInfo[allInfoCnt];
				for(int i = 0; i < allInfo.Length; i++)
				{
					allInfo[i] = new SceneDungeonHardInfo();
					allInfo[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonHardUpdate : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506804;
		public SceneDungeonHardInfo info = new SceneDungeonHardInfo();

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

	[Protocol]
	public class SceneDungeonStartReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506805;
		public UInt32 dungeonId;
		/// <summary>
		///  要使用的药水
		/// </summary>
		public UInt32[] buffDrugs = new UInt32[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, dungeonId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)buffDrugs.Length);
				for(int i = 0; i < buffDrugs.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, buffDrugs[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungeonId);
				UInt16 buffDrugsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref buffDrugsCnt);
				buffDrugs = new UInt32[buffDrugsCnt];
				for(int i = 0; i < buffDrugs.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref buffDrugs[i]);
				}
			}
		#endregion

	}

	public class SceneDungeonDropItem : Protocol.IProtocolStream
	{
		public UInt32 id;
		public UInt32 typeId;
		public UInt32 num;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, typeId);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref typeId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
			}
		#endregion

	}

	public class SceneDungeonMonster : Protocol.IProtocolStream
	{
		public UInt32 id;
		public UInt32 pointId;
		public UInt32 typeId;
		public SceneDungeonDropItem[] dropItems = new SceneDungeonDropItem[0];
		public byte[] prefixes = new byte[0];
		public UInt32 summonerId;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, pointId);
				BaseDLL.encode_uint32(buffer, ref pos_, typeId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)dropItems.Length);
				for(int i = 0; i < dropItems.Length; i++)
				{
					dropItems[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)prefixes.Length);
				for(int i = 0; i < prefixes.Length; i++)
				{
					BaseDLL.encode_int8(buffer, ref pos_, prefixes[i]);
				}
				BaseDLL.encode_uint32(buffer, ref pos_, summonerId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref pointId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref typeId);
				UInt16 dropItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dropItemsCnt);
				dropItems = new SceneDungeonDropItem[dropItemsCnt];
				for(int i = 0; i < dropItems.Length; i++)
				{
					dropItems[i] = new SceneDungeonDropItem();
					dropItems[i].decode(buffer, ref pos_);
				}
				UInt16 prefixesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref prefixesCnt);
				prefixes = new byte[prefixesCnt];
				for(int i = 0; i < prefixes.Length; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref prefixes[i]);
				}
				BaseDLL.decode_uint32(buffer, ref pos_, ref summonerId);
			}
		#endregion

	}

	public class SceneDungeonArea : Protocol.IProtocolStream
	{
		public UInt32 id;
		public SceneDungeonMonster[] monsters = new SceneDungeonMonster[0];
		public SceneDungeonMonster[] destructs = new SceneDungeonMonster[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)monsters.Length);
				for(int i = 0; i < monsters.Length; i++)
				{
					monsters[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)destructs.Length);
				for(int i = 0; i < destructs.Length; i++)
				{
					destructs[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				UInt16 monstersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref monstersCnt);
				monsters = new SceneDungeonMonster[monstersCnt];
				for(int i = 0; i < monsters.Length; i++)
				{
					monsters[i] = new SceneDungeonMonster();
					monsters[i].decode(buffer, ref pos_);
				}
				UInt16 destructsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref destructsCnt);
				destructs = new SceneDungeonMonster[destructsCnt];
				for(int i = 0; i < destructs.Length; i++)
				{
					destructs[i] = new SceneDungeonMonster();
					destructs[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  深渊波次信息
	/// </summary>
	public class DungeonHellWaveInfo : Protocol.IProtocolStream
	{
		public byte wave;
		public SceneDungeonMonster[] monsters = new SceneDungeonMonster[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, wave);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)monsters.Length);
				for(int i = 0; i < monsters.Length; i++)
				{
					monsters[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref wave);
				UInt16 monstersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref monstersCnt);
				monsters = new SceneDungeonMonster[monstersCnt];
				for(int i = 0; i < monsters.Length; i++)
				{
					monsters[i] = new SceneDungeonMonster();
					monsters[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  深渊信息
	/// </summary>
	public class DungeonHellInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  模式，对应枚举（DungeonHellMode）
		/// </summary>
		public byte mode;
		/// <summary>
		///  所在区域
		/// </summary>
		public UInt32 areaId;
		/// <summary>
		///  波次信息
		/// </summary>
		public DungeonHellWaveInfo[] waveInfoes = new DungeonHellWaveInfo[0];
		/// <summary>
		///  掉落
		/// </summary>
		public SceneDungeonDropItem[] dropItems = new SceneDungeonDropItem[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, mode);
				BaseDLL.encode_uint32(buffer, ref pos_, areaId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)waveInfoes.Length);
				for(int i = 0; i < waveInfoes.Length; i++)
				{
					waveInfoes[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)dropItems.Length);
				for(int i = 0; i < dropItems.Length; i++)
				{
					dropItems[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref mode);
				BaseDLL.decode_uint32(buffer, ref pos_, ref areaId);
				UInt16 waveInfoesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref waveInfoesCnt);
				waveInfoes = new DungeonHellWaveInfo[waveInfoesCnt];
				for(int i = 0; i < waveInfoes.Length; i++)
				{
					waveInfoes[i] = new DungeonHellWaveInfo();
					waveInfoes[i].decode(buffer, ref pos_);
				}
				UInt16 dropItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dropItemsCnt);
				dropItems = new SceneDungeonDropItem[dropItemsCnt];
				for(int i = 0; i < dropItems.Length; i++)
				{
					dropItems[i] = new SceneDungeonDropItem();
					dropItems[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonStartRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506806;
		public UInt32 dungeonId;
		public UInt32 startAreaId;
		public UInt32 result;
		public SceneDungeonArea[] areas = new SceneDungeonArea[0];
		/// <summary>
		///  深渊信息
		/// </summary>
		public DungeonHellInfo hellInfo = new DungeonHellInfo();
		/// <summary>
		///  是否接着上一次保存的状态
		/// </summary>
		public byte isCointnue;
		public UInt32 hp;
		public UInt32 mp;
		/// <summary>
		/// 登录RelayServer的session
		/// </summary>
		public UInt64 session;
		/// <summary>
		///  RelayServer地址
		/// </summary>
		public SockAddr addr = new SockAddr();
		/// <summary>
		///  所有玩家信息
		/// </summary>
		public RacePlayerInfo[] players = new RacePlayerInfo[0];
		/// <summary>
		///  是否开放自动战斗
		/// </summary>
		public byte openAutoBattle;
		/// <summary>
		///  boss掉落
		/// </summary>
		public SceneDungeonDropItem[] bossDropItems = new SceneDungeonDropItem[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, dungeonId);
				BaseDLL.encode_uint32(buffer, ref pos_, startAreaId);
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)areas.Length);
				for(int i = 0; i < areas.Length; i++)
				{
					areas[i].encode(buffer, ref pos_);
				}
				hellInfo.encode(buffer, ref pos_);
				BaseDLL.encode_int8(buffer, ref pos_, isCointnue);
				BaseDLL.encode_uint32(buffer, ref pos_, hp);
				BaseDLL.encode_uint32(buffer, ref pos_, mp);
				BaseDLL.encode_uint64(buffer, ref pos_, session);
				addr.encode(buffer, ref pos_);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)players.Length);
				for(int i = 0; i < players.Length; i++)
				{
					players[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_int8(buffer, ref pos_, openAutoBattle);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)bossDropItems.Length);
				for(int i = 0; i < bossDropItems.Length; i++)
				{
					bossDropItems[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungeonId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref startAreaId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 areasCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref areasCnt);
				areas = new SceneDungeonArea[areasCnt];
				for(int i = 0; i < areas.Length; i++)
				{
					areas[i] = new SceneDungeonArea();
					areas[i].decode(buffer, ref pos_);
				}
				hellInfo.decode(buffer, ref pos_);
				BaseDLL.decode_int8(buffer, ref pos_, ref isCointnue);
				BaseDLL.decode_uint32(buffer, ref pos_, ref hp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref mp);
				BaseDLL.decode_uint64(buffer, ref pos_, ref session);
				addr.decode(buffer, ref pos_);
				UInt16 playersCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref playersCnt);
				players = new RacePlayerInfo[playersCnt];
				for(int i = 0; i < players.Length; i++)
				{
					players[i] = new RacePlayerInfo();
					players[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_int8(buffer, ref pos_, ref openAutoBattle);
				UInt16 bossDropItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref bossDropItemsCnt);
				bossDropItems = new SceneDungeonDropItem[bossDropItemsCnt];
				for(int i = 0; i < bossDropItems.Length; i++)
				{
					bossDropItems[i] = new SceneDungeonDropItem();
					bossDropItems[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonAddMonsterDropItemNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506815;
		public UInt32 monsterId;
		public SceneDungeonDropItem[] dropItems = new SceneDungeonDropItem[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, monsterId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)dropItems.Length);
				for(int i = 0; i < dropItems.Length; i++)
				{
					dropItems[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref monsterId);
				UInt16 dropItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dropItemsCnt);
				dropItems = new SceneDungeonDropItem[dropItemsCnt];
				for(int i = 0; i < dropItems.Length; i++)
				{
					dropItems[i] = new SceneDungeonDropItem();
					dropItems[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonEnterNextAreaReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506807;
		public UInt32 areaId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, areaId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref areaId);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonEnterNextAreaRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506808;
		public UInt32 areaId;
		public UInt32 result;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, areaId);
				BaseDLL.encode_uint32(buffer, ref pos_, result);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref areaId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonRewardReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506809;
		public UInt32[] dropItemIds = new UInt32[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)dropItemIds.Length);
				for(int i = 0; i < dropItemIds.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, dropItemIds[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 dropItemIdsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dropItemIdsCnt);
				dropItemIds = new UInt32[dropItemIdsCnt];
				for(int i = 0; i < dropItemIds.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref dropItemIds[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonRewardRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506810;
		public UInt32[] pickedItems = new UInt32[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)pickedItems.Length);
				for(int i = 0; i < pickedItems.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, pickedItems[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 pickedItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref pickedItemsCnt);
				pickedItems = new UInt32[pickedItemsCnt];
				for(int i = 0; i < pickedItems.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref pickedItems[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonRaceEndReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506811;
		public byte score;
		public UInt16 beHitCount;
		public UInt32 usedTime;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, score);
				BaseDLL.encode_uint16(buffer, ref pos_, beHitCount);
				BaseDLL.encode_uint32(buffer, ref pos_, usedTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref score);
				BaseDLL.decode_uint16(buffer, ref pos_, ref beHitCount);
				BaseDLL.decode_uint32(buffer, ref pos_, ref usedTime);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonRaceEndRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506812;
		public UInt32 result;
		public byte score;
		public UInt32 usedTime;
		public UInt32 killMonsterTotalExp;
		public UInt32 raceEndExp;
		public byte hasRaceEndDrop;
		public byte raceEndDropBaseMulti;
		public DungeonAdditionInfo addition = new DungeonAdditionInfo();
		public ItemReward teamReward = new ItemReward();
		/// <summary>
		///  有没有结算翻牌
		/// </summary>
		public byte hasRaceEndChest;
		/// <summary>
		///  月卡结算金币奖励
		/// </summary>
		public UInt32 monthcartGoldReward;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, score);
				BaseDLL.encode_uint32(buffer, ref pos_, usedTime);
				BaseDLL.encode_uint32(buffer, ref pos_, killMonsterTotalExp);
				BaseDLL.encode_uint32(buffer, ref pos_, raceEndExp);
				BaseDLL.encode_int8(buffer, ref pos_, hasRaceEndDrop);
				BaseDLL.encode_int8(buffer, ref pos_, raceEndDropBaseMulti);
				addition.encode(buffer, ref pos_);
				teamReward.encode(buffer, ref pos_);
				BaseDLL.encode_int8(buffer, ref pos_, hasRaceEndChest);
				BaseDLL.encode_uint32(buffer, ref pos_, monthcartGoldReward);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref score);
				BaseDLL.decode_uint32(buffer, ref pos_, ref usedTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref killMonsterTotalExp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref raceEndExp);
				BaseDLL.decode_int8(buffer, ref pos_, ref hasRaceEndDrop);
				BaseDLL.decode_int8(buffer, ref pos_, ref raceEndDropBaseMulti);
				addition.decode(buffer, ref pos_);
				teamReward.decode(buffer, ref pos_);
				BaseDLL.decode_int8(buffer, ref pos_, ref hasRaceEndChest);
				BaseDLL.decode_uint32(buffer, ref pos_, ref monthcartGoldReward);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonChestNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506816;
		/// <summary>
		///  宝箱付费货币类型
		/// </summary>
		public UInt32 payChestCostItemId;
		/// <summary>
		///  宝箱付费货币数量
		/// </summary>
		public UInt32 payChestCost;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, payChestCostItemId);
				BaseDLL.encode_uint32(buffer, ref pos_, payChestCost);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref payChestCostItemId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref payChestCost);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonOpenChestReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506813;
		public byte pos;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, pos);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
			}
		#endregion

	}

	public class DungeonChest : Protocol.IProtocolStream
	{
		public UInt32 itemId;
		public UInt32 num;
		public byte type;
		public UInt32 goldReward;
		public byte isRareControl;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, itemId);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, goldReward);
				BaseDLL.encode_int8(buffer, ref pos_, isRareControl);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref goldReward);
				BaseDLL.decode_int8(buffer, ref pos_, ref isRareControl);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonOpenChestRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506814;
		public UInt64 owner;
		public byte pos;
		public DungeonChest chest = new DungeonChest();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, owner);
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				chest.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref owner);
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				chest.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  请求复活
	/// </summary>
	[Protocol]
	public class SceneDungeonReviveReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506817;
		/// <summary>
		///  要复活的目标
		/// </summary>
		public UInt64 targetId;
		/// <summary>
		///  每一次复活都有一个ID
		/// </summary>
		public UInt32 reviveId;
		/// <summary>
		///  消耗的复活币数量
		/// </summary>
		public UInt32 reviveCoinNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, targetId);
				BaseDLL.encode_uint32(buffer, ref pos_, reviveId);
				BaseDLL.encode_uint32(buffer, ref pos_, reviveCoinNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref targetId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref reviveId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref reviveCoinNum);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonReviveRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506818;
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
	/// 玩家杀死怪物通知
	/// </summary>
	[Protocol]
	public class SceneDungeonKillMonsterReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506819;
		public UInt32[] monsterIds = new UInt32[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)monsterIds.Length);
				for(int i = 0; i < monsterIds.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, monsterIds[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 monsterIdsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref monsterIdsCnt);
				monsterIds = new UInt32[monsterIdsCnt];
				for(int i = 0; i < monsterIds.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref monsterIds[i]);
				}
			}
		#endregion

	}

	/// <summary>
	/// 玩家杀死怪物返回
	/// </summary>
	[Protocol]
	public class SceneDungeonKillMonsterRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506820;
		public UInt32[] monsterIds = new UInt32[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)monsterIds.Length);
				for(int i = 0; i < monsterIds.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, monsterIds[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 monsterIdsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref monsterIdsCnt);
				monsterIds = new UInt32[monsterIdsCnt];
				for(int i = 0; i < monsterIds.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref monsterIds[i]);
				}
			}
		#endregion

	}

	/// <summary>
	/// 玩家杀死怪物返回
	/// </summary>
	[Protocol]
	public class SceneDungeonClearAreaMonsters : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506821;
		/// <summary>
		///  使用时间(ms)
		/// </summary>
		public UInt32 usedTime;
		/// <summary>
		///  剩余血量
		/// </summary>
		public UInt32 remainHp;
		/// <summary>
		///  剩余蓝量
		/// </summary>
		public UInt32 remainMp;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, usedTime);
				BaseDLL.encode_uint32(buffer, ref pos_, remainHp);
				BaseDLL.encode_uint32(buffer, ref pos_, remainMp);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref usedTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainHp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainMp);
			}
		#endregion

	}

	/// <summary>
	///  地下城开放信息
	/// </summary>
	public class DungeonOpenInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  地下城ID
		/// </summary>
		public UInt32 id;
		/// <summary>
		///  是否开放深渊模式(1:开放，0:不开放)
		/// </summary>
		public byte hellMode;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, hellMode);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref hellMode);
			}
		#endregion

	}

	/// <summary>
	/// 同步新开放的地下城列表
	/// </summary>
	[Protocol]
	public class SceneDungeonSyncNewOpenedList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506822;
		/// <summary>
		/// 新开放的地下城列表
		/// </summary>
		public DungeonOpenInfo[] newOpenedList = new DungeonOpenInfo[0];
		/// <summary>
		/// 新关闭掉的地下城列表
		/// </summary>
		public UInt32[] newClosedList = new UInt32[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)newOpenedList.Length);
				for(int i = 0; i < newOpenedList.Length; i++)
				{
					newOpenedList[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)newClosedList.Length);
				for(int i = 0; i < newClosedList.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, newClosedList[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 newOpenedListCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref newOpenedListCnt);
				newOpenedList = new DungeonOpenInfo[newOpenedListCnt];
				for(int i = 0; i < newOpenedList.Length; i++)
				{
					newOpenedList[i] = new DungeonOpenInfo();
					newOpenedList[i].decode(buffer, ref pos_);
				}
				UInt16 newClosedListCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref newClosedListCnt);
				newClosedList = new UInt32[newClosedListCnt];
				for(int i = 0; i < newClosedList.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref newClosedList[i]);
				}
			}
		#endregion

	}

	/// <summary>
	///  请求结算掉落
	/// </summary>
	[Protocol]
	public class SceneDungeonEndDropReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506823;
		/// <summary>
		///  倍率
		/// </summary>
		public byte multi;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, multi);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref multi);
			}
		#endregion

	}

	/// <summary>
	///  返回结算掉落
	/// </summary>
	[Protocol]
	public class SceneDungeonEndDropRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506824;
		/// <summary>
		///  总倍率（0代表获取失败）
		/// </summary>
		public byte multi;
		/// <summary>
		///  掉落物品
		/// </summary>
		public SceneDungeonDropItem[] items = new SceneDungeonDropItem[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, multi);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref multi);
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new SceneDungeonDropItem[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new SceneDungeonDropItem();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  请求扫荡死亡之塔
	/// </summary>
	[Protocol]
	public class SceneTowerWipeoutReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507201;

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
	///  扫荡死亡之塔返回
	/// </summary>
	[Protocol]
	public class SceneTowerWipeoutRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507202;
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
	///  请求死亡之塔扫荡奖励
	/// </summary>
	[Protocol]
	public class SceneTowerWipeoutResultReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507203;

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
	///  死亡之塔扫荡奖励返回
	/// </summary>
	[Protocol]
	public class SceneTowerWipeoutResultRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507204;
		public UInt32 result;
		public SceneDungeonDropItem[] items = new SceneDungeonDropItem[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new SceneDungeonDropItem[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new SceneDungeonDropItem();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  请求快速完成死亡之塔扫荡
	/// </summary>
	[Protocol]
	public class SceneTowerWipeoutQuickFinishReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507205;

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
	///  快速完成死亡之塔返回
	/// </summary>
	[Protocol]
	public class SceneTowerWipeoutQuickFinishRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507206;
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
	///  请求重置死亡之塔
	/// </summary>
	[Protocol]
	public class SceneTowerResetReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507207;

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
	///  重置死亡之塔返回
	/// </summary>
	[Protocol]
	public class SceneTowerResetRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507208;
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
	///  请求死亡之塔首通奖励
	/// </summary>
	[Protocol]
	public class SceneTowerFloorAwardReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507209;
		public UInt32 floor;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, floor);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref floor);
			}
		#endregion

	}

	/// <summary>
	///  领取死亡之塔首通奖励返回
	/// </summary>
	[Protocol]
	public class SceneTowerFloorAwardRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507210;
		public UInt32 result;
		public SceneDungeonDropItem[] items = new SceneDungeonDropItem[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)items.Length);
				for(int i = 0; i < items.Length; i++)
				{
					items[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new SceneDungeonDropItem[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new SceneDungeonDropItem();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  请求购买地下城次数
	/// </summary>
	[Protocol]
	public class SceneDungeonBuyTimesReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506831;
		public byte subType;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, subType);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref subType);
			}
		#endregion

	}

	/// <summary>
	///  购买地下城次数返回
	/// </summary>
	[Protocol]
	public class SceneDungeonBuyTimesRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 506832;
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
	///  通知服务器进入比赛了
	/// </summary>
	[Protocol]
	public class WorldDungeonEnterRaceReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 606809;

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
	///  服务器返回玩家进入比赛
	/// </summary>
	[Protocol]
	public class WorldDungeonEnterRaceRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 606810;
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

}
