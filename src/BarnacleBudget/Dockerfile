FROM microsoft/dotnet
WORKDIR /app
EXPOSE 80
COPY . /app
RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]