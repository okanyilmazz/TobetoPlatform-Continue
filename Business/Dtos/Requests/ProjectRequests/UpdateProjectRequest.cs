﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.ProjectRequests
{
    public class UpdateProjectRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
