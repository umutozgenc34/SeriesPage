using AutoMapper;
using SeriesPage.Model.Scenes.Dtos;
using SeriesPage.Model.Scenes.Entities;

namespace SeriesPage.Service.Scenes.Profiles;

public class SceneMappingProfile : Profile
{
    public SceneMappingProfile()
    {
        CreateMap<CreateSceneRequest, Scene>().ForMember(dest => dest.VideoUrl, opt => opt.Ignore());
        CreateMap<UpdateSceneRequest, Scene>().ForMember(dest => dest.VideoUrl, opt => opt.Ignore());
        CreateMap<Scene, SceneDto>();
    }
}
