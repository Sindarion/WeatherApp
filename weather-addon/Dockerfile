# ---- Build Angular ----
FROM node:20 AS build-ui
WORKDIR /src/ui
COPY ui/ .
RUN npm install && npm run build --prod

# ---- Build API ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-api
WORKDIR /src/api
COPY api/ .
RUN dotnet publish -c Release -o /out

# ---- Final Runtime ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-api /out .
COPY --from=build-ui /src/ui/dist/ui /app/wwwroot
EXPOSE 5000
ENTRYPOINT ["dotnet", "Api.dll"]
