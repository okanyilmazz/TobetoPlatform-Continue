﻿using Core.Entities;

namespace Entities.Concretes;

public class MediaNew : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}