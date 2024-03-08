using AutoMapper;
using Business.Dtos.Requests.ExamQuestionTypeRequests;
using Business.Dtos.Responses.ExamQuestionTypeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ExamQuestionTypeProfile : Profile
{
    public ExamQuestionTypeProfile()
    {
        CreateMap<ExamQuestionType, CreateExamQuestionTypeRequest>().ReverseMap();
        CreateMap<ExamQuestionType, UpdateExamQuestionTypeRequest>().ReverseMap();
        CreateMap<ExamQuestionType, DeleteExamQuestionTypeRequest>().ReverseMap();

        CreateMap<ExamQuestionType, CreatedExamQuestionTypeResponse>().ReverseMap();
        CreateMap<ExamQuestionType, UpdatedExamQuestionTypeResponse>().ReverseMap();
        CreateMap<ExamQuestionType, DeletedExamQuestionTypeResponse>().ReverseMap();

        CreateMap<IPaginate<ExamQuestionType>, Paginate<GetListExamQuestionTypeResponse>>().ReverseMap();
        CreateMap<ExamQuestionType, GetExamQuestionTypeResponse>().ReverseMap();

        CreateMap<ExamQuestionType, GetListExamQuestionTypeResponse>()
            .ForMember(destinationMember: response => response.ExamName,
            memberOptions: eq => eq.MapFrom(eq => eq.Exam.Name))
            .ForMember(destinationMember: response => response.QuestionTypeName,
            memberOptions: eq => eq.MapFrom(eq => eq.QuestionType.Name))
            .ReverseMap();

        CreateMap<ExamQuestionType, GetExamQuestionTypeResponse>()
          .ForMember(destinationMember: response => response.ExamName,
          memberOptions: eq => eq.MapFrom(eq => eq.Exam.Name))
          .ForMember(destinationMember: response => response.QuestionTypeName,
          memberOptions: eq => eq.MapFrom(eq => eq.QuestionType.Name))
          .ReverseMap();
    }
}