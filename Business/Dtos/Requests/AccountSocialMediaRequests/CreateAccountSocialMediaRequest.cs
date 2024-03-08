using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.AccountSocialMediaRequests
{
    public class CreateAccountSocialMediaRequest
    {
        public Guid AccountId { get; set; }
        public Guid SocialMediaId { get; set; }
        public string Url { get; set; }
    }
}
