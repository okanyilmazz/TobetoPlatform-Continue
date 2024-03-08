using System;
using Business.Dtos.Requests.ProjectRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ProjectValidators
{
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();

        }

    }

}
