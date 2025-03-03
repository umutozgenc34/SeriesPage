using FluentValidation;
using SeriesPage.Model.Awards.Dtos;

namespace SeriesPage.Service.Awards.Validator;

public class UpdateAwardRequestValidator : AbstractValidator<UpdateAwardRequest>
{
    public UpdateAwardRequestValidator()
    {
        RuleFor(x=> x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.WinnerName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Year).NotEmpty().GreaterThan(1900);
    }
}
