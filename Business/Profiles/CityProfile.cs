using AutoMapper;
using Business.Dtos.Requests.CityRequests;
using Business.Dtos.Responses.CityResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CreateCityRequest>().ReverseMap();
        CreateMap<City, CreatedCityResponse>().ReverseMap();

        CreateMap<City, DeleteCityRequest>().ReverseMap();
        CreateMap<City, DeletedCityResponse>().ReverseMap();

        CreateMap<City, UpdateCityRequest>().ReverseMap();
        CreateMap<City, UpdatedCityResponse>().ReverseMap();

        CreateMap<IPaginate<City>, Paginate<GetListCityResponse>>().ReverseMap();

        CreateMap<City, GetCityResponse>()
            .ForMember(destinationMember: response => response.CountryName,
            memberOptions: opt => opt.MapFrom(c => c.Country.Name)).ReverseMap();

        CreateMap<City, GetListCityResponse>()
            .ForMember(destinationMember: response => response.CountryName,
            memberOptions: opt => opt.MapFrom(c => c.Country.Name)).ReverseMap();
    }
}
