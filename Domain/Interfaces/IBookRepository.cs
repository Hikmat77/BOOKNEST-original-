using Domain.Models;
namespace Domain.Interfaces;

public interface IBookRepositories
{
    Task<bool> AddBookAsync(Book book, List<int> genreIds);
    Task<bool> UpdateBookAsync(Book book, List<int> genreIds);
    Task<bool> DeleteBookAsync(int id);
    Task<Book> GetBookAsync(int id);
    Task<List<Book>> GetBooksAsync();
    Task<List<Book>> GetBooksByAuthorIdAsync(int authorid);
}