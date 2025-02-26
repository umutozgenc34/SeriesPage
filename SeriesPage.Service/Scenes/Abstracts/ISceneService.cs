using SeriesPage.Model.Scenes.Dtos;
using Shared.Response;

namespace SeriesPage.Service.Scenes.Abstracts;

public interface ISceneService
{
    Task<ServiceResult<List<SceneDto>>> GetAllAsync();
    Task<ServiceResult<SceneDto>> GetByIdAsync(int id);
    Task<ServiceResult<SceneDto>> AddAsync(CreateSceneRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult> UpdateAsync(UpdateSceneRequest request);
}
