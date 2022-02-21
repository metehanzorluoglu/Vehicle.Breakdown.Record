FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as build
EXPOSE 5432
WORKDIR /app
COPY ./Vehicle.Breakdown.Record.Entity/*.csproj ./Vehicle.Breakdown.Record.Entity/
COPY ./Vehicle.Breakdown.Record.DAL/*.csproj ./Vehicle.Breakdown.Record.DAL/
COPY ./VehicleBreakdownRecor.Business/*.csproj ./VehicleBreakdownRecor.Business/
COPY ./VehicleBreakdownListRecord.API/*.csproj ./VehicleBreakdownListRecord.API/
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet publish ./VehicleBreakdownListRecord.API/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT [ "dotnet","VehicleBreakdownListRecord.API.dll" ]