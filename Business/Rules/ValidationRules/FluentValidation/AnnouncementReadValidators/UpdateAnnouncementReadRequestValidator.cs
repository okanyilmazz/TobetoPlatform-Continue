using Business.Dtos.Requests.AnnouncementReadRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementReadValidators
{
    public class UpdateAnnouncementReadRequestValidator : AbstractValidator<UpdateAnnouncementReadRequest>
    {
        public UpdateAnnouncementReadRequestValidator()
        {
            RuleFor(ar => ar.AnnouncementId).NotEmpty();
            RuleFor(ar => ar.AccountId).NotEmpty();

        }
    }
}
