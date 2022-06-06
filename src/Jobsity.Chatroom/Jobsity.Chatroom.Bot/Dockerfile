#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jobsity.Chatroom.Bot/Jobsity.Chatroom.Bot.csproj", "Jobsity.Chatroom.Bot/"]
RUN dotnet restore "Jobsity.Chatroom.Bot/Jobsity.Chatroom.Bot.csproj"
COPY . .
WORKDIR "/src/Jobsity.Chatroom.Bot"
RUN dotnet build "Jobsity.Chatroom.Bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jobsity.Chatroom.Bot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jobsity.Chatroom.Bot.dll"]