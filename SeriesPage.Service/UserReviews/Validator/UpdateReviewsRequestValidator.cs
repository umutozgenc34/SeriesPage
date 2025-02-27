using FluentValidation;
using SeriesPage.Model.UserReviews.Dtos;

namespace SeriesPage.Service.UserReviews.Validator;

public class UpdateReviewsRequestValidator : AbstractValidator<UpdateReviewsRequest>
{
    public UpdateReviewsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithMessage("Title is required.")
           .MaximumLength(255)
           .WithMessage("Title must be maximum 255 characters.");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required.")
            .MaximumLength(3000)
            .WithMessage("Content must be maximum 3000 characters.");

        RuleFor(x => x.Rating)
            .NotEmpty()
            .WithMessage("Rating is required.")
            .InclusiveBetween(0.0f, 10.0f)
            .WithMessage("Rating value must be between 0.0 and 10.0");
    }
}
