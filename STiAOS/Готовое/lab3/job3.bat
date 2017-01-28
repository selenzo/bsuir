@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET studentName=%1
SET newStudentName=%2
SET fileName=%3
if not exist %fileName% (
echo Искомый файл не найден
) else (
echo Фамилия студента %studentName% удалена из файла %fileName%
findstr /i /v /C:"%studentName%" %fileName%>temp.txt
del %fileName%
rename temp.txt %fileName%
echo %newStudentName%>>%fileName%
sort %fileName% /Output %fileName% 
pause
)