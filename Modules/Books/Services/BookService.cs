using BookCaseApp.Modules.Books.Entities;
using BookCaseApp.Modules.Books.Repositories;

namespace BookCaseApp.Modules.Books.Services;

public class BookService(BookRepository bookRepository) {
  public readonly BookRepository _bookRepository = bookRepository;

  public List<Book> FindAll() {
    return _bookRepository.FindAll();
  }
}