using AutoMapper;
using Business.Dtos.Requests.BlogImageRequests;
using Business.Dtos.Responses.BlogImageResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class BlogImageProfile : Profile
    {
        public BlogImageProfile()
        {
            CreateMap<BlogImage, CreateBlogImageRequest>().ReverseMap();
            CreateMap<BlogImage, CreatedBlogImageResponse>().ReverseMap();

            CreateMap<BlogImage, UpdateBlogImageRequest>().ReverseMap();
            CreateMap<BlogImage, UpdatedBlogImageResponse>().ReverseMap();

            CreateMap<BlogImage, DeletedBlogImageResponse>().ReverseMap();


            CreateMap<IPaginate<BlogImage>, Paginate<GetListBlogImageResponse>>().ReverseMap();
            CreateMap<BlogImage, GetListBlogImageResponse>().ReverseMap();
            CreateMap<BlogImage, GetBlogImageResponse>().ReverseMap();
        }
    }
}
