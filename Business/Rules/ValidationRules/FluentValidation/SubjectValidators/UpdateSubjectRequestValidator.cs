using Business.Dtos.Requests.SubjectRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.LessonSubjectValidators;

public class UpdateSubjectRequestValidator : AbstractValidator<UpdateSubjectRequest>
{
    public UpdateSubjectRequestValidator()
    {
        RuleFor(ls => ls.Name).NotEmpty();
    }
}
