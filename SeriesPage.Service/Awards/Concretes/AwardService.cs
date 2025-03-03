using AutoMapper;
using SeriesPage.Model.Awards.Dtos;
using SeriesPage.Model.Awards.Entities;
using SeriesPage.Repository.Awards.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Awards.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using System.Net;

namespace SeriesPage.Service.Awards.Concretes;

public class AwardService(IAwardRepository awardRepository, IUnitOfWork unitOfWork, IMapper mapper) : IAwardService
{
    public async Task<ServiceResult<AwardDto>> AddAsync(CreateAwardRequest request)
    {
        var award = mapper.Map<Award>(request);
        await awardRepository.AddAsync(award);
        await unitOfWork.SaveChangesAsync();
        var awardAsDto = mapper.Map<AwardDto>(award);

        return ServiceResult<AwardDto>.SuccessAsCreated(awardAsDto, "Award created.", $"api/Awards/{awardAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var award = await awardRepository.GetByIdAsync(id);
        if (award is null)
            throw new NotFoundException("Award not found");

        awardRepository.Delete(award);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Award removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<AwardDto>>> GetAllAsync()
    {
        var awards = await awardRepository.GetAllAsync();
        var awardsAsDto = mapper.Map<List<AwardDto>>(awards);

        return ServiceResult<List<AwardDto>>.Success(awardsAsDto, "Success");
    }

    public async Task<ServiceResult<AwardDto>> GetByIdAsync(int id)
    {
        var award = await awardRepository.GetByIdAsync(id);
        if (award is null)
            throw new NotFoundException("Award not found");

        var awardAsDto = mapper.Map<AwardDto>(award);

        return ServiceResult<AwardDto>.Success(awardAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateAwardRequest request)
    {
        var award = await awardRepository.GetByIdAsync(request.Id);
        if (award is null)
            throw new NotFoundException("Award not found");

        mapper.Map(request, award);
        awardRepository.Update(award);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Award updated.", HttpStatusCode.NoContent);
    }
}

