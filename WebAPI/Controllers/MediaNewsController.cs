using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.MediaNewValidators;
using Business.Dtos.Requests.MediaNewRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaNewsController : ControllerBase
{
    IMediaNewService _mediaNewService;

    public MediaNewsController(IMediaNewService mediaNewService)
    {
        _mediaNewService = mediaNewService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _mediaNewService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _mediaNewService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("MediaNews.Get")]
    [CustomValidation(typeof(CreateMediaNewRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateMediaNewRequest createMediaNewRequest)
    {
        var result = await _mediaNewService.AddAsync(createMediaNewRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("MediaNews.Get")]
    [CustomValidation(typeof(UpdateMediaNewRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateMediaNewRequest updateMediaNewRequest)
    {
        var result = await _mediaNewService.UpdateAsync(updateMediaNewRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("MediaNews.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _mediaNewService.DeleteAsync(id);
        return Ok(result);
    }
}
