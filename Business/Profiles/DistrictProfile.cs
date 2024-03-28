using AutoMapper;
using Business.Dtos.Requests.DistrictRequests;
using Business.Dtos.Responses.DistrictResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class DistrictProfile : Profile
{
    public DistrictProfile()
    {

        CreateMap<District, CreateDistrictRequest>().ReverseMap();
        CreateMap<District, CreatedDistrictResponse>().ReverseMap();

        CreateMap<District, UpdateDistrictRequest>().ReverseMap();
        CreateMap<District, UpdatedDistrictResponse>().ReverseMap();

        CreateMap<District, DeletedDistrictResponse>().ReverseMap();

        CreateMap<District, GetDistrictResponse>()
            .ForMember(destinationMember: response => response.CityName,
            memberOptions: opt => opt.MapFrom(d => d.City.Name))
            .ReverseMap();

        CreateMap<District, GetListDistrictResponse>()
            .ForMember(destinationMember: response => response.CityName,
            memberOptions: opt => opt.MapFrom(d => d.City.Name))
            .ReverseMap();

        CreateMap<IPaginate<District>, Paginate<GetListDistrictResponse>>().ReverseMap();
        
    }
}
