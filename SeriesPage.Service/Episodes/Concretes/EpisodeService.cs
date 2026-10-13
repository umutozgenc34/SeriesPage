using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SeriesPage.Model.Episodes.Dtos;
using SeriesPage.Model.Episodes.Entites;
using SeriesPage.Repository.Episodes.Abstracts;
using SeriesPage.Repository.Seasons.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Episodes.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using Shared.Services.Cloudinaryy.Abstracts;
using System.Net;

namespace SeriesPage.Service.Episodes.Concretes;

public class EpisodeService(
    IEpisodeRepository episodeRepository,
    ISeasonRepository seasonRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ICloudinaryService cloudinaryService) : IEpisodeService
{
    public async Task<ServiceResult<EpisodeDto>> AddAsync(CreateEpisodeRequest request)
    {
        var season = await seasonRepository.GetByIdAsync(request.SeasonId)
            ?? throw new NotFoundException("Season not found");

        var episode = mapper.Map<Episode>(request);
        episode.Season = season;
        episode.VideoUrl = await cloudinaryService.UploadVideo(request.VideoUrl, "episode_videos");

        await episodeRepository.AddAsync(episode);
        await unitOfWork.SaveChangesAsync();
        var episodeAsDto = mapper.Map<EpisodeDto>(episode);

        return ServiceResult<EpisodeDto>.SuccessAsCreated(episodeAsDto, "Episode created.", $"api/Episodes/{episodeAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var episode = await GetTrackedEpisodeAsync(id);

        episodeRepository.Delete(episode);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Episode removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<EpisodeDto>>> GetAllAsync()
    {
        var episodes = await episodeRepository.GetAllAsync();
        var episodesAsDto = mapper.Map<List<EpisodeDto>>(episodes)
            .OrderBy(x => x.SeasonNumber)
            .ThenBy(x => x.EpisodeNumber)
            .ToList();

        return ServiceResult<List<EpisodeDto>>.Success(episodesAsDto, "Success");
    }

    public async Task<ServiceResult<EpisodeDto>> GetByIdAsync(int id)
    {
        var episode = await episodeRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Episode not found");

        var episodeAsDto = mapper.Map<EpisodeDto>(episode);

        return ServiceResult<EpisodeDto>.Success(episodeAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateEpisodeRequest request)
    {
        var episode = await GetTrackedEpisodeAsync(request.Id);

        if (episode.SeasonId != request.SeasonId)
        {
            episode.Season = await seasonRepository.GetByIdAsync(request.SeasonId)
                ?? throw new NotFoundException("Season not found");
        }

        mapper.Map(request, episode);

        if (request.VideoUrl is not null)
            episode.VideoUrl = await cloudinaryService.UploadVideo(request.VideoUrl, "episode_videos");

        episodeRepository.Update(episode);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Episode updated.", HttpStatusCode.NoContent);
    }

    private async Task<Episode> GetTrackedEpisodeAsync(int id) =>
        await episodeRepository.Where(x => x.Id == id).FirstOrDefaultAsync()
            ?? throw new NotFoundException("Episode not found");
}
