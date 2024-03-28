using AutoMapper;
using Business.Dtos.Requests.ExamRequests;
using Business.Dtos.Responses.ExamResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ExamProfile : Profile
{
    public ExamProfile()
    {
        CreateMap<Exam, CreateExamRequest>().ReverseMap();
        CreateMap<Exam, CreatedExamResponse>().ReverseMap();

        CreateMap<Exam, UpdateExamRequest>().ReverseMap();
        CreateMap<Exam, UpdatedExamResponse>().ReverseMap();

        CreateMap<Exam, DeletedExamResponse>().ReverseMap();

        CreateMap<IPaginate<Exam>, Paginate<GetListExamResponse>>().ReverseMap();
        CreateMap<Exam, GetExamResponse>().ReverseMap();
        CreateMap<Exam, GetListExamResponse>()
            .ForMember(
                dest => dest.QuestionTypeNames,
                opt => opt.MapFrom(src => src.ExamQuestions.Select(eq => eq.Question.QuestionType.Name).ToList())).ReverseMap();

        CreateMap<Exam, GetExamResponse>()
           .ForMember(
               dest => dest.QuestionTypeNames,
               opt => opt.MapFrom(src => src.ExamQuestions.Select(eq => eq.Question.QuestionType.Name).ToList())).ReverseMap();
    }
}