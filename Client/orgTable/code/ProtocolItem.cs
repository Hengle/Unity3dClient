using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	/// 商城玩家绑定礼包激活条件
	/// </summary>
	public enum MallGiftPackActivateCond
	{
		/// <summary>
		/// 无
		/// </summary>
		INVALID = 0,
		/// <summary>
		/// 强化到10
		/// </summary>
		STRENGEN_TEN = 1,
		/// <summary>
		/// 强化资源不足	
		/// </summary>
		STRENGEN_NO_RESOURCE = 2,
		/// <summary>
		/// 品级调整箱不足
		/// </summary>
		NO_QUILTY_ADJUST_BOX = 3,
		/// <summary>
		/// 疲劳不足，且背包中无疲劳药水
		/// </summary>
		NO_FATIGUE = 4,
		/// <summary>
		/// 刷深渊门票不足	
		/// </summary>
		NO_HELL_TICKET = 5,
		/// <summary>
		/// 刷远古门票不足	
		/// </summary>
		NO_ANCIENT_TICKET = 6,
		/// <summary>
		/// 死亡
		/// </summary>
		DIE = 7,
		/// <summary>
		/// 强化装备碎掉,推送10级装备
		/// </summary>
		STRENGEN_BROKE_TEN = 8,
		/// <summary>
		/// 强化装备碎掉,推送15级装备
		/// </summary>
		STRENGEN_BROKE_FIFTEEN = 9,
		/// <summary>
		/// 强化装备碎掉,推送20级装备
		/// </summary>
		STRENGEN_BROKE_TWENTY = 10,
		/// <summary>
		/// 强化装备碎掉,推送25级装备
		/// </summary>
		STRENGEN_BROKE_TWENTY_FIVE = 11,
		/// <summary>
		/// 强化装备碎掉,推送30级装备
		/// </summary>
		STRENGEN_BROKE_THIRTY = 12,
		/// <summary>
		/// 强化装备碎掉,推送35级装备
		/// </summary>
		STRENGEN_BROKE_THIRTY_FIVE = 13,
		/// <summary>
		/// 强化装备碎掉,推送40级装备
		/// </summary>
		STRENGEN_BROKE_FORTY = 14,
		/// <summary>
		/// 强化装备碎掉,推送45级装备
		/// </summary>
		STRENGEN_BROKE_FORTY_FIVE = 15,
		/// <summary>
		/// 强化装备碎掉,推送50级装备
		/// </summary>
		STRENGEN_BROKE_FIFTY = 16,
	}

	/// <summary>
	/// 商城商品类型
	/// </summary>
	public enum MallGoodsType
	{
		/// <summary>
		/// 普通商品
		/// </summary>
		INVALID = 0,
		/// <summary>
		/// 礼包：可每日刷新
		/// </summary>
		GIFT_DAILY_REFRESH = 1,
		/// <summary>
		/// 礼包：账号激活限制一次
		/// </summary>
		GIFT_ACTIVATE_ONCE = 2,
		/// <summary>
		/// 礼包：账号激活限制三次礼包
		/// </summary>
		GIFT_ACTIVATE_THREE_TIMES = 3,
		/// <summary>
		/// 普通商品：可多选一
		/// </summary>
		COMMON_CHOOSE_ONE = 4,
		/// <summary>
		/// 礼包：限时活动
		/// </summary>
		GIFT_ACTIVITY = 5,
		/// <summary>
		/// 礼包: 普通不刷新礼包
		/// </summary>
		GIFT_COMMON = 6,
	}

	/// <summary>
	/// 商城礼包活动状态
	/// </summary>
	public enum MallGiftPackActivityState
	{
		/// <summary>
		/// 无效
		/// </summary>
		GPAS_INVALID = 0,
		/// <summary>
		/// 开放
		/// </summary>
		GPAS_OPEN = 1,
		/// <summary>
		/// 关闭
		/// </summary>
		GPAS_CLOSED = 2,
	}

	/// <summary>
	///  快速购买目标类型
	/// </summary>
	public enum QuickBuyTargetType
	{
		/// <summary>
		///  复活
		/// </summary>
		QUICK_BUY_REVIVE = 0,
		/// <summary>
		///  购买道具
		/// </summary>
		QUICK_BUY_ITEM = 1,
	}

	public enum FashionMergeResultType
	{
		FMRT_NORMAL = 1,
		FMRT_SPECIAL = 2,
	}

	public class ItemRandProp : Protocol.IProtocolStream
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

	public class GemStone : Protocol.IProtocolStream
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

	public class ItemMagicProperty : Protocol.IProtocolStream
	{
		public byte type;
		/// <summary>
		/// 1.随机属性，2.buff
		/// </summary>
		public UInt32 param1;
		/// <summary>
		/// 随机属性: 属性id，buff:buffid
		/// </summary>
		public UInt32 param2;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, param1);
				BaseDLL.encode_uint32(buffer, ref pos_, param2);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param1);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param2);
			}
		#endregion

	}

	/// <summary>
	/// 随机属性: 属性值，buff:无用
	/// </summary>
	public class ItemReward : Protocol.IProtocolStream
	{
		public UInt32 id;
		public UInt32 num;
		/// <summary>
		///  强化等级
		/// </summary>
		public byte strength;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
				BaseDLL.encode_int8(buffer, ref pos_, strength);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
				BaseDLL.decode_int8(buffer, ref pos_, ref strength);
			}
		#endregion

	}

	public class OpenJarResult : Protocol.IProtocolStream
	{
		public UInt32 jarItemId;
		public UInt64 itemUid;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, jarItemId);
				BaseDLL.encode_uint64(buffer, ref pos_, itemUid);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref jarItemId);
				BaseDLL.decode_uint64(buffer, ref pos_, ref itemUid);
			}
		#endregion

	}

	public class ItemCD : Protocol.IProtocolStream
	{
		public byte groupid;
		public UInt32 endtime;
		public UInt32 maxtime;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, groupid);
				BaseDLL.encode_uint32(buffer, ref pos_, endtime);
				BaseDLL.encode_uint32(buffer, ref pos_, maxtime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref groupid);
				BaseDLL.decode_uint32(buffer, ref pos_, ref endtime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref maxtime);
			}
		#endregion

	}

	public class MallItemInfo : Protocol.IProtocolStream
	{
		public UInt32 id;
		public byte type;
		public byte subtype;
		public byte jobtype;
		public UInt32 itemid;
		public UInt32 itemnum;
		public UInt32 price;
		public UInt32 discountprice;
		public byte moneytype;
		public byte limit;
		public UInt16 limitnum;
		public byte gift;
		public UInt16 vipscore;
		public string icon;
		public UInt32 starttime;
		public UInt32 endtime;
		public UInt16 limittotalnum;
		public ItemReward[] giftItems = new ItemReward[0];
		public string giftName;
		public byte tagType;
		public UInt32 sortIdx;
		public UInt32 hotSortIdx;
		public UInt16 goodsSubType;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, subtype);
				BaseDLL.encode_int8(buffer, ref pos_, jobtype);
				BaseDLL.encode_uint32(buffer, ref pos_, itemid);
				BaseDLL.encode_uint32(buffer, ref pos_, itemnum);
				BaseDLL.encode_uint32(buffer, ref pos_, price);
				BaseDLL.encode_uint32(buffer, ref pos_, discountprice);
				BaseDLL.encode_int8(buffer, ref pos_, moneytype);
				BaseDLL.encode_int8(buffer, ref pos_, limit);
				BaseDLL.encode_uint16(buffer, ref pos_, limitnum);
				BaseDLL.encode_int8(buffer, ref pos_, gift);
				BaseDLL.encode_uint16(buffer, ref pos_, vipscore);
				byte[] iconBytes = StringHelper.StringToUTF8Bytes(icon);
				BaseDLL.encode_string(buffer, ref pos_, iconBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, starttime);
				BaseDLL.encode_uint32(buffer, ref pos_, endtime);
				BaseDLL.encode_uint16(buffer, ref pos_, limittotalnum);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)giftItems.Length);
				for(int i = 0; i < giftItems.Length; i++)
				{
					giftItems[i].encode(buffer, ref pos_);
				}
				byte[] giftNameBytes = StringHelper.StringToUTF8Bytes(giftName);
				BaseDLL.encode_string(buffer, ref pos_, giftNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, tagType);
				BaseDLL.encode_uint32(buffer, ref pos_, sortIdx);
				BaseDLL.encode_uint32(buffer, ref pos_, hotSortIdx);
				BaseDLL.encode_uint16(buffer, ref pos_, goodsSubType);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref subtype);
				BaseDLL.decode_int8(buffer, ref pos_, ref jobtype);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemid);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemnum);
				BaseDLL.decode_uint32(buffer, ref pos_, ref price);
				BaseDLL.decode_uint32(buffer, ref pos_, ref discountprice);
				BaseDLL.decode_int8(buffer, ref pos_, ref moneytype);
				BaseDLL.decode_int8(buffer, ref pos_, ref limit);
				BaseDLL.decode_uint16(buffer, ref pos_, ref limitnum);
				BaseDLL.decode_int8(buffer, ref pos_, ref gift);
				BaseDLL.decode_uint16(buffer, ref pos_, ref vipscore);
				UInt16 iconLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref iconLen);
				byte[] iconBytes = new byte[iconLen];
				for(int i = 0; i < iconLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref iconBytes[i]);
				}
				icon = StringHelper.BytesToString(iconBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref starttime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref endtime);
				BaseDLL.decode_uint16(buffer, ref pos_, ref limittotalnum);
				UInt16 giftItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref giftItemsCnt);
				giftItems = new ItemReward[giftItemsCnt];
				for(int i = 0; i < giftItems.Length; i++)
				{
					giftItems[i] = new ItemReward();
					giftItems[i].decode(buffer, ref pos_);
				}
				UInt16 giftNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref giftNameLen);
				byte[] giftNameBytes = new byte[giftNameLen];
				for(int i = 0; i < giftNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref giftNameBytes[i]);
				}
				giftName = StringHelper.BytesToString(giftNameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref tagType);
				BaseDLL.decode_uint32(buffer, ref pos_, ref sortIdx);
				BaseDLL.decode_uint32(buffer, ref pos_, ref hotSortIdx);
				BaseDLL.decode_uint16(buffer, ref pos_, ref goodsSubType);
			}
		#endregion

	}

	[Protocol]
	public class SceneSynItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500905;

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
	public class SceneSyncItemProp : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500906;

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
	public class SceneNotifyDeleteItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500907;
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

	[Protocol]
	public class SceneUseItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500901;
		public UInt64 uid;
		public byte useAll;
		public UInt32 param1;
		public UInt32 param2;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, uid);
				BaseDLL.encode_int8(buffer, ref pos_, useAll);
				BaseDLL.encode_uint32(buffer, ref pos_, param1);
				BaseDLL.encode_uint32(buffer, ref pos_, param2);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref uid);
				BaseDLL.decode_int8(buffer, ref pos_, ref useAll);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param1);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param2);
			}
		#endregion

	}

	[Protocol]
	public class SceneUseItemRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500902;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneSellItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500903;
		public UInt64 uid;
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

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

	[Protocol]
	public class SceneSellItemRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500904;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneEnlargePackage : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500908;

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
	public class SceneEnlargePackageRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500917;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class ScenePushStorage : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500909;
		public UInt64 uid;
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

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

	[Protocol]
	public class ScenePushStorageRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500911;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class ScenePullStorage : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500910;
		public UInt64 uid;
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

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

	[Protocol]
	public class ScenePullStorageRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500912;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneEnlargeStorage : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500913;

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
	public class SceneTrimItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500914;
		public byte pack;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, pack);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref pack);
			}
		#endregion

	}

	[Protocol]
	public class SceneTrimItemRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500915;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyGetItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500916;
		public UInt32 itemid;
		public byte quality;
		public UInt32 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, itemid);
				BaseDLL.encode_int8(buffer, ref pos_, quality);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemid);
				BaseDLL.decode_int8(buffer, ref pos_, ref quality);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
			}
		#endregion

	}

	[Protocol]
	public class SceneEquipDecompose : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500918;
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

	[Protocol]
	public class SceneEquipDecomposeRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500919;
		public UInt32 code;
		public ItemReward[] getItems = new ItemReward[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)getItems.Length);
				for(int i = 0; i < getItems.Length; i++)
				{
					getItems[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
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
	/// 抽到的道具
	/// </summary>
	[Protocol]
	public class SceneEquipStrengthen : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500920;
		public UInt64 euqipUid;
		public byte useUnbreak;
		public UInt64 strTickt;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, euqipUid);
				BaseDLL.encode_int8(buffer, ref pos_, useUnbreak);
				BaseDLL.encode_uint64(buffer, ref pos_, strTickt);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref euqipUid);
				BaseDLL.decode_int8(buffer, ref pos_, ref useUnbreak);
				BaseDLL.decode_uint64(buffer, ref pos_, ref strTickt);
			}
		#endregion

	}

	[Protocol]
	public class SceneEquipStrengthenRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500921;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	/// <summary>
	/// ------------商店start------------------------------
	/// </summary>
	[Protocol]
	public class SceneShopQuery : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500922;
		public byte shopId;
		public byte cache;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, shopId);
				BaseDLL.encode_int8(buffer, ref pos_, cache);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref shopId);
				BaseDLL.decode_int8(buffer, ref pos_, ref cache);
			}
		#endregion

	}

	[Protocol]
	public class SceneShopQueryRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500923;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneShopBuy : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500924;
		public byte shopId;
		public UInt32 shopItemId;
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, shopId);
				BaseDLL.encode_uint32(buffer, ref pos_, shopItemId);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref shopId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref shopItemId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	[Protocol]
	public class SceneShopBuyRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500925;
		public UInt32 code;
		public UInt32 shopItemId;
		public UInt16 newNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint32(buffer, ref pos_, shopItemId);
				BaseDLL.encode_uint16(buffer, ref pos_, newNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
				BaseDLL.decode_uint32(buffer, ref pos_, ref shopItemId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref newNum);
			}
		#endregion

	}

	[Protocol]
	public class SceneShopSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500926;

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
	public class SceneShopItemSync : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500927;

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
	public class SceneShopRefresh : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500932;
		public byte shopId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, shopId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref shopId);
			}
		#endregion

	}

	[Protocol]
	public class SceneShopRefreshRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500933;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneShopRefreshNumReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500956;
		public byte shopId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, shopId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref shopId);
			}
		#endregion

	}

	[Protocol]
	public class SceneShopRefreshNumRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500957;
		public byte shopId;
		public byte restRefreshNum;
		public byte maxRefreshNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, shopId);
				BaseDLL.encode_int8(buffer, ref pos_, restRefreshNum);
				BaseDLL.encode_int8(buffer, ref pos_, maxRefreshNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref shopId);
				BaseDLL.decode_int8(buffer, ref pos_, ref restRefreshNum);
				BaseDLL.decode_int8(buffer, ref pos_, ref maxRefreshNum);
			}
		#endregion

	}

	/// <summary>
	/// ------------商店end------------------------------
	/// </summary>
	[Protocol]
	public class SceneOneKeyPushStorage : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500928;

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
	public class SceneOneKeyPushStorageRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500929;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneEnlargeStorageRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500930;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneUpdateNewItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500931;
		public byte pack;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, pack);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref pack);
			}
		#endregion

	}

	[Protocol]
	public class SceneDungeonUseItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500934;
		public UInt32 itemid;
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, itemid);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemid);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	[Protocol]
	public class SceneSealEquipReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500937;
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

	/// <summary>
	///  装备uid
	/// </summary>
	[Protocol]
	public class SceneSealEquipRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500938;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	/// <summary>
	/// 返回码
	/// </summary>
	[Protocol]
	public class SceneCheckSealEquipReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500939;
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

	/// <summary>
	///  装备uid
	/// </summary>
	[Protocol]
	public class SceneCheckSealEquipRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500940;
		public UInt32 code;
		/// <summary>
		/// 返回码
		/// </summary>
		public UInt32 matID;
		/// <summary>
		/// 材料ID
		/// </summary>
		public UInt16 needNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint32(buffer, ref pos_, matID);
				BaseDLL.encode_uint16(buffer, ref pos_, needNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
				BaseDLL.decode_uint32(buffer, ref pos_, ref matID);
				BaseDLL.decode_uint16(buffer, ref pos_, ref needNum);
			}
		#endregion

	}

	/// <summary>
	/// 需要材料数量
	/// </summary>
	[Protocol]
	public class SceneRandEquipQlvReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500941;
		public UInt64 uid;
		/// <summary>
		/// 装备uid
		/// </summary>
		public byte bUsePoint;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, uid);
				BaseDLL.encode_int8(buffer, ref pos_, bUsePoint);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref uid);
				BaseDLL.decode_int8(buffer, ref pos_, ref bUsePoint);
			}
		#endregion

	}

	/// <summary>
	/// 是否使用绑点代替
	/// </summary>
	[Protocol]
	public class SceneRandEquipQlvRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500942;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	/// <summary>
	/// 返回码
	/// </summary>
	/// <summary>
	/// 开罐子返回
	/// </summary>
	[Protocol]
	public class SceneUseMagicJarRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500943;
		public UInt32 code;
		/// <summary>
		/// 返回码
		/// </summary>
		public UInt32 jarID;
		/// <summary>
		/// 罐子ID
		/// </summary>
		public OpenJarResult[] getItems = new OpenJarResult[0];
		/// <summary>
		/// 抽到的道具
		/// </summary>
		public ItemReward baseItem = new ItemReward();
		/// <summary>
		/// 保底道具
		/// </summary>
		public UInt32 getPointId;
		/// <summary>
		/// 获得积分id
		/// </summary>
		public UInt32 getPoint;
		/// <summary>
		/// 获得积分数量
		/// </summary>
		public UInt32 crit;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint32(buffer, ref pos_, jarID);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)getItems.Length);
				for(int i = 0; i < getItems.Length; i++)
				{
					getItems[i].encode(buffer, ref pos_);
				}
				baseItem.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, getPointId);
				BaseDLL.encode_uint32(buffer, ref pos_, getPoint);
				BaseDLL.encode_uint32(buffer, ref pos_, crit);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
				BaseDLL.decode_uint32(buffer, ref pos_, ref jarID);
				UInt16 getItemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref getItemsCnt);
				getItems = new OpenJarResult[getItemsCnt];
				for(int i = 0; i < getItems.Length; i++)
				{
					getItems[i] = new OpenJarResult();
					getItems[i].decode(buffer, ref pos_);
				}
				baseItem.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref getPointId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref getPoint);
				BaseDLL.decode_uint32(buffer, ref pos_, ref crit);
			}
		#endregion

	}

	/// <summary>
	/// 暴击倍数
	/// </summary>
	/// <summary>
	/// 罐子积分请求
	/// </summary>
	[Protocol]
	public class SceneJarPointReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500960;

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
	/// 罐子积分请求响应
	/// </summary>
	[Protocol]
	public class SceneJarPointRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500961;
		public UInt32 goldPoint;
		public UInt32 magPoint;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, goldPoint);
				BaseDLL.encode_uint32(buffer, ref pos_, magPoint);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref goldPoint);
				BaseDLL.decode_uint32(buffer, ref pos_, ref magPoint);
			}
		#endregion

	}

	/// <summary>
	/// 附魔请求
	/// </summary>
	[Protocol]
	public class SceneAddMagicReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500944;
		public UInt64 cardUid;
		/// <summary>
		/// 附魔卡uid
		/// </summary>
		public UInt64 itemUid;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, cardUid);
				BaseDLL.encode_uint64(buffer, ref pos_, itemUid);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref cardUid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref itemUid);
			}
		#endregion

	}

	/// <summary>
	/// 装备uid
	/// </summary>
	/// <summary>
	/// 附魔请求返回
	/// </summary>
	[Protocol]
	public class SceneAddMagicRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500945;
		public UInt32 code;
		/// <summary>
		/// 返回码
		/// </summary>
		public UInt64 itemUid;
		/// <summary>
		/// 附魔的道具
		/// </summary>
		public UInt32 cardId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint64(buffer, ref pos_, itemUid);
				BaseDLL.encode_uint32(buffer, ref pos_, cardId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
				BaseDLL.decode_uint64(buffer, ref pos_, ref itemUid);
				BaseDLL.decode_uint32(buffer, ref pos_, ref cardId);
			}
		#endregion

	}

	/// <summary>
	/// 附魔的附魔卡表ID
	/// </summary>
	/// <summary>
	/// 附魔卡合成
	/// </summary>
	[Protocol]
	public class SceneMagicCardCompReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500946;
		public UInt64 cardA;
		/// <summary>
		/// 附魔卡A
		/// </summary>
		public UInt64 cardB;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, cardA);
				BaseDLL.encode_uint64(buffer, ref pos_, cardB);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref cardA);
				BaseDLL.decode_uint64(buffer, ref pos_, ref cardB);
			}
		#endregion

	}

	/// <summary>
	/// 附魔卡B
	/// </summary>
	/// <summary>
	/// 附魔卡合成返回
	/// </summary>
	[Protocol]
	public class SceneMagicCardCompRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500947;
		public UInt32 code;
		/// <summary>
		/// 返回码
		/// </summary>
		public UInt32 cardId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint32(buffer, ref pos_, cardId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
				BaseDLL.decode_uint32(buffer, ref pos_, ref cardId);
			}
		#endregion

	}

	/// <summary>
	/// 合成的附魔卡id	
	/// </summary>
	/// <summary>
	/// ------------商城相关-----------------------
	/// </summary>
	/// <summary>
	/// 激活商城限时礼包请求
	/// </summary>
	[Protocol]
	public class WorldMallGiftPackActivateReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602814;
		/// <summary>
		///  对应枚举MallGiftPackActivateCond
		/// </summary>
		public byte giftPackActCond;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, giftPackActCond);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref giftPackActCond);
			}
		#endregion

	}

	/// <summary>
	/// 激活条件
	/// </summary>
	/// <summary>
	/// 激活商城限时礼包返回
	/// </summary>
	[Protocol]
	public class WorldMallGiftPackActivateRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602815;
		public MallItemInfo[] items = new MallItemInfo[0];
		/// <summary>
		/// 一个礼包
		/// </summary>
		public UInt32 code;

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
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 itemsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemsCnt);
				items = new MallItemInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new MallItemInfo();
					items[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	/// <summary>
	/// 错误码
	/// </summary>
	/// <summary>
	/// 同步商城礼包活动状态
	/// </summary>
	[Protocol]
	public class SyncWorldMallGiftPackActivityState : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602817;
		/// <summary>
		/// 对应枚举MallGiftPackActivityState
		/// </summary>
		public byte state;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, state);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref state);
			}
		#endregion

	}

	/// <summary>
	/// 商城礼包活动状态
	/// </summary>
	/// <summary>
	/// 查询商城道具请求
	/// </summary>
	[Protocol]
	public class WorldMallQueryItemReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602803;
		public byte tagType;
		/// <summary>
		/// 商城热门类索引,1-热门
		/// </summary>
		public byte type;
		/// <summary>
		/// 商城主页签
		/// </summary>
		public byte subType;
		/// <summary>
		/// 商城子页签
		/// </summary>
		public byte moneyType;
		/// <summary>
		/// 货币类别
		/// </summary>
		public byte occu;
		/// <summary>
		/// 职业
		/// </summary>
		public UInt32 updateTime;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, tagType);
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, subType);
				BaseDLL.encode_int8(buffer, ref pos_, moneyType);
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_uint32(buffer, ref pos_, updateTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref tagType);
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref subType);
				BaseDLL.decode_int8(buffer, ref pos_, ref moneyType);
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
				BaseDLL.decode_uint32(buffer, ref pos_, ref updateTime);
			}
		#endregion

	}

	/// <summary>
	/// 本地数据更新时间
	/// </summary>
	/// <summary>
	/// 查询商城道具返回
	/// </summary>
	[Protocol]
	public class WorldMallQueryItemRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602804;
		public MallItemInfo[] items = new MallItemInfo[0];

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
				items = new MallItemInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new MallItemInfo();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 商城道具
	/// </summary>
	/// <summary>
	/// 购买商城道具请求
	/// </summary>
	[Protocol]
	public class WorldMallBuy : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602801;
		public UInt32 itemId;
		/// <summary>
		/// 商城道具ID
		/// </summary>
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, itemId);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	/// 购买数量
	/// </summary>
	/// <summary>
	/// 购买商城道具返回
	/// </summary>
	[Protocol]
	public class WorldMallBuyRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602802;
		public UInt32 code;
		/// <summary>
		/// 返回码
		/// </summary>
		public UInt32 mallitemid;
		/// <summary>
		/// 商城道具id
		/// </summary>
		public Int32 restLimitNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint32(buffer, ref pos_, mallitemid);
				BaseDLL.encode_int32(buffer, ref pos_, restLimitNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
				BaseDLL.decode_uint32(buffer, ref pos_, ref mallitemid);
				BaseDLL.decode_int32(buffer, ref pos_, ref restLimitNum);
			}
		#endregion

	}

	/// <summary>
	/// 剩余限购数,-1是没有限购
	/// </summary>
	/// <summary>
	/// 商城批量购买请求
	/// </summary>
	[Protocol]
	public class CWMallBatchBuyReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602812;
		public ItemReward[] items = new ItemReward[0];

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
				items = new ItemReward[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new ItemReward();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 商城批量购买返回
	/// </summary>
	[Protocol]
	public class SCMallBatchBuyRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602813;
		public UInt32 code;
		public UInt64[] itemUids = new UInt64[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)itemUids.Length);
				for(int i = 0; i < itemUids.Length; i++)
				{
					BaseDLL.encode_uint64(buffer, ref pos_, itemUids[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
				UInt16 itemUidsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemUidsCnt);
				itemUids = new UInt64[itemUidsCnt];
				for(int i = 0; i < itemUids.Length; i++)
				{
					BaseDLL.decode_uint64(buffer, ref pos_, ref itemUids[i]);
				}
			}
		#endregion

	}

	/// <summary>
	/// 请求商城礼包详情
	/// </summary>
	[Protocol]
	public class WorldMallQueryItemDetailReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602805;
		public UInt32 mallItemId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, mallItemId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref mallItemId);
			}
		#endregion

	}

	/// <summary>
	/// 商城道具id
	/// </summary>
	public class MallGiftDetail : Protocol.IProtocolStream
	{
		public UInt32 itemId;
		public UInt16 num;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, itemId);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	/// 请求商城礼包详情返回
	/// </summary>
	[Protocol]
	public class WorldMallQueryItemDetailRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 602806;
		public MallGiftDetail[] details = new MallGiftDetail[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)details.Length);
				for(int i = 0; i < details.Length; i++)
				{
					details[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 detailsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref detailsCnt);
				details = new MallGiftDetail[detailsCnt];
				for(int i = 0; i < details.Length; i++)
				{
					details[i] = new MallGiftDetail();
					details[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 快速购买请求
	/// </summary>
	[Protocol]
	public class SceneQuickBuyReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507101;
		/// <summary>
		///  类型(对应枚举QuickBuyTargetType)
		/// </summary>
		public byte type;
		/// <summary>
		///  参数
		/// </summary>
		public UInt64 param1;
		public UInt64 param2;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, param1);
				BaseDLL.encode_uint64(buffer, ref pos_, param2);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref param1);
				BaseDLL.decode_uint64(buffer, ref pos_, ref param2);
			}
		#endregion

	}

	/// <summary>
	/// 快速购买返回
	/// </summary>
	[Protocol]
	public class SceneQuickBuyRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 507102;
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
	/// 开罐子
	/// </summary>
	[Protocol]
	public class SceneUseMagicJarReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500948;
		public UInt32 type;
		/// <summary>
		/// 开罐类型
		/// </summary>
		public byte combo;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, combo);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref combo);
			}
		#endregion

	}

	/// <summary>
	/// 是否连开
	/// </summary>
	[Protocol]
	public class SceneNotifyCostItem : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500949;
		public UInt32 itemid;
		public byte quality;
		public UInt16 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, itemid);
				BaseDLL.encode_int8(buffer, ref pos_, quality);
				BaseDLL.encode_uint16(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemid);
				BaseDLL.decode_int8(buffer, ref pos_, ref quality);
				BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	/// 请求快捷使用关卡道具
	/// </summary>
	[Protocol]
	public class SceneQuickUseItemReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500950;
		public byte idx;
		public UInt32 dungenid;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, idx);
				BaseDLL.encode_uint32(buffer, ref pos_, dungenid);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref idx);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungenid);
			}
		#endregion

	}

	/// <summary>
	/// 请求快捷使用关卡道具返回
	/// </summary>
	[Protocol]
	public class SceneQuickUseItemRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500951;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneFashionMergeReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500952;
		public UInt64 leftid;
		public UInt64 rightid;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, leftid);
				BaseDLL.encode_uint64(buffer, ref pos_, rightid);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref leftid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref rightid);
			}
		#endregion

	}

	[Protocol]
	public class SceneFashionMergeRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500953;
		public Int32 result;
		public byte resultType;
		public UInt32 itemA;
		public Int32 numA;
		public UInt32 itemB;
		public Int32 numB;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, resultType);
				BaseDLL.encode_uint32(buffer, ref pos_, itemA);
				BaseDLL.encode_int32(buffer, ref pos_, numA);
				BaseDLL.encode_uint32(buffer, ref pos_, itemB);
				BaseDLL.encode_int32(buffer, ref pos_, numB);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref resultType);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemA);
				BaseDLL.decode_int32(buffer, ref pos_, ref numA);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemB);
				BaseDLL.decode_int32(buffer, ref pos_, ref numB);
			}
		#endregion

	}

	[Protocol]
	public class SceneEquipMakeReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500954;
		public UInt32 equipId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, equipId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref equipId);
			}
		#endregion

	}

	[Protocol]
	public class SceneEquipMakeRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500955;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	[Protocol]
	public class SceneFashionAttributeSelectReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500958;
		public UInt64 guid;
		public Int32 attributeId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, guid);
				BaseDLL.encode_int32(buffer, ref pos_, attributeId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref guid);
				BaseDLL.decode_int32(buffer, ref pos_, ref attributeId);
			}
		#endregion

	}

	[Protocol]
	public class SceneFashionAttributeSelectRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500959;
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
	/// 开罐记录数据
	/// </summary>
	public class OpenJarRecord : Protocol.IProtocolStream
	{
		public string name;
		public UInt32 itemId;
		public UInt32 num;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, itemId);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
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
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	/// 请求开罐记录
	/// </summary>
	[Protocol]
	public class SceneOpenJarRecordReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 600901;
		public UInt32 jarId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, jarId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref jarId);
			}
		#endregion

	}

	/// <summary>
	/// 返回开罐记录
	/// </summary>
	[Protocol]
	public class SceneOpenJarRecordRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 600902;
		public UInt32 jarId;
		public OpenJarRecord[] records = new OpenJarRecord[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, jarId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)records.Length);
				for(int i = 0; i < records.Length; i++)
				{
					records[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref jarId);
				UInt16 recordsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref recordsCnt);
				records = new OpenJarRecord[recordsCnt];
				for(int i = 0; i < records.Length; i++)
				{
					records[i] = new OpenJarRecord();
					records[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	/// 设置关卡药水配置
	/// </summary>
	[Protocol]
	public class SceneSetDungeonPotionReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500964;
		public UInt32 potionId;
		public byte pos;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, potionId);
				BaseDLL.encode_int8(buffer, ref pos_, pos);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref potionId);
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
			}
		#endregion

	}

	[Protocol]
	public class SceneSetDungeonPotionRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500965;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

	/// <summary>
	/// 续费时限道具
	/// </summary>
	[Protocol]
	public class SceneRenewTimeItemReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500966;
		public UInt64 itemUid;
		public UInt32 duration;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, itemUid);
				BaseDLL.encode_uint32(buffer, ref pos_, duration);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref itemUid);
				BaseDLL.decode_uint32(buffer, ref pos_, ref duration);
			}
		#endregion

	}

	[Protocol]
	public class SceneRenewTimeItemRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500967;
		public UInt32 code;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, code);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref code);
			}
		#endregion

	}

}
