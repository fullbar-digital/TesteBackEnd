FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env

WORKDIR /app

RUN dotnet --version

COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE  80

ENTRYPOINT ["dotnet", "App.Domain.Api.dll"]