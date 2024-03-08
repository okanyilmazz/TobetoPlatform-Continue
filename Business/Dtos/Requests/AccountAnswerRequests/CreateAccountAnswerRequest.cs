using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.AccountAnswerRequests
{
    public class CreateAccountAnswerRequest
    {
        public Guid AccountId { get; set; }
        public Guid ExamId { get; set; }
        public Guid QuestionId { get; set; }
        public string GivenAnswer { get; set; }
    }
}
