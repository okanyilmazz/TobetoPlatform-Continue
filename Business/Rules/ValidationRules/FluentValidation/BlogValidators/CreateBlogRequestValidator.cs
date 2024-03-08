using Business.Dtos.Requests.BlogRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.BlogValidators;

public class CreateBlogRequestValidator : AbstractValidator<CreateBlogRequest>
{
    public CreateBlogRequestValidator()
    {
        RuleFor(b => b.Title).NotEmpty();
        RuleFor(b => b.Description).NotEmpty();
        RuleFor(b => b.ReleaseDate).NotEmpty();
        RuleFor(b => b.ThumbnailPath).NotEmpty();

        RuleFor(b => b.Title).MinimumLength(2);
        RuleFor(b => b.Description).MinimumLength(2);
        RuleFor(b => b.ThumbnailPath).MinimumLength(2);
    }
}
