using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.BlogRequests;
using Business.Dtos.Responses.BlogResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BlogManager : IBlogService
{

    IBlogDal _blogDal;
    IMapper _mapper;
    BlogBusinessRules _blogBusinessRules;

    public BlogManager(IBlogDal blogDal, IMapper mapper, BlogBusinessRules blogBusinessRules)
    {
        _blogDal = blogDal;
        _mapper = mapper;
        _blogBusinessRules = blogBusinessRules;

    }

    public async Task<CreatedBlogResponse> AddAsync(CreateBlogRequest createBlogRequest)
    {
        Blog blog = _mapper.Map<Blog>(createBlogRequest);
        Blog createdBlog = await _blogDal.AddAsync(blog);
        CreatedBlogResponse createdBlogResponse = _mapper.Map<CreatedBlogResponse>(createdBlog);
        return createdBlogResponse;
    }

    public async Task<DeletedBlogResponse> DeleteAsync(Guid id)
    {
        await _blogBusinessRules.IsExistsBlog(id);
        Blog blog = await _blogDal.GetAsync(predicate: l => l.Id == id);
        Blog deletedBlog = await _blogDal.DeleteAsync(blog);
        DeletedBlogResponse deletedBlogResponse = _mapper.Map<DeletedBlogResponse>(deletedBlog);
        return deletedBlogResponse;
    }

    public async Task<GetBlogResponse> GetByIdAsync(Guid Id)
    {
        var blog = await _blogDal.GetAsync(b => b.Id == Id);
        var mappedBlog = _mapper.Map<GetBlogResponse>(blog);
        return mappedBlog;
    }

    public async Task<IPaginate<GetListBlogResponse>> GetListAsync(PageRequest pageRequest)
    {
        var blogs = await _blogDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedBlogs = _mapper.Map<Paginate<GetListBlogResponse>>(blogs);
        return mappedBlogs;
    }

    public async Task<UpdatedBlogResponse> UpdateAsync(UpdateBlogRequest updateBlogRequest)
    {
        await _blogBusinessRules.IsExistsBlog(updateBlogRequest.Id);
        Blog blog = _mapper.Map<Blog>(updateBlogRequest);
        Blog updatedBlog = await _blogDal.UpdateAsync(blog);
        UpdatedBlogResponse updatedBlogResponse = _mapper.Map<UpdatedBlogResponse>(updatedBlog);
        return updatedBlogResponse;
    }
}