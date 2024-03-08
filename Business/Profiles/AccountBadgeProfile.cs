using AutoMapper;
using Business.Dtos.Requests.AccountBadgeRequests;
using Business.Dtos.Responses.AccountBadgeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountBadgeProfile : Profile
{
    public AccountBadgeProfile()
    {

        CreateMap<AccountBadge, CreateAccountBadgeRequest>().ReverseMap();
        CreateMap<AccountBadge, CreatedAccountBadgeResponse>().ReverseMap();

        CreateMap<AccountBadge, UpdateAccountBadgeRequest>().ReverseMap();
        CreateMap<AccountBadge, UpdatedAccountBadgeResponse>().ReverseMap();

        CreateMap<AccountBadge, DeleteAccountBadgeRequest>().ReverseMap();
        CreateMap<AccountBadge, DeletedAccountBadgeResponse>().ReverseMap();
        CreateMap<IPaginate<AccountBadge>, Paginate<GetListAccountBadgeResponse>>().ReverseMap();

        CreateMap<AccountBadge, GetListAccountBadgeResponse>()
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(ab => ab.Account.User.FirstName + " " + ab.Account.User.LastName))
            .ForMember(destinationMember: response => response.BadgeThumbnail,
            memberOptions: opt => opt.MapFrom(ab => ab.Badge.ThumbnailPath))
            .ReverseMap();

        CreateMap<List<AccountBadge>, Paginate<GetListAccountBadgeResponse>>()
            .ForMember(destinationMember: ab => ab.Items,
            memberOptions: opt => opt.MapFrom(h => h.ToList())).ReverseMap();

    }
}