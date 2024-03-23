using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.AccountValidators;
using Business.Dtos.Requests.AccountRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetStudentBySessionId")]
    public async Task<IActionResult> GetStudentBySessionIdAsync(Guid sessionId)
    {
        var result = await _accountService.GetStudentBySessionIdAsync(sessionId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetInstructorBySessionId")]
    public async Task<IActionResult> GetInstructorBySessionIdAsync(Guid sessionId)
    {
        var result = await _accountService.GetInstructorBySessionIdAsync(sessionId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByLessonIdForLike")]
    public async Task<IActionResult> GetByLessonIdForLikeAsync(Guid lessonId, [FromQuery] PageRequest pageRequest)
    {
        var result = await _accountService.GetByLessonIdForLikeAsync(lessonId, pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramIdForLike")]
    public async Task<IActionResult> GetByEducationProgramIdForLikeAsync(Guid educationProgramId, [FromQuery] PageRequest pageRequest)
    {
        var result = await _accountService.GetByEducationProgramIdForLikeAsync(educationProgramId, pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [CustomValidation(typeof(CreateAccountRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountRequest createAccountRequest)
    {
        var result = await _accountService.AddAsync(createAccountRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [CustomValidation(typeof(UpdateAccountRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountRequest updateAccountRequest)
    {
        var result = await _accountService.UpdateAsync(updateAccountRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _accountService.DeleteAsync(id);
        return Ok(result);
    }
}
