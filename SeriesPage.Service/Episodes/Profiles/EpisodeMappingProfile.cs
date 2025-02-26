using AutoMapper;
using SeriesPage.Model.Episodes.Dtos;
using SeriesPage.Model.Episodes.Entites;

namespace SeriesPage.Service.Episodes.Profiles;
public class EpisodeMappingProfile : Profile
{
    public EpisodeMappingProfile()
    {
        CreateMap<CreateEpisodeRequest, Episode>();
        CreateMap<UpdateEpisodeRequest, Episode>();
        CreateMap<Episode, EpisodeDto>().ForMember(dest => dest.SeasonNumber, opt => opt.MapFrom(src=>src.Season.SeasonNumber));
    }
}
