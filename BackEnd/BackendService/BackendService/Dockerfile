FROM microsoft/dotnet:3.0-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:3.0-sdk AS build
WORKDIR /src
COPY BackendService/BackendService.csproj BackendService/
RUN dotnet restore BackendService/BackendService.csproj
COPY . .
WORKDIR /src/BackendService
RUN dotnet build BackendService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BackendService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BackendService.dll"]