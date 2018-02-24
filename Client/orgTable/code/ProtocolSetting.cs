using System;
using System.Text;

namespace Protocol
{
	public class SkillBarGrid : Protocol.IProtocolStream
	{
		public byte slot;
		public UInt16 id;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, slot);
				BaseDLL.encode_uint16(buffer, ref pos_, id);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref slot);
				BaseDLL.decode_uint16(buffer, ref pos_, ref id);
			}
		#endregion

	}

	public class SkillBar : Protocol.IProtocolStream
	{
		public byte index;
		public SkillBarGrid[] grids = new SkillBarGrid[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, index);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)grids.Length);
				for(int i = 0; i < grids.Length; i++)
				{
					grids[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref index);
				UInt16 gridsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref gridsCnt);
				grids = new SkillBarGrid[gridsCnt];
				for(int i = 0; i < grids.Length; i++)
				{
					grids[i] = new SkillBarGrid();
					grids[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	public class SkillBars : Protocol.IProtocolStream
	{
		public byte index;
		public SkillBar[] bar = new SkillBar[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, index);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)bar.Length);
				for(int i = 0; i < bar.Length; i++)
				{
					bar[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref index);
				UInt16 barCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref barCnt);
				bar = new SkillBar[barCnt];
				for(int i = 0; i < bar.Length; i++)
				{
					bar[i] = new SkillBar();
					bar[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class SceneExchangeSkillBarReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501201;
		public SkillBars skillBars = new SkillBars();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				skillBars.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				skillBars.decode(buffer, ref pos_);
			}
		#endregion

	}

	[Protocol]
	public class SceneExchangeSkillBarRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501202;
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
	public class SceneChangeOccu : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501212;
		public byte occu;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, occu);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
			}
		#endregion

	}

	[Protocol]
	public class SceneSyncFuncUnlock : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 501213;
		public byte funcId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, funcId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref funcId);
			}
		#endregion

	}

}
