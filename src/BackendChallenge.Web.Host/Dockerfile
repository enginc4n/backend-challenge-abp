FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/BackendChallenge.Web.Host/BackendChallenge.Web.Host.csproj", "src/BackendChallenge.Web.Host/"]
COPY ["src/BackendChallenge.Web.Core/BackendChallenge.Web.Core.csproj", "src/BackendChallenge.Web.Core/"]
COPY ["src/BackendChallenge.Application/BackendChallenge.Application.csproj", "src/BackendChallenge.Application/"]
COPY ["src/BackendChallenge.Core/BackendChallenge.Core.csproj", "src/BackendChallenge.Core/"]
COPY ["src/BackendChallenge.EntityFrameworkCore/BackendChallenge.EntityFrameworkCore.csproj", "src/BackendChallenge.EntityFrameworkCore/"]
WORKDIR "/src/src/BackendChallenge.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BackendChallenge.Web.Host", "src/BackendChallenge.Web.Host"]
COPY ["src/BackendChallenge.Web.Core", "src/BackendChallenge.Web.Core"]
COPY ["src/BackendChallenge.Application", "src/BackendChallenge.Application"]
COPY ["src/BackendChallenge.Core", "src/BackendChallenge.Core"]
COPY ["src/BackendChallenge.EntityFrameworkCore", "src/BackendChallenge.EntityFrameworkCore"]
WORKDIR "/src/src/BackendChallenge.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BackendChallenge.Web.Host.dll"]
