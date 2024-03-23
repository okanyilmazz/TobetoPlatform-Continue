using Business.Abstracts;
using Business.Dtos.Requests.AccountOccupationClassRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountOccupationClassesController : ControllerBase
{
    IAccountOccupationClassService _accountOccupationClass;

    public AccountOccupationClassesController(IAccountOccupationClassService occupationClassOfAccountService)
    {
        _accountOccupationClass = occupationClassOfAccountService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountOccupationClass.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountOccupationClass.GetByIdAsync(id);
        return Ok(result);
    }




    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountIdAndOccupationClassId")]
    public async Task<IActionResult> GetByAccountIdAndOccupationClassId(Guid accountId, Guid occupationClassId)
    {
        var result = await _accountOccupationClass.GetByAccountIdAndOccupationClassId(accountId, occupationClassId);
        return Ok(result);
    }




    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountOccupationClasses.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountOccupationClassRequest createAccountOccupationClassRequest)
    {
        var result = await _accountOccupationClass.AddAsync(createAccountOccupationClassRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountOccupationClasses.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountOccupationClassRequest updateOccupationClassOfAccountRequest)
    {
        var result = await _accountOccupationClass.UpdateAsync(updateOccupationClassOfAccountRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountOccupationClasses.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _accountOccupationClass.DeleteAsync(id);
        return Ok(result);
    }
}