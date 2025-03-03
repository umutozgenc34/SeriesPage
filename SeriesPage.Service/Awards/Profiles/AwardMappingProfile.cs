using AutoMapper;
using SeriesPage.Model.Awards.Dtos;
using SeriesPage.Model.Awards.Entities;

namespace SeriesPage.Service.Awards.Profiles;

public class AwardMappingProfile : Profile
{
    public AwardMappingProfile()
    {
        CreateMap<CreateAwardRequest, Award>();
        CreateMap<UpdateAwardRequest, Award>();
        CreateMap<AwardDto, Award>().ReverseMap();
    }
}
