FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Booking_PP/Booking_PP.csproj", "Booking_PP/"]
RUN dotnet restore "Booking_PP/Booking_PP.csproj"
COPY . .
WORKDIR "/src/Booking_PP"
RUN dotnet build "Booking_PP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking_PP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking_PP.dll"]