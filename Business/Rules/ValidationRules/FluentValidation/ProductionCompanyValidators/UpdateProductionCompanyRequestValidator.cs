using Business.Dtos.Requests.ProductionCompanyRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ProductionCompanyValidators;

public class UpdateProductionCompanyRequestValidator : AbstractValidator<UpdateProductionCompanyRequest>
{

    public UpdateProductionCompanyRequestValidator()
    {
        RuleFor(pc => pc.Name).NotEmpty();
    }
}