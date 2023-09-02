FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Hootel.Worker/Hootel.Worker.csproj", "Hootel.Worker/"]
RUN dotnet restore "Hootel.Worker/Hootel.Worker.csproj"
COPY . .
WORKDIR "/src/Hootel.Worker"
RUN dotnet build "Hootel.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hootel.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hootel.Worker.dll"]
