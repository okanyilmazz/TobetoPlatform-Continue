using AutoMapper;
using Business.Dtos.Requests.SkillRequests;
using Business.Dtos.Responses.SkillResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, CreateSkillRequest>().ReverseMap();
            CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
            CreateMap<Skill, UpdateSkillRequest>().ReverseMap();
            CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();
            CreateMap<Skill, DeleteSkillRequest>().ReverseMap();
            CreateMap<Skill, DeletedSkillResponse>().ReverseMap();

            CreateMap<IPaginate<Skill>, Paginate<GetListSkillResponse>>().ReverseMap();
            CreateMap<Skill, GetListSkillResponse>().ReverseMap();

            CreateMap<List<Skill>, Paginate<GetListSkillResponse>>().ForMember(destinationMember: s => s.Items,
                memberOptions: opt => opt.MapFrom(s => s.ToList())).ReverseMap();
        }
    }
}
