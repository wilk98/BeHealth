FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /App

COPY "BeHealthBackend.csproj" "./"
# Restore as distinct layers
RUN dotnet restore
# Copy everything
COPY . ./
# Build and publish a release
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /App

COPY --from=build /App/out ./
ENTRYPOINT ["dotnet", "BeHealthBackend.dll"]