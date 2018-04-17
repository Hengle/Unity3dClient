#!/bin/bash

# import variables
./_variables.sh

protofiles=`ls | grep [.]proto`
rm -rf *.pb
for f in ${protofiles[*]}
do
	chmod u+x ./protoc-bin/protoc-mac
	./protoc-bin/protoc-mac $f -o ${f/".proto"/".pb"}
	echo " generate" ${f/".proto"/".pb"} done !
done

echo "copy all *.pb file to client folder!"
cp ./*.pb ./../../${CLIENT_DIR_NAME}/res/Protocol/
echo "copy done!"
