using FluentValidation;
using SeriesPage.Model.Episodes.Dtos;
using SeriesPage.Service.Common;

namespace SeriesPage.Service.Episodes.Validator;

public class UpdateEpisodeRequestValidator : AbstractValidator<UpdateEpisodeRequest>
{
    public UpdateEpisodeRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(255)
            .WithMessage("Name maximum length must be 255 characters.");

        RuleFor(x => x.EpisodeNumber)
            .GreaterThan(0)
            .WithMessage("EpisodeNumber must be greater than zero.");

        RuleFor(x => x.VideoUrl)
            .Must(AllowedFileTypes.IsVideo)
            .WithMessage("VideoUrl must be a valid video file (mp4, mov, webm, mkv, avi).");

        RuleFor(x => x.SeasonId)
            .GreaterThan(0)
            .WithMessage("SeasonId must be greater than zero.");
    }
}
