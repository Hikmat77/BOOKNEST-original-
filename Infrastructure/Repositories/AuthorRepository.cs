using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext appDbContext) : IAuthorReporisotories
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddAuthorAsync(Author author)
    {
        _context.Authors.Add(author);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if (author != null)
        {
            _context.Authors.Remove(author);
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        return author ?? new();
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await _context.Authors
            .Include(x => x.Books)
            .ThenInclude(x => x.Genres)
            .ToListAsync();
    }

    public async Task<bool> UpdateAuthorAsync(Author author)
    {
        var existingAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);
        if (existingAuthor != null)
        {
            existingAuthor.Fullname = author.Fullname;
            existingAuthor.Country = author.Country;
            existingAuthor.BirthYear = author.BirthYear;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<int> GetAuthorsAmountAsync()
    {
        return await _context.Authors.CountAsync();
    }
}