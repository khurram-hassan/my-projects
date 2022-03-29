@REM Before using this script you need to execute following command while phone connected to PC via USB:
@REM adb tcpip 5555

@REM 192.168.0.104, 192.168.2.103, 192.168.1.103
@set "IP=192.168.2.101"
adb connect %IP%:5555 | find "connected to"
@ECHO OFF
IF %ERRORLEVEL% NEQ 0 (
    ECHO An error was found. Device could not connect.
    GOTO eof
)

@ECHO ON
C:\ProgramData\chocolatey\lib\scrcpy\tools\scrcpy.exe -w -t -s %IP%:5555 --bit-rate 2M --max-fps 30 --push-target /storage/emulated/0/Download
adb disconnect %IP%:5555

:eof
@ECHO OFF
ECHO Exitting.....
PAUSE
