#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TesteStefanini.Api/TesteStefanini.Api.csproj", "src/TesteStefanini.Api/"]
COPY ["src/TesteStefanini.IoC/TesteStefanini.IoC.csproj", "src/TesteStefanini.IoC/"]
COPY ["src/TesteStefanini.Application/TesteStefanini.Application.csproj", "src/TesteStefanini.Application/"]
COPY ["src/TesteStefanini.Domain/TesteStefanini.Domain.csproj", "src/TesteStefanini.Domain/"]
COPY ["src/TesteStefanini.Commons/TesteStefanini.Commons.csproj", "src/TesteStefanini.Commons/"]
COPY ["src/TesteStefanini.Data/TesteStefanini.Data.csproj", "src/TesteStefanini.Data/"]
RUN dotnet restore "src/TesteStefanini.Api/TesteStefanini.Api.csproj"
COPY . .
WORKDIR "/src/src/TesteStefanini.Api"
RUN dotnet build "TesteStefanini.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteStefanini.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteStefanini.Api.dll"]