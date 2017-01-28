@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul

:main
echo Выберите пункт меню:
echo.
echo 1 - Создание или пополнение списка группы студентов
echo 2 - Замена студента в группе
echo 3 - Исключение студента из группы
echo 4 - Помещение списка группы в одноименный архив
echo 5 - Извлечение списка группы из одноименного архива
echo 6 - Поиск и отображение фамилий студентов и соответствующие наименования групп, в которых имеются однофамильцы
echo 0 - Выход

echo.
SET /p choice="Ваш выбор: "
if not defined choice goto main
if %choice%==1 (goto job1)
if %choice%==2 (goto job3)
if %choice%==3 (goto job2)
if %choice%==4 (goto job4)
if %choice%==5 (goto job5)
if %choice%==6 (goto job6)
if %choice%==0 (goto end)
echo.
echo Неправильный выбор!
echo.
echo.

goto main

:job1
call job1.bat 481064.txt
goto main

:job2
set /p studentName=Введите фамилию студента:
call job2.bat %studentName% 481064.txt
goto main

:job3
set /p studentName=Введите фамилию заменяемого:
echo.
set /p newStudentName=Введите фамилию заменяющего:
call job3.bat %studentName% %newStudentName% 481064.txt
goto main

:job4
call job4.bat 481064
goto main

:job5
call job5.bat 481064
goto main

:job6
set /p studentName=Введите фамилию студента:
call job6.bat %studentName% 481064.txt
goto main

:end
pause