FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY TodoApi.csproj .
RUN dotnet restore TodoApi.csproj

COPY . .
RUN dotnet publish TodoApi.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TodoApi.dll"]