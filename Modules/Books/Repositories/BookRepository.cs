using BookCaseApp.Data;
using BookCaseApp.Modules.Books.Entities;

namespace BookCaseApp.Modules.Books.Repositories;

public class BookRepository(AppDbContext dbContext) {
  public readonly AppDbContext _dbContext = dbContext;
  public List<Book> FindAll() {
    return _dbContext.Books.ToList();
  }

  public void Create(Book book) {
    _dbContext.Add(book);
    _dbContext.SaveChanges();
  }

  public Book? FindOne(Guid uuid) {
    return _dbContext.Books.FirstOrDefault((b) => b.Uuid == uuid);
  }

  public bool Delete(Guid uuid) {
    var book = _dbContext.Books.FirstOrDefault((b) => b.Uuid == uuid);

    if (book is null) {
      return false;
    }

    _dbContext.Books.Remove(book);
    _dbContext.SaveChanges();

    return true;

  }

  public bool Patch(Guid uuid, string? title, string? description) {
    var book = _dbContext.Books.FirstOrDefault((b) => b.Uuid == uuid);

    if (book is null) {
      return false;
    }

    if (title is not null || description is not null) {
      if (title is not null) {
        book.Title = title;
      }

      if (description is not null) {
        book.Description = description;
      }

      _dbContext.SaveChanges();
      return true;
    }

    return false;

  }

}