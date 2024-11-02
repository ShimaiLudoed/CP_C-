FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MikhailShvets_CatFrameWork/MikhailShvets_CatFrameWork.csproj", "MikhailShvets_CatFrameWork/"]
RUN dotnet restore "MikhailShvets_CatFrameWork/MikhailShvets_CatFrameWork.csproj"
COPY . .
WORKDIR "/src/MikhailShvets_CatFrameWork"
RUN dotnet build "MikhailShvets_CatFrameWork.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MikhailShvets_CatFrameWork.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MikhailShvets_CatFrameWork.dll"]
