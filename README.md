# GAP_Test
Prueba tecnica GAP 

MANUAL DE CONFIGURACIÓN
Prueba Tecnica: Aplicación de seguros.
PHANOR MESIAS
El presente documento tiene como objeto explicar la manera de desplegar y ejecutar la aplicación de prueba desarrollada por Phanor Mesias par GAP.
1.	Contenido de la solución.

La solución se encuentra en la carpeta “PruebaTecnicaPhanorMesias” y consta de:

a.	Servicio API Rest (.NET Core 3.1) - Nombre ServiciosSeguros
b.	Proyecto de prueba unitaria para el servicio “Polizas” - Nombre ServicioSeguroTest
c.	Aplicación web para front (.NET Framework 4.7 – C#) - Nombre AplicacionWebSeguros
d.	Proyecto de Base de datos - Nombre dbSeguros

Para los proyectos de servicios api y aplicación web se usó VS 2019 cono editor.

Como parte de la solución es necesario una base de datos. Se construyó una base de datos SQL Server 2019. En la carpeta “Base de datos” se encuentra el backup de ella así como su script de creación.

2.	Restaurar base de datos.

La base de datos se puede crear de 2 maneras:

•	Restaurando el backup que se encuentra en la carpeta “Base de datos” de nombre dbSeguros.bak.
Para esto se necesita abrir el SQL Mangement Studio, click derecho en “Databases” y clic en “Restore Database”
•	Ejecutando el script de creación que se encuentra en la carpeta “Base de datos” de nombre scriptCreacion_dbSeguros.sql.
Se abre una ventana en el SQL Mangement Studio y se ejecuta el script.
La solución cuenta con un proyecto de datos de nombre “dbSeguros” que sirve para observar la estructura de la base de datos. Tambien se puede restaurar desde este proyecto la base de datos. Pero sería necesario poblar las tablas para su correcto funcionamiento.
3.	Configurar Servicio API.

Se debe configurar el script de creación de base de datos en el archivo appsettings.json del proyecto ServiciosSeguros:

En la propiedad “dbSegurosDBConnection” del parámetro ConnectionStrings agregar los valores para la conexión a la base de datos:

"ConnectionStrings": {
    "dbSegurosDBConnection": "Server=NOMBRE_SERVIDOR;Database=dbSeguros;UID=USUARIO;PWD=CONTRASEÑA;"
  }

4.	Configurar aplicación Web

Es necesario definir la ruta de donde se despliegan los servicios. Esto se hace en el archivo web.config del proyecto AplicacionWebSeguros modificando los siguientes parámetros de la sección appSettings:
<add key="urlServicioUsuario" value="https://localhost:44346/api/Usuario/" />
    	<add key="urlServicioPoliza" value="https://localhost:44346/api/Poliza/" />
<add key="urlServicioCliente" value="https://localhost:44346/api/Cliente/" />

Se debe cambiar “localhost:44346” por la ruta en que se despliegan los servicios.
