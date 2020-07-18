FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["KubernetesService/KubernetesService.csproj", "KubernetesService/"]

RUN dotnet restore "KubernetesService/KubernetesService.csproj"
COPY . .
WORKDIR "/src/KubernetesService"
RUN dotnet build "KubernetesService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KubernetesService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KubernetesService.dll"]