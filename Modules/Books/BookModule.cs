
using BookCaseApp.Modules.Books.Repositories;
using BookCaseApp.Modules.Books.Services;
namespace BookCaseApp.Modules.Books;

public static class BookModule {
  public static IServiceCollection AddBookModule(this IServiceCollection services) {

    services.AddScoped<BookRepository>();
    services.AddScoped<BookService>();

    return services;
  }
}