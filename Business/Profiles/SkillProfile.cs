﻿using AutoMapper;
using Business.Dtos.Requests.SkillRequests;
using Business.Dtos.Responses.SkillResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class SkillProfile : Profile
{
    public SkillProfile()
    {
        CreateMap<Skill, CreateSkillRequest>().ReverseMap();
        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<Skill, UpdateSkillRequest>().ReverseMap();
        CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();
        CreateMap<Skill, DeletedSkillResponse>().ReverseMap();

        CreateMap<IPaginate<Skill>, Paginate<GetListSkillResponse>>().ReverseMap();
        CreateMap<Skill, GetSkillResponse>().ReverseMap();
        CreateMap<Skill, GetListSkillResponse>().ReverseMap();

        CreateMap<List<Skill>, Paginate<GetListSkillResponse>>()
            .ForMember(destinationMember: s => s.Items,
            memberOptions: opt => opt.MapFrom(s => s.ToList())).ReverseMap();
    }
}
