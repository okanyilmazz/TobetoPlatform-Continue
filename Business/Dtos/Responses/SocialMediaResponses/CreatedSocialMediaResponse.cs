using System;
using Entities.Concretes;

namespace Business.Dtos.Responses.SocialMediaResponses
{
    public class CreatedSocialMediaResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
    }
}
