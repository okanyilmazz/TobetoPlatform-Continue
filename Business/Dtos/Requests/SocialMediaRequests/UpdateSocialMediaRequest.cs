using System;
using Entities.Concretes;

namespace Business.Dtos.Requests.SocialMediaRequests;

public class UpdateSocialMediaRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
}


