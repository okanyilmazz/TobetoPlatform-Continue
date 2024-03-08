using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.WorkExperienceResquests
{
    public class CreateWorkExperienceRequest
    {
        public Guid CityId { get; set; }
        public Guid AccountId { get; set; }
        public string Industry { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public Account Account { get; set; }
    }
}
