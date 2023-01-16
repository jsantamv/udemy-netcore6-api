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

##Versioning

Esta forma podemos personalizar por medio da la URL la version que se esta utilizando.

`csharp
    [ApiVersion("2.0")]    
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("GetData")]

        public IActionResult Get()
        {
            return Ok("This test v2");
        }
    }
`


## Logging

Microsoft.Extenxions.Logging
IloggerFActory

Serilog: Es una forma mas de almacenar el Log.  

>> logLevel
        - trace
        - debug
        - information
        - warning
        - Error
        - Critical
        - None

>> Sinks: Destination
    - Console
    - File
    - MSSqlServer
    - MongoDb
    - AmazonS2
    - AzureBlobStorage.

paquete para serilgo
`dotnet add package Serilog.AspNetCore`