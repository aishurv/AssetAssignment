# Use .NET SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development
COPY AssetUI/*.csproj ./
RUN dotnet restore
COPY AssetUI/ ./
RUN dotnet publish -c Release -o out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
CMD ["dotnet", "AssetUI.dll"]
