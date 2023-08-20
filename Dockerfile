FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app

COPY ["basecode.sln", "./"]
COPY ["./basecode/basecode.csproj", "./basecode"]
COPY ["./basecode/basecode.Test.csproj", "./basecode"]

RUN dotnet restore 
COPY . ./
RUN dotnet publish -c Release -o out

FROM nginx:1.23.0-alpine
WORKDIR /app
EXPOSE 8080
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/out/wwwroot /usr/share/nginx/html