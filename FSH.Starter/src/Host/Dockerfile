# Base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["Directory.Build.targets", "."]
COPY ["src/Host/Host.csproj", "src/Host/"]
COPY ["src/Core/Application/Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/Domain.csproj", "src/Core/Domain/"]
COPY ["src/Core/Shared/Shared.csproj", "src/Core/Shared/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Migrators/Migrators.MySQL/Migrators.MySQL.csproj", "src/Migrators/Migrators.MySQL/"]
COPY ["src/Migrators/Migrators.Oracle/Migrators.Oracle.csproj", "src/Migrators/Migrators.Oracle/"]
COPY ["src/Migrators/Migrators.PostgreSQL/Migrators.PostgreSQL.csproj", "src/Migrators/Migrators.PostgreSQL/"]
COPY ["src/Migrators/Migrators.MSSQL/Migrators.MSSQL.csproj", "src/Migrators/Migrators.MSSQL/"]
COPY ["src/Migrators/Migrators.SqLite/Migrators.SqLite.csproj", "src/Migrators/Migrators.SqLite/"]
RUN dotnet restore "src/Host/Host.csproj"
COPY . .
WORKDIR "/src/src/Host"
RUN dotnet build "Host.csproj" -c Release -o /app/build

# Publish image
FROM build AS publish
RUN dotnet publish "Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FSH.Starter.Host.dll"]
