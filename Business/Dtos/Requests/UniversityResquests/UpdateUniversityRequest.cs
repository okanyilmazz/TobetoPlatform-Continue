﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.UniversityResquests
{
    public class UpdateUniversityRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
