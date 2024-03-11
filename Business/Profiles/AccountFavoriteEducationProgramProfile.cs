using AutoMapper;
using Business.Dtos.Requests.AccountViewLessonRequest;
using Business.Dtos.Responses.AccountFavoriteEducationProgramResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountFavoriteEducationProgramProfile : Profile
{
    public AccountFavoriteEducationProgramProfile()
    {
        CreateMap<AccountFavoriteEducationProgram, CreateAccountFavoriteEducationProgramRequest>().ReverseMap();
        CreateMap<AccountFavoriteEducationProgram, CreatedAccountFavoriteEducationProgramResponse>().ReverseMap();

        CreateMap<AccountFavoriteEducationProgram, UpdateAccountFavoriteEducationProgramRequest>().ReverseMap();
        CreateMap<AccountFavoriteEducationProgram, UpdatedAccountFavoriteEducationProgramResponse>().ReverseMap();

        CreateMap<AccountFavoriteEducationProgram, DeleteAccountFavoriteEducationProgramRequest>().ReverseMap();
        CreateMap<AccountFavoriteEducationProgram, DeletedAccountFavoriteEducationProgramResponse>().ReverseMap();

        CreateMap<AccountFavoriteEducationProgram, GetAccountFavoriteEducationProgramResponse>().ReverseMap();
        CreateMap<AccountFavoriteEducationProgram, GetListAccountFavoriteEducationProgramResponse>().ReverseMap();
        CreateMap<IPaginate<AccountFavoriteEducationProgram>, Paginate<GetListAccountFavoriteEducationProgramResponse>>().ReverseMap();
    }
}
