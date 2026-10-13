using FluentValidation;
using SeriesPage.Model.Photos.Dtos;
using SeriesPage.Service.Common;

namespace SeriesPage.Service.Photos.Validator;

public class CreatePhotoRequestValidator : AbstractValidator<CreatePhotoRequest>
{
    public CreatePhotoRequestValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotNull()
            .WithMessage("Image file is required.")
            .Must(AllowedFileTypes.IsImage)
            .WithMessage("ImageUrl must be a valid image file (jpg, jpeg, png, gif, webp).");
    }
}
