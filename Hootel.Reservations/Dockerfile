FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Hootel.Reservations/Hootel.Reservations.csproj", "Hootel.Reservations/"]
RUN dotnet restore "Hootel.Reservations/Hootel.Reservations.csproj"
COPY . .
WORKDIR "/src/Hootel.Reservations"
RUN dotnet build "Hootel.Reservations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hootel.Reservations.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hootel.Reservations.dll"]
