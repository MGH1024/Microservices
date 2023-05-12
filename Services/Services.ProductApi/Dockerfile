FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Services.ProductApi/Services.ProductApi.csproj", "Services/Services.ProductApi/"]
RUN dotnet restore "Services/Services.ProductApi/Services.ProductApi.csproj"
COPY . .
WORKDIR "/src/Services/Services.ProductApi"
RUN dotnet build "Services.ProductApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.ProductApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.ProductApi.dll"]
