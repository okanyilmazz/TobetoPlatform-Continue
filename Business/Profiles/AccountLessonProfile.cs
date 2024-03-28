using AutoMapper;
using Business.Dtos.Requests.AccountLessonRequests;
using Business.Dtos.Responses.AccountLessonResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountLessonProfile : Profile
{
    public AccountLessonProfile()
    {
        CreateMap<AccountLesson, CreateAccountLessonRequest>().ReverseMap();
        CreateMap<AccountLesson, UpdateAccountLessonRequest>().ReverseMap();

        CreateMap<AccountLesson, CreatedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, UpdatedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, DeletedAccountLessonResponse>().ReverseMap();

        CreateMap<IPaginate<AccountLesson>, Paginate<GetListAccountLessonResponse>>().ReverseMap();
        CreateMap<AccountLesson, GetAccountLessonResponse>()
            .ForMember(destinationMember: response => response.LessonName,
            memberOptions: opt => opt.MapFrom(al => al.Lesson.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(al => al.Account.User.FirstName))
              .ForMember(destinationMember: response => response.LessonPath,
            memberOptions: opt => opt.MapFrom(al => al.Lesson.LessonPath))
            .ReverseMap();

        CreateMap<AccountLesson, GetListAccountLessonResponse>()
            .ForMember(destinationMember: response => response.LessonName,
            memberOptions: opt => opt.MapFrom(al => al.Lesson.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(al => al.Account.User.FirstName))
              .ForMember(destinationMember: response => response.LessonPath,
            memberOptions: opt => opt.MapFrom(al => al.Lesson.LessonPath))
            .ReverseMap();
    }
}
