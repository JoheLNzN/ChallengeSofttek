FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY JncSofttek.Microservice.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build "JncSofttek.Microservice.csproj" -c Release -o /app/build

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "JncSofttek.Microservice.dll"]