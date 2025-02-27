using AutoMapper;
using SeriesPage.Model.Casts.Dtos;
using SeriesPage.Model.Photos.Dtos;
using SeriesPage.Model.Photos.Entities;
using SeriesPage.Repository.Photos.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Service.Photos.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using Shared.Services.Cloudinaryy.Abstracts;
using System.Net;

namespace SeriesPage.Service.Photos.Concretes;

public class PhotoService(IPhotoRepository photoRepository,IUnitOfWork unitOfWork,IMapper mapper,ICloudinaryService cloudinaryService) : IPhotoService
{
    public async Task<ServiceResult<PhotoDto>> AddAsync(CreatePhotoRequest request)
    {
        var photo = mapper.Map<Photo>(request);
        if (request.ImageUrl is not null)
        {
            var imageUrl = await cloudinaryService.UploadImage(request.ImageUrl, "photos_images");
            photo.ImageUrl = imageUrl;
        }

        await photoRepository.AddAsync(photo);
        await unitOfWork.SaveChangesAsync();

        var photoAsDto = mapper.Map<PhotoDto>(photo);
        return ServiceResult<PhotoDto>.SuccessAsCreated(photoAsDto, "Photo created.", $"api/Photos/{photoAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsnyc(int id)
    {
        var photo = await photoRepository.GetByIdAsync(id);
        if (photo is null)
            throw new NotFoundException("Photo not found");

        photoRepository.Delete(photo);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Photo removed.",HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<PhotoDto>>> GetAllAsync()
    {
        var photos = await photoRepository.GetAllAsync();
        var photosAsDto = mapper.Map<List<PhotoDto>>(photos);

        return ServiceResult<List<PhotoDto>>.Success(photosAsDto,"Sucess");
    }

    public async Task<ServiceResult<PhotoDto>> GetByIdAsync(int id)
    {
        var photo = await photoRepository.GetByIdAsync(id);
        if (photo is null)
            throw new NotFoundException("Photo not found.");

        var photoAsDto = mapper.Map<PhotoDto>(photo);

        return ServiceResult<PhotoDto>.Success(photoAsDto, "Success");
        
    }

    public async Task<ServiceResult> UpdateAsync(UpdatePhotoRequest request)
    {
        var photo = await photoRepository.GetByIdAsync(request.Id);
        if (photo is null)
            throw new NotFoundException("Photo not found");

        mapper.Map(request, photo);
        if(request.ImageUrl is not null)
        {
            var imageUrl = await cloudinaryService.UploadImage(request.ImageUrl, "photos_images");
            photo.ImageUrl = imageUrl;
        }

        photoRepository.Update(photo);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Photo updated.", HttpStatusCode.NoContent);
    }
}
