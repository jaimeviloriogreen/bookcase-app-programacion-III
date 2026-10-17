using BookCaseApp.Data;
using BookCaseApp.Modules.Books.Entities;

namespace BookCaseApp.Modules.Books.Repositories;

public class BookRepository(AppDbContext dbContext) {
  public readonly AppDbContext _dbContext = dbContext;
  public List<Book> FindAll() {
    return _dbContext.Books.ToList();
  }
}