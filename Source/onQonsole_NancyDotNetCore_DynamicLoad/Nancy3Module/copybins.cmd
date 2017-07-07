setlocal
set TargetDir=..\nancy3web\bin\Debug\netcoreapp2.0\modules
mkdir %targetdir%
xcopy /erfi .\bin\Debug\netcoreapp2.0\Nancy3Module.* ..\nancy3web\
