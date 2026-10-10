namespace BookCaseApp.Modules.Books.Entities;

public class Book {
  public int Id { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
}