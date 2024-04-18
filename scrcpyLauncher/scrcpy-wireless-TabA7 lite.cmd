@REM Before using this script you need to execute following command while phone connected to PC via USB:
@REM adb tcpip 5555

@ECHO OFF
set "IP=192.168.29.30"
ECHO adb connect %IP%:5555
adb connect %IP%:5555 | find "connected to"

IF %ERRORLEVEL% NEQ 0 (
    ECHO An error was found. Device could not connect.
    GOTO eof
)
@ECHO:&ECHO:

@ECHO ON
scrcpy --turn-screen-off --stay-awake --show-touches --serial=%IP%:5555 --shortcut-mod=lalt,ralt --video-bit-rate=2M --max-fps=15 --push-target=/storage/emulated/0/Download
@ECHO:&ECHO:
adb disconnect %IP%:5555

:eof
@ECHO:&ECHO:&ECHO:
@ECHO Exitting.....
@PAUSE
