using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController(
    IGenreService genreService,
    ILogger<GenresController> logger) : ControllerBase
{
    private IGenreService service = genreService;
    private ILogger<GenresController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenre(CreateGenreDto dto)
    {
        _logger.LogInformation("POST api/Genres {date}", DateTime.Now);
        return await service.AddGenreAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGenre(int id, UpdateGenreDto dto)
    {
        _logger.LogInformation("PUT api/Genres/{id} {date}", id, DateTime.Now);
        return await service.UpdateGenreAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        _logger.LogInformation("DELETE api/Genres?id={id} {date}", id, DateTime.Now);
        return await service.DeleteGenreAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GenreDto>> GetGenre(int id)
    {
        _logger.LogInformation("GET api/Genres/{id} {date}", id, DateTime.Now);
        return await service.GetGenreAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GenreDto>>> GetGenres()
    {
        _logger.LogInformation("GET api/Genres {date}", DateTime.Now);
        return await service.GetGenresAsync();
    }
}
