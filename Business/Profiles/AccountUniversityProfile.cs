using AutoMapper;
using Business.Dtos.Requests.AccountUniversityRequests;
using Business.Dtos.Responses.AccountUniversityResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountUniversityProfile : Profile
{
    public AccountUniversityProfile()
    {
        CreateMap<AccountUniversity, CreateAccountUniversityRequest>().ReverseMap();
        CreateMap<AccountUniversity, CreatedAccountUniversityResponse>().ReverseMap();

        CreateMap<AccountUniversity, UpdateAccountUniversityRequest>().ReverseMap();
        CreateMap<AccountUniversity, UpdatedAccountUniversityResponse>().ReverseMap();

        CreateMap<AccountUniversity, DeletedAccountUniversityResponse>().ReverseMap();

        CreateMap<AccountUniversity, GetAccountUniversityResponse>()
            .ForMember(destinationMember: response => response.UniversityName,
            memberOptions: opt => opt.MapFrom(au => au.University.Name))
            .ForMember(destinationMember: response => response.UniversityDepartmentName,
            memberOptions: opt => opt.MapFrom(au => au.UniversityDepartment.Name))
            .ForMember(destinationMember: response => response.DegreeTypeName,
            memberOptions: opt => opt.MapFrom(au => au.DegreeType.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(au => au.Account.User.FirstName))
            .ReverseMap();

        CreateMap<AccountUniversity, GetListAccountUniversityResponse>()
            .ForMember(destinationMember: response => response.UniversityName,
            memberOptions: opt => opt.MapFrom(au => au.University.Name))
            .ForMember(destinationMember: response => response.UniversityDepartmentName,
            memberOptions: opt => opt.MapFrom(au => au.UniversityDepartment.Name))
            .ForMember(destinationMember: response => response.DegreeTypeName,
            memberOptions: opt => opt.MapFrom(au => au.DegreeType.Name))
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(au => au.Account.User.FirstName))
            .ReverseMap();

        CreateMap<IPaginate<AccountUniversity>, Paginate<GetListAccountUniversityResponse>>().ReverseMap();
    }
}
