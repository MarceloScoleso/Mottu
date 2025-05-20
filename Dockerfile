FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app


RUN addgroup --system appgroup && adduser --system appuser --ingroup appgroup
USER appuser


COPY --from=build /app/publish .


EXPOSE 80


ENTRYPOINT ["dotnet", "Mottu.dll"]
