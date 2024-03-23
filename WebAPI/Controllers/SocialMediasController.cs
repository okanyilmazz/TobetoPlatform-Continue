using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.SocialMediaValidators;
using Business.Dtos.Requests.SocialMediaRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController : ControllerBase
{
    ISocialMediaService _socialMediaService;

    public SocialMediasController(ISocialMediaService socialMediaService)
    {
        _socialMediaService = socialMediaService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _socialMediaService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _socialMediaService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid accountId)
    {
        var result = await _socialMediaService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("SocialMedias.Get")]
    [CustomValidation(typeof(CreateSocialMediaRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateSocialMediaRequest createSocialMediaRequest)
    {
        var result = await _socialMediaService.AddAsync(createSocialMediaRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("SocialMedias.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _socialMediaService.DeleteAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("SocialMedias.Get")]
    [CustomValidation(typeof(UpdateSocialMediaRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSocialMediaRequest updateSocialMediaRequest)
    {
        var result = await _socialMediaService.UpdateAsync(updateSocialMediaRequest);
        return Ok(result);
    }
}