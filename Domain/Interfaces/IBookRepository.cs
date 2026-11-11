using Domain.Models;
namespace Domain.Interfaces;

public interface IBookRepositories
{
    Task<bool> AddBookAsync(Book book);
    Task<bool> UpdateBookAsync(Book book);
    Task<bool> DeleteBookAsync(int id);
    Task<Book> GetBookAsync(int id);
    Task<List<Book>> GetBooksAsync();
    List<Book> GetBooksByAuthorId(int authorid);
}