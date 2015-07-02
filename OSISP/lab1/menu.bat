@echo off

:m3
cls
echo 1 - notepad
echo 2 - calc
echo 3 - exit
set /p a="input 1,2,3: "
if "%a%" == "1" goto m1
if "%a%" == "2" goto m2
if "%a%" == "3" goto ex
:m1
start notepad.exe
goto m3
:m2
start calc.exe
goto m3
:ex