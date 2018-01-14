FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 5000
LABEL version "1.1.0"
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Readify.KnockKnock.Endpoint.dll"]