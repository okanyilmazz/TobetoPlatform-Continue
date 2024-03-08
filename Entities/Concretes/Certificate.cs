using Core.Entities;

namespace Entities.Concretes;

public class Certificate : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FolderPath { get; set; }

    public Account Account { get; set; }
}