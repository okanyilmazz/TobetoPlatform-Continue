using System;
using Business.Dtos.Requests.ProductionCompanyRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ProductionCompanyValidators
{
    public class CreateProductionCompanyRequestValidator : AbstractValidator<CreateProductionCompanyRequest>
    {
        public CreateProductionCompanyRequestValidator()
        {
            RuleFor(pc => pc.Name).NotEmpty();

        }

    }

}