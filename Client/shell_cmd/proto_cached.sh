#! /bin/sh
filelist='ls /Users/shenshaojun/Desktop/table_convert/Proto/*.proto'
out_dir='/Users/shenshaojun/Desktop/table_convert/Code/'
if [[ ! -d "$out_dir" ]]; then
	mkdir "$out_dir"
fi

line_number=0
file_lines=$($filelist | sed -n '$=')
echo $file_lines

for file in $filelist
do
if [[ $file != "ls" ]]; then
	filename=${file##*/}
	filename=${filename%.*}
	out_path=$out_dir$filename.cs

	protogen -i:$file -o:$out_path >/dev/null 2>&1

	let line_number+=1;

	if [[ $? -eq 0 ]]; then
		echo "\033[0;32m[[$line_number/$file_lines]] $out_path ok!!\033[0m"
	else
		echo "\033[0;31m$[[$line_number/$file_lines]] $out_path failed !!\033[m"
	fi
fi
done
