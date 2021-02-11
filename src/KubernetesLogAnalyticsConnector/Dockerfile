FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["KubernetesLogAnalyticsConnector/KubernetesLogAnalyticsConnector.csproj", "KubernetesLogAnalyticsConnector/"]

RUN dotnet restore "KubernetesLogAnalyticsConnector/KubernetesLogAnalyticsConnector.csproj"
COPY . .
WORKDIR "/src/KubernetesLogAnalyticsConnector"
RUN dotnet build "KubernetesLogAnalyticsConnector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubernetesLogAnalyticsConnector.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubernetesLogAnalyticsConnector.dll"]