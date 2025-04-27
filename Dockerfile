FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["RO.DevTest.WebApi/RO.DevTest.WebApi.csproj", "RO.DevTest.WebApi/"]
COPY ["RO.DevTest.Application/RO.DevTest.Application.csproj", "RO.DevTest.Application/"]
COPY ["RO.DevTest.Domain/RO.DevTest.Domain.csproj", "RO.DevTest.Domain/"]
COPY ["RO.DevTest.Infrastructure/RO.DevTest.Infrastructure.csproj", "RO.DevTest.Infrastructure/"]
COPY ["RO.DevTest.Persistence/RO.DevTest.Persistence.csproj", "RO.DevTest.Persistence/"]
RUN dotnet restore "RO.DevTest.WebApi/RO.DevTest.WebApi.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "RO.DevTest.WebApi/RO.DevTest.WebApi.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "RO.DevTest.WebApi/RO.DevTest.WebApi.csproj" -c Release -o /app/publish

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RO.DevTest.WebApi.dll"] 