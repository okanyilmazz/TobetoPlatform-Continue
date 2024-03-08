using AutoMapper;
using Business.Dtos.Requests.AccountSessionRequests;
using Business.Dtos.Responses.AccountSessionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AccountSessionProfile : Profile
    {
        public AccountSessionProfile()
        {
            CreateMap<AccountSession, CreatedAccountSessionResponse>().ReverseMap();
            CreateMap<AccountSession, CreateAccountSessionRequest>().ReverseMap();

            CreateMap<AccountSession, UpdateAccountSessionRequest>().ReverseMap();
            CreateMap<AccountSession, UpdatedAccountSessionResponse>().ReverseMap();

            CreateMap<AccountSession, DeleteAccountSessionRequest>().ReverseMap();
            CreateMap<AccountSession, DeletedAccountSessionResponse>().ReverseMap();

            CreateMap<AccountSession, GetListAccountSessionResponse>().ReverseMap();
            CreateMap<IPaginate<AccountSession>, Paginate<GetListAccountSessionResponse>>().ReverseMap();
        }
    }
}
