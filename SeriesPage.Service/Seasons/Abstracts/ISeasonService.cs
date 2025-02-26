using SeriesPage.Model.Seasons.Dtos;
using Shared.Response;

namespace SeriesPage.Service.Seasons.Abstracts;

public interface ISeasonService
{
    Task<ServiceResult<List<SeasonDto>>> GetAllAsync();
    Task<ServiceResult<SeasonDto>> GetByIdAsync(int id);
    Task<ServiceResult<SeasonDto>> AddAsync(CreateSeasonRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult> UpdateAsync(UpdateSeasonRequest request);
}
