using System;
using System.Text;

namespace Protocol
{
	[Protocol]
	public class AdminLoginVerifyReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 200201;
		public string param;
		public byte[] hashValue = new byte[20];
		public string source1;
		public string source2;
		public UInt32 version;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] paramBytes = StringHelper.StringToUTF8Bytes(param);
				BaseDLL.encode_string(buffer, ref pos_, paramBytes, (UInt16)(buffer.Length - pos_));
				for(int i = 0; i < hashValue.Length; i++)
				{
					BaseDLL.encode_int8(buffer, ref pos_, hashValue[i]);
				}
				byte[] source1Bytes = StringHelper.StringToUTF8Bytes(source1);
				BaseDLL.encode_string(buffer, ref pos_, source1Bytes, (UInt16)(buffer.Length - pos_));
				byte[] source2Bytes = StringHelper.StringToUTF8Bytes(source2);
				BaseDLL.encode_string(buffer, ref pos_, source2Bytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, version);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 paramLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref paramLen);
				byte[] paramBytes = new byte[paramLen];
				for(int i = 0; i < paramLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref paramBytes[i]);
				}
				param = StringHelper.BytesToString(paramBytes);
				for(int i = 0; i < hashValue.Length; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref hashValue[i]);
				}
				UInt16 source1Len = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref source1Len);
				byte[] source1Bytes = new byte[source1Len];
				for(int i = 0; i < source1Len; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref source1Bytes[i]);
				}
				source1 = StringHelper.BytesToString(source1Bytes);
				UInt16 source2Len = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref source2Len);
				byte[] source2Bytes = new byte[source2Len];
				for(int i = 0; i < source2Len; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref source2Bytes[i]);
				}
				source2 = StringHelper.BytesToString(source2Bytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref version);
			}
		#endregion

	}

	[Protocol]
	public class AdminLoginVerifyRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 200202;
		public UInt32 result;
		public string errMsg;
		public UInt32 accid;
		public SockAddr addr = new SockAddr();
		/// <summary>
		///  目录服务器校验签名
		/// </summary>
		public string dirSig;
		/// <summary>
		///  录像服务器地址
		/// </summary>
		public string replayAgentAddr;
		/// <summary>
		///  手机绑定的角色ID
		/// </summary>
		public UInt64 phoneBindRoleId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				byte[] errMsgBytes = StringHelper.StringToUTF8Bytes(errMsg);
				BaseDLL.encode_string(buffer, ref pos_, errMsgBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, accid);
				addr.encode(buffer, ref pos_);
				byte[] dirSigBytes = StringHelper.StringToUTF8Bytes(dirSig);
				BaseDLL.encode_string(buffer, ref pos_, dirSigBytes, (UInt16)(buffer.Length - pos_));
				byte[] replayAgentAddrBytes = StringHelper.StringToUTF8Bytes(replayAgentAddr);
				BaseDLL.encode_string(buffer, ref pos_, replayAgentAddrBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint64(buffer, ref pos_, phoneBindRoleId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 errMsgLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref errMsgLen);
				byte[] errMsgBytes = new byte[errMsgLen];
				for(int i = 0; i < errMsgLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref errMsgBytes[i]);
				}
				errMsg = StringHelper.BytesToString(errMsgBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref accid);
				addr.decode(buffer, ref pos_);
				UInt16 dirSigLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dirSigLen);
				byte[] dirSigBytes = new byte[dirSigLen];
				for(int i = 0; i < dirSigLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref dirSigBytes[i]);
				}
				dirSig = StringHelper.BytesToString(dirSigBytes);
				UInt16 replayAgentAddrLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref replayAgentAddrLen);
				byte[] replayAgentAddrBytes = new byte[replayAgentAddrLen];
				for(int i = 0; i < replayAgentAddrLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref replayAgentAddrBytes[i]);
				}
				replayAgentAddr = StringHelper.BytesToString(replayAgentAddrBytes);
				BaseDLL.decode_uint64(buffer, ref pos_, ref phoneBindRoleId);
			}
		#endregion

	}

	[Protocol]
	public class GateClientLoginReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300203;
		public UInt32 accid;
		public byte[] hashValue = new byte[20];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, accid);
				for(int i = 0; i < hashValue.Length; i++)
				{
					BaseDLL.encode_int8(buffer, ref pos_, hashValue[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref accid);
				for(int i = 0; i < hashValue.Length; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref hashValue[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class GateClientLoginRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300204;
		public UInt32 result;
		public byte hasrole;
		/// <summary>
		///  需要等待的玩家数
		/// </summary>
		public UInt32 waitPlayerNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_int8(buffer, ref pos_, hasrole);
				BaseDLL.encode_uint32(buffer, ref pos_, waitPlayerNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_int8(buffer, ref pos_, ref hasrole);
				BaseDLL.decode_uint32(buffer, ref pos_, ref waitPlayerNum);
			}
		#endregion

	}

	[Protocol]
	public class GateSendRoleInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300301;
		public RoleInfo[] roles = new RoleInfo[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)roles.Length);
				for(int i = 0; i < roles.Length; i++)
				{
					roles[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 rolesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref rolesCnt);
				roles = new RoleInfo[rolesCnt];
				for(int i = 0; i < roles.Length; i++)
				{
					roles[i] = new RoleInfo();
					roles[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class GateCreateRoleReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300302;
		public string name;
		public byte sex;
		public byte occupation;
		public byte isnewer;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, sex);
				BaseDLL.encode_int8(buffer, ref pos_, occupation);
				BaseDLL.encode_int8(buffer, ref pos_, isnewer);
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
				BaseDLL.decode_int8(buffer, ref pos_, ref sex);
				BaseDLL.decode_int8(buffer, ref pos_, ref occupation);
				BaseDLL.decode_int8(buffer, ref pos_, ref isnewer);
			}
		#endregion

	}

	[Protocol]
	public class GateCreateRoleRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300303;
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
	public class GateDeleteRoleReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300304;
		public UInt64 roldId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roldId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roldId);
			}
		#endregion

	}

	[Protocol]
	public class GateEnterGameReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300306;
		public UInt64 roleId;
		public byte option;
		public string city;
		public UInt32 inviter;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_int8(buffer, ref pos_, option);
				byte[] cityBytes = StringHelper.StringToUTF8Bytes(city);
				BaseDLL.encode_string(buffer, ref pos_, cityBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, inviter);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_int8(buffer, ref pos_, ref option);
				UInt16 cityLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref cityLen);
				byte[] cityBytes = new byte[cityLen];
				for(int i = 0; i < cityLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref cityBytes[i]);
				}
				city = StringHelper.BytesToString(cityBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref inviter);
			}
		#endregion

	}

	[Protocol]
	public class GateEnterGameRet : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300307;
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
	///  离开游戏
	/// </summary>
	[Protocol]
	public class GateLeaveGameReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300401;

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
	public class GateReconnectGameReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300311;
		public UInt32 accid;
		public UInt64 roleId;
		public UInt32 sequence;
		public byte[] session = new byte[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, accid);
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_uint32(buffer, ref pos_, sequence);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)session.Length);
				for(int i = 0; i < session.Length; i++)
				{
					BaseDLL.encode_int8(buffer, ref pos_, session[i]);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref accid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref sequence);
				UInt16 sessionCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref sessionCnt);
				session = new byte[sessionCnt];
				for(int i = 0; i < session.Length; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref session[i]);
				}
			}
		#endregion

	}

	[Protocol]
	public class GateReconnectGameRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300312;
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
	public class GateRecoverRoleReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300305;
		public UInt64 roleId;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
			}
		#endregion

	}

	/// <summary>
	///  恢复角色返回
	/// </summary>
	[Protocol]
	public class GateRecoverRoleRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300314;
		public UInt64 roleId;
		public UInt32 result;
		public string roleUpdateLimit;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				byte[] roleUpdateLimitBytes = StringHelper.StringToUTF8Bytes(roleUpdateLimit);
				BaseDLL.encode_string(buffer, ref pos_, roleUpdateLimitBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 roleUpdateLimitLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref roleUpdateLimitLen);
				byte[] roleUpdateLimitBytes = new byte[roleUpdateLimitLen];
				for(int i = 0; i < roleUpdateLimitLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref roleUpdateLimitBytes[i]);
				}
				roleUpdateLimit = StringHelper.BytesToString(roleUpdateLimitBytes);
			}
		#endregion

	}

	/// <summary>
	///  删除角色返回
	/// </summary>
	[Protocol]
	public class GateDeleteRoleRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300315;
		public UInt64 roleId;
		public UInt32 result;
		public string roleUpdateLimit;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				byte[] roleUpdateLimitBytes = StringHelper.StringToUTF8Bytes(roleUpdateLimit);
				BaseDLL.encode_string(buffer, ref pos_, roleUpdateLimitBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				UInt16 roleUpdateLimitLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref roleUpdateLimitLen);
				byte[] roleUpdateLimitBytes = new byte[roleUpdateLimitLen];
				for(int i = 0; i < roleUpdateLimitLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref roleUpdateLimitBytes[i]);
				}
				roleUpdateLimit = StringHelper.BytesToString(roleUpdateLimitBytes);
			}
		#endregion

	}

	/// <summary>
	///  更新排队信息
	/// </summary>
	[Protocol]
	public class GateNotifyLoginWaitInfo : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300316;
		public UInt32 waitPlayerNum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, waitPlayerNum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref waitPlayerNum);
			}
		#endregion

	}

	/// <summary>
	///  通知玩家可以登录了
	/// </summary>
	[Protocol]
	public class GateNotifyAllowLogin : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300317;

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
	public class GateFinishNewbeeGuide : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300313;
		public UInt64 roleId;
		public UInt32 id;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_uint32(buffer, ref pos_, id);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref id);
			}
		#endregion

	}

	/// <summary>
	///  通知客户端被踢
	/// </summary>
	[Protocol]
	public class GateNotifyKickoff : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300404;
		public UInt32 errorCode;
		public string msg;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, errorCode);
				byte[] msgBytes = StringHelper.StringToUTF8Bytes(msg);
				BaseDLL.encode_string(buffer, ref pos_, msgBytes, (UInt16)(buffer.Length - pos_));
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref errorCode);
				UInt16 msgLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref msgLen);
				byte[] msgBytes = new byte[msgLen];
				for(int i = 0; i < msgLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref msgBytes[i]);
				}
				msg = StringHelper.BytesToString(msgBytes);
			}
		#endregion

	}

}
