using Business.Dtos.Requests.AddressRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Rules.ValidationRules.FluentValidation.AddressValidators
{
    public class CreateAddressRequestValidator : AbstractValidator<CreateAddressRequest>
    {
        public CreateAddressRequestValidator()
        {
        }
    }
}
