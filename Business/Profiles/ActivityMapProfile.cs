using AutoMapper;
using Business.Dtos.Requests.ActivityMapRequests;
using Business.Dtos.Responses.ActivityMapResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ActivityMapProfile : Profile
{
    public ActivityMapProfile()
    {
        CreateMap<ActivityMap, CreateActivityMapRequest>().ReverseMap();
        CreateMap<ActivityMap, UpdateActivityMapRequest>().ReverseMap();

        CreateMap<ActivityMap, CreatedActivityMapResponse>().ReverseMap();
        CreateMap<ActivityMap, UpdatedActivityMapResponse>().ReverseMap();
        CreateMap<ActivityMap, DeletedActivityMapResponse>().ReverseMap();

        CreateMap<ActivityMap, GetActivityMapResponse>().ReverseMap();
        CreateMap<List<ActivityMap>, Paginate<GetListActivityMapResponse>>().ForMember(destinationMember: s => s.Items,
            memberOptions: opt => opt.MapFrom(s => s.ToList())).ReverseMap();
    }
}
