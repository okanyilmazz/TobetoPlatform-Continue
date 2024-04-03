using AutoMapper;
using Business.Dtos.Requests.MediaNewImageRequests;
using Business.Dtos.Responses.MediaNewImageResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class MediaNewImageProfile : Profile
    {
        public MediaNewImageProfile()
        {
            CreateMap<MediaNewImage, CreateMediaNewImageRequest>().ReverseMap();
            CreateMap<MediaNewImage, CreatedMediaNewImageResponse>().ReverseMap();

            CreateMap<MediaNewImage, UpdateMediaNewImageRequest>().ReverseMap();
            CreateMap<MediaNewImage, UpdatedMediaNewImageResponse>().ReverseMap();

            CreateMap<MediaNewImage, DeletedMediaNewImageResponse>().ReverseMap();


            CreateMap<IPaginate<MediaNewImage>, Paginate<GetListMediaNewImageResponse>>().ReverseMap();
            CreateMap<MediaNewImage, GetListMediaNewImageResponse>().ReverseMap();
            CreateMap<MediaNewImage, GetMediaNewImageResponse>().ReverseMap();
        }
    }
}
