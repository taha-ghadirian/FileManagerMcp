# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["FtpManagerMcp.csproj", "./"]
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Build and publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS final
WORKDIR /app

# Copy the published files from build stage
COPY --from=build /app/publish .

# Set the entry point
ENTRYPOINT ["dotnet", "FtpManagerMcp.dll"]