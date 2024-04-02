using Business.Abstracts;
using Business.Dtos.Requests.BlogImageRequests;
using Business.Messages;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogImagesController : ControllerBase
{
    IBlogImageService _blogImageService;
    public static IWebHostEnvironment _webHostEnvironment;

    public BlogImagesController(IBlogImageService blogImageService, IWebHostEnvironment webHostEnvironment)
    {
        _blogImageService = blogImageService;
        _webHostEnvironment = webHostEnvironment;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _blogImageService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _blogImageService.GetByIdAsync(Id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("BlogImages.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _blogImageService.DeleteAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("BlogImages.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] UpdateBlogImageRequest updateBlogImageRequest)
    {
        var result = await _blogImageService.UpdateAsync(updateBlogImageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("BlogImages.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm] CreateBlogImageRequest createBlogImageRequest)
    {
        var currentPath = _webHostEnvironment.ContentRootPath + PathConstant.ImagePath;
        var result = await _blogImageService.AddAsync(createBlogImageRequest, currentPath);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByBlogId")]
    public async Task<IActionResult> GetByBlogIdAsync(Guid blogId)
    {
        var result = await _blogImageService.GetByBlogIdAsync(blogId);
        return Ok(result);
    }
}
