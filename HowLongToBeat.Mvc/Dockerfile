FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HowLongToBeat.Mvc/HowLongToBeat.Mvc.csproj", "HowLongToBeat.Mvc/"]
RUN dotnet restore "HowLongToBeat.Mvc/HowLongToBeat.Mvc.csproj"
COPY . .
WORKDIR "/src/HowLongToBeat.Mvc"
RUN dotnet build "HowLongToBeat.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HowLongToBeat.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HowLongToBeat.Mvc.dll"]
