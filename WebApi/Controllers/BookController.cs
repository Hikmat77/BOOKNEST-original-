using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    private IBookService service = bookService;

    [HttpGet]
    public async Task<ApiResponse<List<Book>>> GetBooks() => await service.GetBooksAsync();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Book>> GetBook(int id) => await service.GetBookAsync(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(Book book) => await service.AddBookAsync(book);

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id) => await service.DeleteBookAsync(id);

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateBook(Book book) => await service.UpdateBookAsync(book);
}