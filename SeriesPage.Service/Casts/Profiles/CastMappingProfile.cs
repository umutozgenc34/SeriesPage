using AutoMapper;
using SeriesPage.Model.Casts.Dtos;
using SeriesPage.Model.Casts.Entities;

namespace SeriesPage.Service.Casts.Profiles;

public class CastMappingProfile : Profile
{
    public CastMappingProfile()
    {
        CreateMap<CreateCastRequest, Cast>().ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        CreateMap<UpdateCastRequest, Cast>().ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        CreateMap<Cast, CastDto>();
    }
}
