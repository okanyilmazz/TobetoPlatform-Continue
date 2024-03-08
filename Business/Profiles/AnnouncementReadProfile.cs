using AutoMapper;
using Business.Dtos.Requests.AnnouncementReadRequests;
using Business.Dtos.Responses.AnnouncementReadResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AnnouncementReadProfile : Profile
{
    public AnnouncementReadProfile()
    {
        CreateMap<AnnouncementRead, CreateAnnouncementReadRequest>().ReverseMap();
        CreateMap<AnnouncementRead, CreatedAnnouncementReadResponse>().ReverseMap();

        CreateMap<AnnouncementRead, UpdateAnnouncementReadRequest>().ReverseMap();
        CreateMap<AnnouncementRead, UpdatedAnnouncementReadResponse>().ReverseMap();

        CreateMap<AnnouncementRead, DeleteAnnouncementReadRequest>().ReverseMap();
        CreateMap<AnnouncementRead, DeletedAnnouncementReadResponse>().ReverseMap();


        CreateMap<IPaginate<AnnouncementRead>, Paginate<GetListAnnouncementReadResponse>>().ReverseMap();
        CreateMap<AnnouncementRead, GetListAnnouncementReadResponse>().ReverseMap();
    }
}
