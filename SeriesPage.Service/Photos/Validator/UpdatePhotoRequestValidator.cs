using FluentValidation;
using SeriesPage.Model.Photos.Dtos;

namespace SeriesPage.Service.Photos.Validator;

public class UpdatePhotoRequestValidator : AbstractValidator<UpdatePhotoRequest>
{
    public UpdatePhotoRequestValidator()
    {
        RuleFor(x=> x.Id).NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.ImageUrl)
            .Must(file => file == null ||
                new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }
                .Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("ImageUrl must be a valid image file (jpg, jpeg, png, gif, webp).");

    }
}
