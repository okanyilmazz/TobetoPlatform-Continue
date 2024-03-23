using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.EducationProgramOccupationClassRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramOccupationClassesController : ControllerBase
{
    IEducationProgramOccupationClassService _educationProgramOccupationClassService;

    public EducationProgramOccupationClassesController(IEducationProgramOccupationClassService educationProgramOccupationClassService)
    {
        _educationProgramOccupationClassService = educationProgramOccupationClassService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramOccupationClassService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramOccupationClassService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramOccupationClasses.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramOccupationClassRequest createEducationProgramOccupationClassRequest)
    {
        var result = await _educationProgramOccupationClassService.AddAsync(createEducationProgramOccupationClassRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramOccupationClasses.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _educationProgramOccupationClassService.DeleteAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramOccupationClasses.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramOccupationClassRequest updateEducationProgramOccupationClassRequest)
    {
        var result = await _educationProgramOccupationClassService.UpdateAsync(updateEducationProgramOccupationClassRequest);
        return Ok(result);
    }
}
