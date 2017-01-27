#!/bin/bash

catal=$1
minValue=$2
maxValue=$3
fout=$4

man find

findResult=$(find /$catal/ -size +$minValue -size -$maxValue -print)

echo $findResult>>$fout

exit 0
