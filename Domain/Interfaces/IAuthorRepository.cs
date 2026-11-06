using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorReporisotories
{
    Task<bool> AddAuthorAsync(Author author);
    Task<bool> UpdateAuthorAsync(Author author);
    Task<bool> DeleteAuthorAsync(int id);
    Task<Author> GetAuthorAsync(int id);
    Task<List<Author>> GetAuthorsAsync();
}