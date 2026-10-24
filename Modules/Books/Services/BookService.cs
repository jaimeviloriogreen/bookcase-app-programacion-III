using BookCaseApp.Modules.Books.Entities;
using BookCaseApp.Modules.Books.Repositories;

namespace BookCaseApp.Modules.Books.Services;

public class BookService(BookRepository bookRepository) {
  public readonly BookRepository _bookRepository = bookRepository;

  public List<Book> FindAll() {
    return _bookRepository.FindAll();
  }

  public void Create(Book book) {
    _bookRepository.Create(book);
  }

  public Book? FindOne(Guid uuid) {
    return _bookRepository.FindOne(uuid);
  }

  public bool Delete(Guid uuid) {
    return _bookRepository.Delete(uuid);
  }

  public bool Patch(Guid uuid, string? title, string? description) {
    return _bookRepository.Patch(uuid, title, description);
  }
}