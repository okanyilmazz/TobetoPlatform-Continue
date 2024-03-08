using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.AddressValidators;
using Business.Dtos.Requests.AddressRequests;
using Business.Rules.ValidationRules.FluentValidation.ActivityMapValidators;
using Business.Dtos.Requests.ActivityMapRequests;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityMapsController : ControllerBase
{
    IActivityMapService _activityMapService;

    public ActivityMapsController(IActivityMapService activityMapService)
    {
        _activityMapService = activityMapService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _activityMapService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _activityMapService.GetByIdAsync(Id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ActivityMap.Get")]
    [CustomValidation(typeof(CreateActivityMapRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateActivityMapRequest createActivityMapRequest)
    {
        var result = await _activityMapService.AddAsync(createActivityMapRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ActivityMap.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteActivityMapRequest deleteActivityMapRequest)
    {
        var result = await _activityMapService.DeleteAsync(deleteActivityMapRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ActivityMap.Get")]
    [CustomValidation(typeof(UpdateActivityMapRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateActivityMapRequest updateActivityMapRequest)
    {
        var result = await _activityMapService.UpdateAsync(updateActivityMapRequest);
        return Ok(result);
    }
}
