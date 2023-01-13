# Configuracion de Docker
https://builtin.com/software-engineering-perspectives/sql-server-management-studio-mac

## Comando para Mac inciar Docker

docker run -d --name sql_server_test -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=reallyStrongPwd123' -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest


## Comandos para utilizar CLI de EF (Entity Framework)

https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

Para realizar una miggracion por medio de los comandos

`dotnet ef migrations add NewFeatureName`

y para actualizar la base de datos utilizamos en el siguiente comando

`dotnet ef database update`