using Business.Abstracts;
using Business.Dtos.Requests.AccountBadgeRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountBadgesController : ControllerBase
{
    IAccountBadgeService _accountBadgeService;

    public AccountBadgesController(IAccountBadgeService accountBadgeService)
    {
        _accountBadgeService = accountBadgeService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountBadgeService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountBadgeService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountAndBadgeId")]
    public async Task<IActionResult> GetByAccountAndBadgeIdAsync(Guid accountId, Guid badgeId)
    {
        var result = await _accountBadgeService.GetByAccountAndBadgeIdAsync(accountId, badgeId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid id)
    {
        var result = await _accountBadgeService.GetByAccountIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountBadges.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountBadgeRequest createAccountBadgeRequest)
    {
        var result = await _accountBadgeService.AddAsync(createAccountBadgeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountBadges.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountBadgeRequest updateAccountBadgeRequest)
    {
        var result = await _accountBadgeService.UpdateAsync(updateAccountBadgeRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountBadges.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountBadgeRequest deleteAccountBadgeRequest)
    {
        var result = await _accountBadgeService.DeleteAsync(deleteAccountBadgeRequest);
        return Ok(result);
    }
}
