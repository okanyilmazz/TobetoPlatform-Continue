using System;
using Entities.Concretes;

namespace Business.Dtos.Requests.SocialMediaRequests;

public class CreateSocialMediaRequest
{
    public string Name { get; set; }
    public string IconPath { get; set; }
}