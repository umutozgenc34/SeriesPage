using FluentValidation;
using SeriesPage.Model.UserReviews.Dtos;

namespace SeriesPage.Service.UserReviews.Validator;

public class CreateReviewsRequestValidator : AbstractValidator<CreateReviewsRequest>
{
    public CreateReviewsRequestValidator()
    {
        RuleFor(x => x.NickName)
            .NotEmpty()
            .WithMessage("NickName is required.")
            .MaximumLength(50)
            .WithMessage("NickName must be maximum 50 characters.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email must be a valid email address.")
            .MaximumLength(255)
            .WithMessage("Email must be maximum 255 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

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
            .InclusiveBetween(1.0f, 10.0f)
            .WithMessage("Rating value must be between 1 and 10.");
    }
}
