using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramSubjectRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramSubjectsController : ControllerBase
{
    IEducationProgramSubjectService _educationProgramSubjectService;

    public EducationProgramSubjectsController(IEducationProgramSubjectService educationProgramSubjectService)
    {
        _educationProgramSubjectService = educationProgramSubjectService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramSubjectService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramSubjectService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramSubjects.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramSubjectRequest createEducationProgramSubjectRequest)
    {
        var result = await _educationProgramSubjectService.AddAsync(createEducationProgramSubjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramSubjects.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramSubjectRequest updateEducationProgramSubjectRequest)
    {
        var result = await _educationProgramSubjectService.UpdateAsync(updateEducationProgramSubjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramSubjects.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _educationProgramSubjectService.DeleteAsync(id);
        return Ok(result);
    }

}
