namespace BookCaseApp.Data;

using BookCaseApp.Modules.Books.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
  public DbSet<Book> Books => Set<Book>();

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);
    // modelBuilder.Entity<Book>().Property(b => b.Uuid);
  }
}