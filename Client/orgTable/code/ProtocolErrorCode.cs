using System;
using System.Text;

namespace Protocol
{
	public enum ProtoErrorCode
	{
		/// <summary>
		///  �ɹ�
		/// </summary>
		SUCCESS = 0,
		/// <summary>
		///  ��¼��֤
		/// </summary>
		LOGIN = 100000,
		/// <summary>
		///  ������δ����
		/// </summary>
		LOGIN_SERVER_UNREADY = 100001,
		/// <summary>
		///  δ֪�˺ţ��˺�������
		/// </summary>
		LOGIN_UNKNOW_ACCOUNT = 100002,
		/// <summary>
		///  �ظ���¼
		/// </summary>
		LOGIN_REPEAT = 100003,
		/// <summary>
		///  �����
		/// </summary>
		LOGIN_WRONG_PASSWD = 100004,
		/// <summary>
		///  ��֤��ʱ
		/// </summary>
		LOGIN_VERIFY_TIMEOUT = 100005,
		/// <summary>
		///  ��������æ
		/// </summary>
		LOGIN_SERVER_BUSY = 100006,
		/// <summary>
		///  �汾�Ŵ���
		/// </summary>
		LOGIN_ERROR_VERSION = 100007,
		/// <summary>
		///  ���
		/// </summary>
		LOGIN_FORBID_LOGIN = 100008,
		/// <summary>
		///  ���ݿ����
		/// </summary>
		LOGIN_DB_ERROR = 100009,
		/// <summary>
		///  �Ŷ���
		/// </summary>
		LOGIN_WAIT = 100010,
		/// <summary>
		///  ��������ֹ��¼
		/// </summary>
		LOGIN_BUSY = 100011,
		/// <summary>
		///  ������Ϸ
		/// </summary>
		ENTERGAME = 200000,
		/// <summary>
		///  ��ɫ��Ϣ���Ϸ�
		/// </summary>
		ENTERGAME_UNVALID_ROLEINFO = 200001,
		/// <summary>
		///  ��������æ
		/// </summary>
		ENTERGAME_SERVER_BUSY = 200002,
		/// <summary>
		///  ̫���ɫ
		/// </summary>
		ENTERGAME_TOOMANY_ROLES = 200003,
		/// <summary>
		///  �ظ���
		/// </summary>
		ENTERGAME_DUPLICATE_NAME = 200004,
		/// <summary>
		///  ɾ����ɫ�������Ϸʱ��ʾ
		/// </summary>
		ENTERGAME_NOROLE = 200005,
		/// <summary>
		///  ����δ����
		/// </summary>
		ENTERGAME_SCENE_UNREADY = 200006,
		/// <summary>
		///  ��ɫ��ʼ��ʧ��
		/// </summary>
		ENTERGAME_INIT_FAILED = 200007,
		/// <summary>
		///  �ظ�
		/// </summary>
		ENTERGAME_REPEAT = 200008,
		/// <summary>
		///  ��ɫ�����Ϸ�
		/// </summary>
		ENTERGAME_UNVALID_NAME = 200009,
		/// <summary>
		///  ��������
		/// </summary>
		ENTERGAME_NO_CREATEROLE = 200010,
		/// <summary>
		///  ��Ҫ�н�ɫ�ﵽ20��
		/// </summary>
		ENTERGAME_NEED_LEVEL_20 = 200011,
		/// <summary>
		///  ��Ҫ�н�ɫ�ﵽ40��
		/// </summary>
		ENTERGAME_NEED_LEVEL_40 = 200012,
		/// <summary>
		///  �������մ�����ɫ�����
		/// </summary>
		ENTERGAME_TODAY_TOOMANY_ROLE = 200013,
		/// <summary>
		///  ����ָ��Ľ�ɫ������
		/// </summary>
		ENTERGAME_RECOVER_ROLE_UNEXIST = 200014,
		/// <summary>
		///  ����ָ��Ľ�ɫ�Ѿ�ɾ���ˣ���������ʱ�䣩
		/// </summary>
		ENTERGAME_RECOVER_ROLE_DELETED = 200015,
		/// <summary>
		///  ����ָ��Ľ�ɫ��û�б�ɾ��
		/// </summary>
		ENTERGAME_RECOVER_ROLE_NOT_DELETE = 200016,
		/// <summary>
		///  ����ɾ���Ľ�ɫ�Ѿ���ɾ����
		/// </summary>
		ENTERGAME_DELETE_ROLE_DELETED = 200017,
		/// <summary>
		///  ����ɾ���Ľ�ɫ������
		/// </summary>
		ENTERGAME_DELETE_ROLE_UNEXIST = 200018,
		/// <summary>
		///  ��ǰ����ɾ���Ľ�ɫ�ﵽ����
		/// </summary>
		ENTERGAME_DELETE_ROLE_MAX_NUM = 200019,
		/// <summary>
		/// ����ɾ���Ľ�ɫ���ޣ�ʱ�����ƣ�
		/// </summary>
		ENTERGAME_DELETE_ROLE_LIMIT = 200020,
		/// <summary>
		/// ����ָ��Ľ�ɫ���ޣ�ʱ�����ƣ�
		/// </summary>
		ENTERGAME_RECOVER_ROLE_LIMIT = 200021,
		/// <summary>
		///  �������
		/// </summary>
		SCENE = 300000,
		/// <summary>
		///  �ظ��ĳ���
		/// </summary>
		SCENE_DUPLICATE = 300001,
		/// <summary>
		///  ����̬����ʱ����
		/// </summary>
		SCENE_NOOWNER = 300002,
		/// <summary>
		///  ����������
		/// </summary>
		RECORD = 400000,
		/// <summary>
		///  ���ݿ����
		/// </summary>
		RECORD_ERROR = 400001,
		/// <summary>
		///  �ظ���
		/// </summary>
		RECORD_DUPLICATE_NAME = 400002,
		/// <summary>
		///  û��������
		/// </summary>
		RECORD_NO_NAMECOLUMN = 400003,
		RECORD_TIMEOUT = 400004,
		/// <summary>
		///  relayserver������
		/// </summary>
		RELAY = 500000,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		RELAY_LOGIN_SYSTEMERROR = 500001,
		/// <summary>
		///  ��Ч��gamesession
		/// </summary>
		RELAY_LOGIN_INVALIDSESSION = 500002,
		/// <summary>
		///  ��Ч�Ĳ�ս��
		/// </summary>
		RELAY_LOGIN_INVALIDFIGHTER = 500003,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		RELAY_RECONNECT_SYSTEMERROR = 500004,
		/// <summary>
		///  ��һ�������
		/// </summary>
		RELAY_RECONNECT_PLAYER_ONLINE = 500005,
		/// <summary>
		///  ��Ч��gamesession
		/// </summary>
		RELAY_RECONNECT_INVALIDSESSION = 500006,
		/// <summary>
		///  ��Ч�Ĳ�ս��
		/// </summary>
		RELAY_RECONNECT_INVALIDFIGHTER = 500007,
		/// <summary>
		///  ƥ�����
		/// </summary>
		MATCH = 600000,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		MATCH_START_SYSTEMERROR = 600001,
		/// <summary>
		///  �Ѿ���ƥ������
		/// </summary>
		MATCH_START_REPEAT = 600002,
		/// <summary>
		///  ƥ��ʧ�ܣ���ʱ
		/// </summary>
		MATCH_TIMEOUT = 600003,
		/// <summary>
		///  ����PK׼������
		/// </summary>
		MATCH_START_NOT_IN_PK_PARPARE = 600004,
		/// <summary>
		///  ���״̬����ƥ��
		/// </summary>
		MATCH_START_IN_TEAM = 600005,
		/// <summary>
		///  δ����������
		/// </summary>
		MATCH_START_WUDAO_NOT_JOIN = 600006,
		/// <summary>
		///  �������Ѿ����
		/// </summary>
		MATCH_START_WUDAO_COMPLETE = 600007,
		/// <summary>
		///  ����ƥ���б���
		/// </summary>
		MATCH_CANCLE_NOT_MATCHING = 600008,
		/// <summary>
		///  ����Ѿ�����Ϸ����
		/// </summary>
		MATCH_CANCLE_RACING = 600009,
		/// <summary>
		///  �������
		/// </summary>
		SKILL = 700000,
		/// <summary>
		///  ERROR
		/// </summary>
		SKILL_ERROR = 700001,
		/// <summary>
		///  ���浽���ݿ�ʧ��
		/// </summary>
		SKILL_SAVE_DB_ERROR = 700002,
		/// <summary>
		///  û���������
		/// </summary>
		SKILL_NOT_FOUNT = 700003,
		/// <summary>
		///  ����ļ�������
		/// </summary>
		SKILL_TYPE_ERROR = 700004,
		/// <summary>
		///  SP����
		/// </summary>
		SKILL_SP_NOT_ENOUGH = 700005,
		/// <summary>
		///  �Ƴ�SPʧ��
		/// </summary>
		SKILL_SP_REMOVE_ERROR = 700006,
		/// <summary>
		///  �������ȼ�
		/// </summary>
		SKILL_MAX_SKILL_LEVEL = 700007,
		/// <summary>
		///  ְҵ���Ϸ�
		/// </summary>
		SKILL_OCCU_ERROR = 700008,
		/// <summary>
		///  �����ҵȼ�
		/// </summary>
		SKILL_PLAYER_LEVEL = 700009,
		/// <summary>
		///  ǰ�ü��ܴ���
		/// </summary>
		SKILL_NEED_SKILL_ERROR = 700010,
		/// <summary>
		///  û����Ҫ����Ʒ��BUFF
		/// </summary>
		SKILL_NEED_ITEM_ERROR = 700011,
		/// <summary>
		///  ���ü��ܴ���
		/// </summary>
		SKILL_NEXT_SKILL_ERROR = 700012,
		/// <summary>
		///  ������С�ȼ�
		/// </summary>
		SKILL_MIN_SKILL_LEVEL = 700013,
		/// <summary>
		///  �������
		/// </summary>
		SETTING = 800000,
		/// <summary>
		///  ERROR
		/// </summary>
		SETTING_ERROR = 800001,
		/// <summary>
		///  ��������
		/// </summary>
		SETTING_INDEX_ERROR = 800002,
		/// <summary>
		///  ��λ��������
		/// </summary>
		SETTING_SLOT_ERROR = 800003,
		/// <summary>
		///  �����ظ�
		/// </summary>
		SETTING_SKILL_REPEAT = 800004,
		/// <summary>
		///  ���ܲ�����
		/// </summary>
		SETTING_SKILL_ERROR = 800005,
		/// <summary>
		///  ���³����
		/// </summary>
		DUNGEON = 900000,
		/// <summary>
		///  ��������ʧ��
		/// </summary>
		DUNGEON_START_CREATE_RACE_FAILED = 900001,
		/// <summary>
		///  ���³ǲ�����
		/// </summary>
		DUNGEON_START_DUNGEON_NOT_EXIST = 900002,
		/// <summary>
		///  δ�ﵽ�ȼ�Ҫ��
		/// </summary>
		DUNGEON_START_LEVEL_LIMIT = 900003,
		/// <summary>
		///  û��ƣ����
		/// </summary>
		DUNGEON_START_NO_FATIGUE = 900004,
		/// <summary>
		///  ���������������ǰ������ǰ�ùؿ��ȣ�
		/// </summary>
		DUNGEON_START_CONDITION = 900005,
		/// <summary>
		///  �Ѷ�δ����
		/// </summary>
		DUNGEON_START_HARD_NOT_OPEN = 900006,
		/// <summary>
		///  ����ѡ��ؿ��ĳ���
		/// </summary>
		DUNGEON_START_NOT_IN_ENTRY_SCENE = 900007,
		/// <summary>
		///  ��ʼ����ʧ��
		/// </summary>
		DUNGEON_START_RACE_FAILED = 900008,
		/// <summary>
		///  ��Ʊ����
		/// </summary>
		DUNGEON_START_NO_TICKET = 900009,
		/// <summary>
		///  û����Ԩģʽ
		/// </summary>
		DUNGEON_START_NO_HELL_MODE = 900010,
		/// <summary>
		///  û���㹻����ԨƱ
		/// </summary>
		DUNGEON_START_NO_HELL_TICKET = 900011,
		/// <summary>
		///  �����Ա������
		/// </summary>
		DUNGEON_START_TEAM_MEMBER_OFFLINE = 900012,
		/// <summary>
		///  ��������λ�ò���
		/// </summary>
		DUNGEON_START_BAG_FULL = 900013,
		/// <summary>
		///  ���ڿ���ʱ��
		/// </summary>
		DUNGEON_START_NOT_OPEN_TIME = 900014,
		/// <summary>
		///  ��������
		/// </summary>
		DUNGEON_START_NO_TIMES = 900015,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		DUNGEON_ENTER_AREA_SYSTEM_ERROR = 900016,
		/// <summary>
		///  �Ѿ��뿪���³���
		/// </summary>
		DUNGEON_ENTER_AREA_NOT_IN_DUNGEON = 900017,
		/// <summary>
		///  �ظ�����
		/// </summary>
		DUNGEON_ENTER_AREA_REPEAT = 900018,
		/// <summary>
		///  ���벻���ڵ�����
		/// </summary>
		DUNGEON_ENTER_AREA_NOT_EXIST = 900019,
		/// <summary>
		///  �����Ŀ�겻����
		/// </summary>
		DUNGEON_REVIVE_PLAYER_NOT_EXIST = 900020,
		/// <summary>
		///  �ظ�����
		/// </summary>
		DUNGEON_REVIVE_REPEAT = 900021,
		/// <summary>
		///  û���㹻�ĸ����
		/// </summary>
		DUNGEON_REVIVE_NOT_ENOUGH_REVIVE_COIN = 900022,
		/// <summary>
		///  ��ʼ�ؿ�ƥ��ʧ��
		/// </summary>
		DUNGEON_MATCH_START_FAILED = 900023,
		/// <summary>
		///  �ظ���ʼ���³�
		/// </summary>
		DUNGEON_TEAM_START_VOTE_REPEAT = 900024,
		/// <summary>
		///  ���³ǲ�����ӿ�ʼ
		/// </summary>
		DUNGEON_TEAM_TARGET_MUST_SINGLE = 900025,
		/// <summary>
		///  �������³��������
		/// </summary>
		DUNGEON_TEAM_TOO_MANY_MEMBER = 900026,
		/// <summary>
		///  �������㣬�޷���ʼ���³�
		/// </summary>
		DUNGEON_TEAM_NOT_ENOUGH_MEMBER = 900027,
		/// <summary>
		///  �ȴ�������ͶƱ
		/// </summary>
		DUNGEON_TEAM_WAIT_OTHER_VOTE = 900028,
		/// <summary>
		///  �޷��������
		/// </summary>
		DUNGEON_TIMES_CANT_BUY = 900029,
		/// <summary>
		///  �޷����������ʣ���������
		/// </summary>
		DUNGEON_TIMES_NO_REMAIN_TIMES = 900030,
		/// <summary>
		///  �޷����������Ǯ����
		/// </summary>
		DUNGEON_TIMES_NO_ENOUGH_MONEY = 900031,
		/// <summary>
		///  ��ʼ����ʧ�ܣ���������²���Ҫ��ʾ
		/// </summary>
		DUNGEON_TEAM_START_RACE_FAILED = 901001,
		/// <summary>
		///  �������
		/// </summary>
		ITEM = 1000000,
		/// <summary>
		///  ���ݷǷ�,����������ؿ�ָ���ж�
		/// </summary>
		ITEM_DATA_INVALID = 1000001,
		/// <summary>
		///  û�в�������
		/// </summary>
		ITEM_NO_REASON = 1000002,
		/// <summary>
		///  item�����Ƿ�
		/// </summary>
		ITEM_NUM_INVALID = 1000003,
		/// <summary>
		///  ���item������
		/// </summary>
		ITEM_ADD_PACK_FULL = 1000004,
		/// <summary>
		///  ��Ǯ��Ӵﵽ����
		/// </summary>
		ITEM_MONEY_ADD_FULL = 1000005,
		/// <summary>
		///  ʹ�õ���ʧ��
		/// </summary>
		ITEM_USE_FAIL = 1000006,
		/// <summary>
		///  ����װ��
		/// </summary>
		ITEM_CAN_NOT_EQUIP = 1000007,
		/// <summary>
		///  װ������
		/// </summary>
		ITEM_LOCKED = 1000008,
		/// <summary>
		///  װ�������İ�������
		/// </summary>
		ITEM_PACK_INVALID = 1000009,
		/// <summary>
		///  �������Ӵﵽ����
		/// </summary>
		ITEM_PACKSIZE_MAX = 1000010,
		/// <summary>
		///  ����������
		/// </summary>
		ITEM_TYPE_INVALID = 1000011,
		/// <summary>
		///  ���߷ֽ�ʧ��
		/// </summary>
		ITEM_DECOMPOSE_FAIL = 1000012,
		/// <summary>
		///  װ��ǿ���ȼ�����
		/// </summary>
		ITEM_STRENTH_LV_INVALID = 1000013,
		/// <summary>
		///  ��Ҳ���
		/// </summary>
		ITEM_NOT_ENOUGH_GOLD = 1000014,
		/// <summary>
		///  ���ϲ���
		/// </summary>
		ITEM_NOT_ENOUGH_MAT = 1000015,
		/// <summary>
		///  װ��ǿ��ʧ���޳ͷ�
		/// </summary>
		ITEM_STRENTH_FAIL = 1000016,
		/// <summary>
		///  װ��ǿ��ʧ�ܿ۵ȼ�
		/// </summary>
		ITEM_STRENTH_FAIL_MINUS = 1000017,
		/// <summary>
		///  װ��ǿ��ʧ�ܵȼ�����
		/// </summary>
		ITEM_STRENTH_FAIL_ZERO = 1000018,
		/// <summary>
		///  װ��ǿ��ʧ������
		/// </summary>
		ITEM_STRENTH_FAIL_BROKE = 1000019,
		/// <summary>
		///  ��ֿ�ռ�����
		/// </summary>
		ITEM_PUSH_STORAGE_FULL = 1000020,
		/// <summary>
		///  ��ȡ�ֿ���������
		/// </summary>
		ITEM_STORAGE_NUM_ERR = 1000021,
		/// <summary>
		///  װ��ְҵ����
		/// </summary>
		ITEM_EQUIP_OCCU = 1000022,
		/// <summary>
		///  װ���ȼ�����
		/// </summary>
		ITEM_EQUIP_LV = 1000023,
		/// <summary>
		///  װ��ǿ��ʧ�ܿ�2��
		/// </summary>
		ITEM_STRENTH_FAIL_TWO = 1000024,
		/// <summary>
		///  װ��ǿ��ʧ�ܿ�2��
		/// </summary>
		ITEM_STRENTH_FAIL_THREE = 1000025,
		/// <summary>
		///  װ��ǿ��ʧ�ܿ�4��
		/// </summary>
		ITEM_STRENTH_FAIL_FOUR = 1000026,
		/// <summary>
		///  ��ȯ����
		/// </summary>
		ITEM_NOT_ENOUGH_POINT = 1000027,
		/// <summary>
		///  ǿ�����ʹ���(�ƺ�)addedbyhuchenhui2016.06.30
		/// </summary>
		ITEM_STRENTH_FAIL_TITLE = 1000028,
		/// <summary>
		///  װ�����ֽܷ�
		/// </summary>
		ITEM_CNA_NOT_DECOMPOSE = 1000029,
		/// <summary>
		///  ����ʹ��CD��
		/// </summary>
		ITEM_USE_CD = 1000030,
		/// <summary>
		///  ��װ�����ﵽ����
		/// </summary>
		ITEM_SEAL_COUNT_MAX = 1000031,
		/// <summary>
		///  װ���Ѿ��Ƿ�װ��
		/// </summary>
		ITEM_ALREADY_SEAL = 1000032,
		/// <summary>
		///  װ����װƷ�ʲ���
		/// </summary>
		ITEM_SEAL_QUALITY_ERR = 1000033,
		/// <summary>
		///  ����֮�겻��
		/// </summary>
		ITEM_NOT_ENOUGH_WARRIOR_SOUL = 1000034,
		/// <summary>
		///  �����Ҳ���
		/// </summary>
		ITEM_NOT_ENOUGH_PKCOIN = 1000035,
		/// <summary>
		///  ��ħ��λ����
		/// </summary>
		ITEM_ADDMAGIC_PART_ERR = 1000036,
		/// <summary>
		///  ��ħ���ϳ�Ʒ�ʲ�ͬ
		/// </summary>
		ITEM_MAGCARD_COMP_DIF_COLOR = 1000037,
		/// <summary>
		///  һ���ֽ�����ȼ�����
		/// </summary>
		ITEM_ONEKEY_DECOMPOSE_LV_NOT_ENOUGH = 1000038,
		/// <summary>
		///  �������ս�Ǯ��������
		/// </summary>
		ITEM_OPEN_JAR_DAYCOUNT = 1000039,
		/// <summary>
		///  ���ܳ���
		/// </summary>
		ITEM_NOT_SELL = 1000040,
		/// <summary>
		///  ������Ʒ������
		/// </summary>
		ITEM_SELL_ITEM_NOT_EXIST = 1000041,
		/// <summary>
		///  ���ṱ�ײ���
		/// </summary>
		ITEM_NOT_ENOUGH_GUILD_CONTRI = 1000042,
		/// <summary>
		///  ʹ�õ���buff�Ѿ�����
		/// </summary>
		ITEM_USE_BUFFALREADYEXIST = 1000043,
		/// <summary>
		///  ���Ҳ���
		/// </summary>
		ITEM_NOT_ENOUGH_MONEY = 1000044,
		/// <summary>
		///  ǿ��ȯ�ȼ�����
		/// </summary>
		ITEM_STRTICKET_LV_ERR = 1000045,
		/// <summary>
		///  ǿ��ȯ�۳�ʧ��
		/// </summary>
		ITEM_STRTICKET_REDUCE_ERR = 1000046,
		/// <summary>
		///  ������ʹ�ô�������
		/// </summary>
		ITEM_DAYUSENUM = 1000047,
		/// <summary>
		///  ǿ��ȯǿ��ʧ��
		/// </summary>
		ITEM_SPECIAL_STRENTH_FAIL = 1000048,
		/// <summary>
		///  errcode49
		/// </summary>
		ITEM_ERRCODE_49 = 1000049,
		/// <summary>
		///  errcode50
		/// </summary>
		ITEM_ERRCODE_50 = 1000050,
		/// <summary>
		///  errcode51
		/// </summary>
		ITEM_ERRCODE_51 = 1000051,
		/// <summary>
		///  errcode52
		/// </summary>
		ITEM_ERRCODE_52 = 1000052,
		/// <summary>
		///  errcode53
		/// </summary>
		ITEM_ERRCODE_53 = 1000053,
		/// <summary>
		///  ���³ǲ���ʹ�øõ���
		/// </summary>
		ITEM_CAN_NOT_USE_IN_DUNGEON = 1000054,
		/// <summary>
		///  �����ڲ���ʹ�øõ���
		/// </summary>
		ITEM_CAN_NOT_USE_IN_TOWN = 1000055,
		/// <summary>
		///  ���߷���
		/// </summary>
		ITEM_ABANDON = 1000056,
		/// <summary>
		///  �̵����
		/// </summary>
		SHOP = 1100000,
		/// <summary>
		///  �̵��ѯ����
		/// </summary>
		SHOP_QUERY_ERR = 1100001,
		/// <summary>
		///  �̵�ˢ�´���
		/// </summary>
		SHOP_REFRESH_ERR = 1100002,
		/// <summary>
		///  �̵깺�����
		/// </summary>
		SHOP_BUY_ERR = 1100003,
		/// <summary>
		///  �̵깺���Ҳ���
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_GOLD = 1100004,
		/// <summary>
		///  �̵깺���ȯ����
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_POINT = 1100005,
		/// <summary>
		///  �̵깺����߲���
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_ITEM = 1100006,
		/// <summary>
		///  �̵깺�򱳰��ռ䲻��
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_PACKSIZE = 1100007,
		/// <summary>
		///  �̵깺������
		/// </summary>
		SHOP_BUY_SALE_OUT = 1100008,
		/// <summary>
		///  �̵�ˢ�µ�ȯ����
		/// </summary>
		SHOP_REFRESH_NOT_ENOUGH_MONEY = 1100009,
		/// <summary>
		///  ��������������
		/// </summary>
		SHOP_NOT_ENOUGH_TOWER_LEVEL = 1100010,
		/// <summary>
		///  �Ƕ������ֲ���
		/// </summary>
		SHOP_NOT_ENOUGH_DUEL_POINT = 1100011,
		/// <summary>
		///  �̵�ˢ�´�������
		/// </summary>
		SHOP_REFRESH_COUNT = 1100012,
		/// <summary>
		///  �����̵겻����
		/// </summary>
		SHOP_GUIlD_SHOP_NOT_EXIST = 1100013,
		/// <summary>
		///  �����̵�ȼ�����
		/// </summary>
		SHOP_GUIlD_NOT_ENOUGH_LV = 1100014,
		/// <summary>
		///  �ʼ����
		/// </summary>
		MAIL = 1200000,
		/// <summary>
		///  �ʼ�ϵͳ����
		/// </summary>
		MAIL_ERROR = 1200001,
		/// <summary>
		///  �������
		/// </summary>
		MAIL_TITLE_ERROR = 1200002,
		/// <summary>
		///  ���ⳤ�ȴ���
		/// </summary>
		MAIL_TITLE_LENGTH_ERROR = 1200003,
		/// <summary>
		///  ���ݴ���
		/// </summary>
		MAIL_CONTENT_ERROR = 1200004,
		/// <summary>
		///  ���ݳ��ȴ���
		/// </summary>
		MAIL_CONTENT_LENGTH_ERROR = 1200005,
		/// <summary>
		///  �������ַ�������
		/// </summary>
		MAIL_SENDER_NAME_ERROR = 1200006,
		/// <summary>
		///  �������ַ������ȴ���
		/// </summary>
		MAIL_SENDER_NAME_LENGTH_ERROR = 1200007,
		/// <summary>
		///  ��������
		/// </summary>
		MAIL_REWARD_ERROR = 1200008,
		/// <summary>
		///  ������
		/// </summary>
		TEAM = 1300000,
		/// <summary>
		///  ���ϵͳ����
		/// </summary>
		TEAM_ERROR = 1300001,
		/// <summary>
		///  �������飬�Ѿ��ж�����
		/// </summary>
		TEAM_CREATE_TEAM_HAS_TEAM = 1300002,
		/// <summary>
		///  �������飬��Ч�Ķ���Ŀ��
		/// </summary>
		TEAM_CREATE_TEAM_INVALID_TARGET = 1300003,
		/// <summary>
		///  ������飬��ʱ
		/// </summary>
		TEAM_JOIN_TIMEOUT = 1300004,
		/// <summary>
		///  ������飬���鲻����
		/// </summary>
		TEAM_JOIN_TEAM_UNEXIST = 1300005,
		/// <summary>
		///  ������飬������
		/// </summary>
		TEAM_JOIN_TEAM_FULL = 1300006,
		/// <summary>
		///  ������飬�ӳ�����
		/// </summary>
		TEAM_JOIN_TEAM_MASTER_OFFLINE = 1300007,
		/// <summary>
		///  ������飬�Ѿ��ж�����
		/// </summary>
		TEAM_JOIN_TEAM_HAS_TEAM = 1300008,
		/// <summary>
		///  ������飬�������
		/// </summary>
		TEAM_JOIN_TEAM_PASSWD_ERROR = 1300009,
		/// <summary>
		///  ������飬����������
		/// </summary>
		TEAM_JOIN_TEAM_HAS_PASSWD = 1300010,
		/// <summary>
		///  ������飬�ȼ�����
		/// </summary>
		TEAM_JOIN_LEVEL_LIMIT = 1300011,
		/// <summary>
		///  ���볤�Ȳ���
		/// </summary>
		TEAM_PASSWD_ERROR_LENGTH = 1300012,
		/// <summary>
		///  ����ֻ��������
		/// </summary>
		TEAM_PASSWD_ONLY_NUM = 1300013,
		/// <summary>
		///  ����̫��
		/// </summary>
		TEAM_NAME_TOO_LONG = 1300014,
		/// <summary>
		///  ��Ч������
		/// </summary>
		TEAM_NAME_INVALID = 1300015,
		/// <summary>
		///  ��Ч��Ŀ��
		/// </summary>
		TEAM_TARGET_INVALID = 1300016,
		/// <summary>
		///  �л�Ŀ��ʧ�ܣ�����̫��
		/// </summary>
		TEAM_TOO_MANY_PLAYER = 1300017,
		/// <summary>
		///  ���������ߣ��㲻�Ƕӳ�
		/// </summary>
		TEAM_REPLY_NOT_MASTER = 1300018,
		/// <summary>
		///  ���������ߣ���Ҳ�����
		/// </summary>
		TEAM_REPLY_PLAYER_OFFLINE = 1300019,
		/// <summary>
		///  ���������ߣ������δ�������
		/// </summary>
		TEAM_REPLY_PLAYER_INVALID = 1300020,
		/// <summary>
		///  ���������ߣ���������
		/// </summary>
		TEAM_REPLY_TEAM_FULL = 1300021,
		/// <summary>
		///  ������ң��Լ�û�ж���
		/// </summary>
		TEAM_INVITE_NO_TEAM = 1300022,
		/// <summary>
		///  ������ң��Լ����Ƕӳ�
		/// </summary>
		TEAM_INVITE_NOT_TEAM_MASTER = 1300023,
		/// <summary>
		///  ������ң���������
		/// </summary>
		TEAM_INVITE_TEAM_FULL = 1300024,
		/// <summary>
		///  ������ң���������ս����
		/// </summary>
		TEAM_INVITE_TEAM_IN_RACE = 1300025,
		/// <summary>
		///  ������ң��Է�������
		/// </summary>
		TEAM_INVITE_TARGET_OFFLINE = 1300026,
		/// <summary>
		///  ������ң��Է��Ѿ��ڶ�����
		/// </summary>
		TEAM_INVITE_TARGET_IN_TEAM = 1300027,
		/// <summary>
		///  ������ң�Ŀ����æ
		/// </summary>
		TEAM_INVITE_TARGET_BUSY = 1300028,
		/// <summary>
		///  ������ң��ظ�����
		/// </summary>
		TEAM_INVITE_REPEAT = 1300029,
		/// <summary>
		///  ������飬��������ս����
		/// </summary>
		TEAM_JOIN_RACING = 1300030,
		/// <summary>
		///  �ȼ�����
		/// </summary>
		TEAM_MIN_LEVEL = 1300031,
		/// <summary>
		///  ������ң��Է��ȼ�����
		/// </summary>
		TEAM_INVITE_TARGET_MIN_LEVEL = 1300032,
		/// <summary>
		///  ������ң�̫Ƶ��
		/// </summary>
		TEAM_INVITE_FREQUENTLY = 1300033,
		/// <summary>
		///  ��ʼƥ��ʧ�ܣ������������Ҫ��ʾ
		/// </summary>
		TEAM_MATCH_START_FAILED = 1301001,
		/// <summary>
		///  ֻ�жӳ��ܲ���
		/// </summary>
		TEAM_MATCH_ONLY_MASTER = 1301002,
		/// <summary>
		///  ��ʼƥ��ʧ�ܣ��Ѿ���ƥ����
		/// </summary>
		TEAM_MATCH_START_IN_MATCHING = 1301003,
		/// <summary>
		///  ȡ��ƥ��ʧ�ܣ�����ƥ����
		/// </summary>
		TEAM_MATCH_CANCEL_NOT_IN_MATCHING = 1301004,
		/// <summary>
		///  ��Ԫʯ���
		/// </summary>
		WARPSTONE = 1400000,
		/// <summary>
		///  ���Ҳ���
		/// </summary>
		WARP_STONE_SILVER_ERROR = 1400001,
		/// <summary>
		///  û�н���
		/// </summary>
		WARP_STONE_UNLOCK_ERROR = 1400002,
		/// <summary>
		///  �������ȼ�
		/// </summary>
		WARP_STONE_LEVEL_MAX = 1400003,
		/// <summary>
		///  ��Ԫʯû�ҵ�
		/// </summary>
		WARP_STONE_NOT_FOUNT = 1400004,
		/// <summary>
		///  ��Ԫʯ�����ȼ�����
		/// </summary>
		WARP_STONE_PLAYER_LEVEL_ERROR = 1400005,
		/// <summary>
		///  ����ʯû���ҵ�
		/// </summary>
		ENERGY_STONE_NOT_FOUNT = 1400006,
		/// <summary>
		///  ����ʯ����
		/// </summary>
		ENERGY_STONE_NOT_ENOUGH = 1400007,
		/// <summary>
		///  ����ʯ���ʹ���
		/// </summary>
		ENERGY_STONE_TYPE_ERROR = 1400008,
		/// <summary>
		///  ������
		/// </summary>
		RETINUE = 1500000,
		/// <summary>
		///  û�ж�Ӧ�����
		/// </summary>
		RETINUE_NOT_PLAYER = 1500001,
		/// <summary>
		///  ������ݱ�����
		/// </summary>
		RETINUE_DATA_NOT_EXIST = 1500002,
		/// <summary>
		///  ��Ӳ�����
		/// </summary>
		RETINUE_NOT_EXIST = 1500003,
		/// <summary>
		///  ����Ѿ�����
		/// </summary>
		RETINUE_IS_EXIST = 1500004,
		/// <summary>
		///  ��ҵȼ�����
		/// </summary>
		RETINUE_PLAYER_LEVEL = 1500005,
		/// <summary>
		///  ϴ����Ʒ����
		/// </summary>
		RETINUE_NOT_ITEM = 1500006,
		/// <summary>
		///  ������Ʒ����
		/// </summary>
		RETINUE_UNLOCK_NOT_ITEM = 1500007,
		/// <summary>
		///  ��ӵȼ�������.
		/// </summary>
		RETINUE_LEVEL_DATA_NOT_EXIST = 1500008,
		/// <summary>
		///  ������Ʒ����
		/// </summary>
		RETINUE_LEVEL_NOT_ITEM = 1500009,
		/// <summary>
		///  �������λ�ô���
		/// </summary>
		RETINUE_RETINUE_INDEX_ERROR = 1500010,
		/// <summary>
		///  ��ʿ֮�겻��
		/// </summary>
		RETINUE_WARRIOR_SOUL_ERROR = 1500011,
		/// <summary>
		///  ���ܳ�������Ǽ�
		/// </summary>
		RETINUE_MAX_STAR_ERROR = 1500012,
		/// <summary>
		///  û������Ǽ�
		/// </summary>
		RETINUE_STAR_LEVEL_NOT_EXIST = 1500013,
		/// <summary>
		///  ������Ƭ����
		/// </summary>
		RETINUE_UP_STAR_NOT_ITEM = 1500014,
		/// <summary>
		///  û�п�ϴ���ļ���
		/// </summary>
		RETINUE_NOT_CHANGE_SKILL_ERROR = 1500015,
		/// <summary>
		///  û�ж�Ӧ��ϴ����
		/// </summary>
		RETINUE_NOT_SKILL_GROUP_ERROR = 1500016,
		/// <summary>
		///  ϴ������һ����
		/// </summary>
		RETINUE_SKILL_GROUP_RING_ERROR = 1500017,
		/// <summary>
		///  �������Ͳ���ȷ
		/// </summary>
		RETINUE_UP_TYPE_ERROR = 1500018,
		/// <summary>
		///  û�������
		/// </summary>
		RETINUE_NOT_MAIN_ERROR = 1500019,
		/// <summary>
		///  �޷��������
		/// </summary>
		RETINUE_NOT_DOWN_ERROR = 1500020,
		/// <summary>
		///  ����
		/// </summary>
		RECONNECT = 1600000,
		/// <summary>
		///  ��ɫ�����Ѿ�ɾ��
		/// </summary>
		RECONNECT_PLAYER_DELETED = 1600001,
		/// <summary>
		///  ��Ч��sequence
		/// </summary>
		RECONNECT_INVALID_SEQUENCE = 1600002,
		/// <summary>
		///  �˺Ż�����
		/// </summary>
		RECONNECT_PLAYER_ONLINE = 1600003,
		/// <summary>
		///  ���������
		/// </summary>
		RECONNECT_NO_CONNECTION = 1600004,
		/// <summary>
		///  �̳�
		/// </summary>
		MALL = 1700000,
		/// <summary>
		///  �̳���Ʒ��ѯʧ��
		/// </summary>
		MALL_QUERY_FAIL = 1700001,
		/// <summary>
		///  ������������
		/// </summary>
		MALL_BUYNUM_ERR = 1700002,
		/// <summary>
		///  �Ҳ���Ҫ�������Ʒ
		/// </summary>
		MALL_CANNOT_FIND_ITEM = 1700003,
		/// <summary>
		///  �Ҳ���Ҫ��������ʱ���
		/// </summary>
		MALL_CANNOT_FIND_GIFT_PACK = 1700004,
		/// <summary>
		///  �̳���ʱ����Ѵ���
		/// </summary>
		MALL_GIFT_PACK_ACTIVATED = 1700005,
		/// <summary>
		///  ������
		/// </summary>
		PLAYER = 1800000,
		/// <summary>
		///  תְ�ȼ�����
		/// </summary>
		PLAYER_TRANSFORM_OCCU_LEVEL_ERROR = 1800001,
		/// <summary>
		///  ���ѵȼ�����
		/// </summary>
		PLAYER_AWAKEN_LEVEL_ERROR = 1800002,
		/// <summary>
		///  �Ѿ�����
		/// </summary>
		PLAYER_AWAKEN_EXIST = 1800003,
		/// <summary>
		///  ��δתְ
		/// </summary>
		PLAYER_AWAKEN_NOT_TRANSFORM_OCCU = 1800004,
		/// <summary>
		///  vip����ʱ,vip�ȼ�����
		/// </summary>
		PLAYER_VIP_BUY_LEVEL_ERROR = 1800005,
		/// <summary>
		///  vip�������,�����
		/// </summary>
		PLAYER_VIP_BUY_GIFT_ENOUGH_POINT = 1800006,
		/// <summary>
		///  vip���Ϊ��
		/// </summary>
		PLAYER_VIP_GIFT_EMPTY = 1800007,
		/// <summary>
		///  vip������������ռ䲻��
		/// </summary>
		PLAYER_VIP_BUY_NOT_ENOUGH_PACKSIZE = 1800008,
		/// <summary>
		///  vip����������ĵ��ʧ��
		/// </summary>
		PLAYER_VIP_BUY_REMOVE_POINT_ERROR = 1800009,
		/// <summary>
		///  vip�Ѿ�����������
		/// </summary>
		PLAYER_VIP_BUY_ALREADY = 1800010,
		/// <summary>
		///  vip�ȼ�����
		/// </summary>
		PLAYER_VIPLV_NOT_ENOUGH = 1800011,
		/// <summary>
		///  ���ٹ���
		/// </summary>
		QUICKBUY = 1900000,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		QUICK_BUY_SYSTEM_ERROR = 1900001,
		/// <summary>
		///  ��һ������û����
		/// </summary>
		QUICK_BUY_LAST_TRANS_NOT_FINISH = 1900002,
		/// <summary>
		///  ��ʱ
		/// </summary>
		QUICK_BUY_TIMEOUT = 1900003,
		/// <summary>
		///  ��Ч������
		/// </summary>
		QUICK_BUY_INVALID_TYPE = 1900004,
		/// <summary>
		///  Ǯ����
		/// </summary>
		QUICK_BUY_NOT_ENOUGH_MONEY = 1900005,
		/// <summary>
		///  ���߲�����
		/// </summary>
		QUICK_BUY_INVALID_ITEM = 1900006,
		/// <summary>
		///  ������������ȷ
		/// </summary>
		QUICK_BUY_INVALID_NUM = 1900007,
		/// <summary>
		///  �����ռ䲻��
		/// </summary>
		QUICK_BUY_BAG_FULL = 1900008,
		/// <summary>
		///  ���ڱ�����
		/// </summary>
		QUICK_BUY_REVIVE_NOT_IN_RACE = 1900009,
		/// <summary>
		///  �������
		/// </summary>
		TASK = 2000000,
		/// <summary>
		///  �ύ������Ʒ���ʹ���
		/// </summary>
		TASK_SET_ITEM_TASK_TYPE_ERROR = 2000001,
		/// <summary>
		///  �ύ�����������Ʒ
		/// </summary>
		TASK_SET_ITEM_ERROR = 2000002,
		/// <summary>
		///  �ύ��������Ʒ��������
		/// </summary>
		TASK_SET_ITEM_NUM_ERROR = 2000003,
		/// <summary>
		///  ���񲻴���
		/// </summary>
		TASK_NOT_EXIST = 2000004,
		/// <summary>
		///  ����ű�������
		/// </summary>
		TASK_SCRIPT_NOT_EXIST = 2000005,
		/// <summary>
		///  �����ٽ�ȡ״̬
		/// </summary>
		TASK_NOT_UNFINISH = 2000006,
		/// <summary>
		///  �������ʹ���
		/// </summary>
		TASK_TYPE_ERROR = 2000007,
		/// <summary>
		///  ѭ�����񲻴���
		/// </summary>
		TASK_CYCLE_NOT_EXIST = 2000008,
		/// <summary>
		///  ������Դ����
		/// </summary>
		TASK_CYCLE_REFRESH_NOT_CONSUME = 2000009,
		/// <summary>
		///  ÿ��������ֽ������Ӳ�����
		/// </summary>
		TASK_DATILY_TASK_SCORE_BOX_NOT_FOUNT = 2000010,
		/// <summary>
		///  ÿ��������ֽ������ֲ���
		/// </summary>
		TASK_DATILY_TASK_SCORE_BOX_SCORE = 2000011,
		/// <summary>
		///  ÿ��������ֽ����Ѿ���ȡ
		/// </summary>
		TASK_DATILY_TASK_SCORE_BOX_RECEIVE = 2000012,
		/// <summary>
		///  ����֮��
		/// </summary>
		TOWER = 2100000,
		/// <summary>
		///  û�����ô���
		/// </summary>
		TOWER_RESET_NO_REMAIN_COUNT = 2100001,
		/// <summary>
		///  ����ɨ����
		/// </summary>
		TOWER_DOING_WIPEOUT = 2100002,
		/// <summary>
		///  û�в���ȥɨ��
		/// </summary>
		TOWER_NO_FLOOR_WIPEOUT = 2100003,
		/// <summary>
		///  û����ɨ����
		/// </summary>
		TOWER_NOT_DOING_WIPEOUT = 2100004,
		/// <summary>
		///  ɨ��δ���
		/// </summary>
		TOWER_WIPEOUT_NOT_FINISH = 2100005,
		/// <summary>
		///  ɨ�������
		/// </summary>
		TOWER_WIPEOUT_FINISHED = 2100006,
		/// <summary>
		///  û���㹻�ĵㄻ
		/// </summary>
		TOWER_WIPEOUT_NOT_ENOUGH_POINT = 2100007,
		/// <summary>
		///  δͨ���ò�
		/// </summary>
		TOWER_AWARD_NOT_PASS_FLOOR = 2100008,
		/// <summary>
		///  ��Ч�Ĳ�����û�ж�Ӧ����
		/// </summary>
		TOWER_AWARD_INVALID_FLOOR = 2100009,
		/// <summary>
		///  �ظ��콱
		/// </summary>
		TOWER_AWARD_REPEAT_RECEIVE = 2100010,
		/// <summary>
		///  ����Ҫ����
		/// </summary>
		TOWER_NO_NEED_RESET = 2100011,
		/// <summary>
		///  û��VIPȨ��
		/// </summary>
		TOWER_RESET_NO_VIP_PRIVILEGE = 2100012,
		/// <summary>
		///  PK���
		/// </summary>
		PK = 2200000,
		/// <summary>
		///  �����
		/// </summary>
		PK_CHALLENGE_IN_TEAM = 2200001,
		/// <summary>
		///  ����PK׼������
		/// </summary>
		PK_CHALLENGE_NOT_IN_PK_PREPARE = 2200002,
		/// <summary>
		///  Ŀ����æ
		/// </summary>
		PK_CHALLENGE_TARGET_BUSY = 2200003,
		/// <summary>
		///  Ŀ�겻����
		/// </summary>
		PK_CHALLENGE_TARGET_NOT_ONLINE = 2200004,
		/// <summary>
		///  �ظ���ս
		/// </summary>
		PK_CHALLENGE_REPEAT = 2200005,
		/// <summary>
		///  �ȼ�̫��
		/// </summary>
		PK_CHALLENGE_LEVEL_LIMIT = 2200006,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		PK_WUDAO_SYSTEM_ERROR = 2200007,
		/// <summary>
		///  �δ��ʼ
		/// </summary>
		PK_WUDAO_ACTIVITY_NOT_OPEN = 2200008,
		/// <summary>
		///  ��������������
		/// </summary>
		PK_WUDAO_ACTIVITY_COND = 2200009,
		/// <summary>
		///  û����Ʊ
		/// </summary>
		PK_WUDAO_NO_TICKET = 2200010,
		/// <summary>
		///  �Ѿ��μ���
		/// </summary>
		PK_WUDAO_JOINED = 2200011,
		/// <summary>
		///  ������δ���
		/// </summary>
		PK_WUDAO_NOT_COMPLETE = 2200012,
		/// <summary>
		///  ����
		/// </summary>
		GUILD = 2300000,
		/// <summary>
		///  û�ж�Ӧ��Ȩ��
		/// </summary>
		GUILD_NO_POWER = 2300001,
		/// <summary>
		///  ��������
		/// </summary>
		GUILD_FULL = 2300002,
		/// <summary>
		///  ���ڹ�����
		/// </summary>
		GUILD_NOT_IN_GUILD = 2300003,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		GUILD_SYS_ERROR = 2300004,
		/// <summary>
		///  û���㹻��Ǯ
		/// </summary>
		GUILD_NOT_ENOUGH_MONEY = 2300005,
		/// <summary>
		///  ��������
		/// </summary>
		GUILD_NOT_ENOUGH_TIMES = 2300006,
		/// <summary>
		///  ����ս�ڼ䲻���뿪����
		/// </summary>
		GUILD_BATTLE_NOT_LEAVE = 2300007,
		/// <summary>
		///  �����ظ�
		/// </summary>
		GUILD_NAME_REPEAT = 2301001,
		/// <summary>
		///  ��������������
		/// </summary>
		GUILD_NAME_INVALID = 2301002,
		/// <summary>
		///  ��������������
		/// </summary>
		GUILD_DECLARATION_INVALID = 2301003,
		/// <summary>
		///  ��������������
		/// </summary>
		GUILD_ANNOUNCEMENT_INVALID = 2301004,
		/// <summary>
		///  ��������������
		/// </summary>
		GUILD_MAIL_INVALID = 2301005,
		/// <summary>
		///  �ظ�����
		/// </summary>
		GUILD_CREATE_REPEAT = 2302001,
		/// <summary>
		///  �Ѿ��ڹ�����
		/// </summary>
		GUILD_CREATE_ALREADY_HAS_GUILD = 2302002,
		/// <summary>
		///  ��Ч�Ĺ�����
		/// </summary>
		GUILD_CREATE_INVALID_NAME = 2302003,
		/// <summary>
		///  ��Ч�Ĺ�������
		/// </summary>
		GUILD_CREATE_INVALID_DECLARATION = 2302004,
		/// <summary>
		///  û���㹻��Ǯ
		/// </summary>
		GUILD_CREATE_NOT_ENOUGH_MONEY = 2302005,
		/// <summary>
		///  �ȼ�����
		/// </summary>
		GUILD_CREATE_MIN_LEVEL = 2302006,
		/// <summary>
		///  ���뿪���ᣬ������ȴʱ����
		/// </summary>
		GUILD_CREATE_COLDTIME = 2302007,
		/// <summary>
		///  ������Ϊ��
		/// </summary>
		GUILD_CREATE_NAME_EMPTY = 2302008,
		/// <summary>
		///  ��������Ϊ��
		/// </summary>
		GUILD_CREATE_DECLARATION_EMPTY = 2302009,
		/// <summary>
		///  �ظ�����
		/// </summary>
		GUILD_JOIN_REPEAT = 2303001,
		/// <summary>
		///  �Ѿ��ڹ�����
		/// </summary>
		GUILD_JOIN_ALREADY_HAS_GUILD = 2303002,
		/// <summary>
		///  �ȼ�����
		/// </summary>
		GUILD_JOIN_MIN_LEVEL = 2303003,
		/// <summary>
		///  ���᲻����
		/// </summary>
		GUILD_JOIN_NOT_EXIST = 2303004,
		/// <summary>
		///  ���뿪���ᣬ������ȴʱ����
		/// </summary>
		GUILD_JOIN_COLDTIME = 2303005,
		/// <summary>
		///  ���������б�����
		/// </summary>
		GUILD_JOIN_REQUEST_QUEUE_FULL = 2303006,
		/// <summary>
		///  �������ڽ�ɢ
		/// </summary>
		GUILD_JOIN_IN_DISMISS = 2303007,
		/// <summary>
		///  ��ת�û᳤
		/// </summary>
		GUILD_LEAVE_TRANSFER_LEADER = 2304001,
		/// <summary>
		///  û�����������
		/// </summary>
		GUILD_REPLY_REQUESTER_UNEXIST = 2305001,
		/// <summary>
		///  �Ѿ���������������
		/// </summary>
		GUILD_REPLY_IN_OTHER_GUILD = 2305002,
		/// <summary>
		///  ���뿪���ᣬ������ȴʱ����
		/// </summary>
		GUILD_REPLY_COLDTIME = 2305003,
		/// <summary>
		///  Ŀ��ְ����������
		/// </summary>
		GUILD_POST_FULL = 2306001,
		/// <summary>
		///  ��Ҫ�᳤����7�첻����
		/// </summary>
		GUILD_POST_LEADER_LEAVE_TIME = 2306002,
		/// <summary>
		///  �������ǵȼ������������ǵȼ�
		/// </summary>
		GUILD_BUILDING_UPGRADE_MAIN_FIRST = 2307001,
		/// <summary>
		///  �Ѿ�������
		/// </summary>
		GUILD_BUILDING_TOP_LEVEL = 2307002,
		/// <summary>
		///  ����ʽ���
		/// </summary>
		GUILD_BUILDING_NOT_ENOUGH_FUND = 2307003,
		/// <summary>
		///  ʣ���������
		/// </summary>
		GUILD_DONATE_NO_REMAIN_TIMES = 2308001,
		/// <summary>
		///  ����CD��
		/// </summary>
		GUILD_EXCHANGE_CD = 2309001,
		/// <summary>
		///  ʣ���������
		/// </summary>
		GUILD_EXCHANGE_NO_REMAIN_TIMES = 2309002,
		/// <summary>
		///  ���ײ���
		/// </summary>
		GUILD_EXCHANGE_NOT_ENOUGH_CONTRI = 2309003,
		/// <summary>
		///  �Ѿ�������ߵȼ�
		/// </summary>
		GUILD_SKILL_TOP_LEVEL = 2310001,
		/// <summary>
		///  ���ڽ�ɢ��
		/// </summary>
		GUILD_DISMISS_IN_DISMISS = 2311001,
		/// <summary>
		///  ���ڽ�ɢ��
		/// </summary>
		GUILD_NOT_IN_DISMISS = 2311002,
		/// <summary>
		///  Բ������
		/// </summary>
		GUILD_TABLE_FULL = 2312001,
		/// <summary>
		///  λ���Ѿ���ռ
		/// </summary>
		GUILD_TABLE_SEAT_HAS_PLAYER = 2312002,
		/// <summary>
		///  �Ѿ���λ������
		/// </summary>
		GUILD_TABLE_REPEAT = 2312003,
		/// <summary>
		///  ��Ч��λ��
		/// </summary>
		GUILD_TABLE_SEAT_INVALID = 2312004,
		/// <summary>
		///  Ĥ�����ʹ���
		/// </summary>
		GUILD_ORZ_INVALID_TYPE = 2313001,
		/// <summary>
		///  û�����VIPȨ��
		/// </summary>
		GUILD_ORZ_VIP_PRIVILEGE = 2313002,
		/// <summary>
		///  û���ҵ����
		/// </summary>
		GUILD_BATTLE_NOT_PLAYER = 2314001,
		/// <summary>
		///  ���û�й���
		/// </summary>
		GUILD_BATTLE_NOT_EXIST = 2314002,
		/// <summary>
		///  ��Ҳ��ǹ����Ա
		/// </summary>
		GUILD_BATTLE_NOT_IS_MEMBER = 2314003,
		/// <summary>
		///  ����ս���������Ҳ���
		/// </summary>
		GUILD_BATTLE_ENROLL_GUILD_NOT_FIND = 2314004,
		/// <summary>
		///  ��ұ���û��Ȩ��
		/// </summary>
		GUILD_BATTLE_ENROLL_NOT_POWER = 2314005,
		/// <summary>
		///  ����սû�п�ʼ����
		/// </summary>
		GUILD_BATTLE_ENROLL_NOT_ENROLL = 2314006,
		/// <summary>
		///  ����ս������������
		/// </summary>
		GUILD_BATTLE_ENROLL_FULL = 2314007,
		/// <summary>
		///  ����ս��������ȼ�����
		/// </summary>
		GUILD_BATTLE_ENROLL_GUILD_LEVEL = 2314008,
		/// <summary>
		///  ����ս����ռ����صȼ�̫��
		/// </summary>
		GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_LOW = 2314009,
		/// <summary>
		///  ����ս����ռ����صȼ�̫��
		/// </summary>
		GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_HIGH = 2314010,
		/// <summary>
		///  ����ս�����ظ�����
		/// </summary>
		GUILD_BATTLE_ENROLL_EXIST = 2314011,
		/// <summary>
		///  ����ս�������ڴ�������
		/// </summary>
		GUILD_BATTLE_ENROLL_TRANSACTION = 2314012,
		/// <summary>
		///  ��ز����ڻ��߹���û�б���
		/// </summary>
		GUILD_BATTLE_TERRITORY_NOT_EXIST = 2314013,
		/// <summary>
		///  ����û�б���
		/// </summary>
		GUILD_BATTLE_NOT_ENROLL = 2314014,
		/// <summary>
		///  ����ս�����Ѿ���ߴ���
		/// </summary>
		GUILD_BATTLE_INSPIRE_MAX_COUNT = 2314015,
		/// <summary>
		///  ����ս������߲���
		/// </summary>
		GUILD_BATTLE_INSPIRE_ITEM = 2314016,
		/// <summary>
		///  ����ս�������ڴ�������
		/// </summary>
		GUILD_BATTLE_INSPIRE_TRANSACTION = 2314017,
		/// <summary>
		///  ����ս��Աƥ���������
		/// </summary>
		GUILD_BATTLE_MEMBER_MATCH_COUNT = 2314018,
		/// <summary>
		///  ս�������Ҳ������
		/// </summary>
		GUILD_BATTLE_RACE_END_NOT_MEMBER = 2314019,
		/// <summary>
		///  ����ս�Ѿ�����
		/// </summary>
		GUILD_BATTLE_IS_END = 2314020,
		/// <summary>
		///  ��ȡ�����Ҳ������
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_NOT_MEMBER = 2314021,
		/// <summary>
		///  ��ȡ����û���ҵ�������
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_DATA_ERROR = 2314022,
		/// <summary>
		///  ��ȡ�������ֲ���
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_SCORE_ERROR = 2314023,
		/// <summary>
		///  �����Ѿ���ȡ
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_ALREADY = 2314024,
		/// <summary>
		///  ����ս��һ��ս��û�н���
		/// </summary>
		GUILD_BATTLE_RACE_NOT_END = 2314025,
		/// <summary>
		///  ����սƥ�����ڴ�������
		/// </summary>
		GUILD_BATTLE_MATCH_TRANSACTION = 2314026,
		/// <summary>
		///  ����ս�������ܽ�ɢ
		/// </summary>
		GUILD_BATTLE_ENROLL_NOT_DISMISS = 2314027,
		/// <summary>
		///  ����ս��ɢ�в��ܱ���
		/// </summary>
		GUILD_BATTLE_DISMISS_NOT_ENROLL = 2314028,
		/// <summary>
		///  ��������
		/// </summary>
		ITEM_TRANS = 2400000,
		/// <summary>
		///  ʧ��
		/// </summary>
		ITEM_TRANS_FAILED = 2400001,
		/// <summary>
		///  Ǯ����
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_MONEY = 2400002,
		/// <summary>
		///  ����Ҳ���
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_REVIVE_COIN = 2400003,
		/// <summary>
		///  ���߲���
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_ITEM = 2400004,
		/// <summary>
		///  ��������
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_TIMES = 2400005,
		/// <summary>
		///  ���
		/// </summary>
		RED_PACKET = 2500000,
		/// <summary>
		///  ϵͳ����
		/// </summary>
		RED_PACKET_SYS_ERROR = 2500001,
		/// <summary>
		///  ��Ч�ĺ��
		/// </summary>
		RED_PACKET_INVALID = 2500002,
		/// <summary>
		///  ���������
		/// </summary>
		RED_PACKET_NOT_EXIST = 2500003,
		/// <summary>
		///  ����������
		/// </summary>
		RED_PACKET_NOT_OWNER = 2500004,
		/// <summary>
		///  ����Ѿ�����ȥ��
		/// </summary>
		RED_PACKET_ALREADY_SEND = 2500005,
		/// <summary>
		///  �����������ڹ�����
		/// </summary>
		RED_PACKET_NOT_IN_GUILD = 2500006,
		/// <summary>
		///  ����޷���
		/// </summary>
		RED_PACKET_CANT_OPEN = 2500007,
		/// <summary>
		///  ����ѱ�����
		/// </summary>
		RED_PACKET_EMPTY = 2500008,
		/// <summary>
		///  �����������
		/// </summary>
		RED_PACKET_INVALID_NUM = 2500009,
		/// <summary>
		///  ������ִ���
		/// </summary>
		RED_PACKET_INVALID_NAME = 2500010,
		/// <summary>
		///  ��ֵ
		/// </summary>
		BILLING = 2600000,
		/// <summary>
		///  ��Ҳ�����
		/// </summary>
		BILLING_PLAYER_OFFLINE = 2600001,
		/// <summary>
		///  ���ﲻ����
		/// </summary>
		BILLING_GOODS_UNEXIST = 2600002,
		/// <summary>
		///  û�д�����
		/// </summary>
		BILLING_GOODS_NUM_LIMIT = 2600003,
		/// <summary>
		///  �¿�ʱ��δ���޷�����
		/// </summary>
		BILLING_GOODS_MONTH_CARD_CANT_BUY = 2600004,
	}

}
