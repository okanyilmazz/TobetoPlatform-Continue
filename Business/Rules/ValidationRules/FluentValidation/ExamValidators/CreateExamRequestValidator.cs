﻿using Business.Dtos.Requests.ExamRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ExamValidators;

public class CreateExamRequestValidator : AbstractValidator<CreateExamRequest>
{
    public CreateExamRequestValidator()
    {
        RuleFor(eppl => eppl.Name).NotEmpty();
        RuleFor(eppl => eppl.Description).NotEmpty();
        RuleFor(eppl => eppl.Duration).NotEmpty();
        RuleFor(eppl => eppl.QuestionCount).NotEmpty();

        RuleFor(eppl => eppl.Name).MinimumLength(2);
        RuleFor(eppl => eppl.Description).MinimumLength(10);
    }
}