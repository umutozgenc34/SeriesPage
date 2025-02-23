using SeriesPage.Model.Summaries.Dtos;
using Shared.Response;

namespace SeriesPage.Service.Summaries.Abstracts;

public interface ISummaryService
{
    Task<ServiceResult<List<SummaryDto>>> GetAllAsync();
    Task<ServiceResult<SummaryDto>> GetByIdAsync(int id);
    Task<ServiceResult<SummaryDto>> AddAsync(CreateSummaryRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult> UpdateAsync(UpdateSummaryRequest request);
   
}
