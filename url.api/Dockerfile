#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["url.api/url.api.csproj", "url.api/"]
RUN dotnet restore "url.api/url.api.csproj"
COPY . .
WORKDIR "/src/url.api"
RUN dotnet build "url.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "url.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "url.api.dll"]