using BookCaseApp.Modules.Books.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCaseApp.Modules.Books.Controllers;


[ApiController]
[Route("/api/books")]
public class BookController(BookService bookService) : ControllerBase {
  private readonly BookService _bookService = bookService;

  [HttpGet]
  public IActionResult FindAll() {
    return Ok(_bookService.FindAll());
  }
}