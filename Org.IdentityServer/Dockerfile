#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Org.IdentityServer/Org.IdentityServer.csproj", "Org.IdentityServer/"]
RUN dotnet restore "Org.IdentityServer/Org.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Org.IdentityServer"
RUN dotnet build "Org.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Org.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Org.IdentityServer.dll"]
