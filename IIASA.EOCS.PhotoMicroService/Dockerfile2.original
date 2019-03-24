FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY IIASA.EOCS.PhotoMicroService/IIASA.EOCS.PhotoMicroService.csproj IIASA.EOCS.PhotoMicroService/
RUN dotnet restore IIASA.EOCS.PhotoMicroService/IIASA.EOCS.PhotoMicroService.csproj
COPY . .
WORKDIR /src/IIASA.EOCS.PhotoMicroService
RUN dotnet build IIASA.EOCS.PhotoMicroService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish IIASA.EOCS.PhotoMicroService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IIASA.EOCS.PhotoMicroService.dll"]
