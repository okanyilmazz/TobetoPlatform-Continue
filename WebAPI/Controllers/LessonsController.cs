using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.LessonValidators;
using Business.Dtos.Requests.LessonRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonsController : ControllerBase
{
    ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramId")]
    public async Task<IActionResult> GetByEducationProgramIdAsync([FromQuery] Guid id)
    {
        var result = await _lessonService.GetByEducationProgramIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid id)
    {
        var result = await _lessonService.GetByAccountIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _lessonService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Lessons.Get")]
    [CustomValidation(typeof(CreateLessonRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonRequest createLessonRequest)
    {
        var result = await _lessonService.AddAsync(createLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Lessons.Get")]
    [CustomValidation(typeof(UpdateLessonRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonRequest updateLessonRequest)
    {
        var result = await _lessonService.UpdateAsync(updateLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Lessons.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _lessonService.DeleteAsync(id);
        return Ok(result);
    }
}
