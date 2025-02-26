using AutoMapper;
using SeriesPage.Model.Episodes.Dtos;
using SeriesPage.Model.Episodes.Entites;
using SeriesPage.Repository.Episodes.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Episodes.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using Shared.Services.Cloudinaryy.Abstracts;
using System.Net;

namespace SeriesPage.Service.Episodes.Concretes;

public class EpisodeService(IEpisodeRepository episodeRepository, IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinaryService) : IEpisodeService
{
    public async Task<ServiceResult<EpisodeDto>> AddAsync(CreateEpisodeRequest request)
    {
        var episode = mapper.Map<Episode>(request);

        if (request.VideoUrl is not null)
        {
            var videoUrl = await cloudinaryService.UploadVideo(request.VideoUrl, "episode_videos");
            episode.VideoUrl = videoUrl;
        }

        await episodeRepository.AddAsync(episode);
        await unitOfWork.SaveChangesAsync();
        var episodeAsDto = mapper.Map<EpisodeDto>(episode);

        return ServiceResult<EpisodeDto>.SuccessAsCreated(episodeAsDto, "Episode created.", $"api/episode/{episodeAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var episode = await episodeRepository.GetByIdAsync(id);
        if (episode is null)
            throw new NotFoundException("Episode not found");

        episodeRepository.Delete(episode);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Episode removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<EpisodeDto>>> GetAllAsync()
    {
        var episodes = await episodeRepository.GetAllAsync();
        var episodesAsDto = mapper.Map<List<EpisodeDto>>(episodes);

        return ServiceResult<List<EpisodeDto>>.Success(episodesAsDto, "Success");
    }

    public async Task<ServiceResult<EpisodeDto>> GetByIdAsync(int id)
    {
        var episode = await episodeRepository.GetByIdAsync(id);
        if (episode is null)
            throw new NotFoundException("Episode not found");

        var episodeAsDto = mapper.Map<EpisodeDto>(episode);

        return ServiceResult<EpisodeDto>.Success(episodeAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateEpisodeRequest request)
    {
        var episode = await episodeRepository.GetByIdAsync(request.Id);
        if (episode is null)
            throw new NotFoundException("Episode not found");

        mapper.Map(request, episode);

        if (request.VideoUrl is not null)
        {
            var videoUrl = await cloudinaryService.UploadVideo(request.VideoUrl, "episode_videos");
            episode.VideoUrl = videoUrl;
        }

        episodeRepository.Update(episode);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Episode updated.", HttpStatusCode.NoContent);
    }
}