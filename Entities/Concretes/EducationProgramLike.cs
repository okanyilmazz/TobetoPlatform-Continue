﻿using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramLike : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }

    public Account Account { get; set; }
    public EducationProgram EducationProgram { get; set; }
}