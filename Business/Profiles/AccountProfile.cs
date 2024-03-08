﻿using AutoMapper;
using Business.Dtos.Requests.AccountRequests;
using Business.Dtos.Responses.AccountResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, CreatedAccountResponse>().ReverseMap();
        CreateMap<Account, CreateAccountRequest>().ReverseMap();

        CreateMap<Account, UpdateAccountRequest>().ReverseMap();
        CreateMap<Account, UpdatedAccountResponse>().ReverseMap();

        CreateMap<Account, DeleteAccountRequest>().ReverseMap();
        CreateMap<Account, DeletedAccountResponse>().ReverseMap();

        CreateMap<Account, GetListAccountResponse>()
            //.ForMember(destinationMember: response => response.DistrictId,
            //memberOptions: a => a.MapFrom(a => a.Address.District.Id))
            //.ForMember(destinationMember: response => response.CityId,
            //memberOptions: a => a.MapFrom(a => a.Address.City.Id))
            //.ForMember(destinationMember: response => response.CountryId,
            //memberOptions: a => a.MapFrom(a => a.Address.Country.Id))
            .ForMember(destinationMember: response => response.FirstName,
            memberOptions: a => a.MapFrom(a => a.User.FirstName))
              .ForMember(destinationMember: response => response.LastName,
            memberOptions: a => a.MapFrom(a => a.User.LastName))
            .ForMember(destinationMember: response => response.Email,
            memberOptions: a => a.MapFrom(a => a.User.Email))
         .ForMember(dest => dest.OccupationClassName, opt => opt.MapFrom
         (src => string.Join(", ", src.AccountOccupationClasses.Select(aoc => aoc.OccupationClass.Name))))
           .ForMember(dest => dest.OccupationClassId, opt => opt.MapFrom
         (src => string.Join(", ", src.AccountOccupationClasses.Select(aoc => aoc.OccupationClass.Id))));



        CreateMap<IPaginate<Account>, Paginate<GetListAccountResponse>>().ReverseMap();

        CreateMap<List<Account>, Paginate<GetListAccountResponse>>().ForMember(destinationMember: h => h.Items,
            memberOptions: opt => opt.MapFrom(h => h.ToList())).ReverseMap();
    }
}