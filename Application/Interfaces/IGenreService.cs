using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IGenreService
{
    Task<ApiResponse<bool>> AddGenreAsync(CreateGenreDto dto);
    Task<ApiResponse<bool>> UpdateGenreAsync(int id, UpdateGenreDto dto);
    Task<ApiResponse<bool>> DeleteGenreAsync(int id);
    Task<ApiResponse<GenreDto>> GetGenreAsync(int id);
    Task<ApiResponse<List<GenreDto>>> GetGenresAsync();
}
