using Business.Abstracts;
using Business.Dtos.Requests.BadgeRequests;
using Business.Dtos.Requests.EducationProgramDevelopmentRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BadgesController : ControllerBase
{
    IBadgeService _badgeService;

    public BadgesController(IBadgeService badgeService)
    {
        _badgeService = badgeService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _badgeService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _badgeService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid id)
    {
        var result = await _badgeService.GetByAccountIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Badges.Get")]
    [HttpPost]
    [CustomValidation(typeof(CreateBadgeRequest))]


    public async Task<IActionResult> AddAsync([FromBody] CreateBadgeRequest createBadgeRequest)
    {
        var result = await _badgeService.AddAsync(createBadgeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Badges.Get")]
    [HttpPut]
    [CustomValidation(typeof(UpdateBadgeRequest))]

    public async Task<IActionResult> UpdateAsync([FromBody] UpdateBadgeRequest updateBadgeRequest)
    {
        var result = await _badgeService.UpdateAsync(updateBadgeRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Badges.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _badgeService.DeleteAsync(id);
        return Ok(result);
    }
}