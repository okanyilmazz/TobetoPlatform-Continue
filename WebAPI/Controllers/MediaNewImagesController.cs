using Business.Abstracts;
using Business.Dtos.Requests.MediaNewImageRequests;
using Business.Messages;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaNewImagesController : ControllerBase
    {
        IMediaNewImageService _mediaNewImageService;
        public static IWebHostEnvironment _webHostEnvironment;

        public MediaNewImagesController(IMediaNewImageService mediaNewImageService, IWebHostEnvironment webHostEnvironment)
        {
            _mediaNewImageService = mediaNewImageService;
            _webHostEnvironment = webHostEnvironment;
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _mediaNewImageService.GetListAsync(pageRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _mediaNewImageService.GetByIdAsync(Id);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("MediaNewImages.Get")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _mediaNewImageService.DeleteAsync(id);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("MediaNewImages.Get")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateMediaNewImageRequest updateMediaNewImageRequest)
        {
            var result = await _mediaNewImageService.UpdateAsync(updateMediaNewImageRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("MediaNewImages.Get")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] CreateMediaNewImageRequest createMediaNewImageRequest)
        {
            var currentPath = _webHostEnvironment.ContentRootPath + PathConstant.ImagePath;
            var result = await _mediaNewImageService.AddAsync(createMediaNewImageRequest, currentPath);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache]
        [HttpGet("GetByMediaNewId")]
        public async Task<IActionResult> GetByMediaNewIdAsync(Guid mediaNewId)
        {
            var result = await _mediaNewImageService.GetByMediaNewIdAsync(mediaNewId);
            return Ok(result);
        }
    }
}
