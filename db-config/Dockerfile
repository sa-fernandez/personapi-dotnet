FROM mcr.microsoft.com/mssql/server:2019-latest

WORKDIR /usr/src/app

COPY . /usr/src/app

USER root
RUN chmod +x entrypoint.sh
RUN chmod +x run-initialization.sh

ENV ACCEPT_EULA Y
ENV MSSQL_SA_PASSWORD sebaspipfer123*A
ENV MSSQL_PID Express

EXPOSE 1433

ENTRYPOINT ["./entrypoint.sh"]