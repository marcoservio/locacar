FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY LocaCar.Api/*.csproj ./LocaCar.Api/
COPY LocaCar.Domain/*.csproj ./LocaCar.Domain/
COPY LocaCar.Infra.Ioc/*.csproj ./LocaCar.Infra.Ioc/
COPY LocaCar.Application/*.csproj ./LocaCar.Application/
COPY LocaCar.Infra.Data/*.csproj ./LocaCar.Infra.Data/

COPY . ./
RUN dotnet publish LocaCar.Api/LocaCar.Api.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "LocaCar.Api.dll" ]