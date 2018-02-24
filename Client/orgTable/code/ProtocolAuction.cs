using System;
using System.Text;

namespace Protocol
{
	public enum AuctionType
	{
		Item = 0,
		Gold = 1,
	}

	public enum AuctionSortType
	{
		/// <summary>
		///  按价格升序
		/// </summary>
		PriceAsc = 0,
		/// <summary>
		///  按价格降序
		/// </summary>
		PriceDesc = 1,
	}

	public enum AuctionSellDuration
	{
		/// <summary>
		///  24小时
		/// </summary>
		Hour_24 = 0,
		/// <summary>
		///  48小时
		/// </summary>
		Hour_48 = 1,
	}

	public enum AuctionMainItemType
	{
		/// <summary>
		///  无效
		/// </summary>
		AMIT_INVALID = 0,
		/// <summary>
		///  武器
		/// </summary>
		AMIT_WEAPON = 1,
		/// <summary>
		///  防具
		/// </summary>
		AMIT_ARMOR = 2,
		/// <summary>
		///  首饰
		/// </summary>
		AMIT_JEWELRY = 3,
		/// <summary>
		///  消耗品
		/// </summary>
		AMIT_COST = 4,
		/// <summary>
		///  材料
		/// </summary>
		AMIT_MATERIAL = 5,
		/// <summary>
		///  其它
		/// </summary>
		AMIT_OTHER = 6,
		/// <summary>
		///  数量
		/// </summary>
		AMIT_NUM = 7,
	}

	/// <summary>
	///  拍卖行刷新原因
	/// </summary>
	public enum AuctionRefreshReason
	{
		/// <summary>
		///  购买
		/// </summary>
		SRR_BUY = 0,
		/// <summary>
		///  上架
		/// </summary>
		SRR_SELL = 1,
		/// <summary>
		///  下架
		/// </summary>
		SRR_CANCEL = 2,
	}

	public class AuctionQueryCondition : Protocol.IProtocolStream
	{
		/// <summary>
		///  拍卖类型
		/// </summary>
		public byte type;
		/// <summary>
		///  物品主类型(AuctionMainItemType)
		/// </summary>
		public byte itemMainType;
		/// <summary>
		///  物品子类型
		/// </summary>
		public UInt32[] itemSubTypes = new UInt32[0];
		/// <summary>
		///  物品ID
		/// </summary>
		public UInt32 itemTypeID;
		/// <summary>
		///  品质
		/// </summary>
		public byte quality;
		/// <summary>
		///  最低物品等级
		/// </summary>
		public byte minLevel;
		/// <summary>
		///  最高物品等级
		/// </summary>
		public byte maxLevel;
		/// <summary>
		///  最低强化等级
		/// </summary>
		public byte minStrength;
		/// <summary>
		///  最高强化等级
		/// </summary>
		public byte maxStrength;
		/// <summary>
		///  排序方式（对应枚举AuctionSortType）
		/// </summary>
		public byte sortType;
		/// <summary>
		///  页数
		/// </summary>
		public UInt16 page;
		/// <summary>
		///  每页物品数量
		/// </summary>
		public byte itemNumPerPage;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, itemMainType);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)itemSubTypes.Length);
				for(int i = 0; i < itemSubTypes.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, itemSubTypes[i]);
				}
				BaseDLL.encode_uint32(buffer, ref pos_, itemTypeID);
				BaseDLL.encode_int8(buffer, ref pos_, quality);
				BaseDLL.encode_int8(buffer, ref pos_, minLevel);
				BaseDLL.encode_int8(buffer, ref pos_, maxLevel);
				BaseDLL.encode_int8(buffer, ref pos_, minStrength);
				BaseDLL.encode_int8(buffer, ref pos_, maxStrength);
				BaseDLL.encode_int8(buffer, ref pos_, sortType);
				BaseDLL.encode_uint16(buffer, ref pos_, page);
				BaseDLL.encode_int8(buffer, ref pos_, itemNumPerPage);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref itemMainType);
				UInt16 itemSubTypesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref itemSubTypesCnt);
				itemSubTypes = new UInt32[itemSubTypesCnt];
				for(int i = 0; i < itemSubTypes.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref itemSubTypes[i]);
				}
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemTypeID);
				BaseDLL.decode_int8(buffer, ref pos_, ref quality);
				BaseDLL.decode_int8(buffer, ref pos_, ref minLevel);
				BaseDLL.decode_int8(buffer, ref pos_, ref maxLevel);
				BaseDLL.decode_int8(buffer, ref pos_, ref minStrength);
				BaseDLL.decode_int8(buffer, ref pos_, ref maxStrength);
				BaseDLL.decode_int8(buffer, ref pos_, ref sortType);
				BaseDLL.decode_uint16(buffer, ref pos_, ref page);
				BaseDLL.decode_int8(buffer, ref pos_, ref itemNumPerPage);
			}
		#endregion

	}

	/// <summary>
	///  拍卖行道具基本信息（类型，数量）
	/// </summary>
	public class AuctionItemBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  道具ID
		/// </summary>
		public UInt32 itemTypeId;
		/// <summary>
		///  道具数量
		/// </summary>
		public UInt32 num;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, itemTypeId);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemTypeId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603901;
		public AuctionQueryCondition cond = new AuctionQueryCondition();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				cond.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				cond.decode(buffer, ref pos_);
			}
		#endregion

	}

	public class AuctionBaseInfo : Protocol.IProtocolStream
	{
		/// <summary>
		///  唯一id
		/// </summary>
		public UInt64 guid;
		public UInt32 price;
		public byte pricetype;
		public UInt32 duetime;
		public UInt32 num;
		public UInt32 itemTypeId;
		public UInt32 strengthed;
		public UInt32 itemScore;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, guid);
				BaseDLL.encode_uint32(buffer, ref pos_, price);
				BaseDLL.encode_int8(buffer, ref pos_, pricetype);
				BaseDLL.encode_uint32(buffer, ref pos_, duetime);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
				BaseDLL.encode_uint32(buffer, ref pos_, itemTypeId);
				BaseDLL.encode_uint32(buffer, ref pos_, strengthed);
				BaseDLL.encode_uint32(buffer, ref pos_, itemScore);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref guid);
				BaseDLL.decode_uint32(buffer, ref pos_, ref price);
				BaseDLL.decode_int8(buffer, ref pos_, ref pricetype);
				BaseDLL.decode_uint32(buffer, ref pos_, ref duetime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemTypeId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref strengthed);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemScore);
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionListQueryRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603902;
		public byte type;
		public AuctionBaseInfo[] data = new AuctionBaseInfo[0];
		public UInt32 curPage;
		public UInt32 maxPage;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)data.Length);
				for(int i = 0; i < data.Length; i++)
				{
					data[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint32(buffer, ref pos_, curPage);
				BaseDLL.encode_uint32(buffer, ref pos_, maxPage);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				UInt16 dataCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dataCnt);
				data = new AuctionBaseInfo[dataCnt];
				for(int i = 0; i < data.Length; i++)
				{
					data[i] = new AuctionBaseInfo();
					data[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_uint32(buffer, ref pos_, ref curPage);
				BaseDLL.decode_uint32(buffer, ref pos_, ref maxPage);
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionSelfListReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603904;
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
	public class WorldAuctionSelfListRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603905;
		public byte type;
		public AuctionBaseInfo[] data = new AuctionBaseInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)data.Length);
				for(int i = 0; i < data.Length; i++)
				{
					data[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				UInt16 dataCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dataCnt);
				data = new AuctionBaseInfo[dataCnt];
				for(int i = 0; i < data.Length; i++)
				{
					data[i] = new AuctionBaseInfo();
					data[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionRequest : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603906;
		/// <summary>
		///  拍卖类型
		/// </summary>
		public byte type;
		/// <summary>
		///  拍卖道具id
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  拍卖道具类型id
		/// </summary>
		public UInt32 typeId;
		/// <summary>
		///  数量
		/// </summary>
		public UInt32 num;
		/// <summary>
		///  价格
		/// </summary>
		public UInt32 price;
		/// <summary>
		///  持续时间(AuctionSellDuration)
		/// </summary>
		public byte duration;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, typeId);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
				BaseDLL.encode_uint32(buffer, ref pos_, price);
				BaseDLL.encode_int8(buffer, ref pos_, duration);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref typeId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
				BaseDLL.decode_uint32(buffer, ref pos_, ref price);
				BaseDLL.decode_int8(buffer, ref pos_, ref duration);
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionBuy : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603908;
		public UInt64 id;
		public UInt32 num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref num);
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionCancel : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603909;
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

	[Protocol]
	public class WorldAuctionNotifyRefresh : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603911;
		/// <summary>
		///  拍卖行类型
		/// </summary>
		public byte type;
		/// <summary>
		///  原因
		/// </summary>
		public byte reason;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_int8(buffer, ref pos_, reason);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_int8(buffer, ref pos_, ref reason);
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionQueryItemReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603916;
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

	[Protocol]
	public class WorldAuctionQueryItemRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603917;

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
	public class WorldAuctionRecommendPriceReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603918;
		public byte type;
		public UInt32 itemTypeId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, itemTypeId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemTypeId);
			}
		#endregion

	}

	[Protocol]
	public class WorldAuctionRecommendPriceRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603919;
		public byte type;
		public UInt32 itemTypeId;
		public UInt32 price;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint32(buffer, ref pos_, itemTypeId);
				BaseDLL.encode_uint32(buffer, ref pos_, price);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint32(buffer, ref pos_, ref itemTypeId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref price);
			}
		#endregion

	}

	/// <summary>
	///  查询拍卖行道具数量
	/// </summary>
	[Protocol]
	public class WorldAuctionItemNumReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603920;
		public AuctionQueryCondition cond = new AuctionQueryCondition();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				cond.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				cond.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  返回拍卖行道具数量
	/// </summary>
	[Protocol]
	public class WorldAuctionItemNumRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 603921;
		public AuctionItemBaseInfo[] items = new AuctionItemBaseInfo[0];

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
				items = new AuctionItemBaseInfo[itemsCnt];
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = new AuctionItemBaseInfo();
					items[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  刷新拍卖行时间请求
	/// </summary>
	[Protocol]
	public class SceneAuctionRefreshReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 503901;

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
	///  刷新拍卖行时间返回
	/// </summary>
	[Protocol]
	public class SceneAuctionRefreshRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 503902;
		/// <summary>
		///  结果
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
	///  购买拍卖行栏位请求
	/// </summary>
	[Protocol]
	public class SceneAuctionBuyBoothReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 503903;

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
	///  购买拍卖行栏位返回
	/// </summary>
	[Protocol]
	public class SceneAuctionBuyBoothRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 503904;
		/// <summary>
		///  结果
		/// </summary>
		public UInt32 result;
		/// <summary>
		///  栏位数
		/// </summary>
		public UInt32 boothNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, boothNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref boothNum);
			}
		#endregion

	}

}
