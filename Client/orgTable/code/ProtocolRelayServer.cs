using System;
using System.Text;

namespace Protocol
{
	/// <summary>
	///  ��������֡����
	/// </summary>
	public enum FrameCommandID
	{
		/// <summary>
		///  ս����ʼ
		/// </summary>
		GameStart = 0,
		/// <summary>
		///  �ƶ�
		/// </summary>
		Move = 1,
		/// <summary>
		///  ֹͣ
		/// </summary>
		Stop = 2,
		/// <summary>
		///  �ż���
		/// </summary>
		Skill = 3,
		/// <summary>
		///  ����뿪ս��
		/// </summary>
		Leave = 4,
		/// <summary>
		///  ��Ҹ���
		/// </summary>
		Reborn = 5,
		/// <summary>
		///  ��ʼ����
		/// </summary>
		ReconnectBegin = 6,
		/// <summary>
		///  ��������
		/// </summary>
		ReconnectEnd = 7,
		/// <summary>
		///  ʹ����Ʒ
		/// </summary>
		UseItem = 8,
		/// <summary>
		/// ����
		/// </summary>
		LevelChange = 9,
		/// <summary>
		/// �Զ�ս��
		/// </summary>
		AutoFight = 10,
		/// <summary>
		/// ˫������
		/// </summary>
		DoublePressConfig = 11,
		/// <summary>
		///  ����˳�ս��(�������˳�)
		/// </summary>
		PlayerQuit = 12,
		/// <summary>
		///  ս������
		/// </summary>
		RaceEnd = 13,
		/// <summary>
		///  ��������
		/// </summary>
		NetQuality = 14,
	}

	/// <summary>
	///  ��������ԭ��
	/// </summary>
	public enum RaceEndReason
	{
		/// <summary>
		///  �����˳�
		/// </summary>
		Normal = 0,
		/// <summary>
		///  ��ս����ʱ�䳬ʱ
		/// </summary>
		Timeout = 1,
		/// <summary>
		///  �ȴ���ʼ��ʱ
		/// </summary>
		LoginTimeout = 2,
		/// <summary>
		///  �쳣����
		/// </summary>
		Errro = 3,
		/// <summary>
		///  ϵͳ��ɢ
		/// </summary>
		System = 4,
		/// <summary>
		///  �ȴ�������ʱ
		/// </summary>
		WaitRaceEndTimeout = 5,
		/// <summary>
		///  ���ڲ�ս������
		/// </summary>
		GamerOffline = 6,
		/// <summary>
		///  ֡У�鳬ʱ
		/// </summary>
		FrameChecksumTimeout = 7,
		/// <summary>
		///  ֡У�鲻һ��
		/// </summary>
		FrameChecksumDifferent = 8,
	}

	[Protocol]
	public class RelaySvrLoginReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300001;
		public byte seat;
		public UInt32 accid;
		public UInt64 roleid;
		public UInt64 session;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				BaseDLL.encode_uint32(buffer, ref pos_, accid);
				BaseDLL.encode_uint64(buffer, ref pos_, roleid);
				BaseDLL.encode_uint64(buffer, ref pos_, session);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				BaseDLL.decode_uint32(buffer, ref pos_, ref accid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref session);
			}
		#endregion

	}

	[Protocol]
	public class RelaySvrLoginRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300002;
		public UInt32 result;
		public UInt64 currentTime;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, result);
				BaseDLL.encode_uint64(buffer, ref pos_, currentTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref result);
				BaseDLL.decode_uint64(buffer, ref pos_, ref currentTime);
			}
		#endregion

	}

	[Protocol]
	public class RelaySvrNotifyGameStart : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300003;
		public UInt64 session;
		public UInt64 startTime;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, session);
				BaseDLL.encode_uint64(buffer, ref pos_, startTime);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref session);
				BaseDLL.decode_uint64(buffer, ref pos_, ref startTime);
			}
		#endregion

	}

	public class _inputData : Protocol.IProtocolStream
	{
		public UInt32 sendTime;
		public UInt32 data1;
		public UInt32 data2;
		public UInt32 data3;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, sendTime);
				BaseDLL.encode_uint32(buffer, ref pos_, data1);
				BaseDLL.encode_uint32(buffer, ref pos_, data2);
				BaseDLL.encode_uint32(buffer, ref pos_, data3);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref sendTime);
				BaseDLL.decode_uint32(buffer, ref pos_, ref data1);
				BaseDLL.decode_uint32(buffer, ref pos_, ref data2);
				BaseDLL.decode_uint32(buffer, ref pos_, ref data3);
			}
		#endregion

	}

	public class _fighterInput : Protocol.IProtocolStream
	{
		public byte seat;
		public _inputData input = new _inputData();

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				input.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				input.decode(buffer, ref pos_);
			}
		#endregion

	}

	public class Frame : Protocol.IProtocolStream
	{
		public UInt32 sequence;
		public _fighterInput[] data = new _fighterInput[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, sequence);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)data.Length);
				for(int i = 0; i < data.Length; i++)
				{
					data[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref sequence);
				UInt16 dataCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref dataCnt);
				data = new _fighterInput[dataCnt];
				for(int i = 0; i < data.Length; i++)
				{
					data[i] = new _fighterInput();
					data[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class RelaySvrFrameDataNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300004;
		public Frame[] frames = new Frame[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)frames.Length);
				for(int i = 0; i < frames.Length; i++)
				{
					frames[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				UInt16 framesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref framesCnt);
				frames = new Frame[framesCnt];
				for(int i = 0; i < frames.Length; i++)
				{
					frames[i] = new Frame();
					frames[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	[Protocol]
	public class RelaySvrPlayerInputReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300005;
		public UInt64 session;
		public byte seat;
		public UInt64 roleid;
		public _inputData input = new _inputData();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, session);
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				BaseDLL.encode_uint64(buffer, ref pos_, roleid);
				input.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref session);
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleid);
				input.decode(buffer, ref pos_);
			}
		#endregion

	}

	public class FightergResult : Protocol.IProtocolStream
	{
		public byte flag;
		public byte seat;
		public UInt32 accid;
		public UInt64 roldid;
		/// <summary>
		/// ʣ��Ѫ��(�ٷֱ�)
		/// </summary>
		public UInt32 remainHp;
		/// <summary>
		/// ʣ��ħ��(�ٷֱ�)
		/// </summary>
		public UInt32 remainMp;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, flag);
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				BaseDLL.encode_uint32(buffer, ref pos_, accid);
				BaseDLL.encode_uint64(buffer, ref pos_, roldid);
				BaseDLL.encode_uint32(buffer, ref pos_, remainHp);
				BaseDLL.encode_uint32(buffer, ref pos_, remainMp);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref flag);
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				BaseDLL.decode_uint32(buffer, ref pos_, ref accid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref roldid);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainHp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainMp);
			}
		#endregion

	}

	[Protocol]
	public class RelaySvrGameResultNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300006;
		public byte reason;
		public UInt64 session;
		public FightergResult[] results = new FightergResult[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, reason);
				BaseDLL.encode_uint64(buffer, ref pos_, session);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)results.Length);
				for(int i = 0; i < results.Length; i++)
				{
					results[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref reason);
				BaseDLL.decode_uint64(buffer, ref pos_, ref session);
				UInt16 resultsCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref resultsCnt);
				results = new FightergResult[resultsCnt];
				for(int i = 0; i < results.Length; i++)
				{
					results[i] = new FightergResult();
					results[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���PK����
	/// </summary>
	public class PkPlayerRaceEndInfo : Protocol.IProtocolStream
	{
		public UInt64 roleId;
		public byte pos;
		public byte result;
		public UInt32 remainHp;
		public UInt32 remainMp;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				BaseDLL.encode_int8(buffer, ref pos_, result);
				BaseDLL.encode_uint32(buffer, ref pos_, remainHp);
				BaseDLL.encode_uint32(buffer, ref pos_, remainMp);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				BaseDLL.decode_int8(buffer, ref pos_, ref result);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainHp);
				BaseDLL.decode_uint32(buffer, ref pos_, ref remainMp);
			}
		#endregion

	}

	/// <summary>
	///  pk����
	/// </summary>
	public class PkRaceEndInfo : Protocol.IProtocolStream
	{
		public UInt64 gamesessionId;
		/// <summary>
		/// ������ҵĽ�����Ϣ
		/// </summary>
		public PkPlayerRaceEndInfo[] infoes = new PkPlayerRaceEndInfo[0];
		/// <summary>
		/// ¼������
		/// </summary>
		public UInt32 replayScore;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, gamesessionId);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)infoes.Length);
				for(int i = 0; i < infoes.Length; i++)
				{
					infoes[i].encode(buffer, ref pos_);
				}
				BaseDLL.encode_uint32(buffer, ref pos_, replayScore);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref gamesessionId);
				UInt16 infoesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref infoesCnt);
				infoes = new PkPlayerRaceEndInfo[infoesCnt];
				for(int i = 0; i < infoes.Length; i++)
				{
					infoes[i] = new PkPlayerRaceEndInfo();
					infoes[i].decode(buffer, ref pos_);
				}
				BaseDLL.decode_uint32(buffer, ref pos_, ref replayScore);
			}
		#endregion

	}

	[Protocol]
	public class RelaySvrEndGameReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300007;
		public PkRaceEndInfo end = new PkRaceEndInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				end.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				end.decode(buffer, ref pos_);
			}
		#endregion

	}

	public class DungeonPlayerRaceEndInfo : Protocol.IProtocolStream
	{
		public UInt64 roleId;
		public byte pos;
		public byte score;
		public UInt16 beHitCount;

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				BaseDLL.encode_int8(buffer, ref pos_, score);
				BaseDLL.encode_uint16(buffer, ref pos_, beHitCount);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				BaseDLL.decode_int8(buffer, ref pos_, ref score);
				BaseDLL.decode_uint16(buffer, ref pos_, ref beHitCount);
			}
		#endregion

	}

	public class DungeonRaceEndInfo : Protocol.IProtocolStream
	{
		public UInt64 sessionId;
		public UInt32 dungeonId;
		public UInt32 usedTime;
		/// <summary>
		///  ����ҵĽ�����Ϣ
		/// </summary>
		public DungeonPlayerRaceEndInfo[] infoes = new DungeonPlayerRaceEndInfo[0];

		#region METHOD

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, sessionId);
				BaseDLL.encode_uint32(buffer, ref pos_, dungeonId);
				BaseDLL.encode_uint32(buffer, ref pos_, usedTime);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)infoes.Length);
				for(int i = 0; i < infoes.Length; i++)
				{
					infoes[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref sessionId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref dungeonId);
				BaseDLL.decode_uint32(buffer, ref pos_, ref usedTime);
				UInt16 infoesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref infoesCnt);
				infoes = new DungeonPlayerRaceEndInfo[infoesCnt];
				for(int i = 0; i < infoes.Length; i++)
				{
					infoes[i] = new DungeonPlayerRaceEndInfo();
					infoes[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  ���³ǽ���
	/// </summary>
	[Protocol]
	public class RelaySvrDungeonRaceEndReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300008;
		public UInt64 roleId;
		public DungeonRaceEndInfo raceEndInfo = new DungeonRaceEndInfo();

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, roleId);
				raceEndInfo.encode(buffer, ref pos_);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleId);
				raceEndInfo.decode(buffer, ref pos_);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ��������
	/// </summary>
	[Protocol]
	public class RelaySvrRaceEndNotify : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300009;
		/// <summary>
		///  ����ԭ�򣨶�Ӧö��RaceEndReason��
		/// </summary>
		public byte reason;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, reason);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref reason);
			}
		#endregion

	}

	/// <summary>
	///  �ϱ�����У������
	/// </summary>
	[Protocol]
	public class RelaySvrFrameChecksumRequest : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300011;
		/// <summary>
		///  ֡���
		/// </summary>
		public UInt32 frame;
		/// <summary>
		///  ֡У��ֵ
		/// </summary>
		public UInt32 checksum;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, frame);
				BaseDLL.encode_uint32(buffer, ref pos_, checksum);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref frame);
				BaseDLL.decode_uint32(buffer, ref pos_, ref checksum);
			}
		#endregion

	}

	/// <summary>
	///  ��������
	/// </summary>
	[Protocol]
	public class RelaySvrReconnectReq : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300012;
		public byte seat;
		public UInt32 accid;
		public UInt64 roleid;
		public UInt64 session;
		public UInt64 lastFrame;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, seat);
				BaseDLL.encode_uint32(buffer, ref pos_, accid);
				BaseDLL.encode_uint64(buffer, ref pos_, roleid);
				BaseDLL.encode_uint64(buffer, ref pos_, session);
				BaseDLL.encode_uint64(buffer, ref pos_, lastFrame);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref seat);
				BaseDLL.decode_uint32(buffer, ref pos_, ref accid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref roleid);
				BaseDLL.decode_uint64(buffer, ref pos_, ref session);
				BaseDLL.decode_uint64(buffer, ref pos_, ref lastFrame);
			}
		#endregion

	}

	/// <summary>
	///  ��������
	/// </summary>
	[Protocol]
	public class RelaySvrReconnectRes : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300013;
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
	///  ����֡����
	/// </summary>
	[Protocol]
	public class RelaySvrReconnectFrameData : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300014;
		public byte finish;
		public Frame[] frames = new Frame[0];

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, finish);
				BaseDLL.encode_uint16(buffer, ref pos_, (UInt16)frames.Length);
				for(int i = 0; i < frames.Length; i++)
				{
					frames[i].encode(buffer, ref pos_);
				}
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref finish);
				UInt16 framesCnt = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref framesCnt);
				frames = new Frame[framesCnt];
				for(int i = 0; i < frames.Length; i++)
				{
					frames[i] = new Frame();
					frames[i].decode(buffer, ref pos_);
				}
			}
		#endregion

	}

	/// <summary>
	///  �ϱ����ؽ���
	/// </summary>
	[Protocol]
	public class RelaySvrReportLoadProgress : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300015;
		/// <summary>
		///  ���ؽ���
		/// </summary>
		public byte progress;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, progress);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref progress);
			}
		#endregion

	}

	/// <summary>
	///  ֪ͨ���ؽ���
	/// </summary>
	[Protocol]
	public class RelaySvrNotifyLoadProgress : Protocol.IProtocolStream, Protocol.IGetMsgID
	{
		public const UInt32 MsgID = 1300016;
		/// <summary>
		///  ��λ��
		/// </summary>
		public byte pos;
		/// <summary>
		///  ���ؽ���
		/// </summary>
		public byte progress;

		#region METHOD
			public UInt32 GetMsgID()
			{
				return MsgID;
			}

			public void encode(byte[] buffer, ref int pos_)
			{
				BaseDLL.encode_int8(buffer, ref pos_, pos);
				BaseDLL.encode_int8(buffer, ref pos_, progress);
			}

			public void decode(byte[] buffer, ref int pos_)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref pos);
				BaseDLL.decode_int8(buffer, ref pos_, ref progress);
			}
		#endregion

	}

}
