FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS="http://*:7060"
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 7060

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY "BeHealthBackend.csproj" "./"
# Restore as distinct layers
RUN dotnet restore
# Copy everything
COPY . ./
# Build and publish a release
RUN dotnet publish -c Release -o out


FROM base AS runtime

WORKDIR /app

COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "BeHealthBackend.dll"]