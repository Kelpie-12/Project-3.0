#FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
#WORKDIR /app
#COPY . .
#WORKDIR /app
#RUN dotnet publish -c Release -o /app/publish
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 as final
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "Project 3.0.dll"]
FROM mysql:8.0

# ������������� ���������� ��������� ��� MySQL
ENV MYSQL_ROOT_PASSWORD=
ENV MYSQL_DATABASE=ComopanyProject

# �������� ���� ���� ������ � ����������� ���������� MySQL
COPY damp_db.sql /docker-entrypoint-initdb.d/