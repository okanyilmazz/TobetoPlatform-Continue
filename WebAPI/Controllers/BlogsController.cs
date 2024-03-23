using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.BlogValidators;
using Business.Dtos.Requests.BlogRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _blogService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _blogService.GetByIdAsync(Id);
        return Ok(result);
    }


    //[SecuredOperation("Admin,SuperAdmin")]
    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Blogs.Get")]
    [CustomValidation(typeof(CreateBlogRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateBlogRequest createBlogRequest)
    {
        var result = await _blogService.AddAsync(createBlogRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Blogs.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _blogService.DeleteAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Blogs.Get")]
    [CustomValidation(typeof(UpdateBlogRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateBlogRequest updateBlogRequest)
    {
        var result = await _blogService.UpdateAsync(updateBlogRequest);
        return Ok(result);
    }
}
