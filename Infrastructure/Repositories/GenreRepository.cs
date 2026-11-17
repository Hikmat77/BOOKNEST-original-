using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenreRepository(AppDbContext appDbContext) : IGenreRepositories
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddGenreAsync(Genre genre)
    {
        _context.Genres.Add(genre);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteGenreAsync(int id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        if (genre != null)
        {
            _context.Genres.Remove(genre);
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Genre> GetGenreAsync(int id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        return genre ?? new();
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<bool> UpdateGenreAsync(Genre genre)
    {
        var existingGenre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genre.Id);
        if (existingGenre != null)
        {
            existingGenre.Name = genre.Name;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<int> GetGenresAmountAsync()
    {
        return await _context.Genres.CountAsync();
    }
}