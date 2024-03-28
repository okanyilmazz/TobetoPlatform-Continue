using AutoMapper;
using Business.Dtos.Requests.AccountViewLessonRequests;
using Business.Dtos.Responses.AccountViewLessonResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountViewLessonProfile : Profile
{
    public AccountViewLessonProfile()
    {
        CreateMap<AccountViewLesson, CreateAccountViewLessonRequest>().ReverseMap();
        CreateMap<AccountViewLesson, CreatedAccountViewLessonResponse>().ReverseMap();

        CreateMap<AccountViewLesson, UpdateAccountViewLessonRequest>().ReverseMap();
        CreateMap<AccountViewLesson, UpdatedAccountViewLessonResponse>().ReverseMap();

        CreateMap<AccountViewLesson, DeletedAccountViewLessonResponse>().ReverseMap();

        CreateMap<AccountViewLesson, GetAccountViewLessonResponse>().ReverseMap();
        CreateMap<AccountViewLesson, GetListAccountViewLessonResponse>().ReverseMap();
        CreateMap<IPaginate<AccountViewLesson>, Paginate<GetListAccountViewLessonResponse>>().ReverseMap();
    }
}
