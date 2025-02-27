using AutoMapper;
using SeriesPage.Model.UserReviews.Dtos;
using SeriesPage.Model.UserReviews.Entities;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Repository.UserReviews.Abstracts;
using SeriesPage.Service.UserReviews.Abstracts;
using Shared.Exceptions;
using Shared.Response;
using System.Net;

namespace SeriesPage.Service.UserReviews.Concretes;

public class ReviewsService(IReviewsRepository reviewsRepository, IUnitOfWork unitOfWork, IMapper mapper) : IReviewsService
{
    public async Task<ServiceResult<ReviewsDto>> AddAsync(CreateReviewsRequest request)
    {
        var review = mapper.Map<Reviews>(request);
        await reviewsRepository.AddAsync(review);
        await unitOfWork.SaveChangesAsync();
        var reviewAsDto = mapper.Map<ReviewsDto>(review);

        return ServiceResult<ReviewsDto>.SuccessAsCreated(reviewAsDto, "Review created.", $"api/reviews/{reviewAsDto.Id}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var review = await reviewsRepository.GetByIdAsync(id);
        if (review is null)
            throw new NotFoundException("Review not found");

        reviewsRepository.Delete(review);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Review removed.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<ReviewsDto>>> GetAllAsync()
    {
        var reviews = await reviewsRepository.GetAllAsync();
        var reviewsAsDto = mapper.Map<List<ReviewsDto>>(reviews);

        return ServiceResult<List<ReviewsDto>>.Success(reviewsAsDto, "Success");
    }

    public async Task<ServiceResult<ReviewsDto>> GetByIdAsync(int id)
    {
        var review = await reviewsRepository.GetByIdAsync(id);
        if (review is null)
            throw new NotFoundException("Review not found");

        var reviewAsDto = mapper.Map<ReviewsDto>(review);

        return ServiceResult<ReviewsDto>.Success(reviewAsDto, "Success");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateReviewsRequest request)
    {
        var review = await reviewsRepository.GetByIdAsync(request.Id);
        if (review is null)
            throw new NotFoundException("Review not found");

        mapper.Map(request, review);
        reviewsRepository.Update(review);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Review updated.", HttpStatusCode.NoContent);
    }
}