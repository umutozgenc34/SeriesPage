using SeriesPage.Model.Summaries.Entities;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Summaries.Abstracts;
using Shared.Repositories;

namespace SeriesPage.Repository.Summaries.Concretes;

public class SummaryRepository(AppDbContext context) : BaseRepository<AppDbContext,Summary,int>(context),ISummaryRepository
{
}
