using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepositories
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book != null)
        {
            _context.Books.Remove(book);
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Book> GetBookAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        return book ?? new();
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorid)
    {
        return await _context.Books
            .Where(x => x.AuthorId == authorid)
            .ToListAsync();
    }

    public async Task<bool> UpdateBookAsync(Book book)
    {
        var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.PublishedYear = book.PublishedYear;
            existingBook.TotalCopies = book.TotalCopies;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}