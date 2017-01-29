FROM microsoft/aspnetcore:1.1.0
WORKDIR /app
EXPOSE 5000
COPY . /app

# Fix-up permissions
RUN  find . -exec chown www-data:www-data {} \; \
  && find . -type f -exec chmod 444 {} \; \
  && find . -type d -exec chmod 555 {} \;

USER www-data
ENTRYPOINT ["dotnet"]
CMD ["BarnacleBudget.dll"]
