using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.AccountSkillRequests
{
    public class DeleteAccountSkillRequest
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public Guid AccountId { get; set; }
    }
}
