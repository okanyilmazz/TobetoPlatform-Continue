using AutoMapper;
using Business.Dtos.Requests.AccountHomeworkRequests;
using Business.Dtos.Responses.AccountHomeworkResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountHomeworkProfile : Profile
{
    public AccountHomeworkProfile()
    {
        CreateMap<AccountHomework, CreateAccountHomeworkRequest>().ReverseMap();
        CreateMap<AccountHomework, CreatedAccountHomeworkResponse>().ReverseMap();

        CreateMap<AccountHomework, UpdateAccountHomeworkRequest>().ReverseMap();
        CreateMap<AccountHomework, UpdatedAccountHomeworkResponse>().ReverseMap();

        CreateMap<AccountHomework, DeleteAccountHomeworkRequest>().ReverseMap();
        CreateMap<AccountHomework, DeletedAccountHomeworkResponse>().ReverseMap();

        CreateMap<IPaginate<AccountHomework>, Paginate<GetListAccountHomeworkResponse>>().ReverseMap();
        CreateMap<AccountHomework, GetAccountHomeworkResponse>()
            .ForMember(destinationMember: response => response.HomeworkName,
            memberOptions: opt => opt.MapFrom(ah => ah.Homework.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(ah => ah.Account.User.FirstName))
            .ReverseMap();

        CreateMap<AccountHomework, GetListAccountHomeworkResponse>()
            .ForMember(destinationMember: response => response.HomeworkName,
            memberOptions: opt => opt.MapFrom(ah => ah.Homework.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(ah => ah.Account.User.FirstName))
            .ReverseMap();
    }
}
