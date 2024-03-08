﻿namespace Business.Dtos.Requests.LessonRequests;

public class CreateLessonRequest
{
    public Guid LanguageId { get; set; }
    public Guid LessonModuleId { get; set; }
    public Guid LessonCategoryId { get; set; }
    public Guid LessonSubTypeId { get; set; }
    public Guid ProductionCompanyId { get; set; }
    public string Name { get; set; }
    public string LessonPath { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
}
