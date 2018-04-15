
°
HkFiveCard.proto
HkFiveCard"t
UpdateGameInfo
session (Rsession
index (Rindex
params1 (Rparams1
params2 (Rparams2"X

OperateReq
session (Rsession
optype (Roptype
opvalue (Ropvalue"ˆ

OperateRep
session (Rsession
index (Rindex
seatid (Rseatid
optype (Roptype
opvalue (Ropvalue
curchip (Rcurchip
	askseatid (R	askseatid
oplist (Roplist
timeout	 (Rtimeout
secret
 (Rsecret"á
AddCard
session (Rsession
index (Rindex
seatid (Rseatid
	askseatid (R	askseatid
cardid (Rcardid
time (Rtime
odds (Rodds
cardids (Rcardids
secret	 (Rsecret"l
ShowCard
session (Rsession
index (Rindex
seatid (Rseatid
cardids (Rcardids"Ø
SyncGameData
session (Rsession
status (Rstatus
index (Rindex
seatid (Rseatid
odds (Rodds
opseat (Ropseat
oplist (Roplist
optime (Roptime=
players	 (2#.HkFiveCard.SyncGameData.PlayerInfoRplayersÌ

PlayerInfo
uid (Ruid
seatid (Rseatid
ingame (Ringame
giveup (Rgiveup
showhand (Rshowhand
prechip (Rprechip
curchip (Rcurchip
cards (Rcards"‡
SettleAccount
session (Rsession
	winseatid (R	winseatid 
goldchanges (Rgoldchanges
	cardtypes (R	cardtypes