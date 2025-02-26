using AutoMapper;
using SeriesPage.Model.Casts.Dtos;
using SeriesPage.Model.Seasons.Dtos;
using SeriesPage.Model.Seasons.Entities;

namespace SeriesPage.Service.Seasons.Profiles;

public class SeasonMappingProfile : Profile
{
    public SeasonMappingProfile()
    {
        CreateMap<CreateSeasonRequest, Season>();
        CreateMap<UpdateSeasonRequest, Season>();
        CreateMap<Season, SeasonDto>().ReverseMap();
        CreateMap<Season, SeasonWithEpisodesDto>();
    }
}
