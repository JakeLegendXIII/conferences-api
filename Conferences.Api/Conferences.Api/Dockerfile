FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Conferences.Api/Conferences.Api.csproj", "Conferences.Api/"]
RUN dotnet restore "Conferences.Api/Conferences.Api.csproj"
COPY . .
WORKDIR "/src/Conferences.Api"
RUN dotnet build "Conferences.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Conferences.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Conferences.Api.dll"]