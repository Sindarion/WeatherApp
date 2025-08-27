# Build Angular
FROM node:20 AS ui-build
WORKDIR /ui
COPY ui/package*.json ./
RUN npm install
COPY ui/ ./
# 👇 build Angular with relative paths for HA ingress
RUN npm run build -- --configuration production --base-href ./ --deploy-url ./

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
# 👇 Angular output folder for Angular 20 (has /browser inside)
COPY --from=ui-build /ui/dist/ui/browser ./wwwroot

COPY run.sh /run.sh
RUN chmod +x /run.sh
ENTRYPOINT ["/run.sh"]



# # Build Angular
# FROM node:20 AS ui-build
# WORKDIR /ui
# COPY ui/package*.json ./
# RUN npm install
# COPY ui/ ./
# # RUN npm run build --prod
# RUN npm run build -- --configuration production --base-href ./


# # Build ASP.NET Core
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# COPY api/*.csproj ./api/
# RUN dotnet restore ./api/api.csproj
# COPY api/ ./api/
# WORKDIR /src/api
# RUN dotnet publish -c Release -o /app/publish

# # Final runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
# WORKDIR /app
# COPY --from=build /app/publish ./
# COPY --from=ui-build /ui/dist/ui/browser ./wwwroot
# # ENTRYPOINT ["dotnet", "api.dll"]

# COPY run.sh .
# RUN chmod +x run.sh

# ENTRYPOINT ["./run.sh"]