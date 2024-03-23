using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.AccountSkillRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSkillsController : ControllerBase
{
    IAccountSkillService _accountSkillsService;

    public AccountSkillsController(IAccountSkillService accountSkillsService)
    {
        _accountSkillsService = accountSkillsService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountSkillsService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountSkillsService.GetByIdAsync(Id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId, [FromQuery] PageRequest pageRequest)
    {
        var result = await _accountSkillsService.GetByAccountIdAsync(accountId, pageRequest);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSkills.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountSkillRequest createAccountSkillRequest)
    {
        var result = await _accountSkillsService.AddAsync(createAccountSkillRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSkills.Get")]
    [HttpPost("AddRange")]
    public async Task<IActionResult> AddRangeAsync([FromBody] ICollection<CreateAccountSkillRequest> createAccountSkillRequests)
    {
        var result = await _accountSkillsService.AddRangeAsync(createAccountSkillRequests);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSkills.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSkillRequest updateAccountSkillRequest)
    {
        var result = await _accountSkillsService.UpdateAsync(updateAccountSkillRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountSkills.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _accountSkillsService.DeleteAsync(id);
        return Ok(result);
    }
}