using Business.Abstracts;
using Business.Dtos.Requests.AccountCompetenceTestRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountCompetenceTestsController : ControllerBase
{

    IAccountCompetenceTestService _accountCompetenceTestService;

    public AccountCompetenceTestsController(IAccountCompetenceTestService accountCompetenceTestService)
    {
        _accountCompetenceTestService = accountCompetenceTestService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountCompetenceTestService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountCompetenceTestService.GetByIdAsync(Id);
        return Ok(result);
    }


    //[SecuredOperation("Admin,SuperAdmin")]
    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountCompetenceTest.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountCompetenceTestRequest createAccountCompetenceTestRequest)
    {
        var result = await _accountCompetenceTestService.AddAsync(createAccountCompetenceTestRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountCompetenceTest.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountCompetenceTestRequest deleteAccountCompetenceTestRequest)
    {
        var result = await _accountCompetenceTestService.DeleteAsync(deleteAccountCompetenceTestRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountCompetenceTest.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountCompetenceTestRequest updateAccountCompetenceTestRequest)
    {
        var result = await _accountCompetenceTestService.UpdateAsync(updateAccountCompetenceTestRequest);
        return Ok(result);
    }
}
