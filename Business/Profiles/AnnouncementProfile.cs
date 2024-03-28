using AutoMapper;
using Business.Dtos.Requests.AnnouncementRequests;
using Business.Dtos.Responses.AnnouncementResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AnnouncementProfile : Profile
{
    public AnnouncementProfile()
    {
        CreateMap<Announcement, CreateAnnouncementRequest>().ReverseMap();
        CreateMap<Announcement, CreatedAnnouncementResponse>().ReverseMap();

        CreateMap<Announcement, UpdateAnnouncementRequest>().ReverseMap();
        CreateMap<Announcement, UpdatedAnnouncementResponse>().ReverseMap();

        CreateMap<Announcement, DeletedAnnouncementResponse>().ReverseMap();

        CreateMap<Announcement, GetAnnouncementResponse>()
            .ForMember(destinationMember: response => response.AnnouncementTypeName,
            memberOptions: opt => opt.MapFrom(er => er.AnnouncementType.Name)).ReverseMap();

        CreateMap<IPaginate<Announcement>, Paginate<GetListAnnouncementResponse>>().ReverseMap();

        CreateMap<Announcement, GetListAnnouncementResponse>()
       .ForMember(destinationMember: response => response.AnnouncementTypeName,
       memberOptions: opt => opt.MapFrom(er => er.AnnouncementType.Name)).ReverseMap();

    }
}