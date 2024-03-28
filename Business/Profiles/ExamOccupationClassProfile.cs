using AutoMapper;
using Business.Dtos.Requests.ExamOccupationClassRequests;
using Business.Dtos.Responses.ExamOccupationClassResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ExamOccupationClassProfile : Profile
{
    public ExamOccupationClassProfile()
    {
        CreateMap<ExamOccupationClass, CreateExamOccupationClassRequest>().ReverseMap();
        CreateMap<ExamOccupationClass, CreatedExamOccupationClassResponse>().ReverseMap();

        CreateMap<ExamOccupationClass, UpdateExamOccupationClassRequest>().ReverseMap();
        CreateMap<ExamOccupationClass, UpdatedExamOccupationClassResponse>().ReverseMap();

        CreateMap<ExamOccupationClass, DeletedExamOccupationClassResponse>().ReverseMap();
        CreateMap<ExamOccupationClass, GetExamOccupationClassResponse>().ReverseMap();

        CreateMap<ExamOccupationClass, GetExamOccupationClassResponse>()
            .ForMember(destinationMember: response => response.ExamName,
            memberOptions: opt => opt.MapFrom(eoc => eoc.Exam.Name))
            .ForMember(destinationMember: response => response.OccupationClassName,
            memberOptions: opt => opt.MapFrom(eoc => eoc.OccupationClass.Name))
            .ReverseMap();

        CreateMap<ExamOccupationClass, GetListExamOccupationClassResponse>()
            .ForMember(destinationMember: response => response.ExamName,
            memberOptions: opt => opt.MapFrom(eoc => eoc.Exam.Name))
            .ForMember(destinationMember: response => response.OccupationClassName,
            memberOptions: opt => opt.MapFrom(eoc => eoc.OccupationClass.Name))
            .ReverseMap();
        CreateMap<IPaginate<ExamOccupationClass>, Paginate<GetListExamOccupationClassResponse>>().ReverseMap();
    }
}
