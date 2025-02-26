using FluentValidation;
using SeriesPage.Model.Episodes.Dtos;

namespace SeriesPage.Service.Episodes.Validator;

public class CreateEpisodeRequestValidator : AbstractValidator<CreateEpisodeRequest>
{
    public CreateEpisodeRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(255)
            .WithMessage("Name maximum length must be 255 characters.");

        RuleFor(x => x.EpisodeNumber)
            .NotEmpty()
            .WithMessage("EpisodeNumber is required.")
            .GreaterThan(0)
            .WithMessage("EpisodeNumber must be greater than zero.");

        RuleFor(x => x.VideoUrl)
            .NotEmpty()
            .WithMessage("VideoUrl is required");

        RuleFor(x => x.SeasonId)
            .NotEmpty()
            .WithMessage("SeasonId is required")
            .GreaterThan(0)
            .WithMessage("SeasonId must be greater than zero.");

    }
}
