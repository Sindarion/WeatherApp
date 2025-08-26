# Build Angular
FROM node:20 AS ui-build
WORKDIR /ui
COPY ui/package*.json ./
RUN npm install
COPY ui/ ./
# RUN npm run build --prod
RUN npm run build -- --configuration production --base-href ./


# Build ASP.NET Core
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY api/*.csproj ./api/
RUN dotnet restore ./api/api.csproj
COPY api/ ./api/
WORKDIR /src/api
RUN dotnet publish -c Release -o /app/publish

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish ./
COPY --from=ui-build /ui/dist/ui/browser ./wwwroot
ENTRYPOINT ["dotnet", "api.dll"]
