namespace Application.DTOs;

public class UpdateBookDto
{
    public string Title {get; set;}=null!;
    public int PublishedYear {get; set;}
    public int TotalCopies {get; set;}
}
