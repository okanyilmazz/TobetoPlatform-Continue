using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.EducationProgramLessonResponses
{
    public class UpdatedEducationProgramLessonResponse
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid EducationProgramId { get; set; }
    }
}
