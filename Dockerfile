#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["GradeRank-API/GradeRank-API.csproj", "GradeRank-API/"]
RUN dotnet restore "GradeRank-API/GradeRank-API.csproj"

COPY ["GradeRank-Application/GradeRank-Application.csproj", "GradeRank-Application/"]
RUN dotnet restore "GradeRank-Application/GradeRank-Application.csproj"

COPY ["GradeRank-Domain/GradeRank-Domain.csproj", "GradeRank-Domain/"]
RUN dotnet restore "GradeRank-Domain/GradeRank-Domain.csproj"

COPY ["GradeRank-Domain/GradeRank-Domain.csproj", "GradeRank-Domain/"]
RUN dotnet restore "GradeRank-Domain/GradeRank-Domain.csproj"

COPY ["GradeRank-Infrastructure/GradeRank-Infrastructure.csproj", "GradeRank-Infrastructure/"]
RUN dotnet restore "GradeRank-Infrastructure/GradeRank-Infrastructure.csproj"

COPY ["GradeRank-Tests/GradeRank-Tests.csproj", "GradeRank-Tests/"]
RUN dotnet restore "GradeRank-Tests/GradeRank-Tests.csproj"

COPY . .
WORKDIR "/src/GradeRank-API"
RUN dotnet build "GradeRank-API.csproj" -c Release -o /app

WORKDIR "/src/GradeRank-Application"
RUN dotnet build "GradeRank-Application.csproj" -c Release -o /app

WORKDIR "/src/GradeRank-Domain"
RUN dotnet build "GradeRank-Domain.csproj" -c Release -o /app

WORKDIR "/src/GradeRank-Infrastructure"
RUN dotnet build "GradeRank-Infrastructure.csproj" -c Release -o /app

WORKDIR "/src/GradeRank-Tests"
RUN dotnet build "GradeRank-Tests.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GradeRank-API.dll"]