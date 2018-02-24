using System;
using System.Text;

namespace Protocol
{
	public class PetInfo : Protocol.IProtocolStream
	{
		public UInt64 id;
		public UInt32 dataId;
		public UInt16 level;
		public UInt32 exp;
		public UInt16 hunger;
		public byte skillIndex;
		public byte pointFeedCount;
		public byte goldFeedCount;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, dataId);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_uint32(buffer, ref pos_, exp);
				BaseDLL.encode_uint16(buffer, ref pos_, hunger);
				BaseDLL.encode_int8(buffer, ref pos_, skillIndex);
				BaseDLL.encode_int8(buffer, ref pos_, pointFeedCount);
				BaseDLL.encode_int8(buffer, ref pos_, goldFeedCount);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dataId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_uint32(buffer, ref pos_, ref exp);
				BaseDLL.decode_uint16(buffer, ref pos_, ref hunger);
				BaseDLL.decode_int8(buffer, ref pos_, ref skillIndex);
				BaseDLL.decode_int8(buffer, ref pos_, ref pointFeedCount);
				BaseDLL.decode_int8(buffer, ref pos_, ref goldFeedCount);
			}
		#endregion

	}

	public class PetBaseInfo : Protocol.IProtocolStream
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

	public class ScenePet : Protocol.IProtocolStream
	{
		public UInt64 id;
		public UInt32 dataId;
		public UInt16 level;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_uint32(buffer, ref pos_, dataId);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dataId);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
			}
		#endregion

	}

	[Protocol]
	public class SceneSyncPetList : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502201;
		public UInt64 followPetId;
		public UInt64[] battlePets = new UInt64[0];
		public PetInfo[] petList = new PetInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, followPetId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)battlePets.Length);
				for(int i = 0; i < battlePets.Length; i++)
				{
					BaseDLL.encode_uint64(buffer, ref pos_, battlePets[i]);
				}
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)petList.Length);
				for(int i = 0; i < petList.Length; i++)
				{
					petList[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref followPetId);
				UInt16 battlePetsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref battlePetsCnt);
				battlePets = new UInt64[battlePetsCnt];
				for(int i = 0; i < battlePets.Length; i++)
				{
					BaseDLL.decode_uint64(buffer, ref pos_, ref battlePets[i]);
				}
				UInt16 petListCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref petListCnt);
				petList = new PetInfo[petListCnt];
				for(int i = 0; i < petList.Length; i++)
				{
					petList[i] = new PetInfo();
					petList[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneSyncPet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502202;

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
	public class SceneDeletePet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502203;
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
	public class SceneSetPetSoltReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502205;
		public byte petType;
		public UInt64 petId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, petType);
				BaseDLL.encode_uint64(buffer, ref pos_, petId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref petType);
				BaseDLL.decode_uint64(buffer, ref pos_, ref petId);
			}
		#endregion

	}

	[Protocol]
	public class SceneSetPetSoltRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502206;
		public UInt32 result;
		public UInt64[] battlePets = new UInt64[0];
		public UInt64 followPetId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)battlePets.Length);
				for(int i = 0; i < battlePets.Length; i++)
				{
					BaseDLL.encode_uint64(buffer, ref pos_, battlePets[i]);
				}
				BaseDLL.encode_uint64(buffer, ref pos_, followPetId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 battlePetsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref battlePetsCnt);
				battlePets = new UInt64[battlePetsCnt];
				for(int i = 0; i < battlePets.Length; i++)
				{
					BaseDLL.decode_uint64(buffer, ref pos_, ref battlePets[i]);
				}
				BaseDLL.decode_uint64(buffer, ref pos_, ref followPetId);
			}
		#endregion

	}

	[Protocol]
	public class SceneFeedPetReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502207;
		public UInt64 id;
		public byte feedType;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, feedType);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref feedType);
			}
		#endregion

	}

	[Protocol]
	public class SceneFeedPetRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502208;
		public UInt32 result;
		public byte feedType;
		public byte isCritical;
		public UInt32 value;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, feedType);
				BaseDLL.encode_int8(buffer, ref pos_, isCritical);
				BaseDLL.encode_uint32(buffer, ref pos_, value);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref feedType);
				BaseDLL.decode_int8(buffer, ref pos_, ref isCritical);
				BaseDLL.decode_uint32(buffer, ref pos_, ref value);
			}
		#endregion

	}

	[Protocol]
	public class SceneSellPetReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502209;
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
	public class SceneSellPetRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502210;
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
	public class SceneChangePetSkillReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502211;
		public UInt64 id;
		public byte skillIndex;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_int8(buffer, ref pos_, skillIndex);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				BaseDLL.decode_int8(buffer, ref pos_, ref skillIndex);
			}
		#endregion

	}

	[Protocol]
	public class SceneChangePetSkillRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502212;
		public UInt32 result;
		public UInt64 petId;
		public byte skillIndex;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint64(buffer, ref pos_, petId);
				BaseDLL.encode_int8(buffer, ref pos_, skillIndex);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint64(buffer, ref pos_, ref petId);
				BaseDLL.decode_int8(buffer, ref pos_, ref skillIndex);
			}
		#endregion

	}

	[Protocol]
	public class SceneSetPetFollowReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502213;
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
	public class SceneSetPetFollowRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502214;
		public UInt32 result;
		public UInt64 petId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint64(buffer, ref pos_, petId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint64(buffer, ref pos_, ref petId);
			}
		#endregion

	}

	[Protocol]
	public class SceneDevourPetReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502215;
		public UInt64 id;
		public UInt64[] petIds = new UInt64[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)petIds.Length);
				for(int i = 0; i < petIds.Length; i++)
				{
					BaseDLL.encode_uint64(buffer, ref pos_, petIds[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref id);
				UInt16 petIdsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref petIdsCnt);
				petIds = new UInt64[petIdsCnt];
				for(int i = 0; i < petIds.Length; i++)
				{
					BaseDLL.decode_uint64(buffer, ref pos_, ref petIds[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneDevourPetRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 502216;
		public UInt32 result;
		public UInt32 exp;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, exp);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref exp);
			}
		#endregion

	}

}
