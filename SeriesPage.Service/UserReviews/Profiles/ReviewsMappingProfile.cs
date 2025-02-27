using AutoMapper;
using SeriesPage.Model.UserReviews.Dtos;
using SeriesPage.Model.UserReviews.Entities;

namespace SeriesPage.Service.UserReviews.Profiles;

public class ReviewsMappingProfile : Profile
{
    public ReviewsMappingProfile()
    {
        CreateMap<CreateReviewsRequest, Reviews>();
        CreateMap<UpdateReviewsRequest, Reviews>();
        CreateMap<Reviews, ReviewsDto>();
    }
}
