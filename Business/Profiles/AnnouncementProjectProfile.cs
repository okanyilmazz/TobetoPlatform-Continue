using AutoMapper;
using Business.Dtos.Requests.AnnouncementProjectRequests;
using Business.Dtos.Responses.AnnouncementProjectResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AnnouncementProjectProfile : Profile
{
    public AnnouncementProjectProfile()
    {
        CreateMap<AnnouncementProject, CreateAnnouncementProjectRequest>().ReverseMap();
        CreateMap<AnnouncementProject, CreatedAnnouncementProjectResponse>().ReverseMap();

        CreateMap<AnnouncementProject, UpdateAnnouncementProjectRequest>().ReverseMap();
        CreateMap<AnnouncementProject, UpdatedAnnouncementProjectResponse>().ReverseMap();

        CreateMap<AnnouncementProject, DeletedAnnouncementProjectResponse>().ReverseMap();
        CreateMap<AnnouncementProject, GetAnnouncementProjectResponse>()
            .ForMember(destinationMember: response => response.Announcement, memberOptions:
            opt => opt.MapFrom(ap => ap.Announcement))
            .ForMember(destinationMember: response => response.Project, memberOptions:
            opt => opt.MapFrom(ap => ap.Project)).ReverseMap();

        CreateMap<AnnouncementProject, GetListAnnouncementProjectResponse>()
             .ForMember(destinationMember: response => response.Announcement, memberOptions:
            opt => opt.MapFrom(ap => ap.Announcement))
            .ForMember(destinationMember: response => response.Project, memberOptions:
            opt => opt.MapFrom(ap => ap.Project)).ReverseMap();

        CreateMap<IPaginate<AnnouncementProject>, Paginate<GetListAnnouncementProjectResponse>>().ReverseMap();
    }
}
