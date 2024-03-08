using AutoMapper;
using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.SessionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<Session, CreateSessionRequest>().ReverseMap();
        CreateMap<Session, CreatedSessionResponse>().ReverseMap();

        CreateMap<Session, UpdateSessionRequest>().ReverseMap();
        CreateMap<Session, UpdatedSessionResponse>().ReverseMap();

        CreateMap<Session, DeleteSessionRequest>().ReverseMap();
        CreateMap<Session, DeletedSessionResponse>().ReverseMap();

        CreateMap<IPaginate<Session>, Paginate<GetListSessionResponse>>().ReverseMap();

        CreateMap<Session, GetListSessionResponse>()
            .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
            .ForMember(dest => dest.OccupationClassName, opt => opt.MapFrom(src => MapOccupationClassName(src)))
            .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => MapAccountName(src)))
            .ReverseMap();

        CreateMap<Session, GetSessionResponse>()
       .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
       .ForMember(dest => dest.OccupationClassName, opt => opt.MapFrom(src => MapOccupationClassName(src)))
       .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => MapAccountName(src)))
       .ReverseMap();
    }

    private static string MapOccupationClassName(Session src)
    {
        var occupationClassNames = src.Lesson.EducationProgramLessons
            .SelectMany(epl => epl.EducationProgram.EducationProgramOccupationClasses
                .Select(epoc => epoc.OccupationClass.Name));

        return string.Join(", ", occupationClassNames);
    }

    private static string MapAccountName(Session src)
    {
        var accountNames = src.Lesson.EducationProgramLessons
            .SelectMany(epl => epl.EducationProgram.EducationProgramOccupationClasses
                .SelectMany(epoc => epoc.OccupationClass.AccountOccupationClasses
                    .Select(aoc => aoc.Account.User.FirstName+ " " + aoc.Account.User.LastName)));

        return string.Join(", ", accountNames);
    }

}