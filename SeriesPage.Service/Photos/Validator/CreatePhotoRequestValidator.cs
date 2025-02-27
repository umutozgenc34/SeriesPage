using FluentValidation;
using SeriesPage.Model.Photos.Dtos;

namespace SeriesPage.Service.Photos.Validator;

public class CreatePhotoRequestValidator : AbstractValidator<CreatePhotoRequest>
{
    public CreatePhotoRequestValidator()
    {
        RuleFor(x => x.ImageUrl)
            .Must(file => file == null ||
                new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }
                .Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("ImageUrl must be a valid image file (jpg, jpeg, png, gif, webp).");

    }
}
