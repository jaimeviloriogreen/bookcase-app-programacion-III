using BookCaseApp.Modules.Books.Dtos;
using BookCaseApp.Modules.Books.Entities;
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
  // http://localhost:3000/api/books/uuid-uuid-uuid-uuid-uuid
  [HttpGet("{uuid}")]
  public IActionResult FindOne(Guid uuid) {
    var book = _bookService.FindOne(uuid);

    if (book is null) {
      return NotFound(new { Message = "Libro no encontrado" });
    }

    return Ok(book);
  }

  [HttpPost]
  public IActionResult Create(CreateBookDto bookDto) {

    var book = new Book {
      Uuid = Guid.NewGuid(), // Aquí genero con código de C# el UUID
      Title = bookDto.Title,
      Description = bookDto.Description
    };

    _bookService.Create(book);

    return Created();
  }

  [HttpDelete("{uuid}")]
  public IActionResult Delete(Guid uuid) {
    var deleted = _bookService.Delete(uuid);

    if (!deleted) {
      return NotFound(new { Message = "El libro no se pudo eliminar." });
    }

    return Ok();
  }

  [HttpPatch("{uuid}")]
  public IActionResult Patch(Guid uuid, PatchBookDto patchBookDto) {
    var title = patchBookDto.Title;
    var description = patchBookDto.Description;

    var updated = _bookService.Patch(uuid, title, description);

    if (!updated) {
      return NotFound(new { Message = "El libro no se pudo actualizar." });
    }

    return Ok();

  }
}