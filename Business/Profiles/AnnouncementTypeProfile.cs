using AutoMapper;
using Business.Dtos.Requests.AnnouncementTypeRequests;
using Business.Dtos.Responses.AnnouncementTypeResponse;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AnnouncementTypeProfile : Profile
{
    public AnnouncementTypeProfile()
    {
        CreateMap<AnnouncementType, CreateAnnouncementTypeRequest>().ReverseMap();
        CreateMap<AnnouncementType, CreatedAnnouncementTypeResponse>().ReverseMap();

        CreateMap<AnnouncementType, UpdateAnnouncementTypeRequest>().ReverseMap();
        CreateMap<AnnouncementType, UpdatedAnnouncementTypeResponse>().ReverseMap();

        CreateMap<AnnouncementType, DeleteAnnouncementTypeRequest>().ReverseMap();
        CreateMap<AnnouncementType, DeletedAnnouncementTypeResponse>().ReverseMap();


        CreateMap<IPaginate<AnnouncementType>, Paginate<GetListAnnouncementTypeResponse>>().ReverseMap();
        CreateMap<AnnouncementType, GetListAnnouncementTypeResponse>().ReverseMap();
    }
}
