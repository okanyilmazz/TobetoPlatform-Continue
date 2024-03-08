using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.EducationProgramValidators;
using Business.Dtos.Requests.EducationProgramRequests;
using Business.Dtos.Requests.FilterRequest;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramsController : ControllerBase
{
    IEducationProgramService _educationProgramService;

    public EducationProgramsController(IEducationProgramService EducationProgramService)
    {
        _educationProgramService = EducationProgramService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _educationProgramService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationPrograms.Get")]
    [HttpPost("GetListByFiltered")]
    public async Task<IActionResult> GetListByFiltered([FromBody] EducationProgramFilterRequest educationProgramFilterRequest)
    {
        var result = await _educationProgramService.GetListByFiltered(educationProgramFilterRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetListByOccupationClassId")]
    public async Task<IActionResult> GetByOccupationClassId([FromQuery] Guid id)
    {
        var result = await _educationProgramService.GetByOccupationClassIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] PageRequest pageRequest, Guid accountId)
    {
        var result = await _educationProgramService.GetByAccountIdAsync(accountId, pageRequest);
        return Ok(result); 
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationPrograms.Get")]
    [CustomValidation(typeof(CreateEducationProgramRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramRequest createEducationProgramRequest)
    {
        var result = await _educationProgramService.AddAsync(createEducationProgramRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationPrograms.Get")]
    [CustomValidation(typeof(UpdateEducationProgramRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramRequest updateEducationProgramRequest)
    {
        var result = await _educationProgramService.UpdateAsync(updateEducationProgramRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationPrograms.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramRequest deleteEducationProgramRequest)
    {
        var result = await _educationProgramService.DeleteAsync(deleteEducationProgramRequest);
        return Ok(result);
    }


 
}
