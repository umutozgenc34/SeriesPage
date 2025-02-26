using FluentValidation;
using SeriesPage.Model.Scenes.Dtos;

namespace SeriesPage.Service.Scenes.Validator;

public class CreateSceneRequestValidator : AbstractValidator<CreateSceneRequest>
{
    public CreateSceneRequestValidator()
    {
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description maximum length must be 500 characters");
        RuleFor(x => x.VideoUrl)
            .NotEmpty()
            .WithMessage("Video file is required.");
            
    }
}
