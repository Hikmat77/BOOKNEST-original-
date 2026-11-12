using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<bool>> AddAuthorAsync(CreateAuthorDto dto);
    Task<ApiResponse<bool>> UpdateAuthorAsync(int id, UpdateAuthorDto dto);
    Task<ApiResponse<bool>> DeleteAuthorAsync(int id);
    Task<ApiResponse<AuthorDto>> GetAuthorAsync(int id);
    Task<ApiResponse<List<AuthorDto>>> GetAuthorsAsync();
    Task<ApiResponse<List<AuthorWithBooks>>> GetAuthorsWithBooksAsync();
}
