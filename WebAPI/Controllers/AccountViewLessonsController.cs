using Business.Abstracts;
using Business.Dtos.Requests.AccountViewLessonRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountViewLessonsController : ControllerBase
{
    IAccountViewLessonService _accountViewLessonsService;

    public AccountViewLessonsController(IAccountViewLessonService accountViewLessonsService)
    {
        _accountViewLessonsService = accountViewLessonsService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountViewLessonsService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountViewLessonsService.GetByIdAsync(Id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId)
    {
        var result = await _accountViewLessonsService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByLessonId")]
    public async Task<IActionResult> GetByLessonIdAsync(Guid lessonId)
    {
        var result = await _accountViewLessonsService.GetByLessonIdAsync(lessonId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountIdAndLessonId")]
    public async Task<IActionResult> GetByAccountIdAndLessonIdAsync(Guid accountId,Guid lessonId)
    {
        var result = await _accountViewLessonsService.GetByAccountIdAndLessonIdAsync(accountId, lessonId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountViewLessons.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountViewLessonRequest createAccountViewLessonRequest)
    {
        var result = await _accountViewLessonsService.AddAsync(createAccountViewLessonRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountViewLessons.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountViewLessonRequest updateAccountViewLessonRequest)
    {
        var result = await _accountViewLessonsService.UpdateAsync(updateAccountViewLessonRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountViewLessons.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _accountViewLessonsService.DeleteAsync(id);
        return Ok(result);
    }
}