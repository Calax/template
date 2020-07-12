FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS publish
WORKDIR /src

COPY *.sln .
COPY Service.Template.Repository.Migrations/Service.Template.Repository.Migrations.csproj ./Service.Template.Repository.Migrations/
COPY Service.Template.Repository/Service.Template.Repository.csproj ./Service.Template.Repository/
COPY Service.Template.Client/Service.Template.Client.csproj ./Service.Template.Client/
COPY Service.Template.Tests/Service.Template.Tests.UnitTests/Service.Template.Tests.UnitTests.csproj ./Service.Template.Tests/Service.Template.Tests.UnitTests/
COPY Service.Template.Host/Service.Template.Host.csproj ./Service.Template.Host/
RUN dotnet restore Service.Template.sln

COPY . .
RUN dotnet publish Service.Template.Host/Service.Template.Host.csproj -c Release -r linux-x64 -o /app

FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1-buster-slim AS runtime
WORKDIR /app
COPY --from=publish /app .
EXPOSE 9876
ENTRYPOINT ["./Service.Template.Host"]
