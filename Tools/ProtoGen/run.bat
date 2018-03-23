echo off
set cur_dir=%~dp0
set proto_path=%cur_dir%..\..\Share\Protocol\Proto\
set cs_path=%cur_dir%..\..\Client\excel\Assets\Scripts\09Protocol\
set cpp_path=%cur_dir%..\..\Share\Protocol\Server\protoc\
pushd %proto_path%
echo on
%cur_dir%/protogen -i:MsgHead.proto -o:MsgHead.cs
%cur_dir%/protogen -i:LogItem.proto -o:LogItem.cs
%cur_dir%/protogen -i:Person.proto -o:Person.cs

move *.cs %cs_path%
del %cpp_path%*.h
del %cpp_path%*.cc

%cur_dir%/protoc --cpp_out=%cpp_path% MsgHead.proto
%cur_dir%/protoc --cpp_out=%cpp_path% LogItem.proto
%cur_dir%/protoc --cpp_out=%cpp_path% Person.proto
@echo off
popd
pause