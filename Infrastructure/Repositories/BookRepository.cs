using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepositories
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddBookAsync(Book book, List<int> genreIds)
    {
        var genres = await GetGenresAsync(genreIds);
        if (genres == null)
        {
            return false;
        }
        book.Genres = genres;
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
        var book = await _context.Books
            .Include(x => x.Genres)
            .FirstOrDefaultAsync(x => x.Id == id);
        return book ?? new();
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Books
            .Include(x => x.Genres)
            .ToListAsync();
    }

    public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorid)
    {
        return await _context.Books
            .Include(x => x.Genres)
            .Where(x => x.AuthorId == authorid)
            .ToListAsync();
    }

    public async Task<bool> UpdateBookAsync(Book book, List<int> genreIds)
    {
        var existingBook = await _context.Books
            .Include(x => x.Genres)
            .FirstOrDefaultAsync(x => x.Id == book.Id);
        if (existingBook != null)
        {
            var genres = await GetGenresAsync(genreIds);
            if (genres == null)
            {
                return false;
            }
            existingBook.Title = book.Title;
            existingBook.PublishedYear = book.PublishedYear;
            existingBook.TotalCopies = book.TotalCopies;
            existingBook.Genres = genres;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    private async Task<List<Genre>?> GetGenresAsync(List<int> genreIds)
    {
        var uniqueGenreIds = genreIds.Distinct().ToList();
        var genres = await _context.Genres
            .Where(x => uniqueGenreIds.Contains(x.Id))
            .ToListAsync();
        return genres.Count == uniqueGenreIds.Count ? genres : null;
    }
}