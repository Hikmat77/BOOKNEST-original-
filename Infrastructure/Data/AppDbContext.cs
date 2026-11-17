using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("books");
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Title).HasColumnName("title");
            entity.Property(x => x.PublishedYear).HasColumnName("publishedyear");
            entity.Property(x => x.TotalCopies).HasColumnName("totalcopies");
            entity.Property(x => x.AuthorId).HasColumnName("authorid");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("authors");
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Fullname).HasColumnName("fullname");
            entity.Property(x => x.Country).HasColumnName("country");
            entity.Property(x => x.BirthYear).HasColumnName("birthyear");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Name).HasColumnName("name");
        });
    }
}