using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(
    IAuthorService authorService,
    ILogger<AuthorsController> logger) : ControllerBase
{
    private IAuthorService service = authorService;
    private ILogger<AuthorsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto dto)
    {
        _logger.LogInformation("POST api/Authors {date}", DateTime.Now);
        return await service.AddAuthorAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateAuthor(int id, UpdateAuthorDto dto)
    {
        _logger.LogInformation("PUT api/Authors/{id} {date}", id, DateTime.Now);
        return await service.UpdateAuthorAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        _logger.LogInformation("DELETE api/Authors?id={id} {date}", id, DateTime.Now);
        return await service.DeleteAuthorAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<AuthorDto>> GetAuthor(int id)
    {
        _logger.LogInformation("GET api/Authors/{id} {date}", id, DateTime.Now);
        return await service.GetAuthorAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        _logger.LogInformation("GET api/Authors {date}", DateTime.Now);
        return await service.GetAuthorsAsync();
    }

    [HttpGet("authors-with-books")]
    public async Task<ApiResponse<List<AuthorWithBooks>>> GetAuthorsWithBooks()
    {
        _logger.LogInformation("GET api/Authors/authors-with-books {date}", DateTime.Now);
        return await service.GetAuthorsWithBooksAsync();
    }
}
