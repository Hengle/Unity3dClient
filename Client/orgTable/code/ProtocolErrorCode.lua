local descriptor = require "descriptor"

module "ProtocolErrorCode"

ProtoErrorCode = descriptor.def_enum("ProtoErrorCode",
	{
		//  成功

		descriptor.def_enum_value("SUCCESS", 0),
		//  登录验证

		descriptor.def_enum_value("LOGIN", 100000),
		//  服务器未就绪

		descriptor.def_enum_value("LOGIN_SERVER_UNREADY", 100001),
		//  未知账号，账号名错误

		descriptor.def_enum_value("LOGIN_UNKNOW_ACCOUNT", 100002),
		//  重复登录

		descriptor.def_enum_value("LOGIN_REPEAT", 100003),
		//  密码错

		descriptor.def_enum_value("LOGIN_WRONG_PASSWD", 100004),
		//  验证超时

		descriptor.def_enum_value("LOGIN_VERIFY_TIMEOUT", 100005),
		//  服务器繁忙

		descriptor.def_enum_value("LOGIN_SERVER_BUSY", 100006),
		//  版本号错误

		descriptor.def_enum_value("LOGIN_ERROR_VERSION", 100007),
		//  封号

		descriptor.def_enum_value("LOGIN_FORBID_LOGIN", 100008),
		//  数据库错误

		descriptor.def_enum_value("LOGIN_DB_ERROR", 100009),
		//  排队中

		descriptor.def_enum_value("LOGIN_WAIT", 100010),
		//  服务器禁止登录

		descriptor.def_enum_value("LOGIN_BUSY", 100011),
		//  进入游戏

		descriptor.def_enum_value("ENTERGAME", 200000),
		//  角色信息不合法

		descriptor.def_enum_value("ENTERGAME_UNVALID_ROLEINFO", 200001),
		//  服务器繁忙

		descriptor.def_enum_value("ENTERGAME_SERVER_BUSY", 200002),
		//  太多角色

		descriptor.def_enum_value("ENTERGAME_TOOMANY_ROLES", 200003),
		//  重复名

		descriptor.def_enum_value("ENTERGAME_DUPLICATE_NAME", 200004),
		//  删除角色或进入游戏时提示

		descriptor.def_enum_value("ENTERGAME_NOROLE", 200005),
		//  场景未就绪

		descriptor.def_enum_value("ENTERGAME_SCENE_UNREADY", 200006),
		//  角色初始化失败

		descriptor.def_enum_value("ENTERGAME_INIT_FAILED", 200007),
		//  重复

		descriptor.def_enum_value("ENTERGAME_REPEAT", 200008),
		//  角色名不合法

		descriptor.def_enum_value("ENTERGAME_UNVALID_NAME", 200009),
		//  不允许建号

		descriptor.def_enum_value("ENTERGAME_NO_CREATEROLE", 200010),
		//  需要有角色达到20级

		descriptor.def_enum_value("ENTERGAME_NEED_LEVEL_20", 200011),
		//  需要有角色达到40级

		descriptor.def_enum_value("ENTERGAME_NEED_LEVEL_40", 200012),
		//  超过今日创建角色最大数

		descriptor.def_enum_value("ENTERGAME_TODAY_TOOMANY_ROLE", 200013),
		//  请求恢复的角色不存在

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_UNEXIST", 200014),
		//  请求恢复的角色已经删除了（超过保存时间）

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_DELETED", 200015),
		//  请求恢复的角色并没有被删除

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_NOT_DELETE", 200016),
		//  请求删除的角色已经被删除了

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_DELETED", 200017),
		//  请求删除的角色不存在

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_UNEXIST", 200018),
		//  当前正在删除的角色达到上限

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_MAX_NUM", 200019),
		// 请求删除的角色受限（时间限制）

		descriptor.def_enum_value("ENTERGAME_DELETE_ROLE_LIMIT", 200020),
		// 请求恢复的角色受限（时间限制）

		descriptor.def_enum_value("ENTERGAME_RECOVER_ROLE_LIMIT", 200021),
		//  场景相关

		descriptor.def_enum_value("SCENE", 300000),
		//  重复的场景

		descriptor.def_enum_value("SCENE_DUPLICATE", 300001),
		//  建动态场景时下线

		descriptor.def_enum_value("SCENE_NOOWNER", 300002),
		//  档案错误码

		descriptor.def_enum_value("RECORD", 400000),
		//  数据库错误

		descriptor.def_enum_value("RECORD_ERROR", 400001),
		//  重复名

		descriptor.def_enum_value("RECORD_DUPLICATE_NAME", 400002),
		//  没有名字列

		descriptor.def_enum_value("RECORD_NO_NAMECOLUMN", 400003),
		descriptor.def_enum_value("RECORD_TIMEOUT", 400004),
		//  relayserver错误码

		descriptor.def_enum_value("RELAY", 500000),
		//  系统错误

		descriptor.def_enum_value("RELAY_LOGIN_SYSTEMERROR", 500001),
		//  无效的gamesession

		descriptor.def_enum_value("RELAY_LOGIN_INVALIDSESSION", 500002),
		//  无效的参战者

		descriptor.def_enum_value("RELAY_LOGIN_INVALIDFIGHTER", 500003),
		//  系统错误

		descriptor.def_enum_value("RELAY_RECONNECT_SYSTEMERROR", 500004),
		//  玩家还在线上

		descriptor.def_enum_value("RELAY_RECONNECT_PLAYER_ONLINE", 500005),
		//  无效的gamesession

		descriptor.def_enum_value("RELAY_RECONNECT_INVALIDSESSION", 500006),
		//  无效的参战者

		descriptor.def_enum_value("RELAY_RECONNECT_INVALIDFIGHTER", 500007),
		//  匹配相关

		descriptor.def_enum_value("MATCH", 600000),
		//  系统错误

		descriptor.def_enum_value("MATCH_START_SYSTEMERROR", 600001),
		//  已经在匹配中了

		descriptor.def_enum_value("MATCH_START_REPEAT", 600002),
		//  匹配失败，超时

		descriptor.def_enum_value("MATCH_TIMEOUT", 600003),
		//  不在PK准备区中

		descriptor.def_enum_value("MATCH_START_NOT_IN_PK_PARPARE", 600004),
		//  组队状态不能匹配

		descriptor.def_enum_value("MATCH_START_IN_TEAM", 600005),
		//  未加入武道大会

		descriptor.def_enum_value("MATCH_START_WUDAO_NOT_JOIN", 600006),
		//  武道大会已经完成

		descriptor.def_enum_value("MATCH_START_WUDAO_COMPLETE", 600007),
		//  不在匹配列表中

		descriptor.def_enum_value("MATCH_CANCLE_NOT_MATCHING", 600008),
		//  玩家已经在游戏中了

		descriptor.def_enum_value("MATCH_CANCLE_RACING", 600009),
		//  技能相关

		descriptor.def_enum_value("SKILL", 700000),
		//  ERROR

		descriptor.def_enum_value("SKILL_ERROR", 700001),
		//  保存到数据库失败

		descriptor.def_enum_value("SKILL_SAVE_DB_ERROR", 700002),
		//  没有这个技能

		descriptor.def_enum_value("SKILL_NOT_FOUNT", 700003),
		//  错误的技能类型

		descriptor.def_enum_value("SKILL_TYPE_ERROR", 700004),
		//  SP不够

		descriptor.def_enum_value("SKILL_SP_NOT_ENOUGH", 700005),
		//  移除SP失败

		descriptor.def_enum_value("SKILL_SP_REMOVE_ERROR", 700006),
		//  超过最大等级

		descriptor.def_enum_value("SKILL_MAX_SKILL_LEVEL", 700007),
		//  职业不合法

		descriptor.def_enum_value("SKILL_OCCU_ERROR", 700008),
		//  检查玩家等级

		descriptor.def_enum_value("SKILL_PLAYER_LEVEL", 700009),
		//  前置技能错误

		descriptor.def_enum_value("SKILL_NEED_SKILL_ERROR", 700010),
		//  没有需要的物品或BUFF

		descriptor.def_enum_value("SKILL_NEED_ITEM_ERROR", 700011),
		//  后置技能错误

		descriptor.def_enum_value("SKILL_NEXT_SKILL_ERROR", 700012),
		//  超过最小等级

		descriptor.def_enum_value("SKILL_MIN_SKILL_LEVEL", 700013),
		//  设置相关

		descriptor.def_enum_value("SETTING", 800000),
		//  ERROR

		descriptor.def_enum_value("SETTING_ERROR", 800001),
		//  索引错误

		descriptor.def_enum_value("SETTING_INDEX_ERROR", 800002),
		//  槽位索引错误

		descriptor.def_enum_value("SETTING_SLOT_ERROR", 800003),
		//  技能重复

		descriptor.def_enum_value("SETTING_SKILL_REPEAT", 800004),
		//  技能不存在

		descriptor.def_enum_value("SETTING_SKILL_ERROR", 800005),
		//  地下城相关

		descriptor.def_enum_value("DUNGEON", 900000),
		//  创建比赛失败

		descriptor.def_enum_value("DUNGEON_START_CREATE_RACE_FAILED", 900001),
		//  地下城不存在

		descriptor.def_enum_value("DUNGEON_START_DUNGEON_NOT_EXIST", 900002),
		//  未达到等级要求

		descriptor.def_enum_value("DUNGEON_START_LEVEL_LIMIT", 900003),
		//  没有疲劳了

		descriptor.def_enum_value("DUNGEON_START_NO_FATIGUE", 900004),
		//  不满足进入条件（前置任务，前置关卡等）

		descriptor.def_enum_value("DUNGEON_START_CONDITION", 900005),
		//  难度未开放

		descriptor.def_enum_value("DUNGEON_START_HARD_NOT_OPEN", 900006),
		//  不在选择关卡的场景

		descriptor.def_enum_value("DUNGEON_START_NOT_IN_ENTRY_SCENE", 900007),
		//  开始比赛失败

		descriptor.def_enum_value("DUNGEON_START_RACE_FAILED", 900008),
		//  门票不足

		descriptor.def_enum_value("DUNGEON_START_NO_TICKET", 900009),
		//  没有深渊模式

		descriptor.def_enum_value("DUNGEON_START_NO_HELL_MODE", 900010),
		//  没有足够的深渊票

		descriptor.def_enum_value("DUNGEON_START_NO_HELL_TICKET", 900011),
		//  队伍成员不在线

		descriptor.def_enum_value("DUNGEON_START_TEAM_MEMBER_OFFLINE", 900012),
		//  背包空余位置不足

		descriptor.def_enum_value("DUNGEON_START_BAG_FULL", 900013),
		//  不在开放时间

		descriptor.def_enum_value("DUNGEON_START_NOT_OPEN_TIME", 900014),
		//  次数用完

		descriptor.def_enum_value("DUNGEON_START_NO_TIMES", 900015),
		//  系统错误

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_SYSTEM_ERROR", 900016),
		//  已经离开地下城了

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_NOT_IN_DUNGEON", 900017),
		//  重复进入

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_REPEAT", 900018),
		//  进入不存在的区域

		descriptor.def_enum_value("DUNGEON_ENTER_AREA_NOT_EXIST", 900019),
		//  复活的目标不存在

		descriptor.def_enum_value("DUNGEON_REVIVE_PLAYER_NOT_EXIST", 900020),
		//  重复复活

		descriptor.def_enum_value("DUNGEON_REVIVE_REPEAT", 900021),
		//  没有足够的复活币

		descriptor.def_enum_value("DUNGEON_REVIVE_NOT_ENOUGH_REVIVE_COIN", 900022),
		//  开始关卡匹配失败

		descriptor.def_enum_value("DUNGEON_MATCH_START_FAILED", 900023),
		//  重复开始地下城

		descriptor.def_enum_value("DUNGEON_TEAM_START_VOTE_REPEAT", 900024),
		//  地下城不能组队开始

		descriptor.def_enum_value("DUNGEON_TEAM_TARGET_MUST_SINGLE", 900025),
		//  超过地下城最大人数

		descriptor.def_enum_value("DUNGEON_TEAM_TOO_MANY_MEMBER", 900026),
		//  人数不足，无法开始地下城

		descriptor.def_enum_value("DUNGEON_TEAM_NOT_ENOUGH_MEMBER", 900027),
		//  等待其他人投票

		descriptor.def_enum_value("DUNGEON_TEAM_WAIT_OTHER_VOTE", 900028),
		//  无法购买次数

		descriptor.def_enum_value("DUNGEON_TIMES_CANT_BUY", 900029),
		//  无法购买次数，剩余次数不足

		descriptor.def_enum_value("DUNGEON_TIMES_NO_REMAIN_TIMES", 900030),
		//  无法购买次数，钱不够

		descriptor.def_enum_value("DUNGEON_TIMES_NO_ENOUGH_MONEY", 900031),
		//  开始比赛失败，这种情况下不需要提示

		descriptor.def_enum_value("DUNGEON_TEAM_START_RACE_FAILED", 901001),
		//  道具相关

		descriptor.def_enum_value("ITEM", 1000000),
		//  数据非法,包括各种相关空指正判断

		descriptor.def_enum_value("ITEM_DATA_INVALID", 1000001),
		//  没有操作理由

		descriptor.def_enum_value("ITEM_NO_REASON", 1000002),
		//  item数量非法

		descriptor.def_enum_value("ITEM_NUM_INVALID", 1000003),
		//  添加item背包满

		descriptor.def_enum_value("ITEM_ADD_PACK_FULL", 1000004),
		//  金钱添加达到上限

		descriptor.def_enum_value("ITEM_MONEY_ADD_FULL", 1000005),
		//  使用道具失败

		descriptor.def_enum_value("ITEM_USE_FAIL", 1000006),
		//  不能装备

		descriptor.def_enum_value("ITEM_CAN_NOT_EQUIP", 1000007),
		//  装备加锁

		descriptor.def_enum_value("ITEM_LOCKED", 1000008),
		//  装备所处的包裹错误

		descriptor.def_enum_value("ITEM_PACK_INVALID", 1000009),
		//  背包格子达到上限

		descriptor.def_enum_value("ITEM_PACKSIZE_MAX", 1000010),
		//  道具类别错误

		descriptor.def_enum_value("ITEM_TYPE_INVALID", 1000011),
		//  道具分解失败

		descriptor.def_enum_value("ITEM_DECOMPOSE_FAIL", 1000012),
		//  装备强化等级错误

		descriptor.def_enum_value("ITEM_STRENTH_LV_INVALID", 1000013),
		//  金币不够

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_GOLD", 1000014),
		//  材料不够

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_MAT", 1000015),
		//  装备强化失败无惩罚

		descriptor.def_enum_value("ITEM_STRENTH_FAIL", 1000016),
		//  装备强化失败扣等级

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_MINUS", 1000017),
		//  装备强化失败等级归零

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_ZERO", 1000018),
		//  装备强化失败破碎

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_BROKE", 1000019),
		//  存仓库空间满了

		descriptor.def_enum_value("ITEM_PUSH_STORAGE_FULL", 1000020),
		//  存取仓库数量错误

		descriptor.def_enum_value("ITEM_STORAGE_NUM_ERR", 1000021),
		//  装备职业不符

		descriptor.def_enum_value("ITEM_EQUIP_OCCU", 1000022),
		//  装备等级不符

		descriptor.def_enum_value("ITEM_EQUIP_LV", 1000023),
		//  装备强化失败扣2级

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_TWO", 1000024),
		//  装备强化失败扣2级

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_THREE", 1000025),
		//  装备强化失败扣4级

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_FOUR", 1000026),
		//  点券不够

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_POINT", 1000027),
		//  强化类型错误(称号)addedbyhuchenhui2016.06.30

		descriptor.def_enum_value("ITEM_STRENTH_FAIL_TITLE", 1000028),
		//  装备不能分解

		descriptor.def_enum_value("ITEM_CNA_NOT_DECOMPOSE", 1000029),
		//  道具使用CD中

		descriptor.def_enum_value("ITEM_USE_CD", 1000030),
		//  封装次数达到上限

		descriptor.def_enum_value("ITEM_SEAL_COUNT_MAX", 1000031),
		//  装备已经是封装了

		descriptor.def_enum_value("ITEM_ALREADY_SEAL", 1000032),
		//  装备封装品质不符

		descriptor.def_enum_value("ITEM_SEAL_QUALITY_ERR", 1000033),
		//  勇者之魂不够

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_WARRIOR_SOUL", 1000034),
		//  决斗币不够

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_PKCOIN", 1000035),
		//  附魔部位错误

		descriptor.def_enum_value("ITEM_ADDMAGIC_PART_ERR", 1000036),
		//  附魔卡合成品质不同

		descriptor.def_enum_value("ITEM_MAGCARD_COMP_DIF_COLOR", 1000037),
		//  一键分解所需等级不够

		descriptor.def_enum_value("ITEM_ONEKEY_DECOMPOSE_LV_NOT_ENOUGH", 1000038),
		//  开罐子日金钱次数已满

		descriptor.def_enum_value("ITEM_OPEN_JAR_DAYCOUNT", 1000039),
		//  不能出售

		descriptor.def_enum_value("ITEM_NOT_SELL", 1000040),
		//  出售物品不存在

		descriptor.def_enum_value("ITEM_SELL_ITEM_NOT_EXIST", 1000041),
		//  公会贡献不够

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_GUILD_CONTRI", 1000042),
		//  使用道具buff已经存在

		descriptor.def_enum_value("ITEM_USE_BUFFALREADYEXIST", 1000043),
		//  货币不足

		descriptor.def_enum_value("ITEM_NOT_ENOUGH_MONEY", 1000044),
		//  强化券等级错误

		descriptor.def_enum_value("ITEM_STRTICKET_LV_ERR", 1000045),
		//  强化券扣除失败

		descriptor.def_enum_value("ITEM_STRTICKET_REDUCE_ERR", 1000046),
		//  道具日使用次数完了

		descriptor.def_enum_value("ITEM_DAYUSENUM", 1000047),
		//  强化券强化失败

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
		//  地下城不能使用该道具

		descriptor.def_enum_value("ITEM_CAN_NOT_USE_IN_DUNGEON", 1000054),
		//  城镇内不能使用该道具

		descriptor.def_enum_value("ITEM_CAN_NOT_USE_IN_TOWN", 1000055),
		//  道具废弃

		descriptor.def_enum_value("ITEM_ABANDON", 1000056),
		//  商店相关

		descriptor.def_enum_value("SHOP", 1100000),
		//  商店查询错误

		descriptor.def_enum_value("SHOP_QUERY_ERR", 1100001),
		//  商店刷新错误

		descriptor.def_enum_value("SHOP_REFRESH_ERR", 1100002),
		//  商店购买错误

		descriptor.def_enum_value("SHOP_BUY_ERR", 1100003),
		//  商店购买金币不足

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_GOLD", 1100004),
		//  商店购买点券不足

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_POINT", 1100005),
		//  商店购买道具不足

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_ITEM", 1100006),
		//  商店购买背包空间不足

		descriptor.def_enum_value("SHOP_BUY_NOT_ENOUGH_PACKSIZE", 1100007),
		//  商店购买售罄

		descriptor.def_enum_value("SHOP_BUY_SALE_OUT", 1100008),
		//  商店刷新点券不足

		descriptor.def_enum_value("SHOP_REFRESH_NOT_ENOUGH_MONEY", 1100009),
		//  死亡塔层数不够

		descriptor.def_enum_value("SHOP_NOT_ENOUGH_TOWER_LEVEL", 1100010),
		//  角斗场积分不足

		descriptor.def_enum_value("SHOP_NOT_ENOUGH_DUEL_POINT", 1100011),
		//  商店刷新次数不足

		descriptor.def_enum_value("SHOP_REFRESH_COUNT", 1100012),
		//  公会商店不存在

		descriptor.def_enum_value("SHOP_GUIlD_SHOP_NOT_EXIST", 1100013),
		//  工会商店等级不足

		descriptor.def_enum_value("SHOP_GUIlD_NOT_ENOUGH_LV", 1100014),
		//  邮件相关

		descriptor.def_enum_value("MAIL", 1200000),
		//  邮件系统错误

		descriptor.def_enum_value("MAIL_ERROR", 1200001),
		//  标题错误

		descriptor.def_enum_value("MAIL_TITLE_ERROR", 1200002),
		//  标题长度错误

		descriptor.def_enum_value("MAIL_TITLE_LENGTH_ERROR", 1200003),
		//  内容错误

		descriptor.def_enum_value("MAIL_CONTENT_ERROR", 1200004),
		//  内容长度错误

		descriptor.def_enum_value("MAIL_CONTENT_LENGTH_ERROR", 1200005),
		//  发件人字符串错误

		descriptor.def_enum_value("MAIL_SENDER_NAME_ERROR", 1200006),
		//  发件人字符串长度错误

		descriptor.def_enum_value("MAIL_SENDER_NAME_LENGTH_ERROR", 1200007),
		//  奖励错误

		descriptor.def_enum_value("MAIL_REWARD_ERROR", 1200008),
		//  组队相关

		descriptor.def_enum_value("TEAM", 1300000),
		//  组队系统错误

		descriptor.def_enum_value("TEAM_ERROR", 1300001),
		//  创建队伍，已经有队伍了

		descriptor.def_enum_value("TEAM_CREATE_TEAM_HAS_TEAM", 1300002),
		//  创建队伍，无效的队伍目标

		descriptor.def_enum_value("TEAM_CREATE_TEAM_INVALID_TARGET", 1300003),
		//  加入队伍，超时

		descriptor.def_enum_value("TEAM_JOIN_TIMEOUT", 1300004),
		//  加入队伍，队伍不存在

		descriptor.def_enum_value("TEAM_JOIN_TEAM_UNEXIST", 1300005),
		//  加入队伍，队伍满

		descriptor.def_enum_value("TEAM_JOIN_TEAM_FULL", 1300006),
		//  加入队伍，队长离线

		descriptor.def_enum_value("TEAM_JOIN_TEAM_MASTER_OFFLINE", 1300007),
		//  加入队伍，已经有队伍了

		descriptor.def_enum_value("TEAM_JOIN_TEAM_HAS_TEAM", 1300008),
		//  加入队伍，密码错误

		descriptor.def_enum_value("TEAM_JOIN_TEAM_PASSWD_ERROR", 1300009),
		//  加入队伍，队伍有密码

		descriptor.def_enum_value("TEAM_JOIN_TEAM_HAS_PASSWD", 1300010),
		//  加入队伍，等级不足

		descriptor.def_enum_value("TEAM_JOIN_LEVEL_LIMIT", 1300011),
		//  密码长度不对

		descriptor.def_enum_value("TEAM_PASSWD_ERROR_LENGTH", 1300012),
		//  密码只能是数字

		descriptor.def_enum_value("TEAM_PASSWD_ONLY_NUM", 1300013),
		//  名字太长

		descriptor.def_enum_value("TEAM_NAME_TOO_LONG", 1300014),
		//  无效的名字

		descriptor.def_enum_value("TEAM_NAME_INVALID", 1300015),
		//  无效的目标

		descriptor.def_enum_value("TEAM_TARGET_INVALID", 1300016),
		//  切换目标失败，人数太多

		descriptor.def_enum_value("TEAM_TOO_MANY_PLAYER", 1300017),
		//  处理申请者，你不是队长

		descriptor.def_enum_value("TEAM_REPLY_NOT_MASTER", 1300018),
		//  处理申请者，玩家不在线

		descriptor.def_enum_value("TEAM_REPLY_PLAYER_OFFLINE", 1300019),
		//  处理申请者，该玩家未申请加入

		descriptor.def_enum_value("TEAM_REPLY_PLAYER_INVALID", 1300020),
		//  处理申请者，队伍已满

		descriptor.def_enum_value("TEAM_REPLY_TEAM_FULL", 1300021),
		//  邀请玩家，自己没有队伍

		descriptor.def_enum_value("TEAM_INVITE_NO_TEAM", 1300022),
		//  邀请玩家，自己不是队长

		descriptor.def_enum_value("TEAM_INVITE_NOT_TEAM_MASTER", 1300023),
		//  邀请玩家，队伍已满

		descriptor.def_enum_value("TEAM_INVITE_TEAM_FULL", 1300024),
		//  邀请玩家，队伍正在战斗中

		descriptor.def_enum_value("TEAM_INVITE_TEAM_IN_RACE", 1300025),
		//  邀请玩家，对方不在线

		descriptor.def_enum_value("TEAM_INVITE_TARGET_OFFLINE", 1300026),
		//  邀请玩家，对方已经在队伍中

		descriptor.def_enum_value("TEAM_INVITE_TARGET_IN_TEAM", 1300027),
		//  邀请玩家，目标正忙

		descriptor.def_enum_value("TEAM_INVITE_TARGET_BUSY", 1300028),
		//  邀请玩家，重复邀请

		descriptor.def_enum_value("TEAM_INVITE_REPEAT", 1300029),
		//  加入队伍，队伍正在战斗中

		descriptor.def_enum_value("TEAM_JOIN_RACING", 1300030),
		//  等级不足

		descriptor.def_enum_value("TEAM_MIN_LEVEL", 1300031),
		//  邀请玩家，对方等级不足

		descriptor.def_enum_value("TEAM_INVITE_TARGET_MIN_LEVEL", 1300032),
		//  邀请玩家，太频繁

		descriptor.def_enum_value("TEAM_INVITE_FREQUENTLY", 1300033),
		//  开始匹配失败，这种情况不需要提示

		descriptor.def_enum_value("TEAM_MATCH_START_FAILED", 1301001),
		//  只有队长能操作

		descriptor.def_enum_value("TEAM_MATCH_ONLY_MASTER", 1301002),
		//  开始匹配失败，已经在匹配中

		descriptor.def_enum_value("TEAM_MATCH_START_IN_MATCHING", 1301003),
		//  取消匹配失败，不在匹配中

		descriptor.def_enum_value("TEAM_MATCH_CANCEL_NOT_IN_MATCHING", 1301004),
		//  次元石相关

		descriptor.def_enum_value("WARPSTONE", 1400000),
		//  银币不够

		descriptor.def_enum_value("WARP_STONE_SILVER_ERROR", 1400001),
		//  没有解锁

		descriptor.def_enum_value("WARP_STONE_UNLOCK_ERROR", 1400002),
		//  到达最大等级

		descriptor.def_enum_value("WARP_STONE_LEVEL_MAX", 1400003),
		//  次元石没找到

		descriptor.def_enum_value("WARP_STONE_NOT_FOUNT", 1400004),
		//  次元石解锁等级不够

		descriptor.def_enum_value("WARP_STONE_PLAYER_LEVEL_ERROR", 1400005),
		//  能量石没有找到

		descriptor.def_enum_value("ENERGY_STONE_NOT_FOUNT", 1400006),
		//  能量石不够

		descriptor.def_enum_value("ENERGY_STONE_NOT_ENOUGH", 1400007),
		//  能量石类型错误

		descriptor.def_enum_value("ENERGY_STONE_TYPE_ERROR", 1400008),
		//  随从相关

		descriptor.def_enum_value("RETINUE", 1500000),
		//  没有对应的玩家

		descriptor.def_enum_value("RETINUE_NOT_PLAYER", 1500001),
		//  随从数据表不存在

		descriptor.def_enum_value("RETINUE_DATA_NOT_EXIST", 1500002),
		//  随从不存在

		descriptor.def_enum_value("RETINUE_NOT_EXIST", 1500003),
		//  随从已经存在

		descriptor.def_enum_value("RETINUE_IS_EXIST", 1500004),
		//  玩家等级不够

		descriptor.def_enum_value("RETINUE_PLAYER_LEVEL", 1500005),
		//  洗练物品不够

		descriptor.def_enum_value("RETINUE_NOT_ITEM", 1500006),
		//  解锁物品不够

		descriptor.def_enum_value("RETINUE_UNLOCK_NOT_ITEM", 1500007),
		//  随从等级不存在.

		descriptor.def_enum_value("RETINUE_LEVEL_DATA_NOT_EXIST", 1500008),
		//  升级物品不够

		descriptor.def_enum_value("RETINUE_LEVEL_NOT_ITEM", 1500009),
		//  设置随从位置错误

		descriptor.def_enum_value("RETINUE_RETINUE_INDEX_ERROR", 1500010),
		//  勇士之魂不够

		descriptor.def_enum_value("RETINUE_WARRIOR_SOUL_ERROR", 1500011),
		//  不能超过最大星级

		descriptor.def_enum_value("RETINUE_MAX_STAR_ERROR", 1500012),
		//  没有这个星级

		descriptor.def_enum_value("RETINUE_STAR_LEVEL_NOT_EXIST", 1500013),
		//  升星碎片不够

		descriptor.def_enum_value("RETINUE_UP_STAR_NOT_ITEM", 1500014),
		//  没有可洗练的技能

		descriptor.def_enum_value("RETINUE_NOT_CHANGE_SKILL_ERROR", 1500015),
		//  没有对应的洗练库

		descriptor.def_enum_value("RETINUE_NOT_SKILL_GROUP_ERROR", 1500016),
		//  洗练库是一个环

		descriptor.def_enum_value("RETINUE_SKILL_GROUP_RING_ERROR", 1500017),
		//  升级类型不正确

		descriptor.def_enum_value("RETINUE_UP_TYPE_ERROR", 1500018),
		//  没有主随从

		descriptor.def_enum_value("RETINUE_NOT_MAIN_ERROR", 1500019),
		//  无法下阵随从

		descriptor.def_enum_value("RETINUE_NOT_DOWN_ERROR", 1500020),
		//  重连

		descriptor.def_enum_value("RECONNECT", 1600000),
		//  角色数据已经删除

		descriptor.def_enum_value("RECONNECT_PLAYER_DELETED", 1600001),
		//  无效的sequence

		descriptor.def_enum_value("RECONNECT_INVALID_SEQUENCE", 1600002),
		//  账号还在线

		descriptor.def_enum_value("RECONNECT_PLAYER_ONLINE", 1600003),
		//  错误的连接

		descriptor.def_enum_value("RECONNECT_NO_CONNECTION", 1600004),
		//  商城

		descriptor.def_enum_value("MALL", 1700000),
		//  商城商品查询失败

		descriptor.def_enum_value("MALL_QUERY_FAIL", 1700001),
		//  购买数量错误

		descriptor.def_enum_value("MALL_BUYNUM_ERR", 1700002),
		//  找不到要购买的物品

		descriptor.def_enum_value("MALL_CANNOT_FIND_ITEM", 1700003),
		//  找不到要触发的限时礼包

		descriptor.def_enum_value("MALL_CANNOT_FIND_GIFT_PACK", 1700004),
		//  商城限时礼包已触发

		descriptor.def_enum_value("MALL_GIFT_PACK_ACTIVATED", 1700005),
		//  玩家相关

		descriptor.def_enum_value("PLAYER", 1800000),
		//  转职等级不够

		descriptor.def_enum_value("PLAYER_TRANSFORM_OCCU_LEVEL_ERROR", 1800001),
		//  觉醒等级不够

		descriptor.def_enum_value("PLAYER_AWAKEN_LEVEL_ERROR", 1800002),
		//  已经觉醒

		descriptor.def_enum_value("PLAYER_AWAKEN_EXIST", 1800003),
		//  还未转职

		descriptor.def_enum_value("PLAYER_AWAKEN_NOT_TRANSFORM_OCCU", 1800004),
		//  vip购买时,vip等级错误

		descriptor.def_enum_value("PLAYER_VIP_BUY_LEVEL_ERROR", 1800005),
		//  vip购买礼包,点卷不够

		descriptor.def_enum_value("PLAYER_VIP_BUY_GIFT_ENOUGH_POINT", 1800006),
		//  vip礼包为空

		descriptor.def_enum_value("PLAYER_VIP_GIFT_EMPTY", 1800007),
		//  vip购买礼包背包空间不足

		descriptor.def_enum_value("PLAYER_VIP_BUY_NOT_ENOUGH_PACKSIZE", 1800008),
		//  vip购买礼包消耗点卷失败

		descriptor.def_enum_value("PLAYER_VIP_BUY_REMOVE_POINT_ERROR", 1800009),
		//  vip已经购买这个礼包

		descriptor.def_enum_value("PLAYER_VIP_BUY_ALREADY", 1800010),
		//  vip等级不足

		descriptor.def_enum_value("PLAYER_VIPLV_NOT_ENOUGH", 1800011),
		//  快速购买

		descriptor.def_enum_value("QUICKBUY", 1900000),
		//  系统错误

		descriptor.def_enum_value("QUICK_BUY_SYSTEM_ERROR", 1900001),
		//  上一个事务还没结束

		descriptor.def_enum_value("QUICK_BUY_LAST_TRANS_NOT_FINISH", 1900002),
		//  超时

		descriptor.def_enum_value("QUICK_BUY_TIMEOUT", 1900003),
		//  无效的类型

		descriptor.def_enum_value("QUICK_BUY_INVALID_TYPE", 1900004),
		//  钱不够

		descriptor.def_enum_value("QUICK_BUY_NOT_ENOUGH_MONEY", 1900005),
		//  道具不存在

		descriptor.def_enum_value("QUICK_BUY_INVALID_ITEM", 1900006),
		//  道具数量不正确

		descriptor.def_enum_value("QUICK_BUY_INVALID_NUM", 1900007),
		//  背包空间不足

		descriptor.def_enum_value("QUICK_BUY_BAG_FULL", 1900008),
		//  不在比赛中

		descriptor.def_enum_value("QUICK_BUY_REVIVE_NOT_IN_RACE", 1900009),
		//  任务相关

		descriptor.def_enum_value("TASK", 2000000),
		//  提交任务物品类型错误

		descriptor.def_enum_value("TASK_SET_ITEM_TASK_TYPE_ERROR", 2000001),
		//  提交错误的任务物品

		descriptor.def_enum_value("TASK_SET_ITEM_ERROR", 2000002),
		//  提交的任务物品数量不够

		descriptor.def_enum_value("TASK_SET_ITEM_NUM_ERROR", 2000003),
		//  任务不存在

		descriptor.def_enum_value("TASK_NOT_EXIST", 2000004),
		//  任务脚本不存在

		descriptor.def_enum_value("TASK_SCRIPT_NOT_EXIST", 2000005),
		//  任务不再接取状态

		descriptor.def_enum_value("TASK_NOT_UNFINISH", 2000006),
		//  任务类型错误

		descriptor.def_enum_value("TASK_TYPE_ERROR", 2000007),
		//  循环任务不存在

		descriptor.def_enum_value("TASK_CYCLE_NOT_EXIST", 2000008),
		//  消耗资源不足

		descriptor.def_enum_value("TASK_CYCLE_REFRESH_NOT_CONSUME", 2000009),
		//  每日任务积分奖励箱子不存在

		descriptor.def_enum_value("TASK_DATILY_TASK_SCORE_BOX_NOT_FOUNT", 2000010),
		//  每日任务积分奖励积分不够

		descriptor.def_enum_value("TASK_DATILY_TASK_SCORE_BOX_SCORE", 2000011),
		//  每日任务积分奖励已经领取

		descriptor.def_enum_value("TASK_DATILY_TASK_SCORE_BOX_RECEIVE", 2000012),
		//  死亡之塔

		descriptor.def_enum_value("TOWER", 2100000),
		//  没有重置次数

		descriptor.def_enum_value("TOWER_RESET_NO_REMAIN_COUNT", 2100001),
		//  正在扫荡中

		descriptor.def_enum_value("TOWER_DOING_WIPEOUT", 2100002),
		//  没有层数去扫荡

		descriptor.def_enum_value("TOWER_NO_FLOOR_WIPEOUT", 2100003),
		//  没有在扫荡中

		descriptor.def_enum_value("TOWER_NOT_DOING_WIPEOUT", 2100004),
		//  扫荡未完成

		descriptor.def_enum_value("TOWER_WIPEOUT_NOT_FINISH", 2100005),
		//  扫荡已完成

		descriptor.def_enum_value("TOWER_WIPEOUT_FINISHED", 2100006),
		//  没有足够的点劵

		descriptor.def_enum_value("TOWER_WIPEOUT_NOT_ENOUGH_POINT", 2100007),
		//  未通过该层

		descriptor.def_enum_value("TOWER_AWARD_NOT_PASS_FLOOR", 2100008),
		//  无效的层数，没有对应奖励

		descriptor.def_enum_value("TOWER_AWARD_INVALID_FLOOR", 2100009),
		//  重复领奖

		descriptor.def_enum_value("TOWER_AWARD_REPEAT_RECEIVE", 2100010),
		//  不需要重置

		descriptor.def_enum_value("TOWER_NO_NEED_RESET", 2100011),
		//  没有VIP权限

		descriptor.def_enum_value("TOWER_RESET_NO_VIP_PRIVILEGE", 2100012),
		//  PK相关

		descriptor.def_enum_value("PK", 2200000),
		//  组队中

		descriptor.def_enum_value("PK_CHALLENGE_IN_TEAM", 2200001),
		//  不在PK准备区中

		descriptor.def_enum_value("PK_CHALLENGE_NOT_IN_PK_PREPARE", 2200002),
		//  目标在忙

		descriptor.def_enum_value("PK_CHALLENGE_TARGET_BUSY", 2200003),
		//  目标不在线

		descriptor.def_enum_value("PK_CHALLENGE_TARGET_NOT_ONLINE", 2200004),
		//  重复挑战

		descriptor.def_enum_value("PK_CHALLENGE_REPEAT", 2200005),
		//  等级太低

		descriptor.def_enum_value("PK_CHALLENGE_LEVEL_LIMIT", 2200006),
		//  系统错误

		descriptor.def_enum_value("PK_WUDAO_SYSTEM_ERROR", 2200007),
		//  活动未开始

		descriptor.def_enum_value("PK_WUDAO_ACTIVITY_NOT_OPEN", 2200008),
		//  不满足活动开启条件

		descriptor.def_enum_value("PK_WUDAO_ACTIVITY_COND", 2200009),
		//  没有门票

		descriptor.def_enum_value("PK_WUDAO_NO_TICKET", 2200010),
		//  已经参加了

		descriptor.def_enum_value("PK_WUDAO_JOINED", 2200011),
		//  武道大会未完成

		descriptor.def_enum_value("PK_WUDAO_NOT_COMPLETE", 2200012),
		//  公会

		descriptor.def_enum_value("GUILD", 2300000),
		//  没有对应的权限

		descriptor.def_enum_value("GUILD_NO_POWER", 2300001),
		//  公会已满

		descriptor.def_enum_value("GUILD_FULL", 2300002),
		//  不在公会中

		descriptor.def_enum_value("GUILD_NOT_IN_GUILD", 2300003),
		//  系统错误

		descriptor.def_enum_value("GUILD_SYS_ERROR", 2300004),
		//  没有足够的钱

		descriptor.def_enum_value("GUILD_NOT_ENOUGH_MONEY", 2300005),
		//  次数用完

		descriptor.def_enum_value("GUILD_NOT_ENOUGH_TIMES", 2300006),
		//  公会战期间不能离开公会

		descriptor.def_enum_value("GUILD_BATTLE_NOT_LEAVE", 2300007),
		//  名字重复

		descriptor.def_enum_value("GUILD_NAME_REPEAT", 2301001),
		//  名字中有屏蔽字

		descriptor.def_enum_value("GUILD_NAME_INVALID", 2301002),
		//  宣言中有屏蔽字

		descriptor.def_enum_value("GUILD_DECLARATION_INVALID", 2301003),
		//  公告中有屏蔽字

		descriptor.def_enum_value("GUILD_ANNOUNCEMENT_INVALID", 2301004),
		//  公告中有屏蔽字

		descriptor.def_enum_value("GUILD_MAIL_INVALID", 2301005),
		//  重复创建

		descriptor.def_enum_value("GUILD_CREATE_REPEAT", 2302001),
		//  已经在公会中

		descriptor.def_enum_value("GUILD_CREATE_ALREADY_HAS_GUILD", 2302002),
		//  无效的公会名

		descriptor.def_enum_value("GUILD_CREATE_INVALID_NAME", 2302003),
		//  无效的公会宣言

		descriptor.def_enum_value("GUILD_CREATE_INVALID_DECLARATION", 2302004),
		//  没有足够的钱

		descriptor.def_enum_value("GUILD_CREATE_NOT_ENOUGH_MONEY", 2302005),
		//  等级不足

		descriptor.def_enum_value("GUILD_CREATE_MIN_LEVEL", 2302006),
		//  刚离开公会，还在冷却时间中

		descriptor.def_enum_value("GUILD_CREATE_COLDTIME", 2302007),
		//  公会名为空

		descriptor.def_enum_value("GUILD_CREATE_NAME_EMPTY", 2302008),
		//  公会宣言为空

		descriptor.def_enum_value("GUILD_CREATE_DECLARATION_EMPTY", 2302009),
		//  重复加入

		descriptor.def_enum_value("GUILD_JOIN_REPEAT", 2303001),
		//  已经在公会中

		descriptor.def_enum_value("GUILD_JOIN_ALREADY_HAS_GUILD", 2303002),
		//  等级不足

		descriptor.def_enum_value("GUILD_JOIN_MIN_LEVEL", 2303003),
		//  公会不存在

		descriptor.def_enum_value("GUILD_JOIN_NOT_EXIST", 2303004),
		//  刚离开公会，还在冷却时间中

		descriptor.def_enum_value("GUILD_JOIN_COLDTIME", 2303005),
		//  公会申请列表已满

		descriptor.def_enum_value("GUILD_JOIN_REQUEST_QUEUE_FULL", 2303006),
		//  公会正在解散

		descriptor.def_enum_value("GUILD_JOIN_IN_DISMISS", 2303007),
		//  先转让会长

		descriptor.def_enum_value("GUILD_LEAVE_TRANSFER_LEADER", 2304001),
		//  没有这个请求者

		descriptor.def_enum_value("GUILD_REPLY_REQUESTER_UNEXIST", 2305001),
		//  已经在其他公会中了

		descriptor.def_enum_value("GUILD_REPLY_IN_OTHER_GUILD", 2305002),
		//  刚离开公会，还在冷却时间中

		descriptor.def_enum_value("GUILD_REPLY_COLDTIME", 2305003),
		//  目标职务人数已满

		descriptor.def_enum_value("GUILD_POST_FULL", 2306001),
		//  需要会长连续7天不在线

		descriptor.def_enum_value("GUILD_POST_LEADER_LEAVE_TIME", 2306002),
		//  超过主城等级，先升级主城等级

		descriptor.def_enum_value("GUILD_BUILDING_UPGRADE_MAIN_FIRST", 2307001),
		//  已经到满级

		descriptor.def_enum_value("GUILD_BUILDING_TOP_LEVEL", 2307002),
		//  帮会资金不足

		descriptor.def_enum_value("GUILD_BUILDING_NOT_ENOUGH_FUND", 2307003),
		//  剩余次数不足

		descriptor.def_enum_value("GUILD_DONATE_NO_REMAIN_TIMES", 2308001),
		//  还在CD中

		descriptor.def_enum_value("GUILD_EXCHANGE_CD", 2309001),
		//  剩余次数不足

		descriptor.def_enum_value("GUILD_EXCHANGE_NO_REMAIN_TIMES", 2309002),
		//  贡献不足

		descriptor.def_enum_value("GUILD_EXCHANGE_NOT_ENOUGH_CONTRI", 2309003),
		//  已经到达最高等级

		descriptor.def_enum_value("GUILD_SKILL_TOP_LEVEL", 2310001),
		//  正在解散中

		descriptor.def_enum_value("GUILD_DISMISS_IN_DISMISS", 2311001),
		//  不在解散中

		descriptor.def_enum_value("GUILD_NOT_IN_DISMISS", 2311002),
		//  圆桌已满

		descriptor.def_enum_value("GUILD_TABLE_FULL", 2312001),
		//  位子已经被占

		descriptor.def_enum_value("GUILD_TABLE_SEAT_HAS_PLAYER", 2312002),
		//  已经在位子上了

		descriptor.def_enum_value("GUILD_TABLE_REPEAT", 2312003),
		//  无效的位子

		descriptor.def_enum_value("GUILD_TABLE_SEAT_INVALID", 2312004),
		//  膜拜类型错误

		descriptor.def_enum_value("GUILD_ORZ_INVALID_TYPE", 2313001),
		//  没有这个VIP权限

		descriptor.def_enum_value("GUILD_ORZ_VIP_PRIVILEGE", 2313002),
		//  没有找到玩家

		descriptor.def_enum_value("GUILD_BATTLE_NOT_PLAYER", 2314001),
		//  玩家没有公会

		descriptor.def_enum_value("GUILD_BATTLE_NOT_EXIST", 2314002),
		//  玩家不是公会成员

		descriptor.def_enum_value("GUILD_BATTLE_NOT_IS_MEMBER", 2314003),
		//  公会战报名公会找不到

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_GUILD_NOT_FIND", 2314004),
		//  玩家报名没有权限

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_NOT_POWER", 2314005),
		//  公会战没有开始报名

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_NOT_ENROLL", 2314006),
		//  公会战报名人数已满

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_FULL", 2314007),
		//  公会战报名公会等级不够

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_GUILD_LEVEL", 2314008),
		//  公会战报名占领领地等级太低

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_LOW", 2314009),
		//  公会战报名占领领地等级太高

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_TERRITORY_LEVEL_HIGH", 2314010),
		//  公会战不能重复报名

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_EXIST", 2314011),
		//  公会战报名正在处理事务

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_TRANSACTION", 2314012),
		//  领地不存在或者公会没有报名

		descriptor.def_enum_value("GUILD_BATTLE_TERRITORY_NOT_EXIST", 2314013),
		//  公会没有报名

		descriptor.def_enum_value("GUILD_BATTLE_NOT_ENROLL", 2314014),
		//  公会战鼓舞已经最高次数

		descriptor.def_enum_value("GUILD_BATTLE_INSPIRE_MAX_COUNT", 2314015),
		//  公会战鼓舞道具不足

		descriptor.def_enum_value("GUILD_BATTLE_INSPIRE_ITEM", 2314016),
		//  公会战鼓舞正在处理事务

		descriptor.def_enum_value("GUILD_BATTLE_INSPIRE_TRANSACTION", 2314017),
		//  公会战成员匹配次数不足

		descriptor.def_enum_value("GUILD_BATTLE_MEMBER_MATCH_COUNT", 2314018),
		//  战斗结束找不到玩家

		descriptor.def_enum_value("GUILD_BATTLE_RACE_END_NOT_MEMBER", 2314019),
		//  公会战已经结束

		descriptor.def_enum_value("GUILD_BATTLE_IS_END", 2314020),
		//  领取奖励找不到玩家

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_NOT_MEMBER", 2314021),
		//  领取奖励没有找到数据项

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_DATA_ERROR", 2314022),
		//  领取奖励积分不足

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_SCORE_ERROR", 2314023),
		//  奖励已经领取

		descriptor.def_enum_value("GUILD_BATTLE_GIVE_REWARD_ALREADY", 2314024),
		//  公会战上一场战斗没有结束

		descriptor.def_enum_value("GUILD_BATTLE_RACE_NOT_END", 2314025),
		//  公会战匹配正在处理事务

		descriptor.def_enum_value("GUILD_BATTLE_MATCH_TRANSACTION", 2314026),
		//  公会战报名不能解散

		descriptor.def_enum_value("GUILD_BATTLE_ENROLL_NOT_DISMISS", 2314027),
		//  公会战解散中不能报名

		descriptor.def_enum_value("GUILD_BATTLE_DISMISS_NOT_ENROLL", 2314028),
		//  道具事务

		descriptor.def_enum_value("ITEM_TRANS", 2400000),
		//  失败

		descriptor.def_enum_value("ITEM_TRANS_FAILED", 2400001),
		//  钱不够

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_MONEY", 2400002),
		//  复活币不足

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_REVIVE_COIN", 2400003),
		//  道具不足

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_ITEM", 2400004),
		//  次数不足

		descriptor.def_enum_value("ITEM_TRANS_NOT_ENOUGH_TIMES", 2400005),
		//  红包

		descriptor.def_enum_value("RED_PACKET", 2500000),
		//  系统错误

		descriptor.def_enum_value("RED_PACKET_SYS_ERROR", 2500001),
		//  无效的红包

		descriptor.def_enum_value("RED_PACKET_INVALID", 2500002),
		//  红包不存在

		descriptor.def_enum_value("RED_PACKET_NOT_EXIST", 2500003),
		//  红包不是你的

		descriptor.def_enum_value("RED_PACKET_NOT_OWNER", 2500004),
		//  红包已经发出去了

		descriptor.def_enum_value("RED_PACKET_ALREADY_SEND", 2500005),
		//  公会红包，不在公会中

		descriptor.def_enum_value("RED_PACKET_NOT_IN_GUILD", 2500006),
		//  红包无法打开

		descriptor.def_enum_value("RED_PACKET_CANT_OPEN", 2500007),
		//  红包已被抢完

		descriptor.def_enum_value("RED_PACKET_EMPTY", 2500008),
		//  红包个数错误

		descriptor.def_enum_value("RED_PACKET_INVALID_NUM", 2500009),
		//  红包名字错误

		descriptor.def_enum_value("RED_PACKET_INVALID_NAME", 2500010),
		//  充值

		descriptor.def_enum_value("BILLING", 2600000),
		//  玩家不在线

		descriptor.def_enum_value("BILLING_PLAYER_OFFLINE", 2600001),
		//  货物不存在

		descriptor.def_enum_value("BILLING_GOODS_UNEXIST", 2600002),
		//  没有次数了

		descriptor.def_enum_value("BILLING_GOODS_NUM_LIMIT", 2600003),
		//  月卡时间未到无法购买

		descriptor.def_enum_value("BILLING_GOODS_MONTH_CARD_CANT_BUY", 2600004),
	}
)

