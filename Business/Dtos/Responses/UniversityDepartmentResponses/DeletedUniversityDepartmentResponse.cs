using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.UniversityDepartmentResponses
{
    public class DeletedUniversityDepartmentResponse
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}
