using FluentValidation;
using SeriesPage.Model.Scenes.Dtos;
using SeriesPage.Model.Seasons.Dtos;

namespace SeriesPage.Service.Seasons.Validator;

public class CreateSeasonRequestValidator : AbstractValidator<CreateSeasonRequest>
{
    public CreateSeasonRequestValidator()
    {
        RuleFor(x => x.SeasonNumber)
            .NotEmpty()
            .WithMessage("SeasonNumber is required.")
            .GreaterThan(0)
            .WithMessage("Season number must be greater than 0.");

    }
}
