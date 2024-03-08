using Core.Entities;

namespace Entities.Concretes;

public class AccountUniversity : Entity<Guid>
{
    public Guid? AccountId { get; set; }
    public Guid? DegreeTypeId { get; set; }
    public Guid? UniversityId { get; set; }
    public Guid? UniversityDepartmentId { get; set; }
    public string StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool IsEducationActive { get; set; }


    public Account? Account { get; set; }
    public DegreeType? DegreeType { get; set; }
    public University? University { get; set; }
    public UniversityDepartment? UniversityDepartment { get; set; }
}
