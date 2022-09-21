FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HowLongToBeat.Api/HowLongToBeat.Api.csproj", "HowLongToBeat.Api/"]
RUN dotnet restore "HowLongToBeat.Api/HowLongToBeat.Api.csproj"
COPY . .
WORKDIR "/src/HowLongToBeat.Api"
RUN dotnet build "HowLongToBeat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HowLongToBeat.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HowLongToBeat.Api.dll"]
