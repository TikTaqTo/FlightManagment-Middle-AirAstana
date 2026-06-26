FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FlightManagment-Middle-AirAstana/FlightManagment-Middle-AirAstana.csproj", "FlightManagment-Middle-AirAstana/"]
RUN dotnet restore "FlightManagment-Middle-AirAstana/FlightManagment-Middle-AirAstana.csproj"
COPY . .
WORKDIR "/src/FlightManagment-Middle-AirAstana"
RUN dotnet build "./FlightManagment-Middle-AirAstana.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FlightManagment-Middle-AirAstana.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlightManagment-Middle-AirAstana.dll"]
