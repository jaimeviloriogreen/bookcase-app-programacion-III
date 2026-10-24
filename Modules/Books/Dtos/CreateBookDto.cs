using System.ComponentModel.DataAnnotations;

namespace BookCaseApp.Modules.Books.Dtos;

public class CreateBookDto {
  public Guid Uuid { get; set; }

  [Required(ErrorMessage = "El título es requerido")]
  public required string Title { get; set; }

  [Required(ErrorMessage = "La descripción es requerida")]
  public required string Description { get; set; }
}