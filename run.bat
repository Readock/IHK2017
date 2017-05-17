@echo off

echo ==================================
echo IHK2017 CarsharingSimulator
echo ==================================

:: Zaelen der *.in Dateien im Eingabeverzeichnis
set cnt=0
for %%A in (Input/*.in) do set /a cnt+=1

if not %cnt% == 0 echo %cnt% file(s) found & echo.
if %cnt% == 0 (
	echo.
	echo Es sind keine Eingabe Dateien im Verzeichnis "Input" ! 
	echo Fuege bitte Eingabe Dateien hinzu und stelle sicher,
	echo dass diese die Endung "*.in" Besitzen [zB. test.in]
	echo. 
	goto abort
)

:: Neu Initializierung des ErrorLogs
echo ================= 	> ErrorLog.txt
echo ErrorLog			>> ErrorLog.txt
echo =================	>> ErrorLog.txt
echo %date% - %time% 	>> ErrorLog.txt
echo.					>> ErrorLog.txt

:: Starte Programm fuer jede Eingabedatei
for %%f IN (Input/*.in) DO (
	echo "%%f" wird ausgefuehrt ...
	echo Fehlermeldungen zu "%%f" >> ErrorLog.txt
	C:\Users\Readock\Documents\Git\IHK2017\SourceCode\CarsharingSimulator\CarsharingSimulator\bin\Debug\CarsharingSimulator.exe Input/%%f Output/%%~nf.out >> ErrorLog.txt
	echo. >> ErrorLog.txt
	echo Programm wurde beendet
	echo.
)

echo -----------------
echo Fertig!
echo.
goto end

:abort
echo -----------------
echo Abbruch!
echo.
goto end

:end
pause