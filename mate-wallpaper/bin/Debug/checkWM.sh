#!/bin/bash
search=$1
cd /proc
#ls -R -l | grep "$search"
for file in *; do
   if [ -d $file ]; then
		cd $file;
		if [ -e "exe" ]; then
			readlink exe | grep "$search";
		fi
		cd ..;
   fi
done
