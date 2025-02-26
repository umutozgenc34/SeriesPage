using SeriesPage.Model.Episodes.Dtos;
using Shared.Response;

namespace SeriesPage.Service.Episodes.Abstracts;

public interface IEpisodeService
{
    Task<ServiceResult<List<EpisodeDto>>> GetAllAsync();
    Task<ServiceResult<EpisodeDto>> GetByIdAsync(int id);
    Task<ServiceResult<EpisodeDto>> AddAsync(CreateEpisodeRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult> UpdateAsync(UpdateEpisodeRequest request);
}
