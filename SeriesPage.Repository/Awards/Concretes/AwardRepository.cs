using SeriesPage.Model.Awards.Entities;
using SeriesPage.Repository.Awards.Abstracts;
using SeriesPage.Repository.Context;
using Shared.Repositories;

namespace SeriesPage.Repository.Awards.Concretes;

public class AwardRepository(AppDbContext context) : BaseRepository<AppDbContext,Award,int>(context),IAwardRepository;


