﻿namespace Business.Dtos.Responses.EducationProgramOccupationClassResponses;

public class UpdatedEducationProgramOccupationClassResponse
{
    public Guid Id { get; set; }
    public Guid EducationProgramId { get; set; }
    public Guid OccupationClassId { get; set; }
}