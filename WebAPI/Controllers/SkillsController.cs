using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.SkillValidators;
using Business.Dtos.Requests.SkillRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillsController : ControllerBase
{
    ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _skillService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _skillService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid id)
    {
        var result = await _skillService.GetByAccountIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Skills.Get")]
    [CustomValidation(typeof(CreateSkillRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateSkillRequest createSkillRequest)
    {
        var result = await _skillService.AddAsync(createSkillRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Skills.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteSkillRequest deleteSkillRequest)
    {
        var result = await _skillService.DeleteAsync(deleteSkillRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Skills.Get")]
    [CustomValidation(typeof(UpdateSkillRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSkillRequest updateSkillRequest)
    {
        var result = await _skillService.UpdateAsync(updateSkillRequest);
        return Ok(result);
    }
}