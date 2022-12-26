FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN mkdir KjellBlazorDemo.App
COPY ["KjellBlazorDemo.App/KjellBlazorDemo.App.csproj", "KjellBlazorDemo.App/."]
RUN dotnet restore "KjellBlazorDemo.App/KjellBlazorDemo.App.csproj"
COPY . .
RUN dotnet build "KjellBlazorDemo.App/KjellBlazorDemo.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KjellBlazorDemo.App/KjellBlazorDemo.App.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf