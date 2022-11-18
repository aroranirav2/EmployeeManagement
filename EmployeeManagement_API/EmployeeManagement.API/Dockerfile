#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EmployeeManagement.API/EmployeeManagement.API.csproj", "EmployeeManagement.API/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Database.EmployeeManagement.Persistence.EFCore/Database.EmployeeManagement.Persistence.EFCore.csproj", "Database.EmployeeManagement.Persistence.EFCore/"]
COPY ["EmployeeManagement.Repository/EmployeeManagement.Repository.csproj", "EmployeeManagement.Repository/"]
RUN dotnet restore "EmployeeManagement.API/EmployeeManagement.API.csproj"
COPY . .
WORKDIR "/src/EmployeeManagement.API"
RUN dotnet build "EmployeeManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagement.API.dll"]