FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.2-buster-slim AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/core/sdk:3.1.200-buster AS build

# Version
ARG version=1.2.0
# Token for Sonarqube
ARG sonar_login=359be3330fa97e3a428c989990328694ba1b1f0e

# Java (for Sonarqube)
RUN apt-get update && \
    apt-get install -y openjdk-11-jre-headless && \
    apt-get clean;

RUN java --version

# Reportgenerator for Code Coverage Reports
RUN dotnet tool install dotnet-reportgenerator-globaltool --version 4.5.2 --tool-path /tools

# Sonarqube
RUN dotnet tool install dotnet-sonarscanner --tool-path /tools

WORKDIR /src
RUN /tools/dotnet-sonarscanner begin \
    /k:corona-api \
    /v:$version \
    /d:sonar.login=$sonar_login \
    /d:sonar.host.url=https://192.168.1.35:9000 \
    /d:sonar.verbose=true \
    /d:sonar.cs.vstest.reportsPaths=/testresults/test_results.xml \
    /d:sonar.cs.opencover.reportsPaths=/testresults/coverage/coverage.opencover.xml

COPY corona-api/corona-api.csproj corona-api/
COPY corona-api-tests/corona-api-tests.csproj corona-api-tests/
RUN dotnet restore

COPY corona-api corona-api/

RUN dotnet build -c Release -o /app/build


FROM build AS test

WORKDIR /src
COPY run-tests.sh .
COPY corona-api-tests corona-api-tests/

RUN ls -laR .sonarqube

RUN ["chmod", "+x", "/src/run-tests.sh"]
ENTRYPOINT ["/src/run-tests.sh"]


FROM build as sonar
ARG sonar_login=
ENV sonar_login=$sonar_login

CMD /tools/dotnet-sonarscanner end /d:sonar.login=$sonar_login

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "corona.dll"]