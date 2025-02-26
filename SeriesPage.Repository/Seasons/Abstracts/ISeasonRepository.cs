using SeriesPage.Model.Seasons.Entities;
using Shared.Repositories;

namespace SeriesPage.Repository.Seasons.Abstracts;

public interface ISeasonRepository : IBaseRepository<Season, int>
{
    Task<Season?> GetBySeasonNumberAsync(int seasonNumber);
}



