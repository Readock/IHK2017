@echo off

echo =================
echo IHKSS2017
echo =================

:: count *.in files in Input folder
set cnt=0
for %%A in (Input/*.in) do set /a cnt+=1

if not %cnt% == 0 echo %cnt% file(s) found & echo.
if %cnt% == 0 (
	echo.
	echo There are no input files in the "Input" folder ! 
	echo Please insert your input files and restart.
	echo Make shure you use "*.in" as filename [eg. test.in]
	echo. 
	goto abort
)

:: clear and reinit ErrorLog
echo ================= 	> ErrorLog.txt
echo ErrorLog			>> ErrorLog.txt
echo =================	>> ErrorLog.txt
echo %date% - %time% 	>> ErrorLog.txt
echo.					>> ErrorLog.txt

::run programm with each *.in file as parameter
for %%f IN (Input/*.in) DO (
	echo Executing "%%f" ...
	SourceCode\IHKTempleteProject\IHKTempleteProject\bin\Debug\IHKTempleteProject.exe Input/%%f Output/%%~nf.out >> ErrorLog.txt
	echo "%%f" was executed!
	echo.
)

echo -----------------
echo Done.
echo.
goto end

:abort
echo -----------------
echo Aborted.
echo.
goto end

:end
pause