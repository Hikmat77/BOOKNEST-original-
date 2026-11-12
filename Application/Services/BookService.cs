using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BookService(IBookRepositories bookRepositories) : IBookService
{
    private IBookRepositories repository = bookRepositories;
    public async Task<ApiResponse<bool>> AddBookAsync(CreateBookDto dto)
    {
        var book = new Book()
        {
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            TotalCopies = dto.TotalCopies,
            AuthorId = dto.AuthorId
        };
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

    public async Task<ApiResponse<BookDto>> GetBookAsync(int id)
    {
        var book = await repository.GetBookAsync(id);
        var res = new BookDto()
        {
            Id = book.Id,
            Title = book.Title,
            PublishedYear = book.PublishedYear,
            TotalCopies = book.TotalCopies,
            AuthorId = book.AuthorId
        };
        return new ApiResponse<BookDto>(HttpStatusCode.OK, "Book with given id.", res);
    }

    public async Task<ApiResponse<List<BookDto>>> GetBooksAsync()
    {
        var books = await repository.GetBooksAsync();
        var res = books.Select(x=>new BookDto()
        {
            Id = x.Id,
            Title = x.Title,
            PublishedYear = x.PublishedYear,
            TotalCopies = x.TotalCopies,
            AuthorId = x.AuthorId
        }).ToList();
        return new ApiResponse<List<BookDto>>(HttpStatusCode.OK, "List of books.", res);
    }

    public ApiResponse<List<BookDto>> GetBooksByAuthorIdAsync(int authorId)
    {
        var books = repository.GetBooksByAuthorId(authorId);
        var res = books.Select(x=>new BookDto()
        {
            Id = x.Id,
            Title = x.Title,
            PublishedYear = x.PublishedYear,
            TotalCopies = x.TotalCopies,
            AuthorId = x.AuthorId
        }).ToList();
        return new ApiResponse<List<BookDto>>(HttpStatusCode.OK, "List of books by author.", res);
    }

    public async Task<ApiResponse<bool>> UpdateBookAsync(int id, UpdateBookDto dto)
    {
        var book = new Book()
        {
            Id = id,
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            TotalCopies = dto.TotalCopies
        };
        var res = await repository.UpdateBookAsync(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
