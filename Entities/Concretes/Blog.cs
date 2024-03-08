using Core.Entities;

namespace Entities.Concretes;

public class Blog : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ThumbnailPath { get; set; }
}