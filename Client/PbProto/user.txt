
ÿ,

user.protouser"∏

NoticeInfo
id (Rid
infotype (Rinfotype
gameid (Rgameid
content (	Rcontent
userid (Ruserid
nickname (	Rnickname
endtime (	Rendtime"6
NoticeSyncPack$
pack (2.user.NoticeInfoRpack"
UserInfoReq
uid (Ruid"Ö
UserInfoRep
uid (Ruid
nickname (	Rnickname
money (Rmoney
gold (	Rgold
exp (Rexp
vipexp (Rvipexp
sex (Rsex
imageid (	Rimageid$
havesecondpwd	 (Rhavesecondpwd
	isbinding
 (R	isbinding
honor (:-1Rhonor
bankgold (	Rbankgold
diamond (	Rdiamond
	avatarurl (	R	avatarurl
ipaddr (	Ripaddr"[
ModifyUserInfoReq
nickname (	Rnickname
sex (Rsex
imageid (	Rimageid"+
ModifyUserInfoRep
result (Rresult"J
ModifyLoginPasswordReq
old_pwd (	RoldPwd
new_pwd (	RnewPwd"I
ModifyLoginPasswordRep
result (Rresult
new_pwd (	RnewPwd"
CheckReconnectReq"w
CheckReconnectRep
roomid (Rroomid
tableid (Rtableid
seatid (Rseatid
private (Rprivate"
RoomListReq"õ
RoomListRep
config (	Rconfig7
players (2.user.RoomListRep.RoomPlayersRplayers;
RoomPlayers
roomid (Rroomid
count (Rcount"&
EnterRoomReq
roomid (Rroomid">
EnterRoomRep
result (Rresult
roomid (Rroomid"4
PrivateInfoReq"
onlygameinfo (Ronlygameinfo"◊
PrivateInfoRep
	privateid (R	privateid3
infos	 (2.user.PrivateInfoRep.GameInfoRinfosr
GameInfo
gameid (Rgameid
roundopt (Rroundopt
diamonds (Rdiamonds
params	 (Rparams"∑
CreatePrivateReq
gameid (Rgameid3
conf (2.user.CreatePrivateReq.GameConfRconfV
GameConf
round (Rround
	forothers (R	forothers
params	 (Rparams"H
CreatePrivateRep
result (Rresult
	privateid (R	privateid"
CreatePrivateInfoReq"˘
CreatePrivateInfoRep9
infos (2#.user.CreatePrivateInfoRep.GameInfoRinfos2

PlayerInfo
uid (Ruid
name (	RnameÒ
GameInfo
gameid (Rgameid
	privateid (R	privateid
curround (Rcurround
allround (Rallround
params (Rparams

createtime (	R
createtime?
players	 (2%.user.CreatePrivateInfoRep.PlayerInfoRplayers"/
EnterPrivateReq
	privateid (R	privateid"_
EnterPrivateRep
result (Rresult
roomid (Rroomid
	privateid (R	privateid"C
PrivateHistoryReq
gameid (Rgameid
ishost (Rishost"Ä
PrivateHistoryRep
gameid (Rgameid7
infos	 (2!.user.PrivateHistoryRep.BriefInfoRinfosz

PlayerInfo
seat (Rseat
uid (Ruid
name (	Rname
score (Rscore
	avatarurl (	R	avatarurlù
	BriefInfo
id (Rid
	privateid (R	privateid
hostuid (Rhostuid
hostname (	Rhostname
curround (Rcurround
maxround (Rmaxround
	starttime (	R	starttime
endtime (	Rendtime<
players	 (2".user.PrivateHistoryRep.PlayerInfoRplayers")
PrivateHistoryDetailReq
id (Rid"›
PrivateHistoryDetailRep
id (Rid=
infos	 (2'.user.PrivateHistoryDetailRep.RoundInfoRinfoss
	RoundInfo
round (Rround
players (	Rplayers
scores (	Rscores

recordtime (	R
recordtime"8
PrivateReplayReq
id (Rid
round (Rround"L
PrivateReplayRep
id (Rid
round (Rround
data (	Rdata"+
PlayersAmountReq
game_id (RgameId"|
PlayersAmountRep/
info (2.user.PlayersAmountRep.InfoRinfo7
Info
room_id (RroomId
amount (Ramount"%
CheckSecondPwdReq
pwd (	Rpwd"+
CheckSecondPwdRep
result (Rresult"A
SetSecondPwdReq
oldpwd (	Roldpwd
newpwd (	Rnewpwd")
SetSecondPwdRep
result (Rresult"N
BankOperateReq
optype (Roptype
gold (	Rgold
pwd (	Rpwd"X
BankOperateRep
result (Rresult
gold (	Rgold
bankgold (	Rbankgold"N
BindingDeviceReq
optype (Roptype
key (	Rkey
pwd (	Rpwd"E
GiveGoldReq
uid (Ruid
gold (	Rgold
pwd (	Rpwd"Å
GiveGoldRep
result (Rresult
bankgold (	Rbankgold
subgold (	Rsubgold
fee (	Rfee
time (	Rtime"*
GoldGaveLogReq
pageidx (Rpageidx"Ò
GoldGaveLogRep
result (Rresult
pageidx (Rpageidx
pagesum (Rpagesum,
logs (2.user.GoldGaveLogRep.LogRlogse
Log
fromuid (Rfromuid
touid (Rtouid
gold (	Rgold
datetime (	Rdatetime"*
BindingDeviceRep
result (Rresult"'
RechargeReq
orderid (Rorderid"%
RechargeRep
result (Rresult"
SignInInfoReq"ù
SignInInfoRep
result (Rresult
daycnt (Rdaycnt
signin (Rsignin
insure (Rinsure.
cfgs (2.user.SignInInfoRep.DayCfgRcfgs0
Item
kind (	Rkind
value (RvalueJ
DayCfg
day (Rday.
items (2.user.SignInInfoRep.ItemRitems"
	SignInReq"ô
	SignInRep
result (Rresult
daycnt (Rdaycnt*
items (2.user.SignInRep.ItemRitems0
Item
kind (	Rkind
value (Rvalue"
	InsureReq"7
	InsureRep
result (Rresult
gold (Rgold"
SharedRewardReq"%
SharedRewardRep
gold (Rgold"%
ExchangeCodeReq
code (	Rcode")
ExchangeCodeRep
result (Rresult"
HonorExchangeGoldReq"X
HonorExchangeGoldRep
result (Rresult
honor (	Rhonor
gold (	Rgold"(
UserShoutReq
content (	Rcontent"&
UserShoutRep
result (Rresult"@
PublishNoticeReq
content (	Rcontent
days (Rdays"*
PublishNoticeRep
result (Rresult"#
UpdateAvatarUrl
url (	Rurl