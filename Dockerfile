# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY source/AuctionFinder/AuctionFinder/*.csproj .
RUN dotnet restore --ucr

# copy everything else and build app
COPY source/AuctionFinder/AuctionFinder/. .
RUN dotnet publish --ucr --no-restore -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022
WORKDIR /app
COPY --from=build /app .
USER ContainerUser
ENTRYPOINT ["./AuctionFinder/AuctionFinder"]