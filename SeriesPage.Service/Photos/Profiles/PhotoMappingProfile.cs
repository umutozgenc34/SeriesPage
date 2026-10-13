using AutoMapper;
using SeriesPage.Model.Photos.Dtos;
using SeriesPage.Model.Photos.Entities;

namespace SeriesPage.Service.Photos.Profiles;

public class PhotoMappingProfile : Profile
{
    public PhotoMappingProfile()
    {
        CreateMap<CreatePhotoRequest, Photo>().ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        CreateMap<UpdatePhotoRequest, Photo>().ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        CreateMap<Photo, PhotoDto>();
    }
}
