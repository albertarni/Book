# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY "./BiblioNet.Core/BiblioNet.Core.csproj" "./BiblioNet.Core/BiblioNet.Core.csproj"
RUN dotnet restore "./BiblioNet.Core/BiblioNet.Core.csproj" --disable-parallel
COPY "./BiblioNet.Application/BiblioNet.Application.csproj" "./BiblioNet.Application/BiblioNet.Application.csproj"
RUN dotnet restore "./BiblioNet.Application/BiblioNet.Application.csproj" --disable-parallel
COPY "./BiblioNet.Infrastructure/BiblioNet.Infrastructure.csproj" "./BiblioNet.Infrastructure/BiblioNet.Infrastructure.csproj"
RUN dotnet restore "./BiblioNet.Infrastructure/BiblioNet.Infrastructure.csproj" --disable-parallel
COPY "./BiblioNet/BiblioNet.csproj" "./BiblioNet/BiblioNet.csproj"
RUN dotnet restore "./BiblioNet/BiblioNet.csproj" --disable-parallel
COPY . .
RUN dotnet publish "./BiblioNet/BiblioNet.csproj" -c release -o /app 

# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
RUN ls -al
ENTRYPOINT ["dotnet","BiblioNet.dll", "--urls", "http://*:5000"]