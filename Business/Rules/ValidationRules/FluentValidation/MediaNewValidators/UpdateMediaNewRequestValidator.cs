using Business.Dtos.Requests.MediaNewRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.MediaNewValidators;

public class UpdateMediaNewRequestValidator : AbstractValidator<UpdateMediaNewRequest>
{
    public UpdateMediaNewRequestValidator()
    {
        RuleFor(m => m.Title).NotEmpty();
        RuleFor(m => m.Description).NotEmpty();
        RuleFor(m => m.Description).MinimumLength(10);
        RuleFor(m => m.ReleaseDate).NotEmpty();
        RuleFor(m => m.ThumbnailPath).NotEmpty();
    }
}
