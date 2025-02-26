using FluentValidation;
using SeriesPage.Model.Seasons.Dtos;

namespace SeriesPage.Service.Seasons.Validator;

public class UpdateSeasonRequestValidator : AbstractValidator<UpdateSeasonRequest>
{
    public UpdateSeasonRequestValidator()
    {
        RuleFor(x=> x.Id).NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.SeasonNumber)
            .NotEmpty()
            .WithMessage("SeasonNumber is required.")
            .GreaterThan(0)
            .WithMessage("Season number must be greater than 0.");
    }
}
