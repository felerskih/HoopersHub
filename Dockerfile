# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# Install Node.js for npm build steps
RUN apt-get update && apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
    apt-get install -y nodejs && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /src

COPY HooperHub/*.csproj ./HooperHub/
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/
RUN dotnet restore HooperHub/HooperHub.csproj

COPY . .

RUN cd HooperHub && npm install
RUN dotnet publish HooperHub/HooperHub.csproj -c Release -o /app/publish --no-restore

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=build /app/publish .

RUN chown -R app:app /app
USER app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV PORT=8080
EXPOSE 8080

ENV DOTNET_EnableDiagnostics=0
ENV DOTNET_gcServer=1

ENTRYPOINT ["dotnet", "HooperHub.dll"]