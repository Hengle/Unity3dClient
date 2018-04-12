
§
TexasPoker.proto
TexasPoker"¬
GameConf
session (Rsession
roomgold (Rroomgold
basechip (Rbasechip
maxchip (Rmaxchip
optimecd (Roptimecd
taxrate (Rtaxrate"Ó
	GameStart
session (Rsession
	handcards (R	handcards

bankerseat (R
bankerseat:
players (2 .TexasPoker.GameStart.PlayerInfoRplayers
opseat (Ropseat
optime (Roptime
	addoption (R	addoption
secret (RsecretL

PlayerInfo
uid (Ruid
seat (Rseat
curchip (Rcurchip"X

OperateReq
session (Rsession
optype (Roptype
opvalue (Ropvalue"î

OperateRep
session (Rsession
opseat (Ropseat
optype (Roptype
opvalue (Ropvalue
curchip (Rcurchip
nextseat (Rnextseat
oplist (Roplist
optime (Roptime
secret	 (Rsecret"Š
UpdatePublicCard
session (Rsession
cards (Rcards
opseat (Ropseat
optime (Roptime
secret (Rsecret"ä
GameEnd
session (Rsession8
players (2.TexasPoker.GameEnd.PlayerInfoRplayers„

PlayerInfo
uid (Ruid
seat (Rseat
cards (Rcards
cardtype (Rcardtype

goldchange (R
goldchange"Â
SyncGameInfo
session (Rsession
status (Rstatus
pubcards (Rpubcards
opseat (Ropseat
oplist (Roplist
optime (Roptime
	addoption (R	addoption=
players (2#.TexasPoker.SyncGameInfo.PlayerInfoRplayers¾

PlayerInfo
uid (Ruid
seat (Rseat
ingame (Ringame
fold (Rfold
allin (Rallin
prechip (Rprechip
curchip (Rcurchip
cards (Rcards