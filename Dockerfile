FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS DOTNET_CORE_TOOL_CHAIN

COPY ./ /tmp/

WORKDIR /tmp/Beian

RUN dotnet publish -c Release


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

MAINTAINER harriszhang@live.cn

COPY --from=DOTNET_CORE_TOOL_CHAIN /tmp/Beian/bin/Release/netcoreapp3.1/publish /app

WORKDIR /app

ENTRYPOINT ["dotnet", "Beian.dll"]