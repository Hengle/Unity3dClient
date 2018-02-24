using System;
using System.Text;

namespace Protocol
{
	[Protocol]
	public class SceneNotifyNewBoot : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 505402;
		public UInt32 id;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyBootFlag : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 505403;
		public UInt32 id;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
			}
		#endregion

	}

}
