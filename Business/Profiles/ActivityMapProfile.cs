using AutoMapper;
using Business.Dtos.Requests.ActivityMapRequests;
using Business.Dtos.Requests.AddressRequests;
using Business.Dtos.Responses.ActivityMapResponses;
using Business.Dtos.Responses.AddressResponses;
using Business.Dtos.Responses.SkillResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ActivityMapProfile : Profile
    {
        public ActivityMapProfile()
        {
            CreateMap<ActivityMap, CreateActivityMapRequest>().ReverseMap();
            CreateMap<ActivityMap, UpdateActivityMapRequest>().ReverseMap();
            CreateMap<ActivityMap, DeleteActivityMapRequest>().ReverseMap();

            CreateMap<ActivityMap, CreatedActivityMapResponse>().ReverseMap();
            CreateMap<ActivityMap, UpdatedActivityMapResponse>().ReverseMap();
            CreateMap<ActivityMap, DeletedActivityMapResponse>().ReverseMap();


            CreateMap<List<ActivityMap>, Paginate<GetListActivityMapResponse>>().ForMember(destinationMember: s => s.Items,
                memberOptions: opt => opt.MapFrom(s => s.ToList())).ReverseMap();
        }
    }
}
