using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.UserReviews.Dtos;
using SeriesPage.Service.UserReviews.Abstracts;

namespace SeriesPage.Api.Controllers;

public class ReviewsController(IReviewsService reviewsService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllReviews() => CreateActionResult(await reviewsService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetReviewById([FromRoute] int id) => CreateActionResult(await reviewsService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewsRequest request) => CreateActionResult(await reviewsService.AddAsync(request));

    [HttpPut]
    public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewsRequest request) => CreateActionResult(await reviewsService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteReview([FromRoute] int id) => CreateActionResult(await reviewsService.DeleteAsync(id));
}