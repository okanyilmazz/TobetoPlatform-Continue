using System;
using AutoMapper;
using Business.Dtos.Requests.SocialMediaRequests;
using Business.Dtos.Responses.SocialMediaResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, CreateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, CreatedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, UpdateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, UpdatedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, DeleteSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, DeletedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, GetListSocialMediaResponse>().ReverseMap();
            CreateMap<IPaginate<SocialMedia>, Paginate<GetListSocialMediaResponse>>().ReverseMap();

            CreateMap<List<SocialMedia>, Paginate<GetListSocialMediaResponse>>()
                .ForMember(destinationMember: s => s.Items,
                memberOptions: opt => opt.MapFrom(a => a.ToList())).ReverseMap();
        }
    }
}

