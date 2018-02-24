using System;
using System.Text;

namespace Protocol
{
	[Protocol]
	public class SceneChat : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500801;
		public byte channel;
		public UInt64 targetId;
		public string word;
		public byte bLink;
		public string voiceKey;
		public byte voiceDuration;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, channel);
				BaseDLL.encode_uint64(buffer, ref pos_, targetId);
				byte[] wordBytes = StringHelper.StringToUTF8Bytes(word);
				BaseDLL.encode_string(buffer, ref pos_, wordBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, bLink);
				byte[] voiceKeyBytes = StringHelper.StringToUTF8Bytes(voiceKey);
				BaseDLL.encode_string(buffer, ref pos_, voiceKeyBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, voiceDuration);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref channel);
				BaseDLL.decode_uint64(buffer, ref pos_, ref targetId);
				UInt16 wordLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref wordLen);
				byte[] wordBytes = new byte[wordLen];
				for(int i = 0; i < wordLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref wordBytes[i]);
				}
				word = StringHelper.BytesToString(wordBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref bLink);
				UInt16 voiceKeyLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref voiceKeyLen);
				byte[] voiceKeyBytes = new byte[voiceKeyLen];
				for(int i = 0; i < voiceKeyLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref voiceKeyBytes[i]);
				}
				voiceKey = StringHelper.BytesToString(voiceKeyBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref voiceDuration);
			}
		#endregion

	}

	[Protocol]
	public class SceneNotifyExecGmcmd : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500802;
		public byte suc;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, suc);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref suc);
			}
		#endregion

	}

	/// <summary>
	///  系统提示, 服务器主动发出
	/// </summary>
	[Protocol]
	public class SysNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 11;
		public UInt16 type;
		public string word;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, type);
				byte[] wordBytes = StringHelper.StringToUTF8Bytes(word);
				BaseDLL.encode_string(buffer, ref pos_, wordBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref type);
				UInt16 wordLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref wordLen);
				byte[] wordBytes = new byte[wordLen];
				for(int i = 0; i < wordLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref wordBytes[i]);
				}
				word = StringHelper.BytesToString(wordBytes);
			}
		#endregion

	}

	/// <summary>
	///  系统公告, 服务器主动发出
	/// </summary>
	[Protocol]
	public class SysAnnouncement : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 25;
		public UInt32 id;
		public string word;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, id);
				byte[] wordBytes = StringHelper.StringToUTF8Bytes(word);
				BaseDLL.encode_string(buffer, ref pos_, wordBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
				UInt16 wordLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref wordLen);
				byte[] wordBytes = new byte[wordLen];
				for(int i = 0; i < wordLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref wordBytes[i]);
				}
				word = StringHelper.BytesToString(wordBytes);
			}
		#endregion

	}

	/// <summary>
	/// 同步聊天
	/// </summary>
	[Protocol]
	public class SceneSyncChat : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500803;
		public byte channel;
		public UInt64 objid;
		public byte sex;
		public byte occu;
		public UInt16 level;
		public byte viplvl;
		public string objname;
		public UInt64 receiverId;
		public string word;
		public byte bLink;
		public byte isGm;
		public string voiceKey;
		public byte voiceDuration;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, channel);
				BaseDLL.encode_uint64(buffer, ref pos_, objid);
				BaseDLL.encode_int8(buffer, ref pos_, sex);
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, viplvl);
				byte[] objnameBytes = StringHelper.StringToUTF8Bytes(objname);
				BaseDLL.encode_string(buffer, ref pos_, objnameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint64(buffer, ref pos_, receiverId);
				byte[] wordBytes = StringHelper.StringToUTF8Bytes(word);
				BaseDLL.encode_string(buffer, ref pos_, wordBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, bLink);
				BaseDLL.encode_int8(buffer, ref pos_, isGm);
				byte[] voiceKeyBytes = StringHelper.StringToUTF8Bytes(voiceKey);
				BaseDLL.encode_string(buffer, ref pos_, voiceKeyBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, voiceDuration);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref channel);
				BaseDLL.decode_uint64(buffer, ref pos_, ref objid);
				BaseDLL.decode_int8(buffer, ref pos_, ref sex);
				BaseDLL.decode_int8(buffer, ref pos_, ref occu);
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_int8(buffer, ref pos_, ref viplvl);
				UInt16 objnameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref objnameLen);
				byte[] objnameBytes = new byte[objnameLen];
				for(int i = 0; i < objnameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref objnameBytes[i]);
				}
				objname = StringHelper.BytesToString(objnameBytes);
				BaseDLL.decode_uint64(buffer, ref pos_, ref receiverId);
				UInt16 wordLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref wordLen);
				byte[] wordBytes = new byte[wordLen];
				for(int i = 0; i < wordLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref wordBytes[i]);
				}
				word = StringHelper.BytesToString(wordBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref bLink);
				BaseDLL.decode_int8(buffer, ref pos_, ref isGm);
				UInt16 voiceKeyLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref voiceKeyLen);
				byte[] voiceKeyBytes = new byte[voiceKeyLen];
				for(int i = 0; i < voiceKeyLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref voiceKeyBytes[i]);
				}
				voiceKey = StringHelper.BytesToString(voiceKeyBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref voiceDuration);
			}
		#endregion

	}

	/// <summary>
	/// 请求聊天链接信息
	/// </summary>
	[Protocol]
	public class WorldChatLinkDataReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 600802;
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
	/// 请求聊天链接信息返回
	/// </summary>
	[Protocol]
	public class WorldChatLinkDataRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 600803;

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
	///  请求发送喇叭
	/// </summary>
	[Protocol]
	public class SceneChatHornReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500808;
		/// <summary>
		///  喇叭内容
		/// </summary>
		public string content;
		/// <summary>
		///  一次性发送的喇叭数量
		/// </summary>
		public byte num;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] contentBytes = StringHelper.StringToUTF8Bytes(content);
				BaseDLL.encode_string(buffer, ref pos_, contentBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, num);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  返回发送喇叭结果
	/// </summary>
	[Protocol]
	public class SceneChatHornRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500809;
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
	/// 喇叭信息
	/// </summary>
	public class HornInfo : Protocol.IProtocolStream
	{
		/// <summary>
		/// 角色id
		/// </summary>
		public UInt64 roldId;
		/// <summary>
		/// 名字
		/// </summary>
		public string name;
		/// <summary>
		/// 职业
		/// </summary>
		public byte occu;
		/// <summary>
		/// 等级
		/// </summary>
		public UInt16 level;
		/// <summary>
		/// vip等级
		/// </summary>
		public byte viplvl;
		/// <summary>
		///  内容
		/// </summary>
		public string content;
		/// <summary>
		///  保护时间
		/// </summary>
		public byte minTime;
		/// <summary>
		///  持续时间
		/// </summary>
		public byte maxTime;
		/// <summary>
		///  combo数
		/// </summary>
		public UInt16 combo;
		/// <summary>
		///  连发数量
		/// </summary>
		public byte num;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roldId);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_int8(buffer, ref pos_, viplvl);
				byte[] contentBytes = StringHelper.StringToUTF8Bytes(content);
				BaseDLL.encode_string(buffer, ref pos_, contentBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, minTime);
				BaseDLL.encode_int8(buffer, ref pos_, maxTime);
				BaseDLL.encode_uint16(buffer, ref pos_, combo);
				BaseDLL.encode_int8(buffer, ref pos_, num);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roldId);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref viplvl);
				UInt16 contentLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref contentLen);
				byte[] contentBytes = new byte[contentLen];
				for(int i = 0; i < contentLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref contentBytes[i]);
				}
				content = StringHelper.BytesToString(contentBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref minTime);
				BaseDLL.decode_int8(buffer, ref pos_, ref maxTime);
				BaseDLL.decode_uint16(buffer, ref pos_, ref combo);
				BaseDLL.decode_int8(buffer, ref pos_, ref num);
			}
		#endregion

	}

	/// <summary>
	///  广播喇叭给客户端
	/// </summary>
	[Protocol]
	public class WorldChatHorn : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 600815;
		/// <summary>
		///  喇叭信息
		/// </summary>
		public HornInfo info = new HornInfo();

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

}
