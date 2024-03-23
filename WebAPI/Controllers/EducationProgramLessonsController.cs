using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.EducationProgramLessonRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramLessonsController : ControllerBase
{
    IEducationProgramLessonService _educationProgramLessonService;

    public EducationProgramLessonsController(IEducationProgramLessonService educationProgramLessonService)
    {
        _educationProgramLessonService = educationProgramLessonService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramLessonService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramLessonService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramId")]
    public async Task<IActionResult> GetByEducationProgramIdAsync(Guid educationProgramId)
    {
        var result = await _educationProgramLessonService.GetByEducationProgramIdAsync(educationProgramId);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLessons.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramLessonRequest createEducationProgramLessonRequest)
    {
        var result = await _educationProgramLessonService.AddAsync(createEducationProgramLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLessons.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramLessonRequest updateEducationProgramLessonRequest)
    {
        var result = await _educationProgramLessonService.UpdateAsync(updateEducationProgramLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLessons.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _educationProgramLessonService.DeleteAsync(id);
        return Ok(result);
    }
}
