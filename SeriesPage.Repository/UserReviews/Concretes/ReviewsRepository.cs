using SeriesPage.Model.UserReviews.Entities;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.UserReviews.Abstracts;
using Shared.Repositories;

namespace SeriesPage.Repository.UserReviews.Concretes;

public class ReviewsRepository(AppDbContext context) : BaseRepository<AppDbContext,Reviews,int>(context),IReviewsRepository;

