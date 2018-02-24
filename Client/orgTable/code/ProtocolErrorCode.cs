using System;
using System.Text;

namespace Protocol
{
	public enum ProtoErrorCode
	{
		/// <summary>
		///  成功
		/// </summary>
		SUCCESS = 0,
		/// <summary>
		///  登录验证
		/// </summary>
		LOGIN = 100000,
		/// <summary>
		///  服务器未就绪
		/// </summary>
		LOGIN_SERVER_UNREADY = 100001,
		/// <summary>
		///  未知账号，账号名错误
		/// </summary>
		LOGIN_UNKNOW_ACCOUNT = 100002,
		/// <summary>
		///  重复登录
		/// </summary>
		LOGIN_REPEAT = 100003,
		/// <summary>
		///  密码错
		/// </summary>
		LOGIN_WRONG_PASSWD = 100004,
		/// <summary>
		///  验证超时
		/// </summary>
		LOGIN_VERIFY_TIMEOUT = 100005,
		/// <summary>
		///  服务器繁忙
		/// </summary>
		LOGIN_SERVER_BUSY = 100006,
		/// <summary>
		///  版本号错误
		/// </summary>
		LOGIN_ERROR_VERSION = 100007,
		/// <summary>
		///  封号
		/// </summary>
		LOGIN_FORBID_LOGIN = 100008,
		/// <summary>
		///  数据库错误
		/// </summary>
		LOGIN_DB_ERROR = 100009,
		/// <summary>
		///  排队中
		/// </summary>
		LOGIN_WAIT = 100010,
		/// <summary>
		///  服务器禁止登录
		/// </summary>
		LOGIN_BUSY = 100011,
		/// <summary>
		///  进入游戏
		/// </summary>
		ENTERGAME = 200000,
		/// <summary>
		///  角色信息不合法
		/// </summary>
		ENTERGAME_UNVALID_ROLEINFO = 200001,
		/// <summary>
		///  服务器繁忙
		/// </summary>
		ENTERGAME_SERVER_BUSY = 200002,
		/// <summary>
		///  太多角色
		/// </summary>
		ENTERGAME_TOOMANY_ROLES = 200003,
		/// <summary>
		///  重复名
		/// </summary>
		ENTERGAME_DUPLICATE_NAME = 200004,
		/// <summary>
		///  删除角色或进入游戏时提示
		/// </summary>
		ENTERGAME_NOROLE = 200005,
		/// <summary>
		///  场景未就绪
		/// </summary>
		ENTERGAME_SCENE_UNREADY = 200006,
		/// <summary>
		///  角色初始化失败
		/// </summary>
		ENTERGAME_INIT_FAILED = 200007,
		/// <summary>
		///  重复
		/// </summary>
		ENTERGAME_REPEAT = 200008,
		/// <summary>
		///  角色名不合法
		/// </summary>
		ENTERGAME_UNVALID_NAME = 200009,
		/// <summary>
		///  不允许建号
		/// </summary>
		ENTERGAME_NO_CREATEROLE = 200010,
		/// <summary>
		///  需要有角色达到20级
		/// </summary>
		ENTERGAME_NEED_LEVEL_20 = 200011,
		/// <summary>
		///  需要有角色达到40级
		/// </summary>
		ENTERGAME_NEED_LEVEL_40 = 200012,
		/// <summary>
		///  超过今日创建角色最大数
		/// </summary>
		ENTERGAME_TODAY_TOOMANY_ROLE = 200013,
		/// <summary>
		///  请求恢复的角色不存在
		/// </summary>
		ENTERGAME_RECOVER_ROLE_UNEXIST = 200014,
		/// <summary>
		///  请求恢复的角色已经删除了（超过保存时间）
		/// </summary>
		ENTERGAME_RECOVER_ROLE_DELETED = 200015,
		/// <summary>
		///  请求恢复的角色并没有被删除
		/// </summary>
		ENTERGAME_RECOVER_ROLE_NOT_DELETE = 200016,
		/// <summary>
		///  请求删除的角色已经被删除了
		/// </summary>
		ENTERGAME_DELETE_ROLE_DELETED = 200017,
		/// <summary>
		///  请求删除的角色不存在
		/// </summary>
		ENTERGAME_DELETE_ROLE_UNEXIST = 200018,
		/// <summary>
		///  当前正在删除的角色达到上限
		/// </summary>
		ENTERGAME_DELETE_ROLE_MAX_NUM = 200019,
		/// <summary>
		/// 请求删除的角色受限（时间限制）
		/// </summary>
		ENTERGAME_DELETE_ROLE_LIMIT = 200020,
		/// <summary>
		/// 请求恢复的角色受限（时间限制）
		/// </summary>
		ENTERGAME_RECOVER_ROLE_LIMIT = 200021,
		/// <summary>
		///  场景相关
		/// </summary>
		SCENE = 300000,
		/// <summary>
		///  重复的场景
		/// </summary>
		SCENE_DUPLICATE = 300001,
		/// <summary>
		///  建动态场景时下线
		/// </summary>
		SCENE_NOOWNER = 300002,
		/// <summary>
		///  档案错误码
		/// </summary>
		RECORD = 400000,
		/// <summary>
		///  数据库错误
		/// </summary>
		RECORD_ERROR = 400001,
		/// <summary>
		///  重复名
		/// </summary>
		RECORD_DUPLICATE_NAME = 400002,
		/// <summary>
		///  没有名字列
		/// </summary>
		RECORD_NO_NAMECOLUMN = 400003,
		RECORD_TIMEOUT = 400004,
		/// <summary>
		///  relayserver错误码
		/// </summary>
		RELAY = 500000,
		/// <summary>
		///  系统错误
		/// </summary>
		RELAY_LOGIN_SYSTEMERROR = 500001,
		/// <summary>
		///  无效的gamesession
		/// </summary>
		RELAY_LOGIN_INVALIDSESSION = 500002,
		/// <summary>
		///  无效的参战者
		/// </summary>
		RELAY_LOGIN_INVALIDFIGHTER = 500003,
		/// <summary>
		///  系统错误
		/// </summary>
		RELAY_RECONNECT_SYSTEMERROR = 500004,
		/// <summary>
		///  玩家还在线上
		/// </summary>
		RELAY_RECONNECT_PLAYER_ONLINE = 500005,
		/// <summary>
		///  无效的gamesession
		/// </summary>
		RELAY_RECONNECT_INVALIDSESSION = 500006,
		/// <summary>
		///  无效的参战者
		/// </summary>
		RELAY_RECONNECT_INVALIDFIGHTER = 500007,
		/// <summary>
		///  匹配相关
		/// </summary>
		MATCH = 600000,
		/// <summary>
		///  系统错误
		/// </summary>
		MATCH_START_SYSTEMERROR = 600001,
		/// <summary>
		///  已经在匹配中了
		/// </summary>
		MATCH_START_REPEAT = 600002,
		/// <summary>
		///  匹配失败，超时
		/// </summary>
		MATCH_TIMEOUT = 600003,
		/// <summary>
		///  不在PK准备区中
		/// </summary>
		MATCH_START_NOT_IN_PK_PARPARE = 600004,
		/// <summary>
		///  组队状态不能匹配
		/// </summary>
		MATCH_START_IN_TEAM = 600005,
		/// <summary>
		///  未加入武道大会
		/// </summary>
		MATCH_START_WUDAO_NOT_JOIN = 600006,
		/// <summary>
		///  武道大会已经完成
		/// </summary>
		MATCH_START_WUDAO_COMPLETE = 600007,
		/// <summary>
		///  不在匹配列表中
		/// </summary>
		MATCH_CANCLE_NOT_MATCHING = 600008,
		/// <summary>
		///  玩家已经在游戏中了
		/// </summary>
		MATCH_CANCLE_RACING = 600009,
		/// <summary>
		///  技能相关
		/// </summary>
		SKILL = 700000,
		/// <summary>
		///  ERROR
		/// </summary>
		SKILL_ERROR = 700001,
		/// <summary>
		///  保存到数据库失败
		/// </summary>
		SKILL_SAVE_DB_ERROR = 700002,
		/// <summary>
		///  没有这个技能
		/// </summary>
		SKILL_NOT_FOUNT = 700003,
		/// <summary>
		///  错误的技能类型
		/// </summary>
		SKILL_TYPE_ERROR = 700004,
		/// <summary>
		///  SP不够
		/// </summary>
		SKILL_SP_NOT_ENOUGH = 700005,
		/// <summary>
		///  移除SP失败
		/// </summary>
		SKILL_SP_REMOVE_ERROR = 700006,
		/// <summary>
		///  超过最大等级
		/// </summary>
		SKILL_MAX_SKILL_LEVEL = 700007,
		/// <summary>
		///  职业不合法
		/// </summary>
		SKILL_OCCU_ERROR = 700008,
		/// <summary>
		///  检查玩家等级
		/// </summary>
		SKILL_PLAYER_LEVEL = 700009,
		/// <summary>
		///  前置技能错误
		/// </summary>
		SKILL_NEED_SKILL_ERROR = 700010,
		/// <summary>
		///  没有需要的物品或BUFF
		/// </summary>
		SKILL_NEED_ITEM_ERROR = 700011,
		/// <summary>
		///  后置技能错误
		/// </summary>
		SKILL_NEXT_SKILL_ERROR = 700012,
		/// <summary>
		///  超过最小等级
		/// </summary>
		SKILL_MIN_SKILL_LEVEL = 700013,
		/// <summary>
		///  设置相关
		/// </summary>
		SETTING = 800000,
		/// <summary>
		///  ERROR
		/// </summary>
		SETTING_ERROR = 800001,
		/// <summary>
		///  索引错误
		/// </summary>
		SETTING_INDEX_ERROR = 800002,
		/// <summary>
		///  槽位索引错误
		/// </summary>
		SETTING_SLOT_ERROR = 800003,
		/// <summary>
		///  技能重复
		/// </summary>
		SETTING_SKILL_REPEAT = 800004,
		/// <summary>
		///  技能不存在
		/// </summary>
		SETTING_SKILL_ERROR = 800005,
		/// <summary>
		///  地下城相关
		/// </summary>
		DUNGEON = 900000,
		/// <summary>
		///  创建比赛失败
		/// </summary>
		DUNGEON_START_CREATE_RACE_FAILED = 900001,
		/// <summary>
		///  地下城不存在
		/// </summary>
		DUNGEON_START_DUNGEON_NOT_EXIST = 900002,
		/// <summary>
		///  未达到等级要求
		/// </summary>
		DUNGEON_START_LEVEL_LIMIT = 900003,
		/// <summary>
		///  没有疲劳了
		/// </summary>
		DUNGEON_START_NO_FATIGUE = 900004,
		/// <summary>
		///  不满足进入条件（前置任务，前置关卡等）
		/// </summary>
		DUNGEON_START_CONDITION = 900005,
		/// <summary>
		///  难度未开放
		/// </summary>
		DUNGEON_START_HARD_NOT_OPEN = 900006,
		/// <summary>
		///  不在选择关卡的场景
		/// </summary>
		DUNGEON_START_NOT_IN_ENTRY_SCENE = 900007,
		/// <summary>
		///  开始比赛失败
		/// </summary>
		DUNGEON_START_RACE_FAILED = 900008,
		/// <summary>
		///  门票不足
		/// </summary>
		DUNGEON_START_NO_TICKET = 900009,
		/// <summary>
		///  没有深渊模式
		/// </summary>
		DUNGEON_START_NO_HELL_MODE = 900010,
		/// <summary>
		///  没有足够的深渊票
		/// </summary>
		DUNGEON_START_NO_HELL_TICKET = 900011,
		/// <summary>
		///  队伍成员不在线
		/// </summary>
		DUNGEON_START_TEAM_MEMBER_OFFLINE = 900012,
		/// <summary>
		///  背包空余位置不足
		/// </summary>
		DUNGEON_START_BAG_FULL = 900013,
		/// <summary>
		///  不在开放时间
		/// </summary>
		DUNGEON_START_NOT_OPEN_TIME = 900014,
		/// <summary>
		///  次数用完
		/// </summary>
		DUNGEON_START_NO_TIMES = 900015,
		/// <summary>
		///  系统错误
		/// </summary>
		DUNGEON_ENTER_AREA_SYSTEM_ERROR = 900016,
		/// <summary>
		///  已经离开地下城了
		/// </summary>
		DUNGEON_ENTER_AREA_NOT_IN_DUNGEON = 900017,
		/// <summary>
		///  重复进入
		/// </summary>
		DUNGEON_ENTER_AREA_REPEAT = 900018,
		/// <summary>
		///  进入不存在的区域
		/// </summary>
		DUNGEON_ENTER_AREA_NOT_EXIST = 900019,
		/// <summary>
		///  复活的目标不存在
		/// </summary>
		DUNGEON_REVIVE_PLAYER_NOT_EXIST = 900020,
		/// <summary>
		///  重复复活
		/// </summary>
		DUNGEON_REVIVE_REPEAT = 900021,
		/// <summary>
		///  没有足够的复活币
		/// </summary>
		DUNGEON_REVIVE_NOT_ENOUGH_REVIVE_COIN = 900022,
		/// <summary>
		///  开始关卡匹配失败
		/// </summary>
		DUNGEON_MATCH_START_FAILED = 900023,
		/// <summary>
		///  重复开始地下城
		/// </summary>
		DUNGEON_TEAM_START_VOTE_REPEAT = 900024,
		/// <summary>
		///  地下城不能组队开始
		/// </summary>
		DUNGEON_TEAM_TARGET_MUST_SINGLE = 900025,
		/// <summary>
		///  超过地下城最大人数
		/// </summary>
		DUNGEON_TEAM_TOO_MANY_MEMBER = 900026,
		/// <summary>
		///  人数不足，无法开始地下城
		/// </summary>
		DUNGEON_TEAM_NOT_ENOUGH_MEMBER = 900027,
		/// <summary>
		///  等待其他人投票
		/// </summary>
		DUNGEON_TEAM_WAIT_OTHER_VOTE = 900028,
		/// <summary>
		///  无法购买次数
		/// </summary>
		DUNGEON_TIMES_CANT_BUY = 900029,
		/// <summary>
		///  无法购买次数，剩余次数不足
		/// </summary>
		DUNGEON_TIMES_NO_REMAIN_TIMES = 900030,
		/// <summary>
		///  无法购买次数，钱不够
		/// </summary>
		DUNGEON_TIMES_NO_ENOUGH_MONEY = 900031,
		/// <summary>
		///  开始比赛失败，这种情况下不需要提示
		/// </summary>
		DUNGEON_TEAM_START_RACE_FAILED = 901001,
		/// <summary>
		///  道具相关
		/// </summary>
		ITEM = 1000000,
		/// <summary>
		///  数据非法,包括各种相关空指正判断
		/// </summary>
		ITEM_DATA_INVALID = 1000001,
		/// <summary>
		///  没有操作理由
		/// </summary>
		ITEM_NO_REASON = 1000002,
		/// <summary>
		///  item数量非法
		/// </summary>
		ITEM_NUM_INVALID = 1000003,
		/// <summary>
		///  添加item背包满
		/// </summary>
		ITEM_ADD_PACK_FULL = 1000004,
		/// <summary>
		///  金钱添加达到上限
		/// </summary>
		ITEM_MONEY_ADD_FULL = 1000005,
		/// <summary>
		///  使用道具失败
		/// </summary>
		ITEM_USE_FAIL = 1000006,
		/// <summary>
		///  不能装备
		/// </summary>
		ITEM_CAN_NOT_EQUIP = 1000007,
		/// <summary>
		///  装备加锁
		/// </summary>
		ITEM_LOCKED = 1000008,
		/// <summary>
		///  装备所处的包裹错误
		/// </summary>
		ITEM_PACK_INVALID = 1000009,
		/// <summary>
		///  背包格子达到上限
		/// </summary>
		ITEM_PACKSIZE_MAX = 1000010,
		/// <summary>
		///  道具类别错误
		/// </summary>
		ITEM_TYPE_INVALID = 1000011,
		/// <summary>
		///  道具分解失败
		/// </summary>
		ITEM_DECOMPOSE_FAIL = 1000012,
		/// <summary>
		///  装备强化等级错误
		/// </summary>
		ITEM_STRENTH_LV_INVALID = 1000013,
		/// <summary>
		///  金币不够
		/// </summary>
		ITEM_NOT_ENOUGH_GOLD = 1000014,
		/// <summary>
		///  材料不够
		/// </summary>
		ITEM_NOT_ENOUGH_MAT = 1000015,
		/// <summary>
		///  装备强化失败无惩罚
		/// </summary>
		ITEM_STRENTH_FAIL = 1000016,
		/// <summary>
		///  装备强化失败扣等级
		/// </summary>
		ITEM_STRENTH_FAIL_MINUS = 1000017,
		/// <summary>
		///  装备强化失败等级归零
		/// </summary>
		ITEM_STRENTH_FAIL_ZERO = 1000018,
		/// <summary>
		///  装备强化失败破碎
		/// </summary>
		ITEM_STRENTH_FAIL_BROKE = 1000019,
		/// <summary>
		///  存仓库空间满了
		/// </summary>
		ITEM_PUSH_STORAGE_FULL = 1000020,
		/// <summary>
		///  存取仓库数量错误
		/// </summary>
		ITEM_STORAGE_NUM_ERR = 1000021,
		/// <summary>
		///  装备职业不符
		/// </summary>
		ITEM_EQUIP_OCCU = 1000022,
		/// <summary>
		///  装备等级不符
		/// </summary>
		ITEM_EQUIP_LV = 1000023,
		/// <summary>
		///  装备强化失败扣2级
		/// </summary>
		ITEM_STRENTH_FAIL_TWO = 1000024,
		/// <summary>
		///  装备强化失败扣2级
		/// </summary>
		ITEM_STRENTH_FAIL_THREE = 1000025,
		/// <summary>
		///  装备强化失败扣4级
		/// </summary>
		ITEM_STRENTH_FAIL_FOUR = 1000026,
		/// <summary>
		///  点券不够
		/// </summary>
		ITEM_NOT_ENOUGH_POINT = 1000027,
		/// <summary>
		///  强化类型错误(称号)addedbyhuchenhui2016.06.30
		/// </summary>
		ITEM_STRENTH_FAIL_TITLE = 1000028,
		/// <summary>
		///  装备不能分解
		/// </summary>
		ITEM_CNA_NOT_DECOMPOSE = 1000029,
		/// <summary>
		///  道具使用CD中
		/// </summary>
		ITEM_USE_CD = 1000030,
		/// <summary>
		///  封装次数达到上限
		/// </summary>
		ITEM_SEAL_COUNT_MAX = 1000031,
		/// <summary>
		///  装备已经是封装了
		/// </summary>
		ITEM_ALREADY_SEAL = 1000032,
		/// <summary>
		///  装备封装品质不符
		/// </summary>
		ITEM_SEAL_QUALITY_ERR = 1000033,
		/// <summary>
		///  勇者之魂不够
		/// </summary>
		ITEM_NOT_ENOUGH_WARRIOR_SOUL = 1000034,
		/// <summary>
		///  决斗币不够
		/// </summary>
		ITEM_NOT_ENOUGH_PKCOIN = 1000035,
		/// <summary>
		///  附魔部位错误
		/// </summary>
		ITEM_ADDMAGIC_PART_ERR = 1000036,
		/// <summary>
		///  附魔卡合成品质不同
		/// </summary>
		ITEM_MAGCARD_COMP_DIF_COLOR = 1000037,
		/// <summary>
		///  一键分解所需等级不够
		/// </summary>
		ITEM_ONEKEY_DECOMPOSE_LV_NOT_ENOUGH = 1000038,
		/// <summary>
		///  开罐子日金钱次数已满
		/// </summary>
		ITEM_OPEN_JAR_DAYCOUNT = 1000039,
		/// <summary>
		///  不能出售
		/// </summary>
		ITEM_NOT_SELL = 1000040,
		/// <summary>
		///  出售物品不存在
		/// </summary>
		ITEM_SELL_ITEM_NOT_EXIST = 1000041,
		/// <summary>
		///  公会贡献不够
		/// </summary>
		ITEM_NOT_ENOUGH_GUILD_CONTRI = 1000042,
		/// <summary>
		///  使用道具buff已经存在
		/// </summary>
		ITEM_USE_BUFFALREADYEXIST = 1000043,
		/// <summary>
		///  货币不足
		/// </summary>
		ITEM_NOT_ENOUGH_MONEY = 1000044,
		/// <summary>
		///  强化券等级错误
		/// </summary>
		ITEM_STRTICKET_LV_ERR = 1000045,
		/// <summary>
		///  强化券扣除失败
		/// </summary>
		ITEM_STRTICKET_REDUCE_ERR = 1000046,
		/// <summary>
		///  道具日使用次数完了
		/// </summary>
		ITEM_DAYUSENUM = 1000047,
		/// <summary>
		///  强化券强化失败
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
		///  地下城不能使用该道具
		/// </summary>
		ITEM_CAN_NOT_USE_IN_DUNGEON = 1000054,
		/// <summary>
		///  城镇内不能使用该道具
		/// </summary>
		ITEM_CAN_NOT_USE_IN_TOWN = 1000055,
		/// <summary>
		///  道具废弃
		/// </summary>
		ITEM_ABANDON = 1000056,
		/// <summary>
		///  商店相关
		/// </summary>
		SHOP = 1100000,
		/// <summary>
		///  商店查询错误
		/// </summary>
		SHOP_QUERY_ERR = 1100001,
		/// <summary>
		///  商店刷新错误
		/// </summary>
		SHOP_REFRESH_ERR = 1100002,
		/// <summary>
		///  商店购买错误
		/// </summary>
		SHOP_BUY_ERR = 1100003,
		/// <summary>
		///  商店购买金币不足
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_GOLD = 1100004,
		/// <summary>
		///  商店购买点券不足
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_POINT = 1100005,
		/// <summary>
		///  商店购买道具不足
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_ITEM = 1100006,
		/// <summary>
		///  商店购买背包空间不足
		/// </summary>
		SHOP_BUY_NOT_ENOUGH_PACKSIZE = 1100007,
		/// <summary>
		///  商店购买售罄
		/// </summary>
		SHOP_BUY_SALE_OUT = 1100008,
		/// <summary>
		///  商店刷新点券不足
		/// </summary>
		SHOP_REFRESH_NOT_ENOUGH_MONEY = 1100009,
		/// <summary>
		///  死亡塔层数不够
		/// </summary>
		SHOP_NOT_ENOUGH_TOWER_LEVEL = 1100010,
		/// <summary>
		///  角斗场积分不足
		/// </summary>
		SHOP_NOT_ENOUGH_DUEL_POINT = 1100011,
		/// <summary>
		///  商店刷新次数不足
		/// </summary>
		SHOP_REFRESH_COUNT = 1100012,
		/// <summary>
		///  公会商店不存在
		/// </summary>
		SHOP_GUIlD_SHOP_NOT_EXIST = 1100013,
		/// <summary>
		///  工会商店等级不足
		/// </summary>
		SHOP_GUIlD_NOT_ENOUGH_LV = 1100014,
		/// <summary>
		///  邮件相关
		/// </summary>
		MAIL = 1200000,
		/// <summary>
		///  邮件系统错误
		/// </summary>
		MAIL_ERROR = 1200001,
		/// <summary>
		///  标题错误
		/// </summary>
		MAIL_TITLE_ERROR = 1200002,
		/// <summary>
		///  标题长度错误
		/// </summary>
		MAIL_TITLE_LENGTH_ERROR = 1200003,
		/// <summary>
		///  内容错误
		/// </summary>
		MAIL_CONTENT_ERROR = 1200004,
		/// <summary>
		///  内容长度错误
		/// </summary>
		MAIL_CONTENT_LENGTH_ERROR = 1200005,
		/// <summary>
		///  发件人字符串错误
		/// </summary>
		MAIL_SENDER_NAME_ERROR = 1200006,
		/// <summary>
		///  发件人字符串长度错误
		/// </summary>
		MAIL_SENDER_NAME_LENGTH_ERROR = 1200007,
		/// <summary>
		///  奖励错误
		/// </summary>
		MAIL_REWARD_ERROR = 1200008,
		/// <summary>
		///  组队相关
		/// </summary>
		TEAM = 1300000,
		/// <summary>
		///  组队系统错误
		/// </summary>
		TEAM_ERROR = 1300001,
		/// <summary>
		///  创建队伍，已经有队伍了
		/// </summary>
		TEAM_CREATE_TEAM_HAS_TEAM = 1300002,
		/// <summary>
		///  创建队伍，无效的队伍目标
		/// </summary>
		TEAM_CREATE_TEAM_INVALID_TARGET = 1300003,
		/// <summary>
		///  加入队伍，超时
		/// </summary>
		TEAM_JOIN_TIMEOUT = 1300004,
		/// <summary>
		///  加入队伍，队伍不存在
		/// </summary>
		TEAM_JOIN_TEAM_UNEXIST = 1300005,
		/// <summary>
		///  加入队伍，队伍满
		/// </summary>
		TEAM_JOIN_TEAM_FULL = 1300006,
		/// <summary>
		///  加入队伍，队长离线
		/// </summary>
		TEAM_JOIN_TEAM_MASTER_OFFLINE = 1300007,
		/// <summary>
		///  加入队伍，已经有队伍了
		/// </summary>
		TEAM_JOIN_TEAM_HAS_TEAM = 1300008,
		/// <summary>
		///  加入队伍，密码错误
		/// </summary>
		TEAM_JOIN_TEAM_PASSWD_ERROR = 1300009,
		/// <summary>
		///  加入队伍，队伍有密码
		/// </summary>
		TEAM_JOIN_TEAM_HAS_PASSWD = 1300010,
		/// <summary>
		///  加入队伍，等级不足
		/// </summary>
		TEAM_JOIN_LEVEL_LIMIT = 1300011,
		/// <summary>
		///  密码长度不对
		/// </summary>
		TEAM_PASSWD_ERROR_LENGTH = 1300012,
		/// <summary>
		///  密码只能是数字
		/// </summary>
		TEAM_PASSWD_ONLY_NUM = 1300013,
		/// <summary>
		///  名字太长
		/// </summary>
		TEAM_NAME_TOO_LONG = 1300014,
		/// <summary>
		///  无效的名字
		/// </summary>
		TEAM_NAME_INVALID = 1300015,
		/// <summary>
		///  无效的目标
		/// </summary>
		TEAM_TARGET_INVALID = 1300016,
		/// <summary>
		///  切换目标失败，人数太多
		/// </summary>
		TEAM_TOO_MANY_PLAYER = 1300017,
		/// <summary>
		///  处理申请者，你不是队长
		/// </summary>
		TEAM_REPLY_NOT_MASTER = 1300018,
		/// <summary>
		///  处理申请者，玩家不在线
		/// </summary>
		TEAM_REPLY_PLAYER_OFFLINE = 1300019,
		/// <summary>
		///  处理申请者，该玩家未申请加入
		/// </summary>
		TEAM_REPLY_PLAYER_INVALID = 1300020,
		/// <summary>
		///  处理申请者，队伍已满
		/// </summary>
		TEAM_REPLY_TEAM_FULL = 1300021,
		/// <summary>
		///  邀请玩家，自己没有队伍
		/// </summary>
		TEAM_INVITE_NO_TEAM = 1300022,
		/// <summary>
		///  邀请玩家，自己不是队长
		/// </summary>
		TEAM_INVITE_NOT_TEAM_MASTER = 1300023,
		/// <summary>
		///  邀请玩家，队伍已满
		/// </summary>
		TEAM_INVITE_TEAM_FULL = 1300024,
		/// <summary>
		///  邀请玩家，队伍正在战斗中
		/// </summary>
		TEAM_INVITE_TEAM_IN_RACE = 1300025,
		/// <summary>
		///  邀请玩家，对方不在线
		/// </summary>
		TEAM_INVITE_TARGET_OFFLINE = 1300026,
		/// <summary>
		///  邀请玩家，对方已经在队伍中
		/// </summary>
		TEAM_INVITE_TARGET_IN_TEAM = 1300027,
		/// <summary>
		///  邀请玩家，目标正忙
		/// </summary>
		TEAM_INVITE_TARGET_BUSY = 1300028,
		/// <summary>
		///  邀请玩家，重复邀请
		/// </summary>
		TEAM_INVITE_REPEAT = 1300029,
		/// <summary>
		///  加入队伍，队伍正在战斗中
		/// </summary>
		TEAM_JOIN_RACING = 1300030,
		/// <summary>
		///  等级不足
		/// </summary>
		TEAM_MIN_LEVEL = 1300031,
		/// <summary>
		///  邀请玩家，对方等级不足
		/// </summary>
		TEAM_INVITE_TARGET_MIN_LEVEL = 1300032,
		/// <summary>
		///  邀请玩家，太频繁
		/// </summary>
		TEAM_INVITE_FREQUENTLY = 1300033,
		/// <summary>
		///  开始匹配失败，这种情况不需要提示
		/// </summary>
		TEAM_MATCH_START_FAILED = 1301001,
		/// <summary>
		///  只有队长能操作
		/// </summary>
		TEAM_MATCH_ONLY_MASTER = 1301002,
		/// <summary>
		///  开始匹配失败，已经在匹配中
		/// </summary>
		TEAM_MATCH_START_IN_MATCHING = 1301003,
		/// <summary>
		///  取消匹配失败，不在匹配中
		/// </summary>
		TEAM_MATCH_CANCEL_NOT_IN_MATCHING = 1301004,
		/// <summary>
		///  次元石相关
		/// </summary>
		WARPSTONE = 1400000,
		/// <summary>
		///  银币不够
		/// </summary>
		WARP_STONE_SILVER_ERROR = 1400001,
		/// <summary>
		///  没有解锁
		/// </summary>
		WARP_STONE_UNLOCK_ERROR = 1400002,
		/// <summary>
		///  到达最大等级
		/// </summary>
		WARP_STONE_LEVEL_MAX = 1400003,
		/// <summary>
		///  次元石没找到
		/// </summary>
		WARP_STONE_NOT_FOUNT = 1400004,
		/// <summary>
		///  次元石解锁等级不够
		/// </summary>
		WARP_STONE_PLAYER_LEVEL_ERROR = 1400005,
		/// <summary>
		///  能量石没有找到
		/// </summary>
		ENERGY_STONE_NOT_FOUNT = 1400006,
		/// <summary>
		///  能量石不够
		/// </summary>
		ENERGY_STONE_NOT_ENOUGH = 1400007,
		/// <summary>
		///  能量石类型错误
		/// </summary>
		ENERGY_STONE_TYPE_ERROR = 1400008,
		/// <summary>
		///  随从相关
		/// </summary>
		RETINUE = 1500000,
		/// <summary>
		///  没有对应的玩家
		/// </summary>
		RETINUE_NOT_PLAYER = 1500001,
		/// <summary>
		///  随从数据表不存在
		/// </summary>
		RETINUE_DATA_NOT_EXIST = 1500002,
		/// <summary>
		///  随从不存在
		/// </summary>
		RETINUE_NOT_EXIST = 1500003,
		/// <summary>
		///  随从已经存在
		/// </summary>
		RETINUE_IS_EXIST = 1500004,
		/// <summary>
		///  玩家等级不够
		/// </summary>
		RETINUE_PLAYER_LEVEL = 1500005,
		/// <summary>
		///  洗练物品不够
		/// </summary>
		RETINUE_NOT_ITEM = 1500006,
		/// <summary>
		///  解锁物品不够
		/// </summary>
		RETINUE_UNLOCK_NOT_ITEM = 1500007,
		/// <summary>
		///  随从等级不存在.
		/// </summary>
		RETINUE_LEVEL_DATA_NOT_EXIST = 1500008,
		/// <summary>
		///  升级物品不够
		/// </summary>
		RETINUE_LEVEL_NOT_ITEM = 1500009,
		/// <summary>
		///  设置随从位置错误
		/// </summary>
		RETINUE_RETINUE_INDEX_ERROR = 1500010,
		/// <summary>
		///  勇士之魂不够
		/// </summary>
		RETINUE_WARRIOR_SOUL_ERROR = 1500011,
		/// <summary>
		///  不能超过最大星级
		/// </summary>
		RETINUE_MAX_STAR_ERROR = 1500012,
		/// <summary>
		///  没有这个星级
		/// </summary>
		RETINUE_STAR_LEVEL_NOT_EXIST = 1500013,
		/// <summary>
		///  升星碎片不够
		/// </summary>
		RETINUE_UP_STAR_NOT_ITEM = 1500014,
		/// <summary>
		///  没有可洗练的技能
		/// </summary>
		RETINUE_NOT_CHANGE_SKILL_ERROR = 1500015,
		/// <summary>
		///  没有对应的洗练库
		/// </summary>
		RETINUE_NOT_SKILL_GROUP_ERROR = 1500016,
		/// <summary>
		///  洗练库是一个环
		/// </summary>
		RETINUE_SKILL_GROUP_RING_ERROR = 1500017,
		/// <summary>
		///  升级类型不正确
		/// </summary>
		RETINUE_UP_TYPE_ERROR = 1500018,
		/// <summary>
		///  没有主随从
		/// </summary>
		RETINUE_NOT_MAIN_ERROR = 1500019,
		/// <summary>
		///  无法下阵随从
		/// </summary>
		RETINUE_NOT_DOWN_ERROR = 1500020,
		/// <summary>
		///  重连
		/// </summary>
		RECONNECT = 1600000,
		/// <summary>
		///  角色数据已经删除
		/// </summary>
		RECONNECT_PLAYER_DELETED = 1600001,
		/// <summary>
		///  无效的sequence
		/// </summary>
		RECONNECT_INVALID_SEQUENCE = 1600002,
		/// <summary>
		///  账号还在线
		/// </summary>
		RECONNECT_PLAYER_ONLINE = 1600003,
		/// <summary>
		///  错误的连接
		/// </summary>
		RECONNECT_NO_CONNECTION = 1600004,
		/// <summary>
		///  商城
		/// </summary>
		MALL = 1700000,
		/// <summary>
		///  商城商品查询失败
		/// </summary>
		MALL_QUERY_FAIL = 1700001,
		/// <summary>
		///  购买数量错误
		/// </summary>
		MALL_BUYNUM_ERR = 1700002,
		/// <summary>
		///  找不到要购买的物品
		/// </summary>
		MALL_CANNOT_FIND_ITEM = 1700003,
		/// <summary>
		///  找不到要触发的限时礼包
		/// </summary>
		MALL_CANNOT_FIND_GIFT_PACK = 1700004,
		/// <summary>
		///  商城限时礼包已触发
		/// </summary>
		MALL_GIFT_PACK_ACTIVATED = 1700005,
		/// <summary>
		///  玩家相关
		/// </summary>
		PLAYER = 1800000,
		/// <summary>
		///  转职等级不够
		/// </summary>
		PLAYER_TRANSFORM_OCCU_LEVEL_ERROR = 1800001,
		/// <summary>
		///  觉醒等级不够
		/// </summary>
		PLAYER_AWAKEN_LEVEL_ERROR = 1800002,
		/// <summary>
		///  已经觉醒
		/// </summary>
		PLAYER_AWAKEN_EXIST = 1800003,
		/// <summary>
		///  还未转职
		/// </summary>
		PLAYER_AWAKEN_NOT_TRANSFORM_OCCU = 1800004,
		/// <summary>
		///  vip购买时,vip等级错误
		/// </summary>
		PLAYER_VIP_BUY_LEVEL_ERROR = 1800005,
		/// <summary>
		///  vip购买礼包,点卷不够
		/// </summary>
		PLAYER_VIP_BUY_GIFT_ENOUGH_POINT = 1800006,
		/// <summary>
		///  vip礼包为空
		/// </summary>
		PLAYER_VIP_GIFT_EMPTY = 1800007,
		/// <summary>
		///  vip购买礼包背包空间不足
		/// </summary>
		PLAYER_VIP_BUY_NOT_ENOUGH_PACKSIZE = 1800008,
		/// <summary>
		///  vip购买礼包消耗点卷失败
		/// </summary>
		PLAYER_VIP_BUY_REMOVE_POINT_ERROR = 1800009,
		/// <summary>
		///  vip已经购买这个礼包
		/// </summary>
		PLAYER_VIP_BUY_ALREADY = 1800010,
		/// <summary>
		///  vip等级不足
		/// </summary>
		PLAYER_VIPLV_NOT_ENOUGH = 1800011,
		/// <summary>
		///  快速购买
		/// </summary>
		QUICKBUY = 1900000,
		/// <summary>
		///  系统错误
		/// </summary>
		QUICK_BUY_SYSTEM_ERROR = 1900001,
		/// <summary>
		///  上一个事务还没结束
		/// </summary>
		QUICK_BUY_LAST_TRANS_NOT_FINISH = 1900002,
		/// <summary>
		///  超时
		/// </summary>
		QUICK_BUY_TIMEOUT = 1900003,
		/// <summary>
		///  无效的类型
		/// </summary>
		QUICK_BUY_INVALID_TYPE = 1900004,
		/// <summary>
		///  钱不够
		/// </summary>
		QUICK_BUY_NOT_ENOUGH_MONEY = 1900005,
		/// <summary>
		///  道具不存在
		/// </summary>
		QUICK_BUY_INVALID_ITEM = 1900006,
		/// <summary>
		///  道具数量不正确
		/// </summary>
		QUICK_BUY_INVALID_NUM = 1900007,
		/// <summary>
		///  背包空间不足
		/// </summary>
		QUICK_BUY_BAG_FULL = 1900008,
		/// <summary>
		///  不在比赛中
		/// </summary>
		QUICK_BUY_REVIVE_NOT_IN_RACE = 1900009,
		/// <summary>
		///  任务相关
		/// </summary>
		TASK = 2000000,
		/// <summary>
		///  提交任务物品类型错误
		/// </summary>
		TASK_SET_ITEM_TASK_TYPE_ERROR = 2000001,
		/// <summary>
		///  提交错误的任务物品
		/// </summary>
		TASK_SET_ITEM_ERROR = 2000002,
		/// <summary>
		///  提交的任务物品数量不够
		/// </summary>
		TASK_SET_ITEM_NUM_ERROR = 2000003,
		/// <summary>
		///  任务不存在
		/// </summary>
		TASK_NOT_EXIST = 2000004,
		/// <summary>
		///  任务脚本不存在
		/// </summary>
		TASK_SCRIPT_NOT_EXIST = 2000005,
		/// <summary>
		///  任务不再接取状态
		/// </summary>
		TASK_NOT_UNFINISH = 2000006,
		/// <summary>
		///  任务类型错误
		/// </summary>
		TASK_TYPE_ERROR = 2000007,
		/// <summary>
		///  循环任务不存在
		/// </summary>
		TASK_CYCLE_NOT_EXIST = 2000008,
		/// <summary>
		///  消耗资源不足
		/// </summary>
		TASK_CYCLE_REFRESH_NOT_CONSUME = 2000009,
		/// <summary>
		///  每日任务积分奖励箱子不存在
		/// </summary>
		TASK_DATILY_TASK_SCORE_BOX_NOT_FOUNT = 2000010,
		/// <summary>
		///  每日任务积分奖励积分不够
		/// </summary>
		TASK_DATILY_TASK_SCORE_BOX_SCORE = 2000011,
		/// <summary>
		///  每日任务积分奖励已经领取
		/// </summary>
		TASK_DATILY_TASK_SCORE_BOX_RECEIVE = 2000012,
		/// <summary>
		///  死亡之塔
		/// </summary>
		TOWER = 2100000,
		/// <summary>
		///  没有重置次数
		/// </summary>
		TOWER_RESET_NO_REMAIN_COUNT = 2100001,
		/// <summary>
		///  正在扫荡中
		/// </summary>
		TOWER_DOING_WIPEOUT = 2100002,
		/// <summary>
		///  没有层数去扫荡
		/// </summary>
		TOWER_NO_FLOOR_WIPEOUT = 2100003,
		/// <summary>
		///  没有在扫荡中
		/// </summary>
		TOWER_NOT_DOING_WIPEOUT = 2100004,
		/// <summary>
		///  扫荡未完成
		/// </summary>
		TOWER_WIPEOUT_NOT_FINISH = 2100005,
		/// <summary>
		///  扫荡已完成
		/// </summary>
		TOWER_WIPEOUT_FINISHED = 2100006,
		/// <summary>
		///  没有足够的点劵
		/// </summary>
		TOWER_WIPEOUT_NOT_ENOUGH_POINT = 2100007,
		/// <summary>
		///  未通过该层
		/// </summary>
		TOWER_AWARD_NOT_PASS_FLOOR = 2100008,
		/// <summary>
		///  无效的层数，没有对应奖励
		/// </summary>
		TOWER_AWARD_INVALID_FLOOR = 2100009,
		/// <summary>
		///  重复领奖
		/// </summary>
		TOWER_AWARD_REPEAT_RECEIVE = 2100010,
		/// <summary>
		///  不需要重置
		/// </summary>
		TOWER_NO_NEED_RESET = 2100011,
		/// <summary>
		///  没有VIP权限
		/// </summary>
		TOWER_RESET_NO_VIP_PRIVILEGE = 2100012,
		/// <summary>
		///  PK相关
		/// </summary>
		PK = 2200000,
		/// <summary>
		///  组队中
		/// </summary>
		PK_CHALLENGE_IN_TEAM = 2200001,
		/// <summary>
		///  不在PK准备区中
		/// </summary>
		PK_CHALLENGE_NOT_IN_PK_PREPARE = 2200002,
		/// <summary>
		///  目标在忙
		/// </summary>
		PK_CHALLENGE_TARGET_BUSY = 2200003,
		/// <summary>
		///  目标不在线
		/// </summary>
		PK_CHALLENGE_TARGET_NOT_ONLINE = 2200004,
		/// <summary>
		///  重复挑战
		/// </summary>
		PK_CHALLENGE_REPEAT = 2200005,
		/// <summary>
		///  等级太低
		/// </summary>
		PK_CHALLENGE_LEVEL_LIMIT = 2200006,
		/// <summary>
		///  系统错误
		/// </summary>
		PK_WUDAO_SYSTEM_ERROR = 2200007,
		/// <summary>
		///  活动未开始
		/// </summary>
		PK_WUDAO_ACTIVITY_NOT_OPEN = 2200008,
		/// <summary>
		///  不满足活动开启条件
		/// </summary>
		PK_WUDAO_ACTIVITY_COND = 2200009,
		/// <summary>
		///  没有门票
		/// </summary>
		PK_WUDAO_NO_TICKET = 2200010,
		/// <summary>
		///  已经参加了
		/// </summary>
		PK_WUDAO_JOINED = 2200011,
		/// <summary>
		///  武道大会未完成
		/// </summary>
		PK_WUDAO_NOT_COMPLETE = 2200012,
		/// <summary>
		///  公会
		/// </summary>
		GUILD = 2300000,
		/// <summary>
		///  没有对应的权限
		/// </summary>
		GUILD_NO_POWER = 2300001,
		/// <summary>
		///  公会已满
		/// </summary>
		GUILD_FULL = 2300002,
		/// <summary>
		///  不在公会中
		/// </summary>
		GUILD_NOT_IN_GUILD = 2300003,
		/// <summary>
		///  系统错误
		/// </summary>
		GUILD_SYS_ERROR = 2300004,
		/// <summary>
		///  没有足够的钱
		/// </summary>
		GUILD_NOT_ENOUGH_MONEY = 2300005,
		/// <summary>
		///  次数用完
		/// </summary>
		GUILD_NOT_ENOUGH_TIMES = 2300006,
		/// <summary>
		///  公会战期间不能离开公会
		/// </summary>
		GUILD_BATTLE_NOT_LEAVE = 2300007,
		/// <summary>
		///  名字重复
		/// </summary>
		GUILD_NAME_REPEAT = 2301001,
		/// <summary>
		///  名字中有屏蔽字
		/// </summary>
		GUILD_NAME_INVALID = 2301002,
		/// <summary>
		///  宣言中有屏蔽字
		/// </summary>
		GUILD_DECLARATION_INVALID = 2301003,
		/// <summary>
		///  公告中有屏蔽字
		/// </summary>
		GUILD_ANNOUNCEMENT_INVALID = 2301004,
		/// <summary>
		///  公告中有屏蔽字
		/// </summary>
		GUILD_MAIL_INVALID = 2301005,
		/// <summary>
		///  重复创建
		/// </summary>
		GUILD_CREATE_REPEAT = 2302001,
		/// <summary>
		///  已经在公会中
		/// </summary>
		GUILD_CREATE_ALREADY_HAS_GUILD = 2302002,
		/// <summary>
		///  无效的公会名
		/// </summary>
		GUILD_CREATE_INVALID_NAME = 2302003,
		/// <summary>
		///  无效的公会宣言
		/// </summary>
		GUILD_CREATE_INVALID_DECLARATION = 2302004,
		/// <summary>
		///  没有足够的钱
		/// </summary>
		GUILD_CREATE_NOT_ENOUGH_MONEY = 2302005,
		/// <summary>
		///  等级不足
		/// </summary>
		GUILD_CREATE_MIN_LEVEL = 2302006,
		/// <summary>
		///  刚离开公会，还在冷却时间中
		/// </summary>
		GUILD_CREATE_COLDTIME = 2302007,
		/// <summary>
		///  公会名为空
		/// </summary>
		GUILD_CREATE_NAME_EMPTY = 2302008,
		/// <summary>
		///  公会宣言为空
		/// </summary>
		GUILD_CREATE_DECLARATION_EMPTY = 2302009,
		/// <summary>
		///  重复加入
		/// </summary>
		GUILD_JOIN_REPEAT = 2303001,
		/// <summary>
		///  已经在公会中
		/// </summary>
		GUILD_JOIN_ALREADY_HAS_GUILD = 2303002,
		/// <summary>
		///  等级不足
		/// </summary>
		GUILD_JOIN_MIN_LEVEL = 2303003,
		/// <summary>
		///  公会不存在
		/// </summary>
		GUILD_JOIN_NOT_EXIST = 2303004,
		/// <summary>
		///  刚离开公会，还在冷却时间中
		/// </summary>
		GUILD_JOIN_COLDTIME = 2303005,
		/// <summary>
		///  公会申请列表已满
		/// </summary>
		GUILD_JOIN_REQUEST_QUEUE_FULL = 2303006,
		/// <summary>
		///  公会正在解散
		/// </summary>
		GUILD_JOIN_IN_DISMISS = 2303007,
		/// <summary>
		///  先转让会长
		/// </summary>
		GUILD_LEAVE_TRANSFER_LEADER = 2304001,
		/// <summary>
		///  没有这个请求者
		/// </summary>
		GUILD_REPLY_REQUESTER_UNEXIST = 2305001,
		/// <summary>
		///  已经在其他公会中了
		/// </summary>
		GUILD_REPLY_IN_OTHER_GUILD = 2305002,
		/// <summary>
		///  刚离开公会，还在冷却时间中
		/// </summary>
		GUILD_REPLY_COLDTIME = 2305003,
		/// <summary>
		///  目标职务人数已满
		/// </summary>
		GUILD_POST_FULL = 2306001,
		/// <summary>
		///  需要会长连续7天不在线
		/// </summary>
		GUILD_POST_LEADER_LEAVE_TIME = 2306002,
		/// <summary>
		///  超过主城等级，先升级主城等级
		/// </summary>
		GUILD_BUILDING_UPGRADE_MAIN_FIRST = 2307001,
		/// <summary>
		///  已经到满级
		/// </summary>
		GUILD_BUILDING_TOP_LEVEL = 2307002,
		/// <summary>
		///  帮会资金不足
		/// </summary>
		GUILD_BUILDING_NOT_ENOUGH_FUND = 2307003,
		/// <summary>
		///  剩余次数不足
		/// </summary>
		GUILD_DONATE_NO_REMAIN_TIMES = 2308001,
		/// <summary>
		///  还在CD中
		/// </summary>
		GUILD_EXCHANGE_CD = 2309001,
		/// <summary>
		///  剩余次数不足
		/// </summary>
		GUILD_EXCHANGE_NO_REMAIN_TIMES = 2309002,
		/// <summary>
		///  贡献不足
		/// </summary>
		GUILD_EXCHANGE_NOT_ENOUGH_CONTRI = 2309003,
		/// <summary>
		///  已经到达最高等级
		/// </summary>
		GUILD_SKILL_TOP_LEVEL = 2310001,
		/// <summary>
		///  正在解散中
		/// </summary>
		GUILD_DISMISS_IN_DISMISS = 2311001,
		/// <summary>
		///  不在解散中
		/// </summary>
		GUILD_NOT_IN_DISMISS = 2311002,
		/// <summary>
		///  圆桌已满
		/// </summary>
		GUILD_TABLE_FULL = 2312001,
		/// <summary>
		///  位子已经被占
		/// </summary>
		GUILD_TABLE_SEAT_HAS_PLAYER = 2312002,
		/// <summary>
		///  已经在位子上了
		/// </summary>
		GUILD_TABLE_REPEAT = 2312003,
		/// <summary>
		///  无效的位子
		/// </summary>
		GUILD_TABLE_SEAT_INVALID = 2312004,
		/// <summary>
		///  膜拜类型错误
		/// </summary>
		GUILD_ORZ_INVALID_TYPE = 2313001,
		/// <summary>
		///  没有这个VIP权限
		/// </summary>
		GUILD_ORZ_VIP_PRIVILEGE = 2313002,
		/// <summary>
		///  没有找到玩家
		/// </summary>
		GUILD_BATTLE_NOT_PLAYER = 2314001,
		/// <summary>
		///  玩家没有公会
		/// </summary>
		GUILD_BATTLE_NOT_EXIST = 2314002,
		/// <summary>
		///  玩家不是公会成员
		/// </summary>
		GUILD_BATTLE_NOT_IS_MEMBER = 2314003,
		/// <summary>
		///  公会战报名公会找不到
		/// </summary>
		GUILD_BATTLE_ENROLL_GUILD_NOT_FIND = 2314004,
		/// <summary>
		///  玩家报名没有权限
		/// </summary>
		GUILD_BATTLE_ENROLL_NOT_POWER = 2314005,
		/// <summary>
		///  公会战没有开始报名
		/// </summary>
		GUILD_BATTLE_ENROLL_NOT_ENROLL = 2314006,
		/// <summary>
		///  公会战报名人数已满
		/// </summary>
		GUILD_BATTLE_ENROLL_FULL = 2314007,
		/// <summary>
		///  公会战报名公会等级不够
		/// </summary>
		GUILD_BATTLE_ENROLL_GUILD_LEVEL = 2314008,
		/// <summary>
		///  公会战报名占领领地等级太低
		/// </summary>
		GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_LOW = 2314009,
		/// <summary>
		///  公会战报名占领领地等级太高
		/// </summary>
		GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_HIGH = 2314010,
		/// <summary>
		///  公会战不能重复报名
		/// </summary>
		GUILD_BATTLE_ENROLL_EXIST = 2314011,
		/// <summary>
		///  公会战报名正在处理事务
		/// </summary>
		GUILD_BATTLE_ENROLL_TRANSACTION = 2314012,
		/// <summary>
		///  领地不存在或者公会没有报名
		/// </summary>
		GUILD_BATTLE_TERRITORY_NOT_EXIST = 2314013,
		/// <summary>
		///  公会没有报名
		/// </summary>
		GUILD_BATTLE_NOT_ENROLL = 2314014,
		/// <summary>
		///  公会战鼓舞已经最高次数
		/// </summary>
		GUILD_BATTLE_INSPIRE_MAX_COUNT = 2314015,
		/// <summary>
		///  公会战鼓舞道具不足
		/// </summary>
		GUILD_BATTLE_INSPIRE_ITEM = 2314016,
		/// <summary>
		///  公会战鼓舞正在处理事务
		/// </summary>
		GUILD_BATTLE_INSPIRE_TRANSACTION = 2314017,
		/// <summary>
		///  公会战成员匹配次数不足
		/// </summary>
		GUILD_BATTLE_MEMBER_MATCH_COUNT = 2314018,
		/// <summary>
		///  战斗结束找不到玩家
		/// </summary>
		GUILD_BATTLE_RACE_END_NOT_MEMBER = 2314019,
		/// <summary>
		///  公会战已经结束
		/// </summary>
		GUILD_BATTLE_IS_END = 2314020,
		/// <summary>
		///  领取奖励找不到玩家
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_NOT_MEMBER = 2314021,
		/// <summary>
		///  领取奖励没有找到数据项
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_DATA_ERROR = 2314022,
		/// <summary>
		///  领取奖励积分不足
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_SCORE_ERROR = 2314023,
		/// <summary>
		///  奖励已经领取
		/// </summary>
		GUILD_BATTLE_GIVE_REWARD_ALREADY = 2314024,
		/// <summary>
		///  公会战上一场战斗没有结束
		/// </summary>
		GUILD_BATTLE_RACE_NOT_END = 2314025,
		/// <summary>
		///  公会战匹配正在处理事务
		/// </summary>
		GUILD_BATTLE_MATCH_TRANSACTION = 2314026,
		/// <summary>
		///  公会战报名不能解散
		/// </summary>
		GUILD_BATTLE_ENROLL_NOT_DISMISS = 2314027,
		/// <summary>
		///  公会战解散中不能报名
		/// </summary>
		GUILD_BATTLE_DISMISS_NOT_ENROLL = 2314028,
		/// <summary>
		///  道具事务
		/// </summary>
		ITEM_TRANS = 2400000,
		/// <summary>
		///  失败
		/// </summary>
		ITEM_TRANS_FAILED = 2400001,
		/// <summary>
		///  钱不够
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_MONEY = 2400002,
		/// <summary>
		///  复活币不足
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_REVIVE_COIN = 2400003,
		/// <summary>
		///  道具不足
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_ITEM = 2400004,
		/// <summary>
		///  次数不足
		/// </summary>
		ITEM_TRANS_NOT_ENOUGH_TIMES = 2400005,
		/// <summary>
		///  红包
		/// </summary>
		RED_PACKET = 2500000,
		/// <summary>
		///  系统错误
		/// </summary>
		RED_PACKET_SYS_ERROR = 2500001,
		/// <summary>
		///  无效的红包
		/// </summary>
		RED_PACKET_INVALID = 2500002,
		/// <summary>
		///  红包不存在
		/// </summary>
		RED_PACKET_NOT_EXIST = 2500003,
		/// <summary>
		///  红包不是你的
		/// </summary>
		RED_PACKET_NOT_OWNER = 2500004,
		/// <summary>
		///  红包已经发出去了
		/// </summary>
		RED_PACKET_ALREADY_SEND = 2500005,
		/// <summary>
		///  公会红包，不在公会中
		/// </summary>
		RED_PACKET_NOT_IN_GUILD = 2500006,
		/// <summary>
		///  红包无法打开
		/// </summary>
		RED_PACKET_CANT_OPEN = 2500007,
		/// <summary>
		///  红包已被抢完
		/// </summary>
		RED_PACKET_EMPTY = 2500008,
		/// <summary>
		///  红包个数错误
		/// </summary>
		RED_PACKET_INVALID_NUM = 2500009,
		/// <summary>
		///  红包名字错误
		/// </summary>
		RED_PACKET_INVALID_NAME = 2500010,
		/// <summary>
		///  充值
		/// </summary>
		BILLING = 2600000,
		/// <summary>
		///  玩家不在线
		/// </summary>
		BILLING_PLAYER_OFFLINE = 2600001,
		/// <summary>
		///  货物不存在
		/// </summary>
		BILLING_GOODS_UNEXIST = 2600002,
		/// <summary>
		///  没有次数了
		/// </summary>
		BILLING_GOODS_NUM_LIMIT = 2600003,
		/// <summary>
		///  月卡时间未到无法购买
		/// </summary>
		BILLING_GOODS_MONTH_CARD_CANT_BUY = 2600004,
	}

}
