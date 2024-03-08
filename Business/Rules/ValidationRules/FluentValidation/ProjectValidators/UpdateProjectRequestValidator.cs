using Business.Dtos.Requests.ProjectRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ProjectValidators;

public class UpdateProjectRequestValidator : AbstractValidator<UpdateProjectRequest>
{
    public UpdateProjectRequestValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}