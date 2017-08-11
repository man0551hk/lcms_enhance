REM ****************************************
REM * Filename : Detector_Select.Bat			*
REM * 						*
REM * Description : Select detector(s) on LCMS	*
REM *                                  			*
REM * Target filenames : BASIC.XML			*
REM *                                 			*
REM * Notes : All filenames are CASE Sensitive  	*
REM *                                  			*
REM * DATE : 9 March 2017                     		*
REM *						*
REM * Version 1.0					*
REM *						*
REM ****************************************

@echo off
cls
:start

echo.
echo Detector 1, Top     [ T ]
echo.
echo Detector 2, Bottom  [ B ]
echo.
echo Detectors 1 and 2   [ D ]
echo.
echo Cancel Selection    [ C ]
echo.
Choice /C TBDC /N /M "Enter Your Choice : [ T, B, D, C ] ?"
 
If Errorlevel 4 Goto :4
If Errorlevel 3 Goto :3
If Errorlevel 2 Goto :2
If Errorlevel 1 Goto :1
Goto End

:4
cls
echo Cancel Selection !
Goto End

:3
cls
echo Dual-Detector Mode Selected
rem echo on
copy /y C:\LCMS\xml\Basic_Dual.XML C:\LCMS\xml\Basic.XML
Goto End

:2
cls
echo Bottom Detector Mode Selected
rem echo on
copy /y C:\LCMS\xml\Basic_Bottom.XML C:\LCMS\xml\Basic.XML
Goto End

:1
cls
echo Top Detector Mode Selected
rem echo on
copy /y C:\LCMS\xml\Basic_Top.XML C:\LCMS\xml\Basic.XML
Goto End

:End
echo.
echo.

Pause
exit
