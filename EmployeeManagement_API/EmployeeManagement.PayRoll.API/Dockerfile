#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EmployeeManagement.PayRoll.API/EmployeeManagement.PayRoll.API.csproj", "EmployeeManagement.PayRoll.API/"]
RUN dotnet restore "EmployeeManagement.PayRoll.API/EmployeeManagement.PayRoll.API.csproj"
COPY . .
WORKDIR "/src/EmployeeManagement.PayRoll.API"
RUN dotnet build "EmployeeManagement.PayRoll.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeManagement.PayRoll.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagement.PayRoll.API.dll"]