using FluentValidation;
using SeriesPage.Model.Summaries.Dtos;

namespace SeriesPage.Service.Summaries.Validator;

public class CreateSummaryRequestValidator : AbstractValidator<CreateSummaryRequest>
{
    public CreateSummaryRequestValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Text is required.")
            .MaximumLength(5000)
            .WithMessage("Maximum characters length is 5000");
    }
}
