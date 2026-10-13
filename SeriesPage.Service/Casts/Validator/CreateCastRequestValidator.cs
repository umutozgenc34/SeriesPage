using FluentValidation;
using SeriesPage.Model.Casts.Dtos;
using SeriesPage.Service.Common;

namespace SeriesPage.Service.Casts.Validator;

public class CreateCastRequestValidator : AbstractValidator<CreateCastRequest>
{
    public CreateCastRequestValidator()
    {
        RuleFor(x => x.NameInTheSeries)
            .NotEmpty()
            .WithMessage("NameInTheSeries is required.")
            .MaximumLength(100)
            .WithMessage("NameInTheSeries maximum length should be 100 characters.");

        RuleFor(x => x.RealName)
            .NotEmpty()
            .WithMessage("RealName is required.")
            .MaximumLength(100)
            .WithMessage("RealName maximum length should be 100 characters.");

        RuleFor(x => x.ImageUrl)
            .Must(AllowedFileTypes.IsImage)
            .WithMessage("ImageUrl must be a valid image file (jpg, jpeg, png, gif, webp).");
    }
}
