FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app

COPY ["basecode.sln", "./"]
COPY ["./basecode/basecode.csproj", "./basecode/"]
COPY ["./basecode.Test/basecode.Test.csproj", "./basecode.Test/"]

RUN dotnet restore "./basecode/basecode.csproj"
RUN dotnet restore "./basecode.Test/basecode.Test.csproj"
COPY . ./
RUN dotnet build "./basecode.Test/basecode.Test.csproj" -c Release -o out
RUN dotnet publish "./basecode/basecode.csproj" -c Release -o out

FROM nginx:1.23.0-alpine
WORKDIR /app
EXPOSE 8080
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/out/wwwroot /usr/share/nginx/html