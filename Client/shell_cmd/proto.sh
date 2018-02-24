#! /bin/sh
name=$1
filelist=`ls $2/${name}.proto`
out_dir=$3

if [ $? != 0 ] ; then
	echo "path error!"
	exit -1;
fi

if [[ ! -d "$out_dir" ]]; then
	mkdir "$out_dir"
fi

file_lines=${#filelist[@]}
line_number=0

for file in $filelist
do
if [[ $file != "ls" ]]; then
	filename=${file##*/}
	filename=${filename%.*}
	out_path=$out_dir$filename.cs

	protogen -i:$file -o:$out_path > /dev/null 2>&1

	let line_number+=1;

	if [[ $? -eq 0 ]]; then
		resMsg="[$line_number/$file_lines] $out_path ok!!"
		echo $resMsg
	else
		resMsg="[$line_number/$file_lines] $out_path failed !!"
		echo $resMsg 2>&1
	fi
fi
done
