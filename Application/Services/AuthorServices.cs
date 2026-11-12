using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorServices(
    IAuthorReporisotories authorReporisotories,
    IBookRepositories bookRepositories
    ) : IAuthorService
{
    private IAuthorReporisotories repository = authorReporisotories;
    private readonly IBookRepositories _bookRepository = bookRepositories;

    public async Task<ApiResponse<bool>> AddAuthorAsync(CreateAuthorDto dto)
    {
        var author = new Author()
        {
            Fullname = dto.Fullname,
            Country = dto.Country,
            BirthYear = dto.BirthYear
        };
        var res = await repository.AddAuthorAsync(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteAuthorAsync(int id)
    {
        var res = await repository.DeleteAuthorAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<AuthorDto>> GetAuthorAsync(int id)
    {
        var author = await repository.GetAuthorAsync(id);
        var res = new AuthorDto()
        {
            Id = author.Id,
            Fullname = author.Fullname,
            Country = author.Country,
            BirthYear = author.BirthYear
        };
        return new ApiResponse<AuthorDto>(HttpStatusCode.OK, "Author with given id.", res);
    }

    public async Task<ApiResponse<List<AuthorDto>>> GetAuthorsAsync()
    {
        var authors = await repository.GetAuthorsAsync();
        var res = authors.Select(x=>new AuthorDto()
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Country = x.Country,
            BirthYear = x.BirthYear
        }).ToList();
        return new ApiResponse<List<AuthorDto>>(HttpStatusCode.OK, "List of authors.", res);
    }

    public async Task<ApiResponse<List<AuthorWithBooks>>> GetAuthorsWithBooksAsync()
    {
        var authors = await repository.GetAuthorsAsync();
        var res = new List<AuthorWithBooks>();
        foreach (var x in authors)
        {
            var books = _bookRepository.GetBooksByAuthorId(x.Id);
            res.Add(new AuthorWithBooks()
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Country = x.Country,
                BirthYear = x.BirthYear,
                Books = books.Select(b=>new BookDto()
                {
                    Id = b.Id,
                    Title = b.Title,
                    PublishedYear = b.PublishedYear,
                    TotalCopies = b.TotalCopies,
                    AuthorId = b.AuthorId
                }).ToList()
            });
        }
        return new ApiResponse<List<AuthorWithBooks>>(HttpStatusCode.OK, "List of authors with books.", res);
    }

    public async Task<ApiResponse<bool>> UpdateAuthorAsync(int id, UpdateAuthorDto dto)
    {
        var author = new Author()
        {
            Id = id,
            Fullname = dto.Fullname,
            Country = dto.Country,
            BirthYear = dto.BirthYear
        };
        var res = await repository.UpdateAuthorAsync(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
