using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.AccountSessionValidators;
using Business.Dtos.Requests.AccountSessionRequests;
using Business.Dtos.Responses.AccountSessionResponses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSessionsController : ControllerBase
{
    IAccountSessionService _accountSessionService;

    public AccountSessionsController(IAccountSessionService accountSessionService)
    {
        _accountSessionService = accountSessionService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountSessionService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountSessionService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId)
    {
        var result = await _accountSessionService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountAndSessionId")]
    public async Task<IActionResult> GetByAccountAndSessionIdAsync(Guid accountId, Guid sessionId)
    {
        var result = await _accountSessionService.GetByAccountAndSessionIdAsync(accountId, sessionId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSessions.Get")]
    [CustomValidation(typeof(CreateAccountSessionRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountSessionRequest createAccountSessionRequest)
    {
        var result = await _accountSessionService.AddAsync(createAccountSessionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSessions.Get")]
    [CustomValidation(typeof(UpdateAccountSessionRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSessionRequest updateAccountSessionRequest)
    {
        var result = await _accountSessionService.UpdateAsync(updateAccountSessionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSessions.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _accountSessionService.DeleteAsync(id);
        return Ok(result);
    }
}
