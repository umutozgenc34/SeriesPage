using AutoMapper;
using SeriesPage.Model.Summaries.Dtos;
using SeriesPage.Model.Summaries.Entities;
using SeriesPage.Repository.Summaries.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Summaries.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using System.Net;

namespace SeriesPage.Service.Summaries.Concretes;

public class SummaryService(ISummaryRepository summaryRepository,IUnitOfWork unitOfWork,IMapper mapper) : ISummaryService
{
    public async Task<ServiceResult<SummaryDto>> AddAsync(CreateSummaryRequest request)
    {
        var summary = mapper.Map<Summary>(request);
        await summaryRepository.AddAsync(summary);
        await unitOfWork.SaveChangesAsync();
        var summaryAsDto = mapper.Map<SummaryDto>(summary);

        return ServiceResult<SummaryDto>.SuccessAsCreated(summaryAsDto,"Summary created." ,$"api/summary/{summaryAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var summary = await summaryRepository.GetByIdAsync(id);
        if (summary is null)
            throw new NotFoundException("Summary not found");
        
        summaryRepository.Delete(summary);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Summary removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<SummaryDto>>> GetAllAsync()
    {
        var summaries = await summaryRepository.GetAllAsync();
        var summariesAsDto = mapper.Map<List<SummaryDto>>(summaries);

        return ServiceResult<List<SummaryDto>>.Success(summariesAsDto,"Success");
    }

    public async Task<ServiceResult<SummaryDto>> GetByIdAsync(int id)
    {
        var summary = await summaryRepository.GetByIdAsync(id);
        if (summary is null)
            throw new NotFoundException("Summary not found");

        var summaryAsDto = mapper.Map<SummaryDto>(summary);

        return ServiceResult<SummaryDto>.Success(summaryAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateSummaryRequest request)
    {
        var summary = await summaryRepository.GetByIdAsync(request.Id);
        if (summary is null)
            throw new NotFoundException("Summary not found");

        mapper.Map(request, summary);
        summaryRepository.Update(summary);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Summary updated.",HttpStatusCode.NoContent);
    }
}
