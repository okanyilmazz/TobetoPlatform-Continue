using AutoMapper;
using Business.Dtos.Requests.AccountSocialMediaRequests;
using Business.Dtos.Responses.AccountSocialMediaResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountSocialMediaProfile : Profile
{
    public AccountSocialMediaProfile()
    {
        CreateMap<AccountSocialMedia, CreateAccountSocialMediaRequest>().ReverseMap();
        CreateMap<AccountSocialMedia, UpdateAccountSocialMediaRequest>().ReverseMap();
        CreateMap<AccountSocialMedia, DeleteAccountSocialMediaRequest>().ReverseMap();

        CreateMap<AccountSocialMedia, CreatedAccountSocialMediaResponse>().ReverseMap();
        CreateMap<AccountSocialMedia, UpdatedAccountSocialMediaResponse>().ReverseMap();
        CreateMap<AccountSocialMedia, DeletedAccountSocialMediaResponse>().ReverseMap();

        CreateMap<AccountSocialMedia, GetAccountSocialMediaResponse>()
            .ForMember(destinationMember: response => response.SocialMediaName,
            memberOptions: opt => opt.MapFrom(asm => asm.SocialMedia.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(asm => asm.Account.User.FirstName + " " + asm.Account.User.FirstName))
            .ForMember(destinationMember: response => response.IconPath,
            memberOptions: opt => opt.MapFrom(asm => asm.SocialMedia.IconPath))
            .ReverseMap();

        CreateMap<AccountSocialMedia, GetListAccountSocialMediaResponse>()
            .ForMember(destinationMember: response => response.SocialMediaName,
            memberOptions: opt => opt.MapFrom(asm => asm.SocialMedia.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(asm => asm.Account.User.FirstName + " " + asm.Account.User.FirstName))
            .ForMember(destinationMember: response => response.IconPath,
            memberOptions: opt => opt.MapFrom(asm => asm.SocialMedia.IconPath))
            .ReverseMap();
        CreateMap<IPaginate<AccountSocialMedia>, Paginate<GetListAccountSocialMediaResponse>>().ReverseMap();
    }
}
