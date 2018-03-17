@echo off
echo "mkdir Protos"
mkdir Protos
echo "mkdir CS"
mkdir CS
echo "remove org proto files ..."
del Protos\*.proto /f/s/q/a
echo "remove org cs files ..."
del CS\*.cs /f/s/q/a
echo "start copy proto files ..."
copy /y ..\..\Share\Protocol\Proto\*.proto Protos\
echo "convert proto to cs ..."
@echo on
protogen -i:Protos/Person.proto -o:CS/Person.cs
@echo off
echo "move cs files to target ..."
move /y CS\*.cs ..\..\Client\excel\Assets\Scripts\09Protocol\
echo "remove org server cc ..."
del ..\..\Share\Protocol\Server\protoc\Protos\*.cc
echo "remove org server h ..."
del ..\..\Share\Protocol\Server\protoc\Protos\*.h
echo "convert proto to .cc .h ..."
@echo on
protoc --cpp_out=..\..\Share\Protocol\Server\protoc\ Protos\Person.proto
@echo off
echo "done !!!"
pause