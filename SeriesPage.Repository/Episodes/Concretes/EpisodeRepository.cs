using SeriesPage.Model.Episodes.Entites;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Episodes.Abstracts;
using Shared.Repositories;

namespace SeriesPage.Repository.Episodes.Concretes;

public class EpisodeRepository(AppDbContext context) : BaseRepository<AppDbContext,Episode,int>(context),IEpisodeRepository
{
}
