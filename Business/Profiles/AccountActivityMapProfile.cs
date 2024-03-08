using System;
using AutoMapper;
using Business.Dtos.Requests.AccountActivityMapRequests;
using Business.Dtos.Requests.AccountBadgeRequests;
using Business.Dtos.Responses.AccountActivityMapResponses;
using Business.Dtos.Responses.AccountBadgeResponses;
using Business.Dtos.Responses.LessonResponses;
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

        CreateMap<AccountActivityMap, DeleteAccountActivityMapRequest>().ReverseMap();
        CreateMap<AccountActivityMap, DeletedAccountActivityMapResponse>().ReverseMap();

        CreateMap<IPaginate<AccountActivityMap>, Paginate<GetListAccountActivityMapResponse>>().ReverseMap();

        CreateMap<AccountActivityMap, GetListAccountActivityMapResponse>();

        CreateMap<List<GetListAccountActivityMapResponse>, Paginate<GetListAccountActivityMapResponse>>().ForMember
      (destinationMember: a => a.Items, memberOptions: l => l.MapFrom(l => l.ToList())).ReverseMap();

    }
}