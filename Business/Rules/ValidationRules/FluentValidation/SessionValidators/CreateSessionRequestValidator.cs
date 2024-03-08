using Business.Dtos.Requests.SessionRequests;
using FluentValidation;
using System;

namespace Business.Rules.ValidationRules.FluentValidation.SessionValidators;

public class CreateSessionRequestValidator : AbstractValidator<CreateSessionRequest>
{
    public CreateSessionRequestValidator()
    {


        //RuleFor(s => s.StartDate).NotEmpty();
        //RuleFor(s => s.EndDate).NotEmpty();
        //RuleFor(s => s.StartDate).LessThan(s => s.EndDate);
        //RuleFor(s => s.RecordPath).NotEmpty();

    }
}
