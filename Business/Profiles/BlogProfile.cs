using AutoMapper;
using Business.Dtos.Requests.BlogRequests;
using Business.Dtos.Responses.BlogResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class BlogProfile: Profile
{
    public BlogProfile()
    {
        CreateMap<Blog, CreateBlogRequest>().ReverseMap();
        CreateMap<Blog, CreatedBlogResponse>().ReverseMap();

        CreateMap<Blog, UpdateBlogRequest>().ReverseMap();
        CreateMap<Blog, UpdatedBlogResponse>().ReverseMap();

        CreateMap<Blog, DeleteBlogRequest>().ReverseMap();
        CreateMap<Blog, DeletedBlogResponse>().ReverseMap();


        CreateMap<IPaginate<Blog>, Paginate<GetListBlogResponse>>().ReverseMap();
        CreateMap<Blog, GetListBlogResponse>().ReverseMap();
    }
}
