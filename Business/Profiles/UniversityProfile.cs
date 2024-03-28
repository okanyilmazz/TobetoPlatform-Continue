using AutoMapper;
using Business.Dtos.Requests.UniversityResquests;
using Business.Dtos.Responses.UniversityResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class UniversityProfile : Profile
{
    public UniversityProfile()
    {
        CreateMap<University, CreateUniversityRequest>().ReverseMap();
        CreateMap<University, CreatedUniversityResponse>().ReverseMap();

        CreateMap<University, UpdateUniversityRequest>().ReverseMap();
        CreateMap<University, UpdatedUniversityResponse>().ReverseMap();

        CreateMap<University, DeletedUniversityResponse>().ReverseMap();

        CreateMap<University, GetUniversityResponse>().ReverseMap();
        CreateMap<University, GetListUniversityResponse>().ReverseMap();
        CreateMap<IPaginate<University>, Paginate<GetListUniversityResponse>>().ReverseMap();
    }
}
