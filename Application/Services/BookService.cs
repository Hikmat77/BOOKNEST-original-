using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BookService(IBookRepositories bookRepositories) : IBookService
{
    private IBookRepositories repository = bookRepositories;
    public async Task<ApiResponse<bool>> AddBookAsync(Book book)
    {
        var res = await repository.AddBookAsync(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteBookAsync(int id)
    {
        var res = await repository.DeleteBookAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<Book>> GetBookAsync(int id)
    {
        var res = await repository.GetBookAsync(id);
        return new ApiResponse<Book>(HttpStatusCode.OK, "Book with given id.", res);
    }

    public async Task<ApiResponse<List<Book>>> GetBooksAsync()
    {
        var res = await repository.GetBooksAsync();
        return new ApiResponse<List<Book>>(HttpStatusCode.OK, "List of books.", res);
    }

    public async Task<ApiResponse<bool>> UpdateBookAsync(Book book)
    {
        var res = await repository.UpdateBookAsync(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}