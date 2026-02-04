# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia os arquivos de projeto e restaura as dependências
COPY ["ThreatModelDfdService.csproj", "./"]
RUN dotnet restore

# Copia o restante dos arquivos e compila
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Estágio 2: Runtime (Imagem final leve)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expondo a porta padrão do ASP.NET Core
EXPOSE 8080

ENTRYPOINT ["dotnet", "ThreatModelDfdService.dll"]