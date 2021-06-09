FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:3001
ENV ASPNETCORE_ENVIRONMENT Development
ENTRYPOINT [ "dotnet", "Backend.dll" ]
#EXPOSE 3000
#ENTRYPOINT ["dotnet", "watch", "run", "--no-restore", "Backend.dll"]
