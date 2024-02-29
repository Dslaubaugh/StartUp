FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN apt-get update
RUN apt-get install curl -y
RUN curl -sL https://deb.nodesource.com/setup_16.x |  bash -
RUN apt-get update && apt-get install -y nodejs

WORKDIR /src
COPY [".", "."]
RUN dotnet restore "StartUp.Web/StartUp.Web.csproj"

WORKDIR "/src/StartUp.Web"
RUN dotnet publish "StartUp.Web.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "StartUp.Web.dll"]