using Core.Entities;

namespace Entities.Concretes;

public class Contact : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}