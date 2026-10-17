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

## Ejemplo CRUD Minimal Api

```c#

app.MapGet("/books", (AppDbContext context) => {
  return context.Books.ToList();
});

app.MapPost("/books", (AppDbContext context, Book book) => {
  // var book = new Book { Title = "1984", Description = "Novela distópica" };
  context.Books.Add(book);
  context.SaveChanges();

  return book;
});

app.MapGet("/book/{id}", (AppDbContext context, int id) => {
  var book = context.Books.FirstOrDefault((book) => book.Id == id);

  if (book is null) {
    return Results.NotFound(new { Message = $"El libro con el id {id} no existe." });
  }

  return Results.Ok(book);
});

app.MapDelete("/book/{id}", (AppDbContext context, int id) => {
  var book = context.Books.FirstOrDefault((book) => book.Id == id);

  if (book is null) {
    return Results.NotFound(new { Message = $"El libro con el id {id} no existe." });
  }

  context.Books.Remove(book);
  context.SaveChanges();

  return Results.Ok(new { deleted = book });
});

app.MapPut("/book/{id}", (AppDbContext context, int id, Book book) => {
  var oldBook = context.Books.FirstOrDefault((book) => book.Id == id);

  if (oldBook is null) {
    return Results.NotFound(new { Message = $"El libro con el id {id} no existe." });
  }

  oldBook.Title = book.Title;
  oldBook.Description = book.Description;

  context.SaveChanges();

  return Results.Ok(new { Message = "El libro fue actualizado con éxito" });

});
```
