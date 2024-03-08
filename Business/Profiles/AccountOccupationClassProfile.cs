using AutoMapper;
using Business.Dtos.Requests.AccountOccupationClassRequests;
using Business.Dtos.Responses.AccountOccupationClassResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AccountOccupationClassProfile : Profile
    {
        public AccountOccupationClassProfile()
        {
            CreateMap<AccountOccupationClass, CreateAccountOccupationClassRequest>().ReverseMap();
            CreateMap<AccountOccupationClass, UpdateAccountOccupationClassRequest>().ReverseMap();
            CreateMap<AccountOccupationClass, DeleteAccountOccupationClassRequest>().ReverseMap();

            CreateMap<AccountOccupationClass, CreatedAccountOccupationClassResponse>().ReverseMap();
            CreateMap<AccountOccupationClass, UpdatedAccountOccupationClassResponse>().ReverseMap();
            CreateMap<AccountOccupationClass, DeletedAccountOccupationClassResponse>().ReverseMap();

            CreateMap<IPaginate<AccountOccupationClass>, Paginate<GetListAccountOccupationClassResponse>>().ReverseMap();
            CreateMap<AccountOccupationClass, GetListAccountOccupationClassResponse>()
                .ForMember(destinationMember: response => response.OccupationClassName,
                memberOptions: opt => opt.MapFrom(aoc => aoc.OccupationClass.Name))
                .ForMember(destinationMember: response => response.AccountName,
                memberOptions: opt => opt.MapFrom(aoc => aoc.Account.User.FirstName)
                )
                .ReverseMap();
        }
    }
}
