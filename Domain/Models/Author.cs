namespace Domain.Models;

public class Author
{
    public int Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int BirthYear { get; set; }
}