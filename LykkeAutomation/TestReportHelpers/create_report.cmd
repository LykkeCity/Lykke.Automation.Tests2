set currentDir=%cd%
dotnet test ../LykkeAutomation.csproj --filter "Category=All" --logger "trx;LogFileName=%currentDir%/report.trx"
dotnet MSTestAllureAdapter.Console.dll report.trx output-xmls
%currentDir%/allure-cli/bin/allure generate -c %currentDir% 
pause