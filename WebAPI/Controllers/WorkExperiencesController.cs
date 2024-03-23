using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.WorkExperienceValidators;
using Business.Dtos.Requests.WorkExperienceResquests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkExperiencesController : ControllerBase
{
    IWorkExperienceService _workExperienceService;

    public WorkExperiencesController(IWorkExperienceService examService)
    {
        _workExperienceService = examService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _workExperienceService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _workExperienceService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid accountId)
    {
        var result = await _workExperienceService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("WorkExperiences.Get")]
    [CustomValidation(typeof(CreateWorkExperienceRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateWorkExperienceRequest createWorkExperienceRequest)
    {
        var result = await _workExperienceService.AddAsync(createWorkExperienceRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("WorkExperiences.Get")]
    [CustomValidation(typeof(UpdateWorkExperienceRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateWorkExperienceRequest updateWorkExperienceRequest)
    {
        var result = await _workExperienceService.UpdateAsync(updateWorkExperienceRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("WorkExperiences.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _workExperienceService.DeleteAsync(id);
        return Ok(result);
    }
}