#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
LABEL org.opencontainers.image.authors="getrojob@gmail.com"
LABEL org.opencontainers.image.source=https://github.com/getrojob/THEJOB.cachorro.Api
LABEL org.opencontainers.image.description="API cachorro afim de estudo"
LABEL org.opencontainers.image.licenses=MIT

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["THEJOB.Cachorro.Api/THEJOB.Cachorro.Api.csproj", "THEJOB.Cachorro.Api/"]
COPY ["THEJOB.Cachorro.Domain/THEJOB.Cachorro.Domain.csproj", "THEJOB.Cachorro.Domain/"]
COPY ["THEJOB.Cachorro.Repository/THEJOB.Cachorro.Repository.csproj", "THEJOB.Cachorro.Repository/"]
RUN dotnet restore "THEJOB.Cachorro.Api/THEJOB.Cachorro.Api.csproj"
COPY . .
WORKDIR "/src/THEJOB.Cachorro.Api"
RUN dotnet build "./THEJOB.Cachorro.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./THEJOB.Cachorro.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "THEJOB.Cachorro.Api.dll"]
