using SeriesPage.Model.Photos.Entities;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Photos.Abstracts;
using Shared.Repositories;

namespace SeriesPage.Repository.Photos.Concretes;

public class PhotoRepository(AppDbContext context) : BaseRepository<AppDbContext,Photo,int>(context),IPhotoRepository;

