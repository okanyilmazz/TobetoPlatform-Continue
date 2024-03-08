using Business.Abstracts;
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
public class EducationProgramDevelopmentsController : ControllerBase
{
    IEducationProgramDevelopmentService _educationProgramDevelopmentService;

    public EducationProgramDevelopmentsController(IEducationProgramDevelopmentService educationProgramDevelopmentService)
    {
        _educationProgramDevelopmentService = educationProgramDevelopmentService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramDevelopmentService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramDevelopmentService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramDevelopments.Get")]
    [CustomValidation(typeof(CreateEducationProgramDevelopmentRequest))]

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramDevelopmentRequest createEducationProgramDevelopmentRequest)
    {
        var result = await _educationProgramDevelopmentService.AddAsync(createEducationProgramDevelopmentRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramDevelopments.Get")]
    [CustomValidation(typeof(UpdateEducationProgramDevelopmentRequest))]

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramDevelopmentRequest updateEducationProgramDevelopmentRequest)
    {
        var result = await _educationProgramDevelopmentService.UpdateAsync(updateEducationProgramDevelopmentRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramDevelopments.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramDevelopmentRequest deleteEducationProgramDevelopmentRequest)
    {
        var result = await _educationProgramDevelopmentService.DeleteAsync(deleteEducationProgramDevelopmentRequest);
        return Ok(result);
    }
}
