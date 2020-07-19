#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Fllr/Fllr.csproj Fllr/
COPY Fllr.Application/Fllr.Application.csproj Fllr.Application/
COPY Fllr.Image.Application/Fllr.Image.Generator.csproj Fllr.Image.Application/
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
