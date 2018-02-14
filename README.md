# WebApiServer
## Install
- DataBase Management System
  - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  - [PostgreSQL](https://www.postgresql.org/download/)
- .NET Core
  - [for Linux](https://www.microsoft.com/net/learn/get-started/linuxubuntu)
  - [for macOs](https://www.microsoft.com/net/learn/get-started/macos)
  - [for Windows](https://www.microsoft.com/net/learn/get-started/windows)

## Build
```bash
cp ./appsettings.default.json ./appsettings.json
dotnet build WebApiServer.csproj -c Release

ln -s $(pwd)/appsettings.json $(pwd)/bin/Release/netcoreapp2.0/appsettings.json
ln -s $(pwd)/wwwroot $(pwd)/bin/Release/netcoreapp2.0/wwwroot
```
## Configure
```bash
dotnet restore
dotnet ef database update
```
## Startup
```bash
cd ./bin/Release/netcoreapp2.0/
dotnet WebApiServer.dll
```
## Wiki
For more information, please visit our [wiki](https://github.com/mpgp/WebApiServer/wiki).

