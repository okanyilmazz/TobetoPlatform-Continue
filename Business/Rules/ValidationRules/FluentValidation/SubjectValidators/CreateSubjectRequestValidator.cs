using Business.Dtos.Requests.SubjectRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.LessonSubjectValidators;

public class CreateSubjectRequestValidator : AbstractValidator<CreateSubjectRequest>
{
    public CreateSubjectRequestValidator()
    {
        RuleFor(ls => ls.Name).NotEmpty();
    }
}
