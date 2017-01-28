@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET studentName=%1
SET fileName=%2
if not exist %fileName% (
echo filenot
) else (
SET buf=findstr /i /n /C:"%studentName%" %fileName%
if "%buf%"=="" (
goto noerror
) else (
echo vse ochen' ploho
pause
exit /b 1
)
:noerror
echo vse ok
pause
)