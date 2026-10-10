
using BookCaseApp.Data;
using BookCaseApp.Modules.Books.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<AppDbContext>(option => {
  option.UseNpgsql(builder.Configuration.GetConnectionString("postgresConnection"));
});

var app = builder.Build();

app.MapGet("/books", (AppDbContext context) => {
  return context.Books.ToList();
});

app.MapPost("/books", (AppDbContext context, Book book) => {
  // var book = new Book { Title = "1984", Description = "Novela distópica" };
  context.Books.Add(book);
  context.SaveChanges();

  return book;
});

app.Run("http://localhost:3000");