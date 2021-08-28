#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Fllr/Fllr.csproj", "Fllr/"]
COPY ["../Fllr.Infrastructure/Fllr.Infrastructure.csproj", "../Fllr.Infrastructure/"]
COPY ["../Fllr.Generator.Default/Fllr.Generator.Default.csproj", "../Fllr.Generator.Default/"]
RUN dotnet restore "Fllr/Fllr.csproj"
COPY . .
WORKDIR "/src/Fllr"
RUN dotnet build "Fllr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fllr.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fllr.dll"]