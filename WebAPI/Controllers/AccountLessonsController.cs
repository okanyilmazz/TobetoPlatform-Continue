using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.AccountLessonRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountLessonsController : ControllerBase
{
    IAccountLessonService _accountLessonService;

    public AccountLessonsController(IAccountLessonService accountLessonService)
    {
        _accountLessonService = accountLessonService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountLessonService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountLessonService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId)
    {
        var result = await _accountLessonService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountIdAndLessonId")]
    public async Task<IActionResult> GetByAccountIdAndLessonIdAsync(Guid accountId, Guid lessonId)
    {
        var result = await _accountLessonService.GetByAccountIdAndLessonIdAsync(accountId, lessonId);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountLessons.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountLessonRequest createAccountLessonRequest)
    {
        var result = await _accountLessonService.AddAsync(createAccountLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountLessons.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountLessonRequest updateAccountLessonRequest)
    {
        var result = await _accountLessonService.UpdateAsync(updateAccountLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountLessons.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountLessonRequest deleteAccountLessonRequest)
    {
        var result = await _accountLessonService.DeleteAsync(deleteAccountLessonRequest);
        return Ok(result);
    }
}
