using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepositories
{
    Task<bool> AddGenreAsync(Genre genre);
    Task<bool> UpdateGenreAsync(Genre genre);
    Task<bool> DeleteGenreAsync(int id);
    Task<Genre> GetGenreAsync(int id);
    Task<List<Genre>> GetGenresAsync();
}