using SeriesPage.Model.Casts.Dtos;
using Shared.Response;

namespace SeriesPage.Service.Casts.Abstracts;

public interface ICastService
{
    Task<ServiceResult<List<CastDto>>> GetAllAsync();
    Task<ServiceResult<CastDto>> GetByIdAsync(int id);
    Task<ServiceResult<CastDto>> AddAsync(CreateCastRequest request);
    Task<ServiceResult> UpdateAsync(UpdateCastRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}
