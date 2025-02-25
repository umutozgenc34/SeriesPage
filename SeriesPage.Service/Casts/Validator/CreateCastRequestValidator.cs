using FluentValidation;
using SeriesPage.Model.Casts.Dtos;

namespace SeriesPage.Service.Casts.Validator;

public class CreateCastRequestValidator : AbstractValidator<CreateCastRequest>
{
    public CreateCastRequestValidator()
    {
        RuleFor(x => x.NameInTheSeries)
            .NotEmpty()
            .WithMessage("NameInTheSeries is required.")
            .MaximumLength(100)
            .WithMessage("NameInTheSeries maximumum length should be 100 characters.");

        RuleFor(x => x.RealName)
            .NotEmpty()
            .WithMessage("RealName is required.")
            .MaximumLength(100)
            .WithMessage("RealName maximumu length should be 100 characters.");

        RuleFor(x => x.ImageUrl)
            .Must(file => file == null ||
                new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }
                .Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("ImageUrl must be a valid image file (jpg, jpeg, png, gif, webp).");

    }
}
