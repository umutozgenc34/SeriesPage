using AutoMapper;
using SeriesPage.Model.Scenes.Dtos;
using SeriesPage.Model.Scenes.Entities;

namespace SeriesPage.Service.Scenes.Profiles;

public class SceneMappingProfile : Profile
{
    public SceneMappingProfile()
    {
        CreateMap<CreateSceneRequest, Scene>();
        CreateMap<UpdateSceneRequest, Scene>();
        CreateMap<Scene,SceneDto>().ReverseMap();
    }
}
