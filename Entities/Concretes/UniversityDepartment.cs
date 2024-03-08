using Core.Entities;

namespace Entities.Concretes;

public class UniversityDepartment : Entity<Guid>
{
    public Guid UniversityId { get; set; }
    public string Name { get; set; }

    public University University { get; set; }
}
