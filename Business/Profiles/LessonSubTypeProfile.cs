using AutoMapper;
using Business.Dtos.Requests.LessonSubTypeRequests;
using Business.Dtos.Responses.LessonSubTypeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class LessonSubTypeProfile : Profile
    {
        public LessonSubTypeProfile()
        {
            CreateMap<LessonSubType, CreateLessonSubTypeRequest>().ReverseMap();
            CreateMap<LessonSubType, UpdateLessonSubTypeRequest>().ReverseMap();
            CreateMap<LessonSubType, DeleteLessonSubTypeRequest>().ReverseMap();

            CreateMap<LessonSubType, CreatedLessonSubTypeResponse>().ReverseMap();
            CreateMap<LessonSubType, UpdatedLessonSubTypeResponse>().ReverseMap();
            CreateMap<LessonSubType, DeletedLessonSubTypeResponse>().ReverseMap();

            CreateMap<IPaginate<LessonSubType>, Paginate<GetListLessonSubTypeResponse>>().ReverseMap();
            CreateMap<LessonSubType, GetListLessonSubTypeResponse>().ReverseMap();
        }
    }
}
