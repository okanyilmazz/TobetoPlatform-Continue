using AutoMapper;
using Business.Dtos.Requests.QuestionTypeRequests;
using Business.Dtos.Responses.QuestionTypeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class QuestionTypeProfile : Profile
{
    public QuestionTypeProfile()
    {
        CreateMap<QuestionType, CreateQuestionTypeRequest>().ReverseMap();
        CreateMap<QuestionType, CreatedQuestionTypeResponse>().ReverseMap();

        CreateMap<QuestionType, UpdateQuestionTypeRequest>().ReverseMap();
        CreateMap<QuestionType, UpdatedQuestionTypeResponse>().ReverseMap();

        CreateMap<QuestionType, DeletedQuestionTypeResponse>().ReverseMap();

        CreateMap<QuestionType, GetQuestionTypeResponse>().ReverseMap();
        CreateMap<QuestionType, GetListQuestionTypeResponse>().ReverseMap();
        CreateMap<IPaginate<QuestionType>, Paginate<GetListQuestionTypeResponse>>().ReverseMap();
    }
}

