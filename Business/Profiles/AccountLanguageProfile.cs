using AutoMapper;
using Business.Dtos.Requests.AccountLanguageRequests;
using Business.Dtos.Responses.AccountLanguageResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountLanguageProfile : Profile
{
    public AccountLanguageProfile()
    {
        CreateMap<AccountLanguage, CreateAccountLanguageRequest>().ReverseMap();
        CreateMap<AccountLanguage, CreatedAccountLanguageResponse>().ReverseMap();

        CreateMap<AccountLanguage, UpdateAccountLanguageRequest>().ReverseMap();
        CreateMap<AccountLanguage, UpdatedAccountLanguageResponse>().ReverseMap();

        CreateMap<AccountLanguage, DeletedAccountLanguageResponse>().ReverseMap();

        CreateMap<IPaginate<AccountLanguage>, Paginate<GetListAccountLanguageResponse>>().ReverseMap();
        CreateMap<AccountLanguage, GetAccountLanguageResponse>()
            .ForMember(destinationMember: response => response.LanguageName,
            memberOptions: opt => opt.MapFrom(l => l.Language.Name))
            .ForMember(destinationMember: response => response.LanguageLevelName,
            memberOptions: opt => opt.MapFrom(ll => ll.LanguageLevel.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(a => a.Account.User.FirstName))
            .ReverseMap();

        CreateMap<AccountLanguage, GetListAccountLanguageResponse>()
            .ForMember(destinationMember: response => response.LanguageName,
            memberOptions: opt => opt.MapFrom(l => l.Language.Name))
            .ForMember(destinationMember: response => response.LanguageLevelName,
            memberOptions: opt => opt.MapFrom(ll => ll.LanguageLevel.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(a => a.Account.User.FirstName))
            .ReverseMap();
    }

}
