using Microsoft.EntityFrameworkCore;
using SeriesPage.Model.Seasons.Entities;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Seasons.Abstracts;
using Shared.Repositories;

namespace SeriesPage.Repository.Seasons.Concretes;

public class SeasonRepository(AppDbContext context) : BaseRepository<AppDbContext, Season, int>(context), ISeasonRepository
{
    public async Task<Season?> GetBySeasonNumberAsync(int seasonNumber) => 
        await context.Seasons.FirstOrDefaultAsync(x => x.SeasonNumber == seasonNumber);

    public async Task<Season?> GetWithEpisodesBySeasonNumberAsync(int seasonNumber) =>
        await context.Seasons
            .Include(s => s.Episodes) 
            .FirstOrDefaultAsync(x => x.SeasonNumber == seasonNumber);
    
    public async Task<List<Season>> GetAllWithEpisodesAsync() =>
        await context.Seasons
            .Include(s => s.Episodes) 
            .ToListAsync();

}

