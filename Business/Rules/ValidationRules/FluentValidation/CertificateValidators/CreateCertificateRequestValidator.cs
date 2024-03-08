using Business.Dtos.Requests.CertificateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CertificateValidators
{
    public class CreateCertificateRequestValidator : AbstractValidator<CreateCertificateRequest>
    {
        public CreateCertificateRequestValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.FolderPath).NotEmpty();

            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.FolderPath).MinimumLength(2);
        }
    }
}
