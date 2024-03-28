using AutoMapper;
using Business.Dtos.Requests.AccountEducationProgramRequests;
using Business.Dtos.Responses.AccountEducationProgramResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountEducationProgramProfile : Profile
{
    public AccountEducationProgramProfile()
    {
        CreateMap<AccountEducationProgram, CreateAccountEducationProgramRequest>().ReverseMap();
        CreateMap<AccountEducationProgram, CreatedAccountEducationProgramResponse>().ReverseMap();

        CreateMap<AccountEducationProgram, UpdateAccountEducationProgramRequest>().ReverseMap();
        CreateMap<AccountEducationProgram, UpdatedAccountEducationProgramResponse>().ReverseMap();

        CreateMap<AccountEducationProgram, DeletedAccountEducationProgramResponse>().ReverseMap();

        CreateMap<IPaginate<AccountEducationProgram>, Paginate<GetListAccountEducationProgramResponse>>().ReverseMap();
        CreateMap<AccountEducationProgram, GetAccountEducationProgramResponse>()
            .ForMember(destinationMember: response => response.EducationProgramName,
            memberOptions: opt => opt.MapFrom(aep => aep.EducationProgram.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(aep => aep.Account.User.FirstName + " " + aep.Account.User.LastName))
            .ReverseMap();

        CreateMap<AccountEducationProgram, GetListAccountEducationProgramResponse>()
            .ForMember(destinationMember: response => response.EducationProgramName,
            memberOptions: opt => opt.MapFrom(aep => aep.EducationProgram.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(aep => aep.Account.User.FirstName + " " + aep.Account.User.LastName))
            .ReverseMap();
    }
}
