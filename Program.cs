
using BookCaseApp.Data;
using BookCaseApp.Modules.Books;
using BookCaseApp.Modules.Books.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<AppDbContext>(option => {
  option.UseNpgsql(builder.Configuration.GetConnectionString("postgresConnection"));
});
builder.Services.AddBookModule();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run("http://localhost:3000");