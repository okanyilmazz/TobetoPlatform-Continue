using AutoMapper;
using Business.Dtos.Requests.AccountActivityMapRequests;
using Business.Dtos.Responses.AccountActivityMapResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountActivityMapProfile : Profile
{
    public AccountActivityMapProfile()
    {

        CreateMap<AccountActivityMap, CreateAccountActivityMapRequest>().ReverseMap();
        CreateMap<AccountActivityMap, CreatedAccountActivityMapResponse>().ReverseMap();

        CreateMap<AccountActivityMap, UpdateAccountActivityMapRequest>().ReverseMap();
        CreateMap<AccountActivityMap, UpdatedAccountActivityMapResponse>().ReverseMap();

        CreateMap<AccountActivityMap, DeletedAccountActivityMapResponse>().ReverseMap();

        CreateMap<IPaginate<AccountActivityMap>, Paginate<GetListAccountActivityMapResponse>>().ReverseMap();

        CreateMap<AccountActivityMap, GetListAccountActivityMapResponse>().ReverseMap();
        CreateMap<AccountActivityMap, GetAccountActivityMapResponse>().ReverseMap();

        CreateMap<List<GetListAccountActivityMapResponse>, Paginate<GetListAccountActivityMapResponse>>()
            .ForMember(destinationMember: a => a.Items, memberOptions: l => l.MapFrom(l => l.ToList())).ReverseMap();

    }
}