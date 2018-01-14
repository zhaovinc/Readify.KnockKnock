FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 5000
LABEL version "1.1.3"
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Readify.KnockKnock.Endpoint.dll"]