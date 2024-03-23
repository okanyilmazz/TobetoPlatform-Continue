using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.SessionValidators;
using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.SessionResponses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionsController : Controller
{
    ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _sessionService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetByLessonId")]
    public async Task<IActionResult> GetByLessonIdAsync(Guid lessonId)
    {
        var result = await _sessionService.GetByLessonIdAsync(lessonId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetByAccountAndLessonId")]
    public async Task<IActionResult> GetByAccountAndLessonIdAsync(Guid accountId, Guid lessonId)
    {
        var result = await _sessionService.GetByAccountAndLessonIdAsync(accountId,lessonId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetListWithInstructor")]
    public async Task<IActionResult> GetListWithInstructorAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _sessionService.GetListWithInstructorAsync(pageRequest);
        return Ok(result); 
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetByIdWithInstructor")]
    public async Task<IActionResult> GetByIdWithInstructorAsync(Guid id,[FromQuery] PageRequest pageRequest)
    {
        var result = await _sessionService.GetByIdWithInstructorAsync(id,pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _sessionService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Sessions.Get")]
    [CustomValidation(typeof(CreateSessionRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateSessionRequest createSessionRequest)
    {
        var result = await _sessionService.AddAsync(createSessionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Sessions.Get")]
    [CustomValidation(typeof(UpdateSessionRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSessionRequest updateSessionRequest)
    {
        var result = await _sessionService.UpdateAsync(updateSessionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Sessions.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _sessionService.DeleteAsync(id);
        return Ok(result);
    }
}
