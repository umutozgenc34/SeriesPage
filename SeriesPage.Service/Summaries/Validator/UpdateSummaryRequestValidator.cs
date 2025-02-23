using FluentValidation;
using SeriesPage.Model.Summaries.Dtos;

namespace SeriesPage.Service.Summaries.Validator;

public class UpdateSummaryRequestValidator : AbstractValidator<UpdateSummaryRequest>
{
    public UpdateSummaryRequestValidator()
    {
        RuleFor(x=> x.Id).NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Text is required.")
            .MaximumLength(5000)
            .WithMessage("Maximum characters length is 5000");
    }
}
