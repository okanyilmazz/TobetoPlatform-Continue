using Business.Dtos.Requests.WorkExperienceResquests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.WorkExperienceValidators;

public class UpdateWorkExperienceRequestValidator : AbstractValidator<UpdateWorkExperienceRequest>
{
    public UpdateWorkExperienceRequestValidator()
    {
        RuleFor(w => w.Industry).NotEmpty();
        RuleFor(w => w.CompanyName).NotEmpty();
        RuleFor(w => w.Department).NotEmpty();
        RuleFor(w => w.Description).NotEmpty();
        RuleFor(w => w.StartDate).NotEmpty();
        RuleFor(w => w.EndDate).NotEmpty();
    }
}
