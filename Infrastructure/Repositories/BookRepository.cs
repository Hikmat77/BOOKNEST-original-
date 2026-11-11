using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepositories
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddBookAsync(Book book)
    {
        using var connection = _context.Connection();
        var query = "INSERT INTO books (title, publishedyear, totalcopies) VALUES (@title, @publishedyear, @totalcopies)";
        var res = await connection.ExecuteAsync(query, book);
        return res > 0;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "delete from books where id=@id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Book> GetBookAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from books where id=@id";
        var book = await connection.QuerySingleAsync<Book>(query, new { id });
        return book;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from books";
        return (await connection.QueryAsync<Book>(query)).ToList();
    }

    public List<Book> GetBooksByAuthorId(int authorid)
    {
        using var connection = _context.Connection();
        connection.Open();
        var books = connection.Query<Book>("select * from books where authorid=@authorid", new {authorid});
        return books.ToList();
    }


    public async Task<bool> UpdateBookAsync(Book book)
    {
        using var connection = _context.Connection();
        var query = "update books set title=@title, publishedyear=@publishedyear, totalcopies=@totalcopies where id=@id";
        var res = await connection.ExecuteAsync(query, book);
        return res > 0;
    }
}