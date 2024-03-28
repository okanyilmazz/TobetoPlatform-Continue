using AutoMapper;
using Business.Dtos.Requests.OccupationRequests;
using Business.Dtos.Responses.OccupationResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class OccupationProfile : Profile
{
    public OccupationProfile()
    {
            CreateMap<Occupation, CreateOccupationRequest>().ReverseMap();
            CreateMap<Occupation, CreatedOccupationResponse>().ReverseMap();

            CreateMap<Occupation, DeletedOccupationResponse>().ReverseMap();

            CreateMap<Occupation, UpdateOccupationRequest>().ReverseMap();
            CreateMap<Occupation, UpdatedOccupationResponse>().ReverseMap();

            CreateMap<IPaginate<Occupation>, Paginate<GetListOccupationResponse>>().ReverseMap();
            CreateMap<Occupation, GetListOccupationResponse>().ReverseMap();
            CreateMap<Occupation, GetOccupationResponse>().ReverseMap();
    }
}
