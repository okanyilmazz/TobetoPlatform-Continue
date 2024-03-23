using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.AccountSocialMediaValidators;
using Business.Dtos.Requests.AccountSocialMediaRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSocialMediasController : ControllerBase
{
    IAccountSocialMediaService _accountSocialMediaService;

    public AccountSocialMediasController(IAccountSocialMediaService examService)
    {
        _accountSocialMediaService = examService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountSocialMediaService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountSocialMediaService.GetByIdAsync(Id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId, [FromQuery] PageRequest pageRequest)
    {
        var result = await _accountSocialMediaService.GetByAccountIdAsync(accountId, pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSocialMedias.Get")]
    [CustomValidation(typeof(CreateAccountSocialMediaRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountSocialMediaRequest createAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.AddAsync(createAccountSocialMediaRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSocialMedias.Get")]
    [CustomValidation(typeof(UpdateAccountSocialMediaRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSocialMediaRequest updateAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.UpdateAsync(updateAccountSocialMediaRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSocialMedias.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _accountSocialMediaService.DeleteAsync(id);
        return Ok(result);
    }
}