using AutoMapper;
using Business.Dtos.Requests.AccountCompetenceTestRequests;
using Business.Dtos.Responses.AccountCompetenceTestResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountCompetenceTestProfile : Profile
{
    public AccountCompetenceTestProfile()
    {
        CreateMap<AccountCompetenceTest, CreateAccountCompetenceTestRequest>().ReverseMap();
        CreateMap<AccountCompetenceTest, CreatedAccountCompetenceTestResponse>().ReverseMap();

        CreateMap<AccountCompetenceTest, UpdateAccountCompetenceTestRequest>().ReverseMap();
        CreateMap<AccountCompetenceTest, UpdatedAccountCompetenceTestResponse>().ReverseMap();

        CreateMap<AccountCompetenceTest, DeleteAccountCompetenceTestRequest>().ReverseMap();
        CreateMap<AccountCompetenceTest, DeletedAccountCompetenceTestResponse>().ReverseMap();


        CreateMap<IPaginate<AccountCompetenceTest>, Paginate<GetListAccountCompetenceTestResponse>>().ReverseMap();
        CreateMap<AccountCompetenceTest, GetListAccountCompetenceTestResponse>().ReverseMap();
    }
}
