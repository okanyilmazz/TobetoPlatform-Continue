using Business.Abstracts;
using Business.Dtos.Requests.AccountViewLessonRequest;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountFavoriteEducationProgramsController : ControllerBase
{
    IAccountFavoriteEducationProgramService _accountFavoriteEducationProgramsService;

    public AccountFavoriteEducationProgramsController(IAccountFavoriteEducationProgramService accountFavoriteEducationProgramsService)
    {
        _accountFavoriteEducationProgramsService = accountFavoriteEducationProgramsService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountFavoriteEducationProgramsService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountFavoriteEducationProgramsService.GetByIdAsync(Id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId)
    {
        var result = await _accountFavoriteEducationProgramsService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramId")]
    public async Task<IActionResult> GetByEducationProgramIdAsync(Guid educationProgramId)
    {
        var result = await _accountFavoriteEducationProgramsService.GetByEducationProgramIdAsync(educationProgramId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountIdAndEducationProgramId")]
    public async Task<IActionResult> GetByAccountIdAndEducationProgramIdAsync(Guid accountId, Guid educationProgramId)
    {
        var result = await _accountFavoriteEducationProgramsService.GetByAccountIdAndEducationProgramIdAsync(accountId, educationProgramId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountFavoriteEducationPrograms.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountFavoriteEducationProgramRequest createAccountFavoriteEducationProgramRequest)
    {
        var result = await _accountFavoriteEducationProgramsService.AddAsync(createAccountFavoriteEducationProgramRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountFavoriteEducationPrograms.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountFavoriteEducationProgramRequest updateAccountFavoriteEducationProgramRequest)
    {
        var result = await _accountFavoriteEducationProgramsService.UpdateAsync(updateAccountFavoriteEducationProgramRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountFavoriteEducationPrograms.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountFavoriteEducationProgramRequest deleteAccountFavoriteEducationProgramRequest)
    {
        var result = await _accountFavoriteEducationProgramsService.DeleteAsync(deleteAccountFavoriteEducationProgramRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountFavoriteEducationPrograms.Get")]
    [HttpPost("DeleteByAccountIdAndEducationProgramId")]
    public async Task<IActionResult> DeleteByAccountIdAndEducationProgramIdAsync([FromBody] DeleteAccountFavoriteEducationProgramRequest deleteAccountFavoriteEducationProgramRequest)
    {
        var result = await _accountFavoriteEducationProgramsService.DeleteByAccountIdAndEducationProgramIdAsync(deleteAccountFavoriteEducationProgramRequest);
        return Ok(result);
    }
}