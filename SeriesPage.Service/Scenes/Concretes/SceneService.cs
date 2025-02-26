using AutoMapper;
using SeriesPage.Model.Scenes.Dtos;
using SeriesPage.Model.Scenes.Entities;
using SeriesPage.Repository.Scenes.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Scenes.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using Shared.Services.Cloudinaryy.Abstracts;
using System.Net;

namespace SeriesPage.Service.Scenes.Concretes;

public class SceneService(ISceneRepository sceneRepository, IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinaryService) : ISceneService
{
    public async Task<ServiceResult<SceneDto>> AddAsync(CreateSceneRequest request)
    {
        var scene = mapper.Map<Scene>(request);

        if (request.VideoUrl is not null)
        {
            var videoUrl = await cloudinaryService.UploadVideo(request.VideoUrl, "scene_videos");
            scene.VideoUrl = videoUrl;
        }

        await sceneRepository.AddAsync(scene);
        await unitOfWork.SaveChangesAsync();
        var sceneAsDto = mapper.Map<SceneDto>(scene);

        return ServiceResult<SceneDto>.SuccessAsCreated(sceneAsDto, "Scene created.", $"api/scene/{sceneAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var scene = await sceneRepository.GetByIdAsync(id);
        if (scene is null)
            throw new NotFoundException("Scene not found");

        sceneRepository.Delete(scene);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Scene removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<SceneDto>>> GetAllAsync()
    {
        var scenes = await sceneRepository.GetAllAsync();
        var scenesAsDto = mapper.Map<List<SceneDto>>(scenes);

        return ServiceResult<List<SceneDto>>.Success(scenesAsDto, "Success");
    }

    public async Task<ServiceResult<SceneDto>> GetByIdAsync(int id)
    {
        var scene = await sceneRepository.GetByIdAsync(id);
        if (scene is null)
            throw new NotFoundException("Scene not found");

        var sceneAsDto = mapper.Map<SceneDto>(scene);

        return ServiceResult<SceneDto>.Success(sceneAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateSceneRequest request)
    {
        var scene = await sceneRepository.GetByIdAsync(request.Id);
        if (scene is null)
            throw new NotFoundException("Scene not found");

        mapper.Map(request, scene);

        if (request.VideoUrl is not null)
        {
            var videoUrl = await cloudinaryService.UploadVideo(request.VideoUrl, "scene_videos");
            scene.VideoUrl = videoUrl;
        }

        sceneRepository.Update(scene);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Scene updated.", HttpStatusCode.NoContent);
    }
}
