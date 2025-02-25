using AutoMapper;
using SeriesPage.Model.Casts.Dtos;
using SeriesPage.Model.Casts.Entities;

namespace SeriesPage.Service.Casts.Profiles;

public class CastMappingProfile : Profile
{
    public CastMappingProfile()
    {
        CreateMap<CreateCastRequest, Cast>();
        CreateMap<UpdateCastRequest, Cast>();
        CreateMap<Cast, CastDto>().ReverseMap();
    }
}
