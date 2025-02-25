using SeriesPage.Model.Casts.Entities;
using SeriesPage.Repository.Casts.Abstracts;
using SeriesPage.Repository.Context;
using Shared.Repositories;

namespace SeriesPage.Repository.Casts.Concretes;

public class CastRepository(AppDbContext context) : BaseRepository<AppDbContext,Cast,int>(context),ICastRepository;

