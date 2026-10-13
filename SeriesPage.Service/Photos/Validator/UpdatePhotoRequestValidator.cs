using FluentValidation;
using SeriesPage.Model.Photos.Dtos;
using SeriesPage.Service.Common;

namespace SeriesPage.Service.Photos.Validator;

public class UpdatePhotoRequestValidator : AbstractValidator<UpdatePhotoRequest>
{
    public UpdatePhotoRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id is required.");

        RuleFor(x => x.ImageUrl)
            .Must(AllowedFileTypes.IsImage)
            .WithMessage("ImageUrl must be a valid image file (jpg, jpeg, png, gif, webp).");
    }
}
