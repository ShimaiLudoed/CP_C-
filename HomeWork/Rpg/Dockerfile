FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Rpg/Rpg.csproj", "Rpg/"]
RUN dotnet restore "Rpg/Rpg.csproj"
COPY . .
WORKDIR "/src/Rpg"
RUN dotnet build "Rpg.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rpg.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rpg.dll"]
