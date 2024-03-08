using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.OccupationValidators;
using Business.Dtos.Requests.OccupationRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OccupationsController : ControllerBase
{
    IOccupationService _occupationService;

    public OccupationsController(IOccupationService occupationService)
    {
        _occupationService = occupationService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _occupationService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _occupationService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Occupations.Get")]
    [CustomValidation(typeof(CreateOccupationRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateOccupationRequest createOccupationRequest)
    {
        var result = await _occupationService.AddAsync(createOccupationRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Occupations.Get")]
    [CustomValidation(typeof(UpdateOccupationRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateOccupationRequest updateOccupationRequest)
    {
        var result = await _occupationService.UpdateAsync(updateOccupationRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Occupations.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteOccupationRequest deleteOccupationRequest)
    {
        var result = await _occupationService.DeleteAsync(deleteOccupationRequest);
        return Ok(result);
    }
}
