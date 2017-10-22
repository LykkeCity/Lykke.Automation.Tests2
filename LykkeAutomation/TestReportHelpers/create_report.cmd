set currentDir=%cd%
dotnet test ../LykkeAutomation.csproj --filter "TestCategory=PersonalData" --logger "trx;LogFileName=%currentDir%/report.trx"
dotnet MSTestAllureAdapter.Console.dll report.trx output-xmls
%currentDir%/allure-cli/bin/allure generate %currentDir% -v 1.4.0
pause