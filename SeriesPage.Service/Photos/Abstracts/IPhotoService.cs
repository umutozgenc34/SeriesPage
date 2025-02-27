using SeriesPage.Model.Photos.Dtos;
using Shared.Response;

namespace SeriesPage.Service.Photos.Abstracts;

public interface IPhotoService
{
    Task<ServiceResult<List<PhotoDto>>> GetAllAsync();
    Task<ServiceResult<PhotoDto>> GetByIdAsync(int id);
    Task<ServiceResult<PhotoDto>> AddAsync(CreatePhotoRequest request);
    Task<ServiceResult> UpdateAsync(UpdatePhotoRequest request);
    Task<ServiceResult> DeleteAsnyc(int id);
}
