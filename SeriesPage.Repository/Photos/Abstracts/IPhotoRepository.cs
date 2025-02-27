using SeriesPage.Model.Photos.Entities;
using Shared.Repositories;

namespace SeriesPage.Repository.Photos.Abstracts;

public interface IPhotoRepository : IBaseRepository<Photo,int>;
