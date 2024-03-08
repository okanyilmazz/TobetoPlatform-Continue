using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.ExamOccupationClassResponses
{
    public class GetListExamOccupationClassResponse
    {
        public Guid Id { get; set; }
        public string ExamName { get; set; }
        public string OccupationClassName { get; set; }
    }
}
