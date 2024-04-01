using Core.Entities;

namespace Entities.Concretes;

public class BlogImage : Entity<Guid>
{
    public Guid BlogId { get; set; }
    public string ImagePath { get; set; }

    public Blog Blog { get; set; }
}
