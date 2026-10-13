using Microsoft.EntityFrameworkCore;
using SeriesPage.Model.Seasons.Entities;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Seasons.Abstracts;
using Shared.Repositories;

namespace SeriesPage.Repository.Seasons.Concretes;

public class SeasonRepository(AppDbContext context) : BaseRepository<AppDbContext, Season, int>(context), ISeasonRepository
{
    public async Task<Season?> GetBySeasonNumberAsync(int seasonNumber) =>
        await Context.Seasons.FirstOrDefaultAsync(x => x.SeasonNumber == seasonNumber);

    public async Task<Season?> GetWithEpisodesBySeasonNumberAsync(int seasonNumber) =>
        await Context.Seasons
            .Include(s => s.Episodes.OrderBy(e => e.EpisodeNumber))
            .FirstOrDefaultAsync(x => x.SeasonNumber == seasonNumber);

    public async Task<List<Season>> GetAllWithEpisodesAsync() =>
        await Context.Seasons
            .Include(s => s.Episodes.OrderBy(e => e.EpisodeNumber))
            .OrderBy(s => s.SeasonNumber)
            .ToListAsync();
}
