using System.ComponentModel.DataAnnotations;

namespace BookCaseApp.Modules.Books.Dtos;

public class PatchBookDto {

  [MinLength(3, ErrorMessage = "El título debe tener más de tres caracteres")]
  public string? Title { get; set; }

  [MinLength(3, ErrorMessage = "La descripción debe tener más de tres caracteres")]
  public string? Description { get; set; }
}