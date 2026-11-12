using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<bool>> AddBookAsync(CreateBookDto dto);
    Task<ApiResponse<bool>> UpdateBookAsync(int id, UpdateBookDto dto);
    Task<ApiResponse<bool>> DeleteBookAsync(int id);
    Task<ApiResponse<BookDto>> GetBookAsync(int id);
    Task<ApiResponse<List<BookDto>>> GetBooksAsync();
    ApiResponse<List<BookDto>> GetBooksByAuthorIdAsync(int authorId);
}
