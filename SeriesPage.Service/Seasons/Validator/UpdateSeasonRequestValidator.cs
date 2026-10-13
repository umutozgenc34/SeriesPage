using FluentValidation;
using SeriesPage.Model.Seasons.Dtos;

namespace SeriesPage.Service.Seasons.Validator;

public class UpdateSeasonRequestValidator : AbstractValidator<UpdateSeasonRequest>
{
    public UpdateSeasonRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id is required.");

        RuleFor(x => x.SeasonNumber)
            .GreaterThan(0)
            .WithMessage("Season number must be greater than 0.");
    }
}
