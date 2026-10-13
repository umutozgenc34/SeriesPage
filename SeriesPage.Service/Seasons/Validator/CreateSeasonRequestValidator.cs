using FluentValidation;
using SeriesPage.Model.Seasons.Dtos;

namespace SeriesPage.Service.Seasons.Validator;

public class CreateSeasonRequestValidator : AbstractValidator<CreateSeasonRequest>
{
    public CreateSeasonRequestValidator()
    {
        RuleFor(x => x.SeasonNumber)
            .GreaterThan(0)
            .WithMessage("Season number must be greater than 0.");
    }
}
