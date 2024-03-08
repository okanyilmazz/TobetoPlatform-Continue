using Business.Abstracts;
using Business.Concretes;
using Business.Dtos.Requests.AccountActivityMapRequests;
using Business.Dtos.Requests.AccountBadgeRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountActivityMapsController : ControllerBase
{
    IAccountActivityMapService _accountActivityMapService;

    public AccountActivityMapsController(IAccountActivityMapService accountActivityMapService)
    {
        _accountActivityMapService = accountActivityMapService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountActivityMapService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountActivityMapService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid id)
    {
        var result = await _accountActivityMapService.GetByAccountIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountActivityMaps.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountActivityMapRequest createAccountActivityMapRequest)
    {
        var result = await _accountActivityMapService.AddAsync(createAccountActivityMapRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountActivityMaps.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountActivityMapRequest updateAccountActivityMapRequest)
    {
        var result = await _accountActivityMapService.UpdateAsync(updateAccountActivityMapRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountActivityMaps.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountActivityMapRequest deleteAccountActivityMapRequest)
    {
        var result = await _accountActivityMapService.DeleteAsync(deleteAccountActivityMapRequest);
        return Ok(result);
    }
}
