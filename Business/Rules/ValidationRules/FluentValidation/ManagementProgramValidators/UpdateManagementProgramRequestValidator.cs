using Business.Dtos.Requests.ManagementProgramRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ManagementProgramValidators
{
    public class UpdateManagementProgramRequestValidator:AbstractValidator<UpdateManagementProgramRequest>
    {
        public UpdateManagementProgramRequestValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
        }
    }
}
