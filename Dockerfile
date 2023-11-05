# Use the official .NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# Use the official .NET Core SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the .csproj and restore as distinct layers
COPY source/AuctionFinder/AuctionFinder/AuctionFinder.csproj .
RUN dotnet restore AuctionFinder.csproj

# Copy everything else and build the app
COPY source/AuctionFinder/AuctionFinder/ .
RUN dotnet build AuctionFinder.csproj -c Release -o /app/build

# Create a stage for adding the required framework
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS framework
WORKDIR /app
RUN dotnet publish -c Release -o /app

# Create a final image that includes the published application and the framework
FROM base AS final
COPY --from=framework /app /app
ENTRYPOINT ["dotnet", "AuctionFinder.dll"]