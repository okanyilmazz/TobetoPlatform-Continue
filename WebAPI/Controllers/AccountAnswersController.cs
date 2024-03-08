using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.AccountAnswerValidators;
using Business.Dtos.Requests.AccountAnswerRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountAnswersController : ControllerBase
{
    IAccountAnswerService _accountAnswersService;

    public AccountAnswersController(IAccountAnswerService accountAnswersService)
    {
        _accountAnswersService = accountAnswersService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountAnswersService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountAnswersService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountAnswers.Get")]
    [CustomValidation(typeof(CreateAccountAnswerRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountAnswerRequest createAccountAnswerRequest)
    {
        var result = await _accountAnswersService.AddAsync(createAccountAnswerRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountAnswers.Get")]
    [CustomValidation(typeof(UpdateAccountAnswerRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountAnswerRequest updateAccountAnswerRequest)
    {
        var result = await _accountAnswersService.UpdateAsync(updateAccountAnswerRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountAnswers.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountAnswerRequest deleteAccountAnswerRequest)
    {
        var result = await _accountAnswersService.DeleteAsync(deleteAccountAnswerRequest);
        return Ok(result);
    }
}
