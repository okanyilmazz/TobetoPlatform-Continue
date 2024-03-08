using AutoMapper;
using Business.Dtos.Requests.BadgeRequests;
using Business.Dtos.Responses.BadgeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class BadgeProfile : Profile
{
    public BadgeProfile()
    {
        CreateMap<Badge, CreateBadgeRequest>().ReverseMap();
        CreateMap<Badge, CreatedBadgeResponse>().ReverseMap();

        CreateMap<Badge, UpdateBadgeRequest>().ReverseMap();
        CreateMap<Badge, UpdatedBadgeResponse>().ReverseMap();

        CreateMap<Badge, DeleteBadgeRequest>().ReverseMap();
        CreateMap<Badge, DeletedBadgeResponse>().ReverseMap();

        CreateMap<Badge, GetListBadgeResponse>().ReverseMap();
        CreateMap<Badge, GetBadgeResponse>().ReverseMap();

        CreateMap<IPaginate<Badge>, Paginate<GetListBadgeResponse>>().ReverseMap();

        CreateMap<List<Badge>, Paginate<GetListBadgeResponse>>().ForMember(destinationMember: s => s.Items,
                memberOptions: opt => opt.MapFrom(s => s.ToList())).ReverseMap();
    }
}