# CommentsAPI
Prueba técnica desarrollador Backend – primer punto

Nombre proyecto: CommentsAPI

ULR Github: https://github.com/ccochoam/CommentsAPI.git

Tecnologías: El proyecto fue desarrollado en Visual Studio 2022 con .NET 7 y SQL Server.


Instrucciones:

Luego de la descarga del proyecto y de ser abierto, se deben seguir las siguientes instrucciones para su correcta ejecución.

Configurar la cadena de conexión a la base de datos SQL Server
•	En el archivo appsettings.json debe agregarse en el Json, dentro de DefaultConnection el nombre del servidor donde se va a restaurar la base de datos.

Configurar base de datos:
•	En SQL Server, debe ejecutarse el script SQL que se encuentra dentro del archivo scriptDB.sql ubicado dentro de la raíz del proyecto. Este creará la base de datos PraxedesBD que contiene dos tablas necesarias para la administración de los datos que procesará el API.

Ejecución:

Luego, antes de ejecutar el proyecto, se recomienda ejecutar en el terminal de comandos, la instrucción dotnet restore, con el fin de que se descarguen posibles paquetes que no fueron restaurados automáticamente.

Luego se puede realizar la ejecución y el consumo de cada uno de los Endpoint del API Rest según las especificaciones de la prueba.

