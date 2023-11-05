# Use a Windows base image
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build
WORKDIR C:\source

# Copy csproj and restore as distinct layers
COPY source\AuctionFinder\AuctionFinder\*.csproj .
RUN dotnet restore

# Copy everything else and build the app
COPY source\AuctionFinder\AuctionFinder\ .
RUN dotnet publish --no-restore -o C:\app

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022
WORKDIR C:\app
COPY --from=build C:\app .

# User directive for Windows containers
USER ContainerUser

ENTRYPOINT ["AuctionFinder\\AuctionFinder.exe"]