using System;
using Entities.Concretes;

namespace Business.Dtos.Responses.SocialMediaResponses;

public class UpdatedSocialMediaResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
}

