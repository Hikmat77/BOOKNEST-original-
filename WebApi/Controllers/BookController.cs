using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(
    IBookService bookService,
    ILogger<BookController> logger) : ControllerBase
{
    private IBookService service = bookService;
    private ILogger<BookController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto dto)
    {
        _logger.LogInformation("POST api/Book {date}", DateTime.Now);
        return await service.AddBookAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateBook(int id, UpdateBookDto dto)
    {
        _logger.LogInformation("PUT api/Book/{id} {date}", id, DateTime.Now);
        return await service.UpdateBookAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        _logger.LogInformation("DELETE api/Book?id={id} {date}", id, DateTime.Now);
        return await service.DeleteBookAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<BookDto>> GetBook(int id)
    {
        _logger.LogInformation("GET api/Book/{id} {date}", id, DateTime.Now);
        return await service.GetBookAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        _logger.LogInformation("GET api/Book {date}", DateTime.Now);
        return await service.GetBooksAsync();
    }

    [HttpGet("by-author/{authorId:int}")]
    public ApiResponse<List<BookDto>> GetBooksByAuthorId(int authorId)
    {
        _logger.LogInformation("GET api/Book/by-author/{authorId} {date}", authorId, DateTime.Now);
        return service.GetBooksByAuthorIdAsync(authorId);
    }
}
