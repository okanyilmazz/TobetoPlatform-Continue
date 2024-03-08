using AutoMapper;
using Business.Dtos.Requests.ExamResultRequests;
using Business.Dtos.Responses.ExamResultResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ExamResultProfile : Profile
{
    public ExamResultProfile()
    {
        CreateMap<ExamResult, CreateExamResultRequest>().ReverseMap();
        CreateMap<ExamResult, CreatedExamResultResponse>().ReverseMap();

        CreateMap<ExamResult, UpdateExamResultRequest>().ReverseMap();
        CreateMap<ExamResult, UpdatedExamResultResponse>().ReverseMap();

        CreateMap<ExamResult, DeleteExamResultRequest>().ReverseMap();
        CreateMap<ExamResult, DeletedExamResultResponse>().ReverseMap();

        CreateMap<IPaginate<ExamResult>, Paginate<GetListExamResultResponse>>().ReverseMap();

        CreateMap<ExamResult, GetExamResultResponse>().ReverseMap();
        CreateMap<ExamResult, GetListExamResultResponse>()
            .ForMember(destinationMember: response => response.ExamName,
            memberOptions: opt => opt.MapFrom(er => er.Exam.Name)).ReverseMap();

        CreateMap<ExamResult, GetExamResultResponse>()
         .ForMember(destinationMember: response => response.ExamName,
         memberOptions: opt => opt.MapFrom(er => er.Exam.Name)).ReverseMap();

        CreateMap<List<ExamResult>, Paginate<GetListExamResultResponse>>().ForMember(destinationMember: h => h.Items,
       memberOptions: opt => opt.MapFrom(h => h.ToList())).ReverseMap();
    }
}
