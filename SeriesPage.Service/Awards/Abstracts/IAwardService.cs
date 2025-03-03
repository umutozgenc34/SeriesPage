using SeriesPage.Model.Awards.Dtos;
using Shared.Response;

namespace SeriesPage.Service.Awards.Abstracts;

public interface IAwardService
{
    Task<ServiceResult<List<AwardDto>>> GetAllAsync();
    Task<ServiceResult<AwardDto>> GetByIdAsync(int id);
    Task<ServiceResult<AwardDto>> AddAsync(CreateAwardRequest request);
    Task<ServiceResult> UpdateAsync(UpdateAwardRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}
