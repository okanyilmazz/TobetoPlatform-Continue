using AutoMapper;
using Business.Dtos.Requests.EducationProgramLevelRequests;
using Business.Dtos.Responses.EducationProgramLevelResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class EducationProgramLevelProfile : Profile
    {
        public EducationProgramLevelProfile()
        {
            CreateMap<EducationProgramLevel, CreateEducationProgramLevelRequest>().ReverseMap();
            CreateMap<EducationProgramLevel, UpdateEducationProgramLevelRequest>().ReverseMap();
            CreateMap<EducationProgramLevel, DeleteEducationProgramLevelRequest>().ReverseMap();

            CreateMap<EducationProgramLevel, CreatedEducationProgramLevelResponse>().ReverseMap();
            CreateMap<EducationProgramLevel, UpdatedEducationProgramLevelResponse>().ReverseMap();
            CreateMap<EducationProgramLevel, DeletedEducationProgramLevelResponse>().ReverseMap();

            CreateMap<IPaginate<EducationProgramLevel>, Paginate<GetListEducationProgramLevelResponse>>().ReverseMap();
            CreateMap<EducationProgramLevel, GetListEducationProgramLevelResponse>().ReverseMap();
        }
    }       
}
