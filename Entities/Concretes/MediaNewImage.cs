using Core.Entities;

namespace Entities.Concretes;

public class MediaNewImage : Entity<Guid>
{
    public Guid MediaNewId { get; set; }
    public string ImagePath { get; set; }

    public MediaNew MediaNew { get; set; }
}
