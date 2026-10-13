using AutoMapper;
using SeriesPage.Model.Episodes.Dtos;
using SeriesPage.Model.Episodes.Entites;

namespace SeriesPage.Service.Episodes.Profiles;

public class EpisodeMappingProfile : Profile
{
    public EpisodeMappingProfile()
    {
        CreateMap<CreateEpisodeRequest, Episode>()
            .ForMember(dest => dest.VideoUrl, opt => opt.Ignore())
            .ForMember(dest => dest.Season, opt => opt.Ignore());

        CreateMap<UpdateEpisodeRequest, Episode>()
            .ForMember(dest => dest.VideoUrl, opt => opt.Ignore())
            .ForMember(dest => dest.Season, opt => opt.Ignore());

        CreateMap<Episode, EpisodeDto>()
            .ForMember(dest => dest.SeasonNumber, opt => opt.MapFrom(src => src.Season.SeasonNumber));
    }
}
