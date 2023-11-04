# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
ARG TARGETARCH
WORKDIR /source

# copy csproj and restore as distinct layers
COPY source/AuctionFinder/AuctionFinder/*.csproj .
RUN dotnet restore

# copy and publish app and libraries
COPY source/AuctionFinder/AuctionFinder/. .
RUN dotnet publish --no-restore -o /app


# Enable globalization and time zones:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/enable-globalization.md
# final stage/image
FROM mcr.microsoft.com/dotnet/nightly/aspnet:7.0-alpine-composite
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["./AuctionFinder/AuctionFinder"]