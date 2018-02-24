using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	///  请求类型
	/// </summary>
	public enum RequestType
	{
		/// <summary>
		///  邀请组队
		/// </summary>
		InviteTeam = 1,
		/// <summary>
		///  根据玩家ID请求入队
		/// </summary>
		JoinTeam = 2,
		RequestFriend = 3,
		/// <summary>
		///  根据队伍ID加入队伍
		/// </summary>
		JoinTeamByTeamID = 21,
		RequestFriendByName = 29,
		/// <summary>
		///  挑战
		/// </summary>
		Request_Challenge_PK = 30,
		/// <summary>
		///  邀请公会
		/// </summary>
		InviteJoinGuild = 31,
	}

	[Protocol]
	public class HeartBeatMsg : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 0;

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
	public class GateSyncServerTime : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 300309;
		public UInt32 time;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, time);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref time);
			}
		#endregion

	}

	public class SockAddr : Protocol.IProtocolStream
	{
		public string ip;
		public UInt16 port;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				byte[] ipBytes = StringHelper.StringToUTF8Bytes(ip);
				BaseDLL.encode_string(buffer, ref pos_, ipBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint16(buffer, ref pos_, port);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 ipLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref ipLen);
				byte[] ipBytes = new byte[ipLen];
				for(int i = 0; i < ipLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref ipBytes[i]);
				}
				ip = StringHelper.BytesToString(ipBytes);
				BaseDLL.decode_uint16(buffer, ref pos_, ref port);
			}
		#endregion

	}

	public class PlayerAvatar : Protocol.IProtocolStream
	{
		public UInt32[] equipItemIds = new UInt32[0];
		/// <summary>
		///  武器强化等级
		/// </summary>
		public byte weaponStrengthen;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)equipItemIds.Length);
				for(int i = 0; i < equipItemIds.Length; i++)
				{
					BaseDLL.encode_uint32(buffer, ref pos_, equipItemIds[i]);
				}
				BaseDLL.encode_int8(buffer, ref pos_, weaponStrengthen);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 equipItemIdsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref equipItemIdsCnt);
				equipItemIds = new UInt32[equipItemIdsCnt];
				for(int i = 0; i < equipItemIds.Length; i++)
				{
					BaseDLL.decode_uint32(buffer, ref pos_, ref equipItemIds[i]);
				}
				BaseDLL.decode_int8(buffer, ref pos_, ref weaponStrengthen);
			}
		#endregion

	}

	public class RoleInfo : Protocol.IProtocolStream
	{
		public UInt64 roleId;
		public string strRoleId;
		public string name;
		public byte sex;
		public byte occupation;
		public UInt16 level;
		public UInt32 offlineTime;
		public UInt32 deleteTime;
		public PlayerAvatar avatar = new PlayerAvatar();
		public UInt32 newboot;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				byte[] strRoleIdBytes = StringHelper.StringToUTF8Bytes(strRoleId);
				BaseDLL.encode_string(buffer, ref pos_, strRoleIdBytes, (UInt16)(buffer.Length - pos_));
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, sex);
				BaseDLL.encode_int8(buffer, ref pos_, occupation);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
				BaseDLL.encode_uint32(buffer, ref pos_, offlineTime);
				BaseDLL.encode_uint32(buffer, ref pos_, deleteTime);
				avatar.encode(buffer, ref pos_);
				BaseDLL.encode_uint32(buffer, ref pos_, newboot);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				UInt16 strRoleIdLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref strRoleIdLen);
				byte[] strRoleIdBytes = new byte[strRoleIdLen];
				for(int i = 0; i < strRoleIdLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref strRoleIdBytes[i]);
				}
				strRoleId = StringHelper.BytesToString(strRoleIdBytes);
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
				BaseDLL.decode_uint16(buffer, ref pos_, ref level);
				BaseDLL.decode_uint32(buffer, ref pos_, ref offlineTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref deleteTime);
				avatar.decode(buffer, ref pos_);
				BaseDLL.decode_uint32(buffer, ref pos_, ref newboot);
			}
		#endregion

	}

	/// <summary>
	///  发出请求
	/// </summary>
	[Protocol]
	public class SceneRequest : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500804;
		/// <summary>
		///  类型(对应枚举RequestType)
		/// </summary>
		public byte type;
		/// <summary>
		///  目标ID
		/// </summary>
		public UInt64 target;
		/// <summary>
		///  目标名字
		/// </summary>
		public string targetName;
		/// <summary>
		///  附加参数
		/// </summary>
		public UInt32 param;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, target);
				byte[] targetNameBytes = StringHelper.StringToUTF8Bytes(targetName);
				BaseDLL.encode_string(buffer, ref pos_, targetNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_uint32(buffer, ref pos_, param);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref target);
				UInt16 targetNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref targetNameLen);
				byte[] targetNameBytes = new byte[targetNameLen];
				for(int i = 0; i < targetNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref targetNameBytes[i]);
				}
				targetName = StringHelper.BytesToString(targetNameBytes);
				BaseDLL.decode_uint32(buffer, ref pos_, ref param);
			}
		#endregion

	}

	/// <summary>
	///  同步请求
	/// </summary>
	[Protocol]
	public class SceneSyncRequest : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500805;
		/// <summary>
		///  类型(对应枚举RequestType)
		/// </summary>
		public byte type;
		/// <summary>
		///  请求者
		/// </summary>
		public UInt64 requester;
		/// <summary>
		///  请求者名字
		/// </summary>
		public string requesterName;
		/// <summary>
		///  请求者性别
		/// </summary>
		public byte requesterOccu;
		/// <summary>
		///  请求者等级
		/// </summary>
		public UInt16 requesterLevel;
		/// <summary>
		///  附带参数1
		/// </summary>
		public string param1;
		/// <summary>
		/// vip等级
		/// </summary>
		public byte requesterVipLv;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, requester);
				byte[] requesterNameBytes = StringHelper.StringToUTF8Bytes(requesterName);
				BaseDLL.encode_string(buffer, ref pos_, requesterNameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, requesterOccu);
				BaseDLL.encode_uint16(buffer, ref pos_, requesterLevel);
				byte[] param1Bytes = StringHelper.StringToUTF8Bytes(param1);
				BaseDLL.encode_string(buffer, ref pos_, param1Bytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, requesterVipLv);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref requester);
				UInt16 requesterNameLen = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref requesterNameLen);
				byte[] requesterNameBytes = new byte[requesterNameLen];
				for(int i = 0; i < requesterNameLen; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref requesterNameBytes[i]);
				}
				requesterName = StringHelper.BytesToString(requesterNameBytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref requesterOccu);
				BaseDLL.decode_uint16(buffer, ref pos_, ref requesterLevel);
				UInt16 param1Len = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref param1Len);
				byte[] param1Bytes = new byte[param1Len];
				for(int i = 0; i < param1Len; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref param1Bytes[i]);
				}
				param1 = StringHelper.BytesToString(param1Bytes);
				BaseDLL.decode_int8(buffer, ref pos_, ref requesterVipLv);
			}
		#endregion

	}

	/// <summary>
	///  答复
	/// </summary>
	[Protocol]
	public class SceneReply : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 500806;
		/// <summary>
		/// 类型(对应枚举RequestType)
		/// </summary>
		public byte type;
		/// <summary>
		/// 请求者
		/// </summary>
		public UInt64 requester;
		/// <summary>
		/// 结果	1为接收 0为拒接
		/// </summary>
		public byte result;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, type);
				BaseDLL.encode_uint64(buffer, ref pos_, requester);
				BaseDLL.encode_int8(buffer, ref pos_, result);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref type);
				BaseDLL.decode_uint64(buffer, ref pos_, ref requester);
				BaseDLL.decode_int8(buffer, ref pos_, ref result);
			}
		#endregion

	}

	/// <summary>
	///  头像
	/// </summary>
	public class PlayerIcon : Protocol.IProtocolStream
	{
		/// <summary>
		///  ID
		/// </summary>
		public UInt64 id;
		/// <summary>
		///  名字
		/// </summary>
		public string name;
		/// <summary>
		///  职业
		/// </summary>
		public byte occu;
		/// <summary>
		///  等级
		/// </summary>
		public UInt16 level;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, id);
				byte[] nameBytes = StringHelper.StringToUTF8Bytes(name);
				BaseDLL.encode_string(buffer, ref pos_, nameBytes, (UInt16)(buffer.Length - pos_));
				BaseDLL.encode_int8(buffer, ref pos_, occu);
				BaseDLL.encode_uint16(buffer, ref pos_, level);
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
			}
		#endregion

	}

}
