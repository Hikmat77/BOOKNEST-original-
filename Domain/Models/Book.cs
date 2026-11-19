namespace Domain.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int TotalCopies { get; set; } = 1;
    public int AuthorId {get; set;}
    public Author Author { get; set; } = null!;
    public List<Genre> Genres { get; set; } = [];
}