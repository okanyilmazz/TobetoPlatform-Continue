using System;
using Business.Dtos.Requests.ProgrammingLanguageRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ProgrammingLanguageValidators
{
    public class CreateProgrammingLanguageRequestValidator : AbstractValidator<CreateProgrammingLanguageRequest>
    {
        public CreateProgrammingLanguageRequestValidator()
        {
            RuleFor(pl => pl.Name).NotEmpty();

        }

    }

}

