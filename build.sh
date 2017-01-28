#!bin/sh
set -e
dotnet restore
# dotnet test test/UnitTests/project.json
dotnet publish src/BarnacleBudget/project.json -c release -o $(pwd)/publish/web
