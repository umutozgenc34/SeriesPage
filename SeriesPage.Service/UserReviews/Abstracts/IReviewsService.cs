using SeriesPage.Model.UserReviews.Dtos;
using Shared.Response;

namespace SeriesPage.Service.UserReviews.Abstracts;

public interface IReviewsService
{
    Task<ServiceResult<List<ReviewsDto>>> GetAllAsync();
    Task<ServiceResult<ReviewsDto>> GetByIdAsync(int id);
    Task<ServiceResult<ReviewsDto>> AddAsync(CreateReviewsRequest request);
    Task<ServiceResult> UpdateAsync(UpdateReviewsRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}
