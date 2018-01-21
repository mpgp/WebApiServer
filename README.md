# WebApiServer
## Install
- [.NET Core for Linux](https://www.microsoft.com/net/learn/get-started/linuxubuntu)
- [.NET Core for macOs](https://www.microsoft.com/net/learn/get-started/macos)
- [.NET Core for Windows](https://www.microsoft.com/net/learn/get-started/windows)

## Build
```bash
cp ./appsettings.default.json ./appsettings.json
dotnet build WebApiServer.csproj -c Release
```
## Configure
```bash
dotnet restore
dotnet ef database update
```
## Startup
```bash
cp ./appsettings.json ./bin/Release/netcoreapp2.0/
cd ./bin/Release/netcoreapp2.0/
dotnet WebApiServer.dll
```
## Wiki
For more information, please visit our [wiki](https://github.com/mpgp/WebApiServer/wiki).
