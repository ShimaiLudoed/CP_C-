FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CP3/CP3.csproj", "CP3/"]
RUN dotnet restore "CP3/CP3.csproj"
COPY . .
WORKDIR "/src/CP3"
RUN dotnet build "CP3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CP3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CP3.dll"]
