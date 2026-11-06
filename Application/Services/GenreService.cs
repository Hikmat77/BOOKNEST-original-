using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;      
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepositories genreRepository) : IGenreService
{
    private IGenreRepositories _repository = genreRepository;
    public async Task AddGenreAsync(Genre genre)
    {
        await _repository.AddGenreAsync(genre);
        System.Console.WriteLine("Added successfully!");
    }

    public async Task DeleteGenreAsync(int id)
    {
        await _repository.DeleteGenreAsync(id);
        System.Console.WriteLine("Deleted successfully!");
    }

    public async Task GetAllGenresAsync()
    {
        var genres = await _repository.GetGenresAsync();
        foreach (var genre in genres)
        {
            System.Console.WriteLine($"{genre.Id} | {genre.Name}");
        }
    }

    public async Task GetGenreAsync(int id)
    {
        var genre = await _repository.GetGenreAsync(id);
        System.Console.WriteLine($"{genre.Id} | {genre.Name}");
    }

    public async Task UpdateGenreAsync(Genre genre)
    {
        await _repository.UpdateGenreAsync(genre);
        System.Console.WriteLine("Updated successfully!");
    }

    public async Task<ApiResponse<List<Genre>>> GetGenresAsync()
    {
        var res = await _repository.GetGenresAsync();
        return new ApiResponse<List<Genre>>(HttpStatusCode.OK, "List of genres.", res);
    }

}