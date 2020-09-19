FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY sln /sln
RUN dotnet publish --configuration Release --output /out /sln/Api

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build /out /app
WORKDIR /app
CMD [ "dotnet", "Api.dll" ]
