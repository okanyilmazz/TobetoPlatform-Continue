using AutoMapper;
using Business.Dtos.Requests.ExamQuestionRequests;
using Business.Dtos.Responses.ExamQuestionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ExamQuestionProfile : Profile
{
    public ExamQuestionProfile()
    {
        CreateMap<ExamQuestion, CreateExamQuestionRequest>().ReverseMap();
        CreateMap<ExamQuestion, CreatedExamQuestionResponse>().ReverseMap();

        CreateMap<ExamQuestion, UpdateExamQuestionRequest>().ReverseMap();
        CreateMap<ExamQuestion, UpdatedExamQuestionResponse>().ReverseMap();

        CreateMap<ExamQuestion, DeleteExamQuestionRequest>().ReverseMap();
        CreateMap<ExamQuestion, DeletedExamQuestionResponse>().ReverseMap();

        CreateMap<ExamQuestion, GetExamQuestionResponse>().ReverseMap();
        CreateMap<ExamQuestion, GetListExamQuestionResponse>()
            .ForMember(destinationMember: response => response.ExamName,
            memberOptions: eq => eq.MapFrom(eq => eq.Exam.Name))
            .ForMember(destinationMember: response => response.QuestionName,
            memberOptions: eq => eq.MapFrom(eq => eq.Question.Description))
            .ReverseMap();

        CreateMap<ExamQuestion, GetExamQuestionResponse>()
          .ForMember(destinationMember: response => response.ExamName,
          memberOptions: eq => eq.MapFrom(eq => eq.Exam.Name))
          .ForMember(destinationMember: response => response.QuestionName,
          memberOptions: eq => eq.MapFrom(eq => eq.Question.Description))
          .ReverseMap();
        CreateMap<IPaginate<ExamQuestion>, Paginate<GetListExamQuestionResponse>>().ReverseMap();
    }
}

