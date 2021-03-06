@REM 192.168.0.104, 192.168.2.101

@set "IP=192.168.2.101"
adb connect %IP%:5555 | find "connected to"
@ECHO OFF
IF %ERRORLEVEL% NEQ 0 (
    ECHO An error was found. Device could not connect.
    GOTO eof
)

@ECHO ON
C:\ProgramData\chocolatey\lib\scrcpy\tools\scrcpy.exe -t -s %IP%:5555 -m800 --bit-rate 1M --max-fps 15 --push-target /storage/emulated/0/Download
adb disconnect %IP%:5555

:eof
@ECHO OFF
ECHO Exitting.....
PAUSE
