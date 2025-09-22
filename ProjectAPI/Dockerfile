# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#
## This stage is used to build the service project
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["ProjectAPI.csproj", "."]
#RUN dotnet restore "./ProjectAPI.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "./ProjectAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## This stage is used to publish the service project to be copied to the final stage
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./ProjectAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish 
#
## This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProjectAPI.dll"]

#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
#WORKDIR /src
#COPY ProjectAPI
#WORKDIR /app
#RUN dotnet publish -c Release -o /app/publish
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 as final
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "ProjectAPI.dll"]
# —борка проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
 ENV ASPNETCORE_URLS=http://0.0.0.0:8080
COPY ProjectAPI/ProjectAPI.csproj ./ProjectAPI/
RUN dotnet restore ./ProjectAPI/ProjectAPI.csproj
 
COPY . .
WORKDIR /src/ProjectAPI
RUN dotnet publish -c Release -o /app/publish
 
# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProjectAPI.dll"]