using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.LanguageResponses
{
    public class GetListLanguageResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
