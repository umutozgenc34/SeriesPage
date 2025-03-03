using FluentValidation;
using SeriesPage.Model.Awards.Dtos;

namespace SeriesPage.Service.Awards.Validator;

public class CreateAwardRequestValidator : AbstractValidator<CreateAwardRequest>
{
    public CreateAwardRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.WinnerName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Year).NotEmpty().GreaterThan(1900);
    }
}
