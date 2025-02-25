using AutoMapper;
using SeriesPage.Model.Casts.Dtos;
using SeriesPage.Model.Casts.Entities;
using SeriesPage.Repository.Casts.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Casts.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using Shared.Services.Cloudinaryy.Abstracts;
using System.Net;

namespace SeriesPage.Service.Casts.Concretes;

public class CastService(ICastRepository castRepository, IUnitOfWork unitOfWork, IMapper mapper,ICloudinaryService cloudinaryService) : ICastService
{
    public async Task<ServiceResult<CastDto>> AddAsync(CreateCastRequest request)
    {
        var cast = mapper.Map<Cast>(request);

        if (request.ImageUrl is not null)
        {
            var imageUrl = await cloudinaryService.UploadImage(request.ImageUrl, "cast_images");
            cast.ImageUrl = imageUrl;
        }

        await castRepository.AddAsync(cast);
        await unitOfWork.SaveChangesAsync();
        var castAsDto = mapper.Map<CastDto>(cast);

        return ServiceResult<CastDto>.SuccessAsCreated(castAsDto, "Cast created.", $"api/cast/{castAsDto.Id}");
    }


    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var cast = await castRepository.GetByIdAsync(id);
        if (cast is null)
            throw new NotFoundException("Cast not found");

        castRepository.Delete(cast);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Cast removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<CastDto>>> GetAllAsync()
    {
        var casts = await castRepository.GetAllAsync();
        var castsAsDto = mapper.Map<List<CastDto>>(casts);

        return ServiceResult<List<CastDto>>.Success(castsAsDto, "Success");
    }

    public async Task<ServiceResult<CastDto>> GetByIdAsync(int id)
    {
        var cast = await castRepository.GetByIdAsync(id);
        if (cast is null)
            throw new NotFoundException("Cast not found");

        var castAsDto = mapper.Map<CastDto>(cast);

        return ServiceResult<CastDto>.Success(castAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateCastRequest request)
    {
        var cast = await castRepository.GetByIdAsync(request.Id);
        if (cast is null)
            throw new NotFoundException("Cast not found");

        mapper.Map(request, cast);

        if (request.ImageUrl is not null)
        {
            var imageUrl = await cloudinaryService.UploadImage(request.ImageUrl, "cast_images");
            cast.ImageUrl = imageUrl;
        }

        castRepository.Update(cast);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Cast updated.", HttpStatusCode.NoContent);
    }
}