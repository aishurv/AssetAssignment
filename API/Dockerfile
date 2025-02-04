# Use .NET SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything (including dependencies like DataService)
COPY AssetAPI/AssetAPI.csproj 
# Restore dependencies
RUN dotnet restore AssetAPI.csproj

# Build and publish the API
RUN dotnet publish AssetAPI.csproj -c Release -o /app/out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Ensure the entrypoint is correct
CMD ["dotnet", "AssetAPI.dll"]
