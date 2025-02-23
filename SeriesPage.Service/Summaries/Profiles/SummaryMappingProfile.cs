using AutoMapper;
using SeriesPage.Model.Summaries.Dtos;
using SeriesPage.Model.Summaries.Entities;

namespace SeriesPage.Service.Summaries.Profiles;

public class SummaryMappingProfile : Profile
{
    public SummaryMappingProfile()
    {
        CreateMap<CreateSummaryRequest, Summary>();
        CreateMap<UpdateSummaryRequest, Summary>();
        CreateMap<Summary, SummaryDto>().ReverseMap();
    }
}
