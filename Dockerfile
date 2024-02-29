FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
EXPOSE 80
EXPOSE 443

COPY ["LearnASkill.csproj", "./"]
RUN dotnet restore "LearnASkill.csproj"

COPY . .
RUN dotnet build "LearnASkill.csproj" -c Release -o /app/build

RUN dotnet publish "LearnASkill.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "LearnASkill.dll"]
