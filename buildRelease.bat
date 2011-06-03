@echo off

rem GOTO MERGE

SET msbld="C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

del /Q Release\DomainCommonSE\*.*
del /Q Release\Config\*.*
del /Q Release\ODAC\*.*
del /Q Release\Oracle\*.*
del /Q Release\Oracle\Config\*.*
del /Q Release\MsSqlCe35\*.*
del /Q Release\MsSqlCe35\Config\*.*
del /Q Release\*.*

%msbld% DomainCommonSE.sln /t:Clean /p:Configuration=Release /nologo /m:2
%msbld% DomainCommonSE.sln /t:Rebuild /p:Configuration=Release /nologo /m:2 

rem /detailedsummary

mkdir Release
cd Release
mkdir Config
cd Config
mkdir DbPlugin
cd DbPlugin
mkdir ru
cd ../../..

copy /Y Release\MsSqlCe40\Config\*MsSqlCe40* Release\Config\DbPlugin\
copy /Y Release\MsSqlCe40\Config\ru\*.* Release\Config\DbPlugin\ru\
rem copy /Y Release\Oracle\Config\*.* Release\Config\DbPlugin\
rem copy /Y Release\Oracle\Config\ru\*.* Release\Config\DbPlugin\ru\
del /Q Release\Config\DevExpress.*.xml

GOTO END

echo Сборка GUI
:MERGE
SET platformdir="C:\Windows\Microsoft.NET\Framework\v4.0.30319"

rem SET ilm="C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe"
rem SET dxdll="C:\Program Files (x86)\DevExpress 2010.1\Components\Sources\DevExpress.DLL"

SET ilm="C:\Program Files\Microsoft\ILMerge\ILMerge.exe"
SET dxdll="C:\Program Files\DevExpress 2010.1\Components\Sources\DevExpress.DLL"

del /Q log.txt

cd Release
%ilm% /t:winexe /log:../log.txt /internalize /targetplatform:v4,"%platformdir%" /out:Config.exe EntityObjectORM.Config.exe EntityObjectORM.ConfigLibrary.dll EntityObjectORM.dll %dxdll%\DevExpress.RichEdit.v10.1.Core.dll %dxdll%\DevExpress.XtraEditors.v10.1.dll %dxdll%\DevExpress.XtraGrid.v10.1.dll %dxdll%\DevExpress.XtraGrid.v10.1.Design.dll %dxdll%\DevExpress.Data.v10.1.dll %dxdll%\DevExpress.XtraRichEdit.v10.1.dll %dxdll%\DevExpress.XtraBars.v10.1.dll %dxdll%\DevExpress.XtraVerticalGrid.v10.1.dll %dxdll%\DevExpress.XtraTreeList.v10.1.dll %dxdll%\DevExpress.XtraLayout.v10.1.dll %dxdll%\DevExpress.XtraEditors.v10.1.Design.dll %dxdll%\DevExpress.XtraNavBar.v10.1.dll %dxdll%\DevExpress.Design.v10.1.dll  %dxdll%\DevExpress.Utils.v10.1.dll

rem del /Q Release\Common\*.pdb
rem del /Q Release\Common\*.config
rem del /Q Release\Common\*.v9.3.xml
rem del /Q Release\Common\*.vshost.exe*
:END