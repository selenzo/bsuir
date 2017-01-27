#!/bin/bash

us=$1
catal=$2
fout=$3

findResult=$(find /$catal/ -user us -print)

echo $findResult>>$fout

exit 0
