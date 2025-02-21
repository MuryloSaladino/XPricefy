# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and all projects
COPY . .  
RUN dotnet restore Server.API/Server.API.csproj

# Build & Publish
WORKDIR /app/Server.API
RUN dotnet publish -c Release -o /out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "Server.API.dll"]