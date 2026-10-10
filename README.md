# RestApi Bookcase App

## Instalación de paquetes

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

## Contenedor de PostgreSQL

```shell
docker run --name nombre_contenedor \
-e POSTGRES_PASSWORD=root \
-e POSTGRES_USER=root \
-e POSTGRES_DB=nombre_db \
--volume ibisi-data:/var/lib/postgresql \
-dp 5432:5432 postgres:18
```

## Configurar cadena de conexión

```json
"ConnectionStrings": {
    "postgresConnection":"Host=localhost;Port=5432;Database=dbname;Username=root;Password=root"
  }
```

## Migracion

### Crear la migración

```shell
dotnet ef migrations add Initial
```

### Actualizar la base de datos

````shell
dotnet ef database update
```
````
