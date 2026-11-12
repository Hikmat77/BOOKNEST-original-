namespace Application.DTOs;

public class CreateAuthorDto
{
    public string Fullname {get; set;}=null!;
    public string Country {get; set;}=null!;
    public int BirthYear {get; set;}
}
