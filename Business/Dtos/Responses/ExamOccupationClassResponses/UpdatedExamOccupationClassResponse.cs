using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.ExamOccupationClassResponses
{
    public class UpdatedExamOccupationClassResponse
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}
