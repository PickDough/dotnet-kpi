FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MMS.News.API/MMS.News.API.csproj", "MMS.News.API/"]
RUN dotnet restore "MMS.News.API/MMS.News.API.csproj"
COPY . .
WORKDIR "/src/MMS.News.API"
RUN dotnet build "MMS.News.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MMS.News.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MMS.News.API.dll"]
