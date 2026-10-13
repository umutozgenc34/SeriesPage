using FluentValidation;
using SeriesPage.Model.Scenes.Dtos;
using SeriesPage.Service.Common;

namespace SeriesPage.Service.Scenes.Validator;

public class CreateSceneRequestValidator : AbstractValidator<CreateSceneRequest>
{
    public CreateSceneRequestValidator()
    {
        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description maximum length must be 500 characters.");

        RuleFor(x => x.VideoUrl)
            .NotNull()
            .WithMessage("Video file is required.")
            .Must(AllowedFileTypes.IsVideo)
            .WithMessage("VideoUrl must be a valid video file (mp4, mov, webm, mkv, avi).");
    }
}
