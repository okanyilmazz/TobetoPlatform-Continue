using AutoMapper;
using Business.Dtos.Requests.QuestionRequests;
using Business.Dtos.Responses.QuestionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, CreateQuestionRequest>().ReverseMap();
            CreateMap<Question, CreatedQuestionResponse>().ReverseMap();

            CreateMap<Question, UpdateQuestionRequest>().ReverseMap();
            CreateMap<Question, UpdatedQuestionResponse>().ReverseMap();

            CreateMap<Question, DeleteQuestionRequest>().ReverseMap();
            CreateMap<Question, DeletedQuestionResponse>().ReverseMap();

            CreateMap<Question, GetListQuestionResponse>().ReverseMap();
            CreateMap<IPaginate<Question>, Paginate<GetListQuestionResponse>>().ReverseMap();
            
            CreateMap<List<Question>, Paginate<GetListQuestionResponse>>()
                .ForMember(destinationMember: q => q.Items,
                memberOptions: opt => opt.MapFrom(q => q.ToList())).ReverseMap();
        }
    }
}
