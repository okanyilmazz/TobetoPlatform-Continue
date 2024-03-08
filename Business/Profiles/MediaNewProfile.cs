using AutoMapper;
using Business.Dtos.Requests.MediaNewRequests;
using Business.Dtos.Responses.MediaNewResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class MediaNewProfile : Profile
{
    public MediaNewProfile()
    {
        CreateMap<MediaNew, CreateMediaNewRequest>().ReverseMap();
        CreateMap<MediaNew, CreatedMediaNewResponse>().ReverseMap();

        CreateMap<MediaNew, UpdateMediaNewRequest>().ReverseMap();
        CreateMap<MediaNew, UpdatedMediaNewResponse>().ReverseMap();

        CreateMap<MediaNew, DeleteMediaNewRequest>().ReverseMap();
        CreateMap<MediaNew, DeletedMediaNewResponse>().ReverseMap();

        CreateMap<MediaNew, GetListMediaNewResponse>().ReverseMap();
        CreateMap<MediaNew, GetMediaNewResponse>().ReverseMap();
        CreateMap<IPaginate<MediaNew>, Paginate<GetListMediaNewResponse>>().ReverseMap();
    }
}
