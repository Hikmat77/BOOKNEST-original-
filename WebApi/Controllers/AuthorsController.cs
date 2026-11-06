using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService service = authorService;

    [HttpGet]
    public async Task<ApiResponse<List<Author>>> GetAuthors() => await service.GetAuthorsAsync();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Author>> GetAuthor(int id) => await service.GetAuthorAsync(id);
    
    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(Author author) => await service.AddAuthorAsync(author);
    
    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id) => await service.DeleteAuthorAsync(id);
    
    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(Author author) => await service.UpdateAuthorAsync(author);
}