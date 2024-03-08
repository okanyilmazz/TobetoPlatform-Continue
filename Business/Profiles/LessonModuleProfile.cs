using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Requests.LessonModuleRequests;
using Business.Dtos.Responses;
using Business.Dtos.Responses.LessonModuleResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class LessonModuleProfile : Profile
    {
        public LessonModuleProfile()
        {
            CreateMap<LessonModule, CreateLessonModuleRequest>().ReverseMap();
            CreateMap<LessonModule, CreatedLessonModuleResponse>().ReverseMap();

            CreateMap<LessonModule, UpdateLessonModuleRequest>().ReverseMap();
            CreateMap<LessonModule, UpdatedLessonModuleResponse>().ReverseMap();

            CreateMap<LessonModule, DeleteLessonModuleRequest>().ReverseMap();
            CreateMap<LessonModule, DeletedLessonModuleResponse>().ReverseMap();

            CreateMap<LessonModule, GetListLessonModuleResponse>().ReverseMap();
            CreateMap<IPaginate<LessonModule>, Paginate<GetListLessonModuleResponse>>().ReverseMap();
        }
    }
}
