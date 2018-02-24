local descriptor = require "descriptor"

module "ProtocolErrorCode"

ProtoErrorCode = descriptor.def_enum("ProtoErrorCode",
	{
		//  �ɹ�

		descriptor.def_enum_value("SUCCESS", 0),
		//  ��¼��֤

		descriptor.def_enum_value("LOGIN", 100000),
		//  ������δ����

		descriptor.def_enum_value("LOGIN_SERVER_UNREADY", 100001),
		//  δ֪�˺ţ��˺�������

		descriptor.def_enum_value("LOGIN_UNKNOW_ACCOUNT", 100002),
		//  �ظ���¼

		descriptor.def_enum_value("LOGIN_REPEAT", 100003),
		//  �����

		descriptor.def_enum_value("LOGIN_WRONG_PASSWD", 100004),
		//  ��֤��ʱ

		descriptor.def_enum_value("LOGIN_VERIFY_TIMEOUT", 100005),
		//  ��������æ

		descriptor.def_enum_value("LOGIN_SERVER_BUSY", 100006),
		//  �汾�Ŵ���

		descriptor.def_enum_value("LOGIN_ERROR_VERSION", 100007),
		//  ���

		descriptor.def_enum_value("LOGIN_FORBID_LOGIN", 100008),
		//  ���ݿ����

		descriptor.def_enum_value("LOGIN_DB_ERROR", 100009),
		//  �Ŷ���

		descriptor.def_enum_value("LOGIN_WAIT", 100010),
		//  ��������ֹ��¼

		descriptor.def_enum_value("LOGIN_BUSY", 100011),
		//  ������Ϸ

		descriptor.def_enum_value("ENTERGAME", 200000),
		//  ��ɫ��Ϣ���Ϸ�

		descriptor.def_enum_value("ENTERGAME_UNVALID_ROLEINFO", 200001),
		//  ��������æ

		descriptor.def_enum_value("ENTERGAME_SERVER_BUSY", 200002),
		//  ̫���ɫ

		descriptor.def_enum_value("ENTERGAME_TOOMANY_ROLES", 200003),
		//  �ظ���

		descriptor.def_enum_value("ENTERGAME_DUPLICATE_NAME", 200004),
		//  ɾ����ɫ�������Ϸʱ��ʾ

		descriptor.def_enum_value("ENTERGAME_NOROLE", 200005),
		//  ����δ����

		descriptor.def_enum_value("ENTERGAME_SCENE_UNREADY", 200006),
		//  ��ɫ��ʼ��ʧ��

		descriptor.def_enum_value("ENTERGAME_INIT_FAILED", 200007),
		//  �ظ�

		descriptor.def_enum_value("ENTERGAME_REPEAT", 200008),
		//  ��ɫ�����Ϸ�

		descriptor.def_enum_value("ENTERGAME_UNVALID_NAME", 200009),
		//  ��������

		descriptor.def_enum_value("ENTERGAME_NO_CREATEROLE", 200010),
		//  ��Ҫ�н�ɫ�ﵽ20��

		descriptor.def_enum_value("ENTERGAME_NEED_LEVEL_20", 200011),
		//  ��Ҫ�н�ɫ�ﵽ40��

		descriptor.def_enum_value("ENTERGAME_NEED_LEVEL_40", 200012),
		//  �������մ�����ɫ�����

		descriptor.def_enum_value("ENTERGAME_TODAY_TOOMANY_ROLE", 200013),
		//  ����ָ��Ľ�ɫ������

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_UNEXIST", 200014),
		//  ����ָ��Ľ�ɫ�Ѿ�ɾ���ˣ���������ʱ�䣩

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_DELETED", 200015),
		//  ����ָ��Ľ�ɫ��û�б�ɾ��

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_NOT_DELETE", 200016),
		//  ����ɾ���Ľ�ɫ�Ѿ���ɾ����

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_DELETED", 200017),
		//  ����ɾ���Ľ�ɫ������

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_UNEXIST", 200018),
		//  ��ǰ����ɾ���Ľ�ɫ�ﵽ����

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_MAX_NUM", 200019),
		// ����ɾ���Ľ�ɫ���ޣ�ʱ�����ƣ�

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_LIMIT", 200020),
		// ����ָ��Ľ�ɫ���ޣ�ʱ�����ƣ�

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_LIMIT", 200021),
		//  �������

		descriptor.def_enum_value("SCENE", 300000),
		//  �ظ��ĳ���

		descriptor.def_enum_value("SCENE_DUPLICATE", 300001),
		//  ����̬����ʱ����

		descriptor.def_enum_value("SCENE_NOOWNER", 300002),
		//  ����������

		descriptor.def_enum_value("RECORD", 400000),
		//  ���ݿ����

		descriptor.def_enum_value("RECORD_ERROR", 400001),
		//  �ظ���

		descriptor.def_enum_value("RECORD_DUPLICATE_NAME", 400002),
		//  û��������

		descriptor.def_enum_value("RECORD_NO_NAMECOLUMN", 400003),
		descriptor.def_enum_value("RECORD_TIMEOUT", 400004),
		//  relayserver������

		descriptor.def_enum_value("RELAY", 500000),
		//  ϵͳ����

		descriptor.def_enum_value("RELAY_LOGIN_SYSTEMERROR", 500001),
		//  ��Ч��gamesession

		descriptor.def_enum_value("RELAY_LOGIN_INVALIDSESSION", 500002),
		//  ��Ч�Ĳ�ս��

		descriptor.def_enum_value("RELAY_LOGIN_INVALIDFIGHTER", 500003),
		//  ϵͳ����

		descriptor.def_enum_value("RELAY_RECONNECT_SYSTEMERROR", 500004),
		//  ��һ�������

		descriptor.def_enum_value("RELAY_RECONNECT_PLAYER_ONLINE", 500005),
		//  ��Ч��gamesession

		descriptor.def_enum_value("RELAY_RECONNECT_INVALIDSESSION", 500006),
		//  ��Ч�Ĳ�ս��

		descriptor.def_enum_value("RELAY_RECONNECT_INVALIDFIGHTER", 500007),
		//  ƥ�����

		descriptor.def_enum_value("MATCH", 600000),
		//  ϵͳ����

		descriptor.def_enum_value("MATCH_START_SYSTEMERROR", 600001),
		//  �Ѿ���ƥ������

		descriptor.def_enum_value("MATCH_START_REPEAT", 600002),
		//  ƥ��ʧ�ܣ���ʱ

		descriptor.def_enum_value("MATCH_TIMEOUT", 600003),
		//  ����PK׼������

		descriptor.def_enum_value("MATCH_START_NOT_IN_PK_PARPARE", 600004),
		//  ���״̬����ƥ��

		descriptor.def_enum_value("MATCH_START_IN_TEAM", 600005),
		//  δ����������

		descriptor.def_enum_value("MATCH_START_WUDAO_NOT_JOIN", 600006),
		//  �������Ѿ����

		descriptor.def_enum_value("MATCH_START_WUDAO_COMPLETE", 600007),
		//  ����ƥ���б���

		descriptor.def_enum_value("MATCH_CANCLE_NOT_MATCHING", 600008),
		//  ����Ѿ�����Ϸ����

		descriptor.def_enum_value("MATCH_CANCLE_RACING", 600009),
		//  �������

		descriptor.def_enum_value("SKILL", 700000),
		//  ERROR

		descriptor.def_enum_value("SKILL_ERROR", 700001),
		//  ���浽���ݿ�ʧ��

		descriptor.def_enum_value("SKILL_SAVE_DB_ERROR", 700002),
		//  û���������

		descriptor.def_enum_value("SKILL_NOT_FOUNT", 700003),
		//  ����ļ�������

		descriptor.def_enum_value("SKILL_TYPE_ERROR", 700004),
		//  SP����

		descriptor.def_enum_value("SKILL_SP_NOT_ENOUGH", 700005),
		//  �Ƴ�SPʧ��

		descriptor.def_enum_value("SKILL_SP_REMOVE_ERROR", 700006),
		//  �������ȼ�

		descriptor.def_enum_value("SKILL_MAX_SKILL_LEVEL", 700007),
		//  ְҵ���Ϸ�

		descriptor.def_enum_value("SKILL_OCCU_ERROR", 700008),
		//  �����ҵȼ�

		descriptor.def_enum_value("SKILL_PLAYER_LEVEL", 700009),
		//  ǰ�ü��ܴ���

		descriptor.def_enum_value("SKILL_NEED_SKILL_ERROR", 700010),
		//  û����Ҫ����Ʒ��BUFF

		descriptor.def_enum_value("SKILL_NEED_ITEM_ERROR", 700011),
		//  ���ü��ܴ���

		descriptor.def_enum_value("SKILL_NEXT_SKILL_ERROR", 700012),
		//  ������С�ȼ�

		descriptor.def_enum_value("SKILL_MIN_SKILL_LEVEL", 700013),
		//  �������

		descriptor.def_enum_value("SETTING", 800000),
		//  ERROR

		descriptor.def_enum_value("SETTING_ERROR", 800001),
		//  ��������

		descriptor.def_enum_value("SETTING_INDEX_ERROR", 800002),
		//  ��λ��������

		descriptor.def_enum_value("SETTING_SLOT_ERROR", 800003),
		//  �����ظ�

		descriptor.def_enum_value("SETTING_SKILL_REPEAT", 800004),
		//  ���ܲ�����

		descriptor.def_enum_value("SETTING_SKILL_ERROR", 800005),
		//  ���³����

		descriptor.def_enum_value("DUNGEON", 900000),
		//  ��������ʧ��

		descriptor.def_enum_value("DUNGEON_START_CREATE_RACE_FAILED", 900001),
		//  ���³ǲ�����

		descriptor.def_enum_value("DUNGEON_START_DUNGEON_NOT_EXIST", 900002),
		//  δ�ﵽ�ȼ�Ҫ��

		descriptor.def_enum_value("DUNGEON_START_LEVEL_LIMIT", 900003),
		//  û��ƣ����

		descriptor.def_enum_value("DUNGEON_START_NO_FATIGUE", 900004),
		//  ���������������ǰ������ǰ�ùؿ��ȣ�

		descriptor.def_enum_value("DUNGEON_START_CONDITION", 900005),
		//  �Ѷ�δ����

		descriptor.def_enum_value("DUNGEON_START_HARD_NOT_OPEN", 900006),
		//  ����ѡ��ؿ��ĳ���

		descriptor.def_enum_value("DUNGEON_START_NOT_IN_ENTRY_SCENE", 900007),
		//  ��ʼ����ʧ��

		descriptor.def_enum_value("DUNGEON_START_RACE_FAILED", 900008),
		//  ��Ʊ����

		descriptor.def_enum_value("DUNGEON_START_NO_TICKET", 900009),
		//  û����Ԩģʽ

		descriptor.def_enum_value("DUNGEON_START_NO_HELL_MODE", 900010),
		//  û���㹻����ԨƱ

		descriptor.def_enum_value("DUNGEON_START_NO_HELL_TICKET", 900011),
		//  �����Ա������

		descriptor.def_enum_value("DUNGEON_START_TEAM_MEMBER_OFFLINE", 900012),
		//  ��������λ�ò���

		descriptor.def_enum_value("DUNGEON_START_BAG_FULL", 900013),
		//  ���ڿ���ʱ��

		descriptor.def_enum_value("DUNGEON_START_NOT_OPEN_TIME", 900014),
		//  ��������

		descriptor.def_enum_value("DUNGEON_START_NO_TIMES", 900015),
		//  ϵͳ����

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_SYSTEM_ERROR", 900016),
		//  �Ѿ��뿪���³���

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_NOT_IN_DUNGEON", 900017),
		//  �ظ�����

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_REPEAT", 900018),
		//  ���벻���ڵ�����

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_NOT_EXIST", 900019),
		//  �����Ŀ�겻����

		descriptor.def_enum_value("DUNGEON_REVIVE_PLAYER_NOT_EXIST", 900020),
		//  �ظ�����

		descriptor.def_enum_value("DUNGEON_REVIVE_REPEAT", 900021),
		//  û���㹻�ĸ����

		descriptor.def_enum_value("DUNGEON_REVIVE_NOT_ENOUGH_REVIVE_COIN", 900022),
		//  ��ʼ�ؿ�ƥ��ʧ��

		descriptor.def_enum_value("DUNGEON_MATCH_START_FAILED", 900023),
		//  �ظ���ʼ���³�

		descriptor.def_enum_value("DUNGEON_TEAM_START_VOTE_REPEAT", 900024),
		//  ���³ǲ�����ӿ�ʼ

		descriptor.def_enum_value("DUNGEON_TEAM_TARGET_MUST_SINGLE", 900025),
		//  �������³��������

		descriptor.def_enum_value("DUNGEON_TEAM_TOO_MANY_MEMBER", 900026),
		//  �������㣬�޷���ʼ���³�

		descriptor.def_enum_value("DUNGEON_TEAM_NOT_ENOUGH_MEMBER", 900027),
		//  �ȴ�������ͶƱ

		descriptor.def_enum_value("DUNGEON_TEAM_WAIT_OTHER_VOTE", 900028),
		//  �޷��������

		descriptor.def_enum_value("DUNGEON_TIMES_CANT_BUY", 900029),
		//  �޷����������ʣ���������

		descriptor.def_enum_value("DUNGEON_TIMES_NO_REMAIN_TIMES", 900030),
		//  �޷����������Ǯ����

		descriptor.def_enum_value("DUNGEON_TIMES_NO_ENOUGH_MONEY", 900031),
		//  ��ʼ����ʧ�ܣ���������²���Ҫ��ʾ

		descriptor.def_enum_value("DUNGEON_TEAM_START_RACE_FAILED", 901001),
		//  �������

		descriptor.def_enum_value("ITEM", 1000000),
		//  ���ݷǷ�,����������ؿ�ָ���ж�

		descriptor.def_enum_value("ITEM_DATA_INVALID", 1000001),
		//  û�в�������

		descriptor.def_enum_value("ITEM_NO_REASON", 1000002),
		//  item�����Ƿ�

		descriptor.def_enum_value("ITEM_NUM_INVALID", 1000003),
		//  ���item������

		descriptor.def_enum_value("ITEM_ADD_PACK_FULL", 1000004),
		//  ��Ǯ��Ӵﵽ����

		descriptor.def_enum_value("ITEM_MONEY_ADD_FULL", 1000005),
		//  ʹ�õ���ʧ��

		descriptor.def_enum_value("ITEM_USE_FAIL", 1000006),
		//  ����װ��

		descriptor.def_enum_value("ITEM_CAN_NOT_EQUIP", 1000007),
		//  װ������

		descriptor.def_enum_value("ITEM_LOCKED", 1000008),
		//  װ�������İ�������

		descriptor.def_enum_value("ITEM_PACK_INVALID", 1000009),
		//  �������Ӵﵽ����

		descriptor.def_enum_value("ITEM_PACKSIZE_MAX", 1000010),
		//  ����������

		descriptor.def_enum_value("ITEM_TYPE_INVALID", 1000011),
		//  ���߷ֽ�ʧ��

		descriptor.def_enum_value("ITEM_DECOMPOSE_FAIL", 1000012),
		//  װ��ǿ���ȼ�����

		descriptor.def_enum_value("ITEM_STRENTH_LV_INVALID", 1000013),
		//  ��Ҳ���

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_GOLD", 1000014),
		//  ���ϲ���

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_MAT", 1000015),
		//  װ��ǿ��ʧ���޳ͷ�

		descriptor.def_enum_value("ITEM_STRENTH_FAIL", 1000016),
		//  װ��ǿ��ʧ�ܿ۵ȼ�

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_MINUS", 1000017),
		//  װ��ǿ��ʧ�ܵȼ�����

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_ZERO", 1000018),
		//  װ��ǿ��ʧ������

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_BROKE", 1000019),
		//  ��ֿ�ռ�����

		descriptor.def_enum_value("ITEM_PUSH_STORAGE_FULL", 1000020),
		//  ��ȡ�ֿ���������

		descriptor.def_enum_value("ITEM_STORAGE_NUM_ERR", 1000021),
		//  װ��ְҵ����

		descriptor.def_enum_value("ITEM_EQUIP_OCCU", 1000022),
		//  װ���ȼ�����

		descriptor.def_enum_value("ITEM_EQUIP_LV", 1000023),
		//  װ��ǿ��ʧ�ܿ�2��

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_TWO", 1000024),
		//  װ��ǿ��ʧ�ܿ�2��

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_THREE", 1000025),
		//  װ��ǿ��ʧ�ܿ�4��

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_FOUR", 1000026),
		//  ��ȯ����

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_POINT", 1000027),
		//  ǿ�����ʹ���(�ƺ�)addedbyhuchenhui2016.06.30

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_TITLE", 1000028),
		//  װ�����ֽܷ�

		descriptor.def_enum_value("ITEM_CNA_NOT_DECOMPOSE", 1000029),
		//  ����ʹ��CD��

		descriptor.def_enum_value("ITEM_USE_CD", 1000030),
		//  ��װ�����ﵽ����

		descriptor.def_enum_value("ITEM_SEAL_COUNT_MAX", 1000031),
		//  װ���Ѿ��Ƿ�װ��

		descriptor.def_enum_value("ITEM_ALREADY_SEAL", 1000032),
		//  װ����װƷ�ʲ���

		descriptor.def_enum_value("ITEM_SEAL_QUALITY_ERR", 1000033),
		//  ����֮�겻��

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_WARRIOR_SOUL", 1000034),
		//  �����Ҳ���

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_PKCOIN", 1000035),
		//  ��ħ��λ����

		descriptor.def_enum_value("ITEM_ADDMAGIC_PART_ERR", 1000036),
		//  ��ħ���ϳ�Ʒ�ʲ�ͬ

		descriptor.def_enum_value("ITEM_MAGCARD_COMP_DIF_COLOR", 1000037),
		//  һ���ֽ�����ȼ�����

		descriptor.def_enum_value("ITEM_ONEKEY_DECOMPOSE_LV_NOT_ENOUGH", 1000038),
		//  �������ս�Ǯ��������

		descriptor.def_enum_value("ITEM_OPEN_JAR_DAYCOUNT", 1000039),
		//  ���ܳ���

		descriptor.def_enum_value("ITEM_NOT_SELL", 1000040),
		//  ������Ʒ������

		descriptor.def_enum_value("ITEM_SELL_ITEM_NOT_EXIST", 1000041),
		//  ���ṱ�ײ���

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_GUILD_CONTRI", 1000042),
		//  ʹ�õ���buff�Ѿ�����

		descriptor.def_enum_value("ITEM_USE_BUFFALREADYEXIST", 1000043),
		//  ���Ҳ���

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_MONEY", 1000044),
		//  ǿ��ȯ�ȼ�����

		descriptor.def_enum_value("ITEM_STRTICKET_LV_ERR", 1000045),
		//  ǿ��ȯ�۳�ʧ��

		descriptor.def_enum_value("ITEM_STRTICKET_REDUCE_ERR", 1000046),
		//  ������ʹ�ô�������

		descriptor.def_enum_value("ITEM_DAYUSENUM", 1000047),
		//  ǿ��ȯǿ��ʧ��

		descriptor.def_enum_value("ITEM_SPECIAL_STRENTH_FAIL", 1000048),
		//  errcode49

		descriptor.def_enum_value("ITEM_ERRCODE_49", 1000049),
		//  errcode50

		descriptor.def_enum_value("ITEM_ERRCODE_50", 1000050),
		//  errcode51

		descriptor.def_enum_value("ITEM_ERRCODE_51", 1000051),
		//  errcode52

		descriptor.def_enum_value("ITEM_ERRCODE_52", 1000052),
		//  errcode53

		descriptor.def_enum_value("ITEM_ERRCODE_53", 1000053),
		//  ���³ǲ���ʹ�øõ���

		descriptor.def_enum_value("ITEM_CAN_NOT_USE_IN_DUNGEON", 1000054),
		//  �����ڲ���ʹ�øõ���

		descriptor.def_enum_value("ITEM_CAN_NOT_USE_IN_TOWN", 1000055),
		//  ���߷���

		descriptor.def_enum_value("ITEM_ABANDON", 1000056),
		//  �̵����

		descriptor.def_enum_value("SHOP", 1100000),
		//  �̵��ѯ����

		descriptor.def_enum_value("SHOP_QUERY_ERR", 1100001),
		//  �̵�ˢ�´���

		descriptor.def_enum_value("SHOP_REFRESH_ERR", 1100002),
		//  �̵깺�����

		descriptor.def_enum_value("SHOP_BUY_ERR", 1100003),
		//  �̵깺���Ҳ���

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_GOLD", 1100004),
		//  �̵깺���ȯ����

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_POINT", 1100005),
		//  �̵깺����߲���

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_ITEM", 1100006),
		//  �̵깺�򱳰��ռ䲻��

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_PACKSIZE", 1100007),
		//  �̵깺������

		descriptor.def_enum_value("SHOP_BUY_SALE_OUT", 1100008),
		//  �̵�ˢ�µ�ȯ����

		descriptor.def_enum_value("SHOP_REFRESH_NOT_ENOUGH_MONEY", 1100009),
		//  ��������������

		descriptor.def_enum_value("SHOP_NOT_ENOUGH_TOWER_LEVEL", 1100010),
		//  �Ƕ������ֲ���

		descriptor.def_enum_value("SHOP_NOT_ENOUGH_DUEL_POINT", 1100011),
		//  �̵�ˢ�´�������

		descriptor.def_enum_value("SHOP_REFRESH_COUNT", 1100012),
		//  �����̵겻����

		descriptor.def_enum_value("SHOP_GUIlD_SHOP_NOT_EXIST", 1100013),
		//  �����̵�ȼ�����

		descriptor.def_enum_value("SHOP_GUIlD_NOT_ENOUGH_LV", 1100014),
		//  �ʼ����

		descriptor.def_enum_value("MAIL", 1200000),
		//  �ʼ�ϵͳ����

		descriptor.def_enum_value("MAIL_ERROR", 1200001),
		//  �������

		descriptor.def_enum_value("MAIL_TITLE_ERROR", 1200002),
		//  ���ⳤ�ȴ���

		descriptor.def_enum_value("MAIL_TITLE_LENGTH_ERROR", 1200003),
		//  ���ݴ���

		descriptor.def_enum_value("MAIL_CONTENT_ERROR", 1200004),
		//  ���ݳ��ȴ���

		descriptor.def_enum_value("MAIL_CONTENT_LENGTH_ERROR", 1200005),
		//  �������ַ�������

		descriptor.def_enum_value("MAIL_SENDER_NAME_ERROR", 1200006),
		//  �������ַ������ȴ���

		descriptor.def_enum_value("MAIL_SENDER_NAME_LENGTH_ERROR", 1200007),
		//  ��������

		descriptor.def_enum_value("MAIL_REWARD_ERROR", 1200008),
		//  ������

		descriptor.def_enum_value("TEAM", 1300000),
		//  ���ϵͳ����

		descriptor.def_enum_value("TEAM_ERROR", 1300001),
		//  �������飬�Ѿ��ж�����

		descriptor.def_enum_value("TEAM_CREATE_TEAM_HAS_TEAM", 1300002),
		//  �������飬��Ч�Ķ���Ŀ��

		descriptor.def_enum_value("TEAM_CREATE_TEAM_INVALID_TARGET", 1300003),
		//  ������飬��ʱ

		descriptor.def_enum_value("TEAM_JOIN_TIMEOUT", 1300004),
		//  ������飬���鲻����

		descriptor.def_enum_value("TEAM_JOIN_TEAM_UNEXIST", 1300005),
		//  ������飬������

		descriptor.def_enum_value("TEAM_JOIN_TEAM_FULL", 1300006),
		//  ������飬�ӳ�����

		descriptor.def_enum_value("TEAM_JOIN_TEAM_MASTER_OFFLINE", 1300007),
		//  ������飬�Ѿ��ж�����

		descriptor.def_enum_value("TEAM_JOIN_TEAM_HAS_TEAM", 1300008),
		//  ������飬�������

		descriptor.def_enum_value("TEAM_JOIN_TEAM_PASSWD_ERROR", 1300009),
		//  ������飬����������

		descriptor.def_enum_value("TEAM_JOIN_TEAM_HAS_PASSWD", 1300010),
		//  ������飬�ȼ�����

		descriptor.def_enum_value("TEAM_JOIN_LEVEL_LIMIT", 1300011),
		//  ���볤�Ȳ���

		descriptor.def_enum_value("TEAM_PASSWD_ERROR_LENGTH", 1300012),
		//  ����ֻ��������

		descriptor.def_enum_value("TEAM_PASSWD_ONLY_NUM", 1300013),
		//  ����̫��

		descriptor.def_enum_value("TEAM_NAME_TOO_LONG", 1300014),
		//  ��Ч������

		descriptor.def_enum_value("TEAM_NAME_INVALID", 1300015),
		//  ��Ч��Ŀ��

		descriptor.def_enum_value("TEAM_TARGET_INVALID", 1300016),
		//  �л�Ŀ��ʧ�ܣ�����̫��

		descriptor.def_enum_value("TEAM_TOO_MANY_PLAYER", 1300017),
		//  ���������ߣ��㲻�Ƕӳ�

		descriptor.def_enum_value("TEAM_REPLY_NOT_MASTER", 1300018),
		//  ���������ߣ���Ҳ�����

		descriptor.def_enum_value("TEAM_REPLY_PLAYER_OFFLINE", 1300019),
		//  ���������ߣ������δ�������

		descriptor.def_enum_value("TEAM_REPLY_PLAYER_INVALID", 1300020),
		//  ���������ߣ���������

		descriptor.def_enum_value("TEAM_REPLY_TEAM_FULL", 1300021),
		//  ������ң��Լ�û�ж���

		descriptor.def_enum_value("TEAM_INVITE_NO_TEAM", 1300022),
		//  ������ң��Լ����Ƕӳ�

		descriptor.def_enum_value("TEAM_INVITE_NOT_TEAM_MASTER", 1300023),
		//  ������ң���������

		descriptor.def_enum_value("TEAM_INVITE_TEAM_FULL", 1300024),
		//  ������ң���������ս����

		descriptor.def_enum_value("TEAM_INVITE_TEAM_IN_RACE", 1300025),
		//  ������ң��Է�������

		descriptor.def_enum_value("TEAM_INVITE_TARGET_OFFLINE", 1300026),
		//  ������ң��Է��Ѿ��ڶ�����

		descriptor.def_enum_value("TEAM_INVITE_TARGET_IN_TEAM", 1300027),
		//  ������ң�Ŀ����æ

		descriptor.def_enum_value("TEAM_INVITE_TARGET_BUSY", 1300028),
		//  ������ң��ظ�����

		descriptor.def_enum_value("TEAM_INVITE_REPEAT", 1300029),
		//  ������飬��������ս����

		descriptor.def_enum_value("TEAM_JOIN_RACING", 1300030),
		//  �ȼ�����

		descriptor.def_enum_value("TEAM_MIN_LEVEL", 1300031),
		//  ������ң��Է��ȼ�����

		descriptor.def_enum_value("TEAM_INVITE_TARGET_MIN_LEVEL", 1300032),
		//  ������ң�̫Ƶ��

		descriptor.def_enum_value("TEAM_INVITE_FREQUENTLY", 1300033),
		//  ��ʼƥ��ʧ�ܣ������������Ҫ��ʾ

		descriptor.def_enum_value("TEAM_MATCH_START_FAILED", 1301001),
		//  ֻ�жӳ��ܲ���

		descriptor.def_enum_value("TEAM_MATCH_ONLY_MASTER", 1301002),
		//  ��ʼƥ��ʧ�ܣ��Ѿ���ƥ����

		descriptor.def_enum_value("TEAM_MATCH_START_IN_MATCHING", 1301003),
		//  ȡ��ƥ��ʧ�ܣ�����ƥ����

		descriptor.def_enum_value("TEAM_MATCH_CANCEL_NOT_IN_MATCHING", 1301004),
		//  ��Ԫʯ���

		descriptor.def_enum_value("WARPSTONE", 1400000),
		//  ���Ҳ���

		descriptor.def_enum_value("WARP_STONE_SILVER_ERROR", 1400001),
		//  û�н���

		descriptor.def_enum_value("WARP_STONE_UNLOCK_ERROR", 1400002),
		//  �������ȼ�

		descriptor.def_enum_value("WARP_STONE_LEVEL_MAX", 1400003),
		//  ��Ԫʯû�ҵ�

		descriptor.def_enum_value("WARP_STONE_NOT_FOUNT", 1400004),
		//  ��Ԫʯ�����ȼ�����

		descriptor.def_enum_value("WARP_STONE_PLAYER_LEVEL_ERROR", 1400005),
		//  ����ʯû���ҵ�

		descriptor.def_enum_value("ENERGY_STONE_NOT_FOUNT", 1400006),
		//  ����ʯ����

		descriptor.def_enum_value("ENERGY_STONE_NOT_ENOUGH", 1400007),
		//  ����ʯ���ʹ���

		descriptor.def_enum_value("ENERGY_STONE_TYPE_ERROR", 1400008),
		//  ������

		descriptor.def_enum_value("RETINUE", 1500000),
		//  û�ж�Ӧ�����

		descriptor.def_enum_value("RETINUE_NOT_PLAYER", 1500001),
		//  ������ݱ�����

		descriptor.def_enum_value("RETINUE_DATA_NOT_EXIST", 1500002),
		//  ��Ӳ�����

		descriptor.def_enum_value("RETINUE_NOT_EXIST", 1500003),
		//  ����Ѿ�����

		descriptor.def_enum_value("RETINUE_IS_EXIST", 1500004),
		//  ��ҵȼ�����

		descriptor.def_enum_value("RETINUE_PLAYER_LEVEL", 1500005),
		//  ϴ����Ʒ����

		descriptor.def_enum_value("RETINUE_NOT_ITEM", 1500006),
		//  ������Ʒ����

		descriptor.def_enum_value("RETINUE_UNLOCK_NOT_ITEM", 1500007),
		//  ��ӵȼ�������.

		descriptor.def_enum_value("RETINUE_LEVEL_DATA_NOT_EXIST", 1500008),
		//  ������Ʒ����

		descriptor.def_enum_value("RETINUE_LEVEL_NOT_ITEM", 1500009),
		//  �������λ�ô���

		descriptor.def_enum_value("RETINUE_RETINUE_INDEX_ERROR", 1500010),
		//  ��ʿ֮�겻��

		descriptor.def_enum_value("RETINUE_WARRIOR_SOUL_ERROR", 1500011),
		//  ���ܳ�������Ǽ�

		descriptor.def_enum_value("RETINUE_MAX_STAR_ERROR", 1500012),
		//  û������Ǽ�

		descriptor.def_enum_value("RETINUE_STAR_LEVEL_NOT_EXIST", 1500013),
		//  ������Ƭ����

		descriptor.def_enum_value("RETINUE_UP_STAR_NOT_ITEM", 1500014),
		//  û�п�ϴ���ļ���

		descriptor.def_enum_value("RETINUE_NOT_CHANGE_SKILL_ERROR", 1500015),
		//  û�ж�Ӧ��ϴ����

		descriptor.def_enum_value("RETINUE_NOT_SKILL_GROUP_ERROR", 1500016),
		//  ϴ������һ����

		descriptor.def_enum_value("RETINUE_SKILL_GROUP_RING_ERROR", 1500017),
		//  �������Ͳ���ȷ

		descriptor.def_enum_value("RETINUE_UP_TYPE_ERROR", 1500018),
		//  û�������

		descriptor.def_enum_value("RETINUE_NOT_MAIN_ERROR", 1500019),
		//  �޷��������

		descriptor.def_enum_value("RETINUE_NOT_DOWN_ERROR", 1500020),
		//  ����

		descriptor.def_enum_value("RECONNECT", 1600000),
		//  ��ɫ�����Ѿ�ɾ��

		descriptor.def_enum_value("RECONNECT_PLAYER_DELETED", 1600001),
		//  ��Ч��sequence

		descriptor.def_enum_value("RECONNECT_INVALID_SEQUENCE", 1600002),
		//  �˺Ż�����

		descriptor.def_enum_value("RECONNECT_PLAYER_ONLINE", 1600003),
		//  ���������

		descriptor.def_enum_value("RECONNECT_NO_CONNECTION", 1600004),
		//  �̳�

		descriptor.def_enum_value("MALL", 1700000),
		//  �̳���Ʒ��ѯʧ��

		descriptor.def_enum_value("MALL_QUERY_FAIL", 1700001),
		//  ������������

		descriptor.def_enum_value("MALL_BUYNUM_ERR", 1700002),
		//  �Ҳ���Ҫ�������Ʒ

		descriptor.def_enum_value("MALL_CANNOT_FIND_ITEM", 1700003),
		//  �Ҳ���Ҫ��������ʱ���

		descriptor.def_enum_value("MALL_CANNOT_FIND_GIFT_PACK", 1700004),
		//  �̳���ʱ����Ѵ���

		descriptor.def_enum_value("MALL_GIFT_PACK_ACTIVATED", 1700005),
		//  ������

		descriptor.def_enum_value("PLAYER", 1800000),
		//  תְ�ȼ�����

		descriptor.def_enum_value("PLAYER_TRANSFORM_OCCU_LEVEL_ERROR", 1800001),
		//  ���ѵȼ�����

		descriptor.def_enum_value("PLAYER_AWAKEN_LEVEL_ERROR", 1800002),
		//  �Ѿ�����

		descriptor.def_enum_value("PLAYER_AWAKEN_EXIST", 1800003),
		//  ��δתְ

		descriptor.def_enum_value("PLAYER_AWAKEN_NOT_TRANSFORM_OCCU", 1800004),
		//  vip����ʱ,vip�ȼ�����

		descriptor.def_enum_value("PLAYER_VIP_BUY_LEVEL_ERROR", 1800005),
		//  vip�������,�����

		descriptor.def_enum_value("PLAYER_VIP_BUY_GIFT_ENOUGH_POINT", 1800006),
		//  vip���Ϊ��

		descriptor.def_enum_value("PLAYER_VIP_GIFT_EMPTY", 1800007),
		//  vip������������ռ䲻��

		descriptor.def_enum_value("PLAYER_VIP_BUY_NOT_ENOUGH_PACKSIZE", 1800008),
		//  vip����������ĵ��ʧ��

		descriptor.def_enum_value("PLAYER_VIP_BUY_REMOVE_POINT_ERROR", 1800009),
		//  vip�Ѿ�����������

		descriptor.def_enum_value("PLAYER_VIP_BUY_ALREADY", 1800010),
		//  vip�ȼ�����

		descriptor.def_enum_value("PLAYER_VIPLV_NOT_ENOUGH", 1800011),
		//  ���ٹ���

		descriptor.def_enum_value("QUICKBUY", 1900000),
		//  ϵͳ����

		descriptor.def_enum_value("QUICK_BUY_SYSTEM_ERROR", 1900001),
		//  ��һ������û����

		descriptor.def_enum_value("QUICK_BUY_LAST_TRANS_NOT_FINISH", 1900002),
		//  ��ʱ

		descriptor.def_enum_value("QUICK_BUY_TIMEOUT", 1900003),
		//  ��Ч������

		descriptor.def_enum_value("QUICK_BUY_INVALID_TYPE", 1900004),
		//  Ǯ����

		descriptor.def_enum_value("QUICK_BUY_NOT_ENOUGH_MONEY", 1900005),
		//  ���߲�����

		descriptor.def_enum_value("QUICK_BUY_INVALID_ITEM", 1900006),
		//  ������������ȷ

		descriptor.def_enum_value("QUICK_BUY_INVALID_NUM", 1900007),
		//  �����ռ䲻��

		descriptor.def_enum_value("QUICK_BUY_BAG_FULL", 1900008),
		//  ���ڱ�����

		descriptor.def_enum_value("QUICK_BUY_REVIVE_NOT_IN_RACE", 1900009),
		//  �������

		descriptor.def_enum_value("TASK", 2000000),
		//  �ύ������Ʒ���ʹ���

		descriptor.def_enum_value("TASK_SET_ITEM_TASK_TYPE_ERROR", 2000001),
		//  �ύ�����������Ʒ

		descriptor.def_enum_value("TASK_SET_ITEM_ERROR", 2000002),
		//  �ύ��������Ʒ��������

		descriptor.def_enum_value("TASK_SET_ITEM_NUM_ERROR", 2000003),
		//  ���񲻴���

		descriptor.def_enum_value("TASK_NOT_EXIST", 2000004),
		//  ����ű�������

		descriptor.def_enum_value("TASK_SCRIPT_NOT_EXIST", 2000005),
		//  �����ٽ�ȡ״̬

		descriptor.def_enum_value("TASK_NOT_UNFINISH", 2000006),
		//  �������ʹ���

		descriptor.def_enum_value("TASK_TYPE_ERROR", 2000007),
		//  ѭ�����񲻴���

		descriptor.def_enum_value("TASK_CYCLE_NOT_EXIST", 2000008),
		//  ������Դ����

		descriptor.def_enum_value("TASK_CYCLE_REFRESH_NOT_CONSUME", 2000009),
		//  ÿ��������ֽ������Ӳ�����

		descriptor.def_enum_value("TASK_DATILY_TASK_SCORE_BOX_NOT_FOUNT", 2000010),
		//  ÿ��������ֽ������ֲ���

		descriptor.def_enum_value("TASK_DATILY_TASK_SCORE_BOX_SCORE", 2000011),
		//  ÿ��������ֽ����Ѿ���ȡ

		descriptor.def_enum_value("TASK_DATILY_TASK_SCORE_BOX_RECEIVE", 2000012),
		//  ����֮��

		descriptor.def_enum_value("TOWER", 2100000),
		//  û�����ô���

		descriptor.def_enum_value("TOWER_RESET_NO_REMAIN_COUNT", 2100001),
		//  ����ɨ����

		descriptor.def_enum_value("TOWER_DOING_WIPEOUT", 2100002),
		//  û�в���ȥɨ��

		descriptor.def_enum_value("TOWER_NO_FLOOR_WIPEOUT", 2100003),
		//  û����ɨ����

		descriptor.def_enum_value("TOWER_NOT_DOING_WIPEOUT", 2100004),
		//  ɨ��δ���

		descriptor.def_enum_value("TOWER_WIPEOUT_NOT_FINISH", 2100005),
		//  ɨ�������

		descriptor.def_enum_value("TOWER_WIPEOUT_FINISHED", 2100006),
		//  û���㹻�ĵㄻ

		descriptor.def_enum_value("TOWER_WIPEOUT_NOT_ENOUGH_POINT", 2100007),
		//  δͨ���ò�

		descriptor.def_enum_value("TOWER_AWARD_NOT_PASS_FLOOR", 2100008),
		//  ��Ч�Ĳ�����û�ж�Ӧ����

		descriptor.def_enum_value("TOWER_AWARD_INVALID_FLOOR", 2100009),
		//  �ظ��콱

		descriptor.def_enum_value("TOWER_AWARD_REPEAT_RECEIVE", 2100010),
		//  ����Ҫ����

		descriptor.def_enum_value("TOWER_NO_NEED_RESET", 2100011),
		//  û��VIPȨ��

		descriptor.def_enum_value("TOWER_RESET_NO_VIP_PRIVILEGE", 2100012),
		//  PK���

		descriptor.def_enum_value("PK", 2200000),
		//  �����

		descriptor.def_enum_value("PK_CHALLENGE_IN_TEAM", 2200001),
		//  ����PK׼������

		descriptor.def_enum_value("PK_CHALLENGE_NOT_IN_PK_PREPARE", 2200002),
		//  Ŀ����æ

		descriptor.def_enum_value("PK_CHALLENGE_TARGET_BUSY", 2200003),
		//  Ŀ�겻����

		descriptor.def_enum_value("PK_CHALLENGE_TARGET_NOT_ONLINE", 2200004),
		//  �ظ���ս

		descriptor.def_enum_value("PK_CHALLENGE_REPEAT", 2200005),
		//  �ȼ�̫��

		descriptor.def_enum_value("PK_CHALLENGE_LEVEL_LIMIT", 2200006),
		//  ϵͳ����

		descriptor.def_enum_value("PK_WUDAO_SYSTEM_ERROR", 2200007),
		//  �δ��ʼ

		descriptor.def_enum_value("PK_WUDAO_ACTIVITY_NOT_OPEN", 2200008),
		//  ��������������

		descriptor.def_enum_value("PK_WUDAO_ACTIVITY_COND", 2200009),
		//  û����Ʊ

		descriptor.def_enum_value("PK_WUDAO_NO_TICKET", 2200010),
		//  �Ѿ��μ���

		descriptor.def_enum_value("PK_WUDAO_JOINED", 2200011),
		//  ������δ���

		descriptor.def_enum_value("PK_WUDAO_NOT_COMPLETE", 2200012),
		//  ����

		descriptor.def_enum_value("GUILD", 2300000),
		//  û�ж�Ӧ��Ȩ��

		descriptor.def_enum_value("GUILD_NO_POWER", 2300001),
		//  ��������

		descriptor.def_enum_value("GUILD_FULL", 2300002),
		//  ���ڹ�����

		descriptor.def_enum_value("GUILD_NOT_IN_GUILD", 2300003),
		//  ϵͳ����

		descriptor.def_enum_value("GUILD_SYS_ERROR", 2300004),
		//  û���㹻��Ǯ

		descriptor.def_enum_value("GUILD_NOT_ENOUGH_MONEY", 2300005),
		//  ��������

		descriptor.def_enum_value("GUILD_NOT_ENOUGH_TIMES", 2300006),
		//  ����ս�ڼ䲻���뿪����

		descriptor.def_enum_value("GUILD_BATTLE_NOT_LEAVE", 2300007),
		//  �����ظ�

		descriptor.def_enum_value("GUILD_NAME_REPEAT", 2301001),
		//  ��������������

		descriptor.def_enum_value("GUILD_NAME_INVALID", 2301002),
		//  ��������������

		descriptor.def_enum_value("GUILD_DECLARATION_INVALID", 2301003),
		//  ��������������

		descriptor.def_enum_value("GUILD_ANNOUNCEMENT_INVALID", 2301004),
		//  ��������������

		descriptor.def_enum_value("GUILD_MAIL_INVALID", 2301005),
		//  �ظ�����

		descriptor.def_enum_value("GUILD_CREATE_REPEAT", 2302001),
		//  �Ѿ��ڹ�����

		descriptor.def_enum_value("GUILD_CREATE_ALREADY_HAS_GUILD", 2302002),
		//  ��Ч�Ĺ�����

		descriptor.def_enum_value("GUILD_CREATE_INVALID_NAME", 2302003),
		//  ��Ч�Ĺ�������

		descriptor.def_enum_value("GUILD_CREATE_INVALID_DECLARATION", 2302004),
		//  û���㹻��Ǯ

		descriptor.def_enum_value("GUILD_CREATE_NOT_ENOUGH_MONEY", 2302005),
		//  �ȼ�����

		descriptor.def_enum_value("GUILD_CREATE_MIN_LEVEL", 2302006),
		//  ���뿪���ᣬ������ȴʱ����

		descriptor.def_enum_value("GUILD_CREATE_COLDTIME", 2302007),
		//  ������Ϊ��

		descriptor.def_enum_value("GUILD_CREATE_NAME_EMPTY", 2302008),
		//  ��������Ϊ��

		descriptor.def_enum_value("GUILD_CREATE_DECLARATION_EMPTY", 2302009),
		//  �ظ�����

		descriptor.def_enum_value("GUILD_JOIN_REPEAT", 2303001),
		//  �Ѿ��ڹ�����

		descriptor.def_enum_value("GUILD_JOIN_ALREADY_HAS_GUILD", 2303002),
		//  �ȼ�����

		descriptor.def_enum_value("GUILD_JOIN_MIN_LEVEL", 2303003),
		//  ���᲻����

		descriptor.def_enum_value("GUILD_JOIN_NOT_EXIST", 2303004),
		//  ���뿪���ᣬ������ȴʱ����

		descriptor.def_enum_value("GUILD_JOIN_COLDTIME", 2303005),
		//  ���������б�����

		descriptor.def_enum_value("GUILD_JOIN_REQUEST_QUEUE_FULL", 2303006),
		//  �������ڽ�ɢ

		descriptor.def_enum_value("GUILD_JOIN_IN_DISMISS", 2303007),
		//  ��ת�û᳤

		descriptor.def_enum_value("GUILD_LEAVE_TRANSFER_LEADER", 2304001),
		//  û�����������

		descriptor.def_enum_value("GUILD_REPLY_REQUESTER_UNEXIST", 2305001),
		//  �Ѿ���������������

		descriptor.def_enum_value("GUILD_REPLY_IN_OTHER_GUILD", 2305002),
		//  ���뿪���ᣬ������ȴʱ����

		descriptor.def_enum_value("GUILD_REPLY_COLDTIME", 2305003),
		//  Ŀ��ְ����������

		descriptor.def_enum_value("GUILD_POST_FULL", 2306001),
		//  ��Ҫ�᳤����7�첻����

		descriptor.def_enum_value("GUILD_POST_LEADER_LEAVE_TIME", 2306002),
		//  �������ǵȼ������������ǵȼ�

		descriptor.def_enum_value("GUILD_BUILDING_UPGRADE_MAIN_FIRST", 2307001),
		//  �Ѿ�������

		descriptor.def_enum_value("GUILD_BUILDING_TOP_LEVEL", 2307002),
		//  ����ʽ���

		descriptor.def_enum_value("GUILD_BUILDING_NOT_ENOUGH_FUND", 2307003),
		//  ʣ���������

		descriptor.def_enum_value("GUILD_DONATE_NO_REMAIN_TIMES", 2308001),
		//  ����CD��

		descriptor.def_enum_value("GUILD_EXCHANGE_CD", 2309001),
		//  ʣ���������

		descriptor.def_enum_value("GUILD_EXCHANGE_NO_REMAIN_TIMES", 2309002),
		//  ���ײ���

		descriptor.def_enum_value("GUILD_EXCHANGE_NOT_ENOUGH_CONTRI", 2309003),
		//  �Ѿ�������ߵȼ�

		descriptor.def_enum_value("GUILD_SKILL_TOP_LEVEL", 2310001),
		//  ���ڽ�ɢ��

		descriptor.def_enum_value("GUILD_DISMISS_IN_DISMISS", 2311001),
		//  ���ڽ�ɢ��

		descriptor.def_enum_value("GUILD_NOT_IN_DISMISS", 2311002),
		//  Բ������

		descriptor.def_enum_value("GUILD_TABLE_FULL", 2312001),
		//  λ���Ѿ���ռ

		descriptor.def_enum_value("GUILD_TABLE_SEAT_HAS_PLAYER", 2312002),
		//  �Ѿ���λ������

		descriptor.def_enum_value("GUILD_TABLE_REPEAT", 2312003),
		//  ��Ч��λ��

		descriptor.def_enum_value("GUILD_TABLE_SEAT_INVALID", 2312004),
		//  Ĥ�����ʹ���

		descriptor.def_enum_value("GUILD_ORZ_INVALID_TYPE", 2313001),
		//  û�����VIPȨ��

		descriptor.def_enum_value("GUILD_ORZ_VIP_PRIVILEGE", 2313002),
		//  û���ҵ����

		descriptor.def_enum_value("GUILD_BATTLE_NOT_PLAYER", 2314001),
		//  ���û�й���

		descriptor.def_enum_value("GUILD_BATTLE_NOT_EXIST", 2314002),
		//  ��Ҳ��ǹ����Ա

		descriptor.def_enum_value("GUILD_BATTLE_NOT_IS_MEMBER", 2314003),
		//  ����ս���������Ҳ���

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_GUILD_NOT_FIND", 2314004),
		//  ��ұ���û��Ȩ��

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_NOT_POWER", 2314005),
		//  ����սû�п�ʼ����

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_NOT_ENROLL", 2314006),
		//  ����ս������������

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_FULL", 2314007),
		//  ����ս��������ȼ�����

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_GUILD_LEVEL", 2314008),
		//  ����ս����ռ����صȼ�̫��

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_LOW", 2314009),
		//  ����ս����ռ����صȼ�̫��

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_HIGH", 2314010),
		//  ����ս�����ظ�����

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_EXIST", 2314011),
		//  ����ս�������ڴ�������

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_TRANSACTION", 2314012),
		//  ��ز����ڻ��߹���û�б���

		descriptor.def_enum_value("GUILD_BATTLE_TERRITORY_NOT_EXIST", 2314013),
		//  ����û�б���

		descriptor.def_enum_value("GUILD_BATTLE_NOT_ENROLL", 2314014),
		//  ����ս�����Ѿ���ߴ���

		descriptor.def_enum_value("GUILD_BATTLE_INSPIRE_MAX_COUNT", 2314015),
		//  ����ս������߲���

		descriptor.def_enum_value("GUILD_BATTLE_INSPIRE_ITEM", 2314016),
		//  ����ս�������ڴ�������

		descriptor.def_enum_value("GUILD_BATTLE_INSPIRE_TRANSACTION", 2314017),
		//  ����ս��Աƥ���������

		descriptor.def_enum_value("GUILD_BATTLE_MEMBER_MATCH_COUNT", 2314018),
		//  ս�������Ҳ������

		descriptor.def_enum_value("GUILD_BATTLE_RACE_END_NOT_MEMBER", 2314019),
		//  ����ս�Ѿ�����

		descriptor.def_enum_value("GUILD_BATTLE_IS_END", 2314020),
		//  ��ȡ�����Ҳ������

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_NOT_MEMBER", 2314021),
		//  ��ȡ����û���ҵ�������

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_DATA_ERROR", 2314022),
		//  ��ȡ�������ֲ���

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_SCORE_ERROR", 2314023),
		//  �����Ѿ���ȡ

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_ALREADY", 2314024),
		//  ����ս��һ��ս��û�н���

		descriptor.def_enum_value("GUILD_BATTLE_RACE_NOT_END", 2314025),
		//  ����սƥ�����ڴ�������

		descriptor.def_enum_value("GUILD_BATTLE_MATCH_TRANSACTION", 2314026),
		//  ����ս�������ܽ�ɢ

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_NOT_DISMISS", 2314027),
		//  ����ս��ɢ�в��ܱ���

		descriptor.def_enum_value("GUILD_BATTLE_DISMISS_NOT_ENROLL", 2314028),
		//  ��������

		descriptor.def_enum_value("ITEM_TRANS", 2400000),
		//  ʧ��

		descriptor.def_enum_value("ITEM_TRANS_FAILED", 2400001),
		//  Ǯ����

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_MONEY", 2400002),
		//  ����Ҳ���

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_REVIVE_COIN", 2400003),
		//  ���߲���

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_ITEM", 2400004),
		//  ��������

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_TIMES", 2400005),
		//  ���

		descriptor.def_enum_value("RED_PACKET", 2500000),
		//  ϵͳ����

		descriptor.def_enum_value("RED_PACKET_SYS_ERROR", 2500001),
		//  ��Ч�ĺ��

		descriptor.def_enum_value("RED_PACKET_INVALID", 2500002),
		//  ���������

		descriptor.def_enum_value("RED_PACKET_NOT_EXIST", 2500003),
		//  ����������

		descriptor.def_enum_value("RED_PACKET_NOT_OWNER", 2500004),
		//  ����Ѿ�����ȥ��

		descriptor.def_enum_value("RED_PACKET_ALREADY_SEND", 2500005),
		//  �����������ڹ�����

		descriptor.def_enum_value("RED_PACKET_NOT_IN_GUILD", 2500006),
		//  ����޷���

		descriptor.def_enum_value("RED_PACKET_CANT_OPEN", 2500007),
		//  ����ѱ�����

		descriptor.def_enum_value("RED_PACKET_EMPTY", 2500008),
		//  �����������

		descriptor.def_enum_value("RED_PACKET_INVALID_NUM", 2500009),
		//  ������ִ���

		descriptor.def_enum_value("RED_PACKET_INVALID_NAME", 2500010),
		//  ��ֵ

		descriptor.def_enum_value("BILLING", 2600000),
		//  ��Ҳ�����

		descriptor.def_enum_value("BILLING_PLAYER_OFFLINE", 2600001),
		//  ���ﲻ����

		descriptor.def_enum_value("BILLING_GOODS_UNEXIST", 2600002),
		//  û�д�����

		descriptor.def_enum_value("BILLING_GOODS_NUM_LIMIT", 2600003),
		//  �¿�ʱ��δ���޷�����

		descriptor.def_enum_value("BILLING_GOODS_MONTH_CARD_CANT_BUY", 2600004),
	}
)

