using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.OccupationClassValidators;
using Business.Dtos.Requests.OccupationClassRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OccupationClassesController : ControllerBase
{
    IOccupationClassService _occupationClassService;

    public OccupationClassesController(IOccupationClassService occupationClassService)
    {
        _occupationClassService = occupationClassService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _occupationClassService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _occupationClassService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId)
    {
        var result = await _occupationClassService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("OccupationClasses.Get")]
    [CustomValidation(typeof(CreateOccupationClassRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateOccupationClassRequest createOccupationClassRequest)
    {
        var result = await _occupationClassService.AddAsync(createOccupationClassRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("OccupationClasses.Get")]
    [CustomValidation(typeof(UpdateOccupationClassRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateOccupationClassRequest updateOccupationClassRequest)
    {
        var result = await _occupationClassService.UpdateAsync(updateOccupationClassRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("OccupationClasses.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteOccupationClassRequest deleteOccupationClassRequest)
    {
        var result = await _occupationClassService.DeleteAsync(deleteOccupationClassRequest);
        return Ok(result);
    }
}
