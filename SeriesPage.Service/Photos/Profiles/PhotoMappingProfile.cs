using AutoMapper;
using SeriesPage.Model.Photos.Dtos;
using SeriesPage.Model.Photos.Entities;

namespace SeriesPage.Service.Photos.Profiles;

public class PhotoMappingProfile : Profile
{
    public PhotoMappingProfile()
    {
        CreateMap<CreatePhotoRequest, Photo>();
        CreateMap<UpdatePhotoRequest, Photo>();
        CreateMap<Photo, PhotoDto>().ReverseMap();
    }
}
