using AutoMapper;
using Business.Dtos.Requests.OccupationClassRequests;
using Business.Dtos.Responses.OccupationClassResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class OccupationClassProfile : Profile
{
    public OccupationClassProfile()
    {
        CreateMap<OccupationClass, CreateOccupationClassRequest>().ReverseMap();
        CreateMap<OccupationClass, CreatedOccupationClassResponse>().ReverseMap();

        CreateMap<OccupationClass, DeleteOccupationClassRequest>().ReverseMap();
        CreateMap<OccupationClass, DeletedOccupationClassResponse>().ReverseMap();

        CreateMap<OccupationClass, UpdateOccupationClassRequest>().ReverseMap();
        CreateMap<OccupationClass, UpdatedOccupationClassResponse>().ReverseMap();

        CreateMap<IPaginate<OccupationClass>, Paginate<GetListOccupationClassResponse>>().ReverseMap();
        CreateMap<OccupationClass, GetListOccupationClassResponse>().ReverseMap();
        CreateMap<OccupationClass, GetOccupationClassResponse>().ReverseMap();
    }
}
