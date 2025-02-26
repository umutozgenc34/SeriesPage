using AutoMapper;
using SeriesPage.Model.Seasons.Dtos;
using SeriesPage.Model.Seasons.Entities;
using SeriesPage.Repository.Seasons.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Seasons.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using System.Net;

namespace SeriesPage.Service.Seasons.Concretes;

public class SeasonService(ISeasonRepository seasonRepository,IUnitOfWork unitOfWork,IMapper mapper) : ISeasonService
{
    public async Task<ServiceResult<SeasonDto>> AddAsync(CreateSeasonRequest request)
    {
        var existingSeason = await seasonRepository.GetBySeasonNumberAsync(request.SeasonNumber);
        if (existingSeason is not null)
            throw new BusinessException("A season with this number already exists.");

        var season = mapper.Map<Season>(request);
        await seasonRepository.AddAsync(season);
        await unitOfWork.SaveChangesAsync();
        var seasonAsDto = mapper.Map<SeasonDto>(season);

        return ServiceResult<SeasonDto>.SuccessAsCreated(seasonAsDto, "Season created.", $"api/season/{seasonAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var season = await seasonRepository.GetByIdAsync(id);
        if (season is null)
            throw new NotFoundException("Season not found");

        seasonRepository.Delete(season);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Season removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<SeasonDto>>> GetAllAsync()
    {
        var seasons = await seasonRepository.GetAllAsync();
        var seasonsAsDto = mapper.Map<List<SeasonDto>>(seasons);

        return ServiceResult<List<SeasonDto>>.Success(seasonsAsDto, "Success");
    }

    public async Task<ServiceResult<SeasonDto>> GetByIdAsync(int id)
    {
        var season = await seasonRepository.GetByIdAsync(id);
        if (season is null)
            throw new NotFoundException("Season not found");

        var seasonAsDto = mapper.Map<SeasonDto>(season);

        return ServiceResult<SeasonDto>.Success(seasonAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateSeasonRequest request)
    {
        var season = await seasonRepository.GetByIdAsync(request.Id);
        if (season is null)
            throw new NotFoundException("Season not found");

        var existingSeason = await seasonRepository.GetBySeasonNumberAsync(request.SeasonNumber);
        if (existingSeason is not null && existingSeason.Id != request.Id)
            throw new BusinessException("A season with this number already exists.");

        mapper.Map(request, season);
        seasonRepository.Update(season);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Season updated.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<SeasonWithEpisodesDto>>> GetAllWithEpisodesAsync()
    {
        var seasons = await seasonRepository.GetAllWithEpisodesAsync();
        var seasonsAsDto = mapper.Map<List<SeasonWithEpisodesDto>>(seasons);

        return ServiceResult<List<SeasonWithEpisodesDto>>.Success(seasonsAsDto, "Success");
    }
    public async Task<ServiceResult<SeasonWithEpisodesDto>> GetWithEpisodesBySeasonNumberAsync(int seasonNumber)
    {
        var season = await seasonRepository.GetWithEpisodesBySeasonNumberAsync(seasonNumber);
        if (season is null)
            throw new NotFoundException("Season not found");

        var seasonAsDto = mapper.Map<SeasonWithEpisodesDto>(season);
        return ServiceResult<SeasonWithEpisodesDto>.Success(seasonAsDto, "Success");
    }
}

