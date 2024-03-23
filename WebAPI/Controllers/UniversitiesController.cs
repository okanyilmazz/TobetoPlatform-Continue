using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.UniversityValidators;
using Business.Dtos.Requests.UniversityResquests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : ControllerBase
{
    IUniversityService _universityService;

    public UniversitiesController(IUniversityService universityService)
    {
        _universityService = universityService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _universityService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _universityService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Universities.Get")]
    [CustomValidation(typeof(CreateUniversityRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateUniversityRequest createUniversityRequest)
    {
        var result = await _universityService.AddAsync(createUniversityRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Universities.Get")]
    [CustomValidation(typeof(UpdateUniversityRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUniversityRequest updateUniversityRequest)
    {
        var result = await _universityService.UpdateAsync(updateUniversityRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Universities.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _universityService.DeleteAsync(id);
        return Ok(result);
    }
}