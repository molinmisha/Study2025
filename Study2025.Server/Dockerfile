# ���������� .NET SDK ��� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .  
#ENV ASPNETCORE_ENVIRONMENT=Docker
RUN dotnet restore  
RUN dotnet publish -c Release -o /out  

# ���������� Runtime ��� �������  
FROM mcr.microsoft.com/dotnet/aspnet:8.0  
WORKDIR /app  
COPY --from=build /out .  
ENTRYPOINT ["dotnet", "Study2025.Server.dll"]

#
## ���������� ����������� ����� SDK ��� ������
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
## �������� ����� ������� � ��������������� �����������
#COPY *.sln ./
#COPY /Study2025.Server/*.csproj ./Study2025.Server/
#RUN dotnet restore
#
## �������� ��������� ����� � �������� ������
#COPY Study2025.Server/. ./Study2025.Server/
#WORKDIR /src/Study2025.Server
#RUN dotnet publish -c Release -o /app/publish
#
## ������� ��������� �����
#FROM mcr.microsoft.com/dotnet/aspnet:7.0
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "Study2025.Server.dll"]