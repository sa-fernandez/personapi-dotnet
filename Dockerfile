#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["personapi-dotnet/personapi-dotnet.csproj", "personapi-dotnet/"]
RUN dotnet restore "personapi-dotnet/personapi-dotnet.csproj"
COPY . .
WORKDIR "/src/personapi-dotnet"
RUN dotnet build "personapi-dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "personapi-dotnet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "personapi-dotnet.dll"]