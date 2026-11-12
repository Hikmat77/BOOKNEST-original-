using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepositories genreRepository) : IGenreService
{
    private IGenreRepositories repository = genreRepository;
    public async Task<ApiResponse<bool>> AddGenreAsync(CreateGenreDto dto)
    {
        var genre = new Genre()
        {
            Name = dto.Name
        };
        var res = await repository.AddGenreAsync(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteGenreAsync(int id)
    {
        var res = await repository.DeleteGenreAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<GenreDto>> GetGenreAsync(int id)
    {
        var genre = await repository.GetGenreAsync(id);
        var res = new GenreDto()
        {
            Id = genre.Id,
            Name = genre.Name
        };
        return new ApiResponse<GenreDto>(HttpStatusCode.OK, "Genre with given id.", res);
    }

    public async Task<ApiResponse<List<GenreDto>>> GetGenresAsync()
    {
        var genres = await repository.GetGenresAsync();
        var res = genres.Select(x=>new GenreDto()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
        return new ApiResponse<List<GenreDto>>(HttpStatusCode.OK, "List of genres.", res);
    }

    public async Task<ApiResponse<bool>> UpdateGenreAsync(int id, UpdateGenreDto dto)
    {
        var genre = new Genre()
        {
            Id = id,
            Name = dto.Name
        };
        var res = await repository.UpdateGenreAsync(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
