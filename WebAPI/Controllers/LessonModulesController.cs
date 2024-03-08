using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.LessonModuleValidators;
using Business.Dtos.Requests.LessonModuleRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonModulesController : ControllerBase
{
    ILessonModuleService _lessonModuleService;

    public LessonModulesController(ILessonModuleService lessonsModuleService)
    {
        _lessonModuleService = lessonsModuleService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonModuleService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _lessonModuleService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonModules.Get")]
    [CustomValidation(typeof(CreateLessonModuleRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonModuleRequest createLessonModuleRequest)
    {
        var result = await _lessonModuleService.AddAsync(createLessonModuleRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonModules.Get")]
    [CustomValidation(typeof(UpdateLessonModuleRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonModuleRequest updateLessonModuleRequest)
    {
        var result = await _lessonModuleService.UpdateAsync(updateLessonModuleRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonModules.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLessonModuleRequest deleteLessonModuleRequest)
    {
        var result = await _lessonModuleService.DeleteAsync(deleteLessonModuleRequest);
        return Ok();
    }
}
