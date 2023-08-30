FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Hootel.Hotels/Hootel.Hotels.csproj", "Hootel.Hotels/"]
RUN dotnet restore "Hootel.Hotels/Hootel.Hotels.csproj"
COPY . .
WORKDIR "/src/Hootel.Hotels"
RUN dotnet build "Hootel.Hotels.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hootel.Hotels.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hootel.Hotels.dll"]
